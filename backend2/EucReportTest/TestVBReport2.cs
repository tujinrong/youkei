using AIplus.AiReport.Enums;
using AIplus.AiReport.Models;
using BCC.Affect.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;

namespace EucReportTest
{
    public partial class TestVBReport
    {
        [TestMethod]
        public void Test国民健康保険情報一覧表2()
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
            searchDic.Add(CONDITION_SIKAKUKBN_0001, "1");
            // 国保資格取得年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusyutokuymd
            searchDic.Add(CONDITION_SIKAKUSYUTOKUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保資格喪失年月日（範囲指定） tt_afkokuho_reki.kokuho_sikakusosituymd
            searchDic.Add(CONDITION_SIKAKUSOSITUYMD_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保適用開始年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdf
            searchDic.Add(CONDITION_TEKIYOYMDF_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 国保適用終了年月日（範囲指定） tt_afkokuho_reki.kokuho_tekiyoymdt
            searchDic.Add(CONDITION_TEKIYOYMDT_0001, new ArPair("2010-12-10", "2024-12-11"));
            // 最新フラグ tt_afkokuho_reki.saisinflg
            searchDic.Add(CONDITION_SAISINFLG_0001, true);
            // 個人連絡先利用事業コード (汎用マスタ3019-4) tt_afrenrakusaki.jigyocd
            searchDic.Add(CONDITION_JIGYOCD_0001, "17");
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
    }
}