using AIplus.AiReport;
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
    public class TestSubReport
    {
        const string 検診_TableID = "T";
        const string 住民_TableID = "T1";
        const string 実施日_TableID = "F1";
        const string 受診番号_TableID = "F2";
        const string 医療機関_TableID = "F3";
        const string CONDITION1_NAME = "年度";
        const string CONDITION2_NAME = "事業コード";

        [TestMethod]
        public void Test経年表()
        {
            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.ReportName = "胃がん経年表";
            rptDef.TemplateFullPath = Common.GetTemplatePath(@"その他Templates\胃がん経年表.xlsx");
            if (File.Exists(rptDef.TemplateFullPath)==false)
            {
                return;
            }
            //rptDef.TemplateFullPath = "C:\\開発\\互助防疫システム\\backend\\WebService\\App_Data\\【単体テスト】胃がん経年表850ac67bf9954cc98340ac5592d33092.xlsx";
            //★Sheet定義
            var sheet1 = new ArColumnSheetDef();
            rptDef.SubSheetDefs.Add(sheet1);
            sheet1.Name = AiReport.GetSheetName(rptDef.TemplateFullPath);
            sheet1.IsLandscape = false;

            //データ取得
            var engine = new ArSmartListEngine();
            sheet1.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();
            //★宛名番号改ページ
            engine.ItemDefs[0].IsPageBreakItem = true;

            //----------------------------------------------------------
            //サブ帳票 明細あり台帳
            //----------------------------------------------------------
            var sheet2 = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet2);
            sheet2.Name = sheet1.Name;
            //sheet2.EndRowIndex = 38;

            //サブ帳票
            var engine2 = new ArSQLEngine();
            sheet2.Engine = engine2;
            engine2.ItemDefs = GetItems2();
            engine2.SQL = @"
SELECT atenano AS T_1, count(*) T_2
FROM tt_shkensin T
group by atenano 
";
            engine2.ItemDefs[0].IsPageBreakItem = true;

            //★年度項目設定
            //設定１：Select項目の設定
            var 年度項目 =engine.ItemDefs.Find(x=>x.SqlColumn == "年度")!;
            年度項目.GroupType =  EnumGroupItemType.ColumnGroup;
            //設定２：条件パラメータ名の設定
            engine.ColumnParemeterName = CONDITION1_NAME;

            //----------------------------------------------------------
            //テンプレート設定情報
            //----------------------------------------------------------
            {
                var templateInfo = new ArTemplateDef();
                templateInfo.DetailStartRowIndex = 5;   //明細開始行
                templateInfo.DetailRowCount = 44;       //明細行数
                templateInfo.EndRowIndex = 50;          //最終行
                //★列設定
                templateInfo.DetailStartColumnIndex = 3;//開始列
                templateInfo.DetailColumnCount = 2;     //間隔
                templateInfo.DetailMaxColumns = 5;      //５年
                engine.TemplateInfo = templateInfo;
            }
            {
                var templateInfo = new ArTemplateDef();
                templateInfo.DetailStartRowIndex = 48;   //明細開始行
                templateInfo.DetailRowCount = 2;       //明細行数
                templateInfo.EndRowIndex = 50;          //最終行
                engine2.TemplateInfo = templateInfo;
            }


            //検索条件
            var condition = GetCondition();

            //件数制限
            condition.LimitData = 0;

            //時間制限（秒）
            condition.LimitTime = 3000;

            //ページ分割
            condition.SplitIndex = 1;
            condition.SplitPages = 3;

            //特殊項目情報
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票名] = "胃がん経年表";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.公印] = new byte[0];
            //condition.SpecialItemDic[ArEnumSpecialInputItem.代表者名] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.問い合わせ先] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザーID] = 1;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.基準日] = DateTime.Today;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票グループID] = 1;

            //テスト実行
            condition.OutputType = ArEnumOutputType.Pdf;
            condition.OutputConditionSheet = true;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }

        [TestMethod]
        public void Test経年表2()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath(@"その他Templates\胃がん経年表.xlsx");
            if (File.Exists(rptDef.TemplateFullPath) == false)
            {
                return;
            }
            //rptDef.TemplateFullPath = "C:\\開発\\互助防疫システム\\backend\\WebService\\App_Data\\【単体テスト】胃がん経年表850ac67bf9954cc98340ac5592d33092.xlsx";
            //★Sheet定義
            var sheet1 = new ArColumnSheetDef();
            rptDef.SubSheetDefs.Add(sheet1);
            sheet1.Name = AiReport.GetSheetName(rptDef.TemplateFullPath);
            sheet1.IsLandscape = false;

            //データ取得
            var engine = new ArSmartListEngine();
            sheet1.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();
            //★宛名番号改ページ
            engine.ItemDefs[0].IsPageBreakItem = true;

            //----------------------------------------------------------
            //サブ帳票
            //----------------------------------------------------------
            var sheet2 = new ArPageSheetDef();
            rptDef.SubSheetDefs.Add(sheet2);
            sheet2.Name = sheet1.Name;
            //sheet.EndRowIndex = 38;

            //サブ帳票
            var engine2 = new ArSQLEngine();
            sheet2.Engine = engine2;
            engine2.ItemDefs = GetItems2();
            engine2.SQL = @"
SELECT atenano AS T_1, count(*) T_2
FROM tt_shkensin T
group by atenano 
";
            engine2.ItemDefs[0].IsPageBreakItem = true;

            //★年度項目設定
            //設定１：Select項目の設定
            var 年度項目 = engine.ItemDefs.Find(x => x.SqlColumn == "年度")!;
            年度項目.GroupType = EnumGroupItemType.ColumnGroup;
            //設定２：条件パラメータ名の設定
            engine.ColumnParemeterName = CONDITION1_NAME;

            //----------------------------------------------------------
            //テンプレート設定情報
            //----------------------------------------------------------
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 5;   //明細開始行
            templateInfo.DetailRowCount = 44;       //明細行数
            templateInfo.EndRowIndex = 50;          //最終行
            //★列設定
            templateInfo.DetailStartColumnIndex = 3;//開始列
            templateInfo.DetailColumnCount = 2;     //間隔
            templateInfo.DetailMaxColumns = 5;      //５年

            //検索条件
            var condition = GetCondition();

            //件数制限
            condition.LimitData = 0;

            //時間制限（秒）
            condition.LimitTime = 3000;

            //ページ分割
            condition.SplitIndex = 1;
            condition.SplitPages = 3;

            //特殊項目情報
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票名] = "胃がん経年表";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.公印] = new byte[0];
            //condition.SpecialItemDic[ArEnumSpecialInputItem.代表者名] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.問い合わせ先] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザーID] = 1;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.基準日] = DateTime.Today;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票グループID] = 1;

            //テスト実行
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }
        [TestMethod]
        public void Test明細あり台帳()
        {
            //初期設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath(@"台帳Templates\乳がん・甲状腺検診結果名簿.xlsx");
            if (File.Exists(rptDef.TemplateFullPath) == false)
            {
                return;
            }
            //Sheet定義
            var sheet1 = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet1);
            sheet1.Name = "乳がん・甲状腺検診結果名簿";
            sheet1.IsLandscape = true;

            //メイン帳票
            var engine = new ArSmartListEngine();
            sheet1.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();
            engine.ItemDefs[0].IsPageBreakItem = true;

            //----------------------------------------------------------
            //サブ帳票
            //----------------------------------------------------------
            var sheet2 = new ArPageSheetDef();
            rptDef.SubSheetDefs.Add(sheet2);
            //sheet2.Name = sheet.Name;
            //sheet.EndRowIndex = 38;

            //サブ帳票
            var engine2 = new ArSQLEngine();
            sheet2.Engine = engine2;
            engine2.ItemDefs = GetItems2();
            engine2.SQL = @"
SELECT atenano AS T_1, count(*) T_2
FROM tt_shkensin T
group by atenano 
";
            engine2.ItemDefs[0].IsPageBreakItem = true;

            //★年度項目設定
            //設定１：Select項目の設定
            var 年度項目 = engine.ItemDefs.Find(x => x.SqlColumn == "年度")!;
            年度項目.GroupType = EnumGroupItemType.ColumnGroup;

            //設定２：条件パラメータ名の設定
            engine.ColumnParemeterName = CONDITION1_NAME;

            //----------------------------------------------------------
            //テンプレート設定情報
            //----------------------------------------------------------
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 8;
            templateInfo.DetailRowCount = 2;
            templateInfo.DetailMaxRows = 15;
            templateInfo.EndRowIndex = 38;

            //検索条件
            var condition = GetCondition();

            //テスト実行
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
            //Common.Test(rpt, rptDef, db, condition);
        }

        private List<ArItemDef> GetItems2()
        {
            var items = new List<ArItemDef>();
            items.Add(new ArItemDef() { Seq = 1, ItemID = "T_1", ItemName = "宛名番号"});
            items.Add(new ArItemDef() { Seq = 2, ItemID = "T_2", ItemName = "検診回数"});
            return items;
        }

        private List<ArItemDef> GetTestItems(int testType)
        {
            var items = new List<ArItemDef>();
            //testType = 1;
            //**年度										
            switch (testType)
            {
                case 1:
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度",
                        SqlColumn = nameof(tt_shkensinDto.nendo),
                        FormatKbn = ArEnumFormat.BarCode, Left = 100, Top = 20, Height = 20, Width = 100 }) ;
                    break;

                case 2:
                    //バーコード住所
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度", SqlColumn = nameof(tt_shkensinDto.nendo), FormatKbn = ArEnumFormat.BarCode });
                    break;

                case 3:
                    //バーコード住所
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度", SqlColumn = nameof(tt_shkensinDto.nendo), 
                        FormatKbn = ArEnumFormat.QRCode , Width =20, Height=20});
                    break;

                case 4:
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度", SqlColumn = nameof(tt_shkensinDto.nendo), FormatKbn = ArEnumFormat.Year});
                    break;

                case 5:
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度", SqlColumn = nameof(tt_shkensinDto.nendo), FormatKbn = ArEnumFormat.Year});
                    break;

                default:
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", ItemName = "年度", SqlColumn = nameof(tt_shkensinDto.nendo)});
                    break;
            }
            //**実施日
            items.Add(new ArItemDef() { Seq = 2, ItemID = "F1_1", ItemName = "実施日", SqlColumn = nameof(tt_shfreeDto.strvalue),  BlankValue=DateTime.Today.ToString() });
            //**処理日
            //**受診番号 
            items.Add(new ArItemDef() { Seq = 4, ItemID = "F2_1", ItemName = "受診番号", SqlColumn = nameof(tt_shfreeDto.strvalue)  });
            //**氏名 
            items.Add(new ArItemDef() { Seq = 5, ItemID = "T1_1", ItemName = "氏名", SqlColumn = $"{nameof(tt_afatenaDto.simei)} || {nameof(tt_afatenaDto.simei_kana)}" });
            //**生年月日
            items.Add(new ArItemDef() { Seq = 6, ItemID = "T1_2", ItemName = "生年月日", SqlColumn = nameof(tt_afatenaDto.bymd), SortType = AIplus.AiReport.Enums.ArEnumSort.Ascending });
            //**性別
            items.Add(new ArItemDef() { Seq = 6, ItemID = "T1_2", ItemName = "性別", SqlColumn = nameof(tt_afatenaDto.sex), SortType = AIplus.AiReport.Enums.ArEnumSort.Descending,BlankValue="男" });

            return items;
        }
        private List<ArItemDef> GetItems()
        {
            var items = new List<ArItemDef>();
            //**宛名番号										
            items.Add(new ArItemDef() { Seq = 0, ItemID = "T_1", ItemName = "宛名番号", SqlColumn = nameof(tt_shkensinDto.atenano) });
            //
            //**年度										
            items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3",
                ItemName = "年度", SqlColumn= nameof(tt_shkensinDto.nendo), 
                FormatKbn= ArEnumFormat.Year,
            });
            //**実施日
            items.Add(new ArItemDef() { Seq = 2, ItemID = "F1_1", ItemName = "実施日", SqlColumn = nameof(tt_shfreeDto.strvalue) });
            //**処理日
            //**受診番号 
            items.Add(new ArItemDef() { Seq = 4, ItemID = "F2_1", ItemName = "受診番号", SqlColumn = nameof(tt_shfreeDto.strvalue) });
            //**氏名 
            items.Add(new ArItemDef() {Seq = 5, ItemID = "T1_1", ItemName = "氏名" });
            //**生年月日
            items.Add(new ArItemDef() { Seq = 6, ItemID = "T1_2", ItemName = "生年月日", SqlColumn = nameof(tt_afatenaDto.bymd), SortType = AIplus.AiReport.Enums.ArEnumSort.Ascending });
            //**性別
            items.Add(new ArItemDef() {Seq = 6, ItemID = "T1_3", SqlColumn = "性別" });
            //**住所
            //**受診日
            //**結果
            //**精密受診日
            //**精密結果
            //**検査方法
            //**備考1
            //**受診券番号
            //**整理番号
            //**年齢
            //**実施機関
            //**備考2
            //**拒否DVサイン
            return items;
        }

        private ArRelationDef GetRelation()
        {
            //T = tt_shkensin(成人保健一次検診結果（固定項目）テーブル)
            const string 事業コード = "010";
            var relationDef = new ArRelationDef();
            relationDef.MainTableName = tt_shkensinDto.TABLE_NAME;
            relationDef.MainTableID = 検診_TableID;
            relationDef.Condition = $"{nameof(tt_shkensinDto.jigyocd)} = '{事業コード}'";

            var tableRelations = relationDef.TableRelations;
            tableRelations.Add(new ArTableRelationDef()
            {
                IsLeftJoin = false,
                TableID = 住民_TableID,
                TableName = tt_afatenaDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_afatenaDto.atenano), 検診_TableID, nameof(tt_shkensinDto.atenano))
                //}
            }); ;

            //F1 = 実施日
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 実施日_TableID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), 検診_TableID,nameof(tt_shfreeDto.jigyocd)),
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_TableID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.nendo), 検診_TableID, nameof(tt_shkensinDto.nendo)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_TableID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "00601")
                //}
            });

            //F2 = 受診番号
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 受診番号_TableID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), 検診_TableID,nameof(tt_shfreeDto.jigyocd)),
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_TableID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.nendo), 検診_TableID, nameof(tt_shkensinDto.nendo)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_TableID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "00599")
                //}
            });

            //F3 = 医療機関
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 医療機関_TableID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), 検診_TableID,nameof(tt_shfreeDto.jigyocd)),
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_TableID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.nendo), 検診_TableID, nameof(tt_shkensinDto.nendo)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_TableID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "00605")
                //}
            });

            return relationDef;
        }

        private Dictionary<string, ArConditionDef> GetConditionDef()
        {
            var dic = new Dictionary<string, ArConditionDef>();
            //検索条件 年度
            {
                var conditionDef1 = new ArConditionDef();
                conditionDef1.Name = CONDITION1_NAME;
                //test
                conditionDef1.Sql = $"{検診_TableID}.{nameof(tt_shkensinDto.nendo)} = @{nameof(tt_shkensinDto.nendo)}";
                conditionDef1.ParameterList.Add($"{nameof(tt_shkensinDto.nendo)}");
                conditionDef1.TableIDList.Add($"{検診_TableID}");
                dic.Add(conditionDef1.Name, conditionDef1);
            }

            //事業コード
            {
                var conditionDef1 = new ArConditionDef();
                conditionDef1.Name = CONDITION2_NAME;
                //test
                conditionDef1.Sql = $"{検診_TableID}.{nameof(tt_shkensinDto.jigyocd)} = @{nameof(tt_shkensinDto.jigyocd)}";
                conditionDef1.ParameterList.Add($"{nameof(tt_shkensinDto.jigyocd)}");
                conditionDef1.TableIDList.Add($"{検診_TableID}");
                dic.Add(conditionDef1.Name, conditionDef1);
            }

            return dic;
        }
        private ArConditionModel GetCondition()
        {
            //検索条件
            var condition = new ArConditionModel();
            //年度
            {
                var condition1 = new ArConditionItem();
                condition.ConditionList.Add(condition1);
                condition1.Name = CONDITION1_NAME;
                var para1 = new ArParameterModel(nameof(tt_shkensinDto.nendo), 2012);
                condition1.ParaList.Add(para1);
            }

            //事業コード
            {
                var condition1 = new ArConditionItem();
                condition.ConditionList.Add(condition1);
                condition1.Name = CONDITION2_NAME;
                condition1.IsFix = true;    
                var para1 = new ArParameterModel(nameof(tt_shkensinDto.jigyocd), "010");
                condition1.ParaList.Add(para1);
            }

            return condition;
        }
    }
}