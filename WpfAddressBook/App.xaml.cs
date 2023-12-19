
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedConsoleApp.Services;
using System.Windows;
using WpfAddressBook.ViewModels;
using WpfAddressBook.Views;


namespace WpfAddressBook
{
   
    public partial class App : Application
    {
        private IHost? _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<ContactService>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<ContactListViewModel>();
                services.AddSingleton<ContactListView>();
                services.AddSingleton<ContactAddViewModel>(); 
                services.AddSingleton<ContactAddView>(); 

            }).Build();


        }

        protected override void OnStartup(StartupEventArgs e)
        {
           _host!.Start();
            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
    }

}
