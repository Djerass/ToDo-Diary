using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Controllers
{
    public class MuscleController : Controller
    {
        private readonly IMuscle _db;

        public MuscleController(IMuscle db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.GetAll().ToList());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MuscleGroup muscleGroup)
        {
            await _db.Add(muscleGroup);
            return  RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete(int id)
        {
          await  _db.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id) => View(_db.Find(id));

        [HttpPost]
        public async Task<IActionResult> Update(MuscleGroup muscleGroup)
        {
            await _db.Edit(muscleGroup);
            return RedirectToAction("Index");
            
        }
        
    }
}