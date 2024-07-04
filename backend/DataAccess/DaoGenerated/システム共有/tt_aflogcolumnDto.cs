// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             テーブル項目値変更ログテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aflogcolumnDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_aflogcolumn";
		public long columnlogseq { get; set; }                    //項目値変更ログシーケンス
		public long? sessionseq { get; set; }                     //セッションシーケンス
		public string tablenm { get; set; }                       //テーブル名
		public string henkokbn { get; set; }                      //変更区分
		public string? keys { get; set; }                         //キー
		public string? itemnm { get; set; }                       //項目名
		public string? valuebefore { get; set; }                  //変更前内容
		public string? valueafter { get; set; }                   //更新後内容
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
    }
}
