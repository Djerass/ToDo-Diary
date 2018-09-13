using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDo_Diary.Models;

namespace ToDoDiaryWeb.Models
{
    public class ToDoContext:IdentityDbContext<User>
    {
        public ToDoContext(DbContextOptions<ToDoContext> options):base(options)
        {
            
        }
       public DbSet<ToDo> ToDos{get;set;}
    }
}