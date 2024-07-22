using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00901G
{
    [TestClass]
    public class AWAF00901G_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        public void InitTest()
        {
            var req = new DaRequestBase();
            var res = _service.InitList(req);
        }

        //[TestMethod]
        //public void UserSearchTest()
        //{
        //    var req = new UserSearchRequest
        //    {
        //        user = "1",
        //        syozoku = "1",
        //        orderby = 3,
        //        pagenum = 1,
        //        pagesize = 999
        //    };
        //    var res = _service.UserSearch(req);
        //}

        //[TestMethod]
        //public void SyozokuSearchTest()
        //{
        //    var req = new SearchRequest
        //    {
        //        // syozoku = "999",
        //        orderby = 2,
        //        pagenum = 1,
        //        pagesize = 999
        //    };
        //    var res = _service.SyozokuSearch(req);
        //}
        
        [TestMethod]
        public void DetailTest()
        {
            var req = new InitDetailRequest
            {
                roleid = "1",
                rolekbn = Enumロール区分.ユーザー
            };
            var res = _service.InitDetail(req);
        }
    }
}