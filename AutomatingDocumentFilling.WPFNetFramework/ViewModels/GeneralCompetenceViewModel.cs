using System.Collections.Generic;
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

        public ICommand GetGeneralCompetenceNamesCommand { get; }

        public GeneralCompetenceViewModel()
        {
            GetGeneralCompetenceNamesCommand =
                new GetArrayFromJsonCommand<GeneralCompetenceViewModel>(nameof(GeneralCompetenceNames), this);
            GetGeneralCompetenceNamesCommand.Execute(null);
        }
    }
}