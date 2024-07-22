using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWKK00607D
{
    [TestClass]
    public class AWKK00607D_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        //public void InitDetail()
        //{
        //    var req = new DaRequestBase();
        //    var res = _service.InitDetail(req);
        //}

        //[TestMethod]
        //public void ReSearch()
        //{
        //    var req = new CommonRequest
        //    {
        //        procseq = 6,
        //    };
        //    var res = _service.ReSearch(req);
        //}

        [TestMethod]
        public void SaveTest()
        {
            var req = new SaveRequest();
            req.editkbn = Enum編集区分.新規;
            req.userid = "1";

            req.procedureVM = new ProcedureVM();
            //req.procedureVM.procseq = 6;
            req.procedureVM.procnm = "imp_胃がん結果_Check";
            req.procedureVM.prockbn = "1";
            req.procedureVM.procsql = "BEGIN \r\nRETURN '拒1'; \r\nEND ";

            var res = _service.Save(req);
        }

        //[TestMethod]
        //public void DeleteTest()
        //{
        //    var req = new CommonRequest
        //    {
        //        procseq = 8,  //取込ID
        //        userid = "1"
        //    };

        //    var res = _service.Delete(req);
        //}



    }
}