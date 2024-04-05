using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Zhak.Application.BookUseCase.Commands;
using _253504_Zhak.Application.BookUseCase.Queries;

namespace _253504_Zhak.UI.ViewModels
{
    [QueryProperty(nameof(SelectedAuthor), "SelectedAuthor")]
    [QueryProperty(nameof(LastAddedBookId), "LastAddedBookId")]
    public partial class AddNewBookViewModel : ObservableObject
    {
        private readonly IMediator _mediator;

        private int _lastAddedBookId;

        public int LastAddedBookId
        {
            get => _lastAddedBookId;
            set => SetProperty(ref _lastAddedBookId, value);
        }

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
            _bookId = LastAddedBookId;
            if (_bookRate.HasValue && _bookRate.Value <= 10 && _bookRate.Value >= 0 &&
                double.TryParse(_bookRate.ToString(), out double parsedbookRate) && _bookTitle.Length != 0)
            {
                var newbook =
                    await _mediator.Send(new AddBookToAuthorCommand(_bookTitle, _bookRate.Value, _imageName, LastAddedBookId, SelectedAuthor.Id));
            }

            await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task AddImage()
        {
            _bookId = LastAddedBookId;
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();
                var books = await _mediator.Send(new GetBooksByAuthorRequest(_selectedAuthor.Id));
                if (photo != null)
                {
                    if (_bookId.HasValue)
                    {
                        using var stream = await photo.OpenReadAsync();
                        photo.FileName = $"{_bookId.Value}.png";
                        string localFilePath = Path.Combine(FileSystem.AppDataDirectory, "Images", $"{_bookId.Value}.png");
                        _imageName = photo.FileName;
                        using var fileStream = File.Create(localFilePath);
                        stream.Seek(0, SeekOrigin.Begin);
                        stream.CopyTo(fileStream);
                        stream.Seek(0, SeekOrigin.Begin);
                    }
                }
            }
        }
    }
}
