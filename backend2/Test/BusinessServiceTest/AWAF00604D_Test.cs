namespace BCC.Affect.Service.AWAF00604D
{
    [TestClass]
    public class AWAF00604D_Test
    {

        private readonly Service _service = new();

        [TestMethod]
        public void InitTest()
        {
            //InitRequest req = new()
            //{
            //    userid = "1"
            //};
            //var res = _service.Init(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            SearchRequest req = new()
            {
                userid = "1",
                atenano = "800000000000003"
            };
            var res = _service.Search(req);
        }
    }
}