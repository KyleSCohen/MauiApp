namespace AMPAS.ViewModel;

public partial class FruitViewModel : BaseViewModel
{
    public ObservableCollection<Fruit> Fruits { get; set; } = new ObservableCollection<Fruit>();
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
		Fruits.Insert(0, _fruitService.GetFruit());
    }

    [RelayCommand]
    public void Remove()
    {
        Fruits.RemoveAt(Fruits.Count - 1);
    }
}
