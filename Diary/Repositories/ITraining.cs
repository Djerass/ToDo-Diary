using System.Linq;
using System.Threading.Tasks;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.Repositories
{
    public interface ITraining
    {
        IQueryable<Training> GetAll();
        IQueryable<Exercise> GetAllExercises();
        Task Delete(int id);
        Task Add(Training training);
    }
}