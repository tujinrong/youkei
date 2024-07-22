// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチ処理
//            
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using Hangfire.Common;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.Formula.Functions;
using System.Diagnostics;
using System.Linq.Expressions;


namespace BCC.Affect.BatchService
{
    public class BtServiceBase
    {

        /// <summary>
        /// トランザクション NEW
        /// </summary>
        //[DebuggerStepThrough()]
        public void Transction(string? taskID, long? sessionSeq, object? paraObj, bool? nowFlg, Action<DaDbContext> f)
        {

            var currentMethod = new StackTrace().GetFrame(1)!.GetMethod()!;
            //機能ID
            var kinoid = currentMethod!.DeclaringType!.Namespace;
            kinoid = kinoid!.Substring(kinoid.LastIndexOf('.') + 1);
            var method = new StackTrace().GetFrame(1)?.GetMethod()!;
            var attribute = method.DeclaringType?.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
            //機能名
            var kinoName = attribute.DisplayName;

            //---------------------------------------------------------
            // DB処理
            //---------------------------------------------------------
            using var db = new DaDbContext();
            AiDbUtil.OpenConnection(db.Session.Connection!);
            DaGlobal.InitDbLib();
            db.Session.UserID = "system";

            if (taskID == null)
            {
                f(db);
                return;
            }

            var fields = AiGlobal.DbInfoProvider.GetTableInfo(db.Session, "tt_aflogdb").FieldList;
            var sdto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(taskID!).GetDto();
            if (sdto == null)
            {
                //異常データの場合 
                return;
            }

            //実行中
            updateStatuscdFromTmAftaskschedule(sdto, db, "4");

            BtModel model;
            try
            {
                model = BtJobService.GetBtModel(db, sdto);
                if (model == null)
                {
                    updateStatuscdFromTmAftaskschedule(sdto, db, "3");
                    return;
                }
            }
            catch
            {
                //変換失敗の場合、処理中止
                updateStatuscdFromTmAftaskschedule(sdto, db, "3");
                return;
            }
            //TODO
            //毎日実行の場合、「祝日実行しない」＝True AND (当日＝日曜日　OR　祝日）の場合、処理中止　
            var sch = model.Schedule;
            var today = DaUtil.Today;
            var starttime = DaUtil.Now;
            var sys = nameof(BCC.Affect.BatchService.SYSTEM);
            var sysName = sys.Substring(sys.LastIndexOf(".") + 1);

            if (nowFlg == null || nowFlg == false)
            {
                //開始時間未達場合、祝日停止の場合、処理中止
                if (starttime < sch.StartTime || (sch.syukustopflg == true && BtHolidayService.IsHoliday(db, today)))
                {
                    updateStatuscdFromTmAftaskschedule(sdto, db, "3");
                    return;
                }
            }

            long sessionseq = 0;
            sdto.statuscd = "1";//異常終了
            //---------------------------------------------------------
            // トランザクション
            //---------------------------------------------------------
            using (var tran = db.Connection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    // 外部から空白の場合、内部でログを生成する
                    if (sessionSeq == null)
                    {
                        //const string className = "Service";
                        //const string currentMethodName = "Execute";
                        if (kinoid != sysName)
                        {
                            sessionseq = DaDbLogService.WriteMainLog(db, kinoid, kinoName, "Execute", "実行");
                        }
                        db.Session.SessionData[DaConst.SessionID] = sessionseq;
                    }
                    else
                    {
                        db.Session.SessionData[DaConst.SessionID] = sessionSeq;
                    }

                    //タスクバットに挿入
                    if (kinoid != sysName)
                    {
                        DaDbLogService.WriteBatchLog(db, "タスク開始", $"{taskID}");
                    }

                    f(db);

                    // 後処理 
                    if (kinoid != sysName)
                    {
                        if (sessionSeq == null)
                        {
                            //定期バッチの場合、内部でログ処理を行う
                            var ttaflogDto = db.tt_aflog.GetDtoByKey(sessionseq);
                            // 更新時間
                            var tm = DaUtil.Now;
                            ttaflogDto.syoridttmt = tm;
                            ttaflogDto.milisec = (int)tm.Subtract(ttaflogDto.syoridttmf).TotalMilliseconds;
                            DaDbLogService.UpdateMainLog(db, ttaflogDto);
                        }

                        DaDbLogService.WriteBatchLog(db, "タスク終了", $"{taskID}");
                    }

                    var endtime = DaUtil.Now;

                    //タスクテーブルの開始時間、終了時間を更新する
                    //前回の実行日時（開始）
                    sdto.zenjikkodttmf = starttime;
                    //前回の実行日時（終了）
                    sdto.zenjikkodttmt = endtime;

                    if (nowFlg != null && nowFlg == true && starttime <= sch.StartTime)
                    {
                        BtModel btModel = BtJobService.GetBtModel(db, sdto);
                        var dt = (btModel.Schedule.yukoymdf > DaUtil.Today) ? btModel.Schedule.yukoymdf : DaUtil.Today;
                        var expression = btModel.GetCronExpression(db, dt);
                        DateTime? firstExecuteTime = CalculateFirstExecuteTime(expression, sch.StartTime);
                        // 結果を出力
                        if (firstExecuteTime.HasValue)
                        {
                            sdto.jikaijikkodttmt = firstExecuteTime;
                        }
                        else
                        {
                            sdto.jikaijikkodttmt = null;
                        }
                    }
                    else
                    {
                        DateTime? nextTime = BtJobService.GetNextExecutionTime(model.TaskID);
                        if (sdto.hindokbn == "0")
                        {
                            DateTime yukoymdf = string.IsNullOrEmpty(sdto.yukoymdf) ? DateTime.MinValue : DaConvertUtil.CDate(sdto.yukoymdf);
                            TimeSpan yukotmf = sdto.yukotmf.Length == 4 ? TimeSpan.Parse($"{sdto.yukotmf[..2]}:{sdto.yukotmf.Substring(2, 2)}") : new TimeSpan();
                            if (sdto.kurikaesikanflg != null && sdto.kurikaesikanflg == true)
                            {
                                yukotmf = TimeSpan.Parse($"{sdto.jikantait}:{sdto.jikannait}");
                            }

                            if (yukoymdf + yukotmf > nextTime)
                            {
                                sdto.jikaijikkodttmt = nextTime;
                            }
                            else
                            {
                                sdto.jikaijikkodttmt = null;
                            }

                        }
                        else
                        {
                            //次回予定時間を算出(ダメな場合、BtJobService.GetJobExcListを利用）
                            sdto.jikaijikkodttmt = nextTime;
                        }
                    }

                    sdto.statuscd = "0"; // 正常終了

                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                }
            }

            //更新
            db.tm_aftaskschedule.UPDATE.Execute(sdto);
        }
        private static DateTime? CalculateFirstExecuteTime(string cronExpression, DateTime startTime)
        {
            string[] parts = cronExpression.Split(' ');

            if (parts.Length != 5 && parts.Length != 6)
                return null; // 無効なCron式

            // 分、時間、日、月、曜日を解析
            var minStr = parts[0];
            var hourStr = parts[1];
            var dayStr = parts[2];
            var monStr = parts[3];


            int minute = minStr == "*" ? 0 : int.Parse(minStr.Split('/')[0].Split('-')[0]);
            int hour = hourStr == "*" ? 0 : int.Parse(hourStr.Split('-')[0]);
            int year = startTime.Year;
            int month = startTime.Month;
            int day = startTime.Day;

            if (monStr != "*" && dayStr != "*")
            {
                var monList = monStr.Split(",");
                var dayList = dayStr.Split(",");
                while (true)
                {

                    if (dayList.Contains(startTime.Day.ToString()) &&
                        monList.Contains(startTime.Month.ToString()))
                    {
                        break;
                    }
                    startTime = startTime.AddDays(1);
                }
            }
            else if (monStr != "*" && dayStr == "*")
            {
                var monList = monStr.Split(",");
                while (true)
                {

                    if (monList.Contains(startTime.Month.ToString()))
                    {
                        break;
                    }
                    startTime = startTime.AddMonths(1);
                }
            }
            else if (monStr == "*" && dayStr != "*")
            {
                var dayList = dayStr.Split(",");
                while (true)
                {

                    if (dayList.Contains(startTime.Day.ToString()))
                    {
                        break;
                    }
                    startTime = startTime.AddDays(1);
                }
            }


            // 最初の実行時間を計算
            DateTime firstExecuteTime = new DateTime(year, month, day, hour, minute, 0);

            return firstExecuteTime;
        }

        private static int ParseCronPart(string part, int minValue, int maxValue)
        {
            if (part == "*")
                return minValue;

            string[] subParts = part.Split('/');

            if (subParts.Length > 1)
            {
                int startValue = int.Parse(subParts[0].Split('-')[0]);
                int interval = int.Parse(subParts[1]);
                int nextValue = startValue;

                while (nextValue < minValue || nextValue > maxValue)
                {
                    nextValue += interval;
                }

                return nextValue;
            }

            return int.Parse(part);
        }

        private int GetWeekOfMonth(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);

            int dayOfWeekFirstDay = (int)firstDayOfMonth.DayOfWeek;

            int adjustedDayOfWeekFirstDay = dayOfWeekFirstDay == 0 ? 7 : dayOfWeekFirstDay;

            int daysInFirstWeek = 7 - (adjustedDayOfWeekFirstDay - 1);

            int daysAfterFirstWeek = date.Day - daysInFirstWeek;
            if (daysAfterFirstWeek < 0)
            {
                return 1;
            }

            int weekOfMonth = daysAfterFirstWeek / 7 + (daysAfterFirstWeek % 7 == 0 ? 0 : 1);

            weekOfMonth = weekOfMonth + 1;

            return weekOfMonth;
        }

        /// <summary>
        /// テーブルからパラメータを取得する場合
        /// </summary>
        protected string GetParameter(string? jobId)
        {
            return "TODO";
        }

        private void updateStatuscdFromTmAftaskschedule(tm_aftaskscheduleDto sdto, DaDbContext db, String statuscd)
        {

            sdto.statuscd = statuscd;
            //更新
            db.tm_aftaskschedule.UPDATE.Execute(sdto);
        }

    }
}

//次の実行日を取得
//
//                    var sql = @$"
//SELECT
//    s.key,
//    s.value,
//    s.expireat  --時間
//FROM
//    set s
//INNER JOIN hash h ON s.key = CONCAT('recurring-jobs:', h.value)
//WHERE
//    h.field = 'RecurringJobId'
//    AND h.key = '{taskID}' 
//ORDER BY
//    s.expireat DESC
//LIMIT 1;
//";

//次の稼働日実行の場合
//if (sch.hindokbn == EnumHinDoKBN.EveryMonth && sch.syukustopflg && today.Day != nextTime.Day)
//{
//    var nextDay = DaUtil.Today.AddDays(1);
//     BtJobService.AddOrUpdateJob(db, false, nextDay, model, model.Paramter);
//}
//if (sch.hindokbn == EnumHinDoKBN.EveryWeek && sch.syukustopflg && today.Day != nextTime.Day)
//{
//    var nextDay = DaUtil.Today.AddDays(1);
//    BtJobService.AddOrUpdateJob(db, false, nextDay, model, model.Paramter);
//}


////毎月の最終日
//if ((int)btModel.Schedule.hindokbn == (int)EnumHinDoKBN.EveryMonthLastDay)
//{
//    DateTime today = DaUtil.Today;
//    int lastDayOfMonth = DateTime.DaysInMonth(today.Year, today.Month);

//    if (today.Day == lastDayOfMonth)
//    {
//        // バッチ処理
//        f(db);
//    }
//}
////19.毎月、選択した週(週1,週2,週3,週4,週5)
//else if ((int)btModel.Schedule.hindokbn == (int)EnumHinDoKBN.EveryMonthWeeksAtATime)
//{
//    DateTime today = DaUtil.Today;

//    int weekOfMonth = GetWeekOfMonth(today);

//    int dayOfWeek = (int)today.DayOfWeek;

//    //毎月の週
//    //maitukisyu:1,2,3 ?
//    List<int> listselectedweekofmonth = btModel.Schedule.maigetusyu;
//    List<int> listselecteddayofweek = btModel.Schedule.maisyuyoubi;
//    if (listselectedweekofmonth.Contains(weekOfMonth))
//    {
//        if (listselecteddayofweek.Contains(dayOfWeek))
//        {
//            // バッチ処理
//            f(db);
//        }
//    }
//}
//else
//{
//    // バッチ処理
//    f(db);
//}
