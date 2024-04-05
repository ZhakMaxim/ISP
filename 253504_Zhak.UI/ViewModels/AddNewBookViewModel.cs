using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Zhak.Application.BookUseCase.Commands;
using _253504_Zhak.Application.BookUseCase.Queries;

namespace _253504_Zhak.UI.ViewModels
{
    [QueryProperty(nameof(SelectedAuthor), "SelectedAuthor")]
    public partial class AddNewBookViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private Author _selectedAuthor;

        public Author SelectedAuthor
        {
            get => _selectedAuthor;
            set => SetProperty(ref _selectedAuthor, value);
        }

        private string _imageName { get; set; } = "dotnet_bot.png";

        public AddNewBookViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        private string _bookTitle;

        public string BookTitle
        {
            get { return _bookTitle; }
            set { SetProperty(ref _bookTitle, value); }
        }

        private double? _bookRate;

        public double? BookRate
        {
            get { return _bookRate; }
            set { SetProperty(ref _bookRate, value); }
        }

        private int? _bookId;
        public int? BookId
        {
            get { return _bookId; }
            set { SetProperty(ref _bookId, value); }
        }

        [RelayCommand]
        async Task SaveNewBook() => await SaveBook();

        [RelayCommand]
        async Task AddBookImage() => await AddImage();

        public async Task SaveBook()
        {
            var books = await _mediator.Send(new GetBooksByAuthorRequest(_selectedAuthor.Id));
            if (_bookId.HasValue && _bookId.Value > books.Last().Id && _bookRate.HasValue && _bookRate.Value <= 10 && _bookRate.Value >= 0 &&
                double.TryParse(_bookRate.ToString(), out double parsedbookRate) && _bookTitle.Length != 0)
            {
                var newbook =
                    await _mediator.Send(new AddBookToAuthorCommand(_bookTitle, _bookRate.Value, _imageName, _bookId.Value));
            }

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task AddImage()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    if (_bookId.HasValue)
                    {
                        // save the file into local storage
                        photo.FileName = $"photo_{_bookId.Value}.png";
                        string localFilePath =
                            Path.Combine(
                                "C:/Users/MaxPl/source/repos/253504_Zhak/253504_Zhak.UI/Resources/Images",
                                photo.FileName);
                        _imageName = photo.FileName;

                        using Stream sourceStream = await photo.OpenReadAsync();
                        using FileStream localFileStream = File.OpenWrite(localFilePath);

                        await sourceStream.CopyToAsync(localFileStream);
                    }
                }
            }
        }
    }
}
