// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             取込項目マッピングマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktori_mappingDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktori_mapping";
		public string torinyuryokuno { get; set; }                //一括取込入力No
		public int gamenitemseq { get; set; }                     //画面項目シーケンス
		public string? fileitemseq { get; set; }                  //ファイル項目ID
		public string mappingkbn { get; set; }                    //マッピング区分
		public string? mappinghoho { get; set; }                  //マッピング方法
		public int? siteiketasufrom { get; set; }                 //指定桁数（開始）
		public int? siteiketasuto { get; set; }                   //指定桁数（終了）
    }
}
