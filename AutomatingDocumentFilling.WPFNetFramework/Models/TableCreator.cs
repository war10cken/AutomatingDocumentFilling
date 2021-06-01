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
                                                        char symbol)
            where TViewModel : ViewModelBase
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
                                                    string[] symbols, string[] hours, string[] lastEducationalWork,
                                                    string[] lastEducationalWorkHours)
            where TViewModel : ViewModelBase
        {
            string[] lastEducationalWorkWithoutNull = lastEducationalWork.Where(e => e != null).ToArray();
            string[] lastEducationalWorkHoursWithoutNull = lastEducationalWorkHours.Where(h => h != null).ToArray();
            string[] symbolsWithoutNull = symbols.Where(s => s != null).ToArray();
            string[] neededSymbols = symbolsWithoutNull.Take(symbolsWithoutNull.Length - 1).ToArray();
            string[] hoursWithoutNull = hours.Where(h => h != null).ToArray();

            int lewCount = lastEducationalWorkWithoutNull.Length;
            int s = lastEducationalWorkWithoutNull.Length == 2 ? lewCount : lewCount + 1;
            int lastEducationalWorkWithoutNullCount = lastEducationalWorkWithoutNull.Length + s;
            int neededSymbolsLength = lastEducationalWorkWithoutNull != null ?
                neededSymbols.Length + lastEducationalWorkWithoutNullCount
              : neededSymbols.Length + 2;

            var table = document.AddTable(data.Count + neededSymbolsLength + 1, headers.Count);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].Cells[0].Paragraphs[0].Append(headers[0]).Bold().Alignment = Alignment.center;
            table.Rows[0].Cells[1].Paragraphs[0].Append(headers[1]).Bold().Alignment = Alignment.center;

            List<string> independentWorkHours = data.Select(item => item.GetType().GetProperty("Hours")?.GetValue(item)
                                                                        .ToString()).ToList();
            List<string> independentWorkNames = data.Select(item => item.GetType().GetProperty("WorkName")?.GetValue(item)
                                                                        .ToString()).ToList();

            float totalIndependentWorkHours = independentWorkHours.Select(Convert.ToSingle).Sum();

            bool isInserted = false;
            int independentWorkNamesCount = independentWorkNames.Count;

            for (int i = 1, j = 0; i < data.Count + neededSymbolsLength + 1 && j < independentWorkNamesCount; i++)
            {
                if (i == 4)
                {
                    table.Rows[i].MergeCells(0, 1);
                    table.Rows[i].Cells[0].Paragraphs[0].Append("в том числе:");
                    table.Rows[i + 1].Cells[0].Paragraphs[0].Append(neededSymbols[i - 1]);
                    table.Rows[i + 1].Cells[1].Paragraphs[0].Append(hoursWithoutNull[i - 1]);
                    continue;
                }

                if (i <= neededSymbols.Length && i >= 5)
                {
                    InsertIntoCell(table, i + 1, i - 1, neededSymbols, hoursWithoutNull);
                }

                if (i <= neededSymbols.Length && i < 5)
                {
                    InsertIntoCell(table, i, i - 1, neededSymbols, hoursWithoutNull);
                }

                if (i >= neededSymbols.Length + 1)
                {
                    if (independentWorkNamesCount > 0)
                    {
                        if (!isInserted)
                        {
                            table.Rows[i + 1].Cells[0].Paragraphs[0].Append($"{symbolsWithoutNull.LastOrDefault()}");
                            table.Rows[i + 1].Cells[1].Paragraphs[0].Append($"{totalIndependentWorkHours}");
                            table.Rows[i + 2].Cells[0].Paragraphs[0].Append("в том числе:");
                            isInserted = true;
                        }
                        else
                        {
                            table.Rows[i + 2].Cells[0].Paragraphs[0].Append(independentWorkNames[j].Trim());
                            table.Rows[i + 2].Cells[1].Paragraphs[0].Append(independentWorkHours[j].Trim());

                            j++;
                        }
                    }
                }
            }

            for (int i = 0; i < lastEducationalWorkWithoutNull.Length; i++)
            {
                table.Rows[table.RowCount - 1].Cells[0].Paragraphs[i].Append(lastEducationalWorkWithoutNull[i]);
                table.Rows[table.RowCount - 1].Cells[1].Paragraphs[i].Append(lastEducationalWorkHoursWithoutNull[i]);

                if (i + 1 == lastEducationalWorkWithoutNull.Length)
                {
                    break;
                }

                table.Rows[table.RowCount - 1].Cells[0].InsertParagraph();
                table.Rows[table.RowCount - 1].Cells[1].InsertParagraph();
            }

            return table;
        }

        private static void InsertIntoCell(Table table, int position, int i, string[] neededSymbols, string[] hoursWithoutNull)
        {
            if (neededSymbols[i].Contains("лабораторные"))
            {
                table.Rows[position].Cells[0].Paragraphs[0].Append(neededSymbols[i]);
                table.Rows[position].Cells[1].Paragraphs[0].Append(hoursWithoutNull[i]);
                return;
            }

            if (neededSymbols[i].Contains("практические"))
            {
                table.Rows[position].Cells[0].Paragraphs[0].Append(neededSymbols[i]);
                table.Rows[position].Cells[1].Paragraphs[0].Append(hoursWithoutNull[i]);
                return;
            }

            if (neededSymbols[i].Contains("курсовая"))
            {
                table.Rows[position].Cells[0].Paragraphs[0].Append(neededSymbols[i]);
                table.Rows[position].Cells[1].Paragraphs[0].Append(hoursWithoutNull[i]);
                return;
            }

            // text[i - (i - 1) - 1]

            table.Rows[position].Cells[0].Paragraphs[0].Append($"{neededSymbols[i]}");
            table.Rows[position].Cells[1].Paragraphs[0].Append(hoursWithoutNull[i]);
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

        private static float _sectionNumber = 1.0f;
        private static string _sectionName;

        public static Table CreateHeadOfBigTable(DocX document, ThemeViewModel theme, SectionViewModel section)
        {
            _sectionName = section.SectionName;
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count + 1;
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

        public static Table CreateHeadOfBigTable(DocX document, SectionViewModel section)
        {
            int totalLength = 3;
            const int columns = 5;

            var table = document.AddTable(totalLength, columns);
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

            table.Rows[1].MergeCells(1, 2);
            table.Rows[1].Cells[0].Paragraphs[0].Append("1");
            table.Rows[1].Cells[2].Paragraphs[0].Append("3");
            table.Rows[1].Cells[3].Paragraphs[0].Append("4");
            table.Rows[1].Cells[1].Paragraphs[0].Append("2");

            table.Rows[2].MergeCells(0, 2);
            table.Rows[2].Cells[0].Paragraphs[0].Append($"Раздел {_sectionNumber} {section.SectionName}");
            _sectionNumber += 0.1f;
            _sectionName = section.SectionName;

            return table;
        }

        public static Table CreateCenterOfBigTable(DocX document, ThemeViewModel theme, SectionViewModel section)
        {
            int totalLengthPlusOne = 0;
            int totalLength = 0;

            if (_sectionName != section.SectionName)
            {
                totalLengthPlusOne = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count + 1;
            }

            totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count;

            const int columns = 5;

            int practicalCount = theme.PracticalTrainingTopics.Count;
            int educationCount = theme.EducationMaterials.Count;

            Table table = totalLengthPlusOne != 0 ? document.AddTable(totalLengthPlusOne + 2, columns) :
               document.AddTable(totalLength + 3, columns);

            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLengthPlusOne != 0 ? totalLengthPlusOne + 1 : totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLengthPlusOne != 0 ? totalLengthPlusOne + 1 : totalLength + 2);

            if (_sectionName != section.SectionName)
            {
                table.Rows[2].MergeCells(0, 2);
                table.Rows[2].Cells[0].Paragraphs[0].Append($"Раздел {_sectionNumber} {section.SectionName}");
                _sectionNumber += 0.1f;
                _sectionName = section.SectionName;
            }

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

            table.Rows[totalLengthPlusOne != 0 ? totalLengthPlusOne + 1 : totalLength + 2].Cells[1].Paragraphs[0]
                 .Append("Самостоятельная работа обучающися").Bold().Italic();

            _totalHours = _totalHours + Convert.ToSingle(theme.EducationHours.Trim());
            _sectionName = section.SectionName;

            return table;
        }

        public static Table CreateEndOfBigTable(DocX document, ThemeViewModel theme, HomeViewModel homeViewModel,
            SectionViewModel section)
        {
            int totalLength = theme.EducationMaterials.Count + theme.PracticalTrainingTopics.Count + 1;
            const int columns = 5;

            var table = document.AddTable(totalLength + 6, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.MergeCellsInColumn(0, 0, totalLength + 2);
            table.MergeCellsInColumn(3, 0, theme.EducationMaterials.Count);
            table.MergeCellsInColumn(4, 0, totalLength + 2);

            if (_sectionName != section.SectionName)
            {
                table.Rows[2].MergeCells(0, 2);
                table.Rows[2].Cells[0].Paragraphs[0].Append($"Раздел {_sectionNumber} {section.SectionName}");
            }

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