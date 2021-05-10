using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Commands;
using AutomatingDocumentFilling.WPFNetFramework.Models;

namespace AutomatingDocumentFilling.WPFNetFramework.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly string _documentName;

        #region Properties

        #region BoolProperties

        private bool _isHasConsultation;

        public bool IsHasConsultation
        {
            get => _isHasConsultation;
            set
            {
                _isHasConsultation = value;
                OnPropertyChanged(nameof(IsHasConsultation));
            }
        }

        private bool _isButtonEnable;

        public bool IsButtonEnable
        {
            get => _isButtonEnable;
            set
            {
                _isButtonEnable = value;
                OnPropertyChanged(nameof(IsButtonEnable));
            }
        }

        private bool _isLaboratory;

        public bool IsLaboratory
        {
            get => _isLaboratory;
            set
            {
                _isLaboratory = value;
                OnPropertyChanged(nameof(IsLaboratory));
            }
        }

        private bool _isWorkshop;

        public bool IsWorkshop
        {
            get => _isWorkshop;
            set
            {
                _isWorkshop = value;
                OnPropertyChanged(nameof(IsWorkshop));
            }
        }

        private bool _isEducationRoom;

        public bool IsEducationRoom
        {
            get => _isEducationRoom;
            set
            {
                _isEducationRoom = value;
                OnPropertyChanged(nameof(IsEducationRoom));
            }
        }

        #endregion BoolProperties

        #region ListProperties

        private string _consultationHours;

        public string ConsultationHours
        {
            get => _consultationHours;
            set
            {
                _consultationHours = value;
                OnPropertyChanged(nameof(ConsultationHours));
            }
        }

        private string _certificationForm;

        public string CertificationForm
        {
            get => _certificationForm;
            set
            {
                _certificationForm = value;
                OnPropertyChanged(nameof(CertificationForm));
            }
        }

        private List<string> _certificationForms;

        public List<string> CertificationForms
        {
            get => _certificationForms;
            set
            {
                _certificationForms = value;
                OnPropertyChanged(nameof(CertificationForms));
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

        private List<CourseWorkViewModel> _topicsOfCourseWork;

        public List<CourseWorkViewModel> TopicsOfCourseWork
        {
            get => _topicsOfCourseWork;
            set
            {
                _topicsOfCourseWork = value;
                OnPropertyChanged(nameof(TopicsOfCourseWork));
            }
        }

        private List<InternetResourcesViewModel> _internetResources;

        public List<InternetResourcesViewModel> InternetResources
        {
            get => _internetResources;
            set
            {
                _internetResources = value;
                OnPropertyChanged(nameof(InternetResources));
            }
        }

        private List<AdditionalResourcesViewModel> _additionalResources;

        public List<AdditionalResourcesViewModel> AdditionalResources
        {
            get => _additionalResources;
            set
            {
                _additionalResources = value;
                OnPropertyChanged(nameof(AdditionalResources));
            }
        }

        private List<MainResourcesViewModel> _mainResources;

        public List<MainResourcesViewModel> MainResources
        {
            get => _mainResources;
            set
            {
                _mainResources = value;
                OnPropertyChanged(nameof(MainResources));
            }
        }

        private List<ProfessionalCompetenceViewModel> _professionalCompetence;

        public List<ProfessionalCompetenceViewModel> ProfessionalCompetence
        {
            get => _professionalCompetence;
            set
            {
                _professionalCompetence = value;
                OnPropertyChanged(nameof(ProfessionalCompetence));
            }
        }

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

        private List<SkillViewModel> _skills;

        public List<SkillViewModel> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        private List<KnowledgeViewModel> _knowledge;

        public List<KnowledgeViewModel> Knowledge
        {
            get => _knowledge;
            set
            {
                _knowledge = value;
                OnPropertyChanged(nameof(Knowledge));
            }
        }

        #endregion ListProperties

        #region CountProperties

        private string _countOfProfessionalCompetence;

        public string CountOfProfessionalCompetence
        {
            get => _countOfProfessionalCompetence;
            set
            {
                _countOfProfessionalCompetence = value;
                OnPropertyChanged(nameof(CountOfProfessionalCompetence));
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

        #endregion CountProperties

        private string _courseWorkHours;

        public string CourseWorkHours
        {
            get => _courseWorkHours;
            set
            {
                _courseWorkHours = value;
                OnPropertyChanged(nameof(CourseWorkHours));
            }
        }

        private string _laboratoryRoomNumber;

        public string LaboratoryRoomNumber
        {
            get => _laboratoryRoomNumber;
            set
            {
                _laboratoryRoomNumber = value;
                OnPropertyChanged(nameof(LaboratoryRoomNumber));
            }
        }

        private string _workshopRoomNumber;

        public string WorkshopRoomNumber
        {
            get => _workshopRoomNumber;
            set
            {
                _workshopRoomNumber = value;
                OnPropertyChanged(nameof(WorkshopRoomNumber));
            }
        }

        private string _educationRoomNumber;

        public string EducationRoomNumber
        {
            get => _educationRoomNumber;
            set
            {
                _educationRoomNumber = value;
                OnPropertyChanged(nameof(EducationRoomNumber));
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

        #region GetCommands

        public ICommand ShowWindowCommand { get; }

        public ICommand GetCodesOfAcademicDisciplineCommand { get; }

        public ICommand GetSpecialtiesCommand { get; }

        public ICommand GetFormsOfEducationCommand { get; }

        public ICommand GetPlacesOfDisciplineInStructureCommand { get; }

        public ICommand GetCertificationFormsCommand { get; }

        #endregion GetCommands

        #region AddCommands

        public ICommand AddNewSkillCommand { get; }

        public ICommand AddNewKnowledgeCommand { get; }

        public ICommand AddNewGeneralCompetenceCommand { get; }

        public ICommand AddNewProfessionalCompetenceCommand { get; }

        public ICommand AddNewResource { get; }

        public ICommand AddNewAdditionalResource { get; }

        public ICommand AddNewInternetResource { get; }

        public ICommand AddNewThemeCommand { get; }

        public ICommand AddNewCourseWorkCommand { get; }

        #endregion AddCommands

        public HomeViewModel(DocumentViewModel documentViewModel, string documentName, string outputName)
        {
            _documentName = documentName;

            AddNewCourseWorkCommand = new AddNewItemCommand<HomeViewModel, CourseWorkViewModel>(this, nameof(TopicsOfCourseWork));
            AddNewThemeCommand =
                new AddNewItemCommand<HomeViewModel, ThemeViewModel>(this, nameof(Themes));
            AddNewInternetResource =
                new AddNewItemCommand<HomeViewModel, InternetResourcesViewModel>(this, nameof(InternetResources));
            AddNewInternetResource.Execute(null);
            AddNewAdditionalResource =
                new AddNewItemCommand<HomeViewModel, AdditionalResourcesViewModel>(this, nameof(AdditionalResources));
            AddNewAdditionalResource.Execute(null);
            AddNewResource = new AddNewItemCommand<HomeViewModel, MainResourcesViewModel>(this, nameof(MainResources));
            AddNewResource.Execute(null);
            AddNewProfessionalCompetenceCommand =
                new AddNewItemCommand<HomeViewModel, ProfessionalCompetenceViewModel>(this,
                                                                                      nameof(ProfessionalCompetence),
                                                                                      nameof(
                                                                                          CountOfProfessionalCompetence));
            AddNewGeneralCompetenceCommand =
                new AddNewItemCommand<HomeViewModel, GeneralCompetenceViewModel>(this, nameof(GeneralCompetences),
                                                                                 nameof(CountOfGeneralCompetences));
            AddNewKnowledgeCommand =
                new AddNewItemCommand<HomeViewModel, KnowledgeViewModel>(this, nameof(Knowledge),
                                                                         nameof(CountOfKnowledge));
            AddNewSkillCommand = new AddNewItemCommand<HomeViewModel, SkillViewModel>(this, nameof(Skills),
                                                                                      nameof(CountOfSkills));

            GetCertificationFormsCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(CertificationForms), this);
            GetFormsOfEducationCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(FormsOfEducation), this);
            GetSpecialtiesCommand = new GetArrayFromJsonCommand<HomeViewModel>(nameof(Specialties), this);
            GetCodesOfAcademicDisciplineCommand =
                new GetArrayFromJsonCommand<HomeViewModel>(nameof(CodesOfAcademicDiscipline), this);
            GetPlacesOfDisciplineInStructureCommand =
                new GetArrayFromJsonCommand<HomeViewModel>(nameof(PlacesOfDisciplineInStructure), this);

            GetCertificationFormsCommand.Execute(null);
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