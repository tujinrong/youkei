using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using NPOI.SS.Formula.Functions;
using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;

namespace BCC.Affect.Service.AWSH00303D
{
    [TestClass]
    public class AWSH00303D_Test
    {
        private readonly Service _service = new();


        //[TestMethod]
        ////初期化処理(詳細画面)テスト用
        //public void InitTest()
        //{
        //    var req = new InitRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        nendo = 2022,                                   //年度
        //        atenano = "800000000000009",                    //宛名番号
        //    };

        //    var res = _service.Init(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //保存処理テスト用
        public void SaveTest()
        {
            var req = new SaveRequest
            {
                userid = "1",                               //ユーザーID
                regsisyo = "1",
                kinoid = "AWSH00302G",
                token = "Vwdu6wgvN/pJZCJV9S0sCA==",         //alertviewflg=false 4084

                nendo = 2022,                               //年度
                atenano = "800000000000009",                //宛名番号
            };

            var kekkalist = new List<SaveRowVM>();
            var vm = new SaveRowVM()
            {
                jigyocd = "01",                             //成人健（検）診事業コード
                kyohiriyucdnm = "2 : 2",                    //受診拒否理由(コード：名称)
            };

            var vm1 = new SaveRowVM()
            {
                jigyocd = "02",                             //成人健（検）診事業コード
                kyohiriyucdnm = "3 : 3",                    //受診拒否理由(コード：名称)
            };

            kekkalist.Add(vm);
            kekkalist.Add(vm1);

            req.kekkalist = kekkalist;
            var res = _service.Save(req);

            var str = res.ToString();
        }
    }
}