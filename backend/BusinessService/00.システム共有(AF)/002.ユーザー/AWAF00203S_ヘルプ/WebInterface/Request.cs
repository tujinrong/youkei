// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ヘルプ
//             リクエストインターフェース
// 作成日　　: 2023.02.24
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00203S
{
    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : DaRequestBase
    {
        public string kinoid { get; set; }   //機能ID
    }
}