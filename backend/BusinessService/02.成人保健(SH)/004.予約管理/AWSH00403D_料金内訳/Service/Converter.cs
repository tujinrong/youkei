// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 料金内訳
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00403D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(int nendo,string atenano)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.nendo)}_in", nendo),        //年度
                new($"{nameof(SearchRequest.atenano)}_in", atenano)     //宛名番号
            };
            return paras;
        }
    }
}