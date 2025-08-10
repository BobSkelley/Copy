using FitnessTracker.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessTracker.Views
{
    public partial class ProgressPage : ContentPage
    {
        private CancellationTokenSource? _animationTokenSource;

        public ProgressPage(ProgressViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _animationTokenSource = new CancellationTokenSource();
            StartHeartAnimation(_animationTokenSource.Token);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (_animationTokenSource != null)
            {
                _animationTokenSource.Cancel();
                _animationTokenSource = null;
            }
        }

        private async void StartHeartAnimation(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await HeartImage.ScaleTo(1.1, 500, Easing.SinInOut);
                if (token.IsCancellationRequested) break;
                await HeartImage.ScaleTo(1.0, 500, Easing.SinInOut);
            }
            // Reset scale when animation is cancelled
            HeartImage.Scale = 1.0;
        }
    }
}