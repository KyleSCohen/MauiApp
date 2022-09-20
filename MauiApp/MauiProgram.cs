
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using AMPAS.ViewModel;
global using AMPAS.View;

using Microsoft.Extensions.DependencyInjection;

namespace AMPAS;

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

		// Register all dependencies

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<LoginPage>();

		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<HomePage>();


		return builder.Build();
	}
}
