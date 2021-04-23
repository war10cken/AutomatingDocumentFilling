using System;
using WpfApplication1.State.Navigators;

namespace WpfApplication1.ViewModels.Factories
{
    public class AutomatingDocumentFillingViewModelFactory : IAutomatingDocumentFillingViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;

        public AutomatingDocumentFillingViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _createHomeViewModel(),
                _ => throw new ArgumentNullException(nameof(viewType))
            };
        }
    }
}