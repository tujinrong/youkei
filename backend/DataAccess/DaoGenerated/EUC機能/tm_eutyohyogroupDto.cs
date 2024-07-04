// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             帳票グループマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutyohyogroupDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eutyohyogroup";
		public int reportgroupid { get; set; }                    //帳票グループID
		public string reportgroupnm { get; set; }                 //帳票グループ名
		public string renrakusakicd { get; set; }                 //個人連絡先
		public string? memocd { get; set; }                       //メモ情報（複数）
		public string? memoinfocd { get; set; }                   //世帯メモ情報（複数）
		public string? electronfilecd { get; set; }               //電子ファイル（複数）
		public string? followmanage { get; set; }                 //フォロー管理（複数）
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
