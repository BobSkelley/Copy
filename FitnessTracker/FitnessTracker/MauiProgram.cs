using Microsoft.Extensions.Logging;
using FitnessTracker.Services;
using FitnessTracker.ViewModels;
using FitnessTracker.Views;
using Microcharts.Maui;
using SkiaSharp.Views.Maui.Controls.Hosting;
using CommunityToolkit.Maui;

namespace FitnessTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMicrocharts()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddSingleton<WorkoutManager>();
            builder.Services.AddSingleton<AppDataService>();

            // Register ViewModels
            builder.Services.AddTransient<WorkoutViewModel>();
            builder.Services.AddTransient<ProgressViewModel>();
            builder.Services.AddTransient<GoalsViewModel>();
            builder.Services.AddTransient<ExerciseLibraryViewModel>();
            builder.Services.AddTransient<UserProfileViewModel>();
            builder.Services.AddTransient<AddGoalViewModel>();

            // Register Views
            builder.Services.AddTransient<WorkoutPage>();
            builder.Services.AddTransient<ProgressPage>();
            builder.Services.AddTransient<GoalsPage>();
            builder.Services.AddTransient<ExerciseLibraryPage>();
            builder.Services.AddTransient<WorkoutLogPage>();
            builder.Services.AddTransient<UserProfilePage>();
            builder.Services.AddTransient<AddGoalPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}