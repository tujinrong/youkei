using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00802G
{
    [TestClass]
    public class AWAF00802G_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void SearchMainCdTest()
        {
            AWAF00801G.InitMainCodeRequest req = new()
            {
                userid = "1"
            };
            var res = _service.InitMainCode(req);
        }

        [TestMethod]
        public void SearchSubCdTest()
        {
            InitSubCodeRequest req = new()
            {
                userid = "1",
                ctrlmaincd = "1000"
            };
            var res = _service.InitSubCode(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "1",
                ctrlmaincd = "1000",
                ctrlsubcd = "1"
            };
            var res = _service.Search(req);
        }
    }
}