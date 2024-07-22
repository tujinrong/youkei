// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業コード管理
//             レスポンスインターフェース
// 作成日　　: 2024.01.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00805D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public string nm { get; set; }                              //設定対象表示名称
        public SaveVM detailinfo { get; set; }                      //集約コード情報
        public List<DaSelectorModel> selectorlist { get; set; }     //集約コード一覧
        public DateTime? upddttm1 { get; set; }                     //更新日時(排他用：個人連絡先)
        public DateTime? upddttm2 { get; set; }                     //更新日時(排他用：メモ情報)
        public DateTime? upddttm3 { get; set; }                     //更新日時(排他用：電子ファイル情報)
        public DateTime? upddttm4 { get; set; }                     //更新日時(排他用：フォロー管理)
    }
}