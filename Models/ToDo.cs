using System;
using System.ComponentModel.DataAnnotations;
using ToDo_Diary.Models;

namespace ToDoDiaryWeb.Models
{
    public class ToDo
    {
        public int Id{get;set;}
        
        
        [DataType(DataType.DateTime)]
        public DateTime Date {get;set;}
        
        [Required]
        public string Description {get;set;}

        public bool Status {get;set;}

       public string UserId{get;set;}
       public User User{get;set;}

    }
}