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
    }
}