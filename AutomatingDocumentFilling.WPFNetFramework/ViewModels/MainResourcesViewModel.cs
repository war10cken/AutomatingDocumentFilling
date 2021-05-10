using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    /// <summary>
    /// Учебные издания, интернет-ресурсы, дополнительная литература
    /// </summary>
    public class MainResourcesViewModel : ResourceViewModelBase
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

        public MainResourcesViewModel(HomeViewModel homeViewModel) : base(homeViewModel)
        {
            DeleteResourceCommand = new DeleteResourceCommand<MainResourcesViewModel>(this, homeViewModel);
        }

    }
}