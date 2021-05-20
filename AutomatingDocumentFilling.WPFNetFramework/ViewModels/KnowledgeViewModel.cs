using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class KnowledgeViewModel : ViewModelBase
    {
        private List<string> _knowledgeNames;

        public List<string> KnowledgeNames
        {
            get => _knowledgeNames;
            set
            {
                _knowledgeNames = value;
                OnPropertyChanged(nameof(KnowledgeNames));
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

        private string _appraisal;

        public string Appraisal
        {
            get => _appraisal;
            set
            {
                _appraisal = value;
                OnPropertyChanged(nameof(Appraisal));
            }
        }

        private string _assessmentForm;

        public string AssessmentForm
        {
            get => _assessmentForm;
            set
            {
                _assessmentForm = value;
                OnPropertyChanged(nameof(AssessmentForm));
            }
        }

        public ICommand GetKnowledgeNamesCommand { get; }

        public ICommand DeleteCommand { get; }

        public KnowledgeViewModel(HomeViewModel homeViewModel)
        {
            DeleteCommand = new DeleteItemCommand<HomeViewModel, KnowledgeViewModel>(this, homeViewModel);
            GetKnowledgeNamesCommand = new GetArrayFromJsonCommand<KnowledgeViewModel>(nameof(KnowledgeNames), this);
            GetKnowledgeNamesCommand.Execute(null);
        }
    }
}