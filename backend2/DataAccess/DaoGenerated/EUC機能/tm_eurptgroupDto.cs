// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             帳票グループマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptgroupDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eurptgroup";
		public string rptgroupid { get; set; }                    //帳票グループID
		public string rptgroupnm { get; set; }                    //帳票グループ名
		public string gyomukbn { get; set; }                      //業務区分
		public string? kojinrenrakusakicd { get; set; }           //個人連絡先
		public string? memocd { get; set; }                       //メモ情報（複数）
		public string? electronfilecd { get; set; }               //電子ファイル（複数）
		public string? followmanage { get; set; }                 //フォロー管理（複数）
		public int orderseq { get; set; }                         //並び順
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
