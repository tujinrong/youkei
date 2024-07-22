// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             部署（支所）別更新権限テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afauthsisyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afauthsisyo";
		public Enumロール区分 rolekbn { get; set; }               //ロール区分
		public string roleid { get; set; }                        //ロールID
		public string sisyocd { get; set; }                       //部署（支所）コード
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
