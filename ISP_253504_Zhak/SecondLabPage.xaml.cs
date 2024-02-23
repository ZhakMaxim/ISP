using System.ComponentModel;

namespace ISP_253504_Zhak
{
    public partial class SecondLabPage : ContentPage
    {
        CancellationTokenSource source = new();

        public SecondLabPage()
        {
            InitializeComponent();
        }

        private async Task CalculateIntegralAsync()
        {
            double result = 0.0;
            double step = 0.00001;
            int iterations = 10000;
            await Task.Run(() =>
            {
                for (double x = 0; x < 1; x += step)
                {
                    for (int i = 0; i < iterations; i++)
                    {
                        int dummyResult = i * i;
                    }

                    result += Math.Sin(x) * step;

                    if (source.Token.IsCancellationRequested)
                    {
                        return;
                    }

                    ReportProgress(x);
                }
            }, source.Token);

            if(!source.Token.IsCancellationRequested) 
            {
                TaskInfoLbl.Text = Math.Round(result, 5).ToString();
            }

            StartBtn.IsEnabled = true;
            CancelBtn.IsEnabled = false;
        }

        private void ReportProgress(double progress)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ProgressBar.Progress = progress;
                ProgressLbl.Text = $"{(int)(progress * 100)}%";
            });
        }

        private async void OnStartButtonClicked(object sender, EventArgs e)
        {
            TaskInfoLbl.Text = "Вычисление";
            CancelBtn.IsEnabled = true;
            StartBtn.IsEnabled = false;

            source = new CancellationTokenSource();
            await CalculateIntegralAsync();

        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            TaskInfoLbl.Text = "Задание отменено";
            StartBtn.IsEnabled = true;
            CancelBtn.IsEnabled = false;

            source.Cancel();

        }
    }
}