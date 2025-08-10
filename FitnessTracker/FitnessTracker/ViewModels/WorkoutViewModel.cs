using FitnessTracker.Models;
using FitnessTracker.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using FitnessTracker.Views;

namespace FitnessTracker.ViewModels;

public class WorkoutViewModel : BaseViewModel
{
    private readonly WorkoutManager _workoutManager;
    private bool _isRefreshing;

    public ObservableCollection<Workout> Workouts { get; } = new();
    public ICommand LoadWorkoutsCommand { get; }
    public ICommand AddWorkoutCommand { get; }

    public bool IsRefreshing
    {
        get => _isRefreshing;
        set => SetProperty(ref _isRefreshing, value);
    }

    public WorkoutViewModel(WorkoutManager workoutManager)
    {
        _workoutManager = workoutManager;

        LoadWorkoutsCommand = new Command(async () => await LoadWorkouts());
        AddWorkoutCommand = new Command(async () => await AddWorkout());
    }

    private async Task LoadWorkouts()
    {
        IsRefreshing = true;

        Workouts.Clear();
        var workouts = _workoutManager.GetWorkouts();
        if (workouts != null)
        {
            foreach (var workout in workouts.OrderByDescending(w => w.Date))
            {
                Workouts.Add(workout);
            }
        }

        IsRefreshing = false;
        await Task.CompletedTask; // To satisfy async warning
    }

    private async Task AddWorkout()
    {
        await Shell.Current.GoToAsync(nameof(WorkoutLogPage));
    }
}