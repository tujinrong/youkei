
using BCC.Affect.DataAccess;

namespace BCC.Affect.Service.AWAF00804G
{
    [TestClass]
    public class AWAF00804G_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //検索画面一覧テスト用
        public void SearchTest()
        {
            var req = new DaRequestBase
            {
                userid = "11",                                          //ユーザーID
            };

            var res = _service.Search(req);

            var str = res.ToString();
        }
    }
}