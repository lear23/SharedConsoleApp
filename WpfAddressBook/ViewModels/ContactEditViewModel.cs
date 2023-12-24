

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;
using SharedConsoleApp.Services;


namespace WpfAddressBook.ViewModels;

public partial class ContactEditViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;
    //private readonly ContactService _contactService;//ny

    public ContactEditViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        //_contactService = contactService;

        //Contact = _contactService.CurrentItem;

    }

    [ObservableProperty]
    private PrivateContact _contact = new();

    [RelayCommand]
    private void Update()
    {
        //_contactService.CurrentItem = Contact;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactListViewModel>();

    }



}
