using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPFNetFramework.Models;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using AutomatingDocumentFilling.WPFNetFramework.Views;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class ShowWindowCommand : ICommand
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly string _documentName;
        private readonly ICommand _openCommand;
        private readonly DocumentViewModel _documentViewModel;

        public ShowWindowCommand(ICommand openCommand,
                                 HomeViewModel homeViewModel,
                                 DocumentViewModel documentViewModel,
                                 string documentName)
        {
            _openCommand = openCommand;
            _homeViewModel = homeViewModel;
            _documentViewModel = documentViewModel;
            _documentName = documentName;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_documentName.Length > 0)
            {
                try
                {
                    InsertIntoDocument(_documentName, "output.docx");
                    _openCommand.Execute(null);
                    Window documentWindow = new DocumentView(_documentViewModel);
                    documentWindow.Show();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        private void InsertIntoDocument(string part, string newNameOfDocument)
        {
            using (var document = DocX.Load(part))
            {
                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                {
                    string[] skillsHeaders = { "Умение", "Наименование умения" };

                    string[] knowledgeHeaders =
                        {"Знание", "Наименование занания"};

                    string[] generalCompetenceHeaders = { "Код", "Наименование общих компетенций" };

                    var skillsTable =
                        TableCreator.CreateTable(document, skillsHeaders, _homeViewModel.Skills, 'У');
                    var knowledgeTable =
                        TableCreator.CreateTable(document, knowledgeHeaders,
                                                                     _homeViewModel.Knowledge, 'З');

                    _homeViewModel.GeneralCompetences = new List<GeneralCompetenceViewModel>()
                    {
                        new GeneralCompetenceViewModel()
                        {
                            SelectedText = "123"
                        }
                    };

                    var generalCompetenceTable =
                        TableCreator.CreateTable(document, generalCompetenceHeaders,
                                                                             _homeViewModel.GeneralCompetences, "ОК");

                    List<string> codes = new List<string> { "qwe", "asd", "zxc" };

                    List<EducationMaterial> educationMaterials = new List<EducationMaterial>()
                    {
                        new EducationMaterial()
                        {
                            Name = "qwe",
                            EducationLevel = "1",
                            Hours = 44.3f
                        },
                        new EducationMaterial()
                        {
                            Name = "asd",
                            EducationLevel = "3",
                            Hours = 24.3f
                        },
                        new EducationMaterial()
                        {
                            Name = "gtr",
                            EducationLevel = "2",
                            Hours = 41.3f
                        }
                    };

                    List<PracticalTrainingTopics> practicalTrainingTopicsList = new List<PracticalTrainingTopics>
                    {
                        new PracticalTrainingTopics
                        {
                            Hours = 234.1f,
                            Name = "qwe"
                        },
                        new PracticalTrainingTopics
                        {
                            Hours = 24.1f,
                            Name = "gh"
                        },
                        new PracticalTrainingTopics
                        {
                            Hours = 34.1f,
                            Name = "tywe"
                        }
                    };

                    Theme theme = new Theme
                    {
                        EducationMaterials = educationMaterials,
                        Name = "Theme 1. qwe",
                        PracticalTrainingTopicsList = practicalTrainingTopicsList,
                        Codes = codes
                    };

                    Table endOfBigTable = TableCreator.CreateEndOfBigTable(document, theme);
                    Table centerOfBigTable = TableCreator.CreateCenterOfBigTable(document, theme);
                    Table bigTable = TableCreator.CreateHeadOfBigTable(document, theme);

                    document.ReplaceText("<code>", _homeViewModel.CodeOfAcademicDiscipline, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<specialty>", _homeViewModel.Specialty, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<formofeducation>", _homeViewModel.FormOfEducation, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameDDAA>", _homeViewModel.FullNameOfDeputyDirectorAcademicAffairs, false,
                                         RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameDDAMW>", _homeViewModel.FullNameOfDeputyDirectorAcademicMethodologicalWork,
                                         false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<fullnameCMCC>", _homeViewModel.FullNameOfChairmanOfMethodologicalCyclicCommission,
                                         false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<completedby>", _homeViewModel.CompletedBy, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<techfio>", _homeViewModel.TechExpertFio, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<contentfio>", _homeViewModel.ContentExpertFio, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<outsidefio>", _homeViewModel.OutsideExpertFio, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<order>", _homeViewModel.Order, false, RegexOptions.IgnoreCase);
                    document.ReplaceText("<placeofdisciplineinstructure>", _homeViewModel.PlaceOfDisciplineInStructure, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<skillstable>", skillsTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<knowledgetable>", knowledgeTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<generalcompetencetable>", generalCompetenceTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<bigtable>", bigTable, false, RegexOptions.IgnoreCase);
                    bigTable.InsertTableAfterSelf(endOfBigTable);
                    bigTable.InsertTableAfterSelf(centerOfBigTable);

                    //document.SaveAs(newNameOfDocument);
                }

                document.SaveAs(newNameOfDocument);
                document.Dispose();
            }
        }
    }
}