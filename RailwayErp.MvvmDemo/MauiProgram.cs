using Microsoft.Extensions.Logging;
using RailwayErp.MvvmDemo.Services;
using RailwayErp.MvvmDemo.ViewModels;
using RailwayErp.MvvmDemo.Views;

namespace RailwayErp.MvvmDemo
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IAppStateService, AppStateService>();

            builder.Services.AddTransient<TrainListViewModel>();
            builder.Services.AddTransient<TrainListPage>();

            return builder.Build();


        }
    }
}
