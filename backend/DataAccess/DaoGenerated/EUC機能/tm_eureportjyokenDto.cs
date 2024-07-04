// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUC帳票検索条件マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eureportjyokenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eureportjyoken";
		public int reportid { get; set; }                         //帳票ID
		public int groupid { get; set; }                          //グループID
		public int jyokenid { get; set; }                         //条件ID
		public bool requiredflg { get; set; }                     //必須フラグ
		public int seq { get; set; }                              //表示順
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
