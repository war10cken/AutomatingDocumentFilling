using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class PracticalTrainingTopicViewModel : ViewModelBase
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

        public ICommand DeleteCommand { get; }

        public PracticalTrainingTopicViewModel(ThemeViewModel themeViewModel)
        {
            DeleteCommand =
                new DeleteItemCommand<ThemeViewModel, PracticalTrainingTopicViewModel>(this, themeViewModel);
        }
    }
}