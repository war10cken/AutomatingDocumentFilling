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

        public ICommand GetKnowledgeNamesCommand { get; }

        public KnowledgeViewModel()
        {
            GetKnowledgeNamesCommand = new GetArrayFromJsonCommand<KnowledgeViewModel>(nameof(KnowledgeNames), this);
            GetKnowledgeNamesCommand.Execute(null);
        }
    }
}