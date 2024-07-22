// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 医療機関検索
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00702D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req, List<string> keyList)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(SearchRequest.kikannm)}_in", ToLikeStr(req.kikannm)),              //医療機関名
                new AiKeyValue($"{nameof(SearchRequest.kanakikannm)}_in", ToKanaLikeStr(req.kanakikannm)),  //医療機関名カナ
                new AiKeyValue($"{nameof(SearchRequest.hokenkikancd)}_in", ToLikeStr(req.hokenkikancd)),    //保険医療機関コード
                new($"{nameof(tm_afkikan_subDto.jissijigyo)}s_in", string.Join(DaStrPool.C_COMMA,keyList)), //事業コード一覧(表示範囲)
                new($"{nameof(tm_afkikanDto.stopflg)}_in", req.hasStopFlg)                                  //使用停止sql
            };
            return paras;
        }
    }
}