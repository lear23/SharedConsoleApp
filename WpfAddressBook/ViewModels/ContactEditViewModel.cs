

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;


namespace WpfAddressBook.ViewModels;

public partial class ContactEditViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;

    public ContactEditViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [ObservableProperty]
    private PrivateContact _contact = new();


    [RelayCommand]
    private void Update()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }


}
