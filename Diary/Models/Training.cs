using System;
using System.ComponentModel.DataAnnotations;
using ToDo_Diary.Models;

namespace ToDoDiaryWeb.Models
{
    public class Training
    {
        public int Id { get; set; }
        
        public DateTime Date { get; set; }
        
        [Required]
        public double Weight { get; set; }
        [Required]
        public int Count { get; set; }
       
        public string UserId { get; set; }
        public User User { get; set; }

        [Required]
        public int ExerciseId { get; set; }
        public Exercise Exercise { get;set; }

    }
}