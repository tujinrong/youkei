// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ作成検索画面 
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00401G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            return new List<AiKeyValue>
            {
               new($"{nameof(SearchRequest.rptgroupid)}_in", req.rptgroupid), //帳票グループId
            };
        }
    }
}