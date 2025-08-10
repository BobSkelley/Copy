using FitnessTracker.Views;
using FitnessTracker.Services;
using System.Threading.Tasks;

namespace FitnessTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(WorkoutLogPage), typeof(WorkoutLogPage));
            Routing.RegisterRoute(nameof(AddGoalPage), typeof(AddGoalPage));

            var appDataService = IPlatformApplication.Current?.Services.GetService<AppDataService>();
            if (appDataService != null)
            {
                Task.Run(async () => await appDataService.LoadAppData());
            }
        }
    }
}