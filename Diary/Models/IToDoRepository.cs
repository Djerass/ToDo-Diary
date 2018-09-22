using System.Linq;
using System.Threading.Tasks;

namespace ToDoDiaryWeb.Models
{
    public interface IToDoRepository
    {
        IQueryable<ToDo> GetAll{get;}
        Task Add(ToDo todo);
        Task ChangeStatus(int Id);
        Task Delete(int id);

    }
}