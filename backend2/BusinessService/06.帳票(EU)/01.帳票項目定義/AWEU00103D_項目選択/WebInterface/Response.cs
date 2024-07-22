// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目選択
//             レスポンスインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00103D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<TableItemVM> tableitemlist { get; set; }   //テーブル項目リスト
        public List<TableVM> nextbunruilist { get; set; }       //次の分類リスト
    }
}