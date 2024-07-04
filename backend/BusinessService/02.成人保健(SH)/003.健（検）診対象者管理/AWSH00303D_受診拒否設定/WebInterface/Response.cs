// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 受診拒否設定
//             レスポンスインターフェース
// 作成日　　: 2024.02.06
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00303D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; } //受診拒否理由一覧
        public List<InitRowVM> kekkalist { get; set; }          //受診拒否理由情報一覧
    }
}