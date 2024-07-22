
namespace BCC.Affect.Service.AWAF00706D
{
    [TestClass]
    public class AWAF00706D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //検索画面一覧テスト用
        public void SearchTest()
        {
            var req = new SearchRequest
            {
                userid = "11",                                          //ユーザーID
                //kname = "イ",                                         //カナ氏名（カタカナで入力）
                //kname = "い",                                           //カナ氏名（ひらがなで入力）
                //kname = "",                                           //カナ氏名（未入力）
                //name = "大",                                            //氏名
                //name = "",                                            //氏名（未入力）
                //adrs_yubin = "1040051",                               //世帯郵便番号
                adrs_yubin = "",                                        //世帯郵便番号（未入力）
                //adrs = "東京都",                                      //世帯住所
                //adrs = "区丸",                                          //世帯住所（未入力）

                orderby = -2,                                           //ソート順
            };

            var res = _service.Search(req);

            var str = res.ToString();
        }


    }
}