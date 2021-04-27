using System;
using System.Collections.Generic;
using System.Linq;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public static class TableCreator
    {
        private const string _textPropertyName = "SelectedText";
        
        public static Table CreateTable<TViewModel>(DocX document, IReadOnlyList<string> headers, List<TViewModel> data,
                                         char symbol) where TViewModel : ViewModelBase
        {
            var table = document.AddTable(data.Count + 1, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            List<string> text = data.Select(item => item.GetType().GetProperty(_textPropertyName)?.GetValue(item)
                                                        .ToString()).ToList();

            for (int i = 1; i < data.Count + 1; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol}.{i}");
                table.Rows[i].Cells[1].Paragraphs[0].Append(text[i - 1]);
            }

            return table;
        }
        
        public static Table CreateTable<TViewModel>(DocX document, IReadOnlyList<string> headers, List<TViewModel> data,
                                        string symbol) where TViewModel : ViewModelBase
        {
            var table = document.AddTable(data.Count + 1, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            List<string> text = data.Select(item => item.GetType().GetProperty(_textPropertyName)?.GetValue(item)
                                                        .ToString()).ToList();
            
            for (int i = 1; i < data.Count + 1; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol}.{i}");
                table.Rows[i].Cells[1].Paragraphs[0].Append(text[i - 1]);
            }

            return table;
        }

        public static Table CreateHeadOfBigTable(DocX document, Theme theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopicsList.Count;
            const int columns = 5;

            var table = document.AddTable(totalLength + 5, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append("Наименование разделов и тем").Bold().Italic();
            table.Rows[0].Cells[1].Paragraphs[0]
                 .Append("Содержание учебного материала и формы организации деятельности обучающихся").Bold()
                 .Italic();
            table.Rows[0].Cells[3].Paragraphs[0].Append("Объем часов").Bold().Italic();
            table.Rows[0].Cells[4].Width = 143;
            table.Rows[0].Cells[4].Paragraphs[0]
                 .Append("Коды компетенций, формированию которых способствует элемент программы, знания, умения")
                 .Bold().Italic();

            table.Rows[2].Cells[0].Paragraphs[0].Append(theme.Name);
            table.Rows[2].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[2].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();
            table.Rows[theme.EducationMaterials.Count + 3].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[1].MergeCells(1, 2);
            table.Rows[1].Cells[0].Paragraphs[0].Append("1");
            table.Rows[1].Cells[2].Paragraphs[0].Append("3");
            table.Rows[1].Cells[3].Paragraphs[0].Append("4");
            table.Rows[1].Cells[1].Paragraphs[0].Append("2");

            int practicalCount = theme.PracticalTrainingTopicsList.Count;
            int educationCount = theme.EducationMaterials.Count;
            int totalCount = educationCount + practicalCount;

            table.MergeCellsInColumn(0, 2, totalCount + 4);
            table.MergeCellsInColumn(3, 2, educationCount + 2);
            table.MergeCellsInColumn(4, 2, totalCount + 4);

            for (int i = 0; i < practicalCount + 1; i++)
            {
                table.Rows[i + educationCount + 3].MergeCells(1, 2);
            }

            float totalEducationMaterialsHours = 0;
            theme.EducationMaterials.ForEach(e => totalEducationMaterialsHours =
                                                      totalEducationMaterialsHours + e.Hours);

            for (int i = 0; i < theme.EducationMaterials.Count; i++)
            {
                table.Rows[i + 3].Cells[1].Paragraphs[0].Append(theme.EducationMaterials[i].Name);
                table.Rows[i + 3].Cells[2].Paragraphs[0].Append(theme.EducationMaterials[i].EducationLevel);
            }

            table.Rows[2].Cells[3].Paragraphs[0].Append(totalEducationMaterialsHours.ToString());

            for (int i = 0; i < theme.PracticalTrainingTopicsList.Count; i++)
            {
                table.Rows[educationCount + 4 + i].Cells[1].Paragraphs[0]
                     .Append(theme.PracticalTrainingTopicsList[i].Name);
                table.Rows[educationCount + 4 + i].Cells[2].Paragraphs[0]
                     .Append(theme.PracticalTrainingTopicsList[i].Hours.ToString());
            }

            table.Rows[table.RowCount - 1].MergeCells(1, 2);
            table.Rows[table.RowCount - 1].Cells[1].Paragraphs[0].Append("Самостоятельная работа обучающися").Bold()
                 .Italic();

            return table;
        }
        
        public static Table CreateCenterOfBigTable(DocX document, Theme theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopicsList.Count;
            const int columns = 5;

            int practicalCount = theme.PracticalTrainingTopicsList.Count;
            int educationCount = theme.EducationMaterials.Count;

            var table = document.AddTable(totalLength + 3, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLength + 2);

            for (int i = 0; i < theme.PracticalTrainingTopicsList.Count + 2; i++)
            {
                table.Rows[theme.EducationMaterials.Count + i + 1].MergeCells(1, 2);
            }

            float totalEducationMaterialsHours = 0;
            theme.EducationMaterials.ForEach(e => totalEducationMaterialsHours =
                                                      totalEducationMaterialsHours + e.Hours);

            for (int i = 0; i < theme.EducationMaterials.Count; i++)
            {
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(theme.EducationMaterials[i].Name);
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(theme.EducationMaterials[i].EducationLevel);
            }

            table.Rows[0].Cells[3].Paragraphs[0].Append(totalEducationMaterialsHours.ToString());

            for (int i = 0; i < theme.PracticalTrainingTopicsList.Count; i++)
            {
                table.Rows[practicalCount + 2 + i].Cells[1].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopicsList[i].Name);
                table.Rows[practicalCount + 2 + i].Cells[2].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopicsList[i].Hours.ToString());
            }

            table.Rows[0].Cells[0].Paragraphs[0].Append(theme.Name).Bold().Italic();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();

            table.Rows[theme.EducationMaterials.Count + 1].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[totalLength + 2].Cells[1].Paragraphs[0]
                 .Append("Самостоятельная работа обучающися").Bold().Italic();

            return table;
        }

        public static Table CreateEndOfBigTable(DocX document, Theme theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopicsList.Count;
            const int columns = 5;

            var table = document.AddTable(totalLength + 6, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLength + 2);

            for (int i = 0; i < theme.PracticalTrainingTopicsList.Count + 2; i++)
            {
                table.Rows[theme.EducationMaterials.Count + i + 1].MergeCells(1, 2);
            }

            table.Rows[0].Cells[0].Paragraphs[0].Append(theme.Name).Bold().Italic();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();

            table.Rows[table.RowCount - 1].MergeCells(0, 2);
            table.Rows[table.RowCount - 1].Cells[0].Paragraphs[0].Append("Всего:").Bold().Italic();

            table.Rows[theme.EducationMaterials.Count + 1].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[totalLength + 2].Cells[1].Paragraphs[0]
                 .Append("Самостоятельная работа обучающися").Bold().Italic();

            table.Rows[table.RowCount - 3].MergeCells(0, 2);
            table.Rows[table.RowCount - 2].MergeCells(0, 2);

            return table;
        }
    }
}