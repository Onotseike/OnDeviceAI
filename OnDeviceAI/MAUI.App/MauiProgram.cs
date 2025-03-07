namespace MAUI.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkitMediaElement()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("FontAwesome6FreeBrands.otf", "FontAwesomeBrands");
				fonts.AddFont("FontAwesome6FreeRegular.otf", "FontAwesomeRegular");
				fonts.AddFont("FontAwesome6FreeSolid.otf", "FontAwesomeSolid");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<TextViewModel>();

		builder.Services.AddSingleton<TextPage>();

		builder.Services.AddSingleton<AudioViewModel>();

		builder.Services.AddSingleton<AudioPage>();

		builder.Services.AddSingleton<ImageViewModel>();

		builder.Services.AddSingleton<ImagePage>();

		builder.Services.AddSingleton<VideoViewModel>();

		builder.Services.AddSingleton<VideoPage>();

		builder.Services.AddSingleton<MultiModalViewModel>();

		builder.Services.AddSingleton<MultiModalPage>();

		builder.Services.UsePageResolver();

		builder.Services.AddSingleton(AudioManager.Current);

		return builder.Build();
	}
}
