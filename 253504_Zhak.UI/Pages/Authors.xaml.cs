using _253504_Zhak.UI.ViewModels;
namespace _253504_Zhak.UI.Pages;

public partial class Authors : ContentPage
{ 
    private readonly AuthorsViewModel _viewModel;
    public Authors(AuthorsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }
}