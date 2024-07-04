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
    public class UnitTestTaskEveryDay
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


        [Test]
        public void test2()
        {
            var svcName = "ABSH00101G";
            BtJobService.Execute(svcName, 0);

        }
        //1
        //毎日実行(祝日を含む,営業日を含む);
        //毎日の[特定の時刻]から始まり、[特定の時刻]まで;
        //毎日の[この時間帯]内、[一定の間隔で]繰り返し実行する;
        [Test]
        //[RunOnSpecificServer("Rock")]
        public async Task ExecuteIntervalMinutesEveryDay_Test()
        {
            #region パラメータを取得する

            //cron式のタイプ
            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            //実行予定のタスクのクラス名
            string taskname = "Task1";

            //ジョブ名のサフィックス
            string jobidsuffix = "Rock406";

            //毎日実行(祝日を含む,営業日を含む);
            bool syukushinaiflag = false;

            //間隔時間
            EnumIntervalType intervaltype = EnumIntervalType.Minutes10;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = false;

            jobModel.Module = taskname;

            jobModel.TaskID = jobidsuffix;

            //jobModel.Schedule.syukustugiflag = syukushinaiflag;

            jobModel.Schedule.hindokbn = hindokbn;

            //有効開始時刻
            jobModel.Schedule.beginhour = 9;
            jobModel.Schedule.beginminute = 0;

            //有効終了時刻
            jobModel.Schedule.endhour = 21;
            jobModel.Schedule.endminute = 0;

            //間隔実行の時間(分)
            jobModel.Schedule.kurikaesikankbn = intervaltype;

            #endregion
            var db = new DaDbContext();
            string jobId = BtJobService.AddJob(db, jobModel);

            //このテストメソッドを遅延させる
            await Task.Delay(TimeSpan.FromMinutes(10));

            //このジョブの実行結果を判断する
            _testResult.OutputExecuteResult(jobId);
        }

        //2
        //毎日実行(祝日を含む,営業日を含む);
        //毎日特定の時間に実行する
        [Test]
        [RunOnSpecificServer("Rock")]
        public async Task ExecuteAtATimeEveryDay_Test()
        {
            #region パラメータを取得する

            EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDay;

            string taskname = "Task1";

            string jobidsuffix = "Rock340";

            //毎日実行(祝日を含む,営業日を含む);
            bool syukushinaiflag = false;

            int taskstarthour24 = 12;
            int taskstartminutes = 23;

            #endregion

            #region BtModelにパラメータを設定する

            BtModel jobModel = new BtModel();
            jobModel.Schedule = new BtScheduleModel();

            //jobModel.Schedule.syukustugiflag = false;

            jobModel.Module = taskname;

            jobModel.TaskID = jobidsuffix;

            //jobModel.Schedule.syukustugiflag = syukushinaiflag;

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

            //このテストメソッドを遅延させる
            await Task.Delay(TimeSpan.FromMinutes(5));

            //このジョブの実行結果を判断する
            _testResult.OutputExecuteResult(jobId);
        }

        //3
        //毎日(祝日を除く)実行する
        //実行中の[毎日]で、一定の間隔で繰り返し実行する;
        //[Test]
        //public async Task ExecuteIntervalMinutesEveryDayNotIncludeHoliday_Test()
        //{
        //    #region パラメータを取得する

        //    string taskname = "Task1";
        //    string jobidsuffix = "Rock200";
        //    HinDoKBN hindokbn = HinDoKBN.EveryDayAtATime;
        //    bool syukushinaiflag = true;

        //    #endregion

        //    #region BtModelにパラメータを設定する

        //    BtModel jobModel = new BtModel();
        //    jobModel.Schedule = new BtScheduleModel();

        //    jobModel.Schedule.syukustugiflag = false;

        //    //要执行 的 类的名称
        //    jobModel.Module = taskname;

        //    //任务id后缀
        //    jobModel.jobidsuffix = jobidsuffix;

        //    jobModel.Schedule.hindokbn = hindokbn;

        //    int taskstarthour24 = 0;
        //    int taskstartminutes = 0;
        //    jobModel.Schedule.startdttm = new DateTime(
        //        DateTime.Now.Year,
        //        DateTime.Now.Month,
        //        DateTime.Now.Day,
        //        taskstarthour24,
        //        taskstartminutes,
        //        0);

        //    //祝日実行しないフラグ(execute in work day)
        //    jobModel.Schedule.syukushinaiflag = syukushinaiflag;

        //    #endregion

        //    //休日リスト
        //    //List<DateTime>? listHoliday = new List<DateTime>();

        //    string jobId = BtJobService.AddJob(jobModel);

        //    //このテストメソッドを遅延させる
        //    await Task.Delay(TimeSpan.FromMinutes(5));

        //    //このジョブの実行結果を判断する
        //    _testResult.OutputExecuteResult(jobId);
        //}

        #endregion
    }
}