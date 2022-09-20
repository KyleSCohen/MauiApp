
namespace AMPAS;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		PageAppearing += App_PageAppearing;
		PageDisappearing += App_PageDisappearing;

		MainPage = new Root();
	}

	private void App_PageDisappearing(object sender, Page e)
	{
		if(e.BindingContext is BaseViewModel vm)
			vm.OnDisappearing();
	}

	private void App_PageAppearing(object sender, Page e)
	{
		if (e.BindingContext is BaseViewModel vm)
			vm.OnAppearing();
	}
}
