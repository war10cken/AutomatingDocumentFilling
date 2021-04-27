namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : ViewModelBase;
}