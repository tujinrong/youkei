// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUCデータソース項目マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourceitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eudatasourceitem";
		public string datasourceid { get; set; }                  //データソースID
		public string sqlcolumn { get; set; }                     //SQLカラム
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
