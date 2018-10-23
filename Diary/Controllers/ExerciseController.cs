using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;
using ToDo_Diary.ViewModels;

namespace ToDoDiaryWeb.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExercise _db;

        private  int _stance;
        
        public ExerciseController(IExercise db)
        {
            _db=db;
            
         
            ViewBag.MuscleGroups = _db.GetMuscleGroups().ToList();
            

        }

        public IActionResult Index()
        {
            _stance=ReadCookie();
            if(_stance==-1||_stance==0)
            {
                var model = new ExerciseViewModel(){Exercises = _db.GetAllExercises().OrderBy(i=>i.MuscleGroupId).ToList(),MuscleGroups = _db.GetMuscleGroups().ToList()};
                return View(model);
            }
            else
            {
                var model = new ExerciseViewModel(){Exercises = _db.GetAllExercises().Where(i=>i.MuscleGroupId==_stance).ToList(),MuscleGroups = _db.GetMuscleGroups().ToList()};
                return View(model);
            }
            

        }

        public IActionResult ListofEx()
        {
             _stance=ReadCookie();
            if(_stance==-1||_stance==0)
            {
                var model = new ExerciseViewModel(){Exercises = _db.GetAllExercises().OrderBy(i=>i.MuscleGroupId).ToList(),MuscleGroups = _db.GetMuscleGroups().ToList()};
                return PartialView("pvListofEx", model);
            }
            else
            {
                var model = new ExerciseViewModel(){Exercises = _db.GetAllExercises().Where(i=>i.MuscleGroupId==_stance).ToList(),MuscleGroups = _db.GetMuscleGroups().ToList()};
                return PartialView("pvListofEx", model);
            }
            
        }

        public IActionResult Add()
        {
            ViewBag.MuscleGroups = _db.GetMuscleGroups().ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Exercise exercise)
        {
            await _db.Add(exercise);
            return RedirectToAction("Index");
        }

        public IActionResult More(int id) => View(_db.FindId(id));

        public  async Task<IActionResult> Delete(int id)
        {
            await _db.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.MuscleGroups = _db.GetMuscleGroups().ToList();
            return View(_db.FindId(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Exercise exercise)
        {
            await _db.Edit(exercise);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult ChangeStance(ExerciseViewModel model)
        {
            

            SetCookie("ShowMuscle",model.Stance);
            return RedirectToAction("ListofEx");

        }

        [HttpPost]
        public IActionResult DropStance()
        {
            SetCookie("ShowMuscle",-1);
            return RedirectToAction("Index");
        }

        public IActionResult Group()
        {
            
            var model = new ExerciseViewModel(){MuscleGroups = _db.GetMuscleGroups().ToList()};
            return PartialView("pvGroup",model);
        }

        private int ReadCookie()
        {
            int result=-1;
            try
            {
                if (Request.Cookies.TryGetValue("ShowMuscle", out var res))
                        int.TryParse(res, out result);
            }
            catch (NullReferenceException e)
            {
                

            }
            
            return result;
        }

        private void SetCookie(string key,int value)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(3);
            Response.Cookies.Append(key,value.ToString(),cookieOptions);
        }
                
        

    }
}