using System.Collections.Generic;
using System.Linq;
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

        public ICommand DeleteCommand { get; }

        public SkillViewModel(HomeViewModel homeViewModel)
        {
            SkillNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().SkillNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, SkillViewModel>(this, homeViewModel);
        }
    }
}