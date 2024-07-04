// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行.ファイルアップロード処理
//             レスポンスインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00702D
{
    /// <summary>
    /// アップロード処理
    /// </summary>
    public class ExcelUploadResponse : DaResponseBase
    {
        public int impexeid { get; set; }           //取込実行ID(ファイルエラーがない場合は取得できる)
        public byte[] errorbytebuffer { get; set; } //エラーファイル出力用
    }
}