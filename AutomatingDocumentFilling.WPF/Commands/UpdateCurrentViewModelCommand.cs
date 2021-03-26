using System;
using System.Windows.Input;
using AutomatingDocumentFilling.WPF.State.Navigators;
using AutomatingDocumentFilling.WPF.ViewModels.Factories;

namespace AutomatingDocumentFilling.WPF.Commands
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