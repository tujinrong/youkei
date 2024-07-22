using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.Common.Model;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDefs;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.SS.Formula.Functions;

namespace EucReportTest
{
    [TestClass]
    public class Test集計帳票
    {
        [TestMethod]
        public void TestALL()
        {
            Test住民クロース集計表();
            Test住民年齢別集計表();
            Test年齢別件数表();
            Test年齢別件数表2();
            Test一般集計台帳();
        }
        [TestMethod]

        public void Test一般集計台帳()
        {
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            rptDef.TemplateFullPath = Common.GetTemplatePath(@"集計帳票Templates\一般集計台帳.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "件数表";

            //サブ帳票
            var engine = new ArSmartGroupEngine();

            sheet.Engine = engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems5();
            engine.ConditionDic = GetConditionDef();
            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 4;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailMaxRows = 35;
            templateInfo.EndRowIndex = 40;
            //検索条件
            var condition = GetCondition();

            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV作成
            condition.CsvOption.OutputHeader = true;
            var csvresultc = AiReport.GetCSV(db.Session, rptDef, condition);
            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }


        private List<ArItemDef> GetItems5()
        {
            var items = new List<ArItemDef>();
            //**年齢									
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_1",
                SqlColumn = "年齢",
                GroupType = EnumGroupItemType.RowGroup
            });

            //**性別
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_2",
                ItemName = "性別",
                SqlColumn = "sex",
                GroupType = EnumGroupItemType.RowGroup,
            });

            //**件数
            items.Add(new ArItemDef()
            {
                Seq = 6,
                ItemID = "T_99",
                ItemName = "件数",
                SqlColumn = "Count(*)",
                GroupType = EnumGroupItemType.Totaling
            });
            return items;
        }



        [TestMethod]
        public void Test住民クロース集計表()
        {
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            rptDef.TemplateFullPath = Common.GetTemplatePath(@"集計帳票Templates\住民クロース集計表.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "件数表";
            sheet.IsLandscape = true;

            //Zero表示
            sheet.IsNullToZero = true;

            //帳票エンジン
            var engine = new ArSmartGroupEngine();
            sheet.Engine = engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems4();
            engine.ConditionDic = GetConditionDef();
            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 4;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailColumnCount = 1;
            templateInfo.DetailMaxRows = 34;
            templateInfo.EndRowIndex = 39;
            
            //検索条件
            var condition = GetCondition();

            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV作成
            condition.CsvOption.OutputHeader = true;
            // condition.AutoMerge = true;
            condition.CsvOption.Quotation = ArEnumQuotation.Double;
            var csvresultc = AiReport.GetCSV(db.Session, rptDef, condition);

            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }

        private List<ArItemDef> GetItems4()
        {
            var items = new List<ArItemDef>();
            //**住民種別								
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_1",
                ItemName = "住民種別",
                SqlColumn = nameof(tt_afatenaDto.juminsyubetu),
                GroupType = EnumGroupItemType.RowGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 1,
                    Values = { "1", "2", ArConst.SUM, ArConst.TOTAL },
                    Captions = { "日本人", "外国人", "小計", "総合計" }
                }
            });

            //**住民状態								
            items.Add(new ArItemDef()
            {
                Seq = 2,
                ItemID = "T_2",
                ItemName = "住民状態",
                SqlColumn = nameof(tt_afatenaDto.juminjotai),
                GroupType = EnumGroupItemType.RowGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 0,
                    Values = { "1", "2","3","9", ArConst.SUM },
                    Captions = { "住登者", "転出者", "死亡者", "その他", "計" }
                }
            });

            //**性別
            items.Add(new ArItemDef()
            {
                Seq = 3,
                ItemID = "T_3",
                ItemName = "性別",
                SqlColumn = nameof(tt_afatenaDto.sex),
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 0,
                    Values = { "1", "2", "0", ArConst.SUM },
                    Captions = { "男", "女", "不明", "計" }
                }
            });

            //**住登区分
            items.Add(new ArItemDef()
            {
                Seq = 4,
                ItemID = "T_4",
                ItemName = "住登区分",
                SqlColumn = nameof(tt_afatenaDto.jutokbn),
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 1,
                    Values = { "1", "2", ArConst.SUM, ArConst.TOTAL },
                    Captions = { "住民", "住登外", "小計", "合計" }
                }
            });

            //**件数
            items.Add(new ArItemDef()
            {
                Seq = 6,
                ItemID = "T_99",
                ItemName = "件数",
                SqlColumn= "Count(*)",
                FormatKbn = ArEnumFormat.Number,
                GroupType = EnumGroupItemType.Totaling
            });
            return items;
        }


        [TestMethod]
        public void Test住民年齢別集計表()
        {
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            rptDef.TemplateFullPath = Common.GetTemplatePath(@"集計帳票Templates\住民年齢別集計表.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "件数表";

            //Zero表示
            sheet.IsNullToZero = true;

            //帳票エンジン
            var engine = new ArSmartGroupEngine();
            sheet.Engine = engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems3();
            engine.ConditionDic = GetConditionDef();
            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 4;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailColumnCount = 1;
            templateInfo.DetailMaxRows = 34;
            templateInfo.EndRowIndex = 39;
            //検索条件
            var condition = GetCondition();

            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV作成
            condition.CsvOption.OutputHeader = true;
            condition.CsvOption.Quotation = ArEnumQuotation.Double;
            var csvresultc = AiReport.GetCSV(db.Session, rptDef, condition);

            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }

        private List<ArItemDef> GetItems3()
        {
            var items = new List<ArItemDef>();
            //**年齢									
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_1",
                ItemName = "年齢",
                SqlColumn = "euc_af_getage(T.bymd, NULL)",
                GroupType = EnumGroupItemType.RowGroup,
                
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 0,
                    Values = GetAgeList(),
                    Captions = GetAgeCaptionList()
                }
            });

            //**性別
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_2",
                ItemName = "性別",
                SqlColumn = nameof(tt_afatenaDto.sex),
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 0,
                    Values = {"1", "2", ArConst.SUM},
                    Captions = {"男", "女", "計" }
                }
            });

            //**住登区分
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_3",
                ItemName = "住登区分",
                SqlColumn= nameof(tt_afatenaDto.jutokbn),
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef()
                {
                    Level = 1,
                    Values = { "1", "2", ArConst.SUM, ArConst.TOTAL},
                    Captions = { "住民", "住登外", "小計",　"合計"}
                }
            });

            //**件数
            items.Add(new ArItemDef()
            {
                Seq = 6,
                ItemID = "T_99",
                ItemName = "件数",
                SqlColumn = "Count(*)",
                FormatKbn = ArEnumFormat.Number,
                GroupType = EnumGroupItemType.Totaling
            });
            return items;
        }

        [TestMethod]

        public void Test年齢別件数表()
        {

            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            rptDef.TemplateFullPath = Common.GetTemplatePath(@"集計帳票Templates\年齢別件数表.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "件数表";

            //Zero表示
            sheet.IsNullToZero = true;

            //帳票エンジン
            var engine = new ArSmartGroupEngine();
            sheet.Engine = engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems2();
            engine.ConditionDic = GetConditionDef();
            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 5;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailMaxRows = 35;
            templateInfo.EndRowIndex = 40;
            //検索条件
            var condition = GetCondition();

            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV作成
            condition.CsvOption.OutputHeader = true;
            condition.CsvOption.Quotation = ArEnumQuotation.Double;
            var csvresultc = AiReport.GetCSV(db.Session, rptDef, condition);
            
            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }


        [TestMethod]

        public void Test年齢別件数表2()
        {
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            rptDef.TemplateFullPath = Common.GetTemplatePath(@"集計帳票Templates\年齢別件数表2.xlsx");

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "件数表";

            //サブ帳票
            var engine = new ArSmartGroupEngine();
           
            sheet.Engine=engine;

            //データエンジン
            engine.RelationDef = GetRelation();
            engine.ItemDefs = GetItems1();
            engine.ConditionDic = GetConditionDef();
            //テンプレート設定情報
            var templateInfo = new ArTemplateDef();
            engine.TemplateInfo = templateInfo;
            templateInfo.DetailStartRowIndex = 4;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailMaxRows= 35;
            templateInfo.EndRowIndex = 40;
            //検索条件
            var condition = GetCondition();

            var sql = AiReport.GetSql(rptDef, condition);
            //データの取得
            var result = AiReport.GetDataTable(db.Session, rptDef, condition);
            //CSV作成
            condition.CsvOption.OutputHeader = true;
            var csvresultc = AiReport.GetCSV(db.Session, rptDef, condition);
            //PDF作成
            condition.OutputType = ArEnumOutputType.Pdf;
            var resultPdf = AiReport.MakeReport(db.Session, rptDef, condition);
        }


        private List<ArItemDef> GetItems1()
        {
            var items = new List<ArItemDef>();
            //**年齢									
            items.Add(new ArItemDef() { Seq = 1, ItemID = "T_1", ItemName = "年齢",
                SqlColumn = "euc_af_getage(T.bymd, NULL)", 
                GroupType= EnumGroupItemType.RowGroup });

            //**性別
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_2",
                ItemName = "性別",
                SqlColumn = "sex",
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef() { 
                    Values = new List<string>() { "1", "2", "0" } ,
                    Captions = { "男", "女", "不明" }
            }
            });

            //**件数
            items.Add(new ArItemDef() { Seq = 6, ItemID = "T_99", ItemName = "件数", SqlColumn= "Count(*)", 
                 GroupType= EnumGroupItemType.Totaling});
            return items;
        }

        private List<ArItemDef> GetItems2()
        {
            var items = new List<ArItemDef>();
            //**年齢									
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_1",
                ItemName = "年齢",
                SqlColumn= "euc_af_getage(T.bymd, NULL)",
                GroupType = EnumGroupItemType.RowGroup,
                ItemGroupDef = new ArFixItemGroupDef() { 
                    Values = GetAgeList() , 
                    Captions=GetAgeCaptionList()}
            });

            //**性別
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_2",
                ItemName = "性別",
                SqlColumn= "T.sex",
                GroupType = EnumGroupItemType.ColumnGroup,
                ItemGroupDef = new ArFixItemGroupDef() { 
                    Values = { ArConst.SUM, "1", "2", "0" }, 
                    Captions = { "計", "男", "女", "不明" } }
            });

            //**件数
            items.Add(new ArItemDef()
            {
                Seq = 6,
                ItemID = "T_99",
                ItemName = "件数",
                SqlColumn= "Count(*)",
                GroupType = EnumGroupItemType.Totaling
            });
            return items;
        }
        private ArRelationDef GetRelation()
        {
            var relationDef = new ArRelationDef();
            relationDef.MainTableName = tt_afatenaDto.TABLE_NAME;
            relationDef.MainTableID = "T";
            return relationDef;
        }

        private Dictionary<string, ArConditionDef> GetConditionDef()
        {
            var dic = new Dictionary<string, ArConditionDef>();
            //検索条件
            var conditionDef1 = new ArConditionDef();
            conditionDef1.Name = "氏名";
            conditionDef1.Sql = $"T.{nameof(tt_afatenaDto.simei)} LIKE @{nameof(tt_afatenaDto.simei)}";
            conditionDef1.ParameterList.Add($"{nameof(tt_afatenaDto.simei)}");
            conditionDef1.TableIDList.Add($"T");
            dic.Add(conditionDef1.Name, conditionDef1);

            return dic;
        }
        private ArConditionModel GetCondition()
        {
            //検索条件
            var condition = new ArConditionModel();

            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票名] = "帳票名";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザー名] = "";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.公印] = new byte[0];
            //condition.SpecialItemDic[ArEnumSpecialInputItem.代表者名] = "代表者名";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.問い合わせ先] = "問い合わせ先\n電話番号";
            //condition.SpecialItemDic[ArEnumSpecialInputItem.ユーザーID] = 1;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.基準日] = DateTime.Today;
            //condition.SpecialItemDic[ArEnumSpecialInputItem.帳票グループID] = 1;

            //年度
            var condition1 = new ArConditionItem();
            //condition.ConditionList.Add(condition1);
            condition1.Name = "氏名";
            var para1 = new ArParameterModel(nameof(tt_afatenaDto.simei), "%1%");
            condition1.ParaList.Add(para1);
            return condition;
        }

        private List<string> GetAgeList()
        {
            var list=new List<string>();
            for (int i=-1;i<100;i++)
            {
                list.Add(i.ToString());
            }
            return list;
        }
        private List<string> GetAgeCaptionList()
        {
            var list = new List<string>();
            list.Add("不明");
            for (int i = 0; i < 100; i++)
            {
                list.Add(i.ToString()+"才");
            }
            return list;
        }
    }
}