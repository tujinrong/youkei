// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票検索詳細マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptkensakusyosaiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eurptkensakusyosai";
		public int jyokenseq { get; set; }                        //条件シーケンス
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int yosikieda { get; set; }                        //様式枝番
		public string sql { get; set; }                           //SQL
		public string tablealias { get; set; }                    //テーブル別名
		public string jyokenkbn { get; set; }                     //条件区分
		public string jyokenlabel { get; set; }                   //ラベル
		public string variables { get; set; }                     //変数
    }
}
