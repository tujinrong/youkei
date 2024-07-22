namespace BCC.Affect.Service.AWAF00702D
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
                kikannm = "1",
                kanakikannm = "1",
                orderby = -2
            };
            var res = service.Search(req);
        }
    }
}