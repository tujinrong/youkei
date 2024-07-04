// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             一括取込入力登録マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktorinyuryoku_torokuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktorinyuryoku_toroku";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public string tableid { get; set; }                       //テーブル物理名
		public int recordno { get; set; }                         //レコードNo
		public string fieldnm { get; set; }                       //フィールド物理名
		public string syorikbn { get; set; }                      //処理区分
		public int? datamotoitemseq { get; set; }                 //データ元画面項目シーケンス
		public string? koteiti { get; set; }                      //固定値
		public string? datamototablenm { get; set; }              //データ元テーブル
		public string? datamotofieldnm { get; set; }              //データ元フィールド
		public string? saibankey { get; set; }                    //採番キー
    }
}
