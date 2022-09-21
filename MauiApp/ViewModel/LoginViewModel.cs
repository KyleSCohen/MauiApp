

namespace AMPAS.ViewModel;

public partial class LoginViewModel : BaseViewModel
{

    [RelayCommand]
    public async void Login(object sender)
    {
        // User login and this token should be passed to the next page for persisting
        string token = Guid.NewGuid().ToString();

        // Here you want to get access token and the needed movies etc etc then if no error go to home
        //  await Shell.Current.GoToAsync($"//Tabs?Token={token}");
        await Shell.Current.GoToAsync($"//Tabs");
    }
}
