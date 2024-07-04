using BCC.Affect.DataAccess;
using NPOI.SS.Formula.Functions;
using NPOI.XSSF.Streaming.Values;
using System;
using System.Data;

namespace BCC.Affect.Service.AWKK00701G
{
    [TestClass]
    public class AWKK00701G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        //public void InitKimpListTest()
        //{
        //    var req = new InitKimpListRequest();
        //    req.gyoumukbn = "1";
        //    var res = _service.InitKimpList(req);
        //}

        //[TestMethod]
        //public void SearchKimpList()
        //{
        //    var req = new SearchKimpListRequest();
        //    req.gyoumukbn = "1";
        //    req.impnm = "";
        //    var res = _service.SearchKimpList(req);
        //}

        //[TestMethod]
        //public void InitSearchKimpDataList()
        //{
        //    var req = new InitKimpListRequest();
        //    req.gyoumukbn = "1";
        //    var res = _service.InitSearchKimpDataList(req);
        //}

        //[TestMethod]
        //public void InitSearchKimpHistoryList()
        //{
        //    var req = new InitKimpListRequest();
        //    req.gyoumukbn = "1";
        //    var res = _service.InitSearchKimpHistoryList(req);
        //}

        //[TestMethod]
        //public void DeleteKimpList()
        //{
        //    var req = new DeleteKimpListRequest();
        //    req.locklist = new List<LockVM>();
        //    req.locklist.Add(new LockVM(27, DateTime.Now));
        //    req.userid = "1";
        //    var res = _service.DeleteKimpList(req);
        //}

        //[TestMethod]
        //public void DeleteEdit()
        //{
        //    var req = new DeleteDetailRequest();
        //    req.impexeid = 42;
        //    req.rownoList = new List<int> { 1, 2 };
        //    req.userid = "1";
        //    var res = _service.DeleteEdit(req);
        //}

        //[TestMethod]
        //public void GetTargetItemValue()
        //{

        //    var req = new GetTargetItemValueRequest();
        //    req.impid = 15;
        //    req.pageitemseq = 1;
        //    req.val = "800000000193887";
        //    var res = _service.GetTargetItemValue(req);
        //}

        [TestMethod]
        public void InitDetail()
        {
            var values = ",".Split(',');
            values = values;
            //var req = new InitDetailRequest();
            //req.impid = 15;
            //req.impexeid = 56;
            //req.editkbn = Enum編集区分.変更;
            //var res = _service.InitDetail(req);

            //DetailRequest reqWork = new DetailRequest();
            //reqWork.impid = 15;
            //reqWork.impexeid = 56;
            //reqWork.editkbn = Enum編集区分.変更;
            //reqWork.detailList = res.detailList;
            //reqWork.upddttm = DateTime.Now;
            //reqWork.userid = "1";
            //var resWork = _service.CheckDetail(reqWork);
        }

        //[TestMethod]
        //public void Save()
        //{
        //    var req = new SaveRequest();
        //    req.impexeid = 57;
        //    req.impid = 15;
        //    req.userid = "1";
        //    var res = _service.Save(req);
        //}
    }
}