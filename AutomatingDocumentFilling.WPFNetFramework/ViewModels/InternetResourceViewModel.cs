using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class InternetResourceViewModel : ResourceViewModelBase
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
        
        public InternetResourceViewModel(HomeViewModel homeViewModel) : base(homeViewModel)
        {
            DeleteResourceCommand = new DeleteItemCommand<InternetResourceViewModel>(this, homeViewModel);
        }
    }
}