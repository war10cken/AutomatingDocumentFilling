using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class ProfessionalCompetenceViewModel : ViewModelBase
    {
        private List<string> _professionalCompetenceNames;

        public List<string> ProfessionalCompetenceNames
        {
            get => _professionalCompetenceNames;
            set
            {
                _professionalCompetenceNames = value;
                OnPropertyChanged(nameof(ProfessionalCompetenceNames));
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

        public ICommand GetProfessionalCompetence { get; }

        public ProfessionalCompetenceViewModel()
        {
            GetProfessionalCompetence =
                new GetArrayFromJsonCommand<ProfessionalCompetenceViewModel>(nameof(ProfessionalCompetenceNames), this);
            GetProfessionalCompetence.Execute(null);
        }
    }
}