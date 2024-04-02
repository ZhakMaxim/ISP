using _253504_Zhak.UI.ViewModels;

namespace _253504_Zhak.UI.Pages;

public partial class BookDetails : ContentPage
{
	public BookDetails(BookDetailsViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}