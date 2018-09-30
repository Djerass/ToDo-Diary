using System.Linq;
using System.Threading.Tasks;

namespace ToDoDiaryWeb.Models
{
    public interface IMuscle
    {
        IQueryable<MuscleGroup> GetAll();
        Task Delete(int id);
        Task Add(MuscleGroup muscleGroup);
        Task Edit(MuscleGroup muscleGroup);
        MuscleGroup Find(int id);
    }
}