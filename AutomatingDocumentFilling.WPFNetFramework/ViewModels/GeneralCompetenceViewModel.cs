using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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

                GeneralCompetences = (CollectionView)new CollectionViewSource { Source = _generalCompetenceNames }.View;
                GeneralCompetences.Filter = DropDownFilter;
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

        public CollectionView GeneralCompetences { get; private set; }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (_searchText != SelectedText) GeneralCompetences.Refresh();
            }
        }

        private bool DropDownFilter(object item)
        {
            string generalCompetenceName = item as string;
            if (generalCompetenceName == null) return false;

            // No filter
            if (string.IsNullOrEmpty(SearchText)) return true;
            // Filtered prop here is Name != DisplayMemberPath ComboText
            return generalCompetenceName.ToLower().Contains(SearchText.ToLower());
        }

        public GeneralCompetenceViewModel(HomeViewModel homeViewModel)
        {
            GeneralCompetenceNames = homeViewModel.Specialties.Where(s => s.Name == homeViewModel.Specialty).FirstOrDefault().GeneralCompetenceNames;
            DeleteCommand = new DeleteItemCommand<HomeViewModel, GeneralCompetenceViewModel>(this, homeViewModel);
        }
    }
}