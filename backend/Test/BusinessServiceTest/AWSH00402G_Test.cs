using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWSH00402G
{
    [TestClass]
    public class AWSH00402G_Test
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
            var req = new InitPersonListRequest
            {
                nendo = 2022,
                nitteino = 1
            };
            var res = _service.InitPersonList(req);
            Console.WriteLine(res);
        }
        [TestMethod]
        public void InfoTest2()
        {
            var req = new SaveRequest
            {
                nendo = 2022,
                nitteino = 1,
                atenano = "000000000900029",
                editkbn = Enum編集区分.新規,
                biko = "123",
                userid="1",
                kekkalist = new List<DetailRowSaveVM>() { new DetailRowSaveVM() { jigyocd = "090",
                                                                                    kensahohocdnm= $"1{DaConst.SELECTOR_DELIMITER}nm",
                                                                                    nitteino=1,taikiflg=false} }
            };
            var res = _service.Save(req);
            Console.WriteLine(res);
        }
        //[TestMethod]
        //public void InfoTest()
        //{
        //    var req = new InitDetailRequest
        //    {
        //        nendo = 2022,
        //        nitteino = 1,
        //        editkbn = Enum編集区分.変更
        //    };
        //    var res = _service.InitDetail(req);
        //    Console.WriteLine(res);
        //}

    }
}