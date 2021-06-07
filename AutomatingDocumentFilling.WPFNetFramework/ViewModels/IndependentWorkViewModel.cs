using AutomatingDocumentFilling.WPFNetFramework.Commands;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class IndependentWorkViewModel : ViewModelBase
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

        public ICommand DeleteCommand { get; }

        public IndependentWorkViewModel(HomeViewModel homeViewModel)
        {
            DeleteCommand = new DeleteItemCommand<HomeViewModel, IndependentWorkViewModel>(this, homeViewModel);
        }
    }
}