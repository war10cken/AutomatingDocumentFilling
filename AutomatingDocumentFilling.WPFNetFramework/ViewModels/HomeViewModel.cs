using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly string _documentName;

        #region Properties

            private List<GeneralCompetenceViewModel> _generalCompetences;

            public List<GeneralCompetenceViewModel> GeneralCompetences
            {
                get => _generalCompetences;
                set
                {
                    _generalCompetences = value;
                    OnPropertyChanged(nameof(GeneralCompetences));
                }
            }
            
            private List<SkillViewModel> _skills = new();

            public List<SkillViewModel> Skills
            {
                get => _skills;
                set
                {
                    _skills = value;
                    OnPropertyChanged(nameof(Skills));
                }
            }

            private List<KnowledgeViewModel> _knowledge = new();

            public List<KnowledgeViewModel> Knowledge
            {
                get => _knowledge;
                set
                {
                    _knowledge = value;
                    OnPropertyChanged(nameof(Knowledge));
                }
            }

            private string _countOfSkills;

            public string CountOfSkills
            {
                get => _countOfSkills;
                set
                {
                    _countOfSkills = value;
                    OnPropertyChanged(nameof(CountOfSkills));
                }
            }

            private string _countOfKnowledge;

            public string CountOfKnowledge
            {
                get => _countOfKnowledge;
                set
                {
                    _countOfKnowledge = value;
                    OnPropertyChanged(nameof(CountOfKnowledge));
                }
            }

            private string _countOfGeneralCompetences;

            public string CountOfGeneralCompetences
            {
                get => _countOfGeneralCompetences;
                set
                {
                    _countOfGeneralCompetences = value;
                    OnPropertyChanged(nameof(CountOfGeneralCompetences));
                }
            }

        private string _placeOfDisciplineInStructure;

        public string PlaceOfDisciplineInStructure
        {
            get => _placeOfDisciplineInStructure;
            set
            {
                _placeOfDisciplineInStructure = value;
                OnPropertyChanged(nameof(PlaceOfDisciplineInStructure));
            }
        }

        private List<string> _placesOfDisciplineInStructure;

        public List<string> PlacesOfDisciplineInStructure
        {
            get => _placesOfDisciplineInStructure;
            set
            {
                _placesOfDisciplineInStructure = value;
                OnPropertyChanged(nameof(PlacesOfDisciplineInStructure));
            }
        }

        private string _order = "q";

        public string Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private string _outsideExpertFio = "q";

        public string OutsideExpertFio
        {
            get => _outsideExpertFio;
            set
            {
                _outsideExpertFio = value;
                OnPropertyChanged(nameof(OutsideExpertFio));
            }
        }

        private string _contentExpertFio = "q";

        public string ContentExpertFio
        {
            get => _contentExpertFio;
            set
            {
                _contentExpertFio = value;
                OnPropertyChanged(nameof(ContentExpertFio));
            }
        }

        private string _techExpertFio = "q";

        public string TechExpertFio
        {
            get => _techExpertFio;
            set
            {
                _techExpertFio = value;
                OnPropertyChanged(nameof(TechExpertFio));
            }
        }

        private string _completedBy = "q";

        public string CompletedBy
        {
            get => _completedBy;
            set
            {
                _completedBy = value;
                OnPropertyChanged(nameof(CompletedBy));
            }
        }

        private List<string> _codesOfAcademicDiscipline;

        public List<string> CodesOfAcademicDiscipline
        {
            get => _codesOfAcademicDiscipline;
            set
            {
                _codesOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodesOfAcademicDiscipline));
            }
        }

        private string _codeOfAcademicDiscipline;

        public string CodeOfAcademicDiscipline
        {
            get => _codeOfAcademicDiscipline;
            set
            {
                _codeOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodeOfAcademicDiscipline));
            }
        }

        private List<string> _specialties;

        public List<string> Specialties
        {
            get => _specialties;
            set
            {
                _specialties = value;
                OnPropertyChanged(nameof(Specialties));
            }
        }

        private string _specialty;

        public string Specialty
        {
            get => _specialty;
            set
            {
                _specialty = value;
                OnPropertyChanged(nameof(Specialty));
            }
        }

        private List<string> _formsOfEducation;

        public List<string> FormsOfEducation
        {
            get => _formsOfEducation;
            set
            {
                _formsOfEducation = value;
                OnPropertyChanged(nameof(FormsOfEducation));
            }
        }

        private string _formOfEducation;

        public string FormOfEducation
        {
            get => _formOfEducation;
            set
            {
                _formOfEducation = value;
                OnPropertyChanged(nameof(FormOfEducation));
            }
        }

        private string _fullNameOfDeputyDirectorAcademicAffairs = "q";

        public string FullNameOfDeputyDirectorAcademicAffairs
        {
            get => _fullNameOfDeputyDirectorAcademicAffairs;
            set
            {
                _fullNameOfDeputyDirectorAcademicAffairs = value;
                OnPropertyChanged(nameof(FullNameOfDeputyDirectorAcademicAffairs));
            }
        }

        private string _fullNameOfDeputyDirectorAcademicMethodologicalWork = "q";

        public string FullNameOfDeputyDirectorAcademicMethodologicalWork
        {
            get => _fullNameOfDeputyDirectorAcademicMethodologicalWork;
            set
            {
                _fullNameOfDeputyDirectorAcademicMethodologicalWork = value;
                OnPropertyChanged(nameof(FullNameOfDeputyDirectorAcademicMethodologicalWork));
            }
        }

        private string _fullNameOfChairmanOfMethodologicalCyclicCommission = "q";

        public string FullNameOfChairmanOfMethodologicalCyclicCommission
        {
            get => _fullNameOfChairmanOfMethodologicalCyclicCommission;
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

        public ICommand AddNewSkillCommand { get; }

        public ICommand AddNewKnowledgeCommand { get; }

        public ICommand AddNewGeneralCompetenceCommand { get; }
        
        
        public HomeViewModel(DocumentViewModel documentViewModel, string documentName, string outputName)
        {
            _documentName = documentName;

            AddNewGeneralCompetenceCommand =
                new AddNewItemCommand<GeneralCompetenceViewModel>(this, nameof(GeneralCompetences),
                                                                  nameof(CountOfGeneralCompetences));
            AddNewKnowledgeCommand =
                new AddNewItemCommand<KnowledgeViewModel>(this, nameof(Knowledge),
                                                          nameof(CountOfKnowledge));
            AddNewSkillCommand = new AddNewItemCommand<SkillViewModel>(this, nameof(Skills),
                                                                       nameof(CountOfSkills));
            GetFormsOfEducationCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(FormsOfEducation), this);
            GetSpecialtiesCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(Specialties), this);
            GetCodesOfAcademicDisciplineCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(CodesOfAcademicDiscipline), this);
            GetPlacesOfDisciplineInStructureCommand =
                new GetArrayFromJsonCommand<HomeViewModel>(nameof(PlacesOfDisciplineInStructure), this);

            GetCodesOfAcademicDisciplineCommand.Execute(null);
            GetSpecialtiesCommand.Execute(null);
            GetFormsOfEducationCommand.Execute(null);
            GetPlacesOfDisciplineInStructureCommand.Execute(null);

            documentViewModel.OpenDocumentCommand = new OpenDocumentCommand(documentViewModel, outputName);

            ShowWindowCommand = new ShowWindowCommand(documentViewModel.OpenDocumentCommand,
                                                      this, documentViewModel, _documentName);
        }
    }
}