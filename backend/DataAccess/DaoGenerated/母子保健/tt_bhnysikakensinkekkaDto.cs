// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             乳幼児歯科健診結果（固定項目）テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_bhnysikakensinkekkaDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_bhnysikakensinkekka";
		public string nykensincd { get; set; }                    //乳幼児健診コード
		public string atenano { get; set; }                       //宛名番号
		public int edano { get; set; }                            //枝番
		public string sikajusinymd { get; set; }                  //歯科健診受診日
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
