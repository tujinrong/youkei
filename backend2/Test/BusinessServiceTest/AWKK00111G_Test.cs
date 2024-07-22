using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.InfantVaccination;
using Newtonsoft.Json.Linq;
using NPOI.SS.Format;
using System.Collections.Generic;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00111G
{
    [TestClass]
    public class AWKK00111G_Test
    {
        private readonly Service _service = new();

        //[TestMethod]
        ////①検索画面初期化設定テスト用
        //public void InitTest()
        //{
        //    var req = new DaRequestBase();
        //    var res = _service.InitList(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////②検索画面一覧テスト用
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
        //        kinoid = "AWKK00111G",
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        atenano = "800000000000009",                            //宛名番号
        //        //atenano = "",                                           //宛名番号
        //        //name = "村",                                            //氏名
        //        //kname = "タ",                                           //カナ氏名（カタカナで入力）
        //        //kname = "た",                                           //カナ氏名（ひらがなで入力）
        //        //kname = "",                                           //カナ氏名（未入力）
        //        //bymd = "1995-06-02",                                    //生年月日
        //        //bymd = "",                                              //生年月日
        //        //personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",              //個人番号
        //        syosailist = {},                                      //詳細条件(検索)  -- Pending
        //        fusyoflg = false,                                       //不詳フラグ
        //        //fusyoflg = true,                                       //不詳フラグ
        //        //reguser = "0000000003 : 岡田雄介",                      //登録者(コード：名称)
        //        //reguser = "chen1 : 陳さん",                             //登録者(コード：名称)
        //        //regdatef = DateTime.Now.AddMonths(-10),                 //登録日時（開始）
        //        //regdatet = DateTime.Now,                                //登録日時（終了）
        //        //regdatef = "2023-01-01 11:01:00",                     //登録日時（開始）
        //        //regdatet = "2023-12-01 11:01:00",                     //登録日時（終了）
        //        //upduser = "0000000003 : 鈴木葵",                        //登録者(コード：名称)
        //        //upduser = "0000000003 : 陳さん",                             //登録者(コード：名称)
        //        //upddatef = DateTime.Now.AddMonths(-10),                 //登録日時（開始）
        //        //upddatet = DateTime.Now,                                //登録日時（終了）
        //        //upddatef = "2023-01-01 11:01:00",                     //登録日時（開始）
        //        //upddatet = "2023-12-01 11:01:00",                     //登録日時（終了）
        //        //delflg = "1 : 削除データを含まない",                    //削除フラグ(コード：名称) 使用停止フラグ=false
        //        //delflg = "2 : 削除データのみ",                          //削除フラグ(コード：名称) 使用停止フラグtrue

        //        //gyomuid = "2 : 参照業務テスト２",                       //業務ID(コード：名称)
        //        //dokujisystemid = "3 : 参照独自施策システムテスト３",    //独自施策システム等ID(コード：名称)

        //        //orderby = 4,
        //    };

        //    var res = _service.SearchList(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////③詳細画面初期設定テスト用
        //public void InitDetailTest()
        //{
        //    var req = new DaRequestBase();

        //    var res = _service.InitDetail(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        ////④詳細画面検索テスト用
        //public void SearchDetailTest()
        //{
        //    var req = new SearchDetailRequest
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        kinoid = "AWKK00111G",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        atenano = "800000000000009",                    //宛名番号
        //        rirekino = 1,                                   //履歴番号
        //        rirekinum = 0,                                  //履歴番号（一覧から選択した場合）

        //        //rirekinum = 9,                                 //履歴番号（詳細画面で改ページの場合「手で入力」）
        //        //rirekinum = 7,                                 //履歴番号（詳細画面で改ページの場合「前ページ」）
        //        //rirekinum = 9,                                 //履歴番号（詳細画面で改ページの場合「次ページ」）
        //        //rirekinum = 8,                                 //履歴番号（詳細画面で改ページの場合「自ページ」）
        //    };

        //    var res = _service.SearchDetail(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //⑤詳細画面異動処理テスト用
        public void SearchSaisinDetailTest()
        {
            var req = new SearchSeisinDetailRequest
            {
                userid = "1",                                          //ユーザーID
                regsisyo = "1",
                token = "yyZhazJhfqDgVlho5f1Iog==",                 //alertviewflg=true 4083
                //token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084
                //atenano = "800000000000009",                  //宛名番号
                atenano = "000000000900003",                  //宛名番号
            };

            var res = _service.SearchSeisinDetail(req);

            var str = res.ToString();
        }

        //[TestMethod]
        ////⑥詳細画面保存テスト用
        //public void SaveTest()
        //{
        //    var req = new SaveRequest
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        kinoid = "AWKK00111G",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084
        //    };


        //    var maininfo = new MainInfoVM
        //    {
        //        ////ケース１新規の場合
        //        //atenano = "800000000000009",            //宛名番号
        //        ////atenano = "929999990001",            //宛名番号（新規テスト）
        //        //rirekino = 15,                           //履歴番号
        //        //personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",                //個人番号
        //        //setaino = "700000000000004",            //世帯番号
        //        //jutogaisyasyubetu = "1 : 日本人住民",   //住登外者種別
        //        //jutogaisyajotai = "1 : 住登者",         //住登外者状態
        //        //idoymd = "2000-03-18",                  //異動年月日
        //        //idotodokeymd = "2000-04-11",            //異動届出年月日
        //        //idojiyu = "21 : 消除_国内転出",         //異動事由
        //        //si = "村田",                            //氏_日本人
        //        //mei = "穂美",                           //名_日本人
        //        //simei_gairoma = "abcd",                 //氏名_外国人ローマ字
        //        //simei_gaikanji = "建華",              //氏名_外国人漢字
        //        //simei_kana = "ミホタムラ",              //氏名_フリガナ
        //        //si_kana = "ムタラ",                     //氏_日本人_フリガナ
        //        //mei_kana = "ホミ",                      //名_日本人_フリガナ
        //        //tusyo = "穂美",                         //通称
        //        //tusyo_kana = "ホミ",                    //通称_フリガナ
        //        //tusyo_kanastatus = "1",                 //通称_フリガナ確認状況
        //        //sex = "2 : 女",                         //性別
        //        //bymd = "1996-06-02",                    //生年月日
        //        //bymd_fusyoflg = false,                  //生年月日_不詳フラグ
        //        //bymd_fusyohyoki = "1996年06月02日",     //生年月日_不詳表記
        //        //adrs_sikucd = "141119",                 //市区町村
        //        //adrs_tyoazacd = "9999999",              //町字コード
        //        //tosi_gyoseikucd = "251160001004 : 神奈川県横浜市港南区",       //指定都市_行政区等コード
        //        //adrs_todofuken = "神奈川県",            //住所_都道府県
        //        //adrs_sikunm = "横浜市港南区",           //住所_市区郡町村名
        //        //adrs_tyoaza = "下永谷六丁目",           //住所_町字
        //        //adrs_bantihyoki = "xxxx",               //住所_番地号表記
        //        //adrs_katagaki = "yyyy",                 //住所_方書(フリガナ)
        //        //adrs_katagaki_kana = "zzzz",            //住所_方書
        //        //adrs_yubin = "2330016",                 //住所_郵便番号
        //        //adrs_kokunmcd = "101",                  //住所_国名コード
        //        //adrs_kokunm = "国",                   //住所_国名等
        //        //adrs_gaiadrs = "ソール大道府１１１１",  //住所_国外住所
        //        //hokenkbn = " : ",                         //保険区分（コード：名称）
        //        //nayosemotoflg = "1 : 該当しない",         //名寄せ元フラグ（コード：名称）
        //        //nayosesakiatenano = "1",                  //名寄せ先宛名番号
        //        //togoatenaflg = "2 : 該当する",            //統合宛名フラグ（コード：名称）
        //        //sansyofuka = "1 : 参照不可",              //他業務参照不可フラグ（コード：名称）
        //        //stop = "0",                             //使用停止フラグ
        //        //saisin = "1",                           //最新フラグ
        //        //regbusyocd = "1 : 登録部署テスト１",      //登録部署（コード：名称）
        //        //upddttm = null,                         //更新日時

        //        //ケース２更新の場合
        //        //atenano = "800000000000009",              //宛名番号
        //        atenano = "000000000900015",                  //宛名番号
        //        //atenano = "700000000000104",            //宛名番号（新規テスト）
        //        rirekino = 2,                             //履歴番号
        //        personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",  //個人番号（RSA暗号化）
        //        //setaino = "700000000000004",              //世帯番号
        //        setaino = "000000000800014",              //世帯番号

        //        jutogaisyasyubetu = "2",                  //住登外者種別
        //        jutogaisyajotai = "2",                    //住登外者状態
        //        idoymd = "2001-05-18",                    //異動年月日
        //        idotodokeymd = "2001-05-11",              //異動届出年月日
        //        idojiyu = "21 : 消除_国内転出",           //異動事由（コード：名称）
        //        si = "田中",                              //氏_日本人
        //        mei = "啓二",                             //名_日本人
        //        simei_gairoma = "TOM",                    //氏名_外国人ローマ字
        //        simei_gaikanji = "三",                  //氏名_外国人漢字
        //        simei_kana = "タナカケイジ",              //氏名_フリガナ
        //        si_kana = "タナカ",                       //氏_日本人_フリガナ
        //        mei_kana = "ケイジ",                      //名_日本人_フリガナ
        //        tusyo = "啓二",                           //通称
        //        tusyo_kana = "ケイジ",                    //通称_フリガナ
        //        tusyo_kanastatus = "1",                   //通称_フリガナ確認状況
        //        sex = "1 : 男",                           //性別（コード：名称）
        //        bymd = "1997-03-01",                      //生年月日
        //        bymd_fusyoflg = false,                    //生年月日_不詳フラグ
        //        bymd_fusyohyoki = "1997年03月01日",       //生年月日_不詳表記
        //        adrs_sikucd = "131130",                   //市区町村
        //        adrs_tyoazacd = "9999999",                //町字コード
        //        tosi_gyoseikucd = "251160001004 : 神奈川県横浜市港南区", //指定都市_行政区等コード（コード：名称）
        //        adrs_todofuken = "東京都",                //住所_都道府県
        //        adrs_sikunm = "東京都港南区",             //住所_市区郡町村名
        //        adrs_tyoaza = "ああ下永谷六丁目",         //住所_町字
        //        adrs_bantihyoki = "いいいい",             //住所_番地号表記
        //        adrs_katagaki = "うううう",               //住所_方書(フリガナ)
        //        adrs_katagaki_kana = "ええええ",          //住所_方書
        //        adrs_yubin = "2330016",                   //住所_郵便番号
        //        adrs_kokunmcd = "102",                    //住所_国名コード
        //        adrs_kokunm = "ベトナム",                 //住所_国名等
        //        adrs_gaiadrs = "ベトナム大道府２２２２２",//住所_国外住所
        //        hokenkbn = " : ",                         //保険区分（コード：名称）
        //        nayosemotoflg = "1 : 該当しない",         //名寄せ元フラグ（コード：名称）
        //        nayosesakiatenano = "1",                  //名寄せ先宛名番号
        //        togoatenaflg = "2 : 該当する",            //統合宛名フラグ（コード：名称）
        //        sansyofuka = "1 : 参照不可",              //他業務参照不可フラグ（コード：名称）
        //        stop = "0",                               //使用停止フラグ
        //        saisin = "1",                             //最新フラグ
        //        regbusyocd = "1 : 登録部署テスト１",      //登録部署（コード：名称）
        //        upddttm = CDate("2023/11/21 13:55:09"),   //更新日時
        //    };

        //    var vm2 = new List<RefListVM>();
        //    maininfo.dokujisystemcdlist = vm2;

        //    var vm1 = new RefListVM();
        //    vm1.hanyocd = "1";
        //    vm1.nm = "参照独自施策テスト１";
        //    maininfo.dokujisystemcdlist.Add(vm1);
        //    vm1 = new RefListVM();
        //    vm1.hanyocd = "3";
        //    vm1.nm = "参照独自施策テスト３";
        //    maininfo.dokujisystemcdlist.Add(vm1);
        //    vm1 = new RefListVM();
        //    vm1.hanyocd = "4";
        //    vm1.nm = "参照独自施策テスト４";
        //    maininfo.dokujisystemcdlist.Add(vm1);

        //    vm2 = new List<RefListVM>();
        //    maininfo.sansyogyomucdlist = vm2;
        //    vm1 = new RefListVM();
        //    vm1.hanyocd = "1";
        //    vm1.nm = "参照業務テスト１";
        //    maininfo.sansyogyomucdlist.Add(vm1);
        //    vm1 = new RefListVM();
        //    vm1.hanyocd = "2";
        //    vm1.nm = "参照業務テスト２";
        //    maininfo.sansyogyomucdlist.Add(vm1);
        //    vm1 = new RefListVM();
        //    vm1.hanyocd = "3";
        //    vm1.nm = "参照業務テスト３";
        //    maininfo.sansyogyomucdlist.Add(vm1);

        //    req.maininfo = maininfo;

        //    var res = _service.Save(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑦同一世帯員情報更新処理テスト用
        //public void SaveSeiteiTest()
        //{
        //    //削除の場合
        //    var req = new SaveSeitaiRequest
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        kinoid = "AWKK00111G",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        atenano = "700000000000104",                  //宛名番号

        //        rirekino = 7,                                 //履歴番号
        //    };

        //    var vm1 = new List<SeitaiDictVM>();

        //    var vm = new SeitaiDictVM();
        //    vm.atenano = "800000000000009";
        //    vm1.Add(vm);

        //    vm = new SeitaiDictVM();
        //    vm.atenano = "800000000000010";
        //    vm1.Add(vm);

        //    req.seitaidictlist = vm1;

        //    var res = _service.SaveSeitai(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑧詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteRequest
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        kinoid = "AWKK00111G",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        atenano = "800000000000011",                  //宛名番号
        //    };

        //    var res = _service.Delete(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑨詳細画面郵便情報検索テスト用
        //public void SearchYubinTest()
        //{
        //    var req = new AutoSetRequest
        //    {
        //        userid = "0000000003",                        //ユーザーID
        //        adrs_yubin = "2330016",                       //郵便番号
        //    };

        //    var res = _service.SearchYubin(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑩個人番号取得テスト用
        //public void GetPersonalTest()
        //{
        //    var req = new SearchPersonalRequest()
        //    {
        //        userid = "1",                                          //ユーザーID
        //        regsisyo = "1",
        //        kinoid = "AWKK00111G",
        //        token = "yyZhazJhfqDgVlho5f1Iog==",                     //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",                     //alertviewflg=false 4084

        //        atenano = "800000000000009",                  //宛名番号
        //    };

        //    var res = _service.SearchPersonal(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑪詳細画面自動付番テスト用
        //public void AutoSeibanTest()
        //{
        //    var req = new AutoSaibanRequest()
        //    {
        //        //seqflg = "1",                                   //世帯番号
        //        seqflg = "2",                                   //宛名番号
        //    };

        //    var res = _service.AutoSaisin(req);

        //    var str = res.ToString();
        //}
    }
}