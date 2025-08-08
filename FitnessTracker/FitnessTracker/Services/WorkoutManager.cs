
using FitnessTracker.Models;
using FitnessTracker.Services;

    namespace FitnessTracker.Services;

    public class WorkoutManager
    {
        private readonly DataService _dataService;
        private List<Workout> _workouts = new();

        public WorkoutManager(DataService dataService)
        {
            _dataService = dataService;
            LoadWorkouts();
        }

        public List<Workout> GetWorkouts() => _workouts;

        public void AddWorkout(Workout workout)
        {
            _workouts.Add(workout);
            SaveWorkouts();
        }

        private async void LoadWorkouts()
        {
            _workouts = await _dataService.LoadWorkouts() ?? new List<Workout>();
        }

        private async void SaveWorkouts()
        {
            await _dataService.SaveWorkouts(_workouts);
        }
    }