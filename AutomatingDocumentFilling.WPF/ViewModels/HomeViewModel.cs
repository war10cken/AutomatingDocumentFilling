using AutomatingDocumentFilling.WPF.Commands;
using AutomatingDocumentFilling.WPF.Models;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPF.ViewModels
{
    public class SkillViewModel : ViewModelBase
    {
        private List<string> _skills;

        public List<string> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }
    }

    public class Skill
    {
        public string Name { get; set; }

        public Skill(string name)
        {
            Name = name;
        }
    }

    public class HomeViewModel : ViewModelBase
    {
        private readonly string _firsPart;
        private readonly string _secondPart;
        private readonly string _thirdPart;
        private readonly string _fourthPart;

        #region Properties

        public ObservableCollection<SkillViewModel> SkillItems { get; set; }

        private string _placeOfDisciplineInStructure;

        public string PlaceOfDisciplineInStructure
        {
            get
            {
                return _placeOfDisciplineInStructure;
            }
            set
            {
                _placeOfDisciplineInStructure = value;
                OnPropertyChanged(nameof(PlaceOfDisciplineInStructure));
            }
        }

        private List<string> _placesOfDisciplineInStructure;

        public List<string> PlacesOfDisciplineInStructure
        {
            get
            {
                return _placesOfDisciplineInStructure;
            }
            set
            {
                _placesOfDisciplineInStructure = value;
                OnPropertyChanged(nameof(PlacesOfDisciplineInStructure));
            }
        }

        private string _order;

        public string Order
        {
            get
            {
                return _order;
            }
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private string _outsideExpertFIO;

        public string OutsideExpertFIO
        {
            get
            {
                return _outsideExpertFIO;
            }
            set
            {
                _outsideExpertFIO = value;
                OnPropertyChanged(nameof(OutsideExpertFIO));
            }
        }

        private string _contentExpertFIO;

        public string ContentExpertFIO
        {
            get
            {
                return _contentExpertFIO;
            }
            set
            {
                _contentExpertFIO = value;
                OnPropertyChanged(nameof(ContentExpertFIO));
            }
        }

        private string _techExpertFIO;

        public string TechExpertFIO
        {
            get
            {
                return _techExpertFIO;
            }
            set
            {
                _techExpertFIO = value;
                OnPropertyChanged(nameof(TechExpertFIO));
            }
        }

        private string _completedBy;

        public string CompletedBy
        {
            get
            {
                return _completedBy;
            }
            set
            {
                _completedBy = value;
                OnPropertyChanged(nameof(CompletedBy));
            }
        }

        private List<string> _codesOfAcademicDiscipline;

        public List<string> CodesOfAcademicDiscipline
        {
            get
            {
                return _codesOfAcademicDiscipline;
            }
            set
            {
                _codesOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodesOfAcademicDiscipline));
            }
        }

        private string _codeOfAcademicDiscipline;

        public string CodeOfAcademicDiscipline
        {
            get
            {
                return _codeOfAcademicDiscipline;
            }
            set
            {
                _codeOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodeOfAcademicDiscipline));
            }
        }

        private List<string> _specialties;

        public List<string> Specialties
        {
            get
            {
                return _specialties;
            }
            set
            {
                _specialties = value;
                OnPropertyChanged(nameof(Specialties));
            }
        }

        private string _specialty;

        public string Specialty
        {
            get
            {
                return _specialty;
            }
            set
            {
                _specialty = value;
                OnPropertyChanged(nameof(Specialty));
            }
        }

        private List<string> _formsOfEducation;

        public List<string> FormsOfEducation
        {
            get
            {
                return _formsOfEducation;
            }
            set
            {
                _formsOfEducation = value;
                OnPropertyChanged(nameof(FormsOfEducation));
            }
        }

        private string _formOfEducation;

        public string FormOfEducation
        {
            get
            {
                return _formOfEducation;
            }
            set
            {
                _formOfEducation = value;
                OnPropertyChanged(nameof(FormOfEducation));
            }
        }

        private string _fullNameOfDeputyDirectorAcademicAffairs;

        public string FullNameOfDeputyDirectorAcademicAffairs
        {
            get
            {
                return _fullNameOfDeputyDirectorAcademicAffairs;
            }
            set
            {
                _fullNameOfDeputyDirectorAcademicAffairs = value;
                OnPropertyChanged(nameof(FullNameOfDeputyDirectorAcademicAffairs));
            }
        }

        private string _fullNameOfDeputyDirectorAcademicMethodologicalWork;

        public string FullNameOfDeputyDirectorAcademicMethodologicalWork
        {
            get
            {
                return _fullNameOfDeputyDirectorAcademicMethodologicalWork;
            }
            set
            {
                _fullNameOfDeputyDirectorAcademicMethodologicalWork = value;
                OnPropertyChanged(nameof(FullNameOfDeputyDirectorAcademicMethodologicalWork));
            }
        }

        private string _fullNameOfChairmanOfMethodologicalCyclicCommission;

        public string FullNameOfChairmanOfMethodologicalCyclicCommission
        {
            get
            {
                return _fullNameOfChairmanOfMethodologicalCyclicCommission;
            }
            set
            {
                _fullNameOfChairmanOfMethodologicalCyclicCommission = value;
                OnPropertyChanged(nameof(FullNameOfChairmanOfMethodologicalCyclicCommission));
            }
        }

        #endregion Properties

        public ICommand OpenDocumentCommand { get; }

        public ICommand ShowWindowCommand { get; }

        public ICommand GetCodesOfAcademicDisciplineCommand { get; }

        public ICommand GetSpecialtiesCommand { get; }

        public ICommand GetFormsOfEducationCommand { get; }

        public ICommand GetPlacesOfDisciplineInStructureCommand { get; }

        public ICommand GetSkillsCommand { get; }

        public ICommand GetArrayFromJsonCommand { get; }

        private List<Skill> _skills = new List<Skill>
        {
            new Skill("13"),
            new Skill("234")
        };

        public List<Skill> Skills
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        public HomeViewModel(DocumentViewModel documentViewModel, string firsPart, string secondPart, string thirdPart, string fourthPart)
        {
            _firsPart = firsPart;
            _secondPart = secondPart;
            _thirdPart = thirdPart;
            _fourthPart = fourthPart;

            GetArrayFromJsonCommand =
                new GetArrayFromJsonCommand(nameof(CodesOfAcademicDiscipline), this);
            GetArrayFromJsonCommand.Execute(null);

            GetFormsOfEducationCommand = new GetArrayFromJsonCommand(nameof(FormsOfEducation), this);
            GetFormsOfEducationCommand.Execute(null);
            // GetSpecialtiesCommand = new GetSpecialtiesCommand(this);
            // GetCodesOfAcademicDisciplineCommand = new GetCodesOfAcademicDisciplineCommand(this);
            // GetPlacesOfDisciplineInStructureCommand = new GetPlacesOfDisciplineInStructureCommand(this);
            GetSkillsCommand = new GetSkillsCommand(new SkillViewModel());

            // GetSkillsCommand.Execute(null);
            // GetCodesOfAcademicDisciplineCommand.Execute(null);
            // GetSpecialtiesCommand.Execute(null);
            // GetFormsOfEducationCommand.Execute(null);
            // GetPlacesOfDisciplineInStructureCommand.Execute(null);

            documentViewModel.OpenDocumentCommand = new OpenDocumentCommand(documentViewModel, _firsPart,
                                                                            _secondPart, _thirdPart, _fourthPart);

            ShowWindowCommand = new ShowWindowCommand(documentViewModel.OpenDocumentCommand,
                                                      this, documentViewModel,
                                                      _firsPart, _secondPart,
                                                      _thirdPart, _fourthPart);
        }
    }
}