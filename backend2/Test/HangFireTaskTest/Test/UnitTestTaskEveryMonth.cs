// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチ処理
//            
// 作成日　　: 2024.01.12
// 作成者　　: 羅
// 変更履歴　: 羅(2024.02.21)
// *******************************************************************

using BCC.Affect.BatchService;
using BCC.Affect.DataAccess;

namespace HangFireTaskTest.Test
{
    public class UnitTestTaskEveryMonth
    {
        MyApplicationFactory _factory;
        TestResult _testResult;

        [SetUp]
        public void Setup()
        {
            _factory = new MyApplicationFactory();
            _factory.CreateClient();

            _testResult = new TestResult();
        }

        #region Test

        //1
        //毎月特定の日を選択する(例:1日、6日...);
        //毎月選択された日の[特定の時間]に、タスクを実行する;
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryMonthDaysAtATime_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryMonth;

            string taskname = "Task1";

            string jobidsuffix = "Rock360";

            bool syukustugiflag = false;

            List<int> listSelectDayOfMonth = new List<int>() { 19, 20, 27 };

            int taskstarthour24 = 18;
            int taskstartminutes = 28;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //毎月実行する(休日も含む)
            //jobModel.Schedule.syukustugiflag = syukustugiflag;

            //要执行 的 类的名称
            jobModel.Module = taskname;

            //任务id后缀
            jobModel.TaskID = jobidsuffix;

            jobModel.Schedule.hindokbn = hindokbn;

            //毎月の日
            jobModel.Schedule.maitukituki = new List<int>();
            foreach (int day in listSelectDayOfMonth)
            {
                jobModel.Schedule.maitukituki.Add(day);
            }

            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    taskstarthour24,
            //    taskstartminutes,
            //    0);

            #endregion

            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db,jobModel);

            //このテストメソッドを遅延させる
            await Task.Delay(TimeSpan.FromMinutes(10));

            //このジョブの実行結果を判断する
            _testResult.OutputExecuteResult(jobId);
        }

        //2
        //毎月特定の日を選択する(例:1日、6日...);
        //毎月選択された日の中で、一定の間隔でタスクを繰り返し実行する;
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryMonthDaysRepeatByFixPeriod_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";

            string jobidsuffix = "Rock362";

            bool syukustugiflag = false;

            List<int> listDaysOfMonth = new List<int>();
            listDaysOfMonth.Add(2);
            listDaysOfMonth.Add(10);
            listDaysOfMonth.Add(27);

            EnumIntervalType intervalType = EnumIntervalType.Minutes30;

            int taskstarthour24 = 9;
            int taskstartminutes = 0;

            //Duration duration = Duration.Hour12;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //要执行 的 类的名称
            jobModel.Module = taskname;

            jobModel.Schedule.hindokbn = hindokbn;

            jobModel.Schedule.maitukituki = new List<int>();
            jobModel.Schedule.maitukituki = listDaysOfMonth;

            jobModel.Schedule.kurikaesikankbn = intervalType;

            //jobModel.Schedule.yukotm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    taskstarthour24,
            //    taskstartminutes,
            //    0);

            //jobModel.Schedule.keizokujikan = duration;

            //任务id后缀
            jobModel.TaskID = jobidsuffix;

            //毎月実行する(休日も含む)
            //jobModel.Schedule.syukustugiflag = syukustugiflag;

            #endregion
            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            await Task.Delay(TimeSpan.FromMinutes(10));

            _testResult.OutputExecuteResult(jobId);
        }

        //毎月の最終日
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryMonthLastDayAtATime_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";

            string jobidsuffix = "Rock362";

            bool syukustugiflag = false;

            int taskstarthour24 = 12;
            int taskstartminutes = 23;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = syukustugiflag;

            jobModel.Module = taskname;

            jobModel.TaskID = jobidsuffix;

            jobModel.Schedule.hindokbn = hindokbn;

            //jobModel.Schedule.taskstarthour24 = taskstarthour24;
            //jobModel.Schedule.taskstartminutes = taskstartminutes;

            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    jobModel.Schedule.taskstarthour24,
            //    jobModel.Schedule.taskstartminutes,
            //    0);

            #endregion
            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            await Task.Delay(TimeSpan.FromMinutes(10));

            _testResult.OutputExecuteResult(jobId);
        }

        //毎月、選択した週(週1,週2,週3,週4,週5)
        public async Task ExecuteEveryMonthWeeksAtATime_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";

            string jobidsuffix = "Rock050";

            bool syukustugiflag = false;

            //毎月選択された週
            List<int> listselectedweekofmonth = new List<int>();
            listselectedweekofmonth.Add(1);
            listselectedweekofmonth.Add(2);

            //毎週選択された日
            List<int> listdayofweek = new List<int>();
            listdayofweek.Add(3);
            listdayofweek.Add(5);
            listdayofweek.Add(6);

            int taskstarthour24 = 12;
            int taskstartminutes = 23;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //要执行 的 类的名称
            jobModel.Module = taskname;

            //任务id后缀
            jobModel.TaskID = jobidsuffix;

            jobModel.Schedule.hindokbn = hindokbn;

            //祝日次営業日実行フラグ
            //jobModel.Schedule.syukustugiflag = syukustugiflag;

            //週
            jobModel.Schedule.maitukisyu = new List<int>();
            jobModel.Schedule.maitukisyu = listselectedweekofmonth;

            //曜日
            jobModel.Schedule.yobi = new List<int>();
            jobModel.Schedule.yobi = listdayofweek;

            //jobModel.Schedule.taskstarthour24 = taskstarthour24;
            //jobModel.Schedule.taskstartminutes = taskstartminutes;

            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    jobModel.Schedule.taskstarthour24,
            //    jobModel.Schedule.taskstartminutes,
            //    0);

            #endregion
            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            await Task.Delay(TimeSpan.FromMinutes(10));

            _testResult.OutputExecuteResult(jobId);
        }

        #region 3

        //毎月中に特定の週を選択する(例:週1,週2...);
        //選択された週の中で、さらに週の中の日数を選択する(例:月曜日，火曜日...);
        //[選択された曜日の中]の[特定の時間]にタスクを実行する;
        //[Test]
        //[RunOnSpecificServer("Rock")]
        //public async Task ExecuteEveryMonthWeeksAtATime_Test()
        //{
        //    #region パラメータを取得する

        //    string taskname = "Task1";
        //    string jobidsuffix = "Rock038";

        //    int taskstarthour24 = 10;
        //    int taskstartminutes = 0;

        //    List<int> listweekofmonth = new List<int>();
        //    listweekofmonth.Add(1);
        //    listweekofmonth.Add(5);

        //    List<int> listdayofweek = new List<int>();
        //    listdayofweek.Add(2);
        //    listdayofweek.Add(3);
        //    listdayofweek.Add(4);
        //    listdayofweek.Add(5);

        //    bool syukustugiflag = false;

        //    #endregion

        //    #region BtModelにパラメータを設定する

        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    //每月的第几周(例如:第1周)
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listweekofmonth;

        //    //毎週の曜日(星期 2,3,4,5)
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listdayofweek;

        //    //祝日次営業日実行フラグ
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    #endregion

        //    //BtJobService btJobService = new BtJobService();
        //    string jobId = EveryMonthWeeksAtATime(jobModel);

        //    await Task.Delay(TimeSpan.FromMinutes(10));

        //    _testResult.OutputExecuteResult(jobId);
        //}

        #endregion

        #region 4

        //毎月中に特定の週を選択する(例:週1,週2...);
        //選択された週の中で、さらに週の中の日数を選択する(例:月曜日，火曜日...);
        //[選択された日]の間隔を置いて繰り返し実行する;
        //[Test]
        //[RunOnSpecificServer("Rock")]
        //public async Task ExecuteEveryMonthWeeksRepeatByFixPeriod_Test()
        //{
        //    #region パラメータを取得する

        //    string taskname = "Task1";

        //    string jobidsuffix = "Rock050";

        //    List<int> listweekofmonth = new List<int>();
        //    listweekofmonth.Add(1);
        //    listweekofmonth.Add(2);
        //    List<int> listdayofweek = new List<int>();
        //    listdayofweek.Add(3);
        //    listdayofweek.Add(5);
        //    listdayofweek.Add(6);

        //    bool syukustugiflag = false;

        //    int starthour = 9;
        //    int endhour = 18;
        //    List<int> listminutevaluetype = new List<int>() { 0, 30 };

        //    #endregion

        //    #region BtModelにパラメータを設定する

        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    //週
        //    //jobModel.Schedule.kurikaeshikan = IntervalType.Minutes2;
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listweekofmonth;

        //    //曜日
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listdayofweek;

        //    //祝日次営業日実行フラグ
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    jobModel.starthour = starthour;
        //    jobModel.endhour = endhour;

        //    jobModel.listminutevaluetype = listminutevaluetype;

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    string jobId = EveryMonthWeeksRepeatByFixPeriod(jobModel);

        //    #endregion

        //    await Task.Delay(TimeSpan.FromMinutes(10));

        //    _testResult.OutputExecuteResult(jobId);
        //}

        #endregion

        #endregion

        #region private methods

        #region 1

        //1
        //毎月の日
        //每月的选中的天(例如:1,10号),的 某个时间点 执行
        //public string ExecuteEveryMonthDaysAtATime(
        //    string taskname,
        //    HinDoKBN hindokbn,
        //    string jobidsuffix,
        //    bool syukustugiflag,
        //    List<int> listSelectDayOfMonth,
        //    int taskstarthour24,
        //    int taskstartminutes)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    #region cron

        //    jobModel.Schedule.hindokbn = hindokbn;

        //    //毎月の日
        //    jobModel.Schedule.maigetunichi = new List<int>();
        //    foreach (int day in listSelectDayOfMonth)
        //    {
        //        jobModel.Schedule.maigetunichi.Add(day);
        //    }

        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24, taskstartminutes, 0);

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    //毎月実行する(休日も含む)
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    string jobId = EveryMonthDays(jobModel);

        //    return jobId;
        //}

        //public string EveryMonthDays(BtModel jobModel)
        //{
        //    string jobId = "";

        //    #region Commons

        //    //BtJobService btJobService = new BtJobService();

        //    // 「祝日次営業日実行フラグ」を選択する
        //    //if (jobModel.Schedule.syukustugiflag)
        //    //{
        //    //    _timerEveryMonthDay = new System.Timers.Timer(8 * 60 * 60 * 1000);
        //    //    _timerEveryMonthDay.Elapsed += (s, e) =>
        //    //    {
        //    //        var today = DateTime.Today;
        //    //        int dayOfMonth = today.Day;

        //    //        //毎月選択された日数のリスト
        //    //        var listEveryMonthDay = jobModel.Schedule.maigetunichi;

        //    //        //今日は選択された日です
        //    //        if (listEveryMonthDay.Contains(dayOfMonth))
        //    //        {
        //    //            //日本の休日リストを取得する
        //    //            var holidays = btJobService.GetJapaneseOfficialHolidays();
        //    //            holidays = btJobService.ModifyHolidays(holidays);

        //    //            if (holidays.Contains(today) == true)
        //    //            {
        //    //                // 次の営業日を取得する
        //    //                var listSortedHoliday = btJobService.GetSortedJapaneseHolidays(holidays);
        //    //                DateTime nextWorkingDay = btJobService.FindNextWorkingDay(today, listSortedHoliday);

        //    //                jobId = BtJobService.AddJobOfOnce(jobModel, nextWorkingDay);
        //    //            }
        //    //        }
        //    //    };
        //    //    _timerEveryMonthDay.AutoReset = true;
        //    //    _timerEveryMonthDay.Enabled = true;
        //    //}

        //    #endregion

        //    //毎月実行する(休日も含む)
        //    if (jobModel.Schedule.syukustugiflag == false)
        //    {
        //        jobId = BtJobService.AddJob(jobModel);
        //    }

        //    return jobId;
        //}

        #endregion

        #region 2

        //2
        //每月的选中的天(例如:1,10号)(包含节假日);
        //从 [某个时间开始] 到 [某个时间结束] 的时间范围内; 14-15{14:00-15:59}
        //间隔一段时间执行;
        //public string ExecuteEveryMonthDaysRepeatByFixPeriod(
        //    string taskname,
        //    HinDoKBN hindokbn,
        //    string jobidsuffix,
        //    bool syukustugiflag,//false
        //    List<int> listDaysOfMonth,
        //    IntervalType intervalType,
        //    int taskstarthour24,
        //    int taskstartminutes,
        //    Duration duration)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    #region cron

        //    jobModel.Schedule.hindokbn = hindokbn;

        //    jobModel.Schedule.maigetunichi = new List<int>();
        //    jobModel.Schedule.maigetunichi = listDaysOfMonth;

        //    jobModel.Schedule.kurikaeshikan = intervalType; // IntervalType.Minutes2;

        //    jobModel.Schedule.yukotm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    jobModel.Schedule.keizokujikan = duration;// Duration.Hour1;

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix; // "Rock033";

        //    //毎月実行する(休日も含む)
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;// false;

        //    string jobId = EveryMonthDays(jobModel);

        //    return jobId;
        //}

        #endregion

        #region 3

        //3
        //每月的选中的星期;
        //在选中的每个星期中;
        //在选中的星期中,再[选中天数];
        //每天 的 [某个时间] 执行;
        //public string ExecuteEveryMonthWeeksAtATime(
        //    string taskname,
        //    string jobidsuffix,
        //    int taskstarthour24,
        //    int taskstartminutes,
        //    List<int> listweekofmonth,
        //    List<int> listdayofweek,
        //    bool syukustugiflag //= false;
        //    )
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;// "Task1";

        //    #region cron

        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    //每月的第几周(例如:第1周)
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listweekofmonth;

        //    //毎週の曜日(星期 2,3,4,5)
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listdayofweek;

        //    //祝日次営業日実行フラグ
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;// "Rock038";

        //    BtJobService btJobService = new BtJobService();
        //    string jobId = "";
        //    //string jobId = btJobService.EveryMonthWeeksAtATime(jobModel);

        //    return jobId;
        //}

        //3
        //public string EveryMonthWeeksAtATime(BtModel jobModel)
        //{
        //    string jobId = "";

        //    BtJobService btJobService = new BtJobService();

        //    DateTime runTime = jobModel.Schedule.startdttm;
        //    int hour = runTime.Hour;
        //    int minute = runTime.Minute;
        //    int second = runTime.Second;

        //_timerEveryMonthWeekDayAtATime = new System.Timers.Timer(5 * 60 * 1000);//5 * 60 * 60 * 1000
        //_timerEveryMonthWeekDayAtATime.Elapsed += (s, e) =>
        //{
        //    //毎月の週
        //    //1...5
        //    List<int> listWeeksPerMonth = jobModel.Schedule.maigetusyu;

        //    //今日の週は選択された週に含まれています
        //    int nWeekIndex = GetWeekOfMonth(DateTime.Now);
        //    if (listWeeksPerMonth.Contains(nWeekIndex))
        //    {
        //        //毎週の曜日
        //        //0...6
        //        List<int> listWeekDay = jobModel.Schedule.maisyuyoubi;

        //        var today = DateTime.Today;

        //        //選択された曜日のリストをループする
        //        foreach (int weekDay in listWeekDay)
        //        {
        //            //weekDayが表す日付を取得する
        //            int daysUntilThatDay = (weekDay - (int)today.DayOfWeek + 7) % 7;
        //            DateTime thisDay = today.AddDays(daysUntilThatDay);

        //            IBtService job = BtFactory.GetService(jobModel.Module);
        //            string currentJobId = GetJobId() + jobModel.jobidsuffix;

        //            var japanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        //            // 祝日次営業日実行フラグ
        //            if (jobModel.Schedule.syukustugiflag)
        //            {
        //                //日本の休日リストを取得する
        //                var holidays = this.GetJapaneseOfficialHolidays();
        //                holidays = this.ModifyHolidays(holidays);

        //                //この日は休日です
        //                if (holidays.Contains(thisDay) == true)
        //                {
        //                    // 次の営業日を取得する
        //                    var listSortedHoliday = this.GetSortedJapaneseHolidays(holidays);
        //                    DateTime nextWorkingDay = this.FindNextWorkingDay(thisDay, listSortedHoliday);

        //                    if (nextWorkingDay > DateTime.Now)
        //                    {
        //                        var japanTime = new DateTimeOffset(
        //                            nextWorkingDay.Year, nextWorkingDay.Month, nextWorkingDay.Day,
        //                            hour, minute, second,
        //                            japanTimeZone.GetUtcOffset(
        //                                new DateTime(
        //                                    nextWorkingDay.Year, nextWorkingDay.Month, nextWorkingDay.Day,
        //                                    hour, minute, second)));

        //                        jobId = BackgroundJob.Schedule(
        //                            () => job.Execute(currentJobId, null, null),
        //                            japanTime);
        //                    }
        //                }
        //                else
        //                {
        //                    var japanTime = new DateTimeOffset(
        //                            thisDay.Year, thisDay.Month, thisDay.Day,
        //                            hour, minute, second,
        //                            japanTimeZone.GetUtcOffset(
        //                                new DateTime(
        //                                    thisDay.Year, thisDay.Month, thisDay.Day,
        //                                    hour, minute, second)));

        //                    jobId = BackgroundJob.Schedule(
        //                        () => job.Execute(currentJobId, null, null),
        //                        japanTime);
        //                }
        //            }
        //            else
        //            {
        //                var japanTime = new DateTimeOffset(
        //                        thisDay.Year, thisDay.Month, thisDay.Day,
        //                        hour, minute, second,
        //                        japanTimeZone.GetUtcOffset(
        //                            new DateTime(
        //                                thisDay.Year, thisDay.Month, thisDay.Day,
        //                                hour, minute, second)));

        //                jobId = BackgroundJob.Schedule(
        //                    () => job.Execute(currentJobId, null, null),
        //                    japanTime);
        //            }
        //        }
        //    }
        //};
        //_timerEveryMonthWeekDayAtATime.AutoReset = true;
        //_timerEveryMonthWeekDayAtATime.Enabled = true;

        //    return jobId;
        //}

        #endregion

        #region 4

        //4
        //每月的选中的星期;
        //在选中的每个星期中;
        //在选中的星期中,再[选中天数];
        //每天 [间隔一段时间 重复执行];
        //public string ExecuteEveryMonthWeeksRepeatByFixPeriod(
        //    string taskname,
        //    string jobidsuffix,
        //    List<int> listweekofmonth,
        //    List<int> listdayofweek,
        //    bool syukustugiflag,
        //    int starthour,
        //    int endhour,
        //    List<int> listminutevaluetype)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;// "Task1";

        //    #region cron

        //    //週
        //    //jobModel.Schedule.kurikaeshikan = IntervalType.Minutes2;
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listweekofmonth;

        //    //曜日
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listdayofweek;

        //    //祝日次営業日実行フラグ
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    jobModel.starthour = starthour;
        //    jobModel.endhour = endhour;

        //    jobModel.listminutevaluetype = listminutevaluetype;// new List<int>() { 0, 30 };

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;// "Rock050";

        //    string jobId = EveryMonthWeeksRepeatByFixPeriod(jobModel);

        //    return jobId;
        //}

        //public string EveryMonthWeeksRepeatByFixPeriod(BtModel jobModel)
        //{
        //    string jobId = "";

        //    BtJobService btJobService = new BtJobService();

        ////IntervalType intervalType = jobModel.Schedule.kurikaeshikan;
        ////int nIntervalMinutes = jobModel.Schedule.GetIntervalMinutes(intervalType);

        ////int startHour = 9;
        ////int endHour = 18;
        ////List<int> listMinuteValueType = new List<int>() { 0, 30 };

        //_timerEveryMonthWeekDayRepeatByFixPeriod = new System.Timers.Timer(1 * 60 * 1000);//5 * 60 * 60 * 1000
        //_timerEveryMonthWeekDayRepeatByFixPeriod.Elapsed += (s, e) =>
        //{
        //    if (DateTime.Now.DayOfWeek == DayOfWeek.Friday && DateTime.Now.Hour == 15 && DateTime.Now.Minute == 50)
        //    {
        //        //毎月の週
        //        //1...5
        //        List<int> listWeeksPerMonth = jobModel.Schedule.maigetusyu;

        //        //今日の週は選択された週に含まれています
        //        int nWeekIndex = GetWeekOfMonth(DateTime.Now);

        //        if (listWeeksPerMonth.Contains(nWeekIndex))
        //        {
        //            //毎週の曜日
        //            //0...6
        //            List<int> listWeekDay = jobModel.Schedule.maisyuyoubi;

        //            var today = DateTime.Today;

        //            //選択された曜日のリストをループする
        //            foreach (int weekDay in listWeekDay)
        //            {
        //                //weekDayが表す日付を取得する
        //                int daysUntilThatDay = weekDay - (int)today.DayOfWeek;
        //                if (daysUntilThatDay >= 0)
        //                {
        //                    DateTime thisDay = today.AddDays(daysUntilThatDay);

        //                    IBtService job = BtFactory.GetService(jobModel.Module);

        //                    // 祝日次営業日実行フラグ
        //                    if (jobModel.Schedule.syukustugiflag)
        //                    {
        //                        //日本の休日リストを取得する
        //                        var holidays = this.GetJapaneseOfficialHolidays();
        //                        holidays = this.ModifyHolidays(holidays);

        //                        //この日は休日です
        //                        if (holidays.Contains(thisDay) == true)
        //                        {
        //                            // 次の営業日を取得する
        //                            var listSortedHoliday = this.GetSortedJapaneseHolidays(holidays);
        //                            DateTime nextWorkingDay = this.FindNextWorkingDay(thisDay, listSortedHoliday);

        //                            jobId = ScheduleTasksForSpecificDayTimes(nextWorkingDay, job, jobModel, jobModel.starthour, jobModel.endhour, jobModel.listminutevaluetype);
        //                        }
        //                        else
        //                        {
        //                            jobId = ScheduleTasksForSpecificDayTimes(thisDay, job, jobModel, jobModel.starthour, jobModel.endhour, jobModel.listminutevaluetype);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        jobId = ScheduleTasksForSpecificDayTimes(thisDay, job, jobModel, jobModel.starthour, jobModel.endhour, jobModel.listminutevaluetype);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //};
        //_timerEveryMonthWeekDayRepeatByFixPeriod.AutoReset = true;
        //_timerEveryMonthWeekDayRepeatByFixPeriod.Enabled = true;

        //    return jobId;
        //}

        #endregion

        #endregion
    }
}
