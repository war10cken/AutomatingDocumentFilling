using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class WorkshopEquipmentViewModel : ViewModelBase
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

        public ICommand DeleteCommand { get; }

        public WorkshopEquipmentViewModel(HomeViewModel homeViewModel)
        {
            DeleteCommand = new DeleteItemCommand<HomeViewModel, WorkshopEquipmentViewModel>(this, homeViewModel);
        }
    }
}