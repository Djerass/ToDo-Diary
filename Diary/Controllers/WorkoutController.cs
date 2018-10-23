using System;
using System.Linq;
using System.Threading.Tasks;
using Diary.Models;
using Diary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;
using ToDoDiaryWeb.ViewModels;

namespace ToDoDiaryWeb.Controllers
{
    public class WorkoutController : Controller
    {
        private readonly ITraining _db;

        private readonly Iid _id;

        public WorkoutController(ITraining db,Iid id)
        {
            _db = db;
            _id = id;
        }
        // GET
        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> ListofTask()
        {
            ViewBag.Exercises = _db.GetAllExercises().OrderBy(i=>i.MuscleGroupId).ToList();
            string dateCookie;
            //check: Are we allready have DateCookie  
            //if  we have theirs  - read
            //if we haven`t create default
            try
            {
                dateCookie=Request.Cookies["DateListofTraining"].ToString();
            }
            catch(NullReferenceException)
            {
                dateCookie=DateTime.Now.Date.ToString();
            }
            DateTime.TryParse(dateCookie,out DateTime DateRes);
            var userId = _id.TakeId(this.User);
            ViewData["DateListofTraining"]=DateRes.ToShortDateString();
           // return PartialView("_ListOfWorkouts",new WorkoutViewModel(){Trainings =_db.GetAll().Where(x=>x.UserId==userId).Where(x=>x.Date.Date==DateRes.Date).ToList()});
            return PartialView("_ListOfWorkouts",new WorkoutViewModel(){Trainings = await _db.GetAll().Where(x=>x.UserId==userId).Where(x=>x.Date.Date==DateRes.Date).ToListAsync()});
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutViewModel training)
        {
            
            string dateCookie;
            //check: Are we allready have DateCookie  
            //if  we have theirs  - read
            //if we haven`t create default
            try
            {
                dateCookie=Request.Cookies["DateListofTraining"].ToString();
            }
            catch(NullReferenceException)
            {
                dateCookie=DateTime.Now.Date.ToString();
            }
            DateTime.TryParse(dateCookie,out DateTime DateRes);
            var userId = _id.TakeId(this.User);
            await  _db.Add(new Training(){ExerciseId = training.Workout.ExerciseId,UserId = userId,Weight = training.Workout.Weight,Count = training.Workout.Count,Date = DateRes});
            return RedirectToAction("ListofTask");
            
        }

        public async Task<IActionResult> StatPage()
        {
            ViewBag.Exercises = await _db.GetAllExercises().OrderBy(i=>i.MuscleGroupId).ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Statistic(StatPageViewModel spViewModel)
        {
            var ws = new WorkoutStatistic(await _db.GetAll().ToListAsync(),spViewModel.StartDate,spViewModel.EndDate,spViewModel.ExerciseId);
            ViewBag.exerciseName = ws.ExerciseName();
            ViewBag.count = ws.Count;
            return  View(ws.ToModel());
        }

        public IActionResult ChooseDate(DateTime dateTime)
        {
            SwapCookie("DateListofTraining",dateTime.ToShortDateString());
            return RedirectToAction("ListofTask");
        }

        public async Task<IActionResult> DeleteEx(int id)
        {
            await _db.Delete(id);
            return RedirectToAction("Index");
        }
        
        //Delete old cookies and add new
        private void SwapCookie(string key,string value)
        {
            Response.Cookies.Delete(key);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append(key,value,cookie);
        }
    }

  
}