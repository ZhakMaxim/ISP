using _253504_Zhak.UI.ViewModels;

namespace _253504_Zhak.UI.Pages;

public partial class EditAuthorView : ContentPage
{
	public EditAuthorView(EditAuthorViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}