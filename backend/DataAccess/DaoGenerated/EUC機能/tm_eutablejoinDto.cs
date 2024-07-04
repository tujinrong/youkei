// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUCテーブル結合マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutablejoinDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eutablejoin";
		public string tablealias { get; set; }                    //テーブル別名
		public string kanrentablealias { get; set; }              //上位テーブル別名
		public string ketugosql { get; set; }                     //結合SQL
		public bool jokenflg { get; set; }                        //条件フラグ
		public int? orderseq { get; set; }                        //並びシーケンス
    }
}
