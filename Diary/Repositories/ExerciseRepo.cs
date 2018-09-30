using System.Linq;
using System.Threading.Tasks;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public class ExerciseRepo:IExercise
    {
        private readonly ToDoContext _db;

        public ExerciseRepo(ToDoContext db)
        {
            _db = db;
        }


        public IQueryable<MuscleGroup> GetMuscleGroups() => _db.MuscleGroups;

        public IQueryable<Exercise> GetAllExercises() => _db.Exercises;

        public async Task Add(Exercise exercise )
        {
            _db.Exercises.Add(exercise);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var res = _db.Exercises.FirstOrDefault(i => i.Id == id);
            if (res != null)
            {
                _db.Exercises.Remove(res);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Edit(Exercise exercise)
        {
            var res = _db.Exercises.FirstOrDefault(i => i.Id == exercise.Id);
            if (res != null)
            {
                res.Name = exercise.Name;
                res.Technique = exercise.Technique;
                res.Trainings = exercise.Trainings;
                res.Url = exercise.Url;
                res.MuscleGroupId = exercise.MuscleGroupId;
                await _db.SaveChangesAsync();
            }
        }

        public Exercise FindId(int id) => _db.Exercises.FirstOrDefault(i => i.Id == id);
    }
}