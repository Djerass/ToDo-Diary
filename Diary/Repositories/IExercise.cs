using System.Linq;
using System.Threading.Tasks;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public interface IExercise
    {
        IQueryable<MuscleGroup> GetMuscleGroups();
        IQueryable<Exercise> GetAllExercises();
        Task Add(Exercise exercise);
        Task Delete(int id);
        Task Edit(Exercise exercise);
        Exercise FindId(int id);
    }
}