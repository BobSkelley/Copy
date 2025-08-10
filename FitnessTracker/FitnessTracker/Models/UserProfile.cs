using System;

namespace FitnessTracker.Models
{
    public enum FitnessLevel { Beginner, Intermediate, Advanced }

    public class UserProfile
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public double Height { get; set; } // in cm
        public double Weight { get; set; } // in kg
        public FitnessLevel FitnessLevel { get; set; } = FitnessLevel.Beginner;
    }
}