using FitnessTracker.Views;

namespace FitnessTracker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnNewWorkoutClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(WorkoutLogPage));
        }

        private async void OnViewProgressClicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ProgressPage");
        }
    }
}