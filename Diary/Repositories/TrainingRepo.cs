using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public class TrainingRepo:ITraining
    {
        private readonly ToDoContext _db;

        public TrainingRepo(ToDoContext db)
        {
            _db = db;
        }
        public IQueryable<Training> GetAll() => _db.Trainings.Include(i=>i.Exercise);
        public IQueryable<Exercise> GetAllExercises() => _db.Exercises.Include(i=>i.MuscleGroup);

        public async Task Delete(int id)
        {
            var res = _db.Trainings.FirstOrDefault(i=>i.Id==id);
            if (res != null)
            {
                _db.Trainings.Remove(res);
            }

            await _db.SaveChangesAsync();
        }

        public async Task Add(Training training)
        {
            _db.Trainings.Add(training);
            await _db.SaveChangesAsync();
        }
    }
}