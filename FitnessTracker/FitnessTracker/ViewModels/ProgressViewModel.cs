using Microcharts;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace FitnessTracker.ViewModels
{
    public class WeeklySummary
    {
        public string Title { get; set; } = string.Empty;
        public string PrimaryMetric { get; set; } = string.Empty;
        public Brush Background { get; set; } = new SolidColorBrush(Colors.Transparent);
        public Chart? Chart { get; set; }
    }

    public class ProgressViewModel : BaseViewModel
    {
        public ObservableCollection<WeeklySummary> WeeklySummaries { get; }
        public int AverageHeartRate { get; set; }

        public ProgressViewModel()
        {
            WeeklySummaries = new ObservableCollection<WeeklySummary>();
            LoadData();
        }

        private void LoadData()
        {
            // Weekly summary data
            WeeklySummaries.Add(new WeeklySummary { Title = "Week 3", PrimaryMetric = "150 km", Background = new LinearGradientBrush(new GradientStopCollection { new GradientStop(Color.FromArgb("#62E48C"), 0), new GradientStop(Color.FromArgb("#22B551"), 1) }), Chart = new DonutChart { Entries = new[] { new ChartEntry(150) { Color = SKColors.White } }, HoleRadius = 0.75f, BackgroundColor = SKColors.Transparent, LabelMode = LabelMode.None } });
            WeeklySummaries.Add(new WeeklySummary { Title = "Week 2", PrimaryMetric = "400 km", Background = new LinearGradientBrush(new GradientStopCollection { new GradientStop(Color.FromArgb("#68B9C0"), 0), new GradientStop(Color.FromArgb("#3D858C"), 1) }), Chart = new DonutChart { Entries = new[] { new ChartEntry(400) { Color = SKColors.White } }, HoleRadius = 0.75f, BackgroundColor = SKColors.Transparent, LabelMode = LabelMode.None } });
            WeeklySummaries.Add(new WeeklySummary { Title = "Week 1", PrimaryMetric = "200 km", Background = new LinearGradientBrush(new GradientStopCollection { new GradientStop(Color.FromArgb("#266489"), 0), new GradientStop(Color.FromArgb("#163A50"), 1) }), Chart = new DonutChart { Entries = new[] { new ChartEntry(200) { Color = SKColors.White } }, HoleRadius = 0.75f, BackgroundColor = SKColors.Transparent, LabelMode = LabelMode.None } });

            // Sample average heart rate
            AverageHeartRate = 72;
        }
    }
}