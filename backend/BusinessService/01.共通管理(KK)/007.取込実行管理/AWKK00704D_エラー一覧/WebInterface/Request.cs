// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.エラー一覧
//             リクエストインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00704D
{
    /// <summary>
    /// アップロード処理
    /// </summary>
    public class InitListRequest : CmSearchRequestBase
    {
        public int impexeid { get; set; }   //取込実行ID
    }

    /// <summary>
    /// エラー出力処理
    /// </summary>
    public class DownloadRequest : CmUploadRequestBase
    {
        public List<KimpErrRowVM> kimpErrList { get; set; } = new List<KimpErrRowVM>(); //取込データエラー情報リスト
    }
}