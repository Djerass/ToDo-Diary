using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoDiaryWeb.Models
{
    public class MuscleRepo:IMuscle
    {
        private readonly ToDoContext _db;

        public MuscleRepo(ToDoContext db)
        {
            _db = db;
        }
        public IQueryable<MuscleGroup> GetAll() => _db.MuscleGroups.Include(p=>p.Exercises);

        public async Task Delete(int id)
        {
           var res= _db.MuscleGroups.FirstOrDefault(i=>i.Id==id);
            if (res != null)
            {
                _db.MuscleGroups.Remove(res);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Add(MuscleGroup mg)
        {
                _db.Add(mg);
            await _db.SaveChangesAsync();
        }

        public async Task Edit(MuscleGroup mg)
        {
            var res = _db.MuscleGroups.FirstOrDefault(i=>i.Id==mg.Id);
            if (res != null)
            {
                res.Name = mg.Name;
                await _db.SaveChangesAsync();
            }
        }

        public MuscleGroup Find(int id) => _db.MuscleGroups.FirstOrDefault(i => i.Id == id);


    }
}