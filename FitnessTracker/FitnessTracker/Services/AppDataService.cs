using FitnessTracker.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.Services
{
    public class AppDataService
    {
        private readonly DataService _dataService;
        private AppData _appData = new();

        public AppDataService(DataService dataService)
        {
            _dataService = dataService;
        }

        public async Task LoadAppData()
        {
            _appData = await _dataService.LoadData() ?? new AppData();
        }

        public UserProfile GetUserProfile() => _appData.UserProfile;
        public List<Goal> GetGoals() => _appData.Goals;
        public List<Workout> GetWorkouts() => _appData.Workouts;

        public async Task SaveUserProfile(UserProfile userProfile)
        {
            _appData.UserProfile = userProfile;
            await _dataService.SaveData(_appData);
        }

        public async Task AddGoal(Goal newGoal)
        {
            _appData.Goals.Add(newGoal);
            await _dataService.SaveData(_appData);
        }

        public async Task RemoveGoal(Goal goalToRemove)
        {
            var goal = _appData.Goals.FirstOrDefault(g => g.ID == goalToRemove.ID);
            if (goal != null)
            {
                _appData.Goals.Remove(goal);
                await _dataService.SaveData(_appData);
            }
        }

        public async Task SaveGoals(List<Goal> goals)
        {
            _appData.Goals = goals;
            await _dataService.SaveData(_appData);
        }

        public async Task SaveWorkouts(List<Workout> workouts)
        {
            _appData.Workouts = workouts;
            await _dataService.SaveData(_appData);
        }
    }
}