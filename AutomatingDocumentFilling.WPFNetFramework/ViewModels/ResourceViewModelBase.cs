namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class ResourceViewModelBase : ViewModelBase
    {
        public HomeViewModel HomeViewModel { get; }

        public ResourceViewModelBase(HomeViewModel homeViewModel)
        {
            HomeViewModel = homeViewModel;
        }
    }
}