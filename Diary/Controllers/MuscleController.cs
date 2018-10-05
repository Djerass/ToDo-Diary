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
        //Show all muscle groups
        public IActionResult Index()
        {
            return View(_db.GetAll().ToList());
        }

        //Add muscle group
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        //Add muscle group
        [HttpPost]
        public async Task<IActionResult> Add(MuscleGroup muscleGroup)
        {
            await _db.Add(muscleGroup);
            return  RedirectToAction("Index");

        }

        //Delete muscle group
        public async Task<IActionResult> Delete(int id)
        {
          await  _db.Delete(id);
            return RedirectToAction("Index");
        }

        //Find muscle group for update
        [HttpGet]
        public IActionResult Update(int id) => View(_db.Find(id));

        //Updating muscle group
        [HttpPost]
        public async Task<IActionResult> Update(MuscleGroup muscleGroup)
        {
            await _db.Edit(muscleGroup);
            return RedirectToAction("Index");
            
        }
        
    }
}