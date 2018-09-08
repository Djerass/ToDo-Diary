using System;
using System.Linq;

namespace ToDoDiaryWeb.Models
{
    public class SeedData
    {
         public static void EnsurePopulated(ToDoContext context)
         {
             if(!context.ToDos.Any())
             {
                 context.ToDos.AddRange(
                     new ToDo{Description="GYM Leg`d day",Status=true,Date=new DateTime(2018,09,04,07,00,00)},
                     new ToDo{Description="Go to job",Status=true,Date=new DateTime(2018,09,04,09,30,00)},
                     new ToDo{Description="Read about IDisposable",Status=false,Date=new DateTime(2018,09,04,12,00,00)},
                     new ToDo{Description="Sleep",Status=false,Date=new DateTime(2018,09,04,14,00,00)},
                     new ToDo{Description="Working",Status=true,Date=new DateTime(2018,09,04,18,00,00)},
                     new ToDo{Description="Read about Exel",Status=false,Date=new DateTime(2018,09,04,15,00,00)},
                     new ToDo{Description="English Lesson",Status=false,Date=new DateTime(2018,09,16,17,00,00)},
                     new ToDo{Description="Go to home",Status=true,Date=new DateTime(2018,09,04,19,45,00)},
                     new ToDo{Description="Drive school",Status=true,Date=new DateTime(2018,09,04,22,00,00)},
                     new ToDo{Description="C# Practice",Status=false,Date=new DateTime(2018,09,04,23,00,00)}

                 );

             }


             context.SaveChanges();
         }
    }
}