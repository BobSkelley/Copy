using FitnessTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FitnessTracker.Services
{
    public class WorkoutManager
    {
        private readonly AppDataService _appDataService;
        private List<Workout> _workouts;

        public WorkoutManager(AppDataService appDataService)
        {
            _appDataService = appDataService;
            _workouts = _appDataService.GetWorkouts() ?? new List<Workout>();
        }

        public List<Workout> GetWorkouts() => _workouts;

        public async Task AddWorkout(Workout workout)
        {
            if (_workouts == null)
            {
                _workouts = new List<Workout>();
            }
            _workouts.Add(workout);
            await _appDataService.SaveWorkouts(_workouts);
        }
    }
}