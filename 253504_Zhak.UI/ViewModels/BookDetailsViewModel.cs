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
    [QueryProperty(nameof(SelectedBook), "SelectedBook")]
    public partial class BookDetailsViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private Book _selectedBook;

        private bool _isEditMode;

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                SetProperty(ref _selectedBook, value);
                BookName = SelectedBook.Title;
                BookRate = SelectedBook.Rate;
                BookAuthorId = SelectedBook.AuthorId;
            }
        }

        private string _bookName;

        public string BookName
        {
            get { return _bookName; }
            set { SetProperty(ref _bookName, value); }
        }

        private double? _bookRate;

        public double? BookRate
        {
            get { return _bookRate; }
            set { SetProperty(ref _bookRate, value); }
        }

        private int? _bookAuthorId;

        public int? BookAuthorId
        {
            get { return _bookAuthorId; }
            set { SetProperty(ref _bookAuthorId, value); }
        }

        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                SetProperty(ref _isEditMode, value);
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        public BookDetailsViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        [RelayCommand]
        async Task EditBookDetails() => await EditBook();

        [RelayCommand]
        async Task SaveBookDetails() => await SaveBook();

        [RelayCommand]
        async Task DeleteBook() => await DeleteBook_();

        public bool IsReadOnly => !IsEditMode;

        public async Task EditBook()
        {
            IsEditMode = true;
        }

        public async Task SaveBook()
        {
            var authors = await _mediator.Send(new GetAllAuthorsRequest());
            if (BookName.Length != 0 && BookRate.HasValue && BookRate.Value >= 0 && BookRate.Value <= 10 &&
                BookAuthorId.Value <= authors.Last().Id &&
                BookAuthorId.Value > 0)
            {
                await _mediator.Send(new EditBookCommand(BookName, BookRate.Value, _selectedBook.Id));
                var movedBook =
                    await _mediator.Send(
                        new MoveBookToAuthorCommand(BookName, BookRate.Value, _selectedBook.Id, BookAuthorId.Value));
            }

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task DeleteBook_()
        {
            var deleteBook = await _mediator.Send(new DeleteBookCommand(_selectedBook.Id));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
