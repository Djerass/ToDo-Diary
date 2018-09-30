using System.Collections.Generic;

namespace ToDoDiaryWeb.Models
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}