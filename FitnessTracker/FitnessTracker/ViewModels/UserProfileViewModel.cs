using FitnessTracker.Models;
using FitnessTracker.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessTracker.ViewModels
{
    public class UserProfileViewModel : BaseViewModel
    {
        private readonly AppDataService _appDataService;
        private UserProfile _userProfile;

        public UserProfile UserProfile
        {
            get => _userProfile;
            set => SetProperty(ref _userProfile, value);
        }

        public List<FitnessLevel> FitnessLevels => Enum.GetValues(typeof(FitnessLevel)).Cast<FitnessLevel>().ToList();

        public ICommand SaveProfileCommand { get; }

        public UserProfileViewModel(AppDataService appDataService)
        {
            _appDataService = appDataService;
            _userProfile = _appDataService.GetUserProfile() ?? new UserProfile();
            SaveProfileCommand = new Command(async () => await SaveProfile());
        }

        private async Task SaveProfile()
        {
            if (UserProfile != null)
            {
                await _appDataService.SaveUserProfile(UserProfile);
                await Shell.Current.DisplayAlert("Success", "Profile saved successfully.", "OK");
            }
        }
    }
}