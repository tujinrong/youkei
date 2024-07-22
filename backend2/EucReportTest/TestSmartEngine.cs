using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.Common.Model;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Helpers;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDef;
using AIplus.AiReport.ReportDef.SheetDefs;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EucReportTest
{
    [TestClass]
    public class TestSmartEngine
    {
        const string 検診_ID = "T";
        const string 住民_ID = "V1";
        const string 実施日_ID = "F1";
        const string 受診番号_ID = "F2";
        const string 医療機関_ID = "F3";
        const string 性別_ID = "M1";

        const string CONDITION1_NAME = "年度";


        [TestMethod]
        public void Test経年表()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("胃がん経年表.xlsx");

            //★Sheet定義
            var sheet = new ArColumnSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = rptDef.TemplateFullPath;
            sheet.IsLandscape = false;

            //サブ帳票
            var engine = new ArSmartListEngine();
            sheet.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();
      

            //★宛名番号改ページ
            engine.ItemDefs[0].IsPageBreakItem = true;
            //★年度項目設定
            //設定１：Select項目の設定
            var 年度項目 =engine.ItemDefs.Find(x=>x.SqlColumn == "年度")!;
            年度項目.GroupType = EnumGroupItemType.ColumnGroup;
            //年度項目.ItemGroupIndex = 1;
            //設定２：条件パラメータ名の設定
            engine.ColumnParemeterName = CONDITION1_NAME; 

            //テンプレート設定情報
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
            condition.LimitTime = 30;

            //ページ分割
            condition.SplitIndex = 1;
            condition.SplitPages = 3;

            //特殊項目情報
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票名] = "胃がん経年表";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザー名] = "";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.公印] = new byte[0];
            //condition.SpecialItemDic[ArEnumSpecialInputItem.代表者名] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.問い合わせ先] = "TODO";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザーID] = 1;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.基準日] = DateTime.Today;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票グループID] = 1;

            //テスト実行
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
            //Common.Test(rpt, rptDef, db, condition);
        }

        [TestMethod]
        public void Testシール()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";
            //C:\Users\tujin\AppData\Local\Temp\euc

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("シール.xlsx");
            //rptDef.TemplateFullPath = Common.GetTemplatePath("胃がん経年表.xlsx");
            //Sheet定義
            var sheet = new ArGridSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "Sheet1";
            //sheet.IsLandscape = true;

            //サブ帳票
            var engine = new ArSmartListEngine();
            sheet.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();

            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 1;
            templateInfo.DetailRowCount = 7;
            templateInfo.DetailMaxRows = 6;
            templateInfo.EndRowIndex = 42;
            //★列設定
            templateInfo.DetailStartColumnIndex = 1;//開始列
            templateInfo.DetailColumnCount = 4;
            templateInfo.DetailMaxColumns = 2;

            //検索条件
            var condition = GetCondition();

            //件数制限
            condition.LimitData = 1;

            //テスト実行
            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
            //Common.Test(rpt, rptDef, db, condition);
        }
        [TestMethod]
        public void Test一覧表()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("乳がん・甲状腺検診結果一覧.xlsx");

            //Sheet定義
            var sheet = new ArListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = ArNpoiHelper.GetSheetName(rptDef.TemplateFullPath);
            sheet.IsLandscape = true;

            //サブ帳票
            var engine = new ArSmartListEngine();
            sheet.Engine = engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();

            //変換
            //var transformer = new ArListTransformer();
            //subrpt.Transformer = transformer;

            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 8;
            templateInfo.DetailRowCount = 2;
            templateInfo.EndRowIndex = 10;

            //検索条件
            var condition = GetCondition();

            //テスト実行
            Common.Test(rptDef, db, condition);
        }

        [TestMethod]
        public void Test明細あり台帳()
        {
            //初期設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("乳がん・甲状腺検診結果名簿.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "乳がん・甲状腺検診結果名簿";
            sheet.IsLandscape = true;

            //サブ帳票
            var engine = new ArSmartListEngine();
            sheet.Engine=engine;
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems();
            engine.ConditionDic = GetConditionDef();

            //テンプレート設定情報
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

        [TestMethod]
        public void Test台帳()
        {
            //初期設定
            //ArGlobal.TempPath = @"C:\Temp";

            //DB設定
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();
            rptDef.TemplateFullPath = Common.GetTemplatePath("乳がん・甲状腺検診結果台帳.xlsx");

            //Sheet定義
            var sheet = new ArPageSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "乳がん・甲状腺検診結果名簿";
            //sheet.EndRowIndex = 38;

            //サブ帳票
            var engine = new ArSmartListEngine();
            sheet.Engine=engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            int test = Math.Abs(new Random().Next()) % 6 ;
            engine.ItemDefs = GetTestItems(test);
            engine.ConditionDic = GetConditionDef();

            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 8;
            templateInfo.DetailRowCount = 2;
            templateInfo.EndRowIndex = 38;

            //検索条件
            var condition = GetCondition();

            //テスト実行
            Common.Test(rptDef, db, condition);
        }


        private List<ArItemDef> GetTestItems(int testType)
        {
            var items = new List<ArItemDef>();
            //testType = 1;
            //**年度										
            switch (testType)
            {
                case 1:
                    //バーコードNW７
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", SqlColumn = "年度",
                        FormatKbn = ArEnumFormat.BarCode, Left = 100, Top = 20, Height = 20, Width = 100 }) ;
                    break;

                case 2:
                    //バーコード住所
                    items.Add(new ArItemDef() {Seq = 1, ItemID = "T_3", SqlColumn = "年度" });
                    break;

                case 3:
                    //バーコード住所
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", SqlColumn = "年度",  
                        FormatKbn = ArEnumFormat.QRCode , Width =20, Height=20});
                    break;

                case 4:
                    items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", SqlColumn = "年度"  });
                    break;

                case 5:
                    items.Add(new ArItemDef() {Seq = 1, ItemID = "T_3", SqlColumn = "年度" });
                    break;

                default:
                    items.Add(new ArItemDef() {Seq = 1, ItemID = "T_3", SqlColumn = "年度" });
                    break;
            }
            //**実施日
            items.Add(new ArItemDef() { Seq = 2, ItemID = "F1_1", SqlColumn = "実施日", BlankValue=DateTime.Today.ToString() });
            //**処理日
            //**受診番号 
            items.Add(new ArItemDef() { Seq = 4, ItemID = "F2_1", SqlColumn = "受診番号",  });
            //**氏名 
            items.Add(new ArItemDef() { Seq = 5, ItemID = "V1_1", SqlColumn = "氏名",  });
            //**生年月日
            items.Add(new ArItemDef() {Seq = 6, ItemID = "V1_2", SqlColumn = "生年月日" });
            //**性別
            items.Add(new ArItemDef() {Seq = 6, ItemID = "M1_2", SqlColumn = "性別" });

            return items;
        }
        private List<ArItemDef> GetItems()
        {
            var items = new List<ArItemDef>();
            //**宛名番号										
            items.Add(new ArItemDef() {Seq = 0, ItemID = "T_1", SqlColumn = "宛名番号" });
            //
            //**年度										
            items.Add(new ArItemDef() { Seq = 1, ItemID = "T_3", SqlColumn = "年度",  
                FormatKbn= ArEnumFormat.Year,
            });
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
            var relationDef = new ArRelationDef();
            relationDef.MainTableName = tt_shkensinDto.TABLE_NAME;
            relationDef.MainTableID = 検診_ID;
            relationDef.Condition = $"{nameof(tt_shkensinDto.jigyocd)} = '0001'";

            var tableRelations = relationDef.TableRelations;
            //V1 =tt_afatena(住民View） 
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 住民_ID,
                TableName = tt_afatenaDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_afatenaDto.atenano), "T", nameof(tt_shkensinDto.atenano))
                //}
            });

            //F1 = 実施日
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 実施日_ID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_ID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_ID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), "00001"),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "001")
                //}
            });

            //F2 = 受診番号
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 受診番号_ID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_ID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_ID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), "00001"),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "002")
                //}
            });

            //F3 = 医療機関
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 医療機関_ID,
                TableName = tt_shfreeDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tt_shfreeDto.atenano), 検診_ID, nameof(tt_shkensinDto.atenano)),
                //    new ArJoinItem(nameof(tt_shfreeDto.kensinkaisu), 検診_ID, nameof(tt_shkensinDto.kensinkaisu)),
                //    new ArJoinItem(nameof(tt_shfreeDto.jigyocd), "00001"),
                //    new ArJoinItem(nameof(tt_shfreeDto.itemcd), "003")
                //}
            });

            //M1 = tm_afmeisyo(名称マスタ-性別)
            tableRelations.Add(new ArTableRelationDef()
            {
                TableID = 性別_ID,
                TableName = tm_afmeisyoDto.TABLE_NAME,
                //TableKeys = new List<ArJoinItem>() {
                //    new ArJoinItem(nameof(tm_afmeisyoDto.nmcd), 住民_ID, nameof(tt_afatenaDto.sex)),
                //    new ArJoinItem(nameof(tm_afmeisyoDto.nmmaincd), "0001"),
                //    new ArJoinItem(nameof(tm_afmeisyoDto.nmsubcd), 1),
                //}
            });

            return relationDef;
        }

        private Dictionary<string, ArConditionDef> GetConditionDef()
        {
            var dic = new Dictionary<string, ArConditionDef>();
            //検索条件
            var conditionDef1 = new ArConditionDef();
            conditionDef1.Name = CONDITION1_NAME;
            //test
            if (true)
            {
                conditionDef1.Sql = $"{検診_ID}.{nameof(tt_shkensinDto.nendo)} = @{nameof(tt_shkensinDto.nendo)}";
                conditionDef1.ParameterList.Add($"{nameof(tt_shkensinDto.nendo)}");
                conditionDef1.TableIDList.Add($"{検診_ID}");
            }
            else
            {
                conditionDef1.Sql = $"{住民_ID}.{nameof(tt_afatenaDto.simei)} = @{nameof(tt_afatenaDto.simei)}";
                conditionDef1.ParameterList.Add($"{nameof(tt_afatenaDto.simei)}");
                conditionDef1.TableIDList.Add($"{住民_ID}");
            }
            dic.Add(conditionDef1.Name, conditionDef1);

            //var conditionDef2 = new ArConditionDef();
            //conditionDef2.Name = "宛名番号";
            //conditionDef2.Sql = $"{住民_ID}.{nameof(tt_afatenaDto.atenano)} = @{nameof(tt_afatenaDto.atenano)}";
            //conditionDef2.ParameterList.Add($"{nameof(tt_afatenaDto.atenano)}");
            //conditionDef2.TableIDList.Add($"{住民_ID}");
            //engine.ConditionDic.Add(conditionDef2.Name, conditionDef2);

            return dic;
        }
        private ArConditionModel GetCondition()
        {
            //検索条件
            var condition = new ArConditionModel();
            //年度
            var condition1 = new ArConditionItem();
            condition.ConditionList.Add(condition1);
            condition1.Name = CONDITION1_NAME;
            //test
            if (true)
            {
                var para1 = new ArParameterModel(nameof(tt_shkensinDto.nendo), "2022");
                condition1.ParaList.Add(para1);
            }
            else
            {
                var para1 = new ArParameterModel(nameof(tt_afatenaDto.simei), "2022");
                condition1.ParaList.Add(para1);
            }

            //宛名番号
            //var condition2 = new ArConditionItem();
            //condition.ConditionList.Add(condition2);
            //condition2.Name = conditionDef2.Name;
            //var para2 = new ArParameterModel(nameof(tt_afatenaDto.atenano), 2);
            //condition2.ParaList.Add(para2);
            //condition.ConditionList.Add(condition2);

            return condition;
        }
    }
}