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
    public class tt_kkrpthakkorirekiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkrpthakkorireki";
		public long hakkoseq { get; set; }                        //発行シーケンス
		public string rptid { get; set; }                         //帳票ID
		public string? yosikiid { get; set; }                     //様式ID
		public int? outputkbn { get; set; }                       //出力方式
		public string? hakkodatasyosaikbn { get; set; }           //発行データ詳細区分
		public long? tyusyutuseq { get; set; }                    //抽出シーケンス
		public int nendo { get; set; }                            //年度
		public string hassoymd { get; set; }                      //発送日
		public string? hakkokbn { get; set; }                     //発行区分
		public string? hakkobasyo { get; set; }                   //発行場所
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
