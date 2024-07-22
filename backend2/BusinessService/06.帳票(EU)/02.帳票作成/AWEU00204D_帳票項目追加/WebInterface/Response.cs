// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票項目追加
//             レスポンスインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWEU00107D;

namespace BCC.Affect.Service.AWEU00204D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchNormalTreeResponse : DaResponseBase
    {
        public List<ItemTreeNode<ItemVM>> itemtree { get; set; } = new(); //項目ツリー
    }

    /// <summary>
    /// 集計項目検索処理
    /// </summary>
    public class SearchStatisticResponse : DaResponseBase
    {
        public List<BunruiItemVM> bunruilist { get; set; } //分類リスト
        public List<DaSelectorModel> syukeikbnlist { get; set; } //ドロップダウンリスト(集計項目区分)
    }
}