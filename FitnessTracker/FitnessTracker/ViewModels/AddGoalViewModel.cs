using FitnessTracker.Models;
using FitnessTracker.Services;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessTracker.ViewModels
{
    public class AddGoalViewModel : BaseViewModel
    {
        private readonly AppDataService _appDataService;
        private string _description = string.Empty;
        private double _targetValue;

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public double TargetValue
        {
            get => _targetValue;
            set => SetProperty(ref _targetValue, value);
        }

        public ICommand SaveGoalCommand { get; }

        public AddGoalViewModel(AppDataService appDataService)
        {
            _appDataService = appDataService;
            SaveGoalCommand = new Command(async () => await SaveGoal());
        }

        private async Task SaveGoal()
        {
            if (string.IsNullOrWhiteSpace(Description) || TargetValue <= 0 || TargetValue > 999999999)
            {
                await Shell.Current.DisplayAlert("Error", "Please enter a valid description and a target value less than 1,000,000,000.", "OK");
                return;
            }

            var newGoal = new Goal
            {
                Description = this.Description,
                TargetValue = this.TargetValue,
                CurrentValue = 0
            };

            await _appDataService.AddGoal(newGoal);

            await Shell.Current.DisplayAlert("Success", "Goal saved successfully.", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}