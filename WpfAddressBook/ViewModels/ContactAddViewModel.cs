

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;
using SharedConsoleApp.Services;

namespace WpfAddressBook.ViewModels;

 public partial class ContactAddViewModel : ObservableObject

{
  

    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    public ContactAddViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;
    }


    [ObservableProperty]
    private PrivateContact _contact = new();

    [RelayCommand]
    private void NavigateToList()
    {
        _contactService.AddContactToList(Contact);


        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();
    }

}
