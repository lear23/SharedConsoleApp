

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;

namespace WpfAddressBook.ViewModels;

 public partial class ContactAddViewModel : ObservableObject

{

     [ObservableProperty]
    private PrivateContact _contact = new();
   


    private readonly IServiceProvider _sp;

    public ContactAddViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [RelayCommand]
    private void NavigateToList()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

}
