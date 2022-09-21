namespace AMPAS.View;

public partial class MediaPage : ContentPage
{
	public MediaPage()
	{
		InitializeComponent();
	}

	private async void NextClicked(object sender, EventArgs e)
	{
		await webview.EvaluateJavaScriptAsync("forward()");
	}

	private async void PrevClicked(object sender, EventArgs e)
	{
		await webview.EvaluateJavaScriptAsync("back()");
	}
}