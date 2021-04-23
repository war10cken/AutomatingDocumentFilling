using System.Windows.Input;
using WpfApplication1.Commands;
using WpfApplication1.State.Navigators;
using WpfApplication1.ViewModels.Factories;

namespace WpfApplication1.ViewModels
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