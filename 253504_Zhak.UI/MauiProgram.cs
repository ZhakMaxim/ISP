using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using _253504_Zhak.Application;
using _253504_Zhak.Persistense;
using _253504_Zhak.UI.Pages;
using _253504_Zhak.UI.ViewModels;
using _253504_Zhak.Persistense.Repository;
using _253504_Zhak.Persistense.Data;
using _253504_Zhak.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace _253504_Zhak.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string imagesDir = System.IO.Path.Combine(FileSystem.AppDataDirectory, "Images");
            if (Directory.Exists(imagesDir))
            {
                System.IO.Directory.Delete(imagesDir, true);
                System.IO.Directory.CreateDirectory(imagesDir);
            }
            else
            {
                System.IO.Directory.CreateDirectory(imagesDir);
            }

            string settingsStream = "_253504_Zhak.UI.appsettings.json";
            string dataDirectory = FileSystem.Current.AppDataDirectory + "/";

            var builder = MauiApp.CreateBuilder();

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

            var connStr = builder.Configuration
                .GetConnectionString("SqliteConnection");

            connStr = String.Format(connStr, dataDirectory);
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connStr)
                .Options;

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Lobster-Regular.ttf", "Lobster");
                    fonts.AddFont("Font-Awesome.ttf", "FontAwesome");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services
            .AddApplication()
            .AddPersistence(options)
            .RegisterPages()
            .RegisterViewModels();

            DbInitializer
            .Initialize(builder.Services.BuildServiceProvider())
            .Wait();

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
                .AddTransient<AddNewBookView>();
                

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
                .AddTransient<AddNewBookViewModel>();
                

            services.AddTransient<IMediator, Mediator>();
            return services;
        }
    }

}
