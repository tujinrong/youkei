using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWKK00501G
{
    [TestClass]
    public class AWKK00501G_Test
    {
        private readonly Service service = new();

        [TestMethod]
        public void InitListTest()
        {
            var req = new DaRequestBase();
            var res = service.InitList(req);
        }

        [TestMethod]
        public void SearchListTest()
        {
            var req = new SearchListRequest
            {
                jissiymdf = "",
                jissiymdt = "",
                kaijo = "",
                jigyo = "",
                staff = "0000000001",
                orderby = -7
            };
            var res = service.SearchList(req);
        }
    }
}