using System;
using System.Collections.Generic;
using System.Linq;
using ToDoDiaryWeb.Models;

namespace Diary.Service
{
    public class Statistic
    {
       private readonly ToDo[] _toDos;
        public Statistic(ToDo[] toDos)
        {
            _toDos=toDos;
        }

        public int CountAll=>_toDos.Length;
        public int CountNotFinished=>_toDos.Count(i => i.Status==false);

        public int CountFailed=>_toDos.Count(x => x.Status==false&&x.Date<=DateTime.Now);

         public  IEnumerable<ToDo> Failed()
        {
            return _toDos.Where(x=>x.Status==false&&x.Date<=DateTime.Now);
        }
        
    }
}