// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基幹系他システム情報照会
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00101G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(string atenano, int kazeinendo, int kojorirekino)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tt_afkojinzeikojo_rekiDto.atenano)}_in", atenano),            //宛名番号
                new($"{nameof(tt_afkojinzeikojo_rekiDto.kazeinendo)}_in", kazeinendo),      //課税年度
                new($"{nameof(tt_afkojinzeikojo_rekiDto.kojorirekino)}_in", kojorirekino)   //税額控除情報履歴番号
            };
            return paras;
        }
    }
}