using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessTracker.Models;
using FitnessTracker.Services;
using FitnessTracker.Views;
using System.Linq;

namespace FitnessTracker.ViewModels
{
    public class GoalsViewModel : BaseViewModel
    {
        private readonly AppDataService _appDataService;
        public ObservableCollection<Goal> Goals { get; }

        public ICommand AddGoalCommand { get; }
        public ICommand AppearingCommand { get; }
        public ICommand UpdateGoalCommand { get; }
        public ICommand DeleteGoalCommand { get; }

        public GoalsViewModel(AppDataService appDataService)
        {
            _appDataService = appDataService;
            Goals = new ObservableCollection<Goal>();

            AddGoalCommand = new Command(async () => await GoToAddGoalPage());
            AppearingCommand = new Command(LoadGoals);
            UpdateGoalCommand = new Command<Goal>(async (goal) => await UpdateGoal(goal));
            DeleteGoalCommand = new Command<Goal>(async (goal) => await DeleteGoal(goal));

            LoadGoals();
        }

        private void LoadGoals()
        {
            Goals.Clear();
            var goals = _appDataService.GetGoals();
            if (goals != null && goals.Count == 0)
            {
                goals.Add(new Goal { Description = "Run 10 km", TargetValue = 10, CurrentValue = 5.2 });
                goals.Add(new Goal { Description = "Lift 100 kg", TargetValue = 100, CurrentValue = 85 });
                goals.Add(new Goal { Description = "Workout 5 times a week", TargetValue = 5, CurrentValue = 3 });
            }

            if (goals != null)
            {
                foreach (var goal in goals)
                {
                    Goals.Add(goal);
                }
            }
        }

        private async Task UpdateGoal(Goal goal)
        {
            if (goal == null) return;

            string newValue = await Shell.Current.DisplayPromptAsync($"Update {goal.Description}", "Enter your new progress:", "OK", "Cancel", initialValue: goal.CurrentValue.ToString(), keyboard: Keyboard.Numeric);

            if (double.TryParse(newValue, out double newProgress))
            {
                if (newProgress > 999999999)
                {
                    await Shell.Current.DisplayAlert("Error", "Please enter a value less than 1,000,000,000.", "OK");
                    return;
                }

                goal.CurrentValue = newProgress;
                await _appDataService.SaveGoals(Goals.ToList());
                LoadGoals(); // Refresh UI
            }
        }

        private async Task DeleteGoal(Goal goal)
        {
            if (goal == null) return;

            bool confirm = await Shell.Current.DisplayAlert("Confirm", $"Are you sure you want to delete the goal '{goal.Description}'?", "Yes", "No");
            if (confirm)
            {
                await _appDataService.RemoveGoal(goal);
                LoadGoals();
            }
        }

        private async Task GoToAddGoalPage()
        {
            await Shell.Current.GoToAsync(nameof(AddGoalPage));
        }
    }
}