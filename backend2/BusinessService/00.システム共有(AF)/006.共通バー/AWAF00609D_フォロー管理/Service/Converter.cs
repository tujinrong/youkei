// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理(共通バー)
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.27
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00609D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(内容画面)
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchFollowNaiyoListRequest req, List<string> keyList)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.atenano)}_in", req.atenano));   //宛名番号
            paras.Add(new AiKeyValue($"{nameof(tt_kkfollownaiyoDto.haakujigyocd)}s_in", null));    //事業コード一覧(表示範囲)
            return paras;
        }
    }
}
