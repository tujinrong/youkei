using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00301G
{
    [TestClass]
    public class AWAF00301G_Test
    {
        private readonly Service _service = new();


        [TestMethod]
        public void TestMenu()
        {
            var req = new DaRequestBase
            {
                userid = "1",
            };
            var res = _service.GetMenu(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void InitTest()
        {
            var req = new InitRequest
            {
                userid = "1"
            };
            var res = _service.Init(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void SearchInfoTest()
        {
            var req = new SearchInfoRequest
            {
                userid = "1"
            };
            var res = _service.SearchInfo(req);
            Console.WriteLine(res);
        }

    }
}