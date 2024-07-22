using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00303D
{
    [TestClass]
    public class AWAF00303D_Test
    {
        private readonly Service service = new();

        [TestMethod]
        public void SaveTest()
        {
            var kinoids = new List<string>
            {
                "01010200",
                "01020100",
                "01020300",
                "06030000",
                "06040000",
                "01050600"
            };
            var req = new SaveRequest()
            {
                userid = "jzy",
                kinoids = kinoids
            };
            var res = service.Save(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void UpdTest()
        {
            var req = new UpdateRequest()
            {
                userid = "jzy",
                kinoid = "01020100",
                updkbn = Enum更新区分.追加
                //updkbn = Enumお気に入り更新区分.削除
            };
            var res = service.Update(req);
            Console.WriteLine(res);
        }

        [TestMethod]
        public void InitTest()
        {
            var req = new InitRequest()
            {
                userid = "jzy",
                kinoid = "01020100",
            };
            var res = service.Init(req);
            Console.WriteLine(res);
        }


        [TestMethod]
        public void SearchTest()
        {
            var req = new DaRequestBase()
            {
                userid = "jzy",
            };
            var res = service.Search(req);
            Console.WriteLine(res);
        }
    }
}