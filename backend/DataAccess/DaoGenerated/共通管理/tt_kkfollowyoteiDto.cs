// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             フォロー予定情報テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_kkfollowyoteiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_kkfollowyotei";
		public string atenano { get; set; }                       //宛名番号
		public int follownaiyoedano { get; set; }                 //フォロー内容枝番
		public int edano { get; set; }                            //枝番
		public string? followjigyocd { get; set; }                //フォロー事業コード
		public string? followhoho { get; set; }                   //フォロー方法
		public string? followyoteiymd { get; set; }               //フォロー予定日
		public string? followtm { get; set; }                     //フォロー時間
		public string? followkaijocd { get; set; }                //フォロー会場コード
		public string? followriyu { get; set; }                   //フォロー理由
		public string? followstaffid { get; set; }                //フォロー担当者
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
