using System;
using AutomatingDocumentFilling.WPF.State.Navigators;

namespace AutomatingDocumentFilling.WPF.ViewModels.Factories
{
    public class AutomatingDocumentFillingViewModelFactory : IAutomatingDocumentFillingViewModelFactory
    {
        private readonly CreateViewModel<FirstPageViewModel> _createFirstPageViewModel;
        private readonly CreateViewModel<DocumentViewModel> _createDocumentViewModel;

        public AutomatingDocumentFillingViewModelFactory(CreateViewModel<FirstPageViewModel> createFirstPageViewModel
                                                        )
        {
            _createFirstPageViewModel = createFirstPageViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.FirstPage => _createFirstPageViewModel(),
                _ => throw new ArgumentNullException(nameof(viewType))
            };
        }
    }
}