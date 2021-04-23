using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfApplication1.Commands;

namespace WpfApplication1.ViewModels
{
    public class SkillViewModel : ViewModelBase
    {
        private List<string> _skillNames = new List<string>(){ "123", "345", "645"};

        public List<string> SkillNames
        {
            get
            {
                return _skillNames;
            }
            set
            {
                _skillNames = value;
                OnPropertyChanged(nameof(SkillNames));
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
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
        private readonly string _documentName;

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

        private string _order = "q";

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

        private string _outsideExpertFio = "q";

        public string OutsideExpertFio
        {
            get
            {
                return _outsideExpertFio;
            }
            set
            {
                _outsideExpertFio = value;
                OnPropertyChanged(nameof(OutsideExpertFio));
            }
        }

        private string _contentExpertFio = "q";

        public string ContentExpertFio
        {
            get
            {
                return _contentExpertFio;
            }
            set
            {
                _contentExpertFio = value;
                OnPropertyChanged(nameof(ContentExpertFio));
            }
        }

        private string _techExpertFio = "q";

        public string TechExpertFio
        {
            get
            {
                return _techExpertFio;
            }
            set
            {
                _techExpertFio = value;
                OnPropertyChanged(nameof(TechExpertFio));
            }
        }

        private string _completedBy = "q";

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

        private string _fullNameOfDeputyDirectorAcademicAffairs = "q";

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

        private string _fullNameOfDeputyDirectorAcademicMethodologicalWork = "q";

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

        private string _fullNameOfChairmanOfMethodologicalCyclicCommission = "q";

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

        private List<SkillViewModel> _skills = new List<SkillViewModel>()
        {
            new SkillViewModel(),
            new SkillViewModel(),
            new SkillViewModel(),
            new SkillViewModel()
        };

        public List<SkillViewModel> Skills
        {
            get => _skills;
            set
            {
                _skills = value;
                OnPropertyChanged(nameof(Skills));
            }
        }

        public HomeViewModel(DocumentViewModel documentViewModel, string documentName, string outputName)
        {
            _documentName = documentName;

            GetFormsOfEducationCommand = new GetArrayFromJsonCommand(nameof(FormsOfEducation), this);
            GetSpecialtiesCommand = new GetArrayFromJsonCommand(nameof(Specialties), this);
            GetCodesOfAcademicDisciplineCommand = new GetArrayFromJsonCommand(nameof(CodesOfAcademicDiscipline), this);
            GetPlacesOfDisciplineInStructureCommand =
                new GetArrayFromJsonCommand(nameof(PlacesOfDisciplineInStructure), this);
            
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