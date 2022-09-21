

using Microsoft.ApplicationInsights;

namespace AMPAS;

public partial class App : Application
{
	private TelemetryClient _telemetryClient;

	public App(TelemetryClient telemetryClient)
	{
		InitializeComponent();

		_telemetryClient = telemetryClient;

		PageAppearing += App_PageAppearing;
		PageDisappearing += App_PageDisappearing;

		MainPage = new Root();

		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
	}

	private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		// Serialize the stacktrace to a string for later synnc
		Preferences.Set("Unhandled", "stack bla bla blac");

		// Next time on appearing send the unhandled  stack for investigation
	}

	private void App_PageDisappearing(object sender, Page e)
	{
		if (e.BindingContext is BaseViewModel vm)
		{
			_telemetryClient.TrackPageView(e.BindingContext.GetType().ToString());
			vm.OnDisappearing();
		}
	}

	private void App_PageAppearing(object sender, Page e)
	{
		if (e.BindingContext is BaseViewModel vm)
			vm.OnAppearing();
	}
}
