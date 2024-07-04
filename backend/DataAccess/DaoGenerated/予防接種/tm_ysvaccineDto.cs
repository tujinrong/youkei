// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             ワクチンマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_ysvaccineDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_ysvaccine";
		public string sessyucd { get; set; }                      //接種種類コード
		public string vaccinemakercd { get; set; }                //ワクチンメーカーコード
		public string vaccinenmcd { get; set; }                   //ワクチン名コード
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
