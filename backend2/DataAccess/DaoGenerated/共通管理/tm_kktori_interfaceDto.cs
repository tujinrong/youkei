// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             取込IFマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_interfaceDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktori_interface";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public int fileitemseq { get; set; }                      //ファイル項目ID
		public string itemnm { get; set; }                        //項目名
		public bool keyflg { get; set; }                          //キーフラグ
		public bool hissuflg { get; set; }                        //必須フラグ
		public string datatype { get; set; }                      //データ型
		public int ketasu { get; set; }                           //桁数
		public int? syosuketasu { get; set; }                     //桁数（小数部）
		public string? format { get; set; }                       //フォーマット
		public string? formatcheck { get; set; }                  //フォーマットチェック
		public string? formathenkan { get; set; }                 //フォーマット変換
		public string? biko { get; set; }                         //備考
    }
}
