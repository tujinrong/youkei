// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             宛名番号検索履歴テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afatenalogDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afatenalog";
		public string userid { get; set; }                        //ユーザーID
		public string kinoid { get; set; }                        //機能ID
		public string atenano { get; set; }                       //宛名番号
		public DateTime syoridttm { get; set; }                   //処理日時
    }
}
