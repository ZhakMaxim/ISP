using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using _253504_Zhak.Application;
using _253504_Zhak.Persistense;
using _253504_Zhak.UI.Pages;
using _253504_Zhak.UI.ViewModels;
using _253504_Zhak.Persistense.Repository;

namespace _253504_Zhak.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services
            .AddApplication()
            .AddPersistence()
            .RegisterPages()
            .RegisterViewModels();

#if DEBUG
            builder.Logging.AddDebug();
#endif


            return builder.Build();
        }
        public static IServiceCollection RegisterPages(this IServiceCollection services)
        {
            services
                .AddSingleton<Authors>()
                .AddTransient<BookDetails>()
                .AddTransient<AddNewAuthorView>()
                .AddTransient<EditAuthorView>()
                .AddTransient<AddNewBookView>()
                .AddTransient<_253504_Zhak.Domain.Abstractions.IRepository<Book>, FakeBookRepository>();

            services.AddTransient<IMediator, Mediator>();
            return services;
        }

        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services
                .AddSingleton<AuthorsViewModel>()
                .AddTransient<BookDetailsViewModel>()
                .AddTransient<AddNewAuthorViewModel>()
                .AddTransient<EditAuthorViewModel>()
                .AddTransient<AddNewBookViewModel>()
                .AddTransient<_253504_Zhak.Domain.Abstractions.IRepository<Book>, FakeBookRepository>();

            services.AddTransient<IMediator, Mediator>();
            return services;
        }
    }

}
