namespace AutomatingDocumentFilling.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : ViewModelBase;
}