using System.Linq;
using System.Threading.Tasks;

namespace ToDoDiaryWeb.Models
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _db;
        public ToDoRepository(ToDoContext db)
        {
            _db=db;
           
        }
        public IQueryable<ToDo> GetAll => _db.ToDos;

        public async Task Add(ToDo todo)
        {
           _db.ToDos.Add(todo);
           await _db.SaveChangesAsync();
        }

        public async Task ChangeStatus(int Id)
        {
            var done = _db.ToDos.FirstOrDefault(x=>x.Id==Id);
            if(done!=null)
            {
                done.Status=!done.Status;
                await _db.SaveChangesAsync();
            }

        }

        public async Task Delete(int Id)
        {
             var done = _db.ToDos.FirstOrDefault(x=>x.Id==Id);
            if(done!=null)
            {
                _db.ToDos.Remove(done);
                await _db.SaveChangesAsync();
            }
        }
    }
}