// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.プロシージャ一覧画面
// 　　　　　　レスポンスインターフェース
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00608D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> procList { get; set; }    //プロシージャリスト
    }
}