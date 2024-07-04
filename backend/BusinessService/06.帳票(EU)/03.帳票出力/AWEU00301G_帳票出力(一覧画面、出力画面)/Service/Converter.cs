// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00301G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 一覧画面検索処理
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            var gyomukbn = string.IsNullOrEmpty(req.gyomukbn) ? null : req.gyomukbn.Split(DaConst.SELECTOR_DELIMITER)[0];
            var rptgroupid = string.IsNullOrEmpty(req.rptgroupid) ? null : req.rptgroupid.Split(DaConst.SELECTOR_DELIMITER)[0];
            var rptnm = string.IsNullOrEmpty(req.rptnm) ? null : $"%{req.rptnm}%";
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.gyomukbn)}_in", gyomukbn),      //業務区分
                new($"{nameof(SearchRequest.rptgroupid)}_in", rptgroupid),  //帳票グループID
                new($"{nameof(SearchRequest.rptnm)}_in", rptnm),            //帳票名
            };
        }

        /// <summary>
        /// 出力画面検索処理
        /// </summary>
        public static List<AiKeyValue> GetParameters(long workSeq, string rptGroupId, string tikukbnValue)
        {
            return new List<AiKeyValue>
            {
                new($"{nameof(wk_euatena_subDto.workseq)}_in", workSeq),        //ワークシーケンス
                new($"{nameof(tm_eurptgroupDto.rptgroupid)}_in", rptGroupId),   //帳票グループID
                new($"{nameof(tm_aftikuDto.tikukbn)}_in", tikukbnValue)         //地区区分
            };
        }
    }
}