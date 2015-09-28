using System.Linq;
using System.Collections;
using DevExpress.Spreadsheet;
using DevExpress.Web.Mvc;
using DevExpressControls.Models;

namespace DevExpressControls.Helpers
{
    public class SpreadsheetFormulaHelper
    {
        const string DefaultFontName = "Segoe UI";
        const float DefaultFontSize = 10.5f;
        const int
            InitialColumnOffset = 1,
            InitialRowOffset = 6;

        static IList Invoices = InvoicesProvider.GetInvoices();
        static IWorkbook book;
        static Worksheet sheet;

        public static void PrepareSpreadsheet(MVCxSpreadsheet Spreadsheet)
        {
            book = Spreadsheet.Document;
            book.Unit = DevExpress.Office.DocumentUnit.Point;
            book.Styles.DefaultStyle.Font.Name = DefaultFontName;
            book.Styles.DefaultStyle.Font.Size = DefaultFontSize;
            book.Styles.DefaultStyle.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;

            sheet = book.Worksheets.First();
            sheet.ActiveView.ShowGridlines = false;
            sheet.Name = "Estimator Formulas";

            PrepareColumns(sheet);
            PrepareWatermarkStyleCell(sheet.Cells[1, 1]);
            FillInvoice(sheet);
            book.History.Clear();
        }

        public static CellValue GetCellValue(string cell)
        {
            return sheet[cell].Value;
        }

        static void PrepareColumns(Worksheet sheet)
        {
            sheet.Columns[0].WidthInCharacters = 3;
            sheet.Columns[1].WidthInCharacters = 47.86;
            sheet.Columns[2].WidthInCharacters = 12;
            sheet.Columns[3].WidthInCharacters = 18;
            sheet.Columns[4].WidthInCharacters = 16;
            sheet.Columns[5].WidthInCharacters = 21;
        }
        static void PrepareWatermarkStyleCell(Cell cell)
        {
            cell.Font.Size = 36;
            cell.Font.FontStyle = SpreadsheetFontStyle.BoldItalic;
            cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Left;
            cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Bottom;
            cell.Font.Color = DevExpress.Utils.DXColor.FromArgb(0xff, 0xE0, 0xE0, 0xE0);
            cell.Value = "INVOICE";
        }
        static void FillInvoice(Worksheet sheet)
        {
            CreateTableColumns(sheet);
            FillInvoiceTable(sheet);
            PrepareTotalValue(sheet);
        }
        static void CreateTableColumns(Worksheet sheet)
        {
            string[] columnTitles = new string[] { "Description", "QTY", "Price", "Discount", "Amount" };
            for (int columnOffset = InitialColumnOffset; columnOffset < InitialColumnOffset + columnTitles.Length; columnOffset++)
            {
                Cell cell = sheet.Cells[InitialRowOffset, columnOffset];
                cell.Font.FontStyle = SpreadsheetFontStyle.Bold;
                cell.Font.Color = DevExpress.Utils.DXColor.FromArgb(0xff, 0x33, 0x33, 0x33);
                cell.Borders.BottomBorder.LineStyle = BorderLineStyle.Medium;
                cell.Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
                cell.Alignment.Horizontal = columnOffset == InitialColumnOffset ? SpreadsheetHorizontalAlignment.Left : SpreadsheetHorizontalAlignment.Center;
                cell.Value = columnTitles[columnOffset - InitialColumnOffset];
            }
        }
        static void FillInvoiceTable(Worksheet sheet)
        {
            int currentRowOffset = InitialRowOffset + 1;
            foreach (Ship ship in Invoices)
            {
                sheet[currentRowOffset, InitialColumnOffset].Value = ship.Description;

                Cell cell = sheet[currentRowOffset, InitialColumnOffset + 1];
                cell.Value = ship.Quantity;
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

                cell = sheet[currentRowOffset, InitialColumnOffset + 2];
                sheet[currentRowOffset, InitialColumnOffset + 2].Value = ship.Price;
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

                cell = sheet[currentRowOffset, InitialColumnOffset + 3];
                cell.NumberFormat = "0.00%;[Red]-0.00%;;@";
                cell.Value = CellValue.TryCreateFromObject(ship.Discount);
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

                cell = sheet[currentRowOffset, InitialColumnOffset + 4];
                cell.Formula = string.Format("C{0}*D{0}*(1-E{0})", currentRowOffset + 1);
                cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;

                if (currentRowOffset % 2 == 0)
                    sheet.Range.FromLTRB(1, currentRowOffset, 5, currentRowOffset).FillColor = System.Drawing.Color.FromArgb(0xff, 0xF1, 0xF1, 0xF1);
                currentRowOffset++;
            }
        }
        static void PrepareTotalValue(Worksheet sheet)
        {
            int currentRowOffset = InitialRowOffset + Invoices.Count + 2;
            Cell cell = sheet[currentRowOffset, 4];
            cell.Value = "Total";
            cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            cell.Font.Bold = true;
            cell.Font.Size = 13.5;

            cell = sheet[currentRowOffset, 5];
            cell.Formula = string.Format("SUM(F{0}:F{1})", InitialRowOffset + 2, currentRowOffset - 1);
            cell.NumberFormat = "_($* #,##0.00_);_($* (#,##0.00);_($* \" - \"??_);_(@_)";
            cell.Font.Color = System.Drawing.Color.Black;
            cell.Fill.BackgroundColor = System.Drawing.Color.FromArgb(0xff, 0xea, 0xea, 0xea);
            cell.Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            cell.Font.Size = 13.5;
            cell.Select();
        }
    }
}