using AutomatingDocumentFilling.WPF.Commands;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AutomatingDocumentFilling.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly string _firsPart;
        private readonly string _secondPart;
        private readonly string _thirdPart;
        private readonly string _fourthPart;

    #region Properties

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

        //public ICommand GetArrayFromJsomCommand { get; }

        public HomeViewModel(DocumentViewModel documentViewModel, string firsPart, string secondPart, string thirdPart, string fourthPart)
        {
            _firsPart = firsPart;
            _secondPart = secondPart;
            _thirdPart = thirdPart;
            _fourthPart = fourthPart;

            GetFormsOfEducationCommand = new GetFormsOfEducationCommand(this);
            GetSpecialtiesCommand = new GetSpecialtiesCommand(this);
            GetCodesOfAcademicDisciplineCommand = new GetCodesOfAcademicDisciplineCommand(this);

            GetCodesOfAcademicDisciplineCommand.Execute(null);
            GetSpecialtiesCommand.Execute(null);
            GetFormsOfEducationCommand.Execute(null);

            documentViewModel.OpenDocumentCommand = new OpenDocumentCommand(documentViewModel, _firsPart,
                                                                            _secondPart, _thirdPart, _fourthPart);
            
            ShowWindowCommand = new ShowWindowCommand(documentViewModel.OpenDocumentCommand,
                                                      this, documentViewModel,
                                                      _firsPart, _secondPart,
                                                      _thirdPart, _fourthPart);
        }
    }
}