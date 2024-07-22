// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             妊産婦歯科精健結果（固定）テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssikaseikenkekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnssikaseikenkekka";
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int edano { get; set; }                            //枝番
		public string seimitukensajissiymd { get; set; }          //精密検査実施日
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
