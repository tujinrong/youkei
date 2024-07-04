// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             【住民基本台帳】支援措置対象者情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afsiensotitaisyosyaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afsiensotitaisyosya";
		public string atenano { get; set; }                       //宛名番号
		public string siensotiymdf { get; set; }                  //支援措置開始年月日
		public string siensotiymdt { get; set; }                  //支援措置終了年月日
		public string siensotikbn { get; set; }                   //支援措置区分
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
