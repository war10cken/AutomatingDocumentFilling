namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class PracticalTrainingTopicsViewModel : ViewModelBase
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

        private string _hours;

        public string Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                OnPropertyChanged(nameof(Hours));
            }
        }
    }
}