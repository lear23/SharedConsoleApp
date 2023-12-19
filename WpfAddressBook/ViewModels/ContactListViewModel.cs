

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace WpfAddressBook.ViewModels;

public partial class ContactListViewModel : ObservableObject
{
    private readonly IServiceProvider _sp;

    public ContactListViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }

    [RelayCommand]
    private void NavigateToAdd()
    {
        var mainViewModel = _sp.GetRequiredService<MainViewModel>();

        mainViewModel.CurrentViewModel = _sp.GetRequiredService<ContactAddViewModel>();
    }
}
