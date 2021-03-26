using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutomatingDocumentFilling.WPF.State.Navigators;
using AutomatingDocumentFilling.WPF.ViewModels;
using AutomatingDocumentFilling.WPF.ViewModels.Factories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutomatingDocumentFilling.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            _host = CreateHostBuilder().Build();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                       .ConfigureServices(services =>
                        {
                            services.AddSingleton<IAutomatingDocumentFillingViewModelFactory, AutomatingDocumentFillingViewModelFactory>();

                            services.AddSingleton<CreateViewModel<FirstPageViewModel>>(service => () =>
                                                                                           new FirstPageViewModel());
                            
                            services.AddSingleton<INavigator, Navigator>();
                            services.AddSingleton<MainViewModel>();

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