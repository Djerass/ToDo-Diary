using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ToDoDiaryWeb.Models;
using ToDoDiaryWeb.ViewModels;

namespace Diary.Service
{
    public class WorkoutStatistic
    {
        private IEnumerable<Training> workout;
        private DateTime startDate;
        private DateTime endDate;
        private int exerciseId;
        public WorkoutStatistic(IEnumerable<Training> workout,DateTime startDate,DateTime endDate, int exerciseId)
        {
            this.workout = workout;
            this.startDate = startDate;
            this.endDate = endDate;
            this.exerciseId = exerciseId;

        }

        public int Count => workout.Count(x => x.ExerciseId==exerciseId);

        public string ExerciseName()
        {
            var res = workout.FirstOrDefault(x => x.ExerciseId == exerciseId);
            return res == null ? "Without name" : res.Exercise.Name;
        }
        public List<WorkoutStatisticViewModel> ToModel()
        {
          
            
            var res = (from n in workout
                where (n.Date.Date >= startDate.Date && n.Date.Date <= endDate.Date && n.ExerciseId == exerciseId)
                group n by n.Date
                into g
                select new WorkoutStatisticViewModel()
                {
                    Date = g.Key.ToShortDateString(),
                    MaxWeight = (from r in g
                        select r.Weight).Max()
                }).OrderBy(x=>x.Date);
                
            return res.ToList();

        }
    }
}