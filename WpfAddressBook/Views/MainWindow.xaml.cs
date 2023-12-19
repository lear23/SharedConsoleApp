
using System.Windows;
using WpfAddressBook.ViewModels;


namespace WpfAddressBook.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}