using Microsoft.Extensions.Logging;

namespace FitnessTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddSingleton<WorkoutManager>();
            builder.Services.AddSingleton<ProgressTracker>();
            builder.Services.AddSingleton<GoalManager>();

            // Register ViewModels
            builder.Services.AddTransient<WorkoutViewModel>();
            builder.Services.AddTransient<ProgressViewModel>();
            builder.Services.AddTransient<GoalsViewModel>();
            builder.Services.AddTransient<ExerciseLibraryViewModel>();

            // Register Views
            builder.Services.AddTransient<WorkoutPage>();
            builder.Services.AddTransient<ProgressPage>();
            builder.Services.AddTransient<GoalsPage>();
            builder.Services.AddTransient<ExerciseLibraryPage>();
            builder.Services.AddTransient<AddWorkoutPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
