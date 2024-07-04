// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             事業従事者（担当者）情報マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afstaffDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afstaff";
		public string staffid { get; set; }                       //事業従事者ID
		public string staffsimei { get; set; }                    //事業従事者氏名
		public string kanastaffsimei { get; set; }                //事業従事者カナ氏名
		public string syokusyu { get; set; }                      //職種
		public string katudokbn { get; set; }                     //活動区分
		public bool syokuinflg { get; set; }                      //職員フラグ
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
