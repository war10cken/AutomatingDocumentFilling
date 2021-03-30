using System.Windows.Input;
using AutomatingDocumentFilling.WPF.Commands;
using AutomatingDocumentFilling.WPF.State.Navigators;
using AutomatingDocumentFilling.WPF.ViewModels.Factories;

namespace AutomatingDocumentFilling.WPF.ViewModels
{
    public class MainViewModel
    {
        private readonly IAutomatingDocumentFillingViewModelFactory _viewModelFactory;

        public INavigator Navigator { get; }

        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public MainViewModel(IAutomatingDocumentFillingViewModelFactory viewModelFactory, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            Navigator = navigator;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}