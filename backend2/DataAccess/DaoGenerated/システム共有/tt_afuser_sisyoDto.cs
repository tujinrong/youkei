// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             ユーザー所属部署（支所）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afuser_sisyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afuser_sisyo";
		public string userid { get; set; }                        //ユーザーID
		public string sisyocd { get; set; }                       //部署（支所）コード
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
