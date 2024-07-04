using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWSH00401G
{
    [TestClass]
    public class AWSH00401G_Test
    {
        private readonly Service _service = new();


        [TestMethod]
        public void SearchInfoTest()
        {
            var req = new SearchListRequest
            {
                nendo = 2022
            };
            var res = _service.SearchList(req);
            Console.WriteLine(res);
        }
        [TestMethod]
        public void InfoTest()
        {
            var req = new InitDetailRequest
            {
                nendo = 2022,
                nitteino = 1,
                editkbn = Enum編集区分.変更
            };
            var res = _service.InitDetail(req);
            Console.WriteLine(res);
        }

    }
}