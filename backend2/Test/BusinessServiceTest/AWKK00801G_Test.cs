using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.AWKK00301G;
using GaibuApiService.GaibuDemo.Domain.Others;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00801G
{
    [TestClass]
    public class AWKK00801G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////1初期化処理(選択画面)テスト用
        //public void InitChoiceTest()
        //{
        //    var req = new InitChoiceRequest()
        //    {
        //        kbn1 = Enum名称区分.名称,
        //        kbn2 = Enum名称区分.名称
        //    };

        //    var res = _service.InitChoice(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////2初期化処理(検診事業一覧画面)テスト用
        //public void InitKensinJigyoListest()
        //{
        //    var req = new DaRequestBase();

        //    var res = _service.InitKensinJigyoList(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////3初期化処理(検診事業詳細画面)テスト用
        //public void InitKensinJigyoDetailTest()
        //{
        //    var req = new InitKensinCommonRequest()
        //    {
        //        jigyocd = "00007",
        //    };

        //    var res = _service.InitKensinJigyoDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////4保存処理(検診事業詳細画面テスト用
        //public void SaveKensinJigyoDetailTest()
        //{
        //    var tm = "2024/01/19 16:15:55";
        //    var req = new SaveKensinJigyoDetailRequest
        //    {
        //        userid = "1",                                       //ユーザーID
        //        regsisyo = "1",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        editkbn = Enum編集区分.変更,
        //        jigyonm = "腹部超音波検診",
        //        jigyoshortnm = "腹",
        //        jigyocd = "00007",
        //        upddttm = DateTime.Parse(tm)
        //    };

        //    //検診事業詳細(事業内容)
        //    var jigyoinfo = new KensinDetailJigyoVM
        //    {
        //        kinoid = "AWSH00108G",                              //機能ID
        //        hyojinm = "拡事業管理",                           //機能表示名称
        //        seikenjissikbn = "1 : 実施",                        //精密検査実施区分(コード：名称)
        //        cuponhyojikbn = "1 : 表示",                         //クーポン券表示区分(コード：名称)
        //        genmenkbn = "1 : 特定健診",                         //減免区分(コード：名称)
        //    };

        //    //検診事業情報(検査方法)
        //    var hohoinfo = new KensinDetailHohoSaveVM
        //    {
        //        kensahoho_setflg = true,                            //検査方法設定フラグ
        //        kensahoho_subcdnm = "検査方法7",                    //検査方法サブコード名
        //    };

        //    var kekkalist = new List<KensinDetailHohoRowVM>();
        //    var vm1 = new KensinDetailHohoRowVM
        //    {
        //        kensahoho = "1",                                    //検査方法コード
        //        kensahohonm = "マンモ（１方向）",                   //検査方法名
        //        kensahohoshortnm = "マ１",                          //検査方法略称
        //    };
        //    kekkalist.Add(vm1);
        //    hohoinfo.kekkalist = kekkalist;

        //    //検診事業情報(予約分類)
        //    var yoyakuinfo = new KensinDetailYoyakuSaveVM
        //    {
        //        yoyakubunrui_subcdnm = "予約分類7",                 //予約分類サブコード名
        //    };
        //    var kekkalist1 = new List<KensinDetailYoyakuRowVM>();
        //    var vm2 = new KensinDetailYoyakuRowVM
        //    {
        //        yoyakubunrui = "1",                                 //予約分類コード
        //        yoyakubunruinm = "マンモ",                          //予約分類名
        //        yoyakubunruishortnm = "乳（マ）",                   //予約分類表示名
        //    };
        //    var yoyakubunruilist = new List<string>();
        //    yoyakubunruilist.Add("1");
        //    yoyakubunruilist.Add("2");
        //    yoyakubunruilist.Add("3");
        //    vm2.yoyakubunruilist = yoyakubunruilist;
        //    kekkalist1.Add(vm2);
        //    yoyakuinfo.kekkalist = kekkalist1;

        //    //検診事業情報(フリー項目)
        //    var freeinfo = new KensinDetailFreeSaveVM
        //    {
        //        groupid2_subcdnm = "グループ右7",                    //グループ2サブコード名
        //    };
        //    var kekkalist2 = new List<DaSelectorModel>();
        //    var vm = new DaSelectorModel
        //    {
        //        value = "1",                                        //コード
        //        label = "PHP項目",                                  //名称
        //    };
        //    kekkalist2.Add(vm);
        //    vm = new DaSelectorModel
        //    {
        //        value = "2",                                        //コード
        //        label = "VUE項目",                                  //名称
        //    };
        //    kekkalist2.Add(vm);
        //    freeinfo.kekkalist = kekkalist2;                        

        //    req.jigyoinfo = jigyoinfo;                              //検診事業詳細(事業内容)
        //    req.hohoinfo = hohoinfo;                                //検診事業情報(検査方法)
        //    req.yoyakuinfo = yoyakuinfo;                            //検診事業情報(予約分類)
        //    req.freeinfo = freeinfo;                                //検診事業情報(フリー項目)

        //    var res = _service.SaveKensinJigyoDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////5初期化処理(検診項目一覧画面)テスト用
        //public void InitKensinJigyoListest()
        //{
        //    var req = new InitKensinCommonRequest();

        //    var res = _service.InitKensinItemList(req);

        //    var str = res.ToString();
        //}

    }
}