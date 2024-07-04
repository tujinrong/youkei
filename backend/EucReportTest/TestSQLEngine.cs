using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDef;
using AIplus.AiReport.ReportDef.SheetDefs;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EucReportTest
{
    [TestClass]
    public class TestSQLEngine
    {
        const string 検診_ID = "T";
        const string 住民_ID = "V1";
        const string 実施日_ID = "F1";
        const string 受診番号_ID = "F2";
        const string 医療機関_ID = "F3";
        const string 性別_ID = "M1";
        const string CONDITION1_NAME = "年度";

        [TestMethod]
        public void Testバーコード()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("その他Templates\\バーコード.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = AiReport.GetSheetName(rptDef.TemplateFullPath);
            //sheet.EndRowIndex = 38;

            //サブ帳票
            var engine = new ArSQLEngine();
            sheet.Engine = engine;
            //バーコード
            engine.ItemDefs.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_1",
                SqlColumn = "バーコード",
                //Sql = nameof(tt_shkensinDto.nendo),
                FormatKbn = ArEnumFormat.BarCode,
                Left = 1,
                Top = 1,
                Height = 20,
                Width = 100
            }); ;
            //バーコード住所
            engine.ItemDefs.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_2",
                SqlColumn = "住所",
                FormatKbn = ArEnumFormat.BarCode,
                Height = 10,
                Width = 100
            });

            //QR
            engine.ItemDefs.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_3",
                SqlColumn = "QRコード",
                //Sql = nameof(tt_shkensinDto.nendo),
                FormatKbn = ArEnumFormat.QRCode,
                Width = 40,
                Height = 40
            });
            engine.SQL = @"
SELECT '11333' AS T_1,
'1360071 東京都江東区亀戸1-31-7 亀戸センタービル ' AS T_2,
'http://www.aiplusgroup.co.jp' AS T_3 
FROM tt_afatena T LIMIT 1".Trim();

            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 2;
            templateInfo.DetailRowCount = 8;
            templateInfo.DetailMaxRows = 5;
            templateInfo.EndRowIndex = 38;

            //検索条件
            ArConditionModel condition = new();

            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);

        }


        [TestMethod]
        public void TestSQL()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("その他Templates\\バーコード.xlsx");

            //Sheet定義
            var sheet = new ArPageSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "乳がん・甲状腺検診結果名簿";
            //sheet.EndRowIndex = 38;

            //サブ帳票
            var engine = new ArSQLEngine();
            sheet.Engine=engine;
            engine.ItemDefs = GetItems();
            engine.SQL = @"SELECT T.nendo AS T_3,
F1.strvalue AS F1_1,
F2.strvalue AS F2_1,
V1.simei AS V1_1,
V1.bymd AS V1_2,
M1.nm AS M1_2
FROM tt_shkensin T
LEFT JOIN tt_shfree F1 ON T.atenano = F1.atenano AND T.rirekino = F1.rirekino AND F1.jigyocd = '00001' AND F1.itemcd = '001'
LEFT JOIN tt_shfree F2 ON T.atenano = F2.atenano AND T.rirekino = F2.rirekino AND F2.jigyocd = '00001' AND F2.itemcd = '002'
LEFT JOIN tt_afatena V1 ON T.atenano = V1.atenano
LEFT JOIN tm_afmeisyo M1 ON V1.sex = M1.nmcd AND M1.nmmaincd = '0001' AND M1.nmsubcd = 1
WHERE T.nendo = @nendo
ORDER BY V1.bymd, M1.nm DESC
";

            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 8;
            templateInfo.DetailRowCount = 2;
            templateInfo.EndRowIndex = 38;

            //検索条件
            var condition = GetCondition();

            //テスト実行
            Common.Test( rptDef, db, condition);

        }
        private List<ArItemDef> GetItems()
        {
            var items = new List<ArItemDef>();
            //
            //**年度										
            items.Add(new ArItemDef() {Seq = 1, ItemID = "T_3", SqlColumn = "年度" });
            //**実施日
            items.Add(new ArItemDef() {Seq = 2, ItemID = "F1_1", SqlColumn = "実施日" });
            //**処理日
            //**受診番号 
            items.Add(new ArItemDef() {Seq = 4, ItemID = "F2_1", SqlColumn = "受診番号" });
            //**氏名 
            items.Add(new ArItemDef() {Seq = 5, ItemID = "V1_1", SqlColumn = "氏名" });
            //**生年月日
            items.Add(new ArItemDef() {Seq = 6, ItemID = "V1_2", SqlColumn = "生年月日" });
            //**性別
            items.Add(new ArItemDef() {Seq = 6, ItemID = "M1_2", SqlColumn = "性別" });

            return items;
        }
        private ArConditionModel GetCondition()
        {
            //検索条件
            var condition = new ArConditionModel();
            //年度
            var condition1 = new ArConditionItem();
            condition.ConditionList.Add(condition1);
            condition1.Name = CONDITION1_NAME;
            var para1 = new ArParameterModel(nameof(tt_shkensinDto.nendo), "2022");
            condition1.ParaList.Add(para1);
            return condition;
        }
    }
}