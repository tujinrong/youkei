using AIplus.AiReport.Common;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef.SheetDefs;
using AIplus.AiReport.ReportDef;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NPOI.POIFS.Crypt;

namespace EucReportTest
{
    [TestClass]
    public partial class TestVBReport
    {
        // 0028_0001_事業実施報告書（日報）のキー
        const string CONDITION_JIGYOCD_0028 = "事業コード";
        const string CONDITION_JISSIYMD_0028 = "実施日";
        const string CONDITION_KAIJOCD_0028 = "会場コード";
        const string CONDITION_STAFFID_0028 = "事業従事者ID";
        const string CONDITION_HOKOKUSYONO_0028 = "事業報告書番号";
        const string CONDITION_CREATEDATE_0028 = "作成日_和暦";
        // 0001_国民健康保険情報一覧表のキー
        const string CONDITION_SIKAKUKBN_0001 = "国保資格区分";
        const string CONDITION_SIKAKUSYUTOKUYMD_0001 = "国保資格取得年月日";
        const string CONDITION_SIKAKUSOSITUYMD_0001 = "国保資格喪失年月日";
        const string CONDITION_TEKIYOYMDF_0001 = "国保適用開始年月日";
        const string CONDITION_TEKIYOYMDT_0001 = "国保適用終了年月日";
        const string CONDITION_SAISINFLG_0001 = "最新フラグ";
        const string CONDITION_JIGYOCD_0001 = "個人連絡先利用事業";
        const string CONDITION_RIYOMOKUTEKI_0001 = "送付先利用目的";
        // 0009_事業従事者（担当者）一覧表のキー
        const string CONDITION_STAFFID_0009 = "事業従事者ID";
        const string CONDITION_STAFFSIMEI_0009 = "事業従事者氏名";
        const string CONDITION_KANASTAFFSIMEI_0009 = "事業従事者カナ氏名";
        const string CONDITION_SYOKUSYU_0009 = "職種";
        const string CONDITION_KATUDOKBN_0009 = "活動区分";
        const string CONDITION_KIKANCD_0009 = "医療機関コード（自治体独自）";
        const string CONDITION_JISSIJIGYO_0009 = "実施事業";
        const string CONDITION_STOPFLG_0009 = "利用停止";
        // 0023_0001_教育申込通知書のキー
        const string CONDITION_GYOMUKBN_0023 = "業務区分";
        const string CONDITION_JIGYOCD_0023 = "その他日程事業・保健指導事業コード";
        const string CONDITION_YOTEIYMD_0023 = "実施予定日";
        const string CONDITION_YOTEITM_0023 = "予定開始時間";
        const string CONDITION_KAIJOCD_0023 = "会場コード";
        const string CONDITION_SYUKKETUKBN_0023 = "出欠区分";

        [TestMethod]
        public void Test宛名ワークテーブルにデータ登録()
        {
            // ダミーデータ
            //string Test_tokenID = "AIPlus_0123456789";
            //string Test_rptID = "0001";

            string Test_tokenID = "AIPlus_0123456789";
            string Test_rptID = "0018";
            string Test_yosikiID = "0001";  //★新規追加パラメータ

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //業務区分（名称マスタ1001-101） tt_kksyudansido_mosikomi.gyomukbn
            searchDic.Add(CONDITION_GYOMUKBN_0018, "01");
            //その他日程事業・保健指導事業コード(汎用マスタ3019-100008) tt_kksyudansido_mosikomi.jigyocd
            searchDic.Add(CONDITION_JIGYOCD_0018, "010");
            //実施予定日 tt_kksyudansido_mosikomi.yoteiymd
            searchDic.Add(CONDITION_YOTEIYMD_0018, new ArPair("2020-01-01", "2025-12-31"));
            //予定開始時間 tt_kksyudansido_mosikomi.yoteitm
            searchDic.Add(CONDITION_YOTEITM_0018, new ArPair("0000", "2359"));
            //会場コード tt_kksyudansido_mosikomi.kaijocd
            searchDic.Add(CONDITION_KAIJOCD_0018, "V%");
            //出欠区分(名称マスタ2019-21) tt_kksyudansido_sankasya.syukketukbn
            searchDic.Add(CONDITION_SYUKKETUKBN_0018, "1");
            //住民区分(名称マスタ1000-41) tt_afatena.juminkbn
            searchDic.Add(CONDITION_JUMINKBN_0018, new string[] { "0", "1" });

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeWorkTable(db, Test_tokenID, Test_rptID, Test_yosikiID, searchDic, detailSearchDic, orderByList);
        }

        [TestMethod]
        public void Testワークシーケンス取得()
        {
            // ダミーデータ
            string Test_tokenID = "AIPlus_0123456789";

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
        }

        [TestMethod]
        public void Test国民健康保険情報一覧表()
        {
            // ダミーデータ
            // string Test_tokenID = "1RHGwm8ssoxxYjAFI5Fb/A=="; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0001";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test国民健康保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //// 国保資格区分 (名称マスタ:tm_afmeisyo 2024-1) tt_afkokuho_reki.kokuho_sikakukbn
            //searchDic.Add(CONDITION_SIKAKUKBN_0001, "1");
            //// 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            //searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair(null, "2024-12-11"));
            //// 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            //searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            //searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            //searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afkokuho_reki.saisinflg
            searchDic.Add(CONDITION_SAISINFLG_0001, true);
            //// 個人連絡先利用事業コード (汎用マスタ3019-4) tt_afrenrakusaki.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0001, "17");
            //// 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            ////searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, true, false, false);
        }

        [TestMethod]
        public void Test国民健康保険情報一覧表EXCEL()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "73"; //★新規追加
            string Test_rptID = "0001";
            string Test_yosikiID = "0001";
            string Test_memo = "TestEXCEL";//★新規追加
            string Test_sessionseq = "85711";//★新規追加 必須項目
            string Test_userid = "1";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.EXCEL;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //// 国保資格区分 (名称マスタ:tm_afmeisyo 2024-1) tt_afkokuho_reki.kokuho_sikakukbn
            //searchDic.Add(CONDITION_SIKAKUKBN_0001, "1");
            //// 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            //searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair(null, "2024-12-11"));
            //// 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            //searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            //searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            //searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afkokuho_reki.saisinflg
            searchDic.Add(CONDITION_SAISINFLG_0001, true);
            //// 個人連絡先利用事業コード (汎用マスタ3019-4) tt_afrenrakusaki.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0001, "17");
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, true, true, false, false);
        }

        [TestMethod]
        public void Test国民健康保険情報一覧表PDF()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "20"; //★新規追加
            string Test_rptID = "0023";
            string Test_yosikiID = "0001";
            string Test_memo = "TestPDF";//★新規追加
            string Test_sessionseq = "51080";//★新規追加 必須項目
            string Test_userid = "1";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //// 国保資格区分 (名称マスタ:tm_afmeisyo 2024-1) tt_afkokuho_reki.kokuho_sikakukbn
            //searchDic.Add(CONDITION_SIKAKUKBN_0001, "1");
            //// 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            //searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair(null, "2024-12-11"));
            //// 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            //searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            //searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            //searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 最新フラグ tt_afkokuho_reki.saisinflg
            //searchDic.Add(CONDITION_SAISINFLG_0001, true);
            //// 個人連絡先利用事業コード (汎用マスタ3019-4) tt_afrenrakusaki.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0001, "17");
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, true, true, false);
        }

        [TestMethod]
        public void Test教育申込通知書_T()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0023";
            string Test_yosikiID = "0001";
            string Test_memo = "Test教育申込通知書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //業務区分（名称マスタ1001-101） tt_kksyudansido_mosikomi.gyomukbn
            searchDic.Add(CONDITION_GYOMUKBN_0023, "01");
            //その他日程事業・保健指導事業コード(その他日程事業・保健指導事業マスタ) tt_kksyudansido_mosikomi.jigyocd
            searchDic.Add(CONDITION_JIGYOCD_0023, "010");
            //実施予定日 tt_kksyudansido_mosikomi.yoteiymd
            searchDic.Add(CONDITION_YOTEIYMD_0023, new ArPair("2020-01-01", "2025-12-31"));
            //予定開始時間 tt_kksyudansido_mosikomi.yoteitm
            searchDic.Add(CONDITION_YOTEITM_0023, new ArPair("0000", "2459"));
            //会場コード tt_kksyudansido_mosikomi.kaijocd
            searchDic.Add(CONDITION_KAIJOCD_0023, "1");
            //出欠区分(名称マスタ2019-21) tt_kksyudansido_sankasya.syukketukbn
            searchDic.Add(CONDITION_SYUKKETUKBN_0023, "1");


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }



        [TestMethod]
        public void Test事業実施報告書()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0028";
            string Test_yosikiID = "0001";
            string Test_memo = "Test事業実施報告書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // tt_kkjissihokokusyo.jissiymd 実施日（範囲指定）
            searchDic.Add(CONDITION_JISSIYMD_0028, new ArPair("2023-12-09", "2023-12-12"));
            // tt_kkjissihokokusyo.jigyocd tm_afhanyo(3019-100004) 事業コード
            searchDic.Add(CONDITION_JIGYOCD_0028, new string[] { "17", "177", "178" });
            // tt_kkjissihokokusyo.kaijocd 会場コード
            searchDic.Add(CONDITION_KAIJOCD_0028, "567");
            // tt_kkjissihokokusyo_sub.staffid 事業従事者（担当者）情報マスタの事業従事者ID ★廃止された
            //searchDic.Add(CONDITION_STAFFID_0028, "0000000001");
            // tt_kkjissihokokusyo.hokokusyono 事業報告書番号
            searchDic.Add(CONDITION_HOKOKUSYONO_0028, 1008);
            // 作成日：和暦　★必須ではない
            searchDic.Add(CONDITION_CREATEDATE_0028, "令和06年02月13日");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();
            ////住民状態 
            //detailSearchDic.Add(nameof(tt_afatenaDto.juminjotai), new string[] { "1", "0", "2" });
            ////住登区分
            //detailSearchDic.Add(nameof(tt_afatenaDto.jutokbn), new string[] { "0", "1", "2" });
            ////住民種別
            //detailSearchDic.Add(nameof(tt_afatenaDto.juminsyubetu), new string[] { "11", "22", "33" });
            ////性別
            //detailSearchDic.Add(nameof(tt_afatenaDto.sex), new string[] { "1", "0", "2" });
            ////年齢
            //DaAgeFilter mDaAgeFilter = new DaAgeFilter();
            //mDaAgeFilter.kijunymd = DateTime.Now;
            //mDaAgeFilter.Female = new int[] { 21, 30, 42 };
            //mDaAgeFilter.Male = new int[] { 18, 20, 32 };
            //mDaAgeFilter.Other = new int[] { 30, 41, 52 };
            //detailSearchDic.Add("age", mDaAgeFilter);
            ////生年月日
            //DaBirthdayFilter mDaBirthdayFilter = new DaBirthdayFilter();
            //DaBirthdayModel mDaBirthdayModel = new DaBirthdayModel();
            //mDaBirthdayModel.DateTo = DateTime.Now;
            //mDaBirthdayModel.UnknownY = true;
            //mDaBirthdayModel.UnknownM = true;
            //mDaBirthdayModel.UnknownD = true;
            //mDaBirthdayFilter.Both = mDaBirthdayModel;
            //mDaBirthdayFilter.Female = mDaBirthdayModel;
            //detailSearchDic.Add(nameof(tt_afatenaDto.bymd), mDaBirthdayFilter);
            ////氏名
            //detailSearchDic.Add(nameof(tt_afatenaDto.simei), "日本太郎");
            ////住所（都道府県)
            //detailSearchDic.Add(nameof(tt_afatenaDto.adrs_sikucd), "東京都");
            ////住所（町字）
            //detailSearchDic.Add(nameof(tt_afatenaDto.adrs_tyoazacd), "千代田");
            ////行政区
            //detailSearchDic.Add(nameof(tt_afatenaDto.gyoseikucd), new string[] { "01", "02", "03" });
            ////地区管理コード1～10
            //detailSearchDic.Add(nameof(tt_afatenaDto.tikukanricd1), new string[] { "01", "02", "03", "04", "05", "06" });

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, true, false);
        }


        [TestMethod]
        public void Test事業実施報告書_EXCEL()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0028";
            string Test_yosikiID = "0001";
            string Test_memo = "Test事業実施報告書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.EXCEL;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // tt_kkjissihokokusyo.jissiymd 実施日（範囲指定）
            searchDic.Add(CONDITION_JISSIYMD_0028, new ArPair("2023-12-09", "2023-12-12"));
            // tt_kkjissihokokusyo.jigyocd tm_afhanyo(3019-100004) 事業コード
            searchDic.Add(CONDITION_JIGYOCD_0028, new string[] { "17", "177", "178" });
            // tt_kkjissihokokusyo.kaijocd 会場コード
            searchDic.Add(CONDITION_KAIJOCD_0028, "567");
            // tt_kkjissihokokusyo_sub.staffid 事業従事者（担当者）情報マスタの事業従事者ID ★廃止された
            //searchDic.Add(CONDITION_STAFFID_0028, "0000000001");
            // tt_kkjissihokokusyo.hokokusyono 事業報告書番号
            searchDic.Add(CONDITION_HOKOKUSYONO_0028, 1008);
            // 作成日：和暦　★必須ではない
            searchDic.Add(CONDITION_CREATEDATE_0028, "令和06年02月13日");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();
            ////住民状態 
            //detailSearchDic.Add(nameof(tt_afatenaDto.juminjotai), new string[] { "1", "0", "2" });
            ////住登区分
            //detailSearchDic.Add(nameof(tt_afatenaDto.jutokbn), new string[] { "0", "1", "2" });
            ////住民種別
            //detailSearchDic.Add(nameof(tt_afatenaDto.juminsyubetu), new string[] { "11", "22", "33" });
            ////性別
            //detailSearchDic.Add(nameof(tt_afatenaDto.sex), new string[] { "1", "0", "2" });
            ////年齢
            //DaAgeFilter mDaAgeFilter = new DaAgeFilter();
            //mDaAgeFilter.kijunymd = DateTime.Now;
            //mDaAgeFilter.Female = new int[] { 21, 30, 42 };
            //mDaAgeFilter.Male = new int[] { 18, 20, 32 };
            //mDaAgeFilter.Other = new int[] { 30, 41, 52 };
            //detailSearchDic.Add("age", mDaAgeFilter);
            ////生年月日
            //DaBirthdayFilter mDaBirthdayFilter = new DaBirthdayFilter();
            //DaBirthdayModel mDaBirthdayModel = new DaBirthdayModel();
            //mDaBirthdayModel.DateTo = DateTime.Now;
            //mDaBirthdayModel.UnknownY = true;
            //mDaBirthdayModel.UnknownM = true;
            //mDaBirthdayModel.UnknownD = true;
            //mDaBirthdayFilter.Both = mDaBirthdayModel;
            //mDaBirthdayFilter.Female = mDaBirthdayModel;
            //detailSearchDic.Add(nameof(tt_afatenaDto.bymd), mDaBirthdayFilter);
            ////氏名
            //detailSearchDic.Add(nameof(tt_afatenaDto.simei), "日本太郎");
            ////住所（都道府県)
            //detailSearchDic.Add(nameof(tt_afatenaDto.adrs_sikucd), "東京都");
            ////住所（町字）
            //detailSearchDic.Add(nameof(tt_afatenaDto.adrs_tyoazacd), "千代田");
            ////行政区
            //detailSearchDic.Add(nameof(tt_afatenaDto.gyoseikucd), new string[] { "01", "02", "03" });
            ////地区管理コード1～10
            //detailSearchDic.Add(nameof(tt_afatenaDto.tikukanricd1), new string[] { "01", "02", "03", "04", "05", "06" });

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, true, false);
        }

        [TestMethod]
        public void TestアドレスシールEXCEL()
        {
            // ダミーデータ
            string Test_workSeq = "42";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.Cアドレスシール;
            string Test_memo = "Testアドレスシール";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.EXCEL;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Testアドレスシール()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.Cアドレスシール;
            string Test_memo = "Testアドレスシール";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Testバーコード()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.Cバーコード;
            string Test_memo = "Testバーコード";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            //string Test_paramerIn = "'1', '2', '3'";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, true, false, false);
        }

        [TestMethod]
        public void Testはがき()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.Cはがき;
            string Test_memo = "Testはがき";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, true, false, false);
        }

        [TestMethod]
        public void Test宛名台帳()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.C宛名台帳;
            string Test_memo = "Test宛名台帳";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Test件数表年齢()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.C件数表年齢;
            string Test_memo = "Test件数表年齢";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Test件数表行政区()
        {
            // ダミーデータ
            string Test_workSeq = "1";
            string Test_rptID = ""; //スペシャル帳票場合、レポートID指定が無し
            string Test_yosikiID = DaEucService.C件数表行政区;
            string Test_memo = "Test件数表行政区";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Test事業従事者一覧表()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "20"; //★新規追加
            string Test_rptID = "0009";
            string Test_yosikiID = "0001";
            string Test_memo = "Test事業従事者一覧表";//★新規追加
            string Test_sessionseq = "38747";//★新規追加 必須項目
            string Test_userid = "1";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.EXCEL;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 事業従事者ID tm_afstaff.staffid
            searchDic.Add(CONDITION_STAFFID_0009, "0000000002");
            // 事業従事者氏名 tm_afstaff.staffsimei
            searchDic.Add(CONDITION_STAFFSIMEI_0009, "岡田雄介");
            // 事業従事者カナ氏名 tm_afstaff.kanastaffsimei
            searchDic.Add(CONDITION_KANASTAFFSIMEI_0009, "オカダ");
            // 職種(名称ﾏｽﾀ2019-2) tm_afstaff.syokusyu
            searchDic.Add(CONDITION_SYOKUSYU_0009, "02");
            // 活動区分(名称ﾏｽﾀ2019-3) tm_afstaff.katudokbn
            searchDic.Add(CONDITION_KATUDOKBN_0009, "2");
            // 医療機関コード（自治体独自） tm_afkikan.kikancd
            searchDic.Add(CONDITION_KIKANCD_0009, "0001");
            // 実施事業(名称ﾏｽﾀ1000-43) tm_afstaff_sub.jissijigyo
            searchDic.Add(CONDITION_JISSIJIGYO_0009, "10");
            // 利用停止 tm_afstaff.stopflg
            searchDic.Add(CONDITION_STOPFLG_0009, false);


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }


        [TestMethod]
        public void Test可変長帳票()
        {
            using DaDbContext db = new DaDbContext();

            //帳票定義
            var rptDef = new ArSheetDef();

            var fileName = Path.Combine(Path.Combine(Environment.CurrentDirectory, "App_Data"), @"Test\その他Templates\可変長集計表.xlsx");
            rptDef.TemplateFullPath = fileName;

            //Sheet定義
            var sheet = new ArPageListSheetDef();
            rptDef.SubSheetDefs.Add(sheet);
            sheet.Name = "可変長集計表";

            //Zero表示
            sheet.IsNullToZero = true;
            sheet.IsMain = true;
            sheet.IsMergeCell = true;

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
            templateInfo.DetailStartRowIndex = 2;
            templateInfo.DetailRowCount = 1;
            templateInfo.DetailColumnCount = 1;
            templateInfo.DetailMaxRows = 34;
            templateInfo.EndRowIndex = 39;
            //検索条件
            var condition = GetCondition();
            condition.CrossOption.AutoCross = true;
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
                    Level = 1,
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
                    Level = 2,
                    Values = { "1", "2", "0", ArConst.SUM },
                    Captions = { "男", "女", "不明", "小計" }
                }
            });

            //**住登区分
            items.Add(new ArItemDef()
            {
                Seq = 1,
                ItemID = "T_3",
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
                SqlColumn = "Count(*)",
                FormatKbn = ArEnumFormat.Number,
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
            return dic;
        }
        private ArConditionModel GetCondition()
        {
            //検索条件
            var condition = new ArConditionModel();
            return condition;
        }

        private List<string> GetAgeList()
        {
            var list = new List<string>();
            for (int i = -1; i < 100; i++)
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
                list.Add(i.ToString() + "才");
            }
            return list;
        }

        // 0003_生活保護情報一覧表のキー
        const string CONDITION_SEIHOYMDF_0003 = "生活保護開始年月日";
        const string CONDITION_TEISIYMD_0003 = "停止年月日";
        const string CONDITION_TEISIKAIJOYMD_0003 = "停止解除年月日";
        const string CONDITION_TANHEIKYUKBN_0003 = "単併給区分";
        const string CONDITION_SEIKATUFUJOFLG_0003 = "生活扶助フラグ";
        const string CONDITION_JUTAKUFUJOFLG_0003 = "住宅扶助フラグ";
        const string CONDITION_KYOIKUFUJOFLG_0003 = "教育扶助フラグ";
        const string CONDITION_IRYOFUJOFLG_0003 = "医療扶助フラグ";
        const string CONDITION_SYUSSANFUJOFLG_0003 = "出産扶助フラグ";
        const string CONDITION_SEIGYOFUJOFLG_0003 = "生業扶助フラグ";
        const string CONDITION_SOSAIFUJOFLG_0003 = "葬祭扶助フラグ";
        const string CONDITION_HAISIYMD_0003 = "廃止年月日";
        const string CONDITION_SAISINFLG_0003 = "最新フラグ";

        public string Testワークシーケンス取得Test()
        {
            // ダミーデータ
            string Test_tokenID = "1RHGwm8ssoxxYjAFI5Fb/A==";

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
            return workSeq.ToString();
        }


        [TestMethod]
        public void Test後期高齢者医療保険情Test()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = Testワークシーケンス取得Test(); //★新規追加
            string Test_rptID = "0003";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test後期高齢者医療保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 生活保護開始年月日 tt_afseiho_reki.seihoymdf
            searchDic.Add(CONDITION_SEIHOYMDF_0003, new ArPair("2010-12-10", "2024-12-11"));
            // 停止年月日 tt_afseiho_reki.teisiymd
            searchDic.Add(CONDITION_TEISIYMD_0003, new ArPair("2010-12-10", "2024-12-11"));
            // 停止解除年月日 tt_afseiho_reki.teisikaijoymd
            searchDic.Add(CONDITION_TEISIKAIJOYMD_0003, new ArPair("2010-12-10", "2024-12-11"));
            // 単併給区分(名称ﾏｽﾀ2021-19) tt_afseiho_reki.tanheikyukbn
            searchDic.Add(CONDITION_TANHEIKYUKBN_0003, "1");
            // 生活扶助フラグ(名称ﾏｽﾀ2021-19)tt_afseiho_reki.seikatufujoflg
            searchDic.Add(CONDITION_SEIKATUFUJOFLG_0003, true);
            // 住宅扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.jutakufujoflg
            searchDic.Add(CONDITION_JUTAKUFUJOFLG_0003, false);
            //教育扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.kyoikufujoflg
            searchDic.Add(CONDITION_KYOIKUFUJOFLG_0003, false);
            //医療扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.iryofujoflg
            searchDic.Add(CONDITION_IRYOFUJOFLG_0003, false);
            //出産扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.syussanfujoflg
            searchDic.Add(CONDITION_SYUSSANFUJOFLG_0003, false);
            //生業扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.seigyofujoflg
            searchDic.Add(CONDITION_SEIGYOFUJOFLG_0003, false);
            //葬祭扶助フラグ (名称ﾏｽﾀ2021-19)tt_afseiho_reki.sosaifujoflg
            searchDic.Add(CONDITION_SOSAIFUJOFLG_0003, false);
            //廃止年月日 tt_afseiho_reki.haisiymd
            searchDic.Add(CONDITION_HAISIYMD_0003, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afseiho_reki.saisinflg
            searchDic.Add(CONDITION_SAISINFLG_0003, true);
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        [TestMethod]
        public void Test国民健康保険情報一覧表2_Test()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0001";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test国民健康保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //// 国保資格区分 (名称マスタ:tm_afmeisyo 2024-1) tt_afkokuho_reki.kokuho_sikakukbn
            //searchDic.Add(CONDITION_SIKAKUKBN_0001, new string[] { "1", "2" });
            // 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair(null, null));
            //// 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            //searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            //searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            //searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            //// 最新フラグ tt_afkokuho_reki.saisinflg
            //searchDic.Add(CONDITION_SAISINFLG_0001, true);
            //// 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }


        // 0002_後期高齢者医療保険情報一覧表のキー
        const string CONDITION_HIHOKENSYANO_0002 = "被保険者番号";
        const string CONDITION_KOJINKBNCD_0002 = "個人区分";
        const string CONDITION_SIKAKUSYUTOKUJIYUCD_0002 = "被保険者資格取得事由";
        const string CONDITION_SIKAKUSYUTOKUYMD_0002 = "被保険者資格取得年月日";
        const string CONDITION_SIKAKUSOSITUJIYUCD_0002 = "被保険者資格喪失事由";
        const string CONDITION_SIKAKUSOSITUYMD_0002 = "被保険者資格喪失年月日";
        const string CONDITION_TEKIYOYMDF_0002 = "被保険者適用開始年月日";
        const string CONDITION_TEKIYOYMDT_0002 = "被保険者適用終了年月日";
        const string CONDITION_SAISINFLG_0002 = "最新フラグ";
        const string CONDITION_RIYOMOKUTEKI_0002 = "送付先利用目的";

        public string Testワークシーケンス取得2()
        {
            // ダミーデータ
            string Test_tokenID = "1RHGwm8ssoxxYjAFI5Fb/A==";

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
            return workSeq.ToString();
        }

        [TestMethod]
        public void Test後期高齢者医療保険情報一覧表_Test()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = Testワークシーケンス取得2(); //★新規追加
            string Test_rptID = "0002";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test後期高齢者医療保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 被保険者番号 tt_afkokihoken_reki.hihokensyano
            searchDic.Add(CONDITION_HIHOKENSYANO_0002, "KK%");
            // 個人区分（名称マスタ2025-1） tt_afkokihoken_reki.kojinkbncd
            //searchDic.Add(CONDITION_KOJINKBNCD_0002, "1");
            // 被保険者資格取得事由（称マスタ2025-11）tt_afkokihoken_reki.hiho_sikakusyutokujiyucd
            // searchDic.Add(CONDITION_SIKAKUSYUTOKUJIYUCD_0002, "001");
            // 被保険者資格取得年月日 tt_afkokihoken_reki.hiho_sikakusyutokuymd
            //searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0002, new ArPair("2010-12-10", "2024-12-11"));
            // 被保険者資格喪失事由（名称マスタ2025-12）tt_afkokihoken_reki.hiho_sikakusositujiyucd
            // searchDic.Add(CONDITION_SIKAKUSOSITUJIYUCD_0002, "202");
            // 被保険者資格喪失年月日 tt_afkokihoken_reki.hiho_sikakusosituymd
            // searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0002, new ArPair("2010-12-10", "2024-12-11"));
            //被保険者適用開始年月日 tt_afkokihoken_reki.hoken_tekiyoymdf
            // searchDic.Add(CONDITION_TEKIYOYMDF_0002, new ArPair("2010-12-10", "2024-12-11"));
            //被保険者適用終了年月日 tt_afkokihoken_reki.hoken_tekiyoymdt
            // searchDic.Add(CONDITION_TEKIYOYMDT_0002, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afkokihoken_reki.saisinflg
            // searchDic.Add(CONDITION_SAISINFLG_0002, true);
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0002, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }

        // 0006_医療機関一覧表のキー
        const string CONDITION_KIKANCD_0006 = "医療機関";
        const string CONDITION_HOKENKIKANCD_0006 = "保険医療機関";
        const string CONDITION_KIKANNM_0006 = "医療機関名";
        const string CONDITION_KANAKIKANNM_0006 = "医療機関名カナ";
        const string CONDITION_ADRS_0006 = "住所";
        const string CONDITION_STOPFLG_0006 = "使用停止";
        [TestMethod]
        public void Test医療機関一覧表_Test()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "20"; //★新規追加
            string Test_rptID = "0006";
            string Test_yosikiID = "0001";
            string Test_memo = "Test医療機関一覧表";//★新規追加
            string Test_sessionseq = "38747";//★新規追加 必須項目
            string Test_userid = "1";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.EXCEL;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //// 医療機関 tm_afkikan.kikancd
            //searchDic.Add(CONDITION_KIKANCD_0006, "01%");
            //// 保険医療機関 tm_afkikan.hokenkikancd
            //searchDic.Add(CONDITION_HOKENKIKANCD_0006, "01%");
            //// 医療機関名 tm_afkikan.kikannm
            //searchDic.Add(CONDITION_KIKANNM_0006, "医療機関%");
            //// 医療機関名カナ tm_afkikan.kanakikannm
            //searchDic.Add(CONDITION_KANAKIKANNM_0006, "ｲﾘｮｳｷｶﾝ%");
            //// 住所 tm_afkikan.adrs
            //searchDic.Add(CONDITION_ADRS_0006, "東京都江東区%");
            //// 使用停止 tm_afkikan.stopflg
            //searchDic.Add(CONDITION_STOPFLG_0006, false);

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, true, false, false);
        }

        // 0018_0001_教育申込通知書のキー
        const string CONDITION_GYOMUKBN_0018 = "業務区分";
        const string CONDITION_JIGYOCD_0018 = "その他日程事業・保健指導事業コード";
        const string CONDITION_YOTEIYMD_0018 = "実施予定日";
        const string CONDITION_YOTEITM_0018 = "予定開始時間";
        const string CONDITION_KAIJOCD_0018 = "会場コード";
        const string CONDITION_SYUKKETUKBN_0018 = "出欠区分";
        const string CONDITION_JUMINKBN_0018 = "住民区分";
        const string CONDITION_ATENANO_0018 = "宛名番号";
        const string CONDITION_RIYOMOKUTEKI_0018 = "送付先利用目的";

        [TestMethod]
        public void Test教育申込通知書_Test()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "2"; //★新規追加
            string Test_rptID = "0018";
            string Test_yosikiID = "0001";
            string Test_memo = "Test教育申込通知書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            ////業務区分（名称マスタ1001-101） tt_kksyudansido_mosikomi.gyomukbn
            //searchDic.Add(CONDITION_GYOMUKBN_0018, "01");
            ////その他日程事業・保健指導事業コード(汎用マスタ3019-100008) tt_kksyudansido_mosikomi.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0018, "010");
            ////実施予定日 tt_kksyudansido_mosikomi.yoteiymd
            //searchDic.Add(CONDITION_YOTEIYMD_0018, new ArPair("2020-01-01", "2025-12-31"));
            ////予定開始時間 tt_kksyudansido_mosikomi.yoteitm
            //searchDic.Add(CONDITION_YOTEITM_0018, new ArPair("0000", "2359"));
            ////会場コード tt_kksyudansido_mosikomi.kaijocd
            //searchDic.Add(CONDITION_KAIJOCD_0018, "V%");
            ////出欠区分(名称マスタ2019-21) tt_kksyudansido_sankasya.syukketukbn
            //searchDic.Add(CONDITION_SYUKKETUKBN_0018, "1");
            ////住民区分(名称マスタ1000-41) tt_afatena.juminkbn
            //searchDic.Add(CONDITION_JUMINKBN_0018, new string[] { "0", "1" });


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }

        [TestMethod]
        public void Test教育申込通知書TEST2()
        {
            // ダミーデータ
            using DaDbContext db = new DaDbContext();
            string Test_tokenID = "tU0vGcjG6ezkDHgoe3d6ZA==";
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
            //string Test_workSeq = "2"; //★新規追加
            string Test_rptID = "0018";
            string Test_yosikiID = "0001";
            string Test_memo = "Test教育申込通知書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //業務区分（名称マスタ1001-101） tt_kksyudansido_mosikomi.gyomukbn
            //searchDic.Add(CONDITION_GYOMUKBN_0018, "01");
            //その他日程事業・保健指導事業コード(汎用マスタ3019-100008) tt_kksyudansido_mosikomi.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0018, "010");
            //実施予定日 tt_kksyudansido_mosikomi.yoteiymd
            // searchDic.Add(CONDITION_YOTEIYMD_0018, new ArPair("2020-01-01", "2025-12-31"));
            //予定開始時間 tt_kksyudansido_mosikomi.yoteitm
            // searchDic.Add(CONDITION_YOTEITM_0018, new ArPair("0000", "2359"));
            //会場コード tt_kksyudansido_mosikomi.kaijocd
            // searchDic.Add(CONDITION_KAIJOCD_0018, "V%");
            //出欠区分(名称マスタ2019-21) tt_kksyudansido_sankasya.syukketukbn
            //searchDic.Add(CONDITION_SYUKKETUKBN_0018, "1");
            //住民区分(名称マスタ1000-41) tt_afatena.juminkbn
            // searchDic.Add(CONDITION_JUMINKBN_0018, new string[] { "0", "1" });


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            var resultPdf = DaEucService.MakeWorkTable(db, Test_tokenID, Test_rptID, Test_yosikiID, searchDic, detailSearchDic, orderByList);

            db.Session.Execute($"update wk_euatena_sub set formflg = true where workseq={workSeq}");

            // レポート作成
            //using DaDbContext db = new DaDbContext();
            //var result = DaEucService.MakeSheet(db, workSeq.ToString(), Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);

        }

        [TestMethod]
        public void Test国民健康保険情報一覧表2_Test2()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0001";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test国民健康保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 国保資格区分 (名称マスタ:tm_afmeisyo 2024-1) tt_afkokuho_reki.kokuho_sikakukbn
            searchDic.Add(CONDITION_SIKAKUKBN_0001, new string[] { "1", "2", "3" });
            // 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            // searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            // searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            // searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            // searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afkokuho_reki.saisinflg
            // searchDic.Add(CONDITION_SAISINFLG_0001, true);
            // 個人連絡先利用事業コード (汎用マスタ3019-4) tt_afrenrakusaki.jigyocd
            // searchDic.Add(CONDITION_JIGYOCD_0001, "17");
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            //searchDic.Add(CONDITION_RIYOMOKUTEKI_0001, "001");

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }

        [TestMethod]
        public void Test医療機関一覧表_Test2()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "20"; //★新規追加
            string Test_rptID = "0006";
            string Test_yosikiID = "0001";
            string Test_memo = "Test医療機関一覧表";//★新規追加
            string Test_sessionseq = "38747";//★新規追加 必須項目
            string Test_userid = "1";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 医療機関 tm_afkikan.kikancd
            searchDic.Add(CONDITION_KIKANCD_0006, "01%");
            // 保険医療機関 tm_afkikan.hokenkikancd
            searchDic.Add(CONDITION_HOKENKIKANCD_0006, "01%");
            // 医療機関名 tm_afkikan.kikannm
            searchDic.Add(CONDITION_KIKANNM_0006, "医療機関%");
            // 医療機関名カナ tm_afkikan.kanakikannm
            searchDic.Add(CONDITION_KANAKIKANNM_0006, "ｲﾘｮｳｷｶﾝ%");
            // 住所 tm_afkikan.adrs
            searchDic.Add(CONDITION_ADRS_0006, "東京都江東区%");
            // 使用停止 tm_afkikan.stopflg
            searchDic.Add(CONDITION_STOPFLG_0006, false);

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            using DaDbContext db = new DaDbContext();
            //var resultPdf = DaEucService.MakeSheet(db, Test_workSeq, Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo, false, false, false, false);
        }

        // 0016_訪問申込一覧のキー
        const string CONDITION_GYOMUKBN_0016 = "業務区分";
        const string CONDITION_JIGYOCD_0016 = "その他日程事業・保健指導事業";
        const string CONDITION_YOTEIYMD_0016 = "実施予定日";
        const string CONDITION_YOTEITM_0016 = "予定開始時間";
        const string CONDITION_REGSISYO_0016 = "登録支所";
        const string CONDITION_HOKENSIDOKBN_0016 = "訪問指導";
        const string CONDITION_RIYOMOKUTEKI_0016 = "送付先利用目的";

        [TestMethod]
        public void Test相談申込一覧表_Test2()
        {
            // ダミーデータ
            using DaDbContext db = new DaDbContext();
            string Test_tokenID = "TN54/ZNifM65WJC3O/GFqg==";
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
            string Test_rptID = "0016";
            string Test_yosikiID = "0001";  //★新規追加パラメータ

            string Test_csvPattern = "1";
            string Test_memo = "Test国民健康保険情報一覧表";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";


            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // // 業務区分(名称マスタ:tm_afmeisyo 1001-101) tt_kkhokensido_mosikomi.gyomukbn
            // searchDic.Add(CONDITION_GYOMUKBN_0016, "01");
            // // その他日程事業・保健指導事業 tt_kkhokensido_mosikomi.jigyocd
            // searchDic.Add(CONDITION_JIGYOCD_0016, new string[] { "010", "020" });
            // // 実施予定日 tt_kkhokensido_mosikomi.yoteiymd
            // searchDic.Add(CONDITION_YOTEIYMD_0016, new ArPair("2010-12-10", "2024-12-11"));
            // // 予定開始時間 tt_kkhokensido_mosikomi.yoteitm
            // searchDic.Add(CONDITION_YOTEITM_0016, new ArPair("0000", "2359"));
            // // 登録支所 tt_kkhokensido_mosikomi.regsisyo
            // searchDic.Add(CONDITION_REGSISYO_0016, "1");
            // // 訪問指導 tt_kkhokensido_mosikomi.hokensidokbn
            // searchDic.Add(CONDITION_HOKENSIDOKBN_0016, "1");
            // 送付先利用目的 (汎用マスタ3019-10005) tt_afsofusaki.riyomokuteki  ★必須ではない
            searchDic.Add(CONDITION_RIYOMOKUTEKI_0016, "001");


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            var resultCsv = DaEucService.MakeWorkTable(db, Test_tokenID, Test_rptID, Test_yosikiID, searchDic, detailSearchDic, orderByList);

            db.Session.Execute($"update wk_euatena_sub set formflg = true where workseq={workSeq}");

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);


            // CSV作成
            //using DaDbContext db = new DaDbContext();
            var result = DaEucService.MakeCSV(db, workSeq.ToString(), Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }

        // 0008_事業従事者（担当者）一覧表のキー
        const string CONDITION_STAFFID_0008 = "事業従事者ID";
        const string CONDITION_STAFFSIMEI_0008 = "事業従事者氏名";
        const string CONDITION_KANASTAFFSIMEI_0008 = "事業従事者カナ氏名";
        const string CONDITION_SYOKUSYU_0008 = "職種";
        const string CONDITION_KATUDOKBN_0008 = "活動区分";
        const string CONDITION_KIKANCD_0008 = "医療機関コード（自治体独自）";
        const string CONDITION_JISSIJIGYO_0008 = "実施事業";
        const string CONDITION_STOPFLG_0008 = "利用停止";

        [TestMethod]
        public void Test事業従事者一覧表CSV_Test2()
        {
            // ダミーデータ
            // string Test_tokenID = "AIPlus_0123456789"; //★廃止
            string Test_workSeq = "1"; //★新規追加
            string Test_rptID = "0008";
            string Test_yosikiID = "0001";  //★新規追加パラメータ
            //EnumReportType Test_ReportType = EnumReportType.CSV;
            string Test_csvPattern = "1";
            string Test_memo = "Test事業従事者一覧表CSV";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            bool Test_OutputHeader = true;
            ArEnumEncoding Test_Encoding = ArEnumEncoding.SHIFT_JIS;
            bool Test_BOM = false;
            bool Test_Quotation = false;

            // 抽出項目変動対応？
            string csvPattern = Test_csvPattern;

            // CSVフォーマット情報
            Dictionary<string, object> csvFmtDic = new Dictionary<string, object>();
            // OutputHeader Boolean
            csvFmtDic.Add(DaEucService.CONDITION_OUTPUTHEADER, Test_OutputHeader);
            // Encoding ArEnumEncoding
            csvFmtDic.Add(DaEucService.CONDITION_ENCODING, Test_Encoding);
            // BOM Boolean
            csvFmtDic.Add(DaEucService.CONDITION_BOM, Test_BOM);
            // Quotation Boolean
            csvFmtDic.Add(DaEucService.CONDITION_QUOTATION, Test_Quotation);

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            // 事業従事者ID tm_afstaff.staffid
            searchDic.Add(CONDITION_STAFFID_0008, "000000%");
            // 事業従事者氏名 tm_afstaff.staffsimei
            searchDic.Add(CONDITION_STAFFSIMEI_0008, "岡%");
            // 事業従事者カナ氏名 tm_afstaff.kanastaffsimei
            searchDic.Add(CONDITION_KANASTAFFSIMEI_0008, "オカ%");
            // 職種(名称ﾏｽﾀ2019-2) tm_afstaff.syokusyu
            searchDic.Add(CONDITION_SYOKUSYU_0008, new string[] { "01", "02" });
            // 活動区分(名称ﾏｽﾀ2019-3) tm_afstaff.katudokbn
            searchDic.Add(CONDITION_KATUDOKBN_0008, "2");
            // 医療機関コード（自治体独自） tm_afkikan.kikancd
            searchDic.Add(CONDITION_KIKANCD_0008, "00%");
            // 実施事業(名称ﾏｽﾀ1000-43) tm_afstaff_sub.jissijigyo
            searchDic.Add(CONDITION_JISSIJIGYO_0008, new string[] { "10", "11" });
            // 利用停止 tm_afstaff.stopflg
            searchDic.Add(CONDITION_STOPFLG_0008, false);

            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // CSV作成
            using DaDbContext db = new DaDbContext();
            var resultCsv = DaEucService.MakeCSV(db, Test_workSeq, Test_rptID, Test_yosikiID, csvFmtDic, csvPattern, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);
        }

        [TestMethod]
        public void Test教育申込通知書_TTESTT2()
        {
            // ダミーデータ
            using DaDbContext db = new DaDbContext();
            string Test_tokenID = "tU0vGcjG6ezkDHgoe3d6ZA==";
            var workSeq = DaEucService.GetWorkSeq(db, Test_tokenID);
            //string Test_workSeq = "2"; //★新規追加
            string Test_rptID = "0018";
            string Test_yosikiID = "0001";
            string Test_memo = "Test教育申込通知書";//★新規追加
            string Test_sessionseq = "12345";//★新規追加 必須項目
            string Test_userid = "1111";//★新規追加 必須項目
            string Test_regsisyo = "1";

            // 検索情報
            Dictionary<string, object> searchDic = new Dictionary<string, object>();
            //業務区分（名称マスタ1001-101） tt_kksyudansido_mosikomi.gyomukbn
            //searchDic.Add(CONDITION_GYOMUKBN_0018, "01");
            //その他日程事業・保健指導事業コード(汎用マスタ3019-100008) tt_kksyudansido_mosikomi.jigyocd
            //searchDic.Add(CONDITION_JIGYOCD_0018, "010");
            //実施予定日 tt_kksyudansido_mosikomi.yoteiymd
            // searchDic.Add(CONDITION_YOTEIYMD_0018, new ArPair("2020-01-01", "2025-12-31"));
            //予定開始時間 tt_kksyudansido_mosikomi.yoteitm
            // searchDic.Add(CONDITION_YOTEITM_0018, new ArPair("0000", "2359"));
            //会場コード tt_kksyudansido_mosikomi.kaijocd
            // searchDic.Add(CONDITION_KAIJOCD_0018, "V%");
            //出欠区分(名称マスタ2019-21) tt_kksyudansido_sankasya.syukketukbn
            //searchDic.Add(CONDITION_SYUKKETUKBN_0018, "1");
            //住民区分(名称マスタ1000-41) tt_afatena.juminkbn
            // searchDic.Add(CONDITION_JUMINKBN_0018, new string[] { "0", "1" });


            // 検索詳細情報
            Dictionary<string, object> detailSearchDic = new Dictionary<string, object>();

            // ソート順情報　現時点未使用
            List<string> orderByList = new List<string>();

            // レポート作成
            var resultPdf = DaEucService.MakeWorkTable(db, Test_tokenID, Test_rptID, Test_yosikiID, searchDic, detailSearchDic, orderByList);

            db.Session.Execute($"update wk_euatena_sub set formflg = true where workseq={workSeq}");


            // レポート出力種類
            EnumReportType Test_ReportType = EnumReportType.PDF;

            // レポート作成
            //using DaDbContext db = new DaDbContext();
            //var result = DaEucService.MakeSheet(db, workSeq.ToString(), Test_rptID, Test_yosikiID, Test_ReportType, searchDic, detailSearchDic, orderByList, Test_memo, Test_sessionseq, Test_userid, Test_regsisyo);

        }
    }

}
