using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _253504_Zhak.Application.AuthorUseCase.Commands;
using _253504_Zhak.Application.AuthorUseCase.Queries;
using _253504_Zhak.Application.BookUseCase.Commands;
using _253504_Zhak.Application.BookUseCase.Queries;

namespace _253504_Zhak.UI.ViewModels
{
    [QueryProperty(nameof(SelectedAuthor), "SelectedProject")]
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

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task DeleteAuthor()
        {
            var deleteProject = await _mediator.Send(new DeleteAuthorCommand(_selectedAuthor.Id));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
