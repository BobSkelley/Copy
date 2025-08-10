namespace FitnessTracker.Models
{
    public class Goal
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public double TargetValue { get; set; }
        public double CurrentValue { get; set; }
        public double Progress => (TargetValue > 0) ? (CurrentValue / TargetValue) : 0;
        public string ProgressText => $"{CurrentValue} / {TargetValue}";
    }
}