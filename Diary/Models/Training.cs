using System;
using ToDo_Diary.Models;

namespace ToDoDiaryWeb.Models
{
    public class Training
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        public double Weight { get; set; }
        public int Count { get; set; }
       
        public string UserId { get; set; }
        public User User { get; set; }

        public int ExerciseId { get; set; }
        public Exercise Exercise { get;set; }

    }
}