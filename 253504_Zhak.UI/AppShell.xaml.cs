using _253504_Zhak.UI.Pages;

namespace _253504_Zhak.UI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetails), typeof(BookDetails));
            Routing.RegisterRoute(nameof(AddNewAuthorView), typeof(AddNewAuthorView));
            Routing.RegisterRoute(nameof(EditAuthorView), typeof(EditAuthorView));
            Routing.RegisterRoute(nameof(AddNewBookView), typeof(AddNewBookView));
        }
    }
}
