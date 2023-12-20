
using System.Windows;
using WpfAddressBook.ViewModels;


namespace WpfAddressBook;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}