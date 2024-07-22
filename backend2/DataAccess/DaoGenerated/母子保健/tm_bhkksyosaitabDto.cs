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
    public class tm_bhkksyosaitabDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhkksyosaitab";
		public string bosikbn { get; set; }                       //母子区分
		public string bhsyosaimenyucd { get; set; }               //母子保健詳細メニューコード
		public string bhsyosaitabcd { get; set; }                 //母子保健詳細タブコード
		public string bhsyosaitabnm { get; set; }                 //母子保健詳細タブ名称
		public string jigyocd { get; set; }                       //母子保健事業コード
		public int orderseq { get; set; }                         //並びシーケンス
    }
}
