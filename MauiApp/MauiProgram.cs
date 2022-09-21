
global using AMPAS.Model;
global using System.Collections.ObjectModel;
global using CommunityToolkit.Mvvm.ComponentModel;
global using CommunityToolkit.Mvvm.Input;
global using AMPAS.ViewModel;
global using AMPAS.View;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using System.Globalization;


namespace AMPAS;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

        // Register logger (Application Insights)
        TelemetryConfiguration cfg = TelemetryConfiguration.CreateDefault();
        cfg.ConnectionString = "InstrumentationKey=8b501c6d-2435-4647-8db7-0661b59b885a;IngestionEndpoint=https://eastus-8.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/";
        QuickPulseTelemetryProcessor qp = null;
        cfg.DefaultTelemetrySink.TelemetryProcessorChainBuilder
            .Use((next) =>
            {
                qp = new QuickPulseTelemetryProcessor(next);
                return qp;
            })
            .Build();

        var qpm = new QuickPulseTelemetryModule
        {
            AuthenticationApiKey = "k4gjc1jn3326a0ybj67bmbcedisjm7d4j22yyl53"
        };
        qpm.Initialize(cfg);
        qpm.RegisterTelemetryProcessor(qp);
        TelemetryClient client = new(cfg);

        string uniqueID = Guid.NewGuid().ToString();

        client.Context.User.AccountId ??= uniqueID;
        client.Context.User.Id ??= uniqueID;

        // We have to set the right context for the Device to log correctly in App Insights

        client.Context.Device.Model ??= DeviceInfo.Model;
        client.Context.Device.OperatingSystem ??= DeviceInfo.Platform.ToString();
        client.Context.Device.Language ??= CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
        client.Context.Device.OemName ??= DeviceInfo.Current.Manufacturer.ToString();
        client.Context.Device.Type ??= DeviceInfo.Current.DeviceType.ToString();
        client.Context.Device.NetworkType ??= Connectivity.Current.NetworkAccess.ToString();


        builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton(client);

		builder.Services.AddSingleton<LoginViewModel>();
		builder.Services.AddSingleton<LoginPage>();

		builder.Services.AddSingleton<HomeViewModel>();
		builder.Services.AddSingleton<HomePage>();

		builder.Services.AddSingleton<FruitService>();
		builder.Services.AddSingleton<FruitViewModel>();
		builder.Services.AddSingleton<FruitsPage>();

		return builder.Build();
	}
}
