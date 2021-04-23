using System.Collections.Generic;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace WpfApplication1.Models
{
    public static class TableCreator
    {
        public static Table CreateTable(DocX document, IReadOnlyList<string> headers, string[] data, char symbol)
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

        public static Table CreateTable(DocX document, IReadOnlyList<string> headers, string[] data, string symbol)
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
        
        public static Table CreateBigTable(DocX document, IReadOnlyCollection<string> curriculumContent, IReadOnlyCollection<string> topicsOfPracticalTraining)
        {
            int rows = curriculumContent.Count + topicsOfPracticalTraining.Count + 7;
            int columns = 5;

            var table = document.AddTable(rows, columns);
            table.Alignment = Alignment.center;
            table.Design = TableDesign.TableGrid;
            table.AutoFit = AutoFit.Contents;

            table.Rows[0].MergeCells(1, 2);
            table.MergeCellsInColumn(0, 1, 7);
            table.MergeCellsInColumn(3, 1, 3);
            table.MergeCellsInColumn(4, 1, 7);
            table.Rows[4].MergeCells(1, 2);
            table.Rows[5].MergeCells(1, 2);
            table.Rows[6].MergeCells(1, 2);
            table.Rows[7].MergeCells(1, 2);
            table.Rows[8].MergeCells(0, 2);
            table.Rows[9].MergeCells(0, 2);
            table.Rows[10].MergeCells(0, 2);

            table.Rows[0].Cells[1].Paragraphs[0].Append("Самостоятельная работа обучающихся");
            table.Rows[1].Cells[0].Paragraphs[0].Append("Тема Парампампам.");
            table.Rows[1].Cells[1].Paragraphs[0].Append("Содержание учебного плана");
            
            table.Rows[1].Cells[2].Paragraphs[0].Append("Уровень освоения");
            table.Rows[2].Cells[1].Paragraphs[0].Append("1. pppp");
            table.Rows[3].Cells[1].Paragraphs[0].Append("2. aaa");
            
            table.Rows[4].Cells[1].Paragraphs[0].Append("Тематика практических занятий и лабароторных работ");
            table.Rows[5].Cells[1].Paragraphs[0].Append("1. фцу");
            table.Rows[6].Cells[1].Paragraphs[0].Append("2. пвап");
            
            table.Rows[7].Cells[1].Paragraphs[0].Append("Самостоятельная работа обучающися");

            return table;
        }
    }
}