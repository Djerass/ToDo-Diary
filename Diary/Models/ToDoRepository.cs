using System.Collections.Generic;
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
        public IEnumerable<ToDo> GetAll => _db.ToDos;

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
        public ToDo Find(int Id)=>      
           _db.ToDos.FirstOrDefault(r=>r.Id==Id);

        public async Task Update(ToDo toDo)
        {
            var res = _db.ToDos.FirstOrDefault(r=>r.Id==toDo.Id);
            if(res!=null)
                {
                    res.Date=toDo.Date;
                    res.Status=toDo.Status;
                    res.Description=toDo.Description;
                    await _db.SaveChangesAsync();
                }
        }
    }
}