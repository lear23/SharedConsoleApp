

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using SharedConsoleApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfAddressBook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{



    [ObservableProperty]
    private ObservableObject? _currentViewModel;

    private readonly IServiceProvider _sp;

    public ContactListViewModel(IServiceProvider sp)
    {
        _sp = sp;
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
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactEditViewModel>();
    } 
    
    [RelayCommand]

    private void Remove(PrivateContact contact)
    {

    }

}
