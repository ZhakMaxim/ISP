using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Zhak.Application.AuthorUseCase.Commands;
using _253504_Zhak.Application.AuthorUseCase.Queries;
using _253504_Zhak.Application.BookUseCase.Commands;
using _253504_Zhak.Application.BookUseCase.Queries;
using _253504_Zhak.UI.Pages;
using _253504_Zhak.Domain.Entities;


namespace _253504_Zhak.UI.ViewModels
{
    public partial class AuthorsViewModel: ObservableObject
    {

        private readonly IMediator _mediator;

        public int LastAddedBookId { get; set; } = 30;

        private string _selectedAuthorName;

        public string SelectedAuthorName
        {
            get { return _selectedAuthorName; }
            set
            {
                SetProperty(ref _selectedAuthorName, value);
                UpdateBookList();
            }
        }

        private Book _selectedBook;

        public Book SelectedBook
        {
            get { return _selectedBook; }
            set { SetProperty(ref _selectedBook, value); }
        }

        public AuthorsViewModel(IMediator mediator)
        {
            GetAuthors();
            _mediator = mediator;

        }

        public ObservableCollection<Author> Authors { get; set; } = new();
        public ObservableCollection<string> AuthorsNames { get; set; } = new();
      
        public ObservableCollection<Book> Books { get; set;} = new();

        public ObservableCollection<string> BookNames { get; set; } = new();
      

        [ObservableProperty] 

        public Author selectedAuthor;

        [RelayCommand]
        async Task UpdateAuthorList() => await GetAuthors();

        [RelayCommand]
        async Task UpdateBookList() => await GetBooks();

        [RelayCommand]
        async Task ShowDetails(string BookName) => await GotoDetailsPage(BookName);

        [RelayCommand]
        async Task AddNewAuthor() => await AddAuthor();

        [RelayCommand]
        async Task AddNewBook() => await AddBook();

        [RelayCommand]
        async Task EditAuthorData() => await EditAuthor();

        public async Task GetAuthors()
        {
            var authors = await _mediator.Send(new GetAllAuthorsRequest());
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                AuthorsNames.Clear();
                Authors.Clear();
                foreach (var author in authors)
                {
                    AuthorsNames.Add(author.Name);
                    Authors.Add(author);
                }

                SelectedAuthorName = AuthorsNames.FirstOrDefault();
            });
        }
        public async Task GetBooks()
        {
            var selectedAuthor = Authors.FirstOrDefault(author => author.Name == SelectedAuthorName);
            if (selectedAuthor != null)
            {
                SelectedAuthor = selectedAuthor;
                var books = await _mediator.Send(new GetBooksByAuthorRequest(SelectedAuthor.Id));
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Books.Clear();
                    BookNames.Clear();
                    foreach (var book in books)
                    {
                        Books.Add(book);
                        BookNames.Add(book.Title);
                    }
                });
            }
        }

        private async Task GotoDetailsPage(string title)
        {
            var book = Books.FirstOrDefault(book => book.Title == title);
            if (book != null)
            {
                var navigationParameter = new Dictionary<string, object>()
            {
                { "SelectedBook", book }
            };
                await Shell.Current.GoToAsync(nameof(BookDetails), navigationParameter);
            };
        }

        public async Task AddAuthor()
        {
            await Shell.Current.GoToAsync(nameof(AddNewAuthorView));
        }
        public async Task AddBook()
        {
            var author = Authors.FirstOrDefault(author => author.Name == SelectedAuthorName);
            if (author != null)
            {
                Console.WriteLine($"----------------------------------------------------> : {author.Name}");
                var navigationParameter = new Dictionary<string, object>()
            {
                { "SelectedAuthor", author },
                { "LastAddedBookId", ++LastAddedBookId },

            };
                await Shell.Current.GoToAsync(nameof(AddNewBookView), navigationParameter);
            }

             await UpdateBookList();
        }

        public async Task EditAuthor()
        {
            var author = Authors.FirstOrDefault(author => author.Name == SelectedAuthorName);
            if (author != null)
            {
                Console.WriteLine(author);
                var navigationParameter = new Dictionary<string, object>()
            {
                { "SelectedAuthor", author }
            };
                await Shell.Current.GoToAsync(nameof(EditAuthorView), navigationParameter);

            }
        }

    }
}
