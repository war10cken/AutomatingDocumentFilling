using System;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.State.Navigators;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels.Factories;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        private readonly INavigator _navigator;
        private readonly IAutomatingDocumentFillingViewModelFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigator, IAutomatingDocumentFillingViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}