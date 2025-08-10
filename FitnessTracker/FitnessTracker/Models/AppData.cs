using System.Collections.Generic;

namespace FitnessTracker.Models
{
    public class AppData
    {
        public UserProfile UserProfile { get; set; } = new();
        public List<Workout> Workouts { get; set; } = new();
        public List<Goal> Goals { get; set; } = new();
    }
}