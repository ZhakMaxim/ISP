using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using _253504_Zhak.Application.AuthorUseCase.Commands;
using _253504_Zhak.Application.AuthorUseCase.Queries;


namespace _253504_Zhak.UI.ViewModels
{
    public partial class AddNewAuthorViewModel: ObservableObject
    {
        private readonly IMediator _mediator;

        //private string _imageName { get; set; } = "dotnet_bot.png";

        private string _authorName;

        public string AuthorName
        {
            get { return _authorName; }
            set { SetProperty(ref _authorName, value); }
        }

        private int _authorAge;
        public int AuthorAge
        {
            get { return _authorAge; }
            set { SetProperty(ref _authorAge, value); }
        }

        private string _authorWritingStyle;

        public string AuthorWritingStyle
        {
            get { return _authorWritingStyle; }
            set { SetProperty(ref _authorWritingStyle, value); }
        }

        private int? _authorId;
        public int? AuthorId
        {
            get { return _authorId; }
            set { SetProperty(ref _authorId, value); }
        }

        [RelayCommand]
        async Task SaveNewAuthor() => await SaveAuthor();

        /*[RelayCommand]
        async Task AddAuthorImage() => await AddImage();*/

        public AddNewAuthorViewModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SaveAuthor()
        {
            var authors = await _mediator.Send(new GetAllAuthorsRequest());
            if (_authorId.HasValue && _authorId.Value > authors.Last().Id && int.TryParse(_authorId.ToString(), out int parsedAuthorId))
            {
                var newAuthor = await _mediator.Send(new AddAuthorCommand(_authorName, _authorAge, _authorWritingStyle, _authorId.Value));
            }
            await App.Current.MainPage.Navigation.PopAsync();                                                                                                                                                                                                                                                
        }
       /* public async Task AddImage()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.PickPhotoAsync();

                if (photo != null)
                {
                    if (_authorId.HasValue)
                    {
                        // save the file into local storage
                        photo.FileName = $"photo_{_authorId.Value}.jpeg";
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
        }*/
    }
}
