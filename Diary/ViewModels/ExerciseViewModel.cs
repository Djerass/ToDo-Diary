using System.Collections.Generic;
using ToDoDiaryWeb.Models;

namespace ToDo_Diary.ViewModels
{
    public class ExerciseViewModel
    {
        public IEnumerable<Exercise>  Exercises { get; set; }
        public IEnumerable<MuscleGroup> MuscleGroups { get; set; }
        public int Stance { get; set; }
    }
}