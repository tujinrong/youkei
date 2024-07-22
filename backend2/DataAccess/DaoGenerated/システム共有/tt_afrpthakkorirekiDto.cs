// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             帳票発行履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afrpthakkorirekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afrpthakkorireki";
		public long hakkoseq { get; set; }                        //発行シーケンス
		public int hakkoseqeda { get; set; }                      //発行シーケンス枝番
		public long tyusyutuseq { get; set; }                     //抽出シーケンス
		public string nendo { get; set; }                         //年度
		public string taisyocd { get; set; }                      //抽出対象CD
		public string gyoumucd { get; set; }                      //業務コード
		public string rptyosikihakkocd { get; set; }              //帳票様式発行コード
		public DateTime hakkodttm { get; set; }                   //発行日時
		public string hakkokbn { get; set; }                      //発行区分
		public string? hakkobasyo { get; set; }                   //発行場所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
