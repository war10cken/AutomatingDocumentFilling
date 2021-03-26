using AutomatingDocumentFilling.WPF.ViewModels;

namespace AutomatingDocumentFilling.WPF.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}