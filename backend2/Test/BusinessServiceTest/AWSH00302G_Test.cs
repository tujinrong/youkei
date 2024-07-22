using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;
using NPOI.SS.Formula.Functions;
using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;

namespace BCC.Affect.Service.AWSH00302G
{
    [TestClass]
    public class AWSH00302G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////①検索画面一覧テスト用
        //public void SearchListTest()
        //{

        //    var searchVm1 = new SearchVM();
        //    searchVm1.jyokbn = Enum詳細検索条件区分.共通;
        //    searchVm1.jyoseq = 1;
        //    searchVm1.cdlist = new List<string> { "1", "10" };

        //    var searchVm2 = new SearchVM();
        //    searchVm2.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm2.jyoseq = 16;
        //    var itemVm2 = new AWAF00703D.ItemVM();
        //    itemVm2.value1 = "011000";
        //    searchVm2.itemvm = itemVm2;//ok

        //    var searchVm3 = new SearchVM();
        //    searchVm3.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm3.jyoseq = 7;
        //    var itemVm3 = new AWAF00703D.ItemVM();
        //    itemVm3.value1 = "2022-01-01";
        //    itemVm3.value2 = "2022-08-24";
        //    searchVm3.itemvm = itemVm3;//ok

        //    var syosailist = new List<SearchVM>();
        //    syosailist.Add(searchVm1);
        //    syosailist.Add(searchVm2);
        //    syosailist.Add(searchVm3);

        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        orderby = 0,
        //        kinoid = "AWSH00302G",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        nendo = 2022,                                           //年度
        //        atenano = "800000000000009",                            //宛名番号
        //        //atenano = "",                                           //宛名番号
        //        //personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",              //個人番号
        //        //name = "村",                                            //氏名
        //        //kname = "タ",                                           //カナ氏名（カタカナで入力）
        //        //kname = "た",                                           //カナ氏名（ひらがなで入力）
        //        //kname = "",                                           //カナ氏名（未入力）
        //        //bymd = "1995-06-02",                                    //生年月日
        //        //bymd = "",                                              //生年月日
        //        //syosailist = { },                                      //詳細条件(検索)  -- Pending
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}


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

        //[TestMethod]
        ////検索処理(詳細画面)テスト用
        //public void SearchDetailTest()
        //{
        //    var req = new SearchDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        nendo = 2022,                                   //年度
        //        atenano = "800000000000009",                    //宛名番号
        //    };

        //    var kekkalist = new List<Row3VM>();
        //    var vm1 = new Row3VM
        //    {
        //        jigyocd = "00007",
        //        kensahohocd = "1",
        //        kijunymd = "2022-01-01",
        //    };

        //    var vm2 = new Row3VM
        //    {
        //        jigyocd = "00007",
        //        kensahohocd = "2",
        //        kijunymd = "2022-02-02",
        //    };
        //    kekkalist.Add(vm1);
        //    kekkalist.Add(vm2);

        //    req.kekkalist = kekkalist;

        //    var res = _service.SearchDetail(req);

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

                atenano = "800000000000009",                //宛名番号
                genmenkbn_tokuteicdnm = "1 : 有料",         //減免区分（特定健診）
                genmenkbn_gancdnm = "1 : A",                //減免区分（がん検診）
            };

            var res = _service.Save(req);

            var str = res.ToString();
        }
    }
}