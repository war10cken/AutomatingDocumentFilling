using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using AutomatingDocumentFilling.WPFNetFramework.Models;
using AutomatingDocumentFilling.WPFNetFramework.ViewModels;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AutomatingDocumentFilling.WPFNetFramework.Commands
{
    public class SaveCommand : AsyncCommandBase
    {
        private readonly HomeViewModel _homeViewModel;
        private readonly string _documentName;

        public SaveCommand(HomeViewModel homeViewModel, string documentName)
        {
            _homeViewModel = homeViewModel;
            _documentName = documentName;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await InsertIntoDocument(_documentName, "output.docx");
            }
            catch (NullReferenceException e)
            {
                Debug.Print(e.Message);
                Debug.Print(e.Source);
                Debug.Print(e.StackTrace);
                MessageBox.Show("Вы забыли заполнить поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async ValueTask InsertIntoDocument(string part, string newNameOfDocument)
        {
            using (var document = DocX.Load(part))
            {
                _homeViewModel.IsSaved = false;

                if (document.FindUniqueByPattern(@"<[\w \=]{4,}>", RegexOptions.IgnoreCase).Count > 0)
                {
                    string[] volumeOfDisciplineTableHeaders = { "Вид учебной работы", "Объем часов" };
                    string[] data =
                    {
                        "Суммарная учебная нагрузка во взаимодействии с преподавателем",
                        "Самостоятельная работа",
                        "Объем образовательной программы",
                        "теоретическое обучение",
                        _homeViewModel.LaboratoryWorksHours == null ? null : "лабораторные работы",
                        _homeViewModel.PracticalLessonsHours == null ? null : "практические занятия",
                        _homeViewModel.CourseWorkHoursWithCondition == null ? null : "курсовая работа",
                        "контрольная работа",
                        "консультации",
                        "Самостоятельная работа"
                    };
                    string[] hours =
                    {
                        _homeViewModel.TotalTeachingLoadHours, _homeViewModel.IndependentWorkHours,
                        _homeViewModel.VolumeOfEducationalProgramHours, _homeViewModel.TheoreticalTeachingHours,
                        _homeViewModel.LaboratoryWorksHours,
                        _homeViewModel.PracticalLessonsHours,
                        _homeViewModel.CourseWorkHoursWithCondition,
                        _homeViewModel.TestHours,
                        _homeViewModel.ConsultingHours
                    };
                    string[] lastEducationalWork =
                    {
                        _homeViewModel.SecondCertificationForm,
                        _homeViewModel.SecondConsultationHours == null ? null : "Консультации"
                    };
                    string[] lastEducationalWorkHours =
                    {
                        _homeViewModel.SecondCertificationFormHours,
                        _homeViewModel.SecondConsultationHours
                    };
                    Table volumeOfDisciplineTable = TableCreator.CreateTable(document, volumeOfDisciplineTableHeaders,
                                                                             _homeViewModel.IndependentWork, data,
                                                                             hours, lastEducationalWork, lastEducationalWorkHours);
                    string classroomEquipments = "";
                    string workshopEquipments = "";
                    string laboratoryEquipments = "";

                    if (_homeViewModel.ClassroomEquipments is { Count: > 0 })
                    {
                        classroomEquipments =
                            NormalizeEquipment("Оборудование учебного кабинета и рабочих мест кабинета:",
                                               _homeViewModel.ClassroomEquipments);
                    }

                    if (_homeViewModel.WorkshopEquipments is { Count: > 0 })
                    {
                        workshopEquipments =
                            NormalizeEquipment($"Оборудование мастерской и рабочих мест мастерской «{_homeViewModel.WorkshopRoomName}»:",
                                               _homeViewModel.WorkshopEquipments);
                    }

                    if (_homeViewModel.LaboratoryEquipments is { Count: > 0 })
                    {
                        laboratoryEquipments =
                            NormalizeEquipment($"Оборудование лаборатории и рабочих мест лаборатории «{_homeViewModel.LaboratoryRoomName}»:",
                                               _homeViewModel.LaboratoryEquipments);
                    }

                    string[] skillsHeaders = { "Умение", "Наименование умения" };

                    string[] knowledgeHeaders =
                        {"Знание", "Наименование занания"};

                    string[] generalCompetenceHeaders = { "Код", "Наименование общих компетенций" };

                    string[] professionalCompetenceHeaders =
                        {"Код", "Наименование видов деятельности и профессиональных компетенций"};

                    string[] heads = { "Результаты обучения (знания, умения)", "Критерии оценки", "Формы и методы оценки" };
                    string[] d = { "Характеристики демонстрируемых знаний", "Чем и как проверяется" };

                    var skillsTableWithKnowledge =
                        TableCreator.CreateTable(document, heads, _homeViewModel.Skills, 'У', d);

                    var knowledgeTableWithSkills =
                        TableCreator.CreateLastTable(document, heads, _homeViewModel.Knowledge, 'З');

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
                                                 _homeViewModel.ProfessionalCompetences, "ВД", "ПК");

                    //List<Table> centerTables = _homeViewModel.Themes
                    //                                         .Select(theme => TableCreator.CreateCenterOfBigTable(document, theme))
                    //                                         .ToList();

                    Table headOfBigTable = TableCreator.CreateHeadOfBigTable(document, _homeViewModel.Sections.FirstOrDefault());

                    List<Table> tablesAfterHead = _homeViewModel.Sections.FirstOrDefault()?.Themes
                        .Select(theme => TableCreator.CreateCenterOfBigTable(document, theme, _homeViewModel.Sections.FirstOrDefault()))
                        .ToList();

                    List<Table> tables = new();

                    foreach (var section in _homeViewModel.Sections)
                    {
                        foreach (var theme in section.Themes)
                        {
                            tables.Add(TableCreator.CreateCenterOfBigTable(document, theme, section));
                        }
                    }

                    tablesAfterHead.Reverse();
                    tables.Reverse();

                    Table endOfBigTable =
                        TableCreator.CreateEndOfBigTable(document,
                                                         _homeViewModel.Sections.LastOrDefault()?.Themes
                                                                       .LastOrDefault(), _homeViewModel,
                                                         _homeViewModel.Sections.LastOrDefault());

                    var courseWorksList = ListCreator.AddNewList<CourseWorkViewModel>(document,
                                                                         nameof(_homeViewModel.CourseWorks),
                                                                         _homeViewModel);
                    var mainList =
                        ListCreator.AddNewList<MainResourceViewModel>(document, nameof(_homeViewModel.MainResources),
                                                                   _homeViewModel);
                    var additionalList =
                        ListCreator.AddNewList<AdditionalResourceViewModel>(document,
                                                                             nameof(_homeViewModel.AdditionalResources),
                                                                             _homeViewModel);
                    var internetList =
                        ListCreator.AddNewList<InternetResourceViewModel>(document,
                                                                           nameof(_homeViewModel.InternetResources),
                                                                           _homeViewModel);

                    string name = string.Empty;

                    if (_homeViewModel.IsEducationRoom)
                    {
                        name = "учебный кабинет " + _homeViewModel.EducationRoomName;

                        if (_homeViewModel.IsWorkshop)
                        {
                            name = name.Insert(name.Length, ", мастерская " + _homeViewModel.WorkshopRoomName);

                            if (_homeViewModel.IsLaboratory)
                            {
                                name = name.Insert(name.Length, ", лаборатория " + _homeViewModel.LaboratoryRoomName);
                            }
                        }
                    }

                    await ReplaceTextInDocument(document, name, mainList, additionalList, internetList,
                                                endOfBigTable, courseWorksList, skillsTable, knowledgeTable,
                                                generalCompetenceTable, professionalCompetenceTable, headOfBigTable,
                                                skillsTableWithKnowledge, knowledgeTableWithSkills, tables, tablesAfterHead,
                                                classroomEquipments, workshopEquipments, laboratoryEquipments, _homeViewModel.Cycle,
                                                volumeOfDisciplineTable)
                       .ConfigureAwait(false);

                    _homeViewModel.IsSaved = true;
                    MessageBox.Show("Успешно сохранено!", "Инфо", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                document.SaveAs(newNameOfDocument);
                document.Dispose();
            }
        }

        private string NormalizeEquipment<TViewModel>(string startString, List<TViewModel> equipments)
            where TViewModel : ViewModelBase
        {
            string totalString = startString;
            List<string> names = new List<string>();

            for (int i = 0; i < equipments.Count; i++)
            {
                string equipmentName = equipments[i].GetType().GetProperty("Name")?.GetValue(equipments[i]) as string;

                if (i == 0)
                {
                    names.Add($"\n{equipmentName}");
                    totalString = totalString + names[i];
                    continue;
                }

                names.Add($", {equipmentName}");

                totalString = totalString + names[i];
            }

            totalString = totalString.Replace("\r\n", "");

            return totalString;
        }

        private async Task ReplaceTextInDocument(DocX document, string choice, List mainList,
                                                 List additionalList, List internetList, Table endOfBigTable,
                                                 List courseWorksList, Table skillsTable, Table knowledgeTable,
                                                 Table generalCompetenceTable, Table professionalCompetenceTable,
                                                 Table headOfBigTable, Table skillsTableWithKnowledge,
                                                 Table knowledgeTableWithSkills, List<Table> centerTables,
                                                 List<Table> tablesAfterHead, string classroomEquipments,
                                                 string workshopEquipments, string laboratoryEquipments,
                                                 string cycle, Table volumeOfDisciplineTable)
        {
            await Task.Factory.StartNew(() =>
            {
                document.ReplaceText("<currentyear>", _homeViewModel.CurrentYear, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<code>", _homeViewModel.CodeOfAcademicDiscipline, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<specialty>", _homeViewModel.Specialty, false, RegexOptions.IgnoreCase);
                document.ReplaceText("<formofeducation>", _homeViewModel.FormOfEducation, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<fullnameDDAA>", _homeViewModel.FullNameOfDeputyDirectorAcademicAffairs,
                                     false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<fullnameDDAMW>",
                                     _homeViewModel.FullNameOfDeputyDirectorAcademicMethodologicalWork,
                                     false, RegexOptions.IgnoreCase);
                document.ReplaceText("<fullnameCMCC>",
                                     _homeViewModel.FullNameOfChairmanOfMethodologicalCyclicCommission,
                                     false, RegexOptions.IgnoreCase);
                document.ReplaceText("<completedby>", _homeViewModel.CompletedBy, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<techfio>", _homeViewModel.TechExpertFio, false, RegexOptions.IgnoreCase);
                document.ReplaceText("<contentfio>", _homeViewModel.ContentExpertFio, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<outsidefio>", _homeViewModel.OutsideExpertFio, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<order>", _homeViewModel.Order, false, RegexOptions.IgnoreCase);
                document.ReplaceText("<placeofdisciplineinstructure>",
                                     _homeViewModel.PlaceOfDisciplineInStructure, false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<thechoice>", $"{choice}", false, RegexOptions.IgnoreCase);
                document.ReplaceText("<cycle>", cycle, false, RegexOptions.IgnoreCase);

                if (classroomEquipments != "")
                {
                    document.ReplaceText("<classroomequipments>", $"{classroomEquipments}", false,
                                         RegexOptions.IgnoreCase);
                }

                if (workshopEquipments != "")
                {
                    document.ReplaceText("<workshopequipments>", $"{workshopEquipments}", false,
                                         RegexOptions.IgnoreCase);
                }

                if (laboratoryEquipments != "")
                {
                    document.ReplaceText("<laboratoryequipments>", $"{laboratoryEquipments}", false,
                                         RegexOptions.IgnoreCase);
                }

                document.ReplaceText("<laboratoryequipments>", "", false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<workshopequipments>", "", false,
                                     RegexOptions.IgnoreCase);
                document.ReplaceText("<classroomequipments>", "", false,
                                     RegexOptions.IgnoreCase);

                if (additionalList != null)
                    InsertListIntoDocument(document, additionalList, "<additionallist>");
                else
                    document.ReplaceText("<additionallist>", "", false, RegexOptions.IgnoreCase);

                if (internetList != null)
                    InsertListIntoDocument(document, internetList, "<internetlist>");
                else
                    document.ReplaceText("<internetlist>", "", false, RegexOptions.IgnoreCase);

                InsertListIntoDocument(document, mainList, "<mainlist>");
                InsertListIntoDocument(endOfBigTable, courseWorksList, "<courseworks>");

                document.ReplaceTextWithObject("<skillstable>", skillsTable, false, RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<volumeofdisciplinetable>", volumeOfDisciplineTable, false, RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<knowledgetable>", knowledgeTable, false,
                                               RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<generalcompetencetable>", generalCompetenceTable, false,
                                               RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<professionalcompetencetable>", professionalCompetenceTable,
                                               false, RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<bigtable>", headOfBigTable, false, RegexOptions.IgnoreCase);
                document.ReplaceTextWithObject("<totalresultstable>", skillsTableWithKnowledge, false,
                                               RegexOptions.IgnoreCase);
                skillsTableWithKnowledge.InsertTableAfterSelf(knowledgeTableWithSkills);
                headOfBigTable.InsertTableAfterSelf(endOfBigTable);

                // foreach (var table in tablesAfterHead)
                // {
                //     endOfBigTable.InsertTableAfterSelf(table);
                // }

                //centerTables.RemoveAt(0);
                centerTables.RemoveAt(centerTables.Count - 1);

                foreach (var table in centerTables)
                {
                    headOfBigTable.InsertTableAfterSelf(table);
                }
            });
        }

        private void InsertListIntoDocument(Table table, List list, string phrase)
        {
            foreach (var paragraph in table.Paragraphs.Where(paragraph => paragraph.Text.Contains(phrase)))
            {
                foreach (var item in list.Items.Where(item => !string.IsNullOrWhiteSpace(item.Text)))
                {
                    paragraph.InsertParagraphAfterSelf(item);
                }

                paragraph.Remove(false);
            }
        }

        private void InsertListIntoDocument(DocX document, List list, string phrase)
        {
            foreach (var paragraph in document.Paragraphs.Where(paragraph => paragraph.Text.Contains(phrase)))
            {
                foreach (var item in list.Items.Where(item => !string.IsNullOrWhiteSpace(item.Text)))
                {
                    paragraph.InsertParagraphAfterSelf(item);
                }

                paragraph.Remove(false);
            }
        }
    }
}