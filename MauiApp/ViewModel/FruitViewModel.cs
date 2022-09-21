

using Microsoft.ApplicationInsights;

namespace AMPAS.ViewModel;

public partial class FruitViewModel : BaseViewModel
{
	public ObservableCollection<Fruit> Fruits { get; set; } = new ();
    private FruitService _fruitService;
	private TelemetryClient _telemetryClient;

	public FruitViewModel(FruitService fruitService, TelemetryClient telemetryClient)
	{
		_fruitService = fruitService;
		_telemetryClient = telemetryClient;
	}

	[RelayCommand]
	public void Add()
	{
		Fruit fruit = _fruitService.GetFruit();
		_telemetryClient.TrackEvent(fruit.Name);
        Fruits.Insert(0, fruit);
	}

    [RelayCommand]
    public void Remove()
    {
		Fruits.RemoveAt(Fruits.Count - 1);
    }

	[RelayCommand]
	public void Bad()
	{
		try
		{
			int.Parse("Invalid");
		}
		catch(Exception e)
		{
			_telemetryClient.TrackException(e);
		}
	}
}
