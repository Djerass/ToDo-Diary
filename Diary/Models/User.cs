using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ToDoDiaryWeb.Models;

namespace ToDo_Diary.Models
{
    public class User:IdentityUser
    {
        public int Year { get; set; }
        
        public double Weight{get;set;}
       
        public int Height{get;set;}
        
        public List<ToDo> ToDos { get; set; }
        public List<Training> Trainings { get; set; }
    }
}