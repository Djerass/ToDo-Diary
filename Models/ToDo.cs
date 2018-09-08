using System;
using System.ComponentModel.DataAnnotations;

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
    }
}