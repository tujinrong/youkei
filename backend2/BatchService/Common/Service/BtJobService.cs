// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: バッチ処理
//            
// 作成日　　: 
// 作成者　　: 
// 変更履歴　: 
// *******************************************************************
using Hangfire.Storage;
using System.Data;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.BatchService
{
    public class BtJobService
    {
        /// <summary>
        /// JOBの追加(周期タスク)
        /// </summary>
        public static string AddJob(DaDbContext db, BtModel jobModel, object? param = null)
        {
            var dt = (jobModel.Schedule.yukoymdf > DateTime.Today) ? jobModel.Schedule.yukoymdf : DateTime.Today;
            return AddOrUpdateJob(db, true, dt, jobModel, param);
        }

        /// <summary>
        /// JOBの更新(周期タスク)
        /// </summary>
        public static void UpdateJob(DaDbContext db, BtModel jobModel, object? param = null)
        {
            var dt = (jobModel.Schedule.yukoymdf > DateTime.Today) ? jobModel.Schedule.yukoymdf : DateTime.Today;
            AddOrUpdateJob(db, false, dt, jobModel, param);
        }

        /// <summary>
        /// JOBの削除(周期タスク)
        /// </summary>
        public static void DeleteJob(string jobId)
        {
            RecurringJob.RemoveIfExists(jobId);
        }

        /// <summary>
        /// JOBの実行(即実行タスク)
        /// ログのSessionSeqは画面から渡す
        /// </summary>
        public static void Execute(string kinoid, long sessionseq, string? taskID = null, object? paraObj = null,bool? nowFlg = false)
        {
            IBtService job = BtFactory.GetService(kinoid);
            var client = new BackgroundJobClient();
            client.Enqueue(() => job.Execute(taskID, paraObj, sessionseq, nowFlg));
            Thread.Sleep(3000); 
        }

        /// <summary>
        /// JOBの実行(指定時間実行)
        /// ログのSessionSeqは画面から渡す
        /// </summary>
        public static void Execute(DaDbContext db, DateTime? time, long sessionseq, IBtService job, object? paraObj = null)
        {
            string taskid = GetNewTaskId(db);
            if (time == null)
            {
                var client = new BackgroundJobClient();
                client.Enqueue(() => job.Execute(null, paraObj, sessionseq,true));
                Thread.Sleep(3000);
            }
            else
            {
                var jtime = BtUtil.GetJapanTime((DateTime)time);
                BackgroundJob.Schedule(() => job.Execute(taskid, paraObj, null,false), jtime);
            }
        }

        /// <summary>
        /// JOB共通追加、更新処理
        /// </summary>
        public static string AddOrUpdateJob(DaDbContext db, bool isAdd, DateTime holidayStartDay, BtModel jobModel, object? param = null)
        {
            IBtService job = BtFactory.GetService(jobModel.Module);

            //if (jobModel.Schedule.hindokbn == EnumHinDoKBN.OneTime)
            //{
            //    //一回のみ実行する場合
            //    if (jobModel.TaskID == null)
            //    {
            //        jobModel.TaskID = GetNewTaskId(db);
            //    }
            //    var time = jobModel.Schedule.StartTime;
            //    time = BtUtil.GetJapanTime(time);
            //    BackgroundJob.Schedule(() => job.Execute(jobModel.TaskID, param, null,null), time);
            //    return jobModel.TaskID;
            //}
            //else
            //{
                //通常の場合
                var expression = jobModel.GetCronExpression(db, holidayStartDay);
                var options = new RecurringJobOptions
                {
                    TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"),
                };
                RecurringJob.AddOrUpdate(
                    jobModel.TaskID,
                    () => job.Execute(jobModel.TaskID, param, null, null),
                    expression,
                    options);
                return jobModel.TaskID;
            //}
        }

        /// <summary>
        /// 次回実行時間一覧の取得
        /// </summary>
        public static DateTime? GetNextExecutionTime(string JobID)
        {
            var list = GetNextExecutionInfoList();
            var job = list.Find(e => e.JobId == JobID);
            if (job != null)
            {
                return job.NextExecutionTime;
            }
            else { return null; }
        }

        /// <summary>
        /// 次回実行時間一覧の取得
        /// </summary>
        public static List<JobNextExecutionInfo> GetNextExecutionInfoList()
        {
            var jobList = new List<JobNextExecutionInfo>();
            using (var connection = JobStorage.Current.GetConnection())
            {
                var serverJobs = connection.GetRecurringJobs();
                foreach (var job in serverJobs)
                {
                    jobList.Add(new JobNextExecutionInfo
                    {
                        JobId = job.Id,
                        NextExecutionTime = (job.NextExecution != null) ? BtUtil.GetJapanTime((DateTime)job.NextExecution) : null
                    }); ;
                }
            }
            return jobList;
        }

        /// <summary>
        /// Job一覧を取得する
        /// </summary>
        public static List<string> GetJobList(DaDbContext db)
        {
            var dtl = db.tm_aftaskschedule.SELECT.WHERE.ByItem(nameof(tm_aftaskscheduleDto.stopflg), false).GetDtoList();
            var list = dtl.Select(e => e.taskid).ToList();
            return list;
        }

        /// <summary>
        /// Job一覧を取得する(繰り返しJOB)
        /// </summary>
        public static List<string> GetRecurringJobList(DaDbContext db)
        {
            var dtl = db.tm_aftaskschedule.SELECT.WHERE.ByItem(nameof(tm_aftaskscheduleDto.stopflg), false).GetDtoList();
            var list = dtl.Where(e => e.kurikaesikanflg == true).Select(e => e.taskid).ToList();
            return list;
        }

        /// <summary>
        /// HangFire側Job一覧を取得す(繰り返しJOB)
        /// </summary>
        public static List<string> GetRecurringJobList_HangFire(DaDbContext db)
        {
            var list = new List<string>();
            using (var connection = JobStorage.Current.GetConnection())
            {
                var serverJobs = connection.GetRecurringJobs();
                foreach (var job in serverJobs)
                {
                    list.Add(job.Id);
                }
            }
            return list;
            //var hanConn = DaGlobal.GetConnectionStringFunc!("BatchScheduleConnection");
            //var svcConn = DaGlobal.GetConnectionStringFunc!("connectionString");
            //var sql = "select jobid from job";
            //if (hanConn == svcConn)
            //{
            //    var list = db.Session.GetValueList(sql);
            //    return list.Select(e => e!.ToString()).ToList()!;
            //}
            //else
            //{
            //    var conn = new NpgsqlConnection(hanConn);
            //    AiDbUtil.OpenConnection(conn);
            //    IDbCommand command = AiGlobal.DbApi.GetCommand(conn, sql);
            //    using (var reader = command.ExecuteReader())
            //    {
            //        var list = new List<string>();
            //        while (reader.Read())
            //        {
            //            var value = reader.GetString(0);
            //            list.Add(value);
            //            if (reader.NextResult() == false)
            //            {
            //                return list;
            //            }
            //        }
            //        while (reader.NextResult())
            //            return list;
            //    }
            //}
            //return new List<string>();
        }

        /// <summary>
        /// Jobを更新する
        /// </summary>
        public static void UpdateAllJob(DaDbContext db)
        {
            var Dlist = GetRecurringJobList(db);
            var Hlist = GetRecurringJobList_HangFire(db);
            var delList = Hlist.Where(e => Dlist.Contains(e) == false).ToList();
            var updList = Hlist.Where(e => Dlist.Contains(e)).ToList();
            var insList = Dlist.Where(e => Hlist.Contains(e) == false).ToList();
            foreach (var taskID in delList)
            {
                DeleteJob(taskID);
            }
            var dtl = db.tm_aftaskschedule.SELECT.GetDtoList();
            foreach (var dto in dtl)
            {
                var model = GetBtModel(db, dto);
                var para = model.Paramter;
                var taskid = model.TaskID;
                if (updList.Contains(taskid))
                {
                    UpdateJob(db, model, para);
                }
                else if (insList.Contains(taskid))
                {
                    AddJob(db, model, para);
                }
            }
        }

        /// <summary>
        /// 祝日のスケジュールを更新する。
        /// ローカルタスク管理テーブルに同期する。HangFire側を更新する
        /// </summary>
        public static void UpdateHolidaySchedule(DaDbContext db)
        {
            var nextDay = DateTime.Today.AddDays(1);
            var dtl = db.tm_aftaskschedule.SELECT.WHERE.ByItem(nameof(tm_aftaskscheduleDto.stopflg), false).GetDtoList();
            foreach (var dto in dtl)
            {
                var model = BtJobService.GetBtModel(db, dto);
                var sch = model.Schedule;
                if (sch.hindokbn == EnumHinDoKBN.EveryMonth || sch.hindokbn == EnumHinDoKBN.EveryMonth)
                {
                    if (sch.syukustopflg || sch.IsMonthEnd)
                    {
                        BtJobService.AddOrUpdateJob(db, false, nextDay, model, model.Paramter);
                    }
                }
                else if (sch.hindokbn == EnumHinDoKBN.OneTime && sch.kurikaeshikanFlg && DateTime.Now.Year> sch.yukoymdf.Year) {
                    BtJobService.DeleteJob(dto.taskid);
                }
            }
        }

        /// <summary>
        /// Model変換処理
        /// </summary>
        public static BtModel GetBtModel(DaDbContext db, tm_aftaskscheduleDto dto)
        {
            var model = new BtModel();
            model.TaskID = string.IsNullOrEmpty(dto.taskid) ? GetNewTaskId(db)
              : dto.taskid;                                                       //タスクID
            model.TaskNm = dto.tasknm;                                              //タスク名
            model.renkeiid = AiDataUtil.Nz(dto.renkeiid);                           //HangFire連携ID
            model.setumei = AiDataUtil.Nz(dto.biko);                                //説明
            model.JobInfo = new BtJobInfo
            {
                zenjikkodttmf = CDate(dto.zenjikkodttmf),                //前回の実行日時（開始）
                zenjikkodttmt = CDate(dto.zenjikkodttmt),                //前回の実行日時（終了）
                jikaijikkodttmt = CNDate(dto.jikaijikkodttmt)            //次回時間
            };

            var scheduleModel = new BtScheduleModel();
            scheduleModel.yukoymdf = string.IsNullOrEmpty(dto.yukoymdf) ? DateTime.MinValue : CDate(dto.yukoymdf); // 有効開始時刻
            scheduleModel.yukotmf = dto.yukotmf.Length == 4 ? TimeSpan.Parse($"{dto.yukotmf[..2]}:{dto.yukotmf.Substring(2, 2)}") : new TimeSpan(); // 有効開始時刻
            scheduleModel.hindokbn = ParseEnum<EnumHinDoKBN>(dto.hindokbn); // 頻度区分[0：一回のみ、1：毎日、2：毎週、3：毎月]
            scheduleModel.yobi = StringConvertCdWeekList(dto.yobi); // 毎週の曜日
            scheduleModel.maitukituki = StringConvertCdList(dto.maitukituki); // 毎月の月
            scheduleModel.IsMonthEnd = dto.maitukihi?.Length == 32 && dto.maitukihi!.Substring(31, 1) == "1";
            scheduleModel.maitukisyu = StringConvertCdList(dto.maitukisyu); // 毎月の週
            scheduleModel.hikisu = AiDataUtil.Nz(dto.hikisu); // 引数
            scheduleModel.kurikaeshikanFlg = dto.kurikaesikanflg != null && (bool)dto.kurikaesikanflg; //繰り返し間隔フラグ 0:しない　1:する
            scheduleModel.kurikaesikankbn =
                string.IsNullOrEmpty(dto.kurikaesikankbn) ? EnumIntervalType.Minutes5 : ParseEnum<EnumIntervalType>(dto.kurikaesikankbn!); // 0：5分間、1：10分間、2：15分間、3：30分間、4：1時間
            scheduleModel.syukustopflg = dto.syukustopflg; // 祝日次営業日実行フラグ 0:しない　1:する
            scheduleModel.maitukihi = StringConvertCdList(dto.maitukihi?.Length == 32 ? dto.maitukihi![..31] : dto.maitukihi); //毎月の日                     // 選択された年中の月
            scheduleModel.beginhour = CInt(dto.jikantaif);
            scheduleModel.endhour = CInt(dto.jikantait);
            scheduleModel.beginminute = CInt(dto.jikannaif);
            scheduleModel.endminute = CInt(dto.jikannait);
            model.Schedule = scheduleModel;

            model.Module = DaSelectorService.GetName(db, dto.modulecd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.モジュール));                      //モジュールコード

            return model;
        }

        /// <summary>
        /// TaskIdを作成する
        /// </summary>
        public static string GetNewTaskId(DaDbContext db)
        {
            var sql = "SELECT max(CAST(taskid AS INTEGER) ) +1 from tm_aftaskschedule";
            var dt = db.Session.GetDataTable(sql);
            return dt.Rows[0][0].ToString()!;
        }

        /// <summary>
        /// 文字設定から配列変換処理（曜日）
        /// </summary>
        private static List<int> StringConvertCdWeekList(string? value)
        {
            List<int> list = new List<int>();

            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '1')
                    {
                        if (i == 0)
                        {
                            list.Add(7);
                        }
                        else
                        {
                            list.Add(i);
                        }
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 文字設定から配列変換処理
        /// </summary>
        private static List<int> StringConvertCdList(string? value)
        {
            List<int> list = new List<int>();

            if (!string.IsNullOrEmpty(value))
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (value[i] == '1')
                    {
                        list.Add(i + 1);
                    }
                }
            }

            return list;
        }


        #region 削除

        private List<DateTime> GetLeftDatesOfThisMonth(DateTime startDate)
        {
            List<DateTime> listDateCurrentMonth = new List<DateTime>();

            int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);

            for (DateTime date = startDate; date <= new DateTime(startDate.Year, startDate.Month, daysInMonth); date = date.AddDays(1))
            {
                listDateCurrentMonth.Add(date);
            }

            return listDateCurrentMonth;
        }

        //private void CreateScheduledTaskForHoliday(
        //    BtModel jobModel,
        //    List<DateTime> listDateHoliday,
        //    object? param = null)
        //{
        //    string jobId = "";

        //    IBtService job = BtFactory.GetService(jobModel.Module);
        //    string currentJobId = GetNewTaskId() + jobModel.TaskID;

        //    foreach (var runDate in listDateHoliday)
        //    {
        //        var delay = runDate - DateTime.Now;
        //        if (delay > TimeSpan.Zero)
        //        {
        //            jobId = BackgroundJob.Schedule(
        //                () => job.Execute(currentJobId, param, null),
        //                delay);
        //        }
        //    }
        //}

        /// <summary>
        /// 明日から今月の残りの日付を取得する
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// 来月のすべての日付リストを取得する
        /// </summary>
        /// <param name="startDate">開始日</param>
        /// <returns></returns>
        private List<DateTime> GetAllDatesOfNextMonth(DateTime startDate)
        {
            List<DateTime> listDateNextMonth = new List<DateTime>();

            DateTime nextMonthDate = startDate.AddMonths(1);
            int year = nextMonthDate.Year;
            int month = nextMonthDate.Month;

            int daysInMonth = DateTime.DaysInMonth(year, month);

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime date = new DateTime(year, month, day);
                listDateNextMonth.Add(date);
            }

            return listDateNextMonth;
        }

        /// <summary>
        /// 特定の日付範囲内で、[選択された曜日の日付]を取得する
        /// </summary>
        /// <param name="start">開始日</param>
        /// <param name="end">終了日</param>
        /// <param name="listDayOfWeek">選択された毎週の曜日リスト</param>
        /// <returns></returns>
        private List<DateTime> GetDatesOfSelectedWeekdays(
            DateTime start,
            DateTime end,
            List<DayOfWeek> listDayOfWeek)
        {
            List<DateTime> dates = new List<DateTime>();

            for (DateTime dt = start; dt <= end; dt = dt.AddDays(1))
            {
                if (listDayOfWeek.Contains(dt.DayOfWeek))
                {
                    dates.Add(dt);
                }
            }

            return dates;
        }

        /// <summary>
        /// 実際の実行日リストを取得する
        /// </summary>
        /// <param name="listSelectedDate">選択された日付リスト</param>
        /// <param name="listHoliday">祝日リスト</param>
        /// <returns>実際の実行日リスト</returns>
        private List<DateTime> GetFinalExecutionDate(
            List<DateTime> listSelectedDate,
            List<DateTime> listHoliday)
        {
            List<DateTime> listNextWorkingDate = new List<DateTime>();

            foreach (DateTime date in listSelectedDate)
            {
                DateTime nextWorkingDate = GetNextWorkingDay(date, listHoliday);
                listNextWorkingDate.Add(nextWorkingDate);
            }

            foreach (DateTime nextWorkingDate in listNextWorkingDate)
            {
                if (!listSelectedDate.Contains(nextWorkingDate))
                {
                    listSelectedDate.Add(nextWorkingDate);
                }
            }

            return listSelectedDate;
        }

        /// <summary>
        /// 最も近い将来の仕事日を取得する
        /// </summary>
        /// <param name="date">選択された日付</param>
        /// <param name="listHoliday">祝日リスト</param>
        /// <returns></returns>
        private DateTime GetNextWorkingDay(
            DateTime date,
            List<DateTime> listHoliday)
        {
            if (!listHoliday.Contains(date))
            {
                return date;
            }

            return GetNextWorkingDay(date.AddDays(1), listHoliday);
        }


        private List<DateTime> GetActualExecuteDate(
            BtModel jobModelReq,
            List<DateTime> listHoliday)
        {
            List<int> listWeekDayIndex = jobModelReq.Schedule.yobi;

            List<DayOfWeek> listDayOfWeek = new List<DayOfWeek>();
            foreach (int weekDayIndex in listWeekDayIndex)
            {
                DayOfWeek dayOfWeek = ConvertIntToDayOfWeek(weekDayIndex);
                listDayOfWeek.Add(dayOfWeek);
            }

            DateTime startDate = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            List<DateTime> listDateLeftThisMonth = GetLeftDatesOfThisMonth(startDate);

            List<DateTime> listAllDatesOfNextMonth = GetAllDatesOfNextMonth(startDate);

            DateTime start = startDate;
            DateTime end = listAllDatesOfNextMonth[listAllDatesOfNextMonth.Count - 1];

            List<DateTime> listDatesOfSelectedWeekdays = GetDatesOfSelectedWeekdays(
                start,
                end,
                listDayOfWeek);

            List<DateTime> listSelectedDate = listDatesOfSelectedWeekdays;

            List<DateTime> listFinalExecutionDate = GetFinalExecutionDate(
                listSelectedDate,
                listHoliday);

            return listFinalExecutionDate;
        }

        private BtModel SetBtModel(
            BtModel jobModelReq,
            KeyValuePair<string, List<DateTime>> dict//,
                                                     //string jobidsuffix,
                                                     //string module,
                                                     //int hour,
                                                     //int minute
            )
        {
            //現在の年月
            string yearMonth = dict.Key;
            DateTime dateYearMonth = DateTime.Parse(yearMonth);

            //この年月のすべての日付リスト
            List<DateTime> listDateOfCurMonth = dict.Value;

            List<int> dayNumbers = listDateOfCurMonth.Select(e => e.Day).ToList();

            BtModel jobModel = new BtModel();

            //jobModel.jobidsuffix = jobidsuffix;
            //jobModel.Module = module;

            jobModel.Schedule = new BtScheduleModel();
            jobModel.Schedule.hindokbn = EnumHinDoKBN.OneTime;

            jobModel.Schedule.maitukihi = new List<int>();
            jobModel.Schedule.maitukihi.Add(dateYearMonth.Month);

            jobModel.Schedule.maitukituki = new List<int>();
            jobModel.Schedule.maitukituki = dayNumbers;

            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    jobModel.Schedule.taskstarthour24,
            //    jobModel.Schedule.taskstartminutes, 0);

            return jobModel;
        }

        private Dictionary<string, List<DateTime>> GetOrganizedDateDictionary(List<DateTime> listDate)
        {
            //{年月,現在の年月のすべての日付のリスト}のキーバリューペア
            Dictionary<string, List<DateTime>> dictYearMonthAndDates = new Dictionary<string, List<DateTime>>();

            //重複しない年月のリストを取得する
            var uniqueYearMonths = listDate.Select(e => new { e.Year, e.Month }).Distinct().ToList();

            foreach (var yearMonth in uniqueYearMonths)
            {
                int year = yearMonth.Year;
                int month = yearMonth.Month;

                DateTime date = new DateTime(year, month, 1);

                List<DateTime> listDateTime = new List<DateTime>();

                //現在の年月のすべての日付リストを取得する
                var listDatesOfSpecificMonth =
                    listDate.Where(e => e.Year == year && e.Month == month)
                    .ToList();

                dictYearMonthAndDates.Add(date.ToString("yyyyMM"), listDatesOfSpecificMonth);
            }

            return dictYearMonthAndDates;
        }

        public DayOfWeek ConvertIntToDayOfWeek(int weekDayIndex)
        {
            DayOfWeek dayOfWeek = new DayOfWeek();

            switch (weekDayIndex)
            {
                case 0:
                    dayOfWeek = DayOfWeek.Sunday;
                    break;
                case 1:
                    dayOfWeek = DayOfWeek.Monday;
                    break;
                case 2:
                    dayOfWeek = DayOfWeek.Tuesday;
                    break;
                case 3:
                    dayOfWeek = DayOfWeek.Wednesday;
                    break;
                case 4:
                    dayOfWeek = DayOfWeek.Thursday;
                    break;
                case 5:
                    dayOfWeek = DayOfWeek.Friday;
                    break;
                case 6:
                    dayOfWeek = DayOfWeek.Saturday;
                    break;
            }

            return dayOfWeek;
        }

        /// <summary>
        /// 毎月の指定された日に指定された時間にタスクを実行する
        /// </summary>
        /// <param name="listDate">実際に実行されるタスクの日付リスト</param>
        /// <param name="hour">タスクの実行時間の時間部分</param>
        /// <param name="minute">タスクの実行時間の分部分</param>
        /// <param name="jobidsuffix">ジョブの接尾辞</param>
        /// <param name="module">呼び出しされたタスクのクラス名</param>
        /// <param name="param"></param>
        private void ScheduleJobs(
            BtModel jobModel,
            List<DateTime> listHoliday,
            object? param = null)
        {
            List<DateTime> listDate = GetActualExecuteDate(
                jobModel,
                listHoliday);

            Dictionary<string, List<DateTime>> dictYearMonthAndDates = GetOrganizedDateDictionary(listDate);



            //{年月,現在の年月のすべての日付のリスト}のキーバリューペア
            //Dictionary<string, List<DateTime>> dictYearMonthAndDates = new Dictionary<string, List<DateTime>>();

            ////重複しない年月のリストを取得する
            //var uniqueYearMonths = listDate.Select(e => new { e.Year, e.Month }).Distinct().ToList();

            //foreach (var yearMonth in uniqueYearMonths)
            //{
            //    int year = yearMonth.Year;
            //    int month = yearMonth.Month;

            //    DateTime date = new DateTime(year, month, 1);

            //    List<DateTime> listDateTime = new List<DateTime>();

            //    //現在の年月のすべての日付リストを取得する
            //    var listDatesOfSpecificMonth =
            //        listDate.Where(e => e.Year == year && e.Month == month)
            //        .ToList();

            //    dictYearMonthAndDates.Add(date.ToString("yyyyMM"), listDatesOfSpecificMonth);
            //}



            //int hour = jobModel.Schedule.taskstarthour24;
            //int minute = jobModel.Schedule.taskstartminutes;
            string jobidsuffix = jobModel.TaskID;
            string module = jobModel.Module;

            int indexOfMonth = 0;
            foreach (var dict in dictYearMonthAndDates)
            {
                ++indexOfMonth;

                ////現在の年月
                //string yearMonth = dict.Key;
                //DateTime dateYearMonth = DateTime.Parse(yearMonth);

                ////この年月のすべての日付リスト
                //List<DateTime> listDateOfCurMonth = dict.Value;

                //List<int> dayNumbers = listDateOfCurMonth.Select(e => e.Day).ToList();
                //var resultDayNumbers = String.Join(",", dayNumbers);



                //[この月]の[選択された日]中、[特定の時間]に実行

                //BtModel jobModel = new BtModel();
                //jobModel.jobidsuffix = jobidsuffix;
                //jobModel.Module = module;

                //jobModel.Schedule = new BtScheduleModel();
                //jobModel.Schedule.hindokbn = HinDoKBN.EveryYearAtATime;

                //jobModel.Schedule.monthseveryyear = new List<int>();
                //jobModel.Schedule.monthseveryyear.Add(dateYearMonth.Month);

                //jobModel.Schedule.maigetunichi = new List<int>();
                //jobModel.Schedule.maigetunichi = dayNumbers;

                //jobModel.Schedule.startdttm = new DateTime(
                //    DateTime.Now.Year,
                //    DateTime.Now.Month,
                //    DateTime.Now.Day,
                //    hour,
                //    minute, 0);



                //BtModel jobModel = new BtModel();

                jobModel.TaskID = jobidsuffix;
                jobModel.Module = module;

                jobModel.Schedule = new BtScheduleModel();
                jobModel.Schedule.hindokbn = EnumHinDoKBN.OneTime;

                //現在の年月
                string yearMonth = dict.Key;
                DateTime dateYearMonth = DateTime.Parse(yearMonth);
                jobModel.Schedule.maitukihi = new List<int>();
                jobModel.Schedule.maitukihi.Add(dateYearMonth.Month);

                //この年月のすべての日付リスト
                List<DateTime> listDateOfCurMonth = dict.Value;
                List<int> dayNumbers = listDateOfCurMonth.Select(e => e.Day).ToList();
                jobModel.Schedule.maitukituki = new List<int>();
                jobModel.Schedule.maitukituki = dayNumbers;

                //jobModel.Schedule.startdttm = new DateTime(
                //    DateTime.Now.Year,
                //    DateTime.Now.Month,
                //    DateTime.Now.Day,
                //    jobModel.Schedule.taskstarthour24,
                //    jobModel.Schedule.taskstartminutes, 0);



                //BtModel jobModel = SetBtModel(
                //    jobModelReq,
                //    dict,
                //    jobidsuffix,
                //    module,
                //    hour,
                //    minute);

                //AddJob(jobModel, param);



                //RecurringJob.AddOrUpdate(
                //    jobidsuffix + "-" + indexOfMonth,
                //    () => job.Execute(jobidsuffix, param, null),
                //    minute + " " + hour + " " + resultDayNumbers + " " + dateYearMonth.Month + " *");


            }
        }


        #endregion

    }
}