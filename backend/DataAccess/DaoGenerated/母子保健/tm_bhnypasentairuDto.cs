// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             乳幼児パーセンタイル値マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhnypasentairuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhnyhpasentairu";
		public string buicd { get; set; }                         //部位コード
		public string sex { get; set; }                           //性別
		public int month { get; set; }                            //月
		public int date { get; set; }                             //日
		public string pasentairucd { get; set; }                  //パーセンタイル値コード
		public int pasentairuti { get; set; }                     //パーセンタイル値
		public string? regsisyo { get; set; }                     //登録支所
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
