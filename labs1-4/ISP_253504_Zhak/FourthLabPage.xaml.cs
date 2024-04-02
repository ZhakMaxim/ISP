using ISP_253504_Zhak.Entities;
using ISP_253504_Zhak.Services;
using System.Diagnostics;

namespace ISP_253504_Zhak;

public partial class FourthLabPage : ContentPage
{
	private IRateServise rateServise;
	public FourthLabPage(IRateServise rate)
	{
        rateServise = rate;
        InitializeComponent();
		DatePick.MaximumDate = DateTime.Now;
	}

    private async void OnDateSelected(object sender, EventArgs e)
    {
        var buff = rateServise.GetRates(DatePick.Date);
        IEnumerable<Rate> buff_ = await buff;
        var allRates = buff_.ToList();
        List<Rate> rates = new();
        foreach (var rate in allRates)
        {
            if (rate.Cur_Name == "Российских рублей" || rate.Cur_Name == "Евро" || rate.Cur_Name == "Доллар США" ||
                rate.Cur_Name == "Швейцарский франк" || rate.Cur_Name == "Китайских юаней" || rate.Cur_Name == "Фунт стерлингов")
            {
                rates.Add(rate);
                Debug.WriteLine(rate.Cur_Name);
            }
        }
        CurrencyPicker.ItemsSource = rates;
    }

    private void OnCurrencySelected(object sender, EventArgs e) 
    {
        var selectedCurrency = CurrencyPicker.SelectedItem as Rate;
        if (selectedCurrency != null)
        {
            ForCurrencyLabel.Text = selectedCurrency.Cur_OfficialRate.ToString();
            BelCurrencyLabel.Text = (1 / float.Parse(ForCurrencyLabel.Text)).ToString();
        }
        
    }

}