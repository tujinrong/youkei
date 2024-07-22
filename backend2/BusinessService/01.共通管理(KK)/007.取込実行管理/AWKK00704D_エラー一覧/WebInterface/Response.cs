// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行.エラー一覧
//             レスポンスインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00704D
{
    /// <summary>
    /// 初期処理
    /// </summary>
    public class InitListResponse : CmSearchResponseBase
    {
        public List<KimpErrRowVM> kimpErrList { get; set; } //取込データエラー情報リスト
    }
}