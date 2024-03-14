using System.ComponentModel;
using System.Diagnostics;

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
            Debug.WriteLine($"main thread =====================>{ Thread.CurrentThread.ManagedThreadId}");
            double result = 0.0;
            double step = 0.00001;
            int iterations = 10000;
            await Task.Run(() =>
            {
                Debug.WriteLine($"integral thread =====================>{Thread.CurrentThread.ManagedThreadId}");
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
            Debug.WriteLine($"main thread =====================>{Thread.CurrentThread.ManagedThreadId}");
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