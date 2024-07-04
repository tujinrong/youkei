// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             産婦健診結果（固定）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnssanpukensinkekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnssanpukensinkekka";
		public string atenano { get; set; }                       //宛名番号
		public long torokuno { get; set; }                        //登録番号
		public int edano { get; set; }                            //枝番
		public string jusinymd { get; set; }                      //受診日
		public string kensinsyubetu { get; set; }                 //健診種別
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
