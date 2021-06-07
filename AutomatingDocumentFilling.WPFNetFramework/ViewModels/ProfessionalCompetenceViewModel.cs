using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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

                ProfessionalCompetences = (CollectionView)new CollectionViewSource { Source = _professionalCompetenceNames }.View;
                ProfessionalCompetences.Filter = DropDownFilter;
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

        public CollectionView ProfessionalCompetences { get; private set; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (_searchText != SelectedText) ProfessionalCompetences.Refresh();
            }
        }

        private bool DropDownFilter(object item)
        {
            string professionalCompetenceName = item as string;
            if (professionalCompetenceName == null) return false;

            // No filter
            if (string.IsNullOrEmpty(SearchText)) return true;
            // Filtered prop here is Name != DisplayMemberPath ComboText
            return professionalCompetenceName.ToLower().Contains(SearchText.ToLower());
        }

        public ProfessionalCompetenceViewModel(HomeViewModel homeViewModel)
        {
            ProfessionalCompetenceNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().ProfessionalCompetenceNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, ProfessionalCompetenceViewModel>(this, homeViewModel);
        }
    }
}