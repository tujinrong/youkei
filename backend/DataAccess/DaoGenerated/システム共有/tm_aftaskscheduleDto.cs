// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             タスクスケジュールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_aftaskscheduleDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_aftaskschedule";
		public string taskid { get; set; }                        //タスクID
		public string tasknm { get; set; }                        //タスク名
		public string? renkeiid { get; set; }                     //HangFire連携ID
		public string? biko { get; set; }                         //説明
		public DateTime? zenjikkodttmf { get; set; }              //前回の実行日時（開始）
		public DateTime? zenjikkodttmt { get; set; }              //前回の実行日時（終了）
		public DateTime? jikaijikkodttmt { get; set; }            //次回実行日時
		public string syorikbn { get; set; }                      //処理区分
		public string gyomukbn { get; set; }                      //業務区分
		public string modulecd { get; set; }                      //モジュールコード
		public string? hikisu { get; set; }                       //引数
		public string yukoymdf { get; set; }                      //有効年月日（開始）
		public string yukotmf { get; set; }                       //有効時間（開始）
		public string hindokbn { get; set; }                      //頻度区分
		public bool syukustopflg { get; set; }                    //祝日停止フラグ
		public string? yobi { get; set; }                         //曜日
		public string? maitukihiyobikbn { get; set; }             //毎月の日・曜日区分
		public string? maitukituki { get; set; }                  //毎月の月
		public string? maitukihi { get; set; }                    //毎月の日
		public string? maitukisyu { get; set; }                   //毎月の週
		public string? statuscd { get; set; }                     //処理結果コード
		public bool? kurikaesikanflg { get; set; }                //繰り返し間隔フラグ
		public string? kurikaesikankbn { get; set; }              //繰り返し間隔区分
		public string? jikantaif { get; set; }                    //時間帯開始_時
		public string? jikantait { get; set; }                    //時間帯終了_時
		public string? jikannaif { get; set; }                    //時間内開始_分
		public string? jikannait { get; set; }                    //時間内終了_分
		public bool stopflg { get; set; }                         //使用停止フラグ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
