using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using WpfApplication1.Models;
using WpfApplication1.ViewModels;
using WpfApplication1.Views;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WpfApplication1.Commands
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

                    List<string> codes = new List<string> {"qwe", "asd", "zxc"};
            
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
                    
                    Table bigTable = CreateHeadOfBigTable(document, theme);
                    
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
                    bigTable.InsertTableAfterSelf(2, 2);
                    bigTable.InsertTableAfterSelf(3, 3);

                    //document.SaveAs(newNameOfDocument);
                }

                document.SaveAs(newNameOfDocument);
                document.Dispose();
            }
        }


    #region CutThis

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

        private Table CreateHeadOfBigTable(DocX document, Theme theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopicsList.Count;
            const int columns = 5;

            var table = document.AddTable(totalLength + 5, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append("Наименование разделов и тем");
            table.Rows[0].Cells[1].Paragraphs[0]
                 .Append("Содержание учебного материала и формы организации деятельности обучающихся");
            table.Rows[0].Cells[3].Paragraphs[0].Append("Объем часов");
            table.Rows[0].Cells[4].Width = 143; 
            table.Rows[0].Cells[4].Paragraphs[0]
                 .Append("Коды компетенций, формированию которых способствует элемент программы, знания, умения");
            
            table.Rows[1].MergeCells(1, 2);
            table.Rows[1].Cells[0].Paragraphs[0].Append("1");
            table.Rows[1].Cells[2].Paragraphs[0].Append("3");
            table.Rows[1].Cells[3].Paragraphs[0].Append("4");
            table.Rows[1].Cells[1].Paragraphs[0].Append("2");

            int practicalCount = theme.PracticalTrainingTopicsList.Count;
            int educationCount = theme.EducationMaterials.Count;
            int totalCount = educationCount + practicalCount;
            
            table.MergeCellsInColumn(0, 2, totalCount + 3);
            table.MergeCellsInColumn(3, 2, educationCount + 2);
            table.MergeCellsInColumn(4, 2, totalCount + 3);

            for (int i = 0; i < practicalCount + 1; i++)
            {
                table.Rows[i + educationCount + 3].MergeCells(1, 2);
            }

            // table.Rows[0].MergeCells(1, 2);
            // table.MergeCellsInColumn(0, 1, table.RowCount - 4);
            // table.MergeCellsInColumn(3, 1, curriculumContent.Length + 1);
            // table.MergeCellsInColumn(4, 1, table.RowCount - 4);
            // table.Rows[4].MergeCells(1, 2);
            
            // table.Rows[1].Cells[0].Paragraphs[0].Append("Тема Парампампам.");
            // table.Rows[0].Cells[1].Paragraphs[0].Append("Самостоятельная работа обучающихся");
            // table.Rows[1].Cells[1].Paragraphs[0].Append("Содержание учебного плана");
            // table.Rows[1].Cells[2].Paragraphs[0].Append("Уровень освоения");

            // for (int i = 0; i < curriculumContent.Length; i++)
            // {
            //     table.Rows[i + 2].Cells[1].Paragraphs[0].Append(curriculumContent[i]);
            // }
            //
            // for (int i = 0; i < topicsOfPracticalTraining.Length + 1; i++)
            // {
            //     table.Rows[i + 5].MergeCells(1, 2);
            // }
            //
            // for (int i = 0; i < topicsOfPracticalTraining.Length; i++)
            // {
            //     table.Rows[i + curriculumContent.Length + 3].Cells[1].Paragraphs[0]
            //          .Append(topicsOfPracticalTraining[i]);
            // }
            //
            // table.Rows[curriculumContent.Length + 2].Cells[1].Paragraphs[0]
            //      .Append("Тематика практических занятий и лабароторных работ");
            //
            // table.Rows[table.RowCount - 4].Cells[1].Paragraphs[0]
            //      .Append("Самостоятельная работа обучающися");
            //
            // table.Rows[table.RowCount - 3].MergeCells(0, 2);
            // table.Rows[table.RowCount - 2].MergeCells(0, 2);
            // table.Rows[table.RowCount - 1].MergeCells(0, 2);
            
            return table;
        }

    #endregion
        
    }
}