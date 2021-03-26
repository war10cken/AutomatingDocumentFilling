using AutomatingDocumentFilling.WPF.State.Navigators;

namespace AutomatingDocumentFilling.WPF.ViewModels.Factories
{
    public interface IAutomatingDocumentFillingViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}