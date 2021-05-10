using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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

        // public override async Task ExecuteAsync(object parameter)
        // {
        //     if (_documentName.Length > 0)
        //     {
        //         try
        //         {
        //             [STAThread]
        //             async Task InsertToDoc()
        //             {
        //                 await Task.Run(() =>
        //                 {
        //                     InsertIntoDocument(_documentName, "output.docx");
        //                     _openCommand.Execute(null);
        //                 }).ConfigureAwait(true);
        //             }
        //
        //             await InsertToDoc().ConfigureAwait(true);
        //
        //             InsertIntoDocument(_documentName, "output.docx");
        //             _openCommand.Execute(null);
        //             Window documentWindow = new DocumentView(_documentViewModel);
        //             documentWindow.Show();
        //         }
        //         catch (Exception e)
        //         {
        //             throw new Exception(e.Message);
        //         }
        //     }
        // }

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

                    string[] professionalCompetenceHeaders =
                        {"Код", "Наименование видов деятельности и профессиональных компетенций"};

                    var skillsTable =
                        TableCreator.CreateTable(document, skillsHeaders, _homeViewModel.Skills, 'У');
                    var knowledgeTable =
                        TableCreator.CreateTable(document, knowledgeHeaders,
                                                                     _homeViewModel.Knowledge, 'З');

                    var generalCompetenceTable =
                        TableCreator.CreateTable(document, generalCompetenceHeaders,
                                                                             _homeViewModel.GeneralCompetences, "ОК");
                    var professionalCompetenceTable =
                        TableCreator.CreateTable(document, professionalCompetenceHeaders,
                                                 _homeViewModel.ProfessionalCompetence, "ВД", "ПК");

                    List<Table> centerTables = new();

                    foreach (var theme in _homeViewModel.Themes)
                    {
                        centerTables.Add(TableCreator.CreateCenterOfBigTable(document, theme));
                    }

                    Table headOfBigTable = TableCreator.CreateHeadOfBigTable(document, _homeViewModel.Themes[0]);

                    Table endOfBigTable = TableCreator.CreateEndOfBigTable(document, _homeViewModel.Themes.LastOrDefault(), _homeViewModel);

                    var courseWorksList = ListCreator.AddNewList<CourseWorkViewModel>(document,
                                                                         nameof(_homeViewModel.TopicsOfCourseWork),
                                                                         _homeViewModel);
                    var mainList =
                        ListCreator.AddNewList<MainResourcesViewModel>(document, nameof(_homeViewModel.MainResources),
                                                                   _homeViewModel);
                    var additionalList =
                        ListCreator.AddNewList<AdditionalResourcesViewModel>(document,
                                                                             nameof(_homeViewModel.AdditionalResources),
                                                                             _homeViewModel);
                    var internetList =
                        ListCreator.AddNewList<InternetResourcesViewModel>(document,
                                                                           nameof(_homeViewModel.InternetResources),
                                                                           _homeViewModel);

                    string nameOfChoice = _homeViewModel.IsLaboratory ? "лаборатория"
                                          : _homeViewModel.IsEducationRoom ? "учебный кабинет"
                                          : _homeViewModel.IsWorkshop ? "мастерская" : "";

                    string choice = _homeViewModel.IsEducationRoom ? _homeViewModel.EducationRoomNumber
                             : _homeViewModel.IsLaboratory ? _homeViewModel.LaboratoryRoomNumber
                             : _homeViewModel.WorkshopRoomNumber;

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
                    document.ReplaceText("<thechoice>", $"{nameOfChoice} {choice}", false, RegexOptions.IgnoreCase);

                    foreach (var documentParagraph in document.Paragraphs)
                    {
                        if (documentParagraph.Text.Contains("<mainlist>"))
                        {
                            foreach (var mainListItem in mainList.Items.Where(mainListItem => !string.IsNullOrWhiteSpace(mainListItem.Text)))
                            {
                                documentParagraph.InsertParagraphAfterSelf(mainListItem);
                            }

                            document.RemoveParagraph(documentParagraph);
                        }
                    }

                    foreach (var documentParagraph in document.Paragraphs)
                    {
                        if (documentParagraph.Text.Contains("<additionallist>"))
                        {
                            foreach (var additionalListItem in additionalList.Items.Where(mainListItem => !string.IsNullOrWhiteSpace(mainListItem.Text)))
                            {
                                documentParagraph.InsertParagraphAfterSelf(additionalListItem);
                            }

                            document.RemoveParagraph(documentParagraph);
                        }
                    }

                    foreach (var documentParagraph in document.Paragraphs)
                    {
                        if (documentParagraph.Text.Contains("<internetlist>"))
                        {
                            foreach (var internetListItem in internetList.Items.Where(mainListItem => !string.IsNullOrWhiteSpace(mainListItem.Text)))
                            {
                                documentParagraph.InsertParagraphAfterSelf(internetListItem);
                            }

                            document.RemoveParagraph(documentParagraph);
                        }
                    }

                    foreach (var paragraph in endOfBigTable.Paragraphs)
                    {
                        if (paragraph.Text.Contains("<courseworks>"))
                        {
                            foreach (var item in courseWorksList.Items.Where(mainListItem => !string.IsNullOrWhiteSpace(mainListItem.Text)))
                            {
                                paragraph.InsertParagraphAfterSelf(item);
                            }

                            paragraph.Remove(false);
                        }
                    }

                    document.ReplaceTextWithObject("<skillstable>", skillsTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<knowledgetable>", knowledgeTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<generalcompetencetable>", generalCompetenceTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<professionalcompetencetable>", professionalCompetenceTable, false, RegexOptions.IgnoreCase);
                    document.ReplaceTextWithObject("<bigtable>", headOfBigTable, false, RegexOptions.IgnoreCase);
                    headOfBigTable.InsertTableAfterSelf(endOfBigTable);

                    centerTables.RemoveAt(0);
                    centerTables.RemoveAt(centerTables.Count - 1);
                    foreach (var table in centerTables)
                    {
                        headOfBigTable.InsertTableAfterSelf(table);
                    }

                    //document.SaveAs(newNameOfDocument);
                }

                document.SaveAs(newNameOfDocument);
                document.Dispose();
            }
        }
    }
}