using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WpfApplication1.State.Navigators;
using WpfApplication1.ViewModels;
using WpfApplication1.ViewModels.Factories;
using WpfApplication1.Views;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureAppConfiguration(config =>
                        {
                            config.AddJsonFile("settings.json");
                        })
                       .ConfigureServices((context, services) =>
                        {
                            string documentName = context.Configuration.GetValue<string>("Document");
                            string outputName = context.Configuration.GetValue<string>("OutputName"); 

                            services.AddSingleton<IAutomatingDocumentFillingViewModelFactory, AutomatingDocumentFillingViewModelFactory>();

                            services.AddSingleton<CreateViewModel<HomeViewModel>>(service =>
                            {
                                return () =>
                                    new HomeViewModel(service.GetRequiredService<DocumentViewModel>(), documentName,
                                                      outputName);
                            });

                            services.AddSingleton<INavigator, Navigator>();
                            services.AddSingleton<MainViewModel>();
                            services.AddSingleton<DocumentViewModel>();

                            services.AddScoped(service =>
                                                   new DocumentView(service.GetRequiredService<DocumentViewModel>()));
                            services.AddScoped(service => new MainWindow(service.GetRequiredService<MainViewModel>()));
                        });
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            Window window = _host.Services.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();

            base.OnExit(e);
        }
    }
}