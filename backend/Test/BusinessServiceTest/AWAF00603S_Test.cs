namespace BCC.Affect.Service.AWAF00603S
{
    [TestClass]
    public class AWAF00603S_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            InitRequest req = new()
            {
                userid = "jzy",
                kinoid = "AWSH00101G",
                atenano = "00022222222"
            };
            var res = service.Init(req);
        }
    }
}