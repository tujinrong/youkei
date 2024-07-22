// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: EUC帳票ロジック処理
//
// 作成日　　: 2024.07.07
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
using AIplus.AiReport.ReportDef.SheetDefs.Base;
using AIplus.AiReport.Utils;
using Org.BouncyCastle.Ocsp;
using System;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static NPOI.HSSF.Util.HSSFColor;

namespace BCC.Affect.DataAccess
{
    public static partial class DaEucService
    {
        /// <summary>
        /// 帳票様式出力
        /// </summary>
        public static ArResult MakeSheet(DaDbContext db, string workSeq, string rptID, string yosikiID, EnumReportType reportType, Dictionary<string, object> searchDic,
            Dictionary<string, object> detailSearchDic, Dictionary<string, object> outputInfoDic, List<string> orderByList, string memo, string sessionseq,
             string reguserid, string? regsisyo, bool hasUpdateSql = false, bool isBlank = false, bool hasConditionSheet = false, bool hasUpdHassoRireki = false, bool isBatch = false)
        {
            //必須パラメータチェックを行う
            if (string.IsNullOrWhiteSpace(sessionseq) || string.IsNullOrWhiteSpace(reguserid))
            {
                throw new ArgumentException("必須パラメータ[セッションシーケンス]、[ユーザーID]の値をご確認ください。");
            }


            //固定帳票
            if (yosikiID == Cアドレスシール || yosikiID == Cはがき || yosikiID == C宛名台帳 || yosikiID == Cバーコード || yosikiID == C件数表年齢 || yosikiID == C件数表行政区)
            {
                return MakeSpecialSheet(db, workSeq, rptID, yosikiID, searchDic, outputInfoDic, reportType, memo, sessionseq, reguserid, hasUpdateSql, isBlank, hasConditionSheet, hasUpdHassoRireki);
            }

            //個人番号操作フラグ
            bool pnouseflg = false;

            //処理開始
            DateTime syoridttmf = DaUtil.Now;

            //シート定義情報
            var sheet = new ArSheetDef();

            //条件情報
            var condition = new ArConditionModel();

            //タイムアウト時間の設定
            const int BATCH_TIMEOUT = 3 * 60 * 60;
#if DEBUG
            const int RUNTIME_TIMEOUT = 30 * 60;
#else
            const int RUNTIME_TIMEOUT = 2 * 60;
#endif
            db.Session.CommandTimeout = (isBatch) ? BATCH_TIMEOUT : RUNTIME_TIMEOUT;
            condition.LimitTime = (isBatch) ? BATCH_TIMEOUT : RUNTIME_TIMEOUT;
            condition.SplitIndex = 1;
            condition.SplitPages = (reportType == EnumReportType.PREVIEW) ? 100 : 0;

            // シート情報をバンドル
            pnouseflg = BundleSheetInfo(db, ref sheet, ref condition, workSeq, rptID, yosikiID, reportType, searchDic, detailSearchDic, orderByList, memo, sessionseq, reguserid, regsisyo, "", false, false, hasUpdHassoRireki);

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

            //フォントファイル設定
            ArGlobal.EUDCFiles = DaEucCacheService.GetEUDCFiles(db);
            //帳票作成
            var result = AiReport.MakeReport(db.Session, sheet, condition);

            //データ無しの場合、継続処理無し
            if (!isBlank && result.Error == ArEnumError.NoData)
            {
                result.ErrorCode = リターンNO_DATA;
                return result;
            }

            //処理終了
            DateTime syoridttmt = DaUtil.Now;

            //帳票出力履歴テーブルに登録
            OutPutHistoryInfo(db, rptID, yosikiID, reportType, searchDic, memo, sessionseq, reguserid, result, syoridttmf, syoridttmt, outputInfoDic);

            //宛名番号操作ログに出力
            if (db.tm_eurpt.SELECT.WHERE.ByKey(rptID).GetDto().atenaflg)
            {
                OutPutAtenaOperatedInfo(db, rptID, yosikiID, searchDic, detailSearchDic, orderByList, workSeq, sessionseq, reguserid, pnouseflg, syoridttmt);
            }

            //実行後SQL実施を行う
            if (hasUpdateSql)
            {
                result.MsgUpdateSQL = UpdateSQL(db, rptID, yosikiID, workSeq, reportType, searchDic, reguserid, regsisyo, condition, hasUpdHassoRireki);
            }

            return result;
        }

        /// <summary>
        /// CSV出力
        /// </summary>
        public static ArResult MakeCSV(DaDbContext db, string workSeq, string rptID, string yosikiID, Dictionary<string, object> csvFmtDic, string csvPattern,
            Dictionary<string, object> searchDic, Dictionary<string, object> detailSearchDic, List<string> orderByList, string memo, string sessionseq,
            string reguserid, string? regsisyo, bool hasUpdateSql = false, bool isBlank = false, bool hasConditionSheet = false, bool hasUpdHassoRireki = false)
        {
            //必須パラメータチェックを行う
            if (string.IsNullOrWhiteSpace(sessionseq) || string.IsNullOrWhiteSpace(reguserid))
            {
                throw new ArgumentException("必須パラメータ[セッションシーケンス]、[ユーザーID]の値をご確認ください。");
            }

            //個人番号操作フラグ
            bool pnouseflg = false;

            //処理開始
            DateTime syoridttmf = DaUtil.Now;

            //シート定義情報
            var sheet = new ArSheetDef();

            //条件情報
            var condition = new ArConditionModel();

            //シート情報をバンドル
            pnouseflg = BundleSheetInfo(db, ref sheet, ref condition, workSeq, rptID, yosikiID, EnumReportType.CSV, searchDic, detailSearchDic, orderByList, memo, sessionseq, reguserid, regsisyo, csvPattern, true, false, hasUpdHassoRireki);

            //CSVフォーマット設定
            condition.CsvOption.OutputHeader = (bool)csvFmtDic[CONDITION_OUTPUTHEADER];
            condition.CsvOption.BOM = (bool)csvFmtDic[CONDITION_BOM];
            if (csvFmtDic.ContainsKey(CONDITION_QUOTATION) && csvFmtDic[CONDITION_QUOTATION] != null && !string.IsNullOrEmpty(csvFmtDic[CONDITION_QUOTATION].ToString()))
            {
                if (Enum.TryParse<ArEnumQuotation>(csvFmtDic[CONDITION_QUOTATION].ToString(), out var quotation))
                {
                    condition.CsvOption.Quotation = quotation;
                }
                else
                {
                    condition.CsvOption.Quotation = ArEnumQuotation.Double;
                }
            }
            condition.CsvOption.Encoding = (ArEnumEncoding)csvFmtDic[CONDITION_ENCODING];

            // 空白PDF
            condition.IsBlank = isBlank;
            // 条件シート出力
            condition.OutputConditionSheet = hasConditionSheet;
            var result = new ArResult();
            try
            {
                //CSV作成
                result = AiReport.GetCSV(db.Session, sheet, condition);

                //データ無しの場合、継続処理無し
                if (!isBlank && result.Error == ArEnumError.NoData)
                {
                    result.ErrorCode = リターンNO_DATA;
                    return result;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            //処理終了
            DateTime syoridttmt = DaUtil.Now;
            var outputInfoDic = new Dictionary<string, object>();
            //ファイル名
            outputInfoDic.Add(DaEucService.CONDITION_FILE_NM, csvFmtDic[DaEucService.CONDITION_FILE_NM]);
            // 帳票出力履歴テーブルに登録
            OutPutHistoryInfo(db, rptID, yosikiID, EnumReportType.CSV, searchDic, memo, sessionseq, reguserid, result, syoridttmf, syoridttmt, outputInfoDic);

            // 宛名番号操作ログに出力
            if (db.tm_eurpt.SELECT.WHERE.ByKey(rptID).GetDto().atenaflg)
            {
                OutPutAtenaOperatedInfo(db, rptID, yosikiID, searchDic, detailSearchDic, orderByList, workSeq, sessionseq, reguserid, pnouseflg, syoridttmt);
            }

            //実行後SQL実施を行う
            if (hasUpdateSql)
            {
                result.MsgUpdateSQL = UpdateSQL(db, rptID, yosikiID, workSeq, EnumReportType.CSV, searchDic, reguserid, regsisyo, condition, hasUpdHassoRireki);
            }

            return result;
        }

        /// <summary>
        /// ワークテーブルを作成
        /// </summary>
        public static int MakeWorkTable(DaDbContext db, string tokenID, string rptID, string yosikiID, Dictionary<string, object> searchDic,
            Dictionary<string, object> detailSearchDic, List<string> orderByList)
        {

            //宛名ワークテーブル情報取得
            var wkAtena = db.wk_euatena.SELECT.WHERE.ByItem(nameof(wk_euatenaDto.token), tokenID).GetDtoList().OrderBy(e => e.workseq).ToList();

            //宛名ワークテーブル情報チェック
            if (wkAtena == null || wkAtena.Count == 0)
            {
                throw new Exception("該当トークンIDの宛名ワークテーブル情報が存在しません");
            }

            //ワークシーケンス
            var strWorkseq = wkAtena[wkAtena.Count - 1].workseq.ToString();

            //シート定義情報
            var sheet = new ArSheetDef();

            //条件情報
            var condition = new ArConditionModel();

            //シート情報をバンドル
            BundleSheetInfo(db, ref sheet, ref condition, strWorkseq, rptID, yosikiID, EnumReportType.その他, searchDic, detailSearchDic, orderByList, "", "", "", "", "", false, true, false);

            //ワークテーブル作成
            return MakeWorkTable(db, strWorkseq, rptID, ref condition, sheet);
        }

        /// <summary>
        /// ワークテーブル作成
        /// </summary>
        private static int MakeWorkTable(DaDbContext db, string strWorkseq, string rptID, ref ArConditionModel condition,ArSheetDef sheet)
        {
            //過去データ削除 
            string sql = $"DELETE FROM wk_euatena_sub WHERE workseq = {strWorkseq} or workseq in (SELECT workseq FROM wk_euatena WHERE jikoymd < '{DateTime.Today.ToString("YYYY-MM-DD")}')";
            db.Session.Execute(sql);
            sql = $"DELETE FROM wk_euatena WHERE jikoymd < '{DateTime.Today.ToString("YYYY-MM-DD")}'";
            db.Session.Execute(sql);

            // 宛名ワークテーブル作成
            condition.isDistinct = true;
            //EUC帳票マスタ
            var rpt = db.tm_eurpt.SELECT.WHERE.ByKey(rptID).GetDto();

            int ret;
            //妊産婦フラグ
            if (rpt.ninsanpuflg)
            {
                //妊産婦ワークテーブル
                sql = $"DELETE FROM wk_euninsanpu_sub WHERE workseq = {strWorkseq} or workseq in (SELECT workseq FROM wk_euatena WHERE jikoymd < '{DateTime.Today.ToString("YYYY-MM-DD")}')";
                db.Session.Execute(sql);

                // 妊産婦ワークテーブル作成
                condition.PreSql = @"INSERT INTO wk_euninsanpu_sub (workseq, atenano, torokuno) ";
                ret = AiReport.MakeWorkTable(db.Session, sheet, condition);
                if (ret < 0)
                {
                    throw new Exception("妊産婦ワークテーブル作成が失敗した");
                }

                // 宛名ワークテーブル作成
                sql = $@"INSERT INTO wk_euatena_sub --宛名WKテーブル
                            SELECT
                            DISTINCT
                                {strWorkseq},                      --ワークシーケンス
                                W1.atenano,               --宛名番号
                                true,                     --出力フラグ
                                false,                    --対象外者フラグ
                                false                     --対象外出力可能フラグ
                            FROM
                                wk_euninsanpu_sub W1 --妊産婦WKテーブル
                            WHERE
                                W1.workseq = {strWorkseq}";
                ret = DaDbUtil.RunSql(db, sql);
                if (ret < 0)
                {
                    throw new Exception("宛名ワークテーブル作成が失敗した");
                }
            }
            else
            {
                // 宛名ワークテーブル作成
                condition.PreSql = @"INSERT INTO wk_euatena_sub (workseq, atenano, formflg, taisyoflg, taisyooutflg) ";
                ret = AiReport.MakeWorkTable(db.Session, sheet, condition);
                if (ret < 0)
                {
                    throw new Exception("宛名ワークテーブル作成が失敗した");
                }
            }
            return ret;
        }

        /// <summary>
        /// ワークシーケンス取得
        /// </summary>
        public static long GetWorkSeq(DaDbContext db, string tokenID, bool batchflg = false)
        {
            var maxWorkSeq = db.wk_euatena.SELECT.WHERE.ByItem(nameof(wk_euatenaDto.token), tokenID).GetMax<long>(nameof(wk_euatenaDto.workseq));

            if (maxWorkSeq > 0) return maxWorkSeq;

            // 宛名ワークテーブル情報チェック
            // 自動登録する
            var dto = new wk_euatenaDto
            {
                token = tokenID, //トークン
                jikoymd = DaUtil.Now.ToString("yyyy-MM-dd"), //作成日
                batflg = batchflg //バッチフラグ
            };
            db.wk_euatena.INSERT.Execute(dto);
            maxWorkSeq = dto.workseq;

            // ワークシーケンス
            return maxWorkSeq;
        }

        /// <summary>
        /// シート情報をバンドル
        /// </summary>
        private static bool BundleSheetInfo(DaDbContext db, ref ArSheetDef sheet, ref ArConditionModel condition, string workSeq, string rptID, string yosikiID, EnumReportType reportType, Dictionary<string, object> searchDic,
            Dictionary<string, object> detailSearchDic, List<string> orderByList, string memo, string sessionseq, string reguserid, string? regsisyo, string csvPattern, bool isCsvFlg, bool isMakeWorkFLg, bool hasUpdHassoRireki, TransData? paramData = null)
        {
            condition.searchDic = searchDic;
            DaSystemParameterManager SysParaManger = new DaSystemParameterManager(db, workSeq, rptID, yosikiID, reportType, reguserid, regsisyo, isMakeWorkFLg, hasUpdHassoRireki, condition);

            //個人番号操作フラグ
            bool pnouseflg = false;

            //Sheet定義
            var rpt = db.tm_eurpt.SELECT.WHERE.ByKey(rptID).GetDto();
            var rptSheet = db.tm_euyosiki.SELECT.WHERE.ByKey(rptID, yosikiID).GetDto();

            if (rptSheet == null)
            {
                rptSheet = new tm_euyosikiDto();
            }

            var rptSubSheets = db.tm_euyosikisyosai.SELECT.WHERE.ByKey(rptID, yosikiID).GetDtoList().OrderBy(e => e.yosikieda).ToList();

            // 出力様式がないの場合
            if (rptSubSheets.Count == 0)
            {
                var newTmeuyosikisyosaiDto = new tm_euyosikisyosaiDto();
                if (!String.IsNullOrEmpty(rpt.procnm))
                {
                    newTmeuyosikisyosaiDto.yosikihouhou = Enum様式作成方法.プロシージャ;
                }
                else
                {
                    newTmeuyosikisyosaiDto.yosikihouhou = Enum様式作成方法.データソース;
                }
                newTmeuyosikisyosaiDto.yosikinm = "試験用";
                newTmeuyosikisyosaiDto.sql = "";
                rptSubSheets.Add(newTmeuyosikisyosaiDto);
            }

            // すべての条件
            var rptWheres = new List<tm_eurptkensakuDto>();
            var dataWheres = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKey(rpt.datasourceid!).GetDtoList().ToList();
            var kensakuList = db.tm_eurptkensaku.SELECT.WHERE.ByItem(nameof(tm_eurptkensakuDto.rptid), rptID).GetDtoList().ToList();

            // 追加条件
            var dsNulldatas = kensakuList.Where(x => x.datasourceid is null && x.jyokenkbn == EnumToStr(Enum検索条件区分.通常条件)).ToList();
            // 固定条件
            var fixedJyokenData = kensakuList.Where(x => x.datasourceid is not null && (x.jyokenkbn == EnumToStr(Enum検索条件区分.固定条件))).ToList();
            // 通常条件
            var commonData = kensakuList.Where(x => x.datasourceid is not null && (x.jyokenkbn == EnumToStr(Enum検索条件区分.通常条件))).ToList();
            if (commonData.Count > 0 && searchDic.Count > 0)
            {
                //値が空ではないページ条件に一致する同じデータ
                commonData = commonData.Where(x => searchDic.ContainsKey(x.jyokenlabel!)).ToList();
            }
            commonData.AddRange(fixedJyokenData);
            // 通常条件と固定条件を横断する
            foreach (var vm in commonData)
            {
                var data = dataWheres.FirstOrDefault(rpt => rpt.datasourceid == vm.datasourceid && rpt.jyokenid == vm.jyokenid);
                if (data != null)
                {
                    CopyData(vm, data);
                }
            }

            rptWheres.AddRange(commonData);
            rptWheres.AddRange(dsNulldatas);
            // 処理の前提条件
            var zenteiJokeys = dataWheres.Where(x => x.jyokenkbn == Enum検索条件区分.前提条件).ToList();
            foreach (var vm in zenteiJokeys)
            {
                rptWheres.Add(CreateNewRpt(vm, rptID));
            }
            //文字列のデータをString型に変換する
            foreach (var kvp in searchDic)
            {
                string key = kvp.Key;
                object value = kvp.Value;
                if (value != null)
                {
                    var kensakuDto = rptWheres.FirstOrDefault(rpt => key.Equals(rpt.jyokenlabel));
                    if (kensakuDto != null && kensakuDto.datatype != null && kensakuDto.controlkbn != null)
                    {
                        //サポートされていないタイプ
                        if (IsInvalidCombination((EnumDataType)kensakuDto.datatype!, (Enumコントロール)kensakuDto.controlkbn!))
                        {
                            var errorMeg = DaMessageService.GetMsg(EnumMessage.E003008, "データタイプ", "コントロール");
                            throw new Exception(errorMeg);
                        }
                        //データ型の検証
                        if ((EnumDataType)kensakuDto.datatype != EnumDataType.文字列)
                        {
                            if (!IsValidCombination((EnumDataType)kensakuDto.datatype!, (Enumコントロール)kensakuDto.controlkbn!, value.ToString()))
                            {
                                var errorMeg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"初期値{value}の種類");
                                throw new Exception(errorMeg);
                            }
                        }

                        if ((int)EnumDataType.整数 == kensakuDto.datatype || (int)EnumDataType.小数 == kensakuDto.datatype)
                        {
                            // 数字列に変換
                            if (double.TryParse(kvp.Value.ToString(), out double doubleValue))
                            {
                                searchDic[key] = doubleValue;
                            }
                            else if (int.TryParse(kvp.Value.ToString(), out int intValue))
                            {
                                searchDic[key] = intValue;
                            }
                            else
                            {
                                throw new Exception("入力が正しくありません。" + key + "は数値型です。再入力してください。");
                            }
                        }
                    }
                }
            }

            var rptItems = db.tm_eurptitem.SELECT.WHERE.ByKey(rptID, yosikiID).GetDtoList().OrderBy(e => e.orderseq).ToList();
            if (EnumReportType.PDF.Equals(reportType) || EnumReportType.PREVIEW.Equals(reportType) || EnumReportType.EXCEL.Equals(reportType))
            {
                //ファイル
                var fileData = rptSheet.templatefiledata;
                //var fileName = Path.Combine(Path.Combine(Environment.CurrentDirectory, "App_Data"), @"Test\事業実施報告書.xlsx"); //テスト用
                //sheet.TemplateFullPath = fileName;                              //テスト用
                //sheet.SheetName = AiReport.GetSheetName(sheet.TemplateFullPath); //テスト用
                var tempFilePath = Path.GetTempFileName();           //本番用
                var rptFilenm = $@"{rptSheet.templatefilenm}.xlsx"; //本番用
                var fileName = Path.Combine(Path.GetDirectoryName(tempFilePath)!, rptFilenm); //本番用
                fileName= ArFileUtil.ChangFileName(fileName);
                File.Delete(tempFilePath);                        //本番用
                File.WriteAllBytes(fileName, fileData);           //本番用
                sheet.TemplateData = fileData;                    //本番用
                sheet.TemplateFullPath = fileName;                //本番用
                sheet.SheetName = AiReport.GetSheetName(sheet.TemplateFullPath);
                //sheet.PageSize = rptSheet.pagesize.HasValue ? rptSheet.pagesize.Value : 1; //TODO
                //sheet.ReportName = rpt.rptnm;
                sheet.IsLandscape = rptSheet.landscape.HasValue ? rptSheet.landscape.Value : false;
                //用紙サイズ(ディフォルト値：A4)
            }
            else if (EnumReportType.CSV.Equals(reportType))
            {
                var tempFileName = Path.GetTempFileName();
                sheet.ReportName = Path.GetFileNameWithoutExtension(tempFileName) + CONST_XLSX_EXTENSION;
            }
            //特殊編集
            condition.ReportId = rpt.rptid;
            condition.ReportName = rpt.rptnm;
            //condition.UserNm = string.Empty;
            condition.PaperKind = rptSheet.pagesize.HasValue ? (EnumPaperKind)rptSheet.pagesize.Value : EnumPaperKind.A4;
            //シート定義情報を組み立てる
            foreach (var rptSubSheet in rptSubSheets)
            {
                var subSheet = GetSubSheetDef(ref condition, rptSheet, rptSubSheet);
                var subSheetBase = (ArSheetDefBase)subSheet;
                subSheetBase.IsNullToZero = rptSubSheet.nulltozeroflg;
                subSheetBase.IsMain = rptSubSheet.yosikieda == 0;
                subSheetBase.IsLandscape = sheet.IsLandscape;
                condition.isDistinct = rptSubSheet.distinctflg;
                if (string.IsNullOrWhiteSpace(sheet.SheetName))
                {
                    subSheet.Name = rptSubSheet.yosikinm;
                }
                else
                {
                    subSheet.Name = sheet.SheetName;
                }
                sheet.SubSheetDefs.Add(subSheet);

                //データソースにより、SWL文作成
                switch (rptSubSheet.yosikihouhou)
                {
                    case Enum様式作成方法.データソース:
                        {
                            condition.SystemParameterDic = SysParaManger.GetSystemParameterDic();

                            var datasourceId = !string.IsNullOrEmpty(rptSubSheet.datasourceid) ? rptSubSheet.datasourceid : rpt.datasourceid;
                            if (string.IsNullOrWhiteSpace(datasourceId)) throw new ArgumentException();

                            var dataEngine = (ArSmartEngineBase)GetSmartEngine(rpt, rptSubSheet);
                            subSheet.Engine = (IArEngine)dataEngine;
                            var rlt = new ArRelationDef();
                            dataEngine.RelationDef = rlt;
                            var eudatasource = DaEucCacheService.GetTm_eudatasourceByDataSourceID(db, datasourceId);
                            condition.DetailSearch = GetDetailSql(detailSearchDic);

                            //Select文組み立て
                            pnouseflg = SetSelectInfo(db, ref dataEngine, paramData, rptSubSheet, rptItems, ref subSheetBase, rpt, yosikiID, reportType, csvPattern, eudatasource, workSeq, isMakeWorkFLg, searchDic, rptSheet, reguserid, SysParaManger);


                            bool shouldSetWhereInfo = false;
                            if (rptWheres.Count > 0 && searchDic.Count > 0)
                            {
                                shouldSetWhereInfo = true;
                            }
                            else if (searchDic.Count == 0)
                            {
                                // 出力時に条件が入力されていない場合の条件付きフィルタリング（取得前提条件，固定条件）
                                rptWheres = rptWheres.Where(x => x.jyokenkbn == EnumToStr(Enum検索条件区分.前提条件) || x.jyokenkbn == EnumToStr(Enum検索条件区分.固定条件)).ToList();
                                if (rptWheres.Count > 0)
                                {
                                    shouldSetWhereInfo = true;
                                }
                            }

                            // Where文構成
                            if (shouldSetWhereInfo)
                            {
                                SetWhereInfo(db, ref dataEngine, ref condition, rptWheres, searchDic, ref subSheetBase, datasourceId);
                            }

                            //Join文組み立て
                            var isDetailSearch = detailSearchDic.Count > 0;
                            SetJoinInfo(db, ref rlt, eudatasource, ref dataEngine, ref subSheetBase, datasourceId, workSeq, rpt.atenaflg, isMakeWorkFLg, isDetailSearch);
                        }
                        break;

                    case Enum様式作成方法.SQL:
                        {
                            var engine = new ArSQLEngine();
                            subSheet.Engine = engine;
                            engine.SQL = rpt.sql!;
                        }
                        break;

                    case Enum様式作成方法.プロシージャ:
                        {
                            var engine = (ArSPEngine)GetSmartEngine(rpt, rptSubSheet);
                            subSheet.Engine = engine;
                            var procnm = rpt.procnm!;

                            //プロシージャのパラメータ値を取得
                            List<object> parValues = GetProcParValue(db, searchDic, SysParaManger, rptWheres, procnm);
                            engine.SP = $" {procnm} ({string.Join(",", parValues)}) ";

                            var maintablealias = "SP";

                            var rlt = new ArRelationDef();
                            rlt.MainTableID = maintablealias;
                            rlt.MainTableName = engine.SP;
                            if (rpt.atenaflg)
                            {
                                //詳細検索条件
                                condition.DetailSearch = GetDetailSql(detailSearchDic);

                                //Join文組み立て
                                rlt.TableRelations = GetProcJoinInfo(workSeq, maintablealias, isMakeWorkFLg);

                                // 詳細検索条件ある場合
                                if (!string.IsNullOrEmpty(condition.DetailSearch))
                                {
                                    //宛名テーブル
                                    var relation = new ArTableRelationDef();
                                    relation.IsLeftJoin = false;
                                    relation.TableID = tt_afatenaDto.TABLE_NAME;
                                    relation.TableName = tt_afatenaDto.TABLE_NAME;
                                    relation.RefTableID = maintablealias;
                                    relation.JoinString = $@" {maintablealias}.{nameof(tt_afatenaDto.atenano)} = {tt_afatenaDto.TABLE_NAME}.{nameof(tt_afatenaDto.atenano)} ";
                                    rlt.TableRelations.Add(relation);
                                }
                            }
                            engine.RelationDef = rlt;

                            if (isMakeWorkFLg)
                            {
                                // Selectワークテーブル文組み立て
                                engine.ItemDefs = GetSelectItemMakeWorkInfo(workSeq, maintablealias, rpt);
                            }
                            else if (paramData != null && EnumMakeWorkKbn.宛名番号ログ.Equals(paramData.workKbn))
                            {
                                //Select宛名番号ログ文組み立て
                                engine.ItemDefs = GetSelectAtenaLogInfo(maintablealias, paramData);
                            }
                            else
                            {
                                //項目一覧
                                var itemDefs = new List<ArItemDef>();
                                //ソース順項目一覧
                                var sortItemDefs = new List<ArItemDef>();
                                pnouseflg = SetSelectSubInfo(db, ref itemDefs, ref sortItemDefs, rptSubSheet, rptItems, ref subSheetBase, rptID, yosikiID, reportType, csvPattern, searchDic, rptSheet, reguserid, SysParaManger);
                                SetProcItems(ref itemDefs, maintablealias);
                                //項目一覧
                                engine.ItemDefs = itemDefs.OrderBy(e => e.Seq).ToList();
                                //ソース順項目一覧
                                engine.SortItemDefs = sortItemDefs;
                            }

                            //Select項目チェック
                            if (engine.ItemDefs.Count == 0)
                            {
                                throw new Exception("SELECT項目が存在しません");
                            }
                        }
                        break;
                }

                if (EnumReportType.PDF.Equals(reportType) || EnumReportType.PREVIEW.Equals(reportType) || EnumReportType.EXCEL.Equals(reportType))
                {
                    DaSpecialItemManager manager = new DaSpecialItemManager(db, rptID, yosikiID, condition);
                    if (rptSubSheet.yosikieda == 0) sheet.ReportName = rptSubSheet.yosikinm;

                    if (!subSheet.Engine.IsCross)
                    {
                        manager.Items = manager.Items.Where(e => !e.IsCross).ToList();
                    }

                    condition.SpecialItemDic = manager.GetSpecialItemDic();

                    //特殊項目情報
                    //foreach (var searchItem in searchDic)
                    //{
                    //    //発行日_和暦
                    //    if (Enum.GetName(typeof(ArEnumSpecialItem), ArEnumSpecialItem.発行日_和暦)!.Equals(searchItem.Key))
                    //    {
                    //        condition.SpecialItemDic[ArEnumSpecialInputItem.発行日_和暦] = searchItem.Value;
                    //    }

                    //    //出力日_和暦
                    //    if (Enum.GetName(typeof(ArEnumSpecialItem), ArEnumSpecialItem.出力日_和暦)!.Equals(searchItem.Key))
                    //    {
                    //        condition.SpecialItemDic[ArEnumSpecialInputItem.出力日_和暦] = searchItem.Value;
                    //    }
                    //}

                    ////自治体情報（1001-1-01）
                    //condition.SpecialItemDic[ArEnumSpecialInputItem.自治体名] = DaEucCacheService.Gettm_afhanyoInfo(db, CONST_HANYOMAINCD_1001, CONST_HANYOSUBCD_1, CONST_HANYOCD_01);

                    ////課名（1001－2）
                    //condition.SpecialItemDic[ArEnumSpecialInputItem.課名] = DaEucCacheService.Gettm_afhanyoInfo(db, CONST_HANYOMAINCD_1001, CONST_HANYOSUBCD_2, rptSheet.kacd);

                    ////係名（1001－3）
                    //condition.SpecialItemDic[ArEnumSpecialInputItem.係名] = DaEucCacheService.Gettm_afhanyoInfo(db, CONST_HANYOMAINCD_1001, CONST_HANYOSUBCD_3, rptSheet.kakaricd);

                    ////問い合わせ内容コード（1001ー4）)
                    //condition.SpecialItemDic[ArEnumSpecialInputItem.問い合わせ先] = DaEucCacheService.Gettm_afhanyoInfo(db, CONST_HANYOMAINCD_1001, CONST_HANYOSUBCD_4, rptSheet.toiawasesakicd);

                    //テンプレート終了行
                    subSheetBase.TemplateInfo.EndRowIndex = rptSheet.endrow.HasValue ? rptSheet.endrow.Value : 60;
                    //subSheetBase.PageSize = sheet.PageSize;

                    if (rptSubSheet.startrow != null && subSheetBase.TemplateInfo != null)
                    {
                        //明細開始行№
                        subSheetBase.TemplateInfo.DetailStartRowIndex = rptSubSheet.startrow.HasValue ? (int)rptSubSheet.startrow : 0;
                        //明細行数（行間のRow数）
                        subSheetBase.TemplateInfo.DetailRowCount = rptSubSheet.looprow.HasValue ? (int)rptSubSheet.looprow : 1;
                        //明細の最大行数
                        subSheetBase.TemplateInfo.DetailMaxRows = rptSubSheet.loopmaxrow.HasValue ? (int)rptSubSheet.loopmaxrow : 1;
                        //明細開始列№
                        subSheetBase.TemplateInfo.DetailStartColumnIndex = rptSubSheet.startcol.HasValue ? (int)rptSubSheet.startcol : 0;
                        //明細列数（列間のColumn数）
                        subSheetBase.TemplateInfo.DetailColumnCount = rptSubSheet.loopcol.HasValue ? (int)rptSubSheet.loopcol : 1;
                        //明細の最大列数
                        subSheetBase.TemplateInfo.DetailMaxColumns = rptSubSheet.loopmaxcol.HasValue ? (int)rptSubSheet.loopmaxcol : 1;
                    }
                }
                if (isCsvFlg || isMakeWorkFLg) break;
            }
            return pnouseflg;
        }


        /// <summary>
        /// サポートされていない組み合わせ
        /// </summary>
        public static bool IsInvalidCombination(EnumDataType datatype, Enumコントロール controlkbn)
        {
            if (datatype == EnumDataType.文字列)
            {
                // 文字列の場合、どのcontrolkbnも有効とする
                return false;
            }

            if ((datatype == EnumDataType.整数 || datatype == EnumDataType.小数)
                && (controlkbn != Enumコントロール.数値入力
                && controlkbn != Enumコントロール.数値範囲
                && controlkbn != Enumコントロール.文字入力
                && controlkbn != Enumコントロール.年度))
            {
                return true;
            }

            if ((datatype == EnumDataType.日付 || datatype == EnumDataType.時間) &&
                (controlkbn != Enumコントロール.文字入力 && controlkbn != Enumコントロール.日付入力 && controlkbn != Enumコントロール.日付範囲
                && controlkbn != Enumコントロール.時間範囲 && controlkbn != Enumコントロール.時間入力 && controlkbn != Enumコントロール.年度))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 種類の判断します
        /// </summary>
        public static bool IsValidCombination(EnumDataType datatype, Enumコントロール controlkbn, string syokiti)
        {
            switch (datatype)
            {
                case EnumDataType.整数:
                case EnumDataType.小数:
                    return controlkbn == Enumコントロール.文字入力 || controlkbn == Enumコントロール.数値範囲 ||
                           controlkbn == Enumコントロール.数値入力 || controlkbn == Enumコントロール.年度
                           ? IsParameterValid(datatype, syokiti)
                           : false;

                case EnumDataType.日付:
                    return controlkbn == Enumコントロール.文字入力
                           ? IsParameterValid(datatype, syokiti)
                           : true;

                default:
                    return true;
            }
        }

        /// <summary>
        /// 種類の判断します
        /// </summary>
        public static bool IsParameterValid(EnumDataType? dataType, string parameterValue)
        {
            switch (dataType)
            {
                case EnumDataType.整数:
                    return int.TryParse(parameterValue, out _);
                case EnumDataType.小数:
                    return double.TryParse(parameterValue, out _);
                case EnumDataType.日付:
                    return DateTime.TryParse(parameterValue, out _);
                case EnumDataType.時間:
                    return TimeSpan.TryParse(parameterValue, out _);
                case EnumDataType.フラグ:
                    return bool.TryParse(parameterValue, out _);
                case EnumDataType.文字列:
                    return parameterValue.Contains(" '") || parameterValue.Contains("'");
                default:
                    return false;
            }
        }

        /// <summary>
        /// メインテーブル下のすべて関連テーブルを取り出す
        /// </summary>
        public static List<string> GetAllJoinTables(DaDbContext db, string mainTable)
        {
            List<string> allTables = new List<string>();
            var joinTable = DaEucCacheService.GetEutablejoinDtoList(db);
            allTables.Add(mainTable);
            GetSubTables(joinTable, mainTable, allTables);
            return allTables;
        }

        /// <summary>
        /// tm_eutableitemのチェック
        /// </summary>
        public static string CheckEuTableItem(DaDbContext db, string errFile = null)
        {
            if (errFile != null)
            {
                File.Delete(errFile);
            }
            var itemDtl = DaEucCacheService.GetEutableitemDtoList(db);
            bool hasError = false;
            StringBuilder sb = new StringBuilder();
            foreach (var item in itemDtl)
            {
                var ret = CheckItemSQL(db, item.sqlcolumn);
                if (ret != null)
                {
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
                if (item.itemhyojinm == "宛名番号" && item.itemkbn != Enum出力項目区分.宛名番号)
                {
                    ret = $"「{item.sqlcolumn}」について、宛名番号で項目区分は２になっていません。";
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
                if (item.itemhyojinm == "個人番号" && item.itemkbn != Enum出力項目区分.個人番号)
                {
                    ret = $"「{item.sqlcolumn}」について、個人番号で項目区分は3になっていません。";
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
                //if (item.itemhyojinm == "個人番号" && item.itemkbn != Enum出力項目区分.個人番号)
                //{
                //    ret = $"「{item.sqlcolumn}」について、個人番号で使用区分は3になっていません。";
                //    if (errFile == null) return ret;else { hasError = true; sb.AppendLine(ret); }
                //}
                if (item.itemhyojinm == "宛名番号" && item.syukeikbn != "2")
                {
                    ret = $"「{item.sqlcolumn}」について、宛名番号で集計区分は2になっていません。";
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
                if ((item.usekbn == Enum使用区分.併用 || item.usekbn == Enum使用区分.集計項目) && string.IsNullOrEmpty(item.syukeikbn))
                {
                    ret = $"「{item.sqlcolumn}」について、使用区分は併用で、集計区分は空白になっていません。";
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
                if (item.tablealias2 == tt_afsofusakiDto.TABLE_NAME)
                {
                    ret = $"「{item.sqlcolumn}」について、送付先テーブルと直接結合しないので、「tablealias2」に「tt_afsofusaki」を設定してはいけません。";
                    if (errFile == null) return ret; else { hasError = true; sb.AppendLine(ret); }
                }
            }
            if (errFile != null)
            {
                File.WriteAllText(errFile, sb.ToString());
            }
            return (hasError) ? "NG" : "OK";
        }

        /// <summary>
        /// SQLColumn,検索条件SQLのチェック
        /// </summary>
        public static string? CheckItemSQL(DaDbContext db, string itemSql)
        {
            var tableDtl = DaEucCacheService.GetEutableDtoList(db);

            var itemlist = GetTableAndItem(itemSql);
            foreach (var item in itemlist)
            {
                var ss = item.Split('.');
                var alias = ss[0];
                var itemname = ss[1];
                var euTableinfo = tableDtl.Find(e => e.tablealias == alias);
                if (euTableinfo == null)
                {
                    return $"「{itemSql}」について、テーブル名または別名[{alias}]が[tm_eutable]に存在しません。";
                }
                var tablename = euTableinfo.tablenm;
                if (tablename.StartsWith("t"))
                {
                    var tables = AiGlobal.DbInfoProvider.GetTableList(db.Session);
                    if (!tables.Exists(e => e.TableName == tablename))
                    {
                        return $"「{itemSql}」について、[tm_eutable]テーブルにテーブル別名[{tablename}]が存在しません。";
                    }
                    var tableInfo = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, tablename);
                    var fieldInfo = tableInfo.FieldList.Find(e => e.FieldName == itemname);
                    if (fieldInfo == null)
                    {
                        return $"「{itemSql}」について、[{tablename}]テーブルに項目[{itemname}]が存在しません。";
                    }
                }

            }

            return null;
        }
        /// <summary>
        /// eudatasourcekensakuの情報Copy
        /// </summary>
        private static void CopyData(tm_eurptkensakuDto vm, tm_eudatasourcekensakuDto data)
        {
            vm.sql = data.sql;                                           //SQL
            vm.variables = CStr(data.variables);                         //変数名
            vm.tablealias = CStr(data.tablealias);                       //テーブル名
            vm.mastercd = CStr(data.mastercd);                           //名称マスタコード
            vm.masterpara = CStr(data.masterpara);                       //名称マスタパラメータ
            vm.sansyomotosql = CStr(data.sansyomotosql);                 //参照元SQL
            vm.nendohanikbn = data.nendohanikbn;                         //年度範囲区分
            vm.syokiti = data.syokiti;                                   //初期値
            vm.controlkbn = (int)data.controlkbn;                        //コントロール区分
            vm.aimaikbn = data.aimaikbn;                                 //曖昧検索区分
            vm.datatype = (int)data.datatype;                            //データ型
        }

        /// <summary>
        /// eurptkensakuの情報
        /// </summary>
        private static tm_eurptkensakuDto CreateNewRpt(tm_eudatasourcekensakuDto vm, string rptID)
        {
            return new tm_eurptkensakuDto
            {
                rptid = rptID,                                                       //帳票ID
                datasourceid = vm.datasourceid,                                      //データソースID
                jyokenlabel = vm.jyokenlabel,                                        //ラベル
                jyokenid = vm.jyokenid,                                              //条件ID
                jyokenkbn = EnumToStr(Enum検索条件区分.前提条件),                    //検索条件区分
                tablealias = vm.tablealias,                                          //テーブル別名
                variables = vm.variables,                                            //変数名
                mastercd = vm.mastercd,                                              //名称マスタコード
                masterpara = vm.masterpara,                                          //名称マスタパラメータ 
                sansyomotosql = vm.sansyomotosql,                                    //参照元SQL 
                sql = vm.sql,                                                        //SQL
                hissuflg = true,                                                     //必須フラグ
                controlkbn = (int)vm.controlkbn,                                     //コントロール区分
                datatype = (int)vm.datatype,                                         //データ型
                nendohanikbn = vm.nendohanikbn,                                      //年度範囲区分
                syokiti = vm.syokiti,                                                //初期値
                aimaikbn = vm.aimaikbn                                               //曖昧検索区分
            };
        }
    }

}