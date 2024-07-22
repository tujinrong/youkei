using AIplus.AiReport;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;

namespace EucReportTest
{
    [TestClass]
    public class Common
    {

        [TestMethod]
        public void CheckEucTableData()
        {
            using DaDbContext db = new DaDbContext();

            //   var ret = DaEucService.CheckEuTableItem(db);
            var file = @"C:\temp\Error.txt";
            var ret = DaEucService.CheckEuTableItem(db, file);
            //System.Diagnostics.Process.Start(file);
        }

        [TestMethod]
        public void EUCテーブルデータ修正()
        {
            var sql1 = "update tm_eutableitem set usekbn = '3', syukeikbn = '2' where itemhyojinm = '宛名番号'";
            var sql2 = "update tm_eutableitem set syukeikbn = '1' where usekbn = '3' AND syukeikbn = ''";
            var sql3 = "update tm_eutableitem set itemkbn = '3' where itemhyojinm = '個人番号'";

            using DaDbContext db = new DaDbContext();
            db.Session.Execute(sql1);
            db.Session.Execute(sql2);
            db.Session.Execute(sql3);
        }

        [TestMethod]
        public void TestAll()
        {
            //台帳、一覧
            var tester1 = new TestSmartEngine();
            tester1.Test一覧表();
            tester1.Test明細あり台帳();
            tester1.Test台帳();

            //集計
            //var tester2 = new Test集計帳票();
            //tester2.TestSimple();

            //SQL出力
            var tester3 = new TestSQLEngine();
            tester3.TestSQL();
        }

        public static void Test(ArSheetDef rptDef, DaDbContext db, ArConditionModel condition)
        {
            //SQL取得
            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV帳票作成
            
            if (DateTime.Now.Ticks % 3 == 1)
            {
                condition.CsvOption.Encoding = ArEnumEncoding.UTF8;
                condition.CsvOption.OutputHeader = false;
            }
            else if (DateTime.Now.Ticks % 3 == 2)
            {
                condition.CsvOption.Encoding = ArEnumEncoding.UTF16_LE;
                condition.CsvOption.OutputHeader = true;
            }
            else
            {
                condition.CsvOption.Encoding = ArEnumEncoding.SHIFT_JIS;
                condition.CsvOption.OutputHeader = true;
            }

            var resultCSV = AiReport.GetCSV(db.Session, rptDef, condition);
            //条件シート出力
            condition.OutputConditionSheet = true;
            //EXCEL帳票作成
            condition.OutputType = ArEnumOutputType.Excel;
            var resultExcel = AiReport.MakeReport(db.Session, rptDef, condition);
            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
            //Preview作成
            condition.OutputType = ArEnumOutputType.Svgz;
            var resultSvgz = AiReport.MakeReport(db.Session, rptDef, condition);

            condition.OutputConditionSheet = false;
            //EXCEL白紙作成
            condition.OutputType = ArEnumOutputType.Excel; condition.IsBlank = true;
            var resultExcel2 = AiReport.MakeReport(db.Session, rptDef, condition);
            //PDF白紙作成
            condition.OutputType = ArEnumOutputType.Pdf; condition.IsBlank = true;
            var resultPdf2 = AiReport.MakeReport(db.Session, rptDef, condition);
            //白紙Preview作成
            condition.OutputType = ArEnumOutputType.Svgz; condition.IsBlank = true;
            var resultSvgz2 = AiReport.MakeReport(db.Session, rptDef, condition);
        }
        public static string GetTemplatePath(string file)
        {
            if (System.Net.Dns.GetHostName() == "DELL_DISKTOP1")
            {
                //
                //return Path.Combine("C:\\開発\\互助防疫システム\\backend\\WebService\\App_Data\\", file);
            }
            var path = Path.Combine(Environment.CurrentDirectory, "App_Data");
            return Path.Combine(path, file);
        }
    }
}
