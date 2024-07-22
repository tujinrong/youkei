// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             予防接種依頼テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_yssessyuiraiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_yssessyuirai";
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string uketukeymd { get; set; }                    //受付日
		public string? iraisaki { get; set; }                     //依頼先
		public string? irairiyu { get; set; }                     //依頼理由
		public string? hogosya_atenano { get; set; }              //保護者_宛名番号
		public string? hogosya_simei { get; set; }                //保護者_氏名
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
