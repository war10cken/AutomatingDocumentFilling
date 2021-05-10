namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class AcademicSubjectViewModel : ViewModelBase
    {
        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }
    }
}