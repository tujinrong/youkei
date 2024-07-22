// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 対象サイン
//             リクエストインターフェース
// 作成日　　: 2024.06.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00404D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public int nendo { get; set; }          //年度
        public string atenano { get; set; }     //宛名番号
        public int nitteino { get; set; }    //日程番号
    }
}
