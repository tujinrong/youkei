namespace BCC.Affect.Service.AWKK00704D
{
    [TestClass]
    public class AWKK00704D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitKimpListTest()
        {
            var req = new InitListRequest();
            req.impexeid = 1;
            var res = _service.InitList(req);
        }

        //[TestMethod]
        //public void Download()
        //{
        //    var req = new DownloadRequest();
        //    var res = _service.Download(req);
        //}


    }
}