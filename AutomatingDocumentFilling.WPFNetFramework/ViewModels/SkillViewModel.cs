using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class SkillViewModel : ViewModelBase
    {
        private List<string> _skillNames;

        public List<string> SkillNames
        {
            get => _skillNames;
            set
            {
                _skillNames = value;
                OnPropertyChanged(nameof(SkillNames));
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

        public ICommand GetSkills { get; }

        public SkillViewModel()
        {
            GetSkills = new GetArrayFromJsonCommand<SkillViewModel>(nameof(SkillNames), this);
            GetSkills.Execute(null);
        }
    }
}