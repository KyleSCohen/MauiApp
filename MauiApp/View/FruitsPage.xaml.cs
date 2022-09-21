namespace AMPAS.View;

public partial class FruitsPage : ContentPage
{
	public FruitsPage(FruitViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}