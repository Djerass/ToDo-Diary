using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.Repositories;

namespace ToDoDiaryWeb.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExercise _db;

        public ExerciseController(IExercise db)
        {
            _db=db;
        }

        public IActionResult Index() => View(_db.GetAllExercises().ToList());

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
    }
}