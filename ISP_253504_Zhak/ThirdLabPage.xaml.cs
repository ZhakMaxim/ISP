namespace ISP_253504_Zhak;
using ISP_253504_Zhak.Services;
using ISP_253504_Zhak.Entities;
using System.Collections.ObjectModel;

public partial class ThirdLabPage : ContentPage
{
    private SQLiteService sqliteService;
    public ObservableCollection<Cocktail> Cocktails { get; set; }
    public ThirdLabPage()
	{
		InitializeComponent();

        sqliteService = new SQLiteService();
        sqliteService.Init();

    }
      
    private void CoctailsLoaded(object sender, EventArgs e)
    {
        Cocktails = new ObservableCollection<Cocktail>(sqliteService.GetAllCoctail());
        CocktailPicker.ItemsSource = Cocktails;
    }

    private void OnCocktailSelected(object sender, EventArgs e)
    {
        var selectedCocktail = (Cocktail)CocktailPicker.SelectedItem;

        if (selectedCocktail != null)
        {
            var ingredients = sqliteService.GetCoctailIngridients(selectedCocktail.Id);
            CollView.ItemsSource = ingredients;
        }
    }

}