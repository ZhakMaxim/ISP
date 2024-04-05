using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Zhak.Application.AuthorUseCase.Commands;


namespace _253504_Zhak.UI.ViewModels
{
    [QueryProperty(nameof(SelectedAuthor), "SelectedAuthor")]
    public partial class EditAuthorViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private Author _selectedAuthor;

        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set => SetProperty(ref _selectedAuthor, value);
        }

        private string _authorName;

        public string AuthorName
        {
            get { return _authorName; }
            set { SetProperty(ref _authorName, value); }
        }

        public EditAuthorViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        async Task SaveEditedAuthor() => await SaveAuthor();

        [RelayCommand]
        async Task DeleteEditedAuthor() => await DeleteAuthor();

        public async Task SaveAuthor()
        {
            if (AuthorName != null)
            {
                _selectedAuthor.Name = AuthorName;
            }
            else 
            {
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }
            await _mediator.Send(new EditAuthorCommand(AuthorName, _selectedAuthor.Id));

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task DeleteAuthor()
        {
            var deleteProject = await _mediator.Send(new DeleteAuthorCommand(_selectedAuthor.Id));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
