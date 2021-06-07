using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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

                Knowledges = (CollectionView)new CollectionViewSource { Source = _knowledgeNames }.View;
                Knowledges.Filter = DropDownFilter;
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

        public CollectionView Knowledges { get; private set; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (_searchText != SelectedText) Knowledges.Refresh();
            }
        }

        private bool DropDownFilter(object item)
        {
            string knowledgeName = item as string;
            if (knowledgeName == null) return false;

            // No filter
            if (string.IsNullOrEmpty(SearchText)) return true;
            // Filtered prop here is Name != DisplayMemberPath ComboText
            return knowledgeName.ToLower().Contains(SearchText.ToLower());
        }

        public KnowledgeViewModel(HomeViewModel homeViewModel)
        {
            KnowledgeNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().KnowledgeNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, KnowledgeViewModel>(this, homeViewModel);
        }
    }
}