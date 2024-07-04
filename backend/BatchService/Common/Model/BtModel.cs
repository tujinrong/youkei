// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチ共通モデルクラス
//            
// 作成日　　: 2023.01.12
// 作成者　　: 屠
// 変更履歴　: 
// *******************************************************************
namespace BCC.Affect.BatchService
{
    /// <summary>
    /// バッチタスクモデル
    /// </summary>
    public class BtModel
    {
        public string TaskID { get; set; } //JobID
        public string TaskNm { get; set; } // タスク名
        public string renkeiid { get; set; } // HangFire連携ID = TaskID
        public string setumei { get; set; } // 説明
        public string Module { get; set; }
        public string Paramter { get; set; }    

        /// <summary>
        /// 実行情報
        /// </summary>
        public BtJobInfo JobInfo = new BtJobInfo(); // 処理開始日時、処理終了日時

        /// <summary>
        /// 繰り返す
        /// </summary>
        public BtScheduleModel Schedule = new BtScheduleModel();

        public string GetCronExpression(DaDbContext db, DateTime holidayStartDay)
        {
            return Schedule.GetCorn(db, holidayStartDay);
        }

        //public string GetCronWeeklyDays(List<int> weekdays)
        //{
        //    return string.Join(",", weekdays);
        //}
    }
}
