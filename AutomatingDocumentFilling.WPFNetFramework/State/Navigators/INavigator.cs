using WpfApplication1.ViewModels;

namespace WpfApplication1.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}