namespace BCC.Affect.Service.AWKK00703D
{
    [TestClass]
    public class AWKK00703D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitKimpListTest()
        {
            var req = new InitListRequest();
            req.impexeid = 1;
            req.rowno = 1;
            var res = _service.InitList(req);
        }

        
    }
}