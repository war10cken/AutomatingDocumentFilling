using System;
using System.Windows.Input;
using WpfApplication1.State.Navigators;
using WpfApplication1.ViewModels.Factories;

namespace WpfApplication1.Commands
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