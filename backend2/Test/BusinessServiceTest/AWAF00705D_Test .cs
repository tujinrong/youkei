
namespace BCC.Affect.Service.AWAF00705D
{
    [TestClass]
    public class AWAF00705D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //検索画面一覧テスト用
        public void SearchTest()
        {
            var req = new SearchRequest
            {
                //name = "三",                    //氏名
                ////name = "",                    //氏名（未入力）
                ////kname = "い",                   //カナ氏名（ひらがなで入力）
                //kname = "",                     //カナ氏名（未入力）

                ////bymd = "2000-01-01",          //生年月日
                //bymd = "",                      //生年月日（未入力）
                ////sex = "1",                    //性別
                //sex = "",                       //性別（未入力）
                //juminkbn = "",                  //住民区分
                //hokenkbn = "",                  //保険区分
            };

            var res = _service.Search(req);

            var str = res.ToString();
        }


    }
}