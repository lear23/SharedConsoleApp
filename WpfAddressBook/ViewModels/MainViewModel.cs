using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;


namespace WpfAddressBook.ViewModels;

public partial class MainViewModel : ObservableObject
{

    [ObservableProperty]
    private ObservableObject? _currentViewModel= null!;


    private readonly IServiceProvider _sp;

    public MainViewModel(IServiceProvider sp)
    {
        _sp = sp;

        CurrentViewModel = sp.GetRequiredService<ContactListViewModel>();
    }
    

}
