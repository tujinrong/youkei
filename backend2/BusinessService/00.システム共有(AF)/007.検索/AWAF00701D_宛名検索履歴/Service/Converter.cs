// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 宛名検索履歴
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
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
                new AiKeyValue($"{nameof(SearchRequest.userid)}_in", req.userid),       //ユーザーID
                new AiKeyValue($"{nameof(SearchRequest.kinoid)}_in", ((DaRequestBase)req).kinoid), //機能ID
            };
            return paras;
        }

        /// <summary>
        /// 宛名番号検索履歴テーブル
        /// </summary>
        public static List<tt_afatenalogDto> GetDtl(SaveRequest req)
        {
            var dto = new tt_afatenalogDto();
            dto.userid = req.userid;           //ユーザーID
            dto.kinoid = req.kinoid;     //機能ID
            dto.atenano = req.atenano;         //宛名番号
            dto.syoridttm = DaUtil.Now;        //処理日時
            return new List<tt_afatenalogDto> { dto };
        }
    }
}