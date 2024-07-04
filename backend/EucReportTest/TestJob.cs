/*
using AIplus.AiReport.ReportDef;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using AIplus.FreeQuery;
using BCC.Affect.DataAccess;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BCC.Affect.DataAccess.DaJobService;

namespace EucReportTest
{
    [TestClass]
    public class TestJob
    {
        [TestMethod]
        public void Test1()
        {
            DaJobService.Start();
            try
            {
                using (var db = new DaDbContext())
                {
                    db.Session.UserID = "test";
                    DaRequestBase req = new()
                    {
                        userid = "jzy"
                    };
                    BCC.Affect.Service.AWAF00202S.Service service = new();
                    var res = service.Search(req);
                    DaJobService.Schedule(db, service, "Search", req, DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DaJobService.End();
            }
        }
            
            
        [TestMethod]
        public void TestAsync()
        {
            DaJobService.Start();

            Thread.Sleep(1000*100);
            DaJobService.End();
        }
        [TestMethod]
        public void TestSchdule()
        {
            using (var db = new DaDbContext())
            {
                db.Session.UserID = "test";
                DaRequestBase req = new()
                {
                    userid = "jzy"
                };
                BCC.Affect.Service.AWAF00202S.Service service = new();
                var res = service.Search(req);
                DaJobService.Schedule(db, service, "Search", req, DateTime.Now);
            }

        }
        [TestMethod]
        public void TestSync()
        {
            try
            {
                using (var db = new DaDbContext())
                {
                    var filter = $"{nameof(tt_afjobDto.teijitm)}<='{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'";
                    var joblist = db.tt_afjob.SELECT.WHERE.ByFilter(filter).GetDtoList();
                    foreach (var dto in joblist)
                    {
                        db.tt_afjob.UPDATE.WHERE.ByKey(dto.jobseq).Execute(dto);
                        RunJob(db, dto);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DaJobService.End();
            }
        }
        public static void RunJob(DaDbContext db, tt_afjobDto dto)
        {
            var res = DaJobService.RunMethod(dto.assemby, dto.nmspace, dto.kinoid, dto.method, dto.pram);
            EnumJobStatus istatus = res.returncode == EnumServiceResult.OK ? EnumJobStatus.Success : EnumJobStatus.Failure;
            //dto.status = istatus;
            //dto.msg = res.message;
            db.tt_afjob.UPDATE.WHERE.ByKey(dto.jobseq).Execute(dto);
        }
    }
}
*/
