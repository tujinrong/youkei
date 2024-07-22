// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUCデータソーステーブルマスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourcetableDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eudatasourcetable";
		public string datasourceid { get; set; }                  //データソースID
		public string tablealias { get; set; }                    //テーブル別名
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
