using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00303D
{
    [TestClass]
    public class AWBH00303D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //乳幼児情報一覧画面検索処理
        public void SearchListTest()
        {
            var req = new SearchListRequest
            {
                userid = "1",                                   //ユーザーID
                regsisyo = "1",
                token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

                atenano = "800000000000009",                    //宛名番号
            };

            var res = _service.SearchJyoseiList(req);

            var str = res.ToString();
        }
    }
}