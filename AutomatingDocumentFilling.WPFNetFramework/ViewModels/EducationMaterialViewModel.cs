﻿using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class EducationMaterialViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _educationLevel;

        public string EducationLevel
        {
            get => _educationLevel;
            set
            {
                _educationLevel = value;
                OnPropertyChanged(nameof(EducationLevel));
            }
        }

        public ICommand DeleteCommand { get; }

        public EducationMaterialViewModel(ThemeViewModel themeViewModel)
        {
            DeleteCommand = new DeleteItemCommand<ThemeViewModel, EducationMaterialViewModel>(this, themeViewModel);
        }
    }
}