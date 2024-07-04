using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00803G
{
    [TestClass]
    public class AWAF00803G_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitTest()
        {
            for (int i = 0; i < 10; i++)
            {
                DaRequestBase req = new()
                {
                    userid = "1",
                    regsisyo = "3"
                };
                if (i == 5)
                {
                    Console.WriteLine(i);
                }
                //var res = _service.InitListTest(req);
                //Console.WriteLine(res);
            }
        }

        [TestMethod]
        public void SearchTest()
        {
            for (int i = 0; i < 10; i++)
            {
                SearchListRequest req = new()
                {
                    pagenum = 1,
                    pagesize = 25,
                    orderby = -4,
                    userid = "1",
                    regsisyo = "3"
                };
                if (i==5)
                {
                    Console.WriteLine(i);
                }
                //var res = _service.SearchListTest(req);
                //Console.WriteLine(res.totalpagecount);
            }
        }


    }
}