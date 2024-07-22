// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理(共通バー)
//             リクエストインターフェース
// 作成日　　: 2023.12.26
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00609D
{
    /// <summary>
    /// 検索処理(内容画面)
    /// </summary>
    public class SearchFollowNaiyoListRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }
}