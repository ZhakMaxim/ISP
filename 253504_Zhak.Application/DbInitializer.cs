using Microsoft.Extensions.DependencyInjection;

namespace _253504_Zhak.Application;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider services)
    {
        var unitOfWork = services.GetRequiredService<IUnitOfWork>();

        await unitOfWork.DeleteDataBaseAsync();
        await unitOfWork.CreateDataBaseAsync();

        var author1 = new Author("Author1", 20, "descriptive", 1);
        var author2 = new Author("Author2", 22, "descriptive", 2);
        var author3 = new Author("Author3", 31, "creative", 3);

        await unitOfWork.AuthorRepository.AddAsync(author1);
        await unitOfWork.AuthorRepository.AddAsync(author2);
        await unitOfWork.AuthorRepository.AddAsync(author3);
        int i = 1;

        for (; i <= 10; i++)
        {
            var additionalBook = new Book($"Book {i}", "dotnet_bot.png", i, i);
            additionalBook.AddToAuthor(author1.Id);
            await unitOfWork.BookRepository.AddAsync(additionalBook);
        }

        for (; i <= 20; i++)
        {
            var additionalBook = new Book($"Book {i}", "dotnet_bot.png", i, i);
            additionalBook.AddToAuthor(author2.Id);
            await unitOfWork.BookRepository.AddAsync(additionalBook);
        }

        for (; i <= 30; i++)
        {
            var additionalBook = new Book($"Book {i}", "dotnet_bot.png", i, i);
            additionalBook.AddToAuthor(author3.Id);
            await unitOfWork.BookRepository.AddAsync(additionalBook);
        }

        await unitOfWork.SaveAllAsync();
    }
}