using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.Configuration;
using System.Reflection;
using System.Drawing;
using ICSharpCode.SharpZipLib.Tar;

namespace BCC.Affect.Service.Common
{
    public partial class ExcelLogger: IDisposable
    {
        //private const int V = 0;
        IWorkbook book;
        public ISheet sheet;
        public string FilePath;
        int RowIndex;
        //private int ColIndex = V;
        bool _isAppending;

        public ExcelLogger()
        {

        }

        private void WriteDataTable(string method, DataTable dt, string name)
        {
            //if (!string.IsNullOrEmpty(dt.TableName))
            //    WriteLine(method, dt.TableName, false);

            int rowIndex = RowIndex++;
            IRow row = sheet.CreateRow(rowIndex);
            ICellStyle headStyle = CreateHeadStyle();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ICell cell = row.CreateCell(i);
                cell.SetCellValue(dt.Columns[i].ColumnName);
                cell.CellStyle = headStyle;
            }

            ICellStyle bodyStyle = CreateBodyStyle();

            foreach (DataRow dr in dt.Rows)
            {
                rowIndex = RowIndex++;
                row = sheet.CreateRow(rowIndex);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    ICell cell = row.CreateCell(i);
                    SetCell(cell, dr[i]);
                    cell.CellStyle = bodyStyle;
                }
            }
            //WriteLine();

        }

        public bool Open(string fileName, string sheetName, bool isAppending)
        {
            _isAppending = isAppending;

            FilePath = GetFilePath(fileName);

            try
            {
                if (isAppending)
                {
                    if (File.Exists(FilePath))
                    {
                        OpenExcel(FilePath, sheetName);
                    }
                    else
                    {
                        CreateExcel(FilePath, sheetName);
                    }
                }
                else
                {
                    CreateExcel(FilePath, sheetName);
                }

                //ブック作成

                //ブックを保存
                //Task.Run(() => { WatchImage(); });
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return true;
        }
  
        //public void Write(string s)
        //{

        //    ColIndex++;
        //}





     
        public void Dispose()
        {
            Close();
        }
        public void Close()
        { 
            if (_isAppending)
            {
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    book.Write(fs);
                }
                book.Close();
            }
            else
            {
                var path = Path.GetDirectoryName(FilePath);
                if (Directory.Exists(path)==false)
                {
                    Directory.CreateDirectory(path);
                }
                using (var fs = new FileStream(FilePath, FileMode.Create))
                {
                    book.Write(fs);
                }
                book.Close();

            }
            book = null;
        }
        private IWorkbook CreateNewBook(string filePath)
        {
            IWorkbook book;
            var extension = Path.GetExtension(filePath);

            // HSSF => Microsoft Excel(xls形式)(excel 97-2003)
            // XSSF => Office Open XML Workbook形式(xlsx形式)(excel 2007以降)
            if (extension == ".xls")
            {
                book = new HSSFWorkbook();
            }
            else if (extension == ".xlsx")
            {
                book = new XSSFWorkbook();
            }
            else
            {
                throw new ApplicationException("CreateNewBook: invalid extension");
            }

            return book;
        }


        void SetCell(ICell cell, object value)
        {
            if (value == null)
            {
                cell.SetCellValue("");
                return;
            }
            Type valueType = value.GetType();
            if (valueType == typeof(string)) cell.SetCellValue((string)value);
            else if (valueType == typeof(int)) cell.SetCellValue((int)value);
            else if (valueType == typeof(DateTime)) cell.SetCellValue(((DateTime)value).ToString());
            //2019.02.25
            else if (valueType == typeof(decimal)) cell.SetCellValue(System.Convert.ToDouble(value));
            else if (valueType == typeof(DBNull)) cell.SetCellValue("");
            else { cell.SetCellValue(value.ToString()); }
        }

        public ICellStyle CreateHeadStyle()
        {
            ICellStyle headStyle = book.CreateCellStyle();
            headStyle.BorderBottom = BorderStyle.Thin;
            headStyle.BorderTop = BorderStyle.Thin;
            headStyle.BorderRight = BorderStyle.Thin;
            headStyle.BorderLeft = BorderStyle.Thin;
            headStyle.Alignment = HorizontalAlignment.Center;
            headStyle.FillPattern = FillPattern.SolidForeground;
            headStyle.FillForegroundColor = IndexedColors.Yellow.Index;
            headStyle.FillBackgroundColor = IndexedColors.Yellow.Index;
            return headStyle;
        }


        private ICellStyle CreateDiffRowHeadStyle()
        {
            ICellStyle cellStyle = book.CreateCellStyle();

            IFont font = book.CreateFont();
            font.Color = NPOI.HSSF.Util.HSSFColor.Blue.Index;
            cellStyle.SetFont(font);

            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            return cellStyle;
        }

        public ICellStyle CreateBodyStyle()
        {
            ICellStyle bodyStyle = book.CreateCellStyle();
            bodyStyle.BorderBottom = BorderStyle.Thin;
            bodyStyle.BorderTop = BorderStyle.Thin;
            bodyStyle.BorderRight = BorderStyle.Thin;
            bodyStyle.BorderLeft = BorderStyle.Thin;
            return bodyStyle;
        }
        private ICellStyle CreateChangedStyle()
        {
            ICellStyle cellStyle = book.CreateCellStyle();

            IFont font = book.CreateFont();
            font.Color = NPOI.HSSF.Util.HSSFColor.Red.Index;
            cellStyle.SetFont(font);

            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            return cellStyle;
        }


        private ICellStyle CreateDeletedStyle()
        {
            ICellStyle cellStyle = book.CreateCellStyle();

            IFont font = book.CreateFont();
            font.IsStrikeout = true;
            font.Color = NPOI.HSSF.Util.HSSFColor.Red.Index;
            cellStyle.SetFont(font);

            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            return cellStyle;
        }
        private ICellStyle CreateAddedStyle()
        {
            ICellStyle cellStyle = book.CreateCellStyle();
            IFont font = book.CreateFont();
            font.Color = NPOI.HSSF.Util.HSSFColor.Red.Index;
            cellStyle.SetFont(font);

            cellStyle.BorderBottom = BorderStyle.Thin;
            cellStyle.BorderTop = BorderStyle.Thin;
            cellStyle.BorderRight = BorderStyle.Thin;
            cellStyle.BorderLeft = BorderStyle.Thin;
            return cellStyle;
        }

        public void WriteCell1(int columnIndex, int rowIndex, string value, bool isBold = false, bool isBackgroundColor = false)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            cell.CellStyle.FillBackgroundColor = IndexedColors.Green.Index;
        }


        //セル設定(文字列用)
        public void WriteCell(int columnIndex, int rowIndex, string value, bool isBold = false, bool isBackgroundColor = false)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            if (isBold)
            {
                ICellStyle boldStyle = book.CreateCellStyle();
                IFont font = book.CreateFont();
                //font.IsBold = true;
                boldStyle.SetFont(font);
                cell.CellStyle = boldStyle;
                cell.CellStyle.BorderBottom = BorderStyle.Thin;
                cell.CellStyle.BorderTop = BorderStyle.Thin;
                cell.CellStyle.BorderRight = BorderStyle.Thin;
                cell.CellStyle.BorderLeft = BorderStyle.Thin;
                //boldStyle.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.Yellow.Index;
            }
            if (isBackgroundColor)
            {
                
                cell.CellStyle.FillBackgroundColor = IndexedColors.Green.Index;
            }

            cell.SetCellValue(value);
        }

        public void WriteCell(ICellStyle style, int columnIndex, int rowIndex, string value, bool isBold = false, bool isBackgroundColor = false)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            cell.CellStyle = style;
            cell.SetCellValue(value);
        }


        //セル設定(数値用)
        public void WriteCell(int columnIndex, int rowIndex, double value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }

        //セル設定(数値用)
        public void WriteCell(ICellStyle style, int columnIndex, int rowIndex, double value, bool isBold = false, bool isBackgroundColor = false)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);
            cell.CellStyle = style;
            cell.SetCellValue(value);
        }

        //セル設定(日付用)
        public void WriteCell(int columnIndex, int rowIndex, DateTime value)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.SetCellValue(value);
        }



        //書式変更
        public void WriteStyle(int columnIndex, int rowIndex, ICellStyle style)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(columnIndex) ?? row.CreateCell(columnIndex);

            cell.CellStyle = style;
        }


        private void CreateExcel(string FilePath, string sheetName)
        {
            book = CreateNewBook(FilePath);

            sheet = book.CreateSheet(sheetName);

        }

        private void OpenExcel(string FilePath, string sheetName)
        {
            using (var fs = System.IO.File.OpenRead(FilePath))
            {
                book = WorkbookFactory.Create(fs);
                sheet = book.GetSheet(sheetName);
                if (sheet == null)
                {
                    sheet = book.CreateSheet(sheetName);
                    RowIndex = 0;
                }
                else
                {
                    RowIndex = sheet.LastRowNum + 1;
                }

            }
        }

        private string GetFilePath(string fileName)
        {
            if (!fileName.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                fileName += ".xlsx";
            }
            if (fileName.IndexOf('\\') < 0)
            {
                string settingPath = ConfigurationManager.AppSettings["Test.ExcelPath"] ?? "";
                if (settingPath == "")
                {
                    settingPath = "..\\log";
                }
                string testPath;

                if (settingPath.Contains(":"))
                {
                    testPath = settingPath;
                }
                else
                {
                    string ExePath = this.GetType().Assembly.Location;
                    ExePath = ExePath.Substring(0, ExePath.LastIndexOf('\\'));
                    testPath = Path.Combine(ExePath, settingPath);
                }
                testPath = Path.GetFullPath(testPath);
                if (Directory.Exists(testPath) == false)
                {
                    Directory.CreateDirectory(testPath);
                }
                FilePath = Path.Combine(testPath, fileName);


            }
            else
            {
                FilePath = fileName;
            }
            return FilePath;
        }

        internal void WriteTitleCell(int colIndex, int rowIndex, string sGrouplabel, bool v)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            var cell = row.GetCell(colIndex) ?? row.CreateCell(colIndex);
            ICellStyle boldStyle = book.CreateCellStyle();
            IFont font = book.CreateFont();
            font.IsBold = true;
            boldStyle.SetFont(font);
            cell.CellStyle = boldStyle;
            cell.SetCellValue(sGrouplabel);
        }

        //現在の行をターゲット行にコピー
        public void CopyRow(int rowIndex, int targetIndex)
        {
            var row = sheet.GetRow(rowIndex) ?? sheet.CreateRow(rowIndex);
            row.CopyRowTo(targetIndex);
        }
    }
}