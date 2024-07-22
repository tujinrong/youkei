using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.AWKK00301G;
using GaibuApiService.GaibuDemo.Domain.Others;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;
using Newtonsoft.Json;

namespace BCC.Affect.Service.AWKK00303G
{
    [TestClass]
    public class AWKK00303G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////①初期化処理(個人詳細画面)テスト用
        //public void InitDetailTest()
        //{
        //    var req = new DaRequestBase()
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        token = "yyZhazJhfqDgVlho5f1Iog=1",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var res = _service.InitDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////②検索画面一覧テスト用
        //public void SearchListTest()
        //{

        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                         //ユーザーID
        //        regsisyo = "1",                                       //支所コード
        //        orderby = 0,

        //        //gyomu = "01 : 成人",                                  //業務
        //        //jigyo = "010 : 事業名テスト１",                     //事業
        //        //tantosya = "0000000001 : 鈴木葵",                   //予定者/実施者 
        //        //jissibasyo = "1",                                     //実施場所 
        //        //yoteiymdf = "2022-01-06",                           //予定日(From) 
        //        //yoteiymdt = "2022-02-10",                           //予定日(To) 
        //        //course = "4 : コース名テスト４",                    //コース 
        //        //jissiymdf = "2023-02-05",                           //実施日(From) 
        //        //jissiymdt = "2023-03-01",                           //実施日(To) 
        //        //coursenm = "コース",                                  //コース名 
        //        //atenano = "800000000000009",                        //宛名番号
        //        //atenano = "",                                       //宛名番号

        //        atenano = "000000000900001",                        //宛名番号（会社DB）
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //③個別入力画面検索処理テスト用（集団指導管理の検索結果一覧の行をクリックした場合）
        //④指導情報検索処理テスト用（個別入力画面のタブを選択（申込／結果））
        public void SearchDetailTest()
        {
            var req = new SearchDetailRequest
            {
                userid = "1",                                   //ユーザーID
                regsisyo = "1",
                token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083

                pagesize = 25,
                pagenum = 1,
                orderby = 0,

                //gyomukbn = "01",                                   //業務区分
                //edano = 11,                                        //枝番（設定の場合：更新）
                edano = 0,                                          //枝番（未設定の場合：新規）
                mosikomikekkakbn = "2",                           //申込結果区分
            };

            var res = _service.SearchDetail(req);

            var str = res.ToString();
        }

        //[TestMethod]
        ////⑤参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ））
        //public void SearchSankasyaListTest()
        //{
        //    var req = new SearchSankasyaListRequest
        //    {
        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,

        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        gyomukbn = "01",                                     //業務区分
        //        //jigyocd = "010",                                    //事業コード
        //        edano = 4,                                          //枝番
        //    };

        //    var res = _service.SearchSankasyaList(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////⑥個別入力画面保存テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new MainInfoVM
        //    {
        //        gyomukbn = "01",                                 //業務区分
        //        edano = 11,                                      //枝番（ない場合は新規とする）
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new MosikomiSaveVM()
        //    {
        //        inputflg = false,                                //申込情報入力
        //        jigyo = "010 : 事業コードテスト用1",            //事業コード
        //        yoteiymd = "2022-01-11",                        //実施予定日
        //        yoteitm = "1212",                               //予定開始時間
        //        kaijo = "1 : 沖縄会場",                         //実施場所
        //        regsisyocd = "1",                               //登録支所コード
        //    };

        //    // 申込情報（予定者リスト）
        //    var stafflist = new List<StaffListVM>();
        //    var vm = new StaffListVM()
        //    {
        //        staffid = "0000000001",                         //事業従事者ID
        //        staffsimei = "鈴木葵",                          //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000008",                         //事業従事者ID
        //        staffsimei = "高木明日香",                      //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000002",                         //事業従事者ID
        //        staffsimei = "岡田雄介",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);
        //    vm = new StaffListVM()
        //    {
        //        staffid = "0000000003",                         //事業従事者ID
        //        staffsimei = "中島美香",                        //事業従事者氏名
        //    };
        //    stafflist.Add(vm);

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
        //    var kekkainfo = new KekkaSaveVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        jigyo = "010 : 事業コードテスト用1",            //事業コード
        //        jissiymd = "2024-06-17",                        //実施日
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

        //    // 参加者情報
        //    var sankasyalist = new List<SankasyaListVM>();
        //    var svm = new SankasyaListVM()
        //    {
        //        atenano = "800000000000009",                    //宛名番号
        //        syukketukbn = "1",                              //出欠区分
        //    };
        //    sankasyalist.Add(svm);

        //    svm = new SankasyaListVM()
        //    {
        //        atenano = "800000000000010",                    //宛名番号
        //        syukketukbn = "2",                              //出欠区分
        //    };
        //    sankasyalist.Add(svm);

        //    svm = new SankasyaListVM()
        //    {
        //        atenano = "800000000000014",                    //宛名番号
        //        syukketukbn = "1",                              //出欠区分
        //    };
        //    sankasyalist.Add(svm);

        //    maininfo.mosikomiinfo = mosikomiinfo;
        //    maininfo.kekkainfo = kekkainfo;

        //    var sankasyainfo = new SankasyaSaveVM();
        //    sankasyainfo.inputflg = false;
        //    sankasyainfo.jigyo = "010 : 事業コードテスト用1";
        //    sankasyainfo.sankasyalist = sankasyalist;

        //    maininfo.sankasyainfo = sankasyainfo;

        //    maininfo.mosikomiinfo.jigyo = "010 : AAAAA";
        //    maininfo.kekkainfo.jigyo = "010 : AAAAA";
        //    maininfo.sankasyainfo.jigyo = "010 : AAAAA";

        //    maininfo.mosikomiinfo.inputflg = false;          //申込情報入力
        //    maininfo.kekkainfo.inputflg = true;             //結果情報入力
        //    maininfo.sankasyainfo.inputflg = false;         //参加者情報入力

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑦詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteRequest
        //    {
        //        userid = "0000000003",                          //ユーザーID

        //        gyomukbn = "01",                                 //業務区分
        //        edano = 11,                                     //枝番
        //    };

        //    var res = _service.Delete(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑧参加者詳細画面検索処理テスト用
        ////⑨参加者詳細情報検索処理テスト用（タブ切り替え）
        //public void SearchSankasyaDetail()
        //{
        //    var req = new SearchSankasyaDetailRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        gyomukbn = "01",                                   //業務区分
        //        edano = 1,                                        //枝番
        //        atenano = "800000000000009",                    　//宛名番号
        //        //atenano = "000000000900001",                    　//宛名番号
        //        mosikomikekkakbn = "2",                           //申込結果区分
        //    };

        //    var res = _service.SearchSankasyaDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑩参加者詳細画面保存テスト用
        //public void SaveSankasyaTest()
        //{
        //    var req = new SaveSankasyaRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "3",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new SankasyaMainInfoVM
        //    {
        //        edano = 1,                                      //枝番
        //        gyomukbn = "01",                                 //業務区分
        //        atenano = "800000000000009",                  　//宛名番号
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new SankasyaMosikomiInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        regsisyocd = "1",                               //登録支所コード
        //    };


        //    // 申込情報（フリー項目一覧）
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "111",                                  //値
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 3,                                  //入力タイプ
        //        item = "00607 : 【テスト】精密整数",            //項目
        //        value = "222",                                  //値
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
        //    var kekkainfo = new SankasyaKekkaInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        syukeikbn = "1 : 地域保健集計区分テスト１",     //地域保健集計区分
        //        regsisyocd = "2",                               //登録支所コード
        //    };

        //    // 結果情報（フリー項目一覧）
        //    freeiteminfo = new List<FreeItemInfoVM>();
        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "333",                                  //値
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
        //        value = "2022-12-23",                           //値
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

        //    maininfo.mosikomiinfo.inputflg = true;              //申込情報入力
        //    maininfo.kekkainfo.inputflg = false;                 //結果情報入力

        //    req.maininfo = maininfo;

        //    var res = _service.SaveSankasya(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑪参加者詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteSankasyaRequest
        //    {
        //        userid = "0000000003",                          //ユーザーID

        //        gyomukbn = "01",                                 //業務区分
        //        edano = 1,                                      //枝番
        //        atenano = "800000000000088",                    //宛名番号
        //    };

        //    var res = _service.DeleteSankasya(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑩参加者詳細画面保存テスト用
        //public void SaveSankasyaTest()
        //{
        //    var req = new SaveSankasyaRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "3",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new SankasyaMainInfoVM
        //    {
        //        edano = 7,                                      //枝番
        //        gyomukbn = "02",                                 //業務区分
        //        //atenano = "800000000000009",                  　//宛名番号
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new SankasyaMosikomiInfoVM()
        //    {
        //        yoteiymd = null,
        //        yoteitm = null,
        //        syukeikbn = null,
        //        jissiymd = null,
        //        tmf = null,
        //        tmt = null,
        //        inputflg = false,
        //        jigyo = null,
        //        kaijo = null,
        //        stafflist = null,
        //        regsisyocd = 0,
        //        regsisyonm = 支所000,
        //    };


        //    // 申込情報（フリー項目一覧）
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,
        //        item = "300200001001",
        //        value = null
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,
        //        item = "300100002001",
        //        value = null
        //    };
        //    freeiteminfo.Add(freevm);

        //    mosikomiinfo.freeiteminfo = freeiteminfo;

        //    // 結果情報（固定部分）
        //    var kekkainfo = new SankasyaKekkaInfoVM()
        //    {
        //        inputflg = true,                                //申込情報入力
        //        syukeikbn = "1 : 地域保健集計区分テスト１",     //地域保健集計区分
        //        regsisyocd = "2",                               //登録支所コード
        //    };

        //    // 結果情報（フリー項目一覧）
        //    freeiteminfo = new List<FreeItemInfoVM>();
        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,                                  //入力タイプ
        //        item = "00598 : 市区町村コード",                //項目
        //        value = "333",                                  //値
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
        //        value = "2022-12-23",                           //値
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

        //    maininfo.mosikomiinfo.inputflg = true;              //申込情報入力
        //    maininfo.kekkainfo.inputflg = false;                 //結果情報入力

        //    req.maininfo = maininfo;

        //    var res = _service.SaveSankasya(req);

        //    var str = res.ToString();
        //}



        //[TestMethod]
        ////⑥個別入力画面保存テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
        //    };

        //    var maininfo = new MainInfoVM
        //    {
        //        gyomukbn = "02",                                 //業務区分
        //        edano = 7,                                      //枝番（ない場合は新規とする）
        //    };

        //    // 申込情報（固定部分）
        //    var mosikomiinfo = new MosikomiSaveVM()
        //    {
        //        yoteiymd = null,
        //        yoteitm = null,
        //        //syukeikbn = null,
        //        //jissiymd = null,
        //        //tmf = null,
        //        //tmt = null,
        //        inputflg = false,
        //        jigyo = null,
        //        kaijo = null,
        //        stafflist = null,
        //        regsisyocd = "0",
        //        //regsisyonm = "支所000",
        //    };

        //    // 申込情報（予定者リスト）
        //    var stafflist = new List<StaffListVM>();

        //    mosikomiinfo.stafflist = stafflist;                 //予定者リスト

        //    // 申込情報（フリー項目一覧）
        //    var freeiteminfo = new List<FreeItemInfoVM>();
        //    var freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,
        //        item = "300200001001",
        //        value = null
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,
        //        item = "300100002001",
        //        value = null
        //    };
        //    freeiteminfo.Add(freevm);

        //    mosikomiinfo.freeiteminfo = freeiteminfo;

        //    // 結果情報（固定部分）
        //    var kekkainfo = new KekkaSaveVM()
        //    {
        //        //yoteiymd = null,
        //        //yoteitm = null,
        //        syukeikbn = "",
        //        jissiymd = "2024-06-25",
        //        tmf = "0944",
        //        tmt = "",
        //        inputflg = true,
        //        jigyo = "05  =  集団事業テスト５",
        //        kaijo = "",
        //        regsisyocd = "0",
        //        //regsisyonm = "支所000",
        //    };

        //    // 結果情報（実施者リスト）
        //    stafflist = new List<StaffListVM>();
        //    var vm = new StaffListVM()
        //    {
        //        staffid = "0000000002",
        //        staffsimei = "岡田雄介"
        //    };
        //    stafflist.Add(vm);

        //    kekkainfo.stafflist = stafflist;                    //実施者リスト

        //    // 結果情報（フリー項目一覧）
        //    freeiteminfo = new List<FreeItemInfoVM>();
        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype=1,
        //        item="300200001001",
        //        value=null
        //    };
        //    freeiteminfo.Add(freevm);

        //    freevm = new FreeItemInfoVM()
        //    {
        //        inputtype = 1,
        //        item = "300100002001",
        //        value = 33
        //    };
        //    freeiteminfo.Add(freevm);

        //    kekkainfo.freeiteminfo = freeiteminfo;

        //    // 参加者情報
        //    var sankasyalist = new List<SankasyaListVM>();

        //    maininfo.mosikomiinfo = mosikomiinfo;
        //    maininfo.kekkainfo = kekkainfo;

        //    var sankasyainfo = new SankasyaSaveVM()
        //    {
        //        inputflg = true,
        //        jigyo = "05",
        //    };
        //    sankasyainfo.sankasyalist = sankasyalist;

        //    maininfo.sankasyainfo = sankasyainfo;

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}

    }
}