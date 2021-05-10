using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class InternetResourcesViewModel : ResourceViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICommand DeleteResourceCommand { get; }
        
        public InternetResourcesViewModel(HomeViewModel homeViewModel) : base(homeViewModel)
        {
            DeleteResourceCommand = new DeleteResourceCommand<InternetResourcesViewModel>(this, homeViewModel);
        }
    }
}