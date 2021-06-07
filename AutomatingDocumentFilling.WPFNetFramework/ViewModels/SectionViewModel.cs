using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;
using Xceed.Document.NET;

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

        private float _totalHours;

        public float TotalHours
        {
            get => _totalHours;
            set
            {
                _totalHours = value;
                OnPropertyChanged(nameof(TotalHours));
            }
        }

        private List<Table> _tables;

        public List<Table> Tables
        {
            get => _tables;
            set
            {
                _tables = value;
                OnPropertyChanged(nameof(Tables));
            }
        }

        public ICommand AddNewThemeCommand { get; }

        public ICommand DeleteCommand { get; }

        public SectionViewModel(HomeViewModel homeViewModel)
        {
            AddNewThemeCommand = new AddNewItemCommand<SectionViewModel, ThemeViewModel>(this, nameof(Themes));
            AddNewThemeCommand.Execute(null);
            DeleteCommand = new DeleteItemCommand<HomeViewModel, SectionViewModel>(this, homeViewModel);
        }
    }
}