// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             事業予約希望者テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkjigyoyoyakukibosyaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkjigyoyoyakukibosya";
		public int nitteino { get; set; }                         //日程番号
		public string atenano { get; set; }                       //宛名番号
		public int yoyakuno { get; set; }                         //予約番号
		public Enum待機フラグ cancelmatiflg { get; set; }         //キャンセル待ち
		public int? jusinkingaku { get; set; }                    //受診金額
		public int? kingaku_sityosonhutan { get; set; }           //金額（市区町村負担）
		public string? syokaiuketukeymd { get; set; }             //初回受付日
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
