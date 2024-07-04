// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.ファイルアップロード
//             リクエストインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00702D
{
    /// <summary>
    /// アップロード処理
    /// </summary>
    public class UploadRequest : CmUploadRequestBase
    {
        public string impno { get; set; }       //一括取込入力No
        public string processKey { get; set; }  //処理キー
    }

    /// <summary>
    /// エラーファイル出力用
    /// </summary>
    public class ErrorDownloadRequest : DaRequestBase
    {
        public byte[] errorbytebuffer;  //エラー
    }
}