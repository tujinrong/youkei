// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             連絡先テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afrenrakusakiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afrenrakusaki";
		public string atenano { get; set; }                       //宛名番号
		public string jigyocd { get; set; }                       //個人連絡先利用事業コード
		public string? tel { get; set; }                          //電話番号
		public string? keitaitel { get; set; }                    //携帯番号
		public string? emailadrs { get; set; }                    //E-mailアドレス
		public string? emailadrs2 { get; set; }                   //E-mailアドレス2
		public string? syosai { get; set; }                       //連絡先詳細
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
