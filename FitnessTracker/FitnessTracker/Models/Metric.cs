namespace FitnessTracker.Models
{
    public class Metric
    {
        public int ID { get; set; }
        public int WorkoutID { get; set; }
        public string Type { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}