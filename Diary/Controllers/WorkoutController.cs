using System;
using System.Linq;
using System.Threading.Tasks;
using Diary.Models;
using Diary.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;
using ToDoDiaryWeb.ViewModels;

namespace ToDoDiaryWeb.Controllers
{
    public class WorkoutController : CookieController
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
            
            var userId = _id.TakeId(this.User);
            var date = ReadDateCookie("DateListofTraining");
            ViewData["DateListofTraining"]=date.ToShortDateString();
           // return PartialView("_ListOfWorkouts",new WorkoutViewModel(){Trainings =_db.GetAll().Where(x=>x.UserId==userId).Where(x=>x.Date.Date==DateRes.Date).ToList()});
            return PartialView("pvListOfWorkouts",new WorkoutViewModel(){Trainings = await _db.GetAll().Where(x=>x.UserId==userId).Where(x=>x.Date.Date==date.Date).ToListAsync()});
        }

        [HttpPost]
        public async Task<IActionResult> Add(WorkoutViewModel training)
        {
            
          
            var date = ReadDateCookie("DateListofTraining");
            var userId = _id.TakeId(this.User);
            await  _db.Add(new Training(){ExerciseId = training.Workout.ExerciseId,UserId = userId,Weight = training.Workout.Weight,Count = training.Workout.Count,Date = date});
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






    }

  
}