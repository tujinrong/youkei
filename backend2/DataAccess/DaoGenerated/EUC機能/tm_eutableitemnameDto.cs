// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUCテーブル項目名称マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutableitemnameDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eutableitemname";
		public string mastercd { get; set; }                      //名称マスタコード
		public string masterhyojinm { get; set; }                 //マスタ名称
		public string tablenm { get; set; }                       //テーブル物理名
		public string keynm { get; set; }                         //キー項目物理名
		public string meisyonm { get; set; }                      //名称項目物理名
		public string? maincd { get; set; }                       //メインコード
		public string? subcd { get; set; }                        //サブコード
		public bool maincdnumflg { get; set; }                    //メインコード数値フラグ
    }
}
