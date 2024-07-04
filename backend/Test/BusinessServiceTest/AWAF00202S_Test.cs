using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00202S
{
    [TestClass]
    public class AWAF00202S_Test
    {

        private readonly Service service = new();

        [TestMethod]
        public void InitTest()
        {
            DaRequestBase req = new()
            {
                userid = "jzy"
            };
            var res = service.Search(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void SaveTest()
        {
            SaveRequest req = new()
            {
                userid = "jzy",
                kinoid = "AWSH00101G"
            };
            var res = service.Save(req);
            Console.WriteLine(res);
        }
    }
}