using Microsoft.Extensions.Logging;

namespace Rock_Paper_Scissor
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
                    fonts.AddFont("BLOODY.ttf","BLOODY");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
//public static class MauiProgram
//{
//    public static MauiApp CreateMauiApp()
//    {
//        var builder = MauiApp.CreateBuilder();
//        builder
//           .UseMauiApp<App>()
//           .ConfigureFonts(fonts =>
//           {
//               fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
//               fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
//               fonts.AddFont("Anstting-Kishon.ttf", "AnsttingKishon"); // New Font Added
//           });

//        return builder.Build();
//    }
//}