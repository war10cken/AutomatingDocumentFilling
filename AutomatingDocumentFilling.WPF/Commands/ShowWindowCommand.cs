using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutomatingDocumentFilling.WPF.Services;
using AutomatingDocumentFilling.WPF.ViewModels;
using AutomatingDocumentFilling.WPF.Views;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace AutomatingDocumentFilling.WPF.Commands
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
                InsertIntoDocument(_documentName, "output.docx");

                _openCommand.Execute(null);
                Window documentWindow = new DocumentView(_documentViewModel);
                documentWindow.Show();
            }
        }

        //public override async Task ExecuteAsync(object parameter)
        //{
        //}

        private void InsertIntoDocument(string part, string newNameOfDocument)
        {
            using (var document = DocX.Load(part))
            {
                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                {
                    string[] skillsHeaders = {"Умение", "Наименование умения"};
                    string[] skillsData =
                    {
                        "Управлять параметрами загрузки операционной системы",
                        "э"
                    };

                    string[] knowledgeHeaders =
                        {"Знание", "Наименование занания"};
                    string[] knowledgeData = {"Основные понятия, функции, состав и принципы работы операционных систем.", "q" };

                    string[] generalCompetenceHeaders = {"Код", "Наименование общих компетенций"};
                    string[] generalCompetenceData = {"Берутся в соответствии с ФГОС по профессии (специальности)", "q"};

                    var skillsTable = CreateTable(document, skillsHeaders, skillsData, 'У');
                    var knowledgeTable = CreateTable(document, knowledgeHeaders, knowledgeData, 'З');
                    var generalCompetenceTable =
                        CreateTable(document, generalCompetenceHeaders, generalCompetenceData, "ОК");
                    
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
                    //document.SaveAs(newNameOfDocument);
                }

                document.SaveAs(newNameOfDocument);
            }
        }

        private Table CreateTable(DocX document, IReadOnlyList<string> headers, string[] data, char symbol)
        {
            var table = document.AddTable(data.GetUpperBound(0) + 2, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            int rows = data.GetUpperBound(0) + 2;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            for (int i = 1; i < rows; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol}.{i}");
                table.Rows[i].Cells[1].Paragraphs[0].Append(data[i - 1]);
            }

            return table;
        }

        private Table CreateTable(DocX document, IReadOnlyList<string> headers, string[] data, string symbol)
        {
            var table = document.AddTable(data.GetUpperBound(0) + 2, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            int rows = data.GetUpperBound(0) + 2;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            for (int i = 1; i < rows; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol} {i}.");
                table.Rows[i].Cells[1].Paragraphs[0].Append(data[i - 1]);
            }

            return table;
        }
    }
}