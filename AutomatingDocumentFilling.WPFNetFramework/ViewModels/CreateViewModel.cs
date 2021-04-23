namespace WpfApplication1.ViewModels
{
    public delegate TViewModel CreateViewModel<out TViewModel>() where TViewModel : ViewModelBase;
}