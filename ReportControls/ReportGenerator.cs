using System;
using System.Collections.Generic;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using coursa4.Data;
using coursa4.Models;
using Microsoft.EntityFrameworkCore;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

namespace coursa4.ReportControls
{
    public class ReportGenerator
    {
        public bool GenerateOrderReport(int orderId)
        {
            try
            {
                using var context = new Coursa4Context();
                var order = context.Orders
                    .Include(o => o.Client)
                    .Include(o => o.Vehicle)
                    .Include(o => o.Services)
                    .Include(o => o.Employees)
                    .FirstOrDefault(o => o.Id == orderId);

                if (order == null)
                    return false;

                // Создаем папку Reports если не существует
                string reportsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reports");
                if (!Directory.Exists(reportsFolder))
                {
                    Directory.CreateDirectory(reportsFolder);
                }

                string filePath = Path.Combine(reportsFolder, $"{orderId}.docx");

                // Создаем документ
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(
                    filePath, WordprocessingDocumentType.Document))
                {
                    // Добавляем основную часть документа
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Добавляем стили
                    AddStyles(mainPart);

                    // 1. Заголовок отчета
                    AddReportHeader(body, order);

                    // 2. Основная информация о заказе
                    AddOrderInfo(body, order);

                    // 3. Информация о клиенте
                    AddClientInfo(body, order.Client);

                    // 4. Информация о транспортном средстве
                    AddVehicleInfo(body, order.Vehicle);

                    // 5. Выполненные услуги
                    AddServicesInfo(body, order.Services);

                    // 6. Ответственные сотрудники
                    AddEmployeesInfo(body, order.Employees);

                    // 7. Итоговая стоимость и подписи
                    AddFooterInfo(body, order);

                    // 8. Штамп организации
                    AddOrganizationStamp(body);

                    mainPart.Document.Save();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при генерации отчета: {ex.Message}");
                return false;
            }
        }

        private void AddStyles(MainDocumentPart mainPart)
        {
            // Создание части со стилями
            StyleDefinitionsPart stylePart = mainPart.AddNewPart<StyleDefinitionsPart>();
            Styles styles = new Styles();

            // Стиль для заголовка
            Style titleStyle = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "Title",
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = "Заголовок отчета" };
            titleStyle.Append(styleName1);
            StyleRunProperties runProperties1 = new StyleRunProperties();
            runProperties1.Append(new Bold());
            runProperties1.Append(new FontSize() { Val = "32" });
            runProperties1.Append(new RunFonts() { Ascii = "Times New Roman" });
            runProperties1.Append(new Justification() { Val = JustificationValues.Center });
            titleStyle.Append(runProperties1);
            styles.Append(titleStyle);

            // Стиль для подзаголовков
            Style headingStyle = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "Heading1",
                CustomStyle = true
            };
            StyleName styleName2 = new StyleName() { Val = "Заголовок раздела" };
            headingStyle.Append(styleName2);
            StyleRunProperties runProperties2 = new StyleRunProperties();
            runProperties2.Append(new Bold());
            runProperties2.Append(new FontSize() { Val = "20" });
            runProperties2.Append(new RunFonts() { Ascii = "Times New Roman" });
            runProperties2.Append(new Underline() { Val = UnderlineValues.Single });
            headingStyle.Append(runProperties2);
            styles.Append(headingStyle);

            // Стиль для обычного текста
            Style normalStyle = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "Normal",
                CustomStyle = true
            };
            StyleName styleName3 = new StyleName() { Val = "Обычный текст" };
            normalStyle.Append(styleName3);
            StyleRunProperties runProperties3 = new StyleRunProperties();
            runProperties3.Append(new FontSize() { Val = "14" });
            runProperties3.Append(new RunFonts() { Ascii = "Times New Roman" });
            normalStyle.Append(runProperties3);
            styles.Append(normalStyle);

            // Стиль для таблиц
            Style tableStyle = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = "TableText",
                CustomStyle = true
            };
            StyleName styleName4 = new StyleName() { Val = "Текст таблицы" };
            tableStyle.Append(styleName4);
            StyleRunProperties runProperties4 = new StyleRunProperties();
            runProperties4.Append(new FontSize() { Val = "12" });
            runProperties4.Append(new RunFonts() { Ascii = "Times New Roman" });
            tableStyle.Append(runProperties4);
            styles.Append(tableStyle);

            stylePart.Styles = styles;
        }

        private void AddReportHeader(Body body, Order order)
        {
            // Добавляем логотип (опционально)
            // AddLogo(body);

            // Название организации
            Paragraph orgPara = body.AppendChild(new Paragraph());
            Run orgRun = orgPara.AppendChild(new Run());
            orgRun.AppendChild(new Text("АВТОСЕРВИС 'ТЕХНОСЕРВИС'"));
            orgPara.ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new SpacingBetweenLines() { After = "200" }
            );

            // Заголовок отчета
            Paragraph titlePara = body.AppendChild(new Paragraph());
            Run titleRun = titlePara.AppendChild(new Run());
            titleRun.AppendChild(new Text("ОТЧЕТ О ВЫПОЛНЕННЫХ РАБОТАХ"));
            titlePara.ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new SpacingBetweenLines() { After = "200" }
            );

            // Номер отчета и дата
            Paragraph detailsPara = body.AppendChild(new Paragraph());
            Run detailsRun = detailsPara.AppendChild(new Run());
            detailsRun.AppendChild(new Text($"Отчет №: {order.Id}"));
            detailsRun.AppendChild(new Break());
            detailsRun.AppendChild(new Text($"Дата формирования: {DateTime.Now:dd.MM.yyyy}"));
            detailsRun.AppendChild(new Break());
            detailsRun.AppendChild(new Text($"Номер заказа-наряда: {order.Id}"));
            detailsPara.ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new SpacingBetweenLines() { After = "400" }
            );
        }

        private void AddOrderInfo(Body body, Order order)
        {
            // Заголовок раздела
            AddSectionHeader(body, "1. ОБЩАЯ ИНФОРМАЦИЯ О ЗАКАЗЕ");

            // Таблица с информацией о заказе
            Table table = CreateTable(2, 5);
            TableRow row;

            // Дата приема
            row = AddTableRow(table);
            AddTableCell(row, "Дата приема:", true);
            AddTableCell(row, order.AcceptionDate.ToString("dd.MM.yyyy HH:mm"), false);

            // Дата выполнения
            row = AddTableRow(table);
            AddTableCell(row, "Дата выполнения:", true);
            string completionDate = order.ActualCompletionDate?.ToString("dd.MM.yyyy HH:mm") ?? "В процессе";
            AddTableCell(row, completionDate, false);

            // Планируемая дата
            row = AddTableRow(table);
            AddTableCell(row, "Планируемая дата:", true);
            AddTableCell(row, order.EstimatedCompletionDate.ToString("dd.MM.yyyy"), false);

            // Статус
            row = AddTableRow(table);
            AddTableCell(row, "Статус заказа:", true);
            AddTableCell(row, order.Status, false);

            // Итоговая стоимость
            row = AddTableRow(table);
            AddTableCell(row, "Итоговая стоимость:", true);
            AddTableCell(row, $"{order.Price:N2} руб.", false);

            body.AppendChild(table);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddClientInfo(Body body, Client client)
        {
            AddSectionHeader(body, "2. ИНФОРМАЦИЯ О КЛИЕНТЕ");

            Table table = CreateTable(2, 5);
            TableRow row;

            row = AddTableRow(table);
            AddTableCell(row, "Фамилия:", true);
            AddTableCell(row, client.LastName, false);

            row = AddTableRow(table);
            AddTableCell(row, "Имя:", true);
            AddTableCell(row, client.FirstName, false);

            row = AddTableRow(table);
            AddTableCell(row, "Контактный телефон:", true);
            AddTableCell(row, client.PhoneNumber, false);

            if (!string.IsNullOrEmpty(client.Email))
            {
                row = AddTableRow(table);
                AddTableCell(row, "Электронная почта:", true);
                AddTableCell(row, client.Email, false);
            }

            body.AppendChild(table);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddVehicleInfo(Body body, Vehicle vehicle)
        {
            AddSectionHeader(body, "3. ИНФОРМАЦИЯ О ТРАНСПОРТНОМ СРЕДСТВЕ");

            Table table = CreateTable(2, 7);
            TableRow row;

            row = AddTableRow(table);
            AddTableCell(row, "Марка:", true);
            AddTableCell(row, vehicle.Brand, false);

            row = AddTableRow(table);
            AddTableCell(row, "Модель:", true);
            AddTableCell(row, vehicle.Model, false);

            row = AddTableRow(table);
            AddTableCell(row, "Год выпуска:", true);
            AddTableCell(row, vehicle.Year.ToString(), false);

            row = AddTableRow(table);
            AddTableCell(row, "VIN-номер:", true);
            AddTableCell(row, vehicle.VIN, false);

            row = AddTableRow(table);
            AddTableCell(row, "Государственный номер:", true);
            AddTableCell(row, vehicle.LicensePlate, false);

            row = AddTableRow(table);
            AddTableCell(row, "Пробег:", true);
            AddTableCell(row, $"{vehicle.Mileage:N0} км", false);

            body.AppendChild(table);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddServicesInfo(Body body, List<Service> services)
        {
            AddSectionHeader(body, "4. ВЫПОЛНЕННЫЕ УСЛУГИ");

            if (services == null || services.Count == 0)
            {
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Услуги не указаны"));
                return;
            }

            Table table = CreateTable(4, services.Count + 1);

            // Заголовки таблицы
            TableRow headerRow = AddTableRow(table);
            AddTableCell(headerRow, "№", true, true);
            AddTableCell(headerRow, "Наименование услуги", true, true);
            AddTableCell(headerRow, "Описание", true, true);
            AddTableCell(headerRow, "Стоимость (руб.)", true, true);

            // Данные услуг
            int counter = 1;
            decimal total = 0;

            foreach (var service in services)
            {
                TableRow row = AddTableRow(table);
                AddTableCell(row, counter.ToString(), false, true);
                AddTableCell(row, service.Name, false, true);
                AddTableCell(row, service.Description ?? "-", false, true);
                AddTableCell(row, service.Price.ToString("N2"), false, true);
                counter++;
                total += service.Price;
            }

            // Итоговая строка
            TableRow totalRow = AddTableRow(table);
            AddTableCell(totalRow, "", false, true);
            AddTableCell(totalRow, "ИТОГО:", true, true);
            AddTableCell(totalRow, "", false, true);
            AddTableCell(totalRow, total.ToString("N2"), true, true);

            body.AppendChild(table);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddEmployeesInfo(Body body, List<Employee> employees)
        {
            AddSectionHeader(body, "5. ОТВЕТСТВЕННЫЕ СОТРУДНИКИ");

            if (employees == null || employees.Count == 0)
            {
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());
                run.AppendChild(new Text("Ответственные сотрудники не назначены"));
                return;
            }

            Table table = CreateTable(3, employees.Count + 1);

            // Заголовки таблицы
            TableRow headerRow = AddTableRow(table);
            AddTableCell(headerRow, "№", true, true);
            AddTableCell(headerRow, "Фамилия, Имя", true, true);
            AddTableCell(headerRow, "Специализация", true, true);

            // Данные сотрудников
            int counter = 1;
            foreach (var employee in employees)
            {
                TableRow row = AddTableRow(table);
                AddTableCell(row, counter.ToString(), false, true);
                AddTableCell(row, $"{employee.LastName} {employee.FirstName}", false, true);
                AddTableCell(row, employee.Specialization, false, true);
                counter++;
            }

            body.AppendChild(table);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddFooterInfo(Body body, Order order)
        {
            AddSectionHeader(body, "6. ПОДПИСИ И СОГЛАСОВАНИЯ");

            Paragraph summaryPara = body.AppendChild(new Paragraph());
            Run summaryRun = summaryPara.AppendChild(new Run());
            summaryRun.AppendChild(new Text($"Всего выполнено работ: {order.Services?.Count ?? 0}"));
            summaryRun.AppendChild(new Break());
            summaryRun.AppendChild(new Text($"Общая стоимость работ: {order.Price:N2} руб."));
            summaryRun.AppendChild(new Break());
            summaryRun.AppendChild(new Break());

            // Подписи
            Paragraph signaturesPara = body.AppendChild(new Paragraph());
            signaturesPara.ParagraphProperties = new ParagraphProperties(
                new SpacingBetweenLines() { After = "400" }
            );

            Table signaturesTable = CreateTable(2, 3);

            TableRow row1 = AddTableRow(signaturesTable);
            AddTableCell(row1, "Исполнитель:", false, true);
            AddTableCell(row1, "_________________", false, true);

            TableRow row2 = AddTableRow(signaturesTable);
            AddTableCell(row2, "Должность", false, true);
            AddTableCell(row2, "Подпись", false, true);

            TableRow row3 = AddTableRow(signaturesTable);
            AddTableCell(row3, "Расшифровка подписи", false, true);
            AddTableCell(row3, "Дата", false, true);

            body.AppendChild(signaturesTable);
            body.AppendChild(new Paragraph(new Run(new Text(""))));
        }

        private void AddOrganizationStamp(Body body)
        {
            Paragraph stampPara = body.AppendChild(new Paragraph());
            stampPara.ParagraphProperties = new ParagraphProperties(
                new Justification() { Val = JustificationValues.Center },
                new SpacingBetweenLines() { Before = "800", After = "200" }
            );

            Run stampRun = stampPara.AppendChild(new Run());
            stampRun.AppendChild(new Text("М.П."));
            stampRun.AppendChild(new Break());
            stampRun.AppendChild(new Text("Отпечатано в автосервисе 'Техносервис'"));
            stampRun.AppendChild(new Break());
            stampRun.AppendChild(new Text($"{DateTime.Now:dd.MM.yyyy HH:mm}"));
        }

        private void AddSectionHeader(Body body, string text)
        {
            Paragraph para = body.AppendChild(new Paragraph());
            Run run = para.AppendChild(new Run());
            run.AppendChild(new Text(text));
            para.ParagraphProperties = new ParagraphProperties(
                new SpacingBetweenLines() { Before = "400", After = "200" }
            );
        }

        private Table CreateTable(int columns, int rows)
        {
            Table table = new Table();

            // Свойства таблицы
            TableProperties tableProperties = new TableProperties(
                new TableBorders(
                    new TopBorder() { Val = BorderValues.Single, Size = 4 },
                    new BottomBorder() { Val = BorderValues.Single, Size = 4 },
                    new LeftBorder() { Val = BorderValues.Single, Size = 4 },
                    new RightBorder() { Val = BorderValues.Single, Size = 4 },
                    new InsideHorizontalBorder() { Val = BorderValues.Single, Size = 2 },
                    new InsideVerticalBorder() { Val = BorderValues.Single, Size = 2 }
                ),
                new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct }
            );

            table.AppendChild(tableProperties);
            return table;
        }

        private TableRow AddTableRow(Table table)
        {
            TableRow row = new TableRow();
            table.AppendChild(row);
            return row;
        }

        private void AddTableCell(TableRow row, string text, bool isBold, bool isCentered = false)
        {
            TableCell cell = new TableCell(new Paragraph(new Run(new Text(text))));

            // Свойства ячейки
            TableCellProperties cellProperties = new TableCellProperties(
                new TableCellWidth() { Type = TableWidthUnitValues.Auto }
            );
            cell.AppendChild(cellProperties);

            // Свойства параграфа в ячейке
            if (isBold)
            {
                cell.GetFirstChild<Paragraph>().GetFirstChild<Run>().RunProperties =
                    new RunProperties(new Bold());
            }

            if (isCentered)
            {
                cell.GetFirstChild<Paragraph>().ParagraphProperties =
                    new ParagraphProperties(new Justification() { Val = JustificationValues.Center });
            }

            row.AppendChild(cell);
        }
    }
}
