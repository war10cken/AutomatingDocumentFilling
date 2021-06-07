using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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

                Skills = (CollectionView)new CollectionViewSource { Source = _skillNames }.View;
                Skills.Filter = DropDownFilter;
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

        public CollectionView Skills { get; private set; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (_searchText != SelectedText) Skills.Refresh();
            }
        }

        private bool DropDownFilter(object item)
        {
            string skillName = item as string;
            if (skillName == null) return false;

            // No filter
            if (string.IsNullOrEmpty(SearchText)) return true;
            // Filtered prop here is Name != DisplayMemberPath ComboText
            return skillName.ToLower().Contains(SearchText.ToLower());
        }

        public SkillViewModel(HomeViewModel homeViewModel)
        {
            SkillNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().SkillNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, SkillViewModel>(this, homeViewModel);
        }
    }
}