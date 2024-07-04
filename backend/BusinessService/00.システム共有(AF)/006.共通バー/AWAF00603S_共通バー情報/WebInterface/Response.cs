// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 共通バー情報
//             レスポンスインターフェース
// 作成日　　: 2023.04.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00603S
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<InfoVM> kekkalist { get; set; }   //共通バー情報
    }
}