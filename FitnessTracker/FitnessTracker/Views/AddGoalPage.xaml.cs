using FitnessTracker.ViewModels;

namespace FitnessTracker.Views
{
    public partial class AddGoalPage : ContentPage
    {
        public AddGoalPage(AddGoalViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}