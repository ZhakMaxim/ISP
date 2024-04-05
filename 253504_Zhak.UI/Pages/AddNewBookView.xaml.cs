using _253504_Zhak.UI.ViewModels;

namespace _253504_Zhak.UI.Pages;

public partial class AddNewBookView : ContentPage
{
	public AddNewBookView(AddNewBookViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}