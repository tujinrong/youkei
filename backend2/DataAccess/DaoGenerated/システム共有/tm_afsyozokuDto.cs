// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             所属グループマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afsyozokuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afsyozoku";
		public string syozokucd { get; set; }                     //所属グループコード
		public string syozokunm { get; set; }                     //所属グループ名
		public bool kanrisyaflg { get; set; }                     //管理者フラグ
		public bool pnoeditflg { get; set; }                      //個人番号操作権限付与フラグ
		public bool alertviewflg { get; set; }                    //警告参照区分
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
