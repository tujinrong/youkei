// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUCデータソースマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourceDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eudatasource";
		public string datasourceid { get; set; }                  //データソースID
		public string datasourcenm { get; set; }                  //データソース名称
		public string gyoumucd { get; set; }                      //業務コード
		public int orderseq { get; set; }                         //並び順
		public string maintablealias { get; set; }                //メインテーブル別名
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
