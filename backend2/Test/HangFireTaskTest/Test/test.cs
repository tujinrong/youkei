using AIplus.AIF.DBLib;
using BCC.Affect.BatchService;
using BCC.Affect.DataAccess;
using Hangfire;
using Hangfire.Storage;
using System.Reflection;

namespace HangFireTaskTest.Test
{
    public class test
    {

        MyApplicationFactory _factory;
        [SetUp]
        public void Setup()
        {
            _factory = new MyApplicationFactory();
            _factory.CreateClient();
        }

        [Test]
        public void test1()
        {
            var obj = new BCC.Affect.BatchService.ABSH00102G.Service();
            obj.Execute("100000");
        }
            [Test]
        public void testJob()
        {
            using var db = new DaDbContext();
            var taskID = "300001"; // everyWeek
            DaGlobal.InitDbLib();
            db.Session.UserID = "System";

            var sdto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(taskID!).GetDto();
            if (sdto == null)
            {
                // TODO 
                return;
            }
            BtModel btModel = BtJobService.GetBtModel(db, sdto);
            BtJobService.AddJob(db, btModel);
            var jobList = new List<JobNextExecutionInfo>();
            using (var connection = JobStorage.Current.GetConnection())
            {
                var serverJobs = connection.GetRecurringJobs();
                foreach (var job in serverJobs)
                {
                    jobList.Add(new JobNextExecutionInfo
                    {
                        JobId = job.Id,
                        NextExecutionTime = job.NextExecution
                    });
                }
            }
        }

        [Test]
        public void test2()
        {
            var svcName = "ABSH00102G";
            BtJobService.Execute(svcName, 0, "299999", null,null);

        }


        [Test]
        public void test3()
        {
            var svcName = "ABSH00102G";
            BtModel jobModel = new BtModel();

            //cron式のタイプ
            //EnumHinDoKBN hindokbn = EnumHinDoKBN.EveryDayRepeatByFixPeriod;
            //間隔時間
            //IntervalType intervaltype = IntervalType.Minutes1;

            BtScheduleModel jobSchedule = new BtScheduleModel();
            jobSchedule.syukustopflg = false;                                          
            jobSchedule.hindokbn = EnumHinDoKBN.OneTime;                         

            jobModel.Schedule = jobSchedule;
            jobModel.Module = svcName;

            jobModel.TaskID = "240305";

            //有効開始時刻
            jobModel.Schedule.beginhour = 9;
            jobModel.Schedule.beginminute = 0;

            //有効終了時刻
            jobModel.Schedule.endhour = 21;
            jobModel.Schedule.endminute = 0;


            //jobModel.Schedule.hindokbn = hindokbn;
            //間隔実行の時間(分)
            jobModel.Schedule.kurikaesikankbn =   EnumIntervalType.Minutes5;

            var jobSeb = int.Parse(jobModel.TaskID);

            var db = new DaDbContext();
            BtJobService.AddJob(db, jobModel);
        }



        [Test]
        public void test4()
        {
            using var db = new DaDbContext();
            //var taskID = "300000"; // everyDay
            //var taskID = "300001"; // everyWeek
            var taskID = "300000"; // everyMonth
            //var taskID = "300003"; // everyMonth
            //var taskID = "300004"; // oneTime
            DaGlobal.InitDbLib();
            db.Session.UserID = "System";

            var sdto = db.tm_aftaskschedule.SELECT.WHERE.ByKey(taskID!).GetDto();
            if (sdto == null)
            {

                // TODO 
                return;
            }
            BtModel btModel = BtJobService.GetBtModel(db, sdto);
            BtJobService.AddJob(db, btModel);
        }

        [Test]
        public void test10()
        {
            var svcName = "ABSH00101G";
            var serviceFullName = $"BCC.Affect.BatchService.{svcName}.Service";

            var t = new BCC.Affect.BatchService.ABSH00101G.Service().GetType().Assembly.GetType(serviceFullName);
            var i = (IBtService)Activator.CreateInstance(t!)!;
            var x = new BCC.Affect.BatchService.ABSH00101G.Service();
            if (i == x)
            {
                var m = "";
            }
            IBtService job2 = BtFactory.GetService(svcName);
            IBtService job = GetService(svcName);
            if (job == x)
            {
                var m = "";
            }
        }
        private static IBtService GetService(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetTypes().FirstOrDefault(t => t.FullName == name && typeof(IBtService).IsAssignableFrom(t));

            if (type != null)
            {
                return (IBtService)Activator.CreateInstance(type);
            }
            else
            {
                throw new NotImplementedException();
            }
            //var serviceFullName = $"BCC.Affect.BatchService.{svcName}.Service";

            //var t = new ABSH00101G.Service().GetType().Assembly.GetType(serviceFullName);
            //return (IBtService)Activator.CreateInstance(t!)!;
            //switch (svcName)
            //{
            //    case nameof(BCC.Affect.BatchService.ABSH00101G.Service): return new BCC.Affect.BatchService.ABSH00101G.Service();
            //    case nameof(Task1): return new Task1();
            //    case nameof(Task2): return new Task2();

            //    default: throw new NotImplementedException();
            //}

        }

    }
}