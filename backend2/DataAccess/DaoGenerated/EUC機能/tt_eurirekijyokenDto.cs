// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票出力履歴条件テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_eurirekijyokenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_eurirekijyoken";
		public long rirekiseq { get; set; }                       //履歴シーケンス
		public int jyokenseq { get; set; }                        //条件シーケンス
		public string jyokenlabel { get; set; }                   //ラベル
		public string value { get; set; }                         //値
    }
}
