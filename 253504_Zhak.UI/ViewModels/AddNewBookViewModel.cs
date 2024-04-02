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
    [QueryProperty(nameof(SelectedAuthor), "SelectedAuthor")]
    public partial class AddNewBookViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        public AddNewBookViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private Author _selectedAuthor;

        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set => SetProperty(ref _selectedAuthor, value);
        }

        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set { SetProperty(ref _bookName, value); }
        }

        private int? _bookRate;

        public int? BookRate
        {
            get { return _bookRate; }
            set { SetProperty(ref _bookRate, value); }
        }

        [RelayCommand]
        async Task SaveNewbook() => await Savebook();

        public async Task Savebook()
        {
            if (_bookRate.HasValue && _bookRate.Value <= 100 && _bookRate.Value >= 0 &&
                int.TryParse(_bookRate.ToString(), out int parsedbookRate) && _bookName.Length != 0)
            {
                var newbook =
                    await _mediator.Send(new AddBookToAuthorCommand(_bookName, _bookRate.Value, SelectedAuthor.Id));
            }

            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
