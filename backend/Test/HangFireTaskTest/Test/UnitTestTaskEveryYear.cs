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
    public class UnitTestTaskEveryYear
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

        #region 1

        //timer
        //[Test]
        //public async Task ExecuteEveryYearMonthsWeeksDaysAtATime_Test()
        //{
        //    #region パラメータを取得する

        //    string taskname = "Task1";
        //    string jobidsuffix = "Rock053";

        //    List<int> listSelectMonth = new List<int>();
        //    listSelectMonth.Add(2);
        //    listSelectMonth.Add(5);

        //    List<int> listSelectWeek = new List<int>();
        //    listSelectWeek.Add(1);

        //    List<int> listSelectWeekDay = new List<int>();
        //    listSelectWeekDay.Add(5);
        //    listSelectWeekDay.Add(6);

        //    int taskstarthour24 = 13;
        //    int taskstartminutes = 30;

        //    #endregion

        //    #region BtModelにパラメータを設定する

        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    //月
        //    jobModel.Schedule.monthseveryyear = new List<int>();
        //    jobModel.Schedule.monthseveryyear = listSelectMonth;

        //    //毎月の週
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listSelectWeek;

        //    //毎週の曜日
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listSelectWeekDay;

        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    #endregion

        //    string jobId = EveryYearMonthsWeeksDaysAtATime(jobModel);

        //    await Task.Delay(TimeSpan.FromMinutes(10));

        //    _testResult.OutputExecuteResult(jobId);
        //}

        #endregion

        //2
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteEveryYearAtATime_Test()
        {
            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";
            string jobidsuffix = "Rock500";

            List<int> listselectmonth = new List<int>();
            listselectmonth.Add(1);
            listselectmonth.Add(2);

            List<int> listSelectdayofmonth = new List<int>();
            listSelectdayofmonth.Add(1);
            listSelectdayofmonth.Add(10);
            listSelectdayofmonth.Add(28);

            int taskstarthour24 = 14;
            int taskstartminutes = 6;

            string jobId = ExecuteEveryYearAtATime(
                taskname,
                hindokbn,
                jobidsuffix,
                listselectmonth,
                listSelectdayofmonth,
                taskstarthour24,
                taskstartminutes);

            await Task.Delay(TimeSpan.FromMinutes(8));

            _testResult.OutputExecuteResult(jobId);
        }

        #endregion

        #region private methods

        #region 1

        //1
        //月
        //毎月の週
        //毎週の曜日
        //某个时间点
        //public string ExecuteEveryYearMonthsWeeksDaysAtATime(
        //    string taskname,
        //    string jobidsuffix,
        //    List<int> listSelectMonth,
        //    List<int> listSelectWeek,
        //    List<int> listSelectWeekDay,
        //    int taskstarthour24,
        //    int taskstartminutes)
        //{
        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;// "Task1";

        //    #region cron

        //    //月
        //    jobModel.Schedule.monthseveryyear = new List<int>();
        //    jobModel.Schedule.monthseveryyear = listSelectMonth;

        //    //毎月の週
        //    jobModel.Schedule.maigetusyu = new List<int>();
        //    jobModel.Schedule.maigetusyu = listSelectWeek;

        //    //毎週の曜日
        //    jobModel.Schedule.maisyuyoubi = new List<int>();
        //    jobModel.Schedule.maisyuyoubi = listSelectWeekDay;

        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    #endregion

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;// "Rock053";

        //    string jobId = EveryYearMonthsWeeksDaysAtATime(jobModel);

        //    return jobId;
        //}

        //選択された月、毎月の選択された週
        //public string EveryYearMonthsWeeksDaysAtATime(BtModel jobModel)
        //{
        //    string jobId = "";

        //_timerEveryYearMonthsAtATimeWeeks = new System.Timers.Timer(5 * 60 * 1000);

        //_timerEveryYearMonthsAtATimeWeeks.Elapsed += (s, e) =>
        //{
        //    int nWeekIndex = GetWeekOfMonth(DateTime.Now);

        //    //毎月の週
        //    //1...5
        //    List<int> listWeeksPerMonth = jobModel.Schedule.maigetusyu;

        //    if (listWeeksPerMonth.Contains(nWeekIndex))
        //    {
        //        string months = string.Join(",", jobModel.Schedule.monthseveryyear);

        //        string weekDays = string.Join(",", jobModel.Schedule.maisyuyoubi);

        //        jobId = GetJobId() + jobModel.jobidsuffix;

        //        IBtService job = BtFactory.GetService(jobModel.Module);

        //        var options = new RecurringJobOptions
        //        {
        //            TimeZone = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time"),
        //        };

        //        RecurringJob.AddOrUpdate(
        //            jobId,
        //            () => job.Execute(jobId, null, null),
        //            jobModel.Schedule.startdttm.Minute + " " + jobModel.Schedule.startdttm.Hour + " * " + months + " " + weekDays,
        //            options);
        //    }
        //};
        //_timerEveryYearMonthsAtATimeWeeks.AutoReset = false;
        //_timerEveryYearMonthsAtATimeWeeks.Enabled = true;

        //return jobId;
        //}

        #endregion

        #region 2

        /// <summary>
        /// [毎年選択された月]の[特定の日付]の[特定の時間]に実行
        /// </summary>
        /// <param name="taskname"></param>
        /// <param name="hindokbn"></param>
        /// <param name="jobidsuffix"></param>
        /// <param name="listselectmonth"></param>
        /// <param name="listSelectdayofmonth"></param>
        /// <param name="taskstarthour24"></param>
        /// <param name="taskstartminutes"></param>
        /// <returns></returns>
        public string ExecuteEveryYearAtATime(
            string taskname,
            EnumHinDoKBN hindokbn,
            string jobidsuffix,
            List<int> listselectmonth,
            List<int> listSelectdayofmonth,
            int taskstarthour24,
            int taskstartminutes)
        {
            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = false;

            jobModel.Module = taskname;

            #region cron

            jobModel.Schedule.hindokbn = hindokbn;

            jobModel.Schedule.maitukihi = new List<int>();
            jobModel.Schedule.maitukihi = listselectmonth;

            jobModel.Schedule.maitukituki = new List<int>();
            jobModel.Schedule.maitukituki = listSelectdayofmonth;

            //jobModel.Schedule.startdttm = new DateTime(
            //    DateTime.Now.Year,
            //    DateTime.Now.Month,
            //    DateTime.Now.Day,
            //    taskstarthour24,
            //    taskstartminutes,
            //    0);

            #endregion

            jobModel.TaskID = jobidsuffix;

            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db,jobModel);

            return jobId;
        }

        #endregion

        #endregion
    }
}
