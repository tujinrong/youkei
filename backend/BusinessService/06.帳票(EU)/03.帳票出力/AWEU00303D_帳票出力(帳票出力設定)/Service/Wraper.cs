// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(帳票出力設定)
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using BCC.Affect.BatchService.AWEU00303D;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00303D
{
    public class Wraper : CmWraperBase
    {
        private static readonly Dictionary<EnumReportType, EnumFileTypeKbn> OutputDictionary = new()
        {
            { EnumReportType.PDF, EnumFileTypeKbn.pdf },
            { EnumReportType.EXCEL, EnumFileTypeKbn.xlsx }
        };

        /// <summary>
        /// プレビュー処理
        /// </summary>
        public static string GetPreviewFileName(string? outputfilenm)
        {
            if(string.IsNullOrEmpty(outputfilenm))
            {
                return $"{DateTimeOffset.Now.ToUnixTimeMilliseconds()}{DaStrPool.C_DOT}{EnumFileTypeKbn.pdf}";
            }
            else
            {
                return outputfilenm.EndsWith($"{DaStrPool.C_DOT}{EnumFileTypeKbn.pdf}")
                    ? $"{outputfilenm}"
                    : $"{outputfilenm}{DaStrPool.C_DOT}{EnumFileTypeKbn.pdf}";
            }
        }

        /// <summary>
        /// ダウンロード処理
        /// </summary>
        public static string GetFileSuffixByOutputType(EnumReportType outputtype)
        {
            return $"{DaStrPool.C_DOT}{OutputDictionary.GetValueOrDefault(outputtype, EnumFileTypeKbn.pdf)}";
        }

        /// <summary>
        /// ダウンロード処理
        /// </summary>
        public static string GetFileNameNoSuffix(string fileName, string fileSuffix)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return DateTimeOffset.Now.ToUnixTimeMilliseconds().ToString();
            }
            if (!fileName.EndsWith(fileSuffix, StringComparison.OrdinalIgnoreCase))
            {
                return fileName;
            }
            var index = fileName.LastIndexOf(fileSuffix, StringComparison.OrdinalIgnoreCase);
            return fileName.Remove(index);
        }

        /// <summary>
        /// バッチ処理
        /// </summary>
        public static ParameterModel GetBatchParameter(BatchRequest req, bool nowFlg,long rirekiseq, string? jobId)
        {
            var pm = new ParameterModel();
            pm.workseq = nowFlg ? req.workseq : null;                                   //ワークシーケンス 
            pm.rptid = req.rptid;                                                       //帳票ID
            pm.yosikiid = req.yosikiid;                                                 //様式ID
            pm.memo = CStr(req.memo);                                                   //検索条件メモ
            pm.reporttype = req.outputtype;                                             //出力方式
            pm.searchdic = CommonUtil.GetSearchDict(req.jyokenlist, req.tyusyutuinfo);                    //検索条件
            pm.detaildearchdic = CommonUtil.GetDetailSearchDict(req.detailjyokenlist);  //詳細検索条件
            pm.orderbylist = CommonUtil.GetOrderByList();                               //ソート順
            pm.sessionseq = req.sessionid.ToString();                                   //セッションシーケンス
            pm.reguserid = req.userid;                                                  //登録ユーザID
            pm.regsisyo = req.regsisyo;                                                 //登録支所
            pm.hasupdatesql = req.sqljikkoflg;                                          //更新SQL
            pm.isblank = req.hakusiflg;                                                 //白纸
            pm.hasconditionsheet = req.jyokensheetflg;                                  //条件シートを出力
            pm.hasupdhassorireki = true;
            pm.outputInfoDic = CommonUtil.GetOutPutInfo(req.outPutInfo, req.outputfilenm, rirekiseq, jobId); //出力情報
            return pm;
        }
    }
}