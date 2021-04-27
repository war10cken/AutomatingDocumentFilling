using AutomatingDocumentFilling.WPFNetFramework.State.Navigators;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels.Factories
{
    public interface IAutomatingDocumentFillingViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}