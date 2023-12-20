

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfAddressBook.ViewModels;

public partial class ContactEditViewModel : ObservableObject
{

    private readonly IServiceProvider _sp;

    public ContactEditViewModel(IServiceProvider sp)
    {
        _sp = sp;
    }





}
