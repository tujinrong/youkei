// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お気に入り
//             レスポンスインターフェース
// 作成日　　: 2023.01.19
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00303D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public Enumお気に入り区分 statuskbn { get; set; } // お気に入り状態
    }

    /// <summary>
    /// 検索処理/更新処理/保存処理
    /// </summary>
    public class CommonResponse : DaResponseBase
    {
        public List<string> kekkalist { get; set; } // 機能IDリスト
    }
}