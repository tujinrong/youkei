// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種検診対象者保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.06
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00302G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータを取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(InitRequest req)
        {
            List<AiKeyValue> paras = new List<AiKeyValue>()
            {
                new AiKeyValue($"{nameof(InitRequest.nendo)}_in", req.nendo),       //年度
                new AiKeyValue($"{nameof(InitRequest.atenano)}_in", req.atenano)    //宛名番号
            };
            return paras;
        }
    }
}