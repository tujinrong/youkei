using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using Newtonsoft.Json;
using System.Collections.Generic;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWYS00101G
{
    [TestClass]
    public class AWYS00101G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////①検索画面一覧テスト用
        //public void SearchListTest()
        //{

        //    var searchVm1 = new SearchVM();
        //    searchVm1.jyokbn = Enum詳細検索条件区分.共通;
        //    searchVm1.jyoseq = 1;
        //    searchVm1.cdlist = new List<string> { "1", "10" };//ok

        //    var searchVm2 = new SearchVM();
        //    searchVm2.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm2.jyoseq = 7;
        //    var itemVm2 = new AWAF00703D.ItemVM();
        //    itemVm2.value1 = "5";
        //    searchVm2.itemvm = itemVm2;//ok

        //    var searchVm3 = new SearchVM();
        //    searchVm3.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm3.jyoseq = 16;
        //    var itemVm3 = new AWAF00703D.ItemVM();
        //    itemVm3.value1 = "2022-01-01";
        //    itemVm3.value2 = "2022-12-22";
        //    searchVm3.itemvm = itemVm3;//ok

        //    var syosailist = new List<SearchVM>()
        //    {
        //        searchVm1,
        //        searchVm2,
        //        searchVm3
        //    };

        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                     //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",            //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //        //atenano = "800000000000009",                      //宛名番号
        //        //atenano = "",                                   //宛名番号
        //        //personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",              //個人番号
        //        //name = "田村",                                  //氏名
        //        //name = "小林 悠香",                             //氏名
        //        //kname = "タ",                                   //カナ氏名（カタカナで入力）
        //        //kname = "ぐ",                                   //カナ氏名（カタカナで入力）
        //        //kname = "た",                                   //カナ氏名（ひらがなで入力）
        //        //kname = "",                                     //カナ氏名（未入力）
        //        //bymd = "1997-03-01",                            //生年月日
        //        //bymd = "",                                      //生年月日
        //        //bhtetyono = "9876543211",                       //母子手帳番号「母子健康手帳交付番号」
        //        //syosailist = syosailist
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面検索テスト用
        //public void SearchDetailTest()
        //{
        //    var req = new SearchDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 0,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //        rirekihyoji = true,                             //履歴表示（Ture：すべての枝番のデータを表示　False：最大枝番のデータのみ表示）
        //    };

        //    var res = _service.SearchDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面（生涯１回）検索テスト用
        //public void SearchDetailOneTest()
        //{
        //    var req = new SearchDetailOneRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 0,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //        //sessyufilterkbn = "3",                          //接種種類フィルター区分
        //        rirekihyoji = true,                             //履歴表示（Ture：すべての枝番のデータを表示　False：最大枝番のデータのみ表示）
        //    };

        //    var res = _service.SearchDetailOne(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面（複数回）検索テスト用
        //public void SearchDetailMultiTest()
        //{
        //    var req = new SearchDetailMultiRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 3,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //        //sessyufilterkbn = "5 : 成人用肺炎球菌",         //接種種類フィルター区分
        //        //sessyufilterkbn = " : ",                        //接種種類フィルター区分（選択しない場合）
        //        //sessyufilterkbn = "",                           //接種種類フィルター区分（空白の場合）
        //    };

        //    var res = _service.SearchDetailMulti(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面（罹患情報）検索テスト用
        //public void SearchDetailRikanTest()
        //{
        //    var req = new SearchDetailRikanRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 3,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //    };

        //    var res = _service.SearchDetailRikan(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面（接種依頼情報）検索テスト用
        //public void SearchDetailIraiTest()
        //{
        //    var req = new SearchDetailIraiRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 1,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //    };

        //    var res = _service.SearchDetailIrai(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////詳細画面（その他情報）検索テスト用
        //public void SearchDetailOtherTest()
        //{
        //    var req = new SearchDetailOtherRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,                                  //PageSize
        //        pagenum = 1,                                    //PageNum
        //        orderby = 1,                                    //ソート順

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",          //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //    };

        //    var res = _service.SearchDetailOther(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////接種情報詳細画面検索処理テスト用
        //public void SearchSessyuDetailTest()
        //{
        //    //削除の場合
        //    var req = new SearchSessyuDetailRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //        syougaiflg = "1",                                   //生涯フラグ（1：生涯1回、2：生涯複数回）
        //        sessyucd = "10001",                                 //接種種類コード
        //        kaisu = "12",                                       //回数
        //        edano = 2,                                          //枝番
        //    };

        //    var res = _service.SearchSessyuDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////接種依頼情報詳細画面検索処理テスト用
        //public void SearchSessyuIraiDetailTest()
        //{
        //    //削除の場合
        //    var req = new SearchSessyuIraiDetailRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //        edano = 0,                                          //枝番
        //    };

        //    var res = _service.SearchSessyuIraiDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////風疹抗体検査情報詳細画面検索処理テスト用
        //public void SearchfusinDetailTest()
        //{
        //    //削除の場合
        //    var req = new SearchFusinDetailRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    var res = _service.SearchFusinDetail(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////接種情報詳細画面保存テスト用
        //public void SaveSessyuTest()
        //{
        //    //保存の場合
        //    var req = new SaveSessyuRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //        syougaiflg = "1",                                   //生涯フラグ（1：生涯1回、2：生涯複数回）
        //    };

        //    var fixiteminfo = new FixItemSessyuBaseVM()
        //    {
        //        sessyu = "1000111 : 三種混合(1期初回1回目)",        //接種種類
        //        edano = 2,                                          //枝番
        //        jissiymd = "2020-01-01",                            //実施日
        //        sessyukbn = "2 : 接種",                             //接種区分
        //        lotno = "4K23B",                                    //ロット番号
        //        vaccinenm = "01 : 三種混合",                        //ワクチン名
        //        vaccinemaker = "0001 : 武田薬品工業株式会社",       //ワクチンメーカー
        //        sessyuryo = 12.21,                                  //接種量
        //        sessyukenno = "1000000004",                         //接種券番号
        //        jissikbn = "1 : 集団",                              //実施区分
        //        hoteikbn = "2 : 任意接種",                          //法定区分
        //        jissikikan = "0102 : 実施機関0102",                 //実施機関
        //        jissikikannm = "実施機関名22222",                   //実施機関名
        //        kaijo = "VH002 : BBBBB",                            //会場
        //        kaijonm = "会場名33333",                            //会場名
        //        isi = "0000000003 : AAAAAAAA",                      //医師
        //        isinm = "医師名4444",                               //医師名
        //        tokubetunojijyo = "3 : 新型AAAAA",                  //特別の事情
        //    };

        //    // フリー項目一覧
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005001 : 母子感染対象",               //項目
        //        value = "2",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005002 : 内部障害",                   //項目
        //        value = "1",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    req.fixiteminfo = fixiteminfo;
        //    req.freeiteminfo = freeiteminfo;

        //    var res = _service.SaveSessyu(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////接種依頼情報詳細画面保存テスト用
        //public void SaveSessyuIraiTest()
        //{
        //    //保存の場合
        //    var req = new SaveSessyuIraiRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    var fixiteminfo = new FixItemSessyuIraiBaseVM()
        //    {
        //        edano = 54,                                          //枝番
        //        uketukeymd = "2020-01-15",                          //受付日
        //        iraisaki = "依頼先AAAAA5",                           //依頼先
        //        irairiyu = "依頼理由BBBB5",                          //依頼理由
        //        hogosya_atenano = "800000000000015",                //保護者_宛名番号
        //        hogosya_simei = "田中次郎5",                         //保護者_氏名
        //    };

        //    var sessyulist = new List<SessyuVM>();           //接種種類リスト
        //    var sessyuvm = new SessyuVM()
        //    { 
        //        sessyucd = "10018",
        //        kaisu = "02"
        //    };
        //    sessyulist.Add(sessyuvm);

        //    sessyuvm = new SessyuVM()
        //    {
        //        sessyucd = "10009",
        //        kaisu = "02"
        //    };
        //    sessyulist.Add(sessyuvm);

        //    sessyuvm = new SessyuVM()
        //    {
        //        sessyucd = "10017",
        //        kaisu = "03"
        //    };
        //    sessyulist.Add(sessyuvm);

        //    // フリー項目一覧
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005001 : 母子感染対象",               //項目
        //        value = "1",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005002 : 内部障害",                   //項目
        //        value = "2",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    fixiteminfo.sessyusublist = sessyulist;
        //    req.fixiteminfo = fixiteminfo;
        //    req.freeiteminfo = freeiteminfo;

        //    var res = _service.SaveSessyuIrai(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////その他情報詳細画面保存テスト用
        //public void SaveOtherTest()
        //{
        //    //保存の場合
        //    var req = new SaveOtherRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    // フリー項目一覧
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005001 : 母子感染対象",               //項目
        //        value = "1",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005002 : 内部障害",                   //項目
        //        value = "1",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    req.freeiteminfo = freeiteminfo;

        //    var res = _service.SaveOther(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////風疹抗体検査情報詳細画面保存テスト用
        //public void SaveFusinTest()
        //{
        //    //保存の場合
        //    var req = new SaveFusinRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    var fixiteminfo = new FixItemFusinBaseVM()
        //    {
        //        sessyukenno = "1000000003",                         //接種券番号
        //        kotaikensahoho = "4 : ラデックス4",                  //抗体検査方法
        //        kotaika = "抗体価１",                               //抗体価
        //        tani = "1 : 倍",                                    //単位（抗体価）
        //        sessyuhantei = "1 : 接種対象",                      //接種判定
        //        jissiymd = "2022-03-04",                            //実施日
        //        jissikikan = "0102 : 実施機関0102",                 //実施機関
        //        jissikikannm = "実施機関名22222",                   //実施機関名
        //        isi = "0000000003 : AAAAAAAA",                      //医師
        //        isinm = "医師名4444",                               //医師名
        //        kotaikensano = "3 : 検査番号３",                    //抗体検査番号
        //    };

        //    // フリー項目一覧
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005001 : 母子感染対象",               //項目
        //        value = "2",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                     //入力タイプ
        //        item = "200400005002 : 内部障害",                   //項目
        //        value = "1",                                        //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    req.fixiteminfo = fixiteminfo;
        //    req.freeiteminfo = freeiteminfo;

        //    var res = _service.SaveFusin(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////接種情報詳細画面削除テスト用
        //public void DeleteSessyuTest()
        //{
        //    //削除の場合
        //    var req = new DeleteSessyuRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //        sessyucd = "10001",                                 //接種種類コード
        //        kaisu = "12",                                       //回数
        //        edano = 2,                                          //枝番
        //    };

        //    var res = _service.DeleteSessyu(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////接種依頼情報詳細画面削除テスト用
        //public void DeleteSessyuIraiTest()
        //{
        //    //削除の場合
        //    var req = new DeleteSessyuIraiRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //        edano = 54,                                          //枝番
        //    };

        //    var res = _service.DeleteSessyuIrai(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////風疹抗体検査情報詳細画面削除テスト用
        //public void DeleteFusinTest()
        //{
        //    //削除の場合
        //    var req = new DeleteFusinRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                 //alertviewflg=false 4084

        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    var res = _service.DeleteFusin(req);

        //    var str = res.ToString();
        //}
    }
}