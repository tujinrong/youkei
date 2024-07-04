using BCC.Affect.DataAccess;
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWKK01301G
{
    [TestClass]
    public class AWKK01301G_Test
    {
        private readonly Service _service = new();
       
        [TestMethod]
        public void InitTest()
        {
            DaRequestBase req = new()
            {
                kinoid = "AWKK01301G"
            };
            var res = _service.InitList(req);
        }

        [TestMethod]
        public void SearchTest()
        {
            SearchListRequest req = new()
            {
                kinoid = "AWKK01301G",
                nendo = 2024,
                userid = "1",
                pagenum = 1,
                pagesize = 5,
                pagenum2 = 1,
                pagesize2 = 5
            };
            var res = _service.SearchList(req);
        }

        [TestMethod]
        public void InitDetailTest()
        {
            //年度管理する
            InitDetailRequest req = new()
            {
                kinoid = "AWKK01301G",
                tyusyututaisyocd = "1999",
                nendo = 2024,
                tyusyutuseq = 1,                              //参照モードの場合
                //tyusyutunaiyo = "全体抽出の内容",               //新規モードの場合
                zentaikobetukbn = 名称マスタ.システム.全体個別区分._1,
                userid = "1"
            };

            var res = _service.InitDetail(req);

            //年度管理する
            InitDetailRequest req2 = new()
            {
                kinoid = "AWKK01301G",
                tyusyututaisyocd = "1999",
                nendo = 2024,
                atenano = "000000000900017",
                zentaikobetukbn = 名称マスタ.システム.全体個別区分._2,
                userid = "1"
            };

            var res2 = _service.InitDetail(req2);

            //年度管理しない
            InitDetailRequest req3 = new()
            {
                kinoid = "AWYS99999G",
                tyusyututaisyocd = "1998",
                //tyusyutuseq = 1,                          //参照モードの場合
                tyusyutunaiyo = "全体抽出内容",             //新規モードの場合
                zentaikobetukbn = 名称マスタ.システム.全体個別区分._1,
                userid = "1"
            };

            var res3 = _service.InitDetail(req3);

            //年度管理しない
            InitDetailRequest req4 = new()
            {
                kinoid = "AWYS99999G",
                tyusyututaisyocd = "1998",
                atenano = "800000000000021",
                zentaikobetukbn = 名称マスタ.システム.全体個別区分._2,
                userid = "1"
            };

            var res4 = _service.InitDetail(req4);
        }

        [TestMethod]
        public void ExtractTest()
        {
            ////全体抽出の場合
            //ExtractRequest req = new()
            //{
            //    tyusyututaisyocd = "1999",
            //    kinoid = "AWKK01301G",
            //    nendo = 2024,
            //    tyusyutunaiyo = "令和6年に生まれた人",
            //    continueflg = false,
            //    regsisyo = "1",
            //    userid = "1",
            //    parameters = new List<ParameterVM> {
            //        new ParameterVM { itemcd = "200400801001", value = "VH001" }
            //    }
            //};
            //var res = _service.Extract(req);

            ////個別抽出、ストアド内チェックがエラーになり、個別抽出で継続希望フラグ＝False
            //ExtractRequest req2 = new()
            //{
            //    tyusyututaisyocd = "1997",
            //    kinoid = "AWKK01301G",
            //    nendo = 2024,
            //    atenano = "800000000000021",
            //    tyusyutunaiyo = "個別抽出",
            //    continueflg = false,
            //    regsisyo = "1",
            //    userid = "1",
            //    parameters = new List<ParameterVM> {
            //        new ParameterVM { itemcd = "200400801001", value = "VH001" }
            //    }
            //};
            //var res2 = _service.Extract(req2);

            ////ストアド内チェックがエラーになり、個別抽出で継続希望フラグ＝True
            //ExtractRequest req3 = new()
            //{
            //    tyusyututaisyocd = "1997",
            //    kinoid = "AWKK01301G",
            //    nendo = 2024,
            //    atenano = "800000000000021",
            //    tyusyutunaiyo = "個別抽出",
            //    continueflg = true,
            //    regsisyo = "1",
            //    userid = "1",
            //    parameters = new List<ParameterVM>
            //    {
            //        new ParameterVM { itemcd = "200400801001", value = "VH001" }
            //    }
            //};
            //var res3 = _service.Extract(req3);

            ////ストアド内チェックがアラートになり、個別抽出で継続希望フラグ＝False
            //ExtractRequest req4 = new()
            //{
            //    tyusyututaisyocd = "1996",
            //    kinoid = "AWKK01301G",
            //    nendo = 2024,
            //    atenano = "800000000000021",
            //    tyusyutunaiyo = "個別抽出",
            //    continueflg = false,
            //    regsisyo = "1",
            //    userid = "1",
            //    parameters = new List<ParameterVM>
            //    {
            //        new ParameterVM { itemcd = "200400801001", value = "VH001" }
            //    }
            //};
            //var res4 = _service.Extract(req4);

            //年齢変換ロジックテスト用 年齢該当ある
            ExtractRequest req5 = new()
            {
                tyusyututaisyocd = "1995",
                kinoid = "AWKK01301G",
                nendo = 2024,
                tyusyutunaiyo = "年齢が15-19歳、21歳、25-30歳の人",
                continueflg = false,
                regsisyo = "1",
                userid = "1",
                parameters = new List<ParameterVM>
                {
                    new ParameterVM { itemcd = "200400901101", value = "15-19,21,25-30" }
                }
            };
            var res5 = _service.Extract(req5);

            //年齢変換ロジックテスト用 年齢該当なし
            ExtractRequest req6 = new()
            {
                tyusyututaisyocd = "1995",
                kinoid = "AWKK01301G",
                nendo = 2024,
                tyusyutunaiyo = "年齢が15-20歳、21歳、25-30歳の人",
                continueflg = false,
                regsisyo = "1",
                userid = "1",
                parameters = new List<ParameterVM>
                {
                    new ParameterVM { itemcd = "200400901101", value = "15-20,21,25-30" }
                }
            };
            var res6 = _service.Extract(req6);
        }
    }
}