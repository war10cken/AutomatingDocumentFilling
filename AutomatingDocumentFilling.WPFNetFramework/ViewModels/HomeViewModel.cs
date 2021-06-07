using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
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

        private bool _isTopFifty;

        public bool IsTopFifty
        {
            get => _isTopFifty;
            set
            {
                _isTopFifty = value;
                OnPropertyChanged(nameof(IsTopFifty));
            }
        }

        private bool _isSaved;

        public bool IsSaved
        {
            get => _isSaved;
            set
            {
                _isSaved = value;
                OnPropertyChanged(nameof(IsSaved));
            }
        }

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

        private List<string> _qualificationNames;

        public List<string> QualificationNames
        {
            get => _qualificationNames;
            set
            {
                _qualificationNames = value;
                OnPropertyChanged(nameof(QualificationNames));
            }
        }

        private string _qualificationName;

        public string QualificationName
        {
            get => _qualificationName;
            set
            {
                _qualificationName = value;
                OnPropertyChanged(nameof(QualificationName));
            }
        }

        private List<Qualification> _qualifications;

        public List<Qualification> Qualifications
        {
            get => _qualifications;
            set
            {
                _qualifications = value;
                OnPropertyChanged(nameof(Qualifications));

                QualificationNames = _qualifications.Select(q => q.Name).ToList();
            }
        }

        private List<string> _codesNameOfAcademicDiscipline;

        public List<string> CodesNameOfAcademicDiscipline
        {
            get => _codesNameOfAcademicDiscipline;
            set
            {
                _codesNameOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodesNameOfAcademicDiscipline));
            }
        }

        private List<IndependentWorkViewModel> _independentWorks;

        public List<IndependentWorkViewModel> IndependentWorks
        {
            get => _independentWorks;
            set
            {
                _independentWorks = value;
                OnPropertyChanged(nameof(IndependentWorks));
            }
        }

        private List<string> _cycles;

        public List<string> Cycles
        {
            get => _cycles;
            set
            {
                _cycles = value;
                OnPropertyChanged(nameof(Cycles));
            }
        }

        private List<LaboratoryEquipmentViewModel> _laboratoryEquipments;

        public List<LaboratoryEquipmentViewModel> LaboratoryEquipments
        {
            get => _laboratoryEquipments;
            set
            {
                _laboratoryEquipments = value;
                OnPropertyChanged(nameof(LaboratoryEquipments));
            }
        }

        private List<WorkshopEquipmentViewModel> _workshopEquipments;

        public List<WorkshopEquipmentViewModel> WorkshopEquipments
        {
            get => _workshopEquipments;
            set
            {
                _workshopEquipments = value;
                OnPropertyChanged(nameof(WorkshopEquipments));
            }
        }

        private List<ClassroomEquipmentViewModel> _classroomEquipments;

        public List<ClassroomEquipmentViewModel> ClassroomEquipments
        {
            get => _classroomEquipments;
            set
            {
                _classroomEquipments = value;
                OnPropertyChanged(nameof(ClassroomEquipments));
            }
        }

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

        private List<SectionViewModel> _sections;

        public List<SectionViewModel> Sections
        {
            get => _sections;
            set
            {
                _sections = value;
                OnPropertyChanged(nameof(Sections));
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

        private List<CourseWorkViewModel> _courseWorks;

        public List<CourseWorkViewModel> CourseWorks
        {
            get => _courseWorks;
            set
            {
                _courseWorks = value;
                OnPropertyChanged(nameof(CourseWorks));
            }
        }

        private List<InternetResourceViewModel> _internetResources;

        public List<InternetResourceViewModel> InternetResources
        {
            get => _internetResources;
            set
            {
                _internetResources = value;
                OnPropertyChanged(nameof(InternetResources));
            }
        }

        private List<AdditionalResourceViewModel> _additionalResources;

        public List<AdditionalResourceViewModel> AdditionalResources
        {
            get => _additionalResources;
            set
            {
                _additionalResources = value;
                OnPropertyChanged(nameof(AdditionalResources));
            }
        }

        private List<MainResourceViewModel> _mainResources;

        public List<MainResourceViewModel> MainResources
        {
            get => _mainResources;
            set
            {
                _mainResources = value;
                OnPropertyChanged(nameof(MainResources));
            }
        }

        private List<ProfessionalCompetenceViewModel> _professionalCompetences;

        public List<ProfessionalCompetenceViewModel> ProfessionalCompetences
        {
            get => _professionalCompetences;
            set
            {
                _professionalCompetences = value;
                OnPropertyChanged(nameof(ProfessionalCompetences));
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

        private List<KnowledgeViewModel> _knowledges;

        public List<KnowledgeViewModel> Knowledges
        {
            get => _knowledges;
            set
            {
                _knowledges = value;
                OnPropertyChanged(nameof(Knowledges));
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

        private string _certificationFormHours;

        public string CertificationFormHours
        {
            get => _certificationFormHours;
            set
            {
                _certificationFormHours = value;
                OnPropertyChanged(nameof(CertificationFormHours));
            }
        }

        private string _secondCertificationFormHours;

        public string SecondCertificationFormHours
        {
            get => _secondCertificationFormHours;
            set
            {
                _secondCertificationFormHours = value;
                OnPropertyChanged(nameof(SecondCertificationFormHours));
            }
        }

        private string _secondConsultationHours;

        public string SecondConsultationHours
        {
            get => _secondConsultationHours;
            set
            {
                _secondConsultationHours = value;
                OnPropertyChanged(nameof(SecondConsultationHours));
            }
        }

        private List<string> _secondCertificationForms;

        public List<string> SecondCertificationForms
        {
            get => _secondCertificationForms;
            set
            {
                _secondCertificationForms = value;
                OnPropertyChanged(nameof(SecondCertificationForms));
            }
        }

        private string _secondCertificationForm;

        public string SecondCertificationForm
        {
            get => _secondCertificationForm;
            set
            {
                _secondCertificationForm = value;
                OnPropertyChanged(nameof(SecondCertificationForm));
            }
        }

        private string _consultingHours;

        public string ConsultingHours
        {
            get => _consultingHours;
            set
            {
                _consultingHours = value;
                OnPropertyChanged(nameof(ConsultingHours));
            }
        }

        private string _testHours;

        public string TestHours
        {
            get => _testHours;
            set
            {
                _testHours = value;
                OnPropertyChanged(nameof(TestHours));
            }
        }

        private string _courseWorkHoursWithCondition;

        public string CourseWorkHoursWithCondition
        {
            get => _courseWorkHoursWithCondition;
            set
            {
                _courseWorkHoursWithCondition = value;
                OnPropertyChanged(nameof(CourseWorkHoursWithCondition));
            }
        }

        private string _practicalLessonsHours;

        public string PracticalLessonsHours
        {
            get => _practicalLessonsHours;
            set
            {
                _practicalLessonsHours = value;
                OnPropertyChanged(nameof(PracticalLessonsHours));
            }
        }

        private string _laboratoryWorksHours;

        public string LaboratoryWorksHours
        {
            get => _laboratoryWorksHours;
            set
            {
                _laboratoryWorksHours = value;
                OnPropertyChanged(nameof(LaboratoryWorksHours));
            }
        }

        private string _theoreticalTeachingHours;

        public string TheoreticalTeachingHours
        {
            get => _theoreticalTeachingHours;
            set
            {
                _theoreticalTeachingHours = value;
                OnPropertyChanged(nameof(TheoreticalTeachingHours));
            }
        }

        private string _volumeOfEducationalProgramHours;

        public string VolumeOfEducationalProgramHours
        {
            get => _volumeOfEducationalProgramHours;
            set
            {
                _volumeOfEducationalProgramHours = value;
                OnPropertyChanged(nameof(VolumeOfEducationalProgramHours));
            }
        }

        private string _independentWorkHours;

        public string IndependentWorkHours
        {
            get => _independentWorkHours;
            set
            {
                _independentWorkHours = value;
                OnPropertyChanged(nameof(IndependentWorkHours));
            }
        }

        private string _totalTeachingLoadHours;

        public string TotalTeachingLoadHours
        {
            get => _totalTeachingLoadHours;
            set
            {
                _totalTeachingLoadHours = value;
                OnPropertyChanged(nameof(TotalTeachingLoadHours));
            }
        }

        private string _cycle;

        public string Cycle
        {
            get => _cycle;
            set
            {
                _cycle = value;
                OnPropertyChanged(nameof(Cycle));
            }
        }

        private string _currentYear;

        public string CurrentYear
        {
            get => _currentYear;
            set
            {
                _currentYear = value;
                OnPropertyChanged(nameof(CurrentYear));
            }
        }

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

        private string _laboratoryRoomName;

        public string LaboratoryRoomName
        {
            get => _laboratoryRoomName;
            set
            {
                _laboratoryRoomName = value;
                OnPropertyChanged(nameof(LaboratoryRoomName));
            }
        }

        private string _workshopRoomName;

        public string WorkshopRoomName
        {
            get => _workshopRoomName;
            set
            {
                _workshopRoomName = value;
                OnPropertyChanged(nameof(WorkshopRoomName));
            }
        }

        private string _educationRoomName;

        public string EducationRoomName
        {
            get => _educationRoomName;
            set
            {
                _educationRoomName = value;
                OnPropertyChanged(nameof(EducationRoomName));
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

        private string _order;

        public string Order
        {
            get => _order;
            set
            {
                _order = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private string _outsideExpertFio;

        public string OutsideExpertFio
        {
            get => _outsideExpertFio;
            set
            {
                _outsideExpertFio = value;
                OnPropertyChanged(nameof(OutsideExpertFio));
            }
        }

        private string _contentExpertFio;

        public string ContentExpertFio
        {
            get => _contentExpertFio;
            set
            {
                _contentExpertFio = value;
                OnPropertyChanged(nameof(ContentExpertFio));
            }
        }

        private string _techExpertFio;

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

        private List<CodeOfAcademicDiscipline> _codesOfAcademicDiscipline;

        public List<CodeOfAcademicDiscipline> CodesOfAcademicDiscipline
        {
            get => _codesOfAcademicDiscipline;
            set
            {
                _codesOfAcademicDiscipline = value;
                OnPropertyChanged(nameof(CodesOfAcademicDiscipline));

                List<string> names = new();
                names.AddRange(_codesOfAcademicDiscipline.Select(c => c.Name));
                CodesNameOfAcademicDiscipline = names;
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

                List<string> names = new();
                names.AddRange(CodesOfAcademicDiscipline.Where(c => c.Name == _codeOfAcademicDiscipline)
                    .FirstOrDefault().Specialties.Select(s => s.Name));
                SpecialtiesName = names;

                Specialties = CodesOfAcademicDiscipline.Find(c => c.Name == CodeOfAcademicDiscipline).Specialties;
            }
        }

        private List<string> _specialtiesName;

        public List<string> SpecialtiesName
        {
            get => _specialtiesName;
            set
            {
                _specialtiesName = value;
                OnPropertyChanged(nameof(SpecialtiesName));
                _searchText = _specialtiesName[0];

                SpecialtiesView = (CollectionView)new CollectionViewSource { Source = _specialtiesName }.View;
                SpecialtiesView.Filter = DropDownFilter;
            }
        }

        private List<Specialty> _specialties;

        public List<Specialty> Specialties
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

        public ICommand GetSecondCertificationFormsCommand { get; }

        public ICommand GetCyclesCommand { get; }

        public ICommand GetQualificationsCommand { get; }

        #endregion GetCommands

        #region AddCommands

        public ICommand AddNewSkillCommand { get; }

        public ICommand AddNewKnowledgeCommand { get; }

        public ICommand AddNewGeneralCompetenceCommand { get; }

        public ICommand AddNewProfessionalCompetenceCommand { get; }

        public ICommand AddNewResource { get; }

        public ICommand AddNewAdditionalResource { get; }

        public ICommand AddNewInternetResource { get; }

        public ICommand AddNewCourseWorkCommand { get; }

        public ICommand AddNewSectionCommand { get; }

        public ICommand AddNewClassroomEquipmentCommand { get; }

        public ICommand AddNewWorkshopEquipmentCommand { get; }

        public ICommand AddNewLaboratoryEquipmentCommand { get; }

        public ICommand AddNewIndependentWorkCommand { get; }

        #endregion AddCommands

        public ICommand SaveCommand { get; }

        private CollectionView _specialtiesView;

        public CollectionView SpecialtiesView
        {
            get => _specialtiesView;
            set
            {
                _specialtiesView = value;
                OnPropertyChanged(nameof(SpecialtiesView));
            }
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                if (_searchText != Specialty) SpecialtiesView.Refresh();
            }
        }

        private bool DropDownFilter(object item)
        {
            string specialtyName = item as string;
            if (specialtyName == null) return false;

            // No filter
            if (string.IsNullOrEmpty(SearchText)) return true;
            // Filtered prop here is Name != DisplayMemberPath ComboText
            return specialtyName.ToLower().Contains(SearchText.ToLower());
        }

        public HomeViewModel(DocumentViewModel documentViewModel, string documentName, string outputName)
        {
            _documentName = documentName;

            AddNewIndependentWorkCommand =
                new AddNewItemCommand<HomeViewModel, IndependentWorkViewModel>(this, nameof(IndependentWorks));
            AddNewIndependentWorkCommand.Execute(null);
            AddNewLaboratoryEquipmentCommand =
                new AddNewItemCommand<HomeViewModel, LaboratoryEquipmentViewModel>(this, nameof(LaboratoryEquipments));
            AddNewWorkshopEquipmentCommand =
                new AddNewItemCommand<HomeViewModel, WorkshopEquipmentViewModel>(this, nameof(WorkshopEquipments));
            AddNewClassroomEquipmentCommand =
                new AddNewItemCommand<HomeViewModel, ClassroomEquipmentViewModel>(this, nameof(ClassroomEquipments));
            AddNewSectionCommand = new AddNewItemCommand<HomeViewModel, SectionViewModel>(this, nameof(Sections));
            AddNewSectionCommand.Execute(null);
            SaveCommand = new SaveCommand(this, documentName);
            AddNewCourseWorkCommand = new AddNewItemCommand<HomeViewModel, CourseWorkViewModel>(this, nameof(CourseWorks));
            AddNewCourseWorkCommand.Execute(null);
            AddNewInternetResource =
                new AddNewItemCommand<HomeViewModel, InternetResourceViewModel>(this, nameof(InternetResources));
            AddNewInternetResource.Execute(null);
            AddNewAdditionalResource =
                new AddNewItemCommand<HomeViewModel, AdditionalResourceViewModel>(this, nameof(AdditionalResources));
            AddNewAdditionalResource.Execute(null);
            AddNewResource = new AddNewItemCommand<HomeViewModel, MainResourceViewModel>(this, nameof(MainResources));
            AddNewResource.Execute(null);
            AddNewProfessionalCompetenceCommand =
                new AddNewItemCommand<HomeViewModel, ProfessionalCompetenceViewModel>(this,
                                                                                      nameof(ProfessionalCompetences));
            AddNewGeneralCompetenceCommand =
                new AddNewItemCommand<HomeViewModel, GeneralCompetenceViewModel>(this, nameof(GeneralCompetences));
            AddNewKnowledgeCommand =
                new AddNewItemCommand<HomeViewModel, KnowledgeViewModel>(this, nameof(Knowledges));
            AddNewSkillCommand = new AddNewItemCommand<HomeViewModel, SkillViewModel>(this, nameof(Skills));

            GetQualificationsCommand =
                new GetArrayFromJsonCommand<HomeViewModel, List<Qualification>>(nameof(Qualifications), this);
            GetSecondCertificationFormsCommand =
                new GetArrayFromJsonCommand<HomeViewModel, List<string>>(nameof(SecondCertificationForms), this);
            GetCyclesCommand = new GetArrayFromJsonCommand<HomeViewModel, List<string>>(nameof(Cycles), this);
            GetCertificationFormsCommand = new GetArrayFromJsonCommand<HomeViewModel, List<string>>(nameof(CertificationForms), this);
            GetFormsOfEducationCommand = new GetArrayFromJsonCommand<HomeViewModel, List<string>>(nameof(FormsOfEducation), this);
            GetCodesOfAcademicDisciplineCommand =
                new GetArrayFromJsonCommand<HomeViewModel, List<CodeOfAcademicDiscipline>>(nameof(CodesOfAcademicDiscipline), this);
            GetPlacesOfDisciplineInStructureCommand =
                new GetArrayFromJsonCommand<HomeViewModel, List<string>>(nameof(PlacesOfDisciplineInStructure), this);

            GetQualificationsCommand.Execute(null);
            GetCyclesCommand.Execute(null);
            GetSecondCertificationFormsCommand.Execute(null);
            GetCertificationFormsCommand.Execute(null);
            GetCodesOfAcademicDisciplineCommand.Execute(null);
            GetFormsOfEducationCommand.Execute(null);
            GetPlacesOfDisciplineInStructureCommand.Execute(null);

            documentViewModel.OpenDocumentCommand = new OpenDocumentCommand(documentViewModel, outputName);

            ShowWindowCommand = new ShowWindowCommand(documentViewModel.OpenDocumentCommand, documentViewModel, _documentName);
        }
    }
}