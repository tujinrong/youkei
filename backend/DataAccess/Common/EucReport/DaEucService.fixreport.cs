// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票ロジック処理
//　　　　　　　固定帳票
// 作成日　　: 2023.04.07
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************

using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Interface;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDefs;
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.DataAccess
{
    public static partial class DaEucService
    {
        /// <summary>
        /// 特殊帳票の出力　(CSVは対応しない）
        /// </summary>
        private static ArResult MakeSpecialSheet(DaDbContext db, string workSeq, string rptID, string yosikiID, Dictionary<string, object> searchDic, Dictionary<string, object> outputInfoDic,
            EnumReportType reportType, string memo, string sessionseq, string reguserid, bool hasUpdateSql = false, bool isBlank = false, bool hasConditionSheet = false, bool hasUpdHassoRireki = false)
        {
            //処理開始
            DateTime syoridttmf = DaUtil.Now;
            //宛名番号ログ登録フラグ
            bool outPutAtenaFlg = false;
            //SQL文
            string sql = string.Empty;
            // テンプレートパス
            string excel = string.Empty;
            string atenaSql = "INSERT INTO tt_aflogatena( sessionseq, atenano, pnouseflg, usekbn, msg, reguserid, regdttm) ";
            ArResult? result = null;

            //シート定義情報
            var sheet = new ArSheetDef();
            var engine = new ArSQLEngine();
            var groupEngine = new ArSmartGroupEngine();
            IArSubSheetDef subSheet = new ArGridSheetDef();
            IArSubSheetDef lstSubSheet = new ArPageListSheetDef();
            var specialTemplateDir = Path.Combine(Environment.CurrentDirectory, "App_Data", "Test", "その他Templates");
            //テンプレート情報取得
            var siyokbn = GetSiyoKbn(yosikiID);
            var templatefile = db.tm_eutemplatefile.SELECT.WHERE.ByKey(siyokbn).GetDto();
            switch (yosikiID)
            {
                case Cアドレスシール:
                    excel = Path.Combine(specialTemplateDir, "アドレスシール.xlsx");

                    //出力日
                    var printDate = $"'{DaFormatUtil.FormatWaKjYMD(DateTime.Today)}'";
                    if (outputInfoDic != null && outputInfoDic.TryGetValue(CONDITION_PRINTDATE, out var value) && DateTime.TryParse((string)value, out DateTime parsedDate))
                    {
                        printDate= $"'{DaFormatUtil.FormatWaKjYMD(parsedDate)}'";
                    }

                    // アドレス情報取得SQL
                    sql = $@"
SELECT 
 T.adrs_yubin AS adrs_yubin,       --郵便番号
 T.adrs1 AS adrs1,                 --住所１
 T.adrs2 AS adrs2,                 --住所２
 T.adrs_katagakicd AS adrs_katagakicd,  --方書
 T.simei_yusen AS simei_yusen,          --氏名_優先
 T.adrs_yubin || ',' || T.adrs1 ||T.adrs2 AS  customerCd     --カスタマーコード
,ROW_NUMBER() OVER (ORDER BY T.atenano) AS no,  --番号
{printDate} AS printDate                        --出力日
FROM tt_afatena T 
INNER JOIN wk_euatena_sub W ON T.atenano = W.atenano
WHERE W.workseq = {workSeq} AND W.formflg = true ORDER BY T.atenano";
                    break;

                case Cはがき:
                    //用紙1枚あたりの出力人数
                    var info = DaControlService.GetRow(db, EnumCtrlKbn.はがきの設定, コントロールマスタ.システム.はがきの設定._1);
                    var count = info?.IntValue1 ?? 1;
                    //4枚か1枚
                    if (count == 1)
                    {
                        excel = Path.Combine(specialTemplateDir, "はがき2.xlsx");
                    }
                    else
                    {
                        excel = Path.Combine(specialTemplateDir, "はがき1.xlsx");
                    }

                    // はがき情報取得SQL
                    sql = $@"
SELECT 
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 1 FOR 1) ELSE NULL END AS adrs_yubin1,  -- 郵便番号1
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 2 FOR 1) ELSE NULL END AS adrs_yubin2,  -- 郵便番号2
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 3 FOR 1) ELSE NULL END AS adrs_yubin3,  -- 郵便番号3
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 4 FOR 1) ELSE NULL END AS adrs_yubin4,  -- 郵便番号4
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 5 FOR 1) ELSE NULL END AS adrs_yubin5,  -- 郵便番号5
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 6 FOR 1) ELSE NULL END AS adrs_yubin6,  -- 郵便番号6
 CASE WHEN T.adrs_yubin IS NOT NULL THEN SUBSTRING(T.adrs_yubin FROM 7 FOR 1) ELSE NULL END AS adrs_yubin7,  -- 郵便番号7
 fn_eugetaddress(T.atenano) AS adrs1,  --住所
 T.adrs2 AS adrs2,                 --住所２
-- T.adrs_katagakicd AS adrs_katagakicd,  --方書
 T.simei_yusen AS simei_yusen          --氏名_優先
FROM tt_afatena T 
INNER JOIN wk_euatena_sub W ON T.atenano = W.atenano
WHERE W.workseq = {workSeq} AND W.formflg = true ORDER BY T.atenano";
                    break;

                case C宛名台帳:
                    excel = Path.Combine(specialTemplateDir, "宛名台帳.xlsx");

                    // 宛名台帳情報取得SQL
                    sql = $@"
SELECT 
 T.adrs_yubin AS adrs_yubin,       --郵便番号
 fn_eugetaddress(T.atenano) AS adrs1,  --住所
 T.adrs2 AS adrs2,                 --住所２
 T.adrs_katagakicd AS adrs_katagakicd,  --方書
 T.simei_yusen AS simei_yusen,          --氏名_優先
 T.adrs_yubin || ',' || T.adrs1 ||T.adrs2 AS  customerCd     --カスタマーコード
FROM tt_afatena T 
INNER JOIN wk_euatena_sub W ON T.atenano = W.atenano
WHERE W.workseq = {workSeq} AND W.formflg = true ORDER BY T.atenano";
                    break;

                case Cバーコード:
                    excel = Path.Combine(specialTemplateDir, "バーコード.xlsx");
                    //一人あたりの枚数の設定
                    info = DaControlService.GetRow(db, EnumCtrlKbn.バーコードシールの設定, コントロールマスタ.システム.バーコードシールの設定._1);
                    count= info?.IntValue1 ?? 1; 

                    // 宛名アドレス情報取得SQL
                    sql = $@"
WITH RECURSIVE repeat_rows AS (
    -- 初期クエリ: 必要なデータを選択し、初期の繰り返し回数列 repetition を追加
    SELECT
        T.simei_yusen AS simei_yusen, -- 氏名_優先
        T.atenano AS atenano,         -- 宛名番号
        1 AS repetition               -- 初期繰り返し回数
    FROM
        tt_afatena T
    INNER JOIN wk_euatena_sub W
        ON T.atenano = W.atenano
    WHERE
        W.workseq = {workSeq}
        AND W.formflg = true

    UNION ALL

    -- 再帰部分: 前回のクエリ結果を選択し、繰り返し回数を 1 増加
    SELECT
        r.simei_yusen,    -- 氏名_優先
        r.atenano,        -- 宛名番号
        r.repetition + 1  -- 繰り返し回数を増加
    FROM
        repeat_rows r
    WHERE
        r.repetition < {count}  -- 繰り返し回数の最大値
)

-- 最終クエリ: 結果を選択し、atenano と repetition で並べ替え
SELECT
    simei_yusen, -- 氏名_優先
    atenano      -- 宛名番号
FROM
    repeat_rows
ORDER BY
    atenano,
    repetition;
";
                    break;

                case C件数表年齢:
                    excel = Path.Combine(specialTemplateDir, "件数表年齢.xlsx");
                    lstSubSheet.IsNullToZero = true;
                    // 宛名アドレス情報取得SQL
                    sql = "";
                    break;

                case C件数表行政区:
                    excel = Path.Combine(specialTemplateDir, "件数表行政区.xlsx");
                    lstSubSheet.IsNullToZero = true;
                    // 宛名アドレス情報取得SQL
                    sql = $@"
SELECT 
  M.tikucd AS tikucd,     --行政区コード
  M.tikunm AS tikunm,     --行政区名
 count(*) AS totals,                     --計
 SUM(CASE WHEN T.sex = '1' THEN 1 ELSE 0 END) AS male_count,     --男人数
 SUM(CASE WHEN T.sex = '2' THEN 1 ELSE 0 END) AS female_count,   --女人数
 SUM(CASE WHEN T.sex = '0' THEN 1 ELSE 0 END) AS unknown_count,  --不詳人数
 SUM(CASE WHEN T.sex = '9' THEN 1 ELSE 0 END) AS other_count     --その他
FROM tt_afatena T
INNER JOIN tm_afmeisyo MM ON MM.nmmaincd = '1001' AND MM.nmsubcd = '37' AND MM.hanyokbn2 = '1'
INNER JOIN tm_aftiku M ON T.gyoseikucd = M.tikucd AND M.tikukbn = MM.nmcd
INNER JOIN wk_euatena_sub W ON T.atenano = W.atenano
WHERE W.workseq = {workSeq} AND W.formflg = true
GROUP BY tikucd, tikunm
ORDER BY tikucd; ";
                    break;

                default:
                    throw new ArgumentException();
            }

            //出力条件
            var condition = new ArConditionModel();

            if (C件数表年齢.Equals(yosikiID))
            {
                condition.CrossOption.AutoCross = true;
            }

            if (Cアドレスシール.Equals(yosikiID))
            {
                if (outputInfoDic != null && outputInfoDic.TryGetValue(CONDITION_START_COUNT, out var startCount))
                {
                    //空白明細数(明細開始位置)
                    condition.StartDetailCount = DaConvertUtil.CInt(startCount) - 1;
                }
            }

            outPutAtenaFlg = SetSpeicalSheetInfo(ref sheet, ref subSheet, ref lstSubSheet, ref condition, engine, groupEngine, workSeq, excel, yosikiID, sql, sessionseq, reguserid, out atenaSql);

            switch (yosikiID)
            {
                case Cアドレスシール:

                    //枚数の設定(縦)
                    var info = DaControlService.GetRow(db, EnumCtrlKbn.アドレスシールの設定, コントロールマスタ.システム.アドレスシールの設定._3);
                    // 行情報設定
                    engine.TemplateInfo.DetailMaxRows = info?.IntValue1 ?? 6;
                    
                    //枚数の設定(横)
                    info = DaControlService.GetRow(db, EnumCtrlKbn.アドレスシールの設定, コントロールマスタ.システム.アドレスシールの設定._4);
                    // 列情報設定
                    engine.TemplateInfo.DetailMaxColumns = info?.IntValue1 ?? 2;

                    break;
                case Cはがき:

                    //用紙1枚あたりの出力人数
                    info = DaControlService.GetRow(db, EnumCtrlKbn.はがきの設定, コントロールマスタ.システム.はがきの設定._1);
                    var count = info?.IntValue1 ?? 1;
                    //4枚か1枚
                    if (count == 1)
                    {
                        // 行情報設定
                        engine.TemplateInfo.DetailMaxRows = 1;
                        // 列情報設定
                        engine.TemplateInfo.DetailMaxColumns = 1;
                    }
                    else
                    {
                        // 行情報設定
                        engine.TemplateInfo.DetailMaxRows = 2;
                        // 列情報設定
                        engine.TemplateInfo.DetailMaxColumns = 2;
                    }
                    break;
                case Cバーコード:

                    //行数
                    info = DaControlService.GetRow(db, EnumCtrlKbn.バーコードシールの設定, コントロールマスタ.システム.バーコードシールの設定._2);
                    // 行情報設定
                    engine.TemplateInfo.DetailMaxRows = info?.IntValue1 ?? 8;

                    //列数
                    info = DaControlService.GetRow(db, EnumCtrlKbn.バーコードシールの設定, コントロールマスタ.システム.バーコードシールの設定._3);
                    // 列情報設定
                    engine.TemplateInfo.DetailMaxColumns = info?.IntValue1 ?? 3;
                    break;
            }

            // 空白PDF
            condition.IsBlank = isBlank;
            // 条件シート出力
            condition.OutputConditionSheet = hasConditionSheet;

            //出力方法
            condition.OutputType = reportType switch
            {
                EnumReportType.PREVIEW => ArEnumOutputType.Svgz,
                EnumReportType.PDF => ArEnumOutputType.Pdf,
                EnumReportType.EXCEL => ArEnumOutputType.Excel,
                _ => throw new ArgumentException()
            };

            //固定帳票作成
            result = AiReport.MakeReport(db.Session, sheet, condition);

            //データ無しの場合、継続処理無し
            if (!isBlank && result.Error == ArEnumError.NoData)
            {
                result.ErrorCode = リターンNO_DATA;
                return result;
            }

            var jyotaikbn = Enum履歴出力状態区分.処理完了;
            if (!result.Success)
            {
                jyotaikbn = Enum履歴出力状態区分.処理失敗;
            }
            //処理終了
            DateTime syoridttmt = DaUtil.Now;
            //帳票出力履歴テーブルに登録
            if (reportType != EnumReportType.PREVIEW)
            {
                // 帳票出力履歴テーブルに登録
                OutPutHistoryInfo(db, rptID, yosikiID, reportType, searchDic, memo, sessionseq, reguserid, result, syoridttmf, syoridttmt, outputInfoDic, jyotaikbn);
            }

            // 宛名番号操作ログに出力
            if (outPutAtenaFlg)
            {
                // 宛名番号ログ登録
                var ret = DaDbUtil.RunSql(db, atenaSql);
            }

            //実行後SQL実施を行う
            if (hasUpdateSql)
            {
                result.MsgUpdateSQL = UpdateSQL(db, rptID, yosikiID, workSeq, reportType, searchDic, reguserid, null, condition, hasUpdHassoRireki);
            }

            return result;
        }

        /// <summary>
        /// 固定帳票情報設定
        /// </summary>
        private static bool SetSpeicalSheetInfo(ref ArSheetDef sheet, ref IArSubSheetDef subSheet, ref IArSubSheetDef lstSubSheet, ref ArConditionModel condition, ArSQLEngine engine, ArSmartGroupEngine groupEngine,
            string workSeq, string excel, string yosikiID, string sql, string sessionseq, string reguserid, out string atenaSql)
        {
            bool outPutAtenaFlg = false;
            atenaSql = "INSERT INTO tt_aflogatena( sessionseq, atenano, pnouseflg, usekbn, msg, reguserid, regdttm) ";
            // 宛名番号ログ登録SQL
            if (yosikiID.Equals(Cバーコード) || yosikiID.Equals(Cアドレスシール) || yosikiID.Equals(Cはがき) || yosikiID.Equals(C宛名台帳))
            {
                outPutAtenaFlg = true;

                atenaSql += $@"
SELECT 
 {sessionseq} AS sessionseq, 
 T.atenano AS atenano, 
 False AS pnouseflg, 
 4 AS usekbn, 
 null AS msg, 
 {reguserid} AS  reguserid, 
 now() AS  regdttm 
FROM tt_afatena T 
INNER JOIN wk_euatena_sub W ON T.atenano = W.atenano
WHERE W.workseq = {workSeq} AND W.formflg = true ORDER BY T.atenano";
            }

            // 帳票情報設定
            if (Cアドレスシール.Equals(yosikiID) || Cはがき.Equals(yosikiID) || C宛名台帳.Equals(yosikiID) || Cバーコード.Equals(yosikiID)) SetSubSheetInfo(ref sheet, ref subSheet, engine, excel);
            if (C件数表年齢.Equals(yosikiID)) SetSubSheetInfo(ref sheet, ref lstSubSheet, groupEngine, excel);
            if (C件数表行政区.Equals(yosikiID)) SetSubSheetInfo(ref sheet, ref lstSubSheet, engine, excel);
            engine.SQL = sql;
            switch (yosikiID)
            {
                case Cアドレスシール:
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS, ItemID = ITEMID_YUBIN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.郵便番号, FormatString = FORMAT_YUBIN_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS1_ADRS, ItemID = ITEMID_ADRS1_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS2_ADRS, ItemID = ITEMID_ADRS2_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SIMEI_YUSEN_ADRS, ItemID = ITEMID_SIMEI_YUSEN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEI_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_KATAGAKICD_ADRS, ItemID = ITEMID_KATAGAKICD_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEIKATA_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_CUSTOMERCD_ADRS, ItemID = ITEMID_CUSTOMERCD_ADRS, FormatKbn = ArEnumFormat.BarCode, BarCodeType = ArEnumBarCode.CustomerCode, Width = 50, Height = 3 });
                    //番号
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_NO, ItemID = ITEMID_NO, FormatKbn = ArEnumFormat.String });
                    //出力日
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_PRINTDATE, ItemID = ITEMID_PRINTDATE, FormatKbn = ArEnumFormat.String });

                    // 行情報設定
                    engine.TemplateInfo.DetailStartRowIndex = 1;
                    engine.TemplateInfo.DetailRowCount = 8;
                    engine.TemplateInfo.DetailMaxRows = 7;
                    engine.TemplateInfo.EndRowIndex = 55;//48

                    // 列情報設定
                    engine.TemplateInfo.DetailStartColumnIndex = 1;
                    engine.TemplateInfo.DetailColumnCount = 5;
                    engine.TemplateInfo.DetailMaxColumns = 2;
                    break;

                case Cはがき:
                    //engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS, ItemID = ITEMID_YUBIN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.郵便番号2, FormatString = FORMAT_YUBIN_ADRS_2 });

                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS1, ItemID = ITEMID_YUBIN_ADRS1, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS2, ItemID = ITEMID_YUBIN_ADRS2, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS3, ItemID = ITEMID_YUBIN_ADRS3, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS4, ItemID = ITEMID_YUBIN_ADRS4, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS5, ItemID = ITEMID_YUBIN_ADRS5, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS6, ItemID = ITEMID_YUBIN_ADRS6, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS7, ItemID = ITEMID_YUBIN_ADRS7, FormatKbn = ArEnumFormat.String });

                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS_ADRS, ItemID = ITEMID_ADRS1_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS2_ADRS, ItemID = ITEMID_ADRS2_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SIMEI_YUSEN_ADRS, ItemID = ITEMID_SIMEI_YUSEN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEI_ADRS });

                    // 行情報設定
                    engine.TemplateInfo.DetailStartRowIndex = 1;
                    engine.TemplateInfo.DetailRowCount = 22;
                    engine.TemplateInfo.DetailMaxRows = 2;
                    engine.TemplateInfo.EndRowIndex = 44;

                    // 列情報設定
                    engine.TemplateInfo.DetailStartColumnIndex = 1;
                    engine.TemplateInfo.DetailColumnCount = 12;
                    engine.TemplateInfo.DetailMaxColumns = 2;
                    break;

                case C宛名台帳:
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_YUBIN_ADRS, ItemID = ITEMID_YUBIN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.郵便番号, FormatString = FORMAT_YUBIN_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS_ADRS, ItemID = ITEMID_ADRS1_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ADRS2_ADRS, ItemID = ITEMID_ADRS2_ADRS, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SIMEI_YUSEN_ADRS, ItemID = ITEMID_SIMEI_YUSEN_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEI_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_KATAGAKICD_ADRS, ItemID = ITEMID_KATAGAKICD_ADRS, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEIKATA_ADRS });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_CUSTOMERCD_ADRS, ItemID = ITEMID_CUSTOMERCD_ADRS, FormatKbn = ArEnumFormat.BarCode, BarCodeType = ArEnumBarCode.CustomerCode, Width = 50, Height = 3 });

                    // 行情報設定
                    engine.TemplateInfo.DetailStartRowIndex = 1;
                    engine.TemplateInfo.DetailRowCount = 32;
                    engine.TemplateInfo.DetailMaxRows = 1;
                    engine.TemplateInfo.EndRowIndex = 62;

                    // 列情報設定
                    engine.TemplateInfo.DetailStartColumnIndex = 1;
                    engine.TemplateInfo.DetailColumnCount = 10;
                    engine.TemplateInfo.DetailMaxColumns = 1;
                    break;

                case Cバーコード:
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SIMEI_YUSEN_BARCD, ItemID = ITEMID_SIMEI_YUSEN_BARCD, FormatKbn = ArEnumFormat.String, StringFormat = ArEnumSpecialString.様, FormatString = FORMAT_SIMEI_BARCD });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_ATENANO_BARCD, ItemID = ITEMID_ATENANO_BARCD, FormatKbn = ArEnumFormat.BarCode, BarCodeType = (ArEnumBarCode)ArEnumBarCode.NW7, Width = 40, Height = 10 });

                    // 行情報設定
                    engine.TemplateInfo.DetailStartRowIndex = 1;
                    engine.TemplateInfo.DetailRowCount = 4;
                    engine.TemplateInfo.DetailMaxRows = 9;
                    engine.TemplateInfo.EndRowIndex = 37;
                    // 列情報設定
                    engine.TemplateInfo.DetailStartColumnIndex = 1;
                    engine.TemplateInfo.DetailColumnCount = 3;
                    engine.TemplateInfo.DetailMaxColumns = 4;
                    break;

                case C件数表年齢:
                    //Select文構成
                    groupEngine.ItemDefs.Add(new ArItemDef()
                    {
                        ItemName = CONDITION_AGE,
                        ItemID = ITEMID_AGE,
                        SqlColumn = $@" COALESCE(euc_af_getage({tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.bymd)}, NULL), -1) ",
                        GroupType = EnumGroupItemType.RowGroup,
                        ItemGroupDef = new ArFixItemGroupDef() { Level = 1, Values = GetAgeList(), Captions = GetAgeCaptionList() }
                    });
                    groupEngine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_TOTAL, ItemID = ITEMID_SUM_TOTAL, SqlColumn = "Count(*)", GroupType = EnumGroupItemType.Totaling });
                    groupEngine.ItemDefs.Add(new ArItemDef()
                    {
                        ItemName = CONDITION_SUM_GENDER,
                        ItemID = ITEMID_SUM_GENDER,
                        SqlColumn = $@"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.sex)}",
                        GroupType = EnumGroupItemType.ColumnGroup,
                        ItemGroupDef = new ArFixItemGroupDef() { Level = 1, Values = { ArConst.TOTAL, "1", "2", "0", "9" }, Captions = { CONDITION_SUM_TOTAL, CONDITION_SUM_MALE, CONDITION_SUM_FEMALE, CONDITION_SUM_UNKNOWN, CONDITION_SUM_OTHER } }
                    });

                    //Where文構成
                    //ワークシーケンス
                    var condWorkSeq = new ArConditionDef();
                    condWorkSeq.Sql = $@"{wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.workseq)} = @{nameof(wk_euatena_subDto.workseq)}";
                    condWorkSeq.Name = $@"{nameof(wk_euatena_subDto.workseq)}";
                    condWorkSeq.ParameterList.Add($@"{nameof(wk_euatena_subDto.workseq)}");
                    var condItemWorkSeq = new ArConditionItem();
                    condItemWorkSeq.Name = $@"{nameof(wk_euatena_subDto.workseq)}";
                    ArParameterModel paramWorkSeq = new ArParameterModel();
                    paramWorkSeq.Name = $@"{nameof(wk_euatena_subDto.workseq)}";
                    paramWorkSeq.Value = long.Parse(workSeq);
                    condItemWorkSeq.ParaList.Add(paramWorkSeq);
                    condition.ConditionList.Add(condItemWorkSeq);
                    condWorkSeq.TableIDList.Add(wk_euatena_subDto.TABLE_NAME);
                    groupEngine.ConditionDic.Add(condWorkSeq.Name, condWorkSeq);
                    //出力フラグ
                    var condFormFlg = new ArConditionDef();
                    condFormFlg.Sql = $@"{wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.formflg)} = @{nameof(wk_euatena_subDto.formflg)}";
                    condFormFlg.Name = $@"{nameof(wk_euatena_subDto.formflg)}";
                    condFormFlg.ParameterList.Add($@"{nameof(wk_euatena_subDto.formflg)}");
                    var condItemFormFLg = new ArConditionItem();
                    condItemFormFLg.Name = $@"{nameof(wk_euatena_subDto.formflg)}";
                    ArParameterModel paramFormFLg = new ArParameterModel();
                    paramFormFLg.Name = $@"{nameof(wk_euatena_subDto.formflg)}";
                    paramFormFLg.Value = true;
                    condItemFormFLg.ParaList.Add(paramFormFLg);
                    condition.ConditionList.Add(condItemFormFLg);
                    condFormFlg.TableIDList.Add(wk_euatena_subDto.TABLE_NAME);
                    groupEngine.ConditionDic.Add(condFormFlg.Name, condFormFlg);

                    //Join文構成
                    var rlt = new ArRelationDef();
                    groupEngine.RelationDef = rlt;
                    rlt.MainTableID = tt_afatenaDto.TABLE_NAME;
                    rlt.MainTableName = tt_afatenaDto.TABLE_NAME;
                    var relations = groupEngine.RelationDef.TableRelations;
                    var relation = new ArTableRelationDef();
                    relation.TableName = wk_euatena_subDto.TABLE_NAME;
                    relation.IsLeftJoin = false;
                    relation.MainTableID = tt_afatenaDto.TABLE_NAME;
                    relation.TableID = wk_euatena_subDto.TABLE_NAME;
                    relation.RefTableID = tt_afatenaDto.TABLE_NAME;
                    relation.JoinString = $@"{tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.atenano)} = {wk_euatena_subDto.TABLE_NAME}.{nameof(wk_euatena_subDto.atenano)}";
                    relations.Add(relation);

                    // 行情報設定
                    groupEngine.TemplateInfo.DetailStartRowIndex = 4;
                    groupEngine.TemplateInfo.DetailRowCount = 1;
                    groupEngine.TemplateInfo.DetailMaxRows = 34;
                    groupEngine.TemplateInfo.EndRowIndex = 38;
                    break;

                case C件数表行政区:
                    //Select文構成
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_GYOSEIKUCD, ItemID = ITEMID_GYOSEIKUCD, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_GYOSEIKUNM, ItemID = ITEMID_GYOSEIKUNM, FormatKbn = ArEnumFormat.String });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_TOTAL, ItemID = ITEMID_SUM_TOTAL, FormatKbn = ArEnumFormat.Number, FormatString = "#,0" });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_MALE, ItemID = ITEMID_SUM_MALE, FormatKbn = ArEnumFormat.Number, FormatString = "#,0" });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_FEMALE, ItemID = ITEMID_SUM_FEMALE, FormatKbn = ArEnumFormat.Number, FormatString = "#,0" });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_UNKNOWN, ItemID = ITEMID_SUM_UNKNOWN, FormatKbn = ArEnumFormat.Number, FormatString = "#,0" });
                    engine.ItemDefs.Add(new ArItemDef() { ItemName = CONDITION_SUM_OTHER, ItemID = ITEMID_SUM_OTHER, FormatKbn = ArEnumFormat.Number, FormatString = "#,0" });

                    // 行情報設定
                    engine.TemplateInfo.DetailStartRowIndex = 4;
                    engine.TemplateInfo.DetailRowCount = 1;
                    engine.TemplateInfo.DetailMaxRows = 34;
                    engine.TemplateInfo.EndRowIndex = 38;
                    // 列情報設定
                    engine.TemplateInfo.DetailStartColumnIndex = 2;
                    engine.TemplateInfo.DetailColumnCount = 1;
                    break;

                default:
                    throw new ArgumentException();
            }

            return outPutAtenaFlg;
        }
    }
}