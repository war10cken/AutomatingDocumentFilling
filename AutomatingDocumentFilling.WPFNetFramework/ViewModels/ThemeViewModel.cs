using System.Collections.Generic;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;
using AutomatingDocumentFilling.WPFNetFramework.Models;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class ThemeViewModel : ViewModelBase
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

        private string _codes;

        public string Codes
        {
            get => _codes;
            set
            {
                _codes = value;
                OnPropertyChanged(nameof(Codes));
            }
        }

        private string _educationHours;

        public string EducationHours
        {
            get => _educationHours;
            set
            {
                _educationHours = value;
                OnPropertyChanged(nameof(EducationHours));
            }
        }
        
        private List<EducationMaterialViewModel> _educationMaterials;

        public List<EducationMaterialViewModel> EducationMaterials
        {
            get => _educationMaterials;
            set
            {
                _educationMaterials = value;
                OnPropertyChanged(nameof(EducationMaterials));
            }
        }

        private List<PracticalTrainingTopicsViewModel> _practicalTrainingTopics;

        public List<PracticalTrainingTopicsViewModel> PracticalTrainingTopics
        {
            get => _practicalTrainingTopics;
            set
            {
                _practicalTrainingTopics = value;
                OnPropertyChanged(nameof(PracticalTrainingTopics));
            }
        }

        public ICommand AddNewEducationMaterialCommand { get; }
        public ICommand AddNewPracticalTrainingTopicCommand { get; }

        
        public ThemeViewModel()
        {
            AddNewEducationMaterialCommand =
                new AddNewItemCommand<ThemeViewModel, EducationMaterialViewModel>(this, nameof(EducationMaterials));
            AddNewEducationMaterialCommand.Execute(null);
            AddNewPracticalTrainingTopicCommand =
                new AddNewItemCommand<ThemeViewModel, PracticalTrainingTopicsViewModel>(this, nameof(PracticalTrainingTopics));
            AddNewPracticalTrainingTopicCommand.Execute(null);
        }
    }
}