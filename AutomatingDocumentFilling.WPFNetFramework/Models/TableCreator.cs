using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Models
{
    public static class TableCreator
    {
        private const string _textPropertyName = "SelectedText";
        private static float _totalHours;

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
                                                    char symbol, string[] dataForSecondRow) where TViewModel : ViewModelBase
        {
            var table = document.AddTable(data.Count + 2, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[2].Paragraphs[0].Append(headers[2]).Bold().Alignment = Alignment.center;

            for (int i = 1; i < dataForSecondRow.Length + 1; i++)
            {
                table.Rows[1].Cells[i].Paragraphs[0].Append(dataForSecondRow[i - 1]);
            }

            List<string> text = data.Select(item => item.GetType().GetProperty(_textPropertyName)?.GetValue(item)
                                                        .ToString()).ToList();
            List<string> appraisals = data.Select(item => item.GetType().GetProperty("Appraisal")?.GetValue(item)
                                                              .ToString()).ToList();
            List<string> assessmentForms = data.Select(item => item
                                                              .GetType().GetProperty("AssessmentForm")?.GetValue(item)
                                                              .ToString()).ToList();

            for (int i = 2; i < data.Count + 2; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol}.{i - 1} {text[i - 2]}");
                table.Rows[i].Cells[1].Paragraphs[0].Append(appraisals[i - 2]);
                table.Rows[i].Cells[2].Paragraphs[0].Append(assessmentForms[i - 2]);
            }

            return table;
        }

        public static Table CreateLastTable<TViewModel>(DocX document, IReadOnlyList<string> headers,
                                                        List<TViewModel> data,
                                                        char symbol) where TViewModel : ViewModelBase
        {
            var table = document.AddTable(data.Count, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            List<string> text = data.Select(item => item.GetType().GetProperty(_textPropertyName)?.GetValue(item)
                                                        .ToString()).ToList();
            List<string> appraisals = data.Select(item => item.GetType().GetProperty("Appraisal")?.GetValue(item)
                                                              .ToString()).ToList();
            List<string> assessmentForms = data.Select(item => item
                                                              .GetType().GetProperty("AssessmentForm")?.GetValue(item)
                                                              .ToString()).ToList();

            for (int i = 0; i < data.Count; i++)
            {
                table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbol}.{i + 1} {text[i]}");
                table.Rows[i].Cells[1].Paragraphs[0].Append(appraisals[i]);
                table.Rows[i].Cells[2].Paragraphs[0].Append(assessmentForms[i]);
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

        public static Table CreateTable<TViewModel>(DocX document, IReadOnlyList<string> headers, List<TViewModel> data,
                                                    string symbolOne, string symbolTwo) where TViewModel : ViewModelBase
        {
            var table = document.AddTable(data.Count * 2 + 1, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            List<string> text = data.Select(item => item.GetType().GetProperty(_textPropertyName)?.GetValue(item)
                                                        .ToString()).ToList();

            for (int i = 1, j = 0, u = 1; i < data.Count + 1; i++, j++, u++)
            {
                if (i == 1)
                {
                    table.Rows[i].Cells[0].Paragraphs[0].Append($"{symbolOne} {i}");
                    table.Rows[i + 1].Cells[0].Paragraphs[0].Append($"{symbolTwo} {i}.1");
                    table.Rows[i].Cells[1].Paragraphs[0].Append(text[i - 1]);
                    continue;
                }

                table.Rows[i + j].Cells[0].Paragraphs[0].Append($"{symbolOne} {i}");
                table.Rows[i + u].Cells[0].Paragraphs[0].Append($"{symbolTwo} {i}.1");
                table.Rows[i + j].Cells[1].Paragraphs[0].Append(text[i - 1]);
            }

            return table;
        }

        public static Table CreateHeadOfBigTable(DocX document, ThemeViewModel theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count;
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

            table.Rows[2].Cells[0].Paragraphs[0].Append(theme.Name.Trim());
            table.Rows[2].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[2].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();
            table.Rows[theme.EducationMaterials.Count + 3].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[1].MergeCells(1, 2);
            table.Rows[1].Cells[0].Paragraphs[0].Append("1");
            table.Rows[1].Cells[2].Paragraphs[0].Append("3");
            table.Rows[1].Cells[3].Paragraphs[0].Append("4");
            table.Rows[1].Cells[1].Paragraphs[0].Append("2");

            int practicalCount = theme.PracticalTrainingTopics.Count;
            int educationCount = theme.EducationMaterials.Count;
            int totalCount = educationCount + practicalCount;

            table.MergeCellsInColumn(0, 2, totalCount + 4);
            table.MergeCellsInColumn(3, 2, educationCount + 2);
            table.MergeCellsInColumn(4, 2, totalCount + 4);

            for (int i = 0; i < practicalCount + 1; i++)
            {
                table.Rows[i + educationCount + 3].MergeCells(1, 2);
            }

            float totalEducationMaterialsHours = Convert.ToSingle(theme.EducationHours);

            //theme.EducationMaterials.ForEach(e => totalEducationMaterialsHours =
            //                                          totalEducationMaterialsHours + (float) theme.);

            table.Rows[2].Cells[4].Paragraphs[0].Append(theme.Codes);

            //foreach (string text in theme.Codes.Skip(1))
            //{
            //    table.Rows[2].Cells[4].InsertParagraph(text);
            //}

            for (int i = 0; i < theme.EducationMaterials.Count; i++)
            {
                table.Rows[i + 3].Cells[1].Paragraphs[0].Append(theme.EducationMaterials[i].Name.Trim());
                table.Rows[i + 3].Cells[2].Paragraphs[0].Append(theme.EducationMaterials[i].EducationLevel.Trim());
            }

            table.Rows[2].Cells[3].Paragraphs[0].Append(totalEducationMaterialsHours.ToString());

            for (int i = 0; i < theme.PracticalTrainingTopics.Count; i++)
            {
                table.Rows[educationCount + 4 + i].Cells[1].Paragraphs[0]
                     .Append(theme.PracticalTrainingTopics[i].Name.Trim());
                table.Rows[educationCount + 4 + i].Cells[2].Paragraphs[0]
                     .Append(theme.PracticalTrainingTopics[i].Hours.Trim());

                _totalHours = _totalHours + Convert.ToSingle(theme.PracticalTrainingTopics[i].Hours.Trim());
            }

            table.Rows[table.RowCount - 1].MergeCells(1, 2);
            table.Rows[table.RowCount - 1].Cells[1].Paragraphs[0].Append("Самостоятельная работа обучающися").Bold()
                 .Italic();

            _totalHours = _totalHours + Convert.ToSingle(theme.EducationHours.Trim());

            return table;
        }

        public static Table CreateCenterOfBigTable(DocX document, ThemeViewModel theme)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count;
            const int columns = 5;

            int practicalCount = theme.PracticalTrainingTopics.Count;
            int educationCount = theme.EducationMaterials.Count;

            var table = document.AddTable(totalLength + 3, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLength + 2);

            for (int i = 0; i < theme.PracticalTrainingTopics.Count + 2; i++)
            {
                table.Rows[theme.EducationMaterials.Count + i + 1].MergeCells(1, 2);
            }

            float totalEducationMaterialsHours = Convert.ToSingle(theme.EducationHours);
            //theme.EducationMaterials.ForEach(e => totalEducationMaterialsHours =
            //                                          totalEducationMaterialsHours + e.Hours);

            table.Rows[0].Cells[4].Paragraphs[0].Append(theme.Codes);

            //foreach (string text in theme.Codes.Skip(1))
            //{
            //    table.Rows[0].Cells[4].InsertParagraph(text);
            //}

            for (int i = 0; i < educationCount; i++)
            {
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(theme.EducationMaterials[i].Name.Trim());
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(theme.EducationMaterials[i].EducationLevel.Trim());
            }

            table.Rows[0].Cells[3].Paragraphs[0].Append(totalEducationMaterialsHours.ToString(CultureInfo.InvariantCulture));

            for (int i = 0; i < practicalCount; i++)
            {
                table.Rows[practicalCount + 2 + i].Cells[1].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopics[i].Name.Trim());
                table.Rows[practicalCount + 2 + i].Cells[2].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopics[i].Hours.Trim());

                _totalHours = _totalHours + Convert.ToSingle(theme.PracticalTrainingTopics[i].Hours.Trim());
            }

            table.Rows[0].Cells[0].Paragraphs[0].Append(theme.Name).Bold().Italic();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();

            table.Rows[theme.EducationMaterials.Count + 1].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[totalLength + 2].Cells[1].Paragraphs[0]
                 .Append("Самостоятельная работа обучающися").Bold().Italic();

            _totalHours = _totalHours + Convert.ToSingle(theme.EducationHours.Trim());

            return table;
        }

        public static Table CreateEndOfBigTable(DocX document, ThemeViewModel theme, HomeViewModel homeViewModel)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count;
            const int columns = 5;

            var table = document.AddTable(totalLength + 6, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLength + 2);

            for (int i = 0; i < theme.PracticalTrainingTopics.Count + 2; i++)
            {
                table.Rows[theme.EducationMaterials.Count + i + 1].MergeCells(1, 2);
            }

            int practicalCount = theme.PracticalTrainingTopics.Count;
            int educationCount = theme.EducationMaterials.Count;

            table.Rows[0].Cells[4].Paragraphs[0].Append(theme.Codes);

            table.Rows[0].Cells[0].Paragraphs[0].Append(theme.Name.Trim()).Bold().Italic();
            table.Rows[0].Cells[1].Paragraphs[0].Append("Содержание учебного плана").Bold().Italic();
            table.Rows[0].Cells[2].Paragraphs[0].Append("Уровень освоения").Bold().Italic();

            table.Rows[table.RowCount - 1].MergeCells(0, 2);
            table.Rows[table.RowCount - 1].Cells[0].Paragraphs[0].Append("Всего:").Bold().Italic();

            table.Rows[theme.EducationMaterials.Count + 1].Cells[1].Paragraphs[0]
                 .Append("Тематика практических занятий и лабароторных работ").Bold().Italic();

            table.Rows[totalLength + 2].Cells[1].Paragraphs[0]
                 .Append("Самостоятельная работа обучающися").Bold().Italic();

            float totalEducationMaterialsHours = Convert.ToSingle(theme.EducationHours);

            for (int i = 0; i < educationCount; i++)
            {
                table.Rows[i + 1].Cells[1].Paragraphs[0].Append(theme.EducationMaterials[i].Name.Trim());
                table.Rows[i + 1].Cells[2].Paragraphs[0].Append(theme.EducationMaterials[i].EducationLevel.Trim());
            }

            table.Rows[0].Cells[3].Paragraphs[0].Append(totalEducationMaterialsHours.ToString(CultureInfo.InvariantCulture));

            for (int i = 0; i < practicalCount; i++)
            {
                table.Rows[practicalCount + 2 + i].Cells[1].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopics[i].Name.Trim());
                table.Rows[practicalCount + 2 + i].Cells[2].Paragraphs[0]
                    .Append(theme.PracticalTrainingTopics[i].Hours.Trim());

                _totalHours = _totalHours + Convert.ToSingle(theme.PracticalTrainingTopics[i].Hours.Trim());
            }

            _totalHours = _totalHours + Convert.ToSingle(theme.EducationHours.Trim());

            table.Rows[table.RowCount - 3].MergeCells(0, 2);
            table.Rows[table.RowCount - 2].MergeCells(0, 2);

            table.Rows[table.RowCount - 3].Cells[0].Paragraphs[0].Append("<courseworks>");
            table.Rows[table.RowCount - 3].Cells[1].Paragraphs[0].Append(homeViewModel.CourseWorkHours);

            table.Rows[table.RowCount - 2].Cells[0].Paragraphs[0].Append(homeViewModel.CertificationForm);

            if (homeViewModel.IsHasConsultation)
            {
                table.Rows[table.RowCount - 2].Cells[0].Paragraphs[0].InsertParagraphAfterSelf("Консультации");
                table.Rows[table.RowCount - 2].Cells[1].Paragraphs[0].Append(homeViewModel.ConsultationHours);
                _totalHours = _totalHours + Convert.ToSingle(homeViewModel.ConsultationHours);
            }

            table.Rows[table.RowCount - 1].Cells[1].Paragraphs[0].Append(_totalHours.ToString()).Bold().Italic();

            return table;
        }
    }
}