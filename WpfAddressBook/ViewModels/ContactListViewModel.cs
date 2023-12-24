

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;
using SharedConsoleApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfAddressBook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{



    //[ObservableProperty]
    //private ObservableObject? _currentViewModel;

    private readonly IServiceProvider _sp;
    private readonly ContactService _contactService;

    public ContactListViewModel(IServiceProvider sp, ContactService contactService)
    {
        _sp = sp;
        _contactService = contactService;

        var contacts = _contactService.GetContactsFromList();
        privateContacts = new ObservableCollection<PrivateContact>(contacts.Select(c => (PrivateContact)c));

        

    }


    [ObservableProperty]

    private ObservableCollection<PrivateContact> privateContacts = [];


    [RelayCommand]
    private void NavigateToAdd()
    {

 
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddViewModel>();
    }


    [RelayCommand]

    private void NavigateToEdit(PrivateContact contact)

    {

        //_contactService.CurrentItem = contact;

        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactEditViewModel>();
    }

    [RelayCommand]

    private void Remove(PrivateContact contact)
    {
        _contactService.DeleteContact(contact);
        var contacts = _contactService.GetContactsFromList();
       
    }


}








