namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class VolumeOfDiscipline : ViewModelBase 
    {
        private string _workName;

        public string WorkName
        {
            get => _workName;
            set
            {
                _workName = value;
                OnPropertyChanged(nameof(WorkName));
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