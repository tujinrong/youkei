// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             地区情報マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftikuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_aftiku";
		public Enum地区区分 tikukbn { get; set; }                 //地区区分
		public string tikucd { get; set; }                        //地区コード
		public string tikunm { get; set; }                        //地区名
		public string kanatikunm { get; set; }                    //地区名（カナ）
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
