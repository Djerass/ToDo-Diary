using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;
using ToDo_Diary.ViewModels;

namespace ToDoDiaryWeb.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExercise _db;

        private int _stance;
        
        public ExerciseController(IExercise db)
        {
            _db=db;
            _stance = -1;
            
            ViewBag.MuscleGroups = db.GetMuscleGroups().ToList();

        }

        public IActionResult Index()
        {
            if (_stance!=-1)
            return View(_db.GetAllExercises().Where(i=>i.MuscleGroupId ==_stance).ToList());
            else
            {
                return View(_db.GetAllExercises().ToList());
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

        public IActionResult ChangeStance(int id)
        {
            _stance = id;
            return RedirectToAction("Index");
        }

        public IActionResult Group()
        {
            ViewBag.MuscleGroups = _db.GetMuscleGroups().ToList();
            return PartialView("_Group");
        }

        public IActionResult _Group(StanceViewModel stanceViewModel)
        {
            _stance = stanceViewModel.Id;
            return RedirectToAction("Index");
        }
        

    }
}