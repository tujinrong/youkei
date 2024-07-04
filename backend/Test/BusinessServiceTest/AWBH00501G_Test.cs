using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using Newtonsoft.Json;
using System.Collections.Generic;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00501G
{
    [TestClass]
    public class AWBH00501G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////初期化処理テスト用
        //public void InitListTest()
        //{
        //    var req = new DaRequestBase();

        //    var res = _service.InitList(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////検索画面一覧テスト用
        //public void SearchListTest()
        //{
        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                     //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 500,
        //        pagenum = 1,
        //        orderby = 0,

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",            //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //        buicd = "1 : 身長",                               //部位コード
        //        sex = "1 : 男",                                   //性別
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //保存処理テスト用
        public void SaveTest()
        {

            var req = new SaveRequest
            {
                userid = "1",                                     //ユーザーID
                regsisyo = "1",
            };

            var jsonstr = @"[{
                    'buicd': '1',
                    'sex': '1',
                    'month': 1,
                    'date': 1,
                    'pasentairustd': 11,
                    'pasentairu3p': 12,
                    'pasentairu10p': 13,
                    'pasentairu25p': 14,
                    'pasentairu50p': 15,
                    'pasentairu75p': 16,
                    'pasentairu90p': 17,
                    'pasentairu97p': 18,
                    'prockbn': 1
                }, {
                    'buicd': '1',
                    'sex': '1',
                    'month': 1,
                    'date': 5,
                    'pasentairustd': 21,
                    'pasentairu3p': 32,
                    'pasentairu10p': 23,
                    'pasentairu25p': 24,
                    'pasentairu50p': 25,
                    'pasentairu75p': 26,
                    'pasentairu90p': 82,
                    'pasentairu97p': 28,
                    'prockbn': 3
                }, {
                    'buicd': '1',
                    'sex': '1',
                    'month': 1,
                    'date': 10,
                    'pasentairustd': 31,
                    'pasentairu3p':  32,
                    'pasentairu10p': 33,
                    'pasentairu25p': 34,
                    'pasentairu50p': 35,
                    'pasentairu75p': 36,
                    'pasentairu90p': 37,
                    'pasentairu97p': 38,
                    'prockbn': 2
                }, {
                    'buicd': '1',
                    'sex': '1',
                    'month': 1,
                    'date': 15,
                    'pasentairustd': 41,
                    'pasentairu3p':  42,
                    'pasentairu10p': 43,
                    'pasentairu25p': 44,
                    'pasentairu50p': 45,
                    'pasentairu75p': 46,
                    'pasentairu90p': 47,
                    'pasentairu97p': 48,
                    'prockbn': 1
                }, {
                    'buicd': '1',
                    'sex': '1',
                    'month': 1,
                    'date': 25,
                    'pasentairustd': 61,
                    'pasentairu3p':  62,
                    'pasentairu10p': 63,
                    'pasentairu25p': 64,
                    'pasentairu50p': 65,
                    'pasentairu75p': 66,
                    'pasentairu90p': 67,
                    'pasentairu97p': 68,
                    'prockbn': 2
                }, {
                    'buicd': '1',
                    'sex': '1',
                    'month': 2,
                    'date': 5,
                    'pasentairustd': 71,
                    'pasentairu3p':  72,
                    'pasentairu10p': 73,
                    'pasentairu25p': 74,
                    'pasentairu50p': 75,
                    'pasentairu75p': 76,
                    'pasentairu90p': 77,
                    'pasentairu97p': 78,
                    'prockbn': 3
                }]";

            req.kekkalist = JsonConvert.DeserializeObject<List<PasentairuListVM>>(jsonstr)!;

            var res = _service.Save(req);

            var str = res.ToString();
        }
    }
}