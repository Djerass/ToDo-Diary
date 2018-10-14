using System.Collections;
using System.Collections.Generic;
using ToDoDiaryWeb.Models;

namespace ToDoDiaryWeb.ViewModels
{
    public class WorkoutViewModel
    {
        public IEnumerable<Training> Trainings { get; set; }
        public Training Workout { get; set; }

        
    }
}