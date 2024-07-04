namespace BCC.Affect.Service.AWAF00703D
{
    [TestClass]
    public class DetailedSearchTest
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitTest()
        {
            var req = new InitRequest();
            req.userid = "jzy";
            req.kinoid = "AWSH00101G";
            var res = _service.Init(req);
        }
    }
}