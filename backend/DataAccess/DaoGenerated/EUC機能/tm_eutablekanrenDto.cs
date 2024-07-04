// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUCテーブル関連マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eutablekanrenDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eutablekanren";
		public string tablenm { get; set; }                       //テーブル物理名
		public string kanrentablenm { get; set; }                 //関連先テーブル名
		public string jibunkey { get; set; }                      //自分側結合キー
		public string? kanrenkey { get; set; }                    //相手側結合キー
		public string? kotei { get; set; }                        //固定条件
		public int? seq { get; set; }                             //順番
    }
}
