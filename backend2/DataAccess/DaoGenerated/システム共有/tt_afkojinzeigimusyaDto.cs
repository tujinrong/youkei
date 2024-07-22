// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             【個人住民税】納税義務者情報テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afkojinzeigimusyaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afkojinzeigimusya";
		public string atenano { get; set; }                       //宛名番号
		public int kazeinendo { get; set; }                       //課税年度
		public string? tosi_gyoseikucd { get; set; }              //指定都市_行政区等コード
		public string misinkokukbn { get; set; }                  //未申告区分
		public string takazeikbn { get; set; }                    //他団体課税対象者区分
		public string? takazeisikucd { get; set; }                //他団体課税対象者の課税先市区町村コード
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
