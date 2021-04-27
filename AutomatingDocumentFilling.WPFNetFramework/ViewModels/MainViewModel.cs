using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;
using AutomatingDocumentFilling.WPFNetFramework.State.Navigators;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels.Factories;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAutomatingDocumentFillingViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;

        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get; }

        public MainViewModel(IAutomatingDocumentFillingViewModelFactory viewModelFactory, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
            
            _navigator.StateChanged += NavigatorOnStateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }

        private void NavigatorOnStateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}