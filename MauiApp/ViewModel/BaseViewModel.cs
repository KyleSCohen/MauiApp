

namespace AMPAS.ViewModel;

public abstract partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string username;


    public BaseViewModel()
    {
        Username = "This is changed from ViewModel";  
    }

    public virtual void OnAppearing() { 
    }
    public virtual void OnDisappearing() {
    }

}
