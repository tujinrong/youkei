// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             汎用マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhanyoDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afhanyo";
		public string hanyomaincd { get; set; }                   //汎用メインコード
		public int hanyosubcd { get; set; }                       //汎用サブコード
		public string hanyocd { get; set; }                       //汎用コード
		public string nm { get; set; }                            //名称
		public string? kananm { get; set; }                       //カナ名称
		public string? shortnm { get; set; }                      //略称
		public string? biko { get; set; }                         //備考
		public string? hanyokbn1 { get; set; }                    //汎用区分1
		public string? hanyokbn2 { get; set; }                    //汎用区分2
		public string? hanyokbn3 { get; set; }                    //汎用区分3
		public bool stopflg { get; set; }                         //使用停止フラグ
		public int? orderseq { get; set; }                        //並びシーケンス
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
