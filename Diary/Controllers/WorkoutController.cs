using System;
using System.Linq;
using Diary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ViewBag.Exercises = _db.GetAllExercises().OrderBy(i=>i.MuscleGroupId).ToList();
            return
            View(new WorkoutViewModel(){Trainings =_db.GetAll().ToList()});
        }

        public IActionResult ListofTask()
        {
            
            return PartialView("_ListOfWorkouts",new WorkoutViewModel(){Trainings =_db.GetAll().ToList()});
        }

        [HttpPost]
        public IActionResult Add(WorkoutViewModel training)
        {
            return RedirectToAction("Index");
        }
        
        private void SwapCookie(string key,string value)
        {
            Response.Cookies.Delete(key);
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(3);       
            Response.Cookies.Append(key,value,cookie);
        }
    }
}