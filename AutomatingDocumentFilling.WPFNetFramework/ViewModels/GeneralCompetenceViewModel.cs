using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class GeneralCompetenceViewModel : ViewModelBase
    {
        private List<string> _generalCompetenceNames;

        public List<string> GeneralCompetenceNames
        {
            get => _generalCompetenceNames;
            set
            {
                _generalCompetenceNames = value;
                OnPropertyChanged(nameof(GeneralCompetenceNames));
            }
        }

        private string _selectedText;

        public string SelectedText
        {
            get => _selectedText;
            set
            {
                _selectedText = value;
                OnPropertyChanged(nameof(SelectedText));
            }
        }

        public ICommand DeleteCommand { get; }

        public GeneralCompetenceViewModel(HomeViewModel homeViewModel)
        {
            GeneralCompetenceNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().GeneralCompetenceNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, GeneralCompetenceViewModel>(this, homeViewModel);
        }
    }
}