// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診結果・保健指導履歴照会
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.13
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00610D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tt_afatenaDto.atenano)}_in", req.atenano));    //宛名番号

            return paras;
        }
    }
}
