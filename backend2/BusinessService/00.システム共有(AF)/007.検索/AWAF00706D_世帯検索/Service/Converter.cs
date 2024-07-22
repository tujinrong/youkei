// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 世帯検索
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00706D
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
                new AiKeyValue($"{nameof(SearchRequest.kname)}_in", ToKnameLikeStr(req.kname)),         //世帯主カナ氏名
                new AiKeyValue($"{nameof(SearchRequest.name)}_in", ToLikeStr(req.name)),                //世帯主氏名
                new AiKeyValue($"{nameof(SearchRequest.adrs_yubin)}_in", req.adrs_yubin),               //世帯郵便番号
                new AiKeyValue($"{nameof(SearchRequest.adrs)}_in", ToLikeStr(req.adrs)),                //世帯住所
            };

            return paras;
        }
    }
}