using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00302D
{
    [TestClass]
    public class AWBH00302D_Test
    {
        private readonly Service _service = new();

        [TestMethod]
        //⑧費用助成一覧画面検索処理
        public void SearchJyoseiListTest()
        {
            var req = new SearchJyoseiListRequest
            {
                userid = "1",                                   //ユーザーID
                regsisyo = "1",

                pagesize = 25,                                  //PageSize
                pagenum = 1,                                    //PageNum
                orderby = 3,                                    //ソート順

                //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
                //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
                token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

                bhsyosaimenyucd = "110",                        //母子詳細メニューコード
                bhsyosaitabcd = "2",                            //母子詳細タブコード
                sinseiedano = 1,                                //申請枝番
                atenano = "800000000000009",                    //宛名番号
                torokuno = 2001,                                //登録番号
            };

            var res = _service.SearchJyoseiList(req);

            var str = res.ToString();
        }

        //[TestMethod]
        ////⑨費用助成保存処理テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveJyoseiRequest
        //    {
        //        userid = "0000000002",                            //ユーザーID
        //        regsisyo = "3",                                   //登録支所
        //        token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

        //        bhsyosaimenyucd = "110",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "2",                              //母子詳細タブコード
        //        sinseiedano = 2,                                  //申請枝番
        //        atenano = "800000000000009",                      //宛名番号
        //        torokuno = 2001,                                  //登録番号
        //        checkflg = false,
        //    };

        //    // フリー項目一覧
        //    var jyoseilistinfo = new List<JyoseiListInfoVM>();
        //    var jyoseivm = new JyoseiListInfoVM()
        //    {
        //        joseikensyurui = "1 : １回目",                    //助成券種類
        //        jusinymd = "2022-02-04",                          //受診年月日
        //        siharaikingaku = 11020,                           //支払金額
        //        joseikingaku = 710,                               //助成金額
        //    };
        //    jyoseilistinfo.Add(jyoseivm);

        //    jyoseivm = new JyoseiListInfoVM()
        //    {
        //        joseikensyurui = "2 : ２回目",                    //助成券種類
        //        jusinymd = "2022-03-05",                          //受診年月日
        //        siharaikingaku = 12030,                           //支払金額
        //        joseikingaku = 920,                               //助成金額
        //    };
        //    jyoseilistinfo.Add(jyoseivm);

        //    jyoseivm = new JyoseiListInfoVM()
        //    {
        //        joseikensyurui = "3 : ３回目",                    //助成券種類
        //        jusinymd = "2022-04-06",                          //受診年月日
        //        siharaikingaku = 13040,                           //支払金額
        //        joseikingaku = 3300,                              //助成金額
        //    };
        //    jyoseilistinfo.Add(jyoseivm);

        //    jyoseivm = new JyoseiListInfoVM()
        //    {
        //        joseikensyurui = "4 : ４回目",                    //助成券種類
        //        jusinymd = "2022-05-07",                          //受診年月日
        //        siharaikingaku = 14050,                           //支払金額
        //        joseikingaku = 2450,                              //助成金額
        //    };
        //    jyoseilistinfo.Add(jyoseivm);

        //    req.jyoseilistinfo = jyoseilistinfo;

        //    var res = _service.SaveJyosei(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑨費用助成削除処理テスト用
        //public void DeleteJyoseiTest()
        //{
        //    //101-1テストデータ
        //    var req = new DeleteJyoseiRequest
        //    {
        //        userid = "0000000002",                            //ユーザーID
        //        regsisyo = "3",                                   //登録支所
        //        token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

        //        bhsyosaimenyucd = "110",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "2",                              //母子詳細タブコード
        //        sinseiedano = 2,                                  //申請枝番
        //        atenano = "800000000000009",                      //宛名番号
        //        torokuno = 2001,                                  //登録番号
        //        checkflg = false,
        //    };

        //    var res = _service.DeleteJyosei(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////初期化処理テスト用
        //public void InitListTest()
        //{
        //    //101-1テストデータ
        //    var req = new InitListRequest
        //    {
        //        userid = "0000000002",                            //ユーザーID
        //        regsisyo = "3",                                   //登録支所
        //        token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

        //        bhsyosaimenyucd = "110",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "2",                              //母子詳細タブコード
        //    };

        //    var res = _service.InitList(req);

        //    var str = res.ToString();
        //}
    }
}