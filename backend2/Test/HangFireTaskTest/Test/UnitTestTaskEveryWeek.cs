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
    public class TestParameter
    {
        public List<DayOfWeek> listDayOfWeek { get; set; }
        public List<DateTime> listHoliday { get; set; }
        public int hour { get; set; }
        public int minute { get; set; }
        public BtModel jobModel { get; set; }
    }

    [TestFixture]
    public class UnitTestTaskEveryWeek
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

        #region 実行日付リストの取得        

        /// <summary>
        /// 時間を日本時間に変換する
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        //private DateTime GetJapanDateTime(DateTime dateTime)
        //{
        //    TimeZoneInfo japanTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");

        //    DateTime jobDateInJapan = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local, japanTimeZone);

        //    return jobDateInJapan;
        //}

        #endregion



        [Test]
        [TestCaseSource(nameof(TestData))]
        public void ExecuteEveryWeekAtATime_TestV2(TestParameter testData)
        {
            //List<DateTime> listHoliday = testData.listHoliday;
            //int hour = testData.hour;
            //int minute = testData.minute;
            //BtModel jobModel = testData.jobModel;

            //DateTime startDate = DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            //List<DateTime> listDateLeftThisMonth = GetLeftDatesOfThisMonth(startDate);

            //List<DateTime> listAllDatesOfNextMonth = GetAllDatesOfNextMonth(startDate);

            //DateTime start = startDate;
            //DateTime end = listAllDatesOfNextMonth[listAllDatesOfNextMonth.Count - 1];

            //List<DayOfWeek> listDayOfWeek = testData.listDayOfWeek;

            //List<DateTime> listDatesOfSelectedWeekdays = GetDatesOfSelectedWeekdays(
            //    start,
            //    end,
            //    listDayOfWeek);

            //List<DateTime> listSelectedDate = listDatesOfSelectedWeekdays;

            //List<DateTime> listFinalExecutionDate = GetFinalExecutionDate(
            //    listSelectedDate,
            //    listHoliday);

            //object? param = null;
            ////ScheduleJobs(
            ////    listFinalExecutionDate,
            ////    hour,
            ////    minute,
            ////    //jobModel,
            ////    jobModel.jobidsuffix,
            ////    jobModel.Module,
            ////    param);
        }

        private static IEnumerable<TestParameter> TestData()
        {
            BtModel jobModel1 = new BtModel();
            yield return new TestParameter
            {
                listHoliday = new List<DateTime> { },
                listDayOfWeek = new List<DayOfWeek>() { DayOfWeek.Monday },
                hour = 9,
                minute = 30,
                jobModel = jobModel1
            };
        }




        #region Test

        //1
        //毎週選択された日に、特定の時間にタスクを実行する
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryWeekAtATime_Test()
        {
            var currentServer = Environment.GetEnvironmentVariable("SERVER_NAME");

            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryWeek;

            string taskname = "Task1";

            string jobidsuffix = "Rock355";

            //実行時間
            int taskstarthour24 = 16;
            int taskstartminutes = 46;

            //祝日次営業日実行フラグ
            bool syukustugiflag = false;

            //毎週選択された日
            List<int> listWeekDay = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = false;

            //要执行 的 类的名称
            jobModel.Module = taskname;

            //任务id后缀
            jobModel.TaskID = jobidsuffix;

            jobModel.Schedule.hindokbn = hindokbn;

            //毎週の曜日
            jobModel.Schedule.yobi = new List<int>();
            foreach (int weekday in listWeekDay)
            {
                jobModel.Schedule.yobi.Add(weekday);
            }

            ////Execute Time
            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    taskstarthour24,
            //    taskstartminutes,
            //    0);

            ////祝日次営業日実行フラグ
            //jobModel.Schedule.syukustugiflag = syukustugiflag;

            #endregion

            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            //このテストメソッドを遅延させる
            await Task.Delay(TimeSpan.FromMinutes(5));

            //このジョブの実行結果を判断する
            _testResult.OutputExecuteResult(jobId);
        }

        //2
        //毎週選択された日数の中で、一定の時間間隔で繰り返し実行されます
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryWeekRepeatByFixPeriod_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";

            string jobidsuffix = "Rock359";

            //毎週、選択された曜日(0,1,2,3,4,5,6)のリスト
            List<int> listWeekday = new List<int>() { 0, 1, 2, 3, 4, 5, 6 };

            EnumIntervalType intervalType = EnumIntervalType.Minutes30;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = false;

            //要执行 的 类的名称
            jobModel.Module = taskname;

            //任务id后缀
            jobModel.TaskID = jobidsuffix;

            jobModel.Schedule.hindokbn = hindokbn;

            jobModel.Schedule.yobi = new List<int>();
            foreach (int weekday in listWeekday)
            {
                jobModel.Schedule.yobi.Add(weekday);
            }

            //有効開始時刻
            jobModel.Schedule.beginhour = 9;
            jobModel.Schedule.beginminute = 0;

            //有効終了時刻
            jobModel.Schedule.endhour = 21;
            jobModel.Schedule.endminute = 0;

            jobModel.Schedule.kurikaesikankbn = intervalType;

            #endregion
            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            //このテストメソッドを遅延させる
            await Task.Delay(TimeSpan.FromMinutes(12));

            //このジョブの実行結果を判断する
            _testResult.OutputExecuteResult(jobId);
        }

        #endregion

        #region private methods

        #region 1

        //1
        //每周 中,选中 某几天(例如:星期2,星期3);
        //[在每周中 选中的 每天中] 的 [某个固定的时间] 执行;
        //public string ExecuteEveryWeekAtATime(
        //    string taskname,// "Task1";
        //    HinDoKBN hindokbn,// HinDoKBN.EveryWeekAtATime;// "2";
        //    string jobidsuffix,
        //    int taskstarthour24,
        //    int taskstartminutes,
        //    bool syukustugiflag,//false;
        //    List<int> listWeekDay)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    #region cron

        //    jobModel.Schedule.hindokbn = hindokbn;

        //    //毎週の曜日
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    foreach (int weekday in listWeekDay)
        //    {
        //        jobModel.Schedule.maisyuyoubi.Add(weekday);
        //    }

        //    //Execute Time
        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24, taskstartminutes, 0);

        //    //祝日次営業日実行フラグ
        //    jobModel.Schedule.syukustugiflag = syukustugiflag;

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    string jobId = ExecuteEveryWeek(jobModel);

        //    return jobId;
        //}

        //1
        //public string ExecuteEveryWeek(BtModel jobModel)
        //{
        //    string jobId = "";

        //    #region Comments

        //    //BtJobService btJobService = new BtJobService();

        //    // 「祝日次営業日実行フラグ」を選択する
        //    //if (jobModel.Schedule.syukustugiflag)
        //    //{
        //    //    _timerEveryWeek = new System.Timers.Timer(10 * 60 * 60 * 1000);
        //    //    _timerEveryWeek.Elapsed += (s, e) =>
        //    //    {
        //    //        var today = DateTime.Today;

        //    //        DayOfWeek dayOfWeek = today.DayOfWeek;
        //    //        int dayOfWeekNumber = (int)dayOfWeek;

        //    //        //今日は「毎週選択された日のリスト」に含まれています
        //    //        //0...6
        //    //        var listWeekDays = jobModel.Schedule.maisyuyoubi;
        //    //        if (listWeekDays.Contains(dayOfWeekNumber))
        //    //        {
        //    //            //日本の休日リストを取得する
        //    //            var holidays = btJobService.GetJapaneseOfficialHolidays();
        //    //            holidays = btJobService.ModifyHolidays(holidays);

        //    //            //今日は休日です
        //    //            if (holidays.Contains(today) == true)
        //    //            {
        //    //                // 次の営業日を取得する
        //    //                var listSortedHoliday = btJobService.GetSortedJapaneseHolidays(holidays);
        //    //                DateTime nextWorkingDay = btJobService.FindNextWorkingDay(today, listSortedHoliday);

        //    //                jobId = AddJobOfOnce(jobModel, nextWorkingDay);
        //    //            }
        //    //        }
        //    //    };
        //    //    _timerEveryWeek.AutoReset = true;
        //    //    _timerEveryWeek.Enabled = true;
        //    //}

        //    #endregion

        //    //毎週選択した日に、タスクを実行する
        //    if (jobModel.Schedule.syukustugiflag == false)
        //    {
        //        jobId = BtJobService.AddJob(jobModel);
        //    }

        //    return jobId;
        //}

        #endregion

        #region 2

        //ok
        //每周 中,选中 某几天(例如:星期2,星期3);
        //[在每周中 选中的 每天中],从 [某个时间] 到 [某个时间] 内,每 [间隔一段时间] 执行一次
        //public string ExecuteEveryWeekRepeatByFixPeriod(
        //    string taskname,
        //    HinDoKBN hindokbn,
        //    string jobidsuffix,
        //    List<int> listWeekday,
        //    int taskstarthour24,
        //    int taskstartminutes,
        //    Duration duration,
        //    IntervalType intervalType)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    #region cron

        //    jobModel.Schedule.hindokbn = hindokbn;

        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    foreach (int weekday in listWeekday)
        //    {
        //        jobModel.Schedule.maisyuyoubi.Add(weekday);
        //    }

        //    jobModel.Schedule.yukotm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    jobModel.Schedule.keizokujikan = duration;//Duration.Hour12;

        //    jobModel.Schedule.kurikaeshikan = intervalType;//IntervalType.Minutes2;

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;//"Rock013";

        //    string jobId = ExecuteEveryWeek(jobModel);

        //    return jobId;
        //}

        #endregion

        #endregion



    }
}
