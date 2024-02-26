using Microsoft.Extensions.Logging;
using ISP_253504_Zhak.Services;

namespace ISP_253504_Zhak
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddTransient<IDbService, SQLiteService>();
            builder.Services.AddTransient<ThirdLabPage>();

            builder.Services.AddTransient<IRateServise, RateServise>();
            builder.Services.AddHttpClient<IRateServise, RateServise>(opt => opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
            builder.Services.AddTransient<FourthLabPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif      

            return builder.Build();
        }
    }
}
