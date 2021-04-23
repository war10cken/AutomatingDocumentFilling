using WpfApplication1.State.Navigators;

namespace WpfApplication1.ViewModels.Factories
{
    public interface IAutomatingDocumentFillingViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}