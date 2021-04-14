using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.State.Navigators;
using AutomatingDocumentFilling.WPF.ViewModels;
using AutomatingDocumentFilling.WPF.ViewModels.Factories;
using AutomatingDocumentFilling.WPF.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spire.License;

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
                       .ConfigureAppConfiguration(config =>
                        {
                            config.AddJsonFile("settings.json");
                        })
                       .ConfigureServices((context, services) =>
                        {
                            string firstPart = context.Configuration.GetValue<string>("FirstPartOfDoc");
                            string secondPart = context.Configuration.GetValue<string>("SecondPartOfDoc");
                            string thirdPart = context.Configuration.GetValue<string>("ThirdPartOfDoc");
                            string fourthPart = context.Configuration.GetValue<string>("FourthPartOfDoc");
                            string documentName = context.Configuration.GetValue<string>("Document");

                            services.AddSingleton<IAutomatingDocumentFillingViewModelFactory, AutomatingDocumentFillingViewModelFactory>();
                            services
                               .AddSingleton<IDialogWindowService<DocumentView>, DialogWindowService<DocumentView>>();

                            services.AddSingleton<CreateViewModel<HomeViewModel>>(service =>
                            {
                                return () => new HomeViewModel(service.GetRequiredService<DocumentViewModel>(),
                                                               firstPart, secondPart,
                                                               thirdPart, fourthPart, documentName);
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