using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    /// <summary>
    /// Учебные издания, интернет-ресурсы, дополнительная литература
    /// </summary>
    public class MainResourceViewModel : ResourceViewModelBase
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

        public MainResourceViewModel(HomeViewModel homeViewModel) : base(homeViewModel)
        {
            DeleteResourceCommand = new DeleteItemCommand<HomeViewModel, MainResourceViewModel>(this, homeViewModel);
        }
    }
}