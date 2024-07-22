// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             母子保健詳細タブマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhsyosaitabDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhsyosaitab";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhsyosaimenyucd { get; set; }               //母子詳細メニューコード
		public string bhsyosaitabcd { get; set; }                 //母子詳細タブコード
		public string bhsyosaitabname { get; set; }               //母子詳細タブ名称
		public string bhdatalistcd { get; set; }                  //母子データリストコード
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
