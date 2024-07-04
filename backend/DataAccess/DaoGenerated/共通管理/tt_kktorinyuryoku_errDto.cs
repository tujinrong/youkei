// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力エラーテーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kktorinyuryoku_errDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kktorinyuryoku_err";
		public int impjikkoid { get; set; }                       //取込実行ID
		public int errseq { get; set; }                           //エラーシーケンス
		public int? dataseq { get; set; }                         //データシーケンス
		public int rowno { get; set; }                            //行番号
		public string? atenano { get; set; }                      //宛名番号
		public string? simei { get; set; }                        //氏名
		public string? itemnm { get; set; }                       //項目名
		public string? itemvalue { get; set; }                    //項目値
		public string msg { get; set; }                           //メッセージ
		public string errkbn { get; set; }                        //エラー区分
    }
}
