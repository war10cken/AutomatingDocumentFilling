using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.ViewModels;
using AutomatingDocumentFilling.WPF.Views;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPF.Commands
{
    public class ShowWindowCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly string _firstPart;
        private readonly string _secondPart;
        private readonly string _thirdPart;
        private readonly string _fourthPart;
        private readonly ICommand _openCommand;
        private readonly DocumentViewModel _documentViewModel;

        public ShowWindowCommand(ICommand openCommand,
                                 HomeViewModel homeViewModel,
                                 DocumentViewModel documentViewModel,
                                 string firstPart,
                                 string secondPart,
                                 string thirdPart,
                                 string fourthPart)
        {
            _firstPart = firstPart;
            _openCommand = openCommand;
            _homeViewModel = homeViewModel;
            _documentViewModel = documentViewModel;
            _secondPart = secondPart;
            _thirdPart = thirdPart;
            _fourthPart = fourthPart;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (_firstPart.Length > 0)
            {
                InsertIntoDocument(_firstPart, "doc-c1c.docx");
                InsertIntoDocument(_secondPart, "doc-c2c.docx");
                InsertIntoDocument(_thirdPart, "doc-c3c.docx");
                InsertIntoDocument(_fourthPart, "doc-c4c.docx");

                _openCommand.Execute(null);
                Window documentWindow = new DocumentView(_documentViewModel);
                documentWindow.Show();
            }
        }

        private void InsertIntoDocument(string part, string newNameOfDocument)
        {
            using (var document = DocX.Load(part))
            {
                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                {
                    document.ReplaceText("<code>", _homeViewModel.CodeOfAcademicDiscipline, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<specialty>", _homeViewModel.Specialty, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<formofeducation>", _homeViewModel.FormOfEducation, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameDDAA>", _homeViewModel.FullNameOfDeputyDirectorAcademicAffairs, false,
                                         RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameDDAMW>", _homeViewModel.FullNameOfDeputyDirectorAcademicMethodologicalWork,
                                         false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameCMCC>", _homeViewModel.FullNameOfChairmanOfMethodologicalCyclicCommission,
                                         false, RegexOptions.IgnoreCase);
                    document.SaveAs(newNameOfDocument);
                }
            }
        }

        public event EventHandler? CanExecuteChanged;
    }
}