namespace BCC.Affect.Service.AWAF00701D
{
    [TestClass]
    public class Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "jzy",
                kinoid = "AWSH00101G",
                pagesize = 2
            };
            var res = service.Search(req);
        }

        [TestMethod]
        public void SaveTest()
        {
            SaveRequest req = new()
            {
                userid = "jzy",
                atenano = "00000057890",
                kinoid = "test000001"
            };
            var res = service.Save(req);
        }
    }
}