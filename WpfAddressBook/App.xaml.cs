
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
        private IHost? _host {  get; set; }

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton<ContactService>();               
              
                services.AddTransient<ContactListViewModel>();
                services.AddTransient<ContactListView>();

                services.AddTransient<ContactAddViewModel>(); 
                services.AddTransient<ContactAddView>();

                services.AddTransient<ContactEditViewModel>();
                services.AddTransient<ContactEditView>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

            }).Build();


        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host!.StartAsync();
            var mainWindow = _host!.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }

}
