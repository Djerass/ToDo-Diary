using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoDiaryWeb.Models
{
    public interface IToDoRepository
    {
        IEnumerable<ToDo> GetAll{get;}
        Task Add(ToDo todo);
        Task ChangeStatus(int Id);
        Task Delete(int id);
        ToDo Find(int id);
        Task Update(ToDo Id);
    }
}