using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using NPOI.SS.Formula.Functions;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00301G
{
    [TestClass]
    public class AWKK00301G_Test
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
        //    searchVm2.jyoseq = 16;
        //    var itemVm2 = new AWAF00703D.ItemVM();
        //    itemVm2.value1 = "011000";
        //    searchVm2.itemvm = itemVm2;//ok

        //    var searchVm3 = new SearchVM();
        //    searchVm3.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm3.jyoseq = 7;
        //    var itemVm3 = new AWAF00703D.ItemVM();
        //    itemVm3.value1 = "2022-01-01";
        //    itemVm3.value2 = "2023-12-24";
        //    searchVm3.itemvm = itemVm3;//ok


        //    var syosailist = new List<SearchVM>();
        //    syosailist.Add(searchVm1);
        //    syosailist.Add(searchVm2);
        //    syosailist.Add(searchVm3);

        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                 //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,
        //        pagenum = 2,
        //        orderby = 4,

        //        //token = "yyZhazJhfqDgVlho5f1Iog==",         //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",           //alertviewflg=false 4084
        //        //atenano = "800000000000009",                //宛名番号
        //        //atenano = "",                               //宛名番号
        //        //name = "",                               //氏名
        //        //kname = "リコク",                           //カナ氏名（カタカナで入力）
        //        //kname = "ぐ",                               //カナ氏名（カタカナで入力）
        //        //kname = "た",                               //カナ氏名（ひらがなで入力）
        //        //kname = "",                                 //カナ氏名（未入力）
        //        //bymd = "1997-03-01",                        //生年月日
        //        //bymd = "1996-11-12",                        //生年月日
        //        //bymd = "",                                  //生年月日
        //        //syosailist = syosailist
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////②③詳細画面検索テスト用
        //public void SearchDetailTest()
        //{
        //    var req = new SearchDetailRequest
        //    {
        //        userid = "1",                                 //ユーザーID
        //        regsisyo = "1",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",         //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",           //alertviewflg=false 4084

        //        atenano = "800000000000009",                  //宛名番号
        //        pagesize = 25,                                //PageSize
        //        pagenum = 1,                                  //PageNum
        //        orderby = 3,                                  //ソート順
        //    };

        //    var res = _service.SearchDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////④世帯詳細画面検索テスト用
        //public void SearchSetaiDetailTest()
        //{
        //    var req = new SearchSetaiDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        //atenano = "800000000000009",                    //宛名番号
        //        atenano = "000000000900004",                    //宛名番号
        //        hokensidokbn = "2",                             //保健指導区分
        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,
        //    };

        //    var res = _service.SearchSetaiDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑤.個人一覧画面検索検索テスト用
        //public void SearchShidouDetailTest()
        //{
        //    var req = new SearchShidouDetailRequest
        //    {
        //        //atenano = "800000000000009",                  //宛名番号
        //        atenano = "000000000900001",                    //宛名番号
        //        hokensidokbn = "1",                           //保健指導区分
        //        gyomukbn = "02",                              //業務区分
        //        jigyocd = "21005",                              //事業コード
        //        orderby = 0,
        //    };

        //    var res = _service.SearchShidouDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑥個人詳細新規処理テスト用（新規ボタンを押下）
        //public void SearchPersonDetailTest()
        //{
        //    var req = new SearchPersonDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",           //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084
        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,

        //        atenano = "800000000000009",                    //宛名番号
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "01",                                //業務区分
        //        //edano = 0,                                    //枝番（未設定の場合：新規）
        //        edano = 2,                                      //枝番（未設定の場合：新規）
        //        mosikomikekkakbn = "1",                         //申込結果区分
        //    };

        //    var res = _service.SearchPersonDetail(req);

        //    var str = res.ToString();

        //    //{ "atenano":"800000000000004","hokensidokbn":1,"gyomukbn":2,"mosikomikekkakbn":"1","edano":0,"pagesize":25,"pagenum":1,"orderby":0}
        //}

        //[TestMethod]
        ////⑥個人詳細新規処理テスト用（新規ボタンを押下）
        //public void SearchPersonDetailTest()
        //{
        //    var req = new SearchPersonDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

        //        atenano = "800000000000009",                    //宛名番号
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "02",                                 //業務区分
        //        //edano = 1,                                    //枝番（未設定の場合：新規）
        //        mosikomikekkakbn = "2",                         //申込結果区分
        //    };

        //    var res = _service.SearchPersonDetail(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //⑥個人詳細画面検索テスト用
        public void SearchPersonDetailTest()
        {
            var req = new SearchPersonDetailRequest
            {
                userid = "1",                                   //ユーザーID
                regsisyo = "1",
                token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

                atenano = "800000000000009",                    //宛名番号
                //atenano = "000000000900001",                    //宛名番号
                hokensidokbn = "1",                             //保健指導区分
                gyomukbn = "02",                                 //業務区分
                edano = 3,                                      //枝番
                mosikomikekkakbn = "2",                         //申込結果区分
            };

            var res = _service.SearchPersonDetail(req);

            var str = res.ToString();
        }

        //[TestMethod]
        ////⑦個人詳細新規処理検索テスト用
        //public void SearchPersonShidouTest()
        //{
        //    var req = new SearchPersonDetailRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "3",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",           //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "01",                                 //業務区分
        //        //edano = 1,                                    //枝番（未設定の場合：新規）
        //        mosikomikekkakbn = "1",                         //申込結果区分
        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,
        //    };

        //    var res = _service.SearchPersonShidou(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑦個人詳細画面検索テスト用
        //public void SearchPersonShidouTest()
        //{
        //    var req = new SearchPersonDetailRequest
        //    {
        //        atenano = "800000000000009",                    //宛名番号
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "01",                                //業務区分(01：成人保健　02：母子保健)
        //        edano = 1,                                      //枝番
        //        mosikomikekkakbn = "1",                         //申込結果区分
        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,
        //    };

        //    var res = _service.SearchPersonShidou(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑧詳細画面保存テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",                                 //登録支所
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new MainInfoVM
        //    {
        //        atenano = "000000000900004",                    //宛名番号
        //        //edano = 8,                                      //枝番（新規の場合はedano設定しない）
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "01",                                 //業務区分
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new MosikomiInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        jigyo = "010 : 事業コードテスト用1",            //事業コード
        //        yoteiymd = "2022-01-11",                        //実施予定日
        //        yoteitm = "1101",                               //予定開始時間
        //        kaijo = "1 : 沖縄会場",                         //実施場所
        //        regsisyocd = "0",                               //登録支所コード
        //    };

        //    // 申込情報（予定者リスト）
        //    var stafflist = new List<StaffListVM>();
        //    var vm = new StaffListVM()
        //    {
        //        staffid = "0000000001",                         //事業従事者ID
        //        staffsimei = "鈴木葵",                          //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    //vm = new StaffListVM()
        //    //{
        //    //    staffid = "0000000002",                         //事業従事者ID
        //    //    staffsimei = "岡田雄介",                        //事業従事者氏名
        //    //};
        //    //stafflist.Add(vm);
        //    //vm = new StaffListVM()
        //    //{
        //    //    staffid = "0000000003",                         //事業従事者ID
        //    //    staffsimei = "中島美香",                        //事業従事者氏名
        //    //};
        //    //stafflist.Add(vm);
        //    //vm = new StaffListVM()
        //    //{
        //    //    staffid = "0000000008",                         //事業従事者ID
        //    //    staffsimei = "高木明日香",                      //事業従事者氏名
        //    //};
        //    //stafflist.Add(vm);

        //    mosikomiinfo.stafflist = stafflist;                 //予定者リスト

        //    // 申込情報（フリー項目一覧）
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "431",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 3,                                  //入力タイプ
        //        item = "00607 : 【テスト】精密整数",            //項目
        //        value = "439",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 11,                                 //入力タイプ
        //        item = "00599 : 宛名番号_不詳",                 //項目
        //        value = "011004",                               //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 31,                                 //入力タイプ
        //        item = "00630 : 登録日",                        //項目
        //        value = "2022-05-24",                           //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                 //入力タイプ
        //        item = "00634 : 実施区分",                      //項目
        //        value = "3",                                    //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    mosikomiinfo.freeiteminfo = freeiteminfo;

        //    // 結果情報（固定部分）
        //    var kekkainfo = new KekkaInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        jigyo = "010 : 事業コードテスト用1",            //事業コード
        //        jissiymd = "2022-11-10",                        //実施日
        //        tmf = "0802",                                   //開始時間
        //        tmt = "1208",                                   //終了時間
        //        kaijo = "3 : 神奈川会場",                       //実施場所
        //        syukeikbn = "1 : 地域保健集計区分テスト１",     //地域保健集計区分
        //        regsisyocd = "2",                               //登録支所コード
        //    };

        //    // 結果情報（実施者リスト）
        //    stafflist = new List<StaffListVM>();
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000004",                         //事業従事者ID
        //        staffsimei = "藤田大輝",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000005",                         //事業従事者ID
        //        staffsimei = "小川美穂",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000009",                         //事業従事者ID
        //        staffsimei = "吉田健太郎",                      //事業従事者氏名
        //    };
        //    stafflist.Add(vm);

        //    kekkainfo.stafflist = stafflist;                    //実施者リスト

        //    // 結果情報（フリー項目一覧）
        //    freeiteminfo = new List<FreeItemInfoVM>();
        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "539",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 12,                                 //入力タイプ
        //        item = "00612 : 半角文字（半角英数字）3",       //項目
        //        value = "011045",                               //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 32,                                 //入力タイプ
        //        item = "00632 : 【テスト】精密不詳日付",        //項目
        //        value = "2022-11-25",                           //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                 //入力タイプ
        //        item = "00637 : コード（汎用マスタ）2",         //項目
        //        value = "5",                                    //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    kekkainfo.freeiteminfo = freeiteminfo;

        //    maininfo.mosikomiinfo = mosikomiinfo;
        //    maininfo.kekkainfo = kekkainfo;

        //    maininfo.mosikomiinfo.jigyo = "020 : BBBBB";
        //    maininfo.kekkainfo.jigyo = "020 : BBBBB";

        //    maininfo.mosikomiinfo.inputflg = true;          //申込情報入力
        //    maininfo.kekkainfo.inputflg = false;             //結果情報入力

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑧詳細画面保存テスト用（Front側から）
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",                                 //登録支所
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    //基本情報
        //    var maininfo = new MainInfoVM()
        //    {
        //        atenano = "800000000000009",
        //        hokensidokbn = "2",
        //        gyomukbn ="01",
        //        edano = 0,
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new MosikomiInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        jigyo = "090 : 事業コードテスト用9",            //事業コード
        //        yoteiymd = "2024-03-13",                        //実施予定日
        //        yoteitm = "0405",                               //予定開始時間
        //        kaijo = "",                                     //実施場所
        //        stafflist = { },                                //予定者リスト
        //        regsisyocd = "0",                               //登録支所コード
        //        freeiteminfo = { },                             //フリー項目一覧
        //    };

        //    // 結果情報（固定部分）
        //    var kekkainfo = new KekkaInfoVM()
        //    {
        //        inputflg = false,                               //申込情報入力
        //        jigyo = "",                                     //事業コード
        //        jissiymd = "",                                  //実施日
        //        tmf = "",                                       //開始時間
        //        tmt = "",                                       //終了時間
        //        kaijo = "",                                     //実施場所
        //        stafflist = { },                                //実施者リスト
        //        syukeikbn = "",                                 //地域保健集計区分
        //        //syukeikbn = "1 : 地域保健集計区分テスト１",     //地域保健集計区分
        //        regsisyocd = "0",                               //登録支所コード
        //        freeiteminfo = { },                             //フリー項目一覧
        //    };

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑨詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteRequest
        //    {
        //        userid = "0000000003",                          //ユーザーID

        //        atenano = "800000000000009",                    //宛名番号
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "01",                                 //業務区分
        //        edano = 8,                                      //枝番
        //    };

        //    var res = _service.Delete(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////③初期化処理(個人詳細画面)テスト用
        //public void InitDetailTest()
        //{
        //    var req = new DaRequestBase()
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var res = _service.InitDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////11.実施日時点年齢取得テスト用
        //public void GetAgeTest()
        //{
        //    var req = new GetAgeRequest
        //    {
        //        userid = "0000000003",                          //ユーザーID

        //        atenano = "000000000900008",                    //宛名番号
        //        yoteiymd = "2024-06-13",                        //実施予定日
        //    };

        //    var res = _service.GetAge(req);

        //    var str = res.ToString();
        //}



        //[TestMethod]
        ////⑧詳細画面保存テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                   //ユーザーID
        //        regsisyo = "1",                                 //登録支所
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new MainInfoVM
        //    {
        //        atenano = "000000000900001",                    //宛名番号
        //        edano = 0,                                      //枝番（新規の場合はedano設定しない）
        //        hokensidokbn = "1",                             //保健指導区分
        //        gyomukbn = "02",                                 //業務区分
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new MosikomiInfoVM()
        //    {
        //        inputflg = false,
        //        jigyo = null,
        //        yoteiymd = null,
        //        yoteitm = null,
        //        kaijo = null,
        //        regsisyocd = "0",
        //        regsisyonm = "支所000",
        //    };

        //    // 申込情報（予定者リスト）
        //    var stafflist = new List<StaffListVM>();

        //    mosikomiinfo.stafflist = stafflist;                 //予定者リスト

        //    // 申込情報（フリー項目一覧）
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "431",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 3,                                  //入力タイプ
        //        item = "00607 : 【テスト】精密整数",            //項目
        //        value = "439",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 11,                                 //入力タイプ
        //        item = "00599 : 宛名番号_不詳",                 //項目
        //        value = "011004",                               //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 31,                                 //入力タイプ
        //        item = "00630 : 登録日",                        //項目
        //        value = "2022-05-24",                           //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                 //入力タイプ
        //        item = "00634 : 実施区分",                      //項目
        //        value = "3",                                    //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    mosikomiinfo.freeiteminfo = freeiteminfo;

        //    // 結果情報（固定部分）
        //    var kekkainfo = new KekkaInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        jigyo = "010 : 事業コードテスト用1",            //事業コード
        //        jissiymd = "2022-11-10",                        //実施日
        //        tmf = "0802",                                   //開始時間
        //        tmt = "1208",                                   //終了時間
        //        kaijo = "3 : 神奈川会場",                       //実施場所
        //        syukeikbn = "1 : 地域保健集計区分テスト１",     //地域保健集計区分
        //        regsisyocd = "2",                               //登録支所コード
        //    };

        //    // 結果情報（実施者リスト）
        //    stafflist = new List<StaffListVM>();
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000004",                         //事業従事者ID
        //        staffsimei = "藤田大輝",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000005",                         //事業従事者ID
        //        staffsimei = "小川美穂",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000009",                         //事業従事者ID
        //        staffsimei = "吉田健太郎",                      //事業従事者氏名
        //    };
        //    stafflist.Add(vm);

        //    kekkainfo.stafflist = stafflist;                    //実施者リスト

        //    // 結果情報（フリー項目一覧）
        //    freeiteminfo = new List<FreeItemInfoVM>();
        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "539",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 12,                                 //入力タイプ
        //        item = "00612 : 半角文字（半角英数字）3",       //項目
        //        value = "011045",                               //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 32,                                 //入力タイプ
        //        item = "00632 : 【テスト】精密不詳日付",        //項目
        //        value = "2022-11-25",                           //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 41,                                 //入力タイプ
        //        item = "00637 : コード（汎用マスタ）2",         //項目
        //        value = "5",                                    //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    kekkainfo.freeiteminfo = freeiteminfo;

        //    maininfo.mosikomiinfo = mosikomiinfo;
        //    maininfo.kekkainfo = kekkainfo;

        //    maininfo.mosikomiinfo.jigyo = "020 : BBBBB";
        //    maininfo.kekkainfo.jigyo = "020 : BBBBB";

        //    maininfo.mosikomiinfo.inputflg = true;          //申込情報入力
        //    maininfo.kekkainfo.inputflg = false;             //結果情報入力

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}
    }
}