// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健詳細メニューマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhsyosaimenyuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhsyosaimenyu";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhsyosaimenyucd { get; set; }               //母子詳細メニューコード
		public string bhsyosaimenyuname { get; set; }             //母子詳細メニュー名称
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
