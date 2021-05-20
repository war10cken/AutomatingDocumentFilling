using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class SectionViewModel : ViewModelBase
    {
        private string _sectionName;

        public string SectionName
        {
            get => _sectionName;
            set
            {
                _sectionName = value;
                OnPropertyChanged(nameof(SectionName));
            }
        }

        private List<ThemeViewModel> _themes;

        public List<ThemeViewModel> Themes
        {
            get => _themes;
            set
            {
                _themes = value;
                OnPropertyChanged(nameof(Themes));
            }
        }

        public ICommand AddNewThemeCommand { get; }

        public ICommand DeleteCommand { get; }

        public SectionViewModel(HomeViewModel homeViewModel)
        {
            AddNewThemeCommand = new AddNewItemCommand<SectionViewModel, ThemeViewModel>(this, nameof(Themes));
            DeleteCommand = new DeleteItemCommand<HomeViewModel, SectionViewModel>(this, homeViewModel);
        }
    }
}