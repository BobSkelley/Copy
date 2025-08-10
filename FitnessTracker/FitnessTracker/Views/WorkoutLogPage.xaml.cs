using FitnessTracker.ViewModels;

namespace FitnessTracker.Views
{
    public partial class WorkoutLogPage : ContentPage
    {
        public WorkoutLogPage(WorkoutViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}