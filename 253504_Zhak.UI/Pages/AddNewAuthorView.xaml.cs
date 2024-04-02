using _253504_Zhak.UI.ViewModels;

namespace _253504_Zhak.UI.Pages;

public partial class AddNewAuthorView : ContentPage
{
	public AddNewAuthorView(AddNewAuthorViewModel viewModel)
	{
		InitializeComponent();
        this.BindingContext = viewModel;
    }
}