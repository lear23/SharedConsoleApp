using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;


namespace WpfAddressBook.ViewModels;

public partial class MainViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;

    public MainViewModel(IServiceProvider sp)
    {
        _sp = sp;

        CurrentViewModel = sp.GetRequiredService<ContactListViewModel>();
    }

    [ObservableProperty]
    private ObservableObject? _currentViewModel = null!;

}
