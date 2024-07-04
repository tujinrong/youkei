// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業コード管理
//             リクエストインターフェース
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00805D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string cd { get; set; }  //設定対象コード(キー)
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : InitRequest
    {
        public SaveVM detailinfo { get; set; }  //集約コード情報
        public DateTime? upddttm1 { get; set; } //更新日時(排他用：個人連絡先)
        public DateTime? upddttm2 { get; set; } //更新日時(排他用：メモ情報)
        public DateTime? upddttm3 { get; set; } //更新日時(排他用：電子ファイル情報)
        public DateTime? upddttm4 { get; set; } //更新日時(排他用：フォロー管理)
    }
}