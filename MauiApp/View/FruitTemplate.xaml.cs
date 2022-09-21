namespace AMPAS.View;

public partial class FruitTemplate : ContentView
{
	public FruitTemplate()
	{
		InitializeComponent();
	}

	protected async override void OnChildAdded(Element child)
	{
		base.OnChildAdded(child);

	}

	protected async override void OnBindingContextChanged()
	{
		base.OnBindingContextChanged();
        await fruitImage.RotateTo(360, 2000);
    }
}