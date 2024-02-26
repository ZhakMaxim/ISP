namespace ISP_253504_Zhak;
using ISP_253504_Zhak.Services;
using ISP_253504_Zhak.Entities;
using System.Collections.ObjectModel;

public partial class ThirdLabPage : ContentPage
{
    private IDbService sqliteService;
    public ObservableCollection<Cocktail> Cocktails { get; set; }
    public ThirdLabPage(IDbService dbService)
	{
		InitializeComponent();

        sqliteService = dbService;
        sqliteService.Init();

    }
      
    private void CocktailsLoaded(object sender, EventArgs e)
    {
        Cocktails = new ObservableCollection<Cocktail>(sqliteService.GetAllCocktail());
        CocktailPicker.ItemsSource = Cocktails;
    }

    private void OnCocktailSelected(object sender, EventArgs e)
    {
        var selectedCocktail = (Cocktail)CocktailPicker.SelectedItem;

        if (selectedCocktail != null)
        {
            var ingredients = sqliteService.GetCocktailIngridients(selectedCocktail.Id);
            CollView.ItemsSource = ingredients;
        }
    }

}