using FitnessTracker.ViewModels;

namespace FitnessTracker.Views
{
    public partial class UserProfilePage : ContentPage
    {
        public UserProfilePage(UserProfileViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}