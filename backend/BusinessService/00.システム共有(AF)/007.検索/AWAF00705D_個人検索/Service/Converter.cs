// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人検索
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00705D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(SearchRequest.name)}_in", ToLikeStr(req.name)),                //氏名
                new AiKeyValue($"{nameof(SearchRequest.kname)}_in", ToKnameLikeStr(req.kname)),         //カナ氏名
                new AiKeyValue($"{nameof(SearchRequest.bymd)}_in", req.bymd),                           //生年月日
                new AiKeyValue($"{nameof(SearchRequest.sex)}_in", string.Join(',',req.sex)),            //性別
                new AiKeyValue($"{nameof(SearchRequest.juminkbn)}_in", string.Join(',',req.juminkbn)),  //住民区分
                new AiKeyValue($"{nameof(SearchRequest.hokenkbn)}_in", req.hokenkbn),                   //保険区分
            };

            return paras;
        }
    }
}