using System;
using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int ID { get; set; }
        public int AthleteID { get; set; }
        public string ExerciseType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public List<Metric> Metrics { get; set; } = new List<Metric>();
    }
}