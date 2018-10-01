using System.Collections.Generic;

namespace ToDoDiaryWeb.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string  Name{ get; set; }
        public string Technique { get; set; }
        public string VideoUrl { get; set; }
        public string ImgUrl { get; set;  }

        public int MuscleGroupId { get; set; }
        public MuscleGroup MuscleGroup { get; set; }

        public List<Training> Trainings { get; set; }
    }
}