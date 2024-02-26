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
		
	}

    private async void CurrencyLoaded(object sender, EventArgs e)
    {

        var buff = rateServise.GetRates(DatePick.Date);
        Debug.WriteLine(DatePick.Date.Day);
        IEnumerable<Rate> buff_ = await buff;
        var allRates = buff_.ToList();
        List<Rate> rates = new();
        foreach (var rate in allRates)
        {
            if (rate.Cur_Name == "���������� ������" || rate.Cur_Name == "����" || rate.Cur_Name == "������ ���" ||
                rate.Cur_Name == "����������� �����" || rate.Cur_Name == "��������� �����" || rate.Cur_Name == "���� ����������")
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
            InoCurrencyLabel.Text = selectedCurrency.Cur_OfficialRate.ToString();
            BelCurrencyLabel.Text = (1 / float.Parse(InoCurrencyLabel.Text)).ToString();
        }
        
    }


}
