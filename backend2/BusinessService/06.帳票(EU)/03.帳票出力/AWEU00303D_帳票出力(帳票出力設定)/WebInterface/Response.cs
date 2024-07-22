// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(帳票出力設定)
//             レスポンスインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00303D
{
    /// <summary>
    /// プレビュー処理
    /// </summary>
    public class ReportPreviewResponse : CmPreviewResponseBase
    {
        public int totalpagecount { get; set; }
    }
}