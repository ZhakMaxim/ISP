using ISP_253504_Zhak.Entities;
using ISP_253504_Zhak.Services;
using Kotlin.Properties;
using System.Diagnostics;

namespace ISP_253504_Zhak;

public partial class FourthLabPage : ContentPage
{
	private IRateServise rateServise;
	public FourthLabPage(IRateServise rate)
	{
        rateServise = rate;
        InitializeComponent();
		
	}
    private async void OnBtnClicked(object sender, EventArgs e)
    {

        var rates = rateServise.GetRates(new DateTime(2024,2,26));
        IEnumerable<Rate> rates_ = await rates;
        CollView.ItemsSource = rates_.ToList();

    }
}

