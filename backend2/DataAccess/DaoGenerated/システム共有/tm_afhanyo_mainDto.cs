// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             汎用メインマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afhanyo_mainDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afhanyo_main";
		public string hanyomaincd { get; set; }                   //汎用メインコード
		public int hanyosubcd { get; set; }                       //汎用サブコード
		public string hanyosubcdnm { get; set; }                  //汎用サブコード名称
		public string? kananm { get; set; }                       //カナ名称
		public string? shortnm { get; set; }                      //略称
		public int? keta { get; set; }                            //桁数
		public int? userryoikikaisicd { get; set; }               //ユーザ領域開始コード
		public bool iflg { get; set; }                            //INSERT可能フラグ
		public bool uflg { get; set; }                            //UPDATE可能フラグ
		public bool dflg { get; set; }                            //DELETE可能フラグ
		public string? biko { get; set; }                         //備考
    }
}
