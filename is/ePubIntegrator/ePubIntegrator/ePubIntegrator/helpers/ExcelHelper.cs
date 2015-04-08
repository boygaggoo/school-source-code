using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePubIntegrator.helpers
{
    using Excel = Microsoft.Office.Interop.Excel;
    public static class ExcelHelper
    {
        public static void createNewExcelFile(string path)
        {
            var excelApplication = new Excel.Application(); 
            excelApplication.Visible = false;
            var excelWorkbook = excelApplication.Workbooks.Add();
            excelWorkbook.SaveAs(path, AccessMode: Excel.XlSaveAsAccessMode.xlNoChange);

            excelWorkbook.Close(); 
            excelApplication.Quit();

            //free all the memory used
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);
        }


        public static void createSheetExcelFile(string path,string nameSheet1, string nameSheet2)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelApplication.ActiveSheet;
            Excel.Worksheet excelWorksheet2 = (Excel.Worksheet)excelWorkbook.Worksheets.Add();
            excelWorksheet.Name = nameSheet1; //nome da folha
            excelWorksheet2.Name = nameSheet2;
          
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used

            //ReleaseCOMObject(excelWorksheet2);
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }





        public static void writeTopEbookViewsExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application(); 
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[1, 1] = "Top 5 eBooks Mais Consultados";
            for (int i = 2; i < 7; i++)
            {
                excelWorksheet.Cells[i, 1] = "eBooks";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used
           
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }

        public static void writeTopChaptersEbookViewsExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[1, 2] = "Top 5 Capitulos de eBooks Mais Consultados";
            for (int i = 2; i < 7; i++)
            {
                excelWorksheet.Cells[i, 2] = "chapters";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used

            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }


        public static void writeTopEbookBookMarksExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[8, 1] = "Top 5 eBooks com mais BookMarks";
            for (int i = 9; i < 14; i++)
            {
                excelWorksheet.Cells[i, 1] = "eBook";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used

            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }

        public static void writeTopChaptersEbookBookMarksExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[8, 2] = "Top 5 Capitulos de eBooks com mais BookMarks";
            for (int i = 9; i < 14; i++)
            {
                excelWorksheet.Cells[i, 2] = "Chapter";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();;
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used

            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }


        public static void writeTopEbookFavoriteExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[15, 1] = "Top 5 eBooks Favoritos";
            for (int i = 16; i < 21; i++)
            {
                excelWorksheet.Cells[i, 1] = "ebook";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used
;
            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }

        public static void writeTopChaptersEbookFavoriteExcelFile(string path, string sheet)
        {
            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkbook = excelApplication.Workbooks.Open(path);
            Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelWorkbook.Worksheets.get_Item(sheet);
            excelWorksheet.Cells[15, 2] = "Top 5 Capitulos de Ebooks Favoritos";
            for (int i = 16; i < 21; i++)
            {
                excelWorksheet.Cells[i, 2] = "Chapter";
            }
            excelWorksheet.UsedRange.Columns.AutoFit();
            excelWorkbook.Save();
            excelWorkbook.Close();
            excelApplication.Quit();

            //free all the memory used

            ReleaseCOMObject(excelWorksheet);
            ReleaseCOMObject(excelWorkbook);
            ReleaseCOMObject(excelApplication);

        }


        //It’s necessary to free all the memory used by the excel objects. e.g.: //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook) //excelWorkbook = null;
        //...
        //GC.Collect();
        private static void ReleaseCOMObject(object obj) {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
