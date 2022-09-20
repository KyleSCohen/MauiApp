﻿

namespace AMPAS.ViewModel;

[QueryProperty(nameof(Token), nameof(Token))]
public partial class HomeViewModel : BaseViewModel  
{
    [ObservableProperty]
    private string token;

    [RelayCommand] // LogoutCommand
    public async void Logout(object sender)
        => await Shell.Current.GoToAsync("//Login");
}
