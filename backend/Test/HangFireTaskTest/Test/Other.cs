using BCC.Affect.BatchService;
using BCC.Affect.DataAccess;
using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BCC.Affect.BatchService
{
    public class Other
    {
        #region 1：毎日

        #region V2

        //private void GetParmsFromConfig2(
        //    out string module,
        //    out string suffix,
        //    out string doesNotRunOnHoliday,
        //    out string frequencyType,
        //    out string taskStartHour24,
        //    out string taskStartMinutes,
        //    out string duration,
        //    out string intervalType)
        //{
        //    int id = 2;

        //    string exePath = Assembly.GetExecutingAssembly().Location;
        //    string configPath = Path.Combine(Path.GetDirectoryName(exePath), "App.config");

        //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    var xmlDoc = new XmlDocument();
        //    xmlDoc.Load(configPath);

        //    var jobNodes = xmlDoc.SelectNodes("/configuration/job");
        //    if (jobNodes != null)
        //    {
        //        foreach (XmlNode node in jobNodes)
        //        {
        //            var idAttribute = node.Attributes["id"];
        //        }
        //    }
        //}



        #endregion

        #region V1

        //ok(Tested)
        //毎日(祝日を含む)の[ある時刻]から[ある時刻]までの時間内に、[2分]ごとに実行
        //public string ExecuteIntervalMinutesEveryDay(
        //    string taskname,
        //    int taskstarthour24,
        //    int taskstartminutes,
        //    string jobidsuffix,
        //    Duration duration,
        //    IntervalType intervaltype)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //実行する必要のあるクラスの名前
        //    jobModel.Module = taskname;// "Task1";

        //    #region cron

        //    //11：毎日(毎日(特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)実行。)
        //    jobModel.Schedule.hindokbn = HinDoKBN.EveryDayRepeatByFixPeriod;//"11";

        //    //祝日実行しないフラグ(execute everyday)
        //    jobModel.Schedule.syukushinaiflag = false;

        //    //有効開始時刻 + 持続時間 = 終了時間

        //    //有効開始時刻
        //    jobModel.Schedule.taskstarthour24 = taskstarthour24;
        //    jobModel.Schedule.taskstartminutes = taskstartminutes;
        //    jobModel.Schedule.yukotm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        jobModel.Schedule.taskstarthour24,
        //        jobModel.Schedule.taskstartminutes, 0);//9, 0, 0

        //    //持続時間[12時間続く]
        //    jobModel.Schedule.keizokujikan = duration;//Duration.Hour12;

        //    //2分間隔で実行
        //    jobModel.Schedule.kurikaeshikan = intervaltype;//IntervalType.Minutes2;

        //    #endregion

        //    //タスクIDサフィックス
        //    jobModel.jobidsuffix = jobidsuffix;

        //    BtJobService btJobService = new BtJobService();
        //    string jobId = btJobService.ExecuteEveryDay(jobModel);

        //    return jobId;
        //}





        private System.Timers.Timer _timerEveryDay;



        #endregion

        #endregion

        #region 2：毎週





        private System.Timers.Timer _timerEveryWeek;



        #endregion

        #region 毎月の日





        private System.Timers.Timer _timerEveryMonthDay;

        //毎月の指定された日に、特定の時間に実行
        //毎月の指定された日に、ある時間から別の時間まで、一定の間隔で実行
        

        #endregion

        #region 毎月の曜日

        private System.Timers.Timer _timerEveryMonthWeekDayAtATime;

        //not ok
        

        private System.Timers.Timer _timerEveryMonthWeekDayRepeatByFixPeriod;





        //not ok
        

        private int GetWeekOfMonth(DateTime date)
        {
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            int firstDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            firstDayOfWeek = firstDayOfWeek == 0 ? 7 : firstDayOfWeek;

            int dayofMonth = date.Day;

            return (int)Math.Ceiling((dayofMonth + firstDayOfWeek - 1) / 7.0);
        }

        private string ScheduleTasksForSpecificDayTimes(
            DateTime specificDay,
            IBtService job,
            BtModel jobModel,
            int startHour,
            int endHour,
            List<int> listMinuteValueType)
        {
            string returnJobId = "";

            //var startHour = 15;
            //var endHour = 18;

            for (int hour = startHour; hour < endHour; hour++)
            {
                //var times = new[] { 0, 30 };

                foreach (var minute in listMinuteValueType)
                {
                    var executeTime = new DateTime(specificDay.Year, specificDay.Month, specificDay.Day, hour, minute, 0);

                    TimeZoneInfo japanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
                    DateTime executeUTCDateTime = TimeZoneInfo.ConvertTimeToUtc(executeTime, japanTimeZone);

                    if (executeTime > DateTime.Now)
                    {
                        string jobId = GetJobId() + jobModel.TaskID;

                        returnJobId = BackgroundJob.Schedule(() => job.Execute(jobId, null, null, null), executeUTCDateTime);
                    }
                }
            }

            return returnJobId;
        }

        #endregion

        #region 毎月の月(毎年の月) (特定の時間から始まり、特定の時間に終了し、一定の分数間隔で一回実行する)





        //private System.Timers.Timer _timerEveryYearMonthsAtATimeDays;

        //選択された月、毎月の選択された日
        //public void EveryYearMonthsAtATimeDays(BtModel jobModel)
        //{
        //    _timerEveryYearMonthsAtATimeDays = new System.Timers.Timer(16 * 60 * 60 * 1000);
        //    _timerEveryYearMonthsAtATimeDays.Elapsed += (s, e) =>
        //    {
        //        //選択された年中の月
        //        List<int> listMonthsEveryYear = jobModel.Schedule.monthseveryyear;

        //        int month = DateTime.Now.Month;

        //        if (listMonthsEveryYear.Contains(month))
        //        {
        //            //毎月の日
        //            List<int> listEveryMonthDay = jobModel.Schedule.maigetunichi;

        //            int dayofMonth = DateTime.Now.Day;

        //            //毎月の日
        //            if (listEveryMonthDay.Contains(dayofMonth))
        //            {
        //                AddJobOfOnce(jobModel);
        //            }
        //        }
        //    };
        //    _timerEveryYearMonthsAtATimeDays.AutoReset = true;
        //    _timerEveryYearMonthsAtATimeDays.Enabled = true;
        //}

        private System.Timers.Timer _timerEveryYearMonthsAtATimeWeeks;

        //not ok
        
        //public void EveryYearMonthsAtATimeWeeks(BtModel jobModel)
        //{
        //    _timerEveryYearMonthsAtATimeWeeks = new System.Timers.Timer(16 * 60 * 60 * 1000);
        //    _timerEveryYearMonthsAtATimeWeeks.Elapsed += (s, e) =>
        //    {
        //        //選択された年中の月
        //        List<int> listMonthsEveryYear = jobModel.Schedule.monthseveryyear;

        //        int month = DateTime.Now.Month;

        //        //選択された月
        //        if (listMonthsEveryYear.Contains(month))
        //        {
        //            //毎月の週
        //            List<int> listWeek = jobModel.Schedule.maigetusyu;

        //            int week = GetWeekOfMonth(DateTime.Now);

        //            //今日の週は選択された週に含まれています
        //            if (listWeek.Contains(week))
        //            {
        //                //曜日
        //                List<int> listDayOfWeek = jobModel.Schedule.maisyuyoubi;//0...6

        //                //0...6
        //                int dayOfWeekNumber = (int)DateTime.Now.DayOfWeek;

        //                //一週間中に選択された日
        //                if (listDayOfWeek.Contains(dayOfWeekNumber))
        //                {
        //                    AddJobOfOnce(jobModel);
        //                }
        //            }
        //        }
        //    };
        //    _timerEveryYearMonthsAtATimeWeeks.AutoReset = true;
        //    _timerEveryYearMonthsAtATimeWeeks.Enabled = true;
        //}

        private System.Timers.Timer _timerEveryYearMonthsRepeatByFixPeriod;

        //not ok
        //public void EveryYearMonthsRepeatByFixPeriod(BtModel jobModel)
        //{
        //    _timerEveryYearMonthsRepeatByFixPeriod = new System.Timers.Timer(16 * 60 * 60 * 1000);
        //    _timerEveryYearMonthsRepeatByFixPeriod.Elapsed += (s, e) =>
        //    {
        //        //選択された年中の月
        //        List<int> listMonthsEveryYear = jobModel.Schedule.monthseveryyear;

        //        int month = DateTime.Now.Month;

        //        if (listMonthsEveryYear.Contains(month))
        //        {
        //            //毎月の日
        //            List<int> listEveryMonthDay = jobModel.Schedule.maigetunichi;

        //            int dayofMonth = DateTime.Now.Day;

        //            if (listEveryMonthDay.Contains(dayofMonth))
        //            {
        //                IBtService job = BtFactory.GetService(jobModel.Module);

        //                ScheduleTasksForSpecificDayTimes(DateTime.Now, job, jobModel);
        //            }
        //        }
        //    };
        //    _timerEveryYearMonthsRepeatByFixPeriod.AutoReset = true;
        //    _timerEveryYearMonthsRepeatByFixPeriod.Enabled = true;
        //}

        //private void CreateTasksForToday()
        //{
        //    var startTime = new TimeSpan(8, 0, 0);
        //    var endTime = new TimeSpan(18, 0, 0);
        //    var interval = TimeSpan.FromMinutes(30);

        //    for (var time = startTime; time <= endTime; time += interval)
        //    {
        //        var executionTime = DateTime.Today.Add(time);
        //        if (executionTime > DateTime.Now)
        //        {
        //            //BackgroundJob.Schedule(,executionTime);
        //        }
        //    }
        //}

        #endregion

        #region 毎月の最終日

        private System.Timers.Timer _timerEveryMonthLastDay;

        public void EveryMonthLastDay(BtModel jobModel)
        {
            _timerEveryMonthLastDay = new System.Timers.Timer(20 * 60 * 60 * 1000);
            _timerEveryMonthLastDay.Elapsed += (s, e) =>
            {
                if (IsLastDayOfMonth())
                {
                    IBtService job = BtFactory.GetService(jobModel.Module);
                    Expression<Action<string>> methodCall = (jobId) => job.Execute(jobId, null, null, null);

                    string jobId = BackgroundJob.Schedule(methodCall, TimeSpan.FromMinutes(10));
                }
            };
            _timerEveryMonthLastDay.AutoReset = true;
            _timerEveryMonthLastDay.Enabled = true;
        }

        //今日が今月の最終日かどうかを判断する
        private static bool IsLastDayOfMonth()
        {
            DateTime date = DateTime.Now;
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            return date.Date == lastDayOfMonth.Date;
        }

        #endregion

        #region 毎月の最終週

        private System.Timers.Timer _timerEveryMonthLastWeek;

        //not ok
        public void EveryMonthLastWeek(BtModel jobModel)
        {
            _timerEveryMonthLastWeek = new System.Timers.Timer(22 * 60 * 60 * 1000);
            _timerEveryMonthLastWeek.Elapsed += (s, e) =>
            {
                if (IsLastWeekOfMonth())
                {
                    //今日、「選択された曜日の集合」に含まれていますか
                    //0...6
                    int dayOfWeekNumber = (int)DateTime.Now.DayOfWeek;
                    if (jobModel.Schedule.yobi.Contains(dayOfWeekNumber))
                    {
                        IBtService job = BtFactory.GetService(jobModel.Module);
                        Expression<Action<string>> methodCall = (jobId) => job.Execute(jobId, null, null, null);

                        string jobId = BackgroundJob.Schedule(methodCall, TimeSpan.FromMinutes(10));
                    }
                }
            };
            _timerEveryMonthLastWeek.AutoReset = true;
            _timerEveryMonthLastWeek.Enabled = true;
        }

        private bool IsLastWeekOfMonth()
        {
            DateTime date = DateTime.Now;

            DateTime datePlusOneWeek = date.AddDays(7);
            return date.Month != datePlusOneWeek.Month;
        }

        #endregion

        #region 一度実行するタスク

        /// <summary>
        /// 一度だけ実行するタスクを作成する(0：一回のみ)
        /// </summary>
        /// <param name="jobModel"></param>
        /// <returns></returns>
        public static string AddJobOfOnce(BtModel jobModel)
        {
            IBtService job = BtFactory.GetService(jobModel.Module);
            Expression<Action<string>> methodCall = (jobId) => job.Execute(jobId, null, null, null);
            var db = new DaDbContext();
            var expression = jobModel.GetCronExpression(db, jobModel.Schedule.StartTime);
            var jobId = BackgroundJob.Schedule(methodCall, DateTime.Parse(expression));
            return jobId;
        }

        public static string AddJobOfOnce(BtModel jobModel, DateTime executeDateTime)
        {
            IBtService job = BtFactory.GetService(jobModel.Module);
            Expression<Action<string>> methodCall = (jobId) => job.Execute(jobId, null, null, null);

            var specificDate = new DateTime(
                executeDateTime.Year, executeDateTime.Month, executeDateTime.Day,
                executeDateTime.Hour, executeDateTime.Minute, executeDateTime.Second);
            var jobId = BackgroundJob.Schedule(methodCall, specificDate);
            return jobId;
        }

        /// <summary>
        /// 一度実行するタスクを削除する
        /// </summary>
        /// <param name="jobId"></param>
        public static void DeleteJobOfOnce(string jobId)
        {
            BackgroundJob.Delete(jobId);
        }

        #endregion

        #region 祝日を取得する

        

        /// <summary>
        /// 休日リストを修正する
        /// </summary>
        /// <param name="holidays"></param>
        /// <returns></returns>
        public HashSet<DateTime> ModifyHolidays(HashSet<DateTime> holidays)
        {
            return holidays;
        }

        public List<DateTime> ModifyHolidaysV2()
        {
            List<DateTime> holidays = new List<DateTime>();

            return holidays;
        }

        /// <summary>
        /// 並べ替えられた日本の祝日を取得する
        /// </summary>
        /// <returns></returns>
        public List<DateTime> GetSortedJapaneseHolidays(HashSet<DateTime> holidays)
        {
            var sortedHolidays = holidays.ToList();
            sortedHolidays.Sort();
            return sortedHolidays;
        }

        /// <summary>
        /// 次の営業日を見つける
        /// </summary>
        /// <param name="currentDay"></param>
        /// <param name="holidays"></param>
        /// <returns></returns>
        public DateTime FindNextWorkingDay(
            DateTime currentDay,
            List<DateTime> listHoliday)
        {
            var nextDay = currentDay.AddDays(1);
            while (listHoliday.Contains(nextDay))
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        #endregion

        /// <summary>
        /// JobIdを作成する
        /// </summary>
        /// <returns></returns>
        public static string GetJobId()
        {
            // TODO
            //Get ID from Table(どうして)
            return Guid.NewGuid().ToString("N");
        }
    }
}
