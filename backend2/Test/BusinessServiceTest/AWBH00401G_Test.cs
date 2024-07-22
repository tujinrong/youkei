using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using BCC.Affect.Service.AWBH00301G;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;
using Newtonsoft.Json;

namespace BCC.Affect.Service.AWBH00401G
{
    [TestClass]
    public class AWBH00401G_Test
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
        //    itemVm2.value1 = "1";
        //    searchVm2.itemvm = itemVm2;//ok

        //    var searchVm3 = new SearchVM();
        //    searchVm3.jyokbn = Enum詳細検索条件区分.独自;
        //    searchVm3.jyoseq = 16;
        //    var itemVm3 = new AWAF00703D.ItemVM();
        //    itemVm3.value1 = "2022-01-01";
        //    itemVm3.value2 = "2022-12-22";
        //    searchVm3.itemvm = itemVm3;//ok

        //    var syosailist = new List<SearchVM>();
        //    syosailist.Add(searchVm1);
        //    syosailist.Add(searchVm2);
        //    syosailist.Add(searchVm3);

        //    var req = new SearchListRequest
        //    {
        //        userid = "1",                                     //ユーザーID
        //        regsisyo = "1",

        //        pagesize = 25,
        //        pagenum = 1,
        //        orderby = 0,

        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084
        //        atenano = "800000000000009",                    //宛名番号
        //        //atenano = "",                                     //宛名番号
        //        //personalno = "GRJXzE1kVug+9Y/W+JNF+7QMlmJ4ST6W4dytl++KyYY1YRZzIVx8trIPYQN65RdZ7K3BhlEKFAgZgHyxjpZXUmHVaoNMgXMb//P/76wOW37n0L/ux1FcgD2tPb+5h8rc3xtqouN+yUsIOleA/nyxBMTICle3odn0R8EBMdtboK9l8mU1z116k8mwM+TXEDE80TolIVxrZVxRue2wGeKJfiXvZW5gt3c2iMQLhOpjescXkQ9r0r4Mmd6nwE2y9VWfqhunsJxnZSgeH08KYMXcMQ5oxcYsfgfxdTMUe5KBttnxZGBWiofkBC9A50YjuqlzzgExtXriAhPd7GIU884SZg==",              //個人番号
        //        //name = "中啓",                                  //氏名
        //        //name = "小林 悠香",                             //氏名
        //        //kname = "タ",                                   //カナ氏名（カタカナで入力）
        //        //kname = "ぐ",                                   //カナ氏名（カタカナで入力）
        //        //kname = "た",                                   //カナ氏名（ひらがなで入力）
        //        //kname = "",                                     //カナ氏名（未入力）
        //        //bymd = "1997-03-01",                            //生年月日
        //        //bymd = "",                                      //生年月日
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
        //        userid = "1",                                     //ユーザーID
        //        regsisyo = "1",
        //        token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
        //        //token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

        //        atenano = "800000000000009",                      //宛名番号
        //        pagesize = 25,                                    //PageSize
        //        pagenum = 1,                                      //PageNum
        //        orderby = 3,                                      //ソート順
        //    };

        //    var res = _service.SearchDetail(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        //④フリー検索テスト用
        //④新規ボタンテスト用
        public void SearchSyosaiTest()
        {
            var req = new SearchSyosaiRequest
            {
                userid = "1",                                     //ユーザーID
                regsisyo = "1",
                token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
                //token = "yyZhazJhfqDgVlho5f1Iog==",             //alertviewflg=true 4083
                //token = "Vwdu6wgvN/pJZCJV9S0sCA==",             //alertviewflg=false 4084

                //bhsyosaimenyucd = "217",                        //母子詳細メニューコード（発育曲線）
                //bhsyosaitabcd = "1",                            //母子詳細タブコード（発育曲線）
                bhsyosaimenyucd = "115",                          //母子詳細メニューコード
                bhsyosaitabcd = "1",                              //母子詳細タブコード
                atenano = "800000000000009",                      //宛名番号
                kaisu = 0,                                        //履歴回数（新規の場合は0を設定する）
            };

            var res = _service.SearchSyosai(req);

            var str = res.ToString();
        }

        //[TestMethod]
        ////⑤父母親情報検索処理テスト用
        //public void SearchAtenaInfoTest()
        //{
        //    var req = new SearchAtenaInfoRequest
        //    {
        //        atenano = "800000000000009",                        //宛名番号
        //    };

        //    var res = _service.SearchAtenaInfo(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        //////⑥詳細画面保存テスト用
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",

        //    };

        //    var jsonstr = @"[{
        //        'userid': '1',
        //        'regsisyo': '1',
        //        'token': 'c3ynXVSMb65oDefej4nWpg==',
        //        'bhsyurui': '2',
        //        'bhsyosaimenyucd': '101',
        //        'bhsyosaitabcd': '1',
        //        'atenano': '800000000000009',
        //        'kaisu': 0,
        //        'freeiteminfo': [{
        //                'inputtype': 1,
        //                'item': '101901800001 : 出生順序',
        //                'value': '2'
        //            }, {
        //                'inputtype': 31,
        //                'item': '101901801001 : 把握日',
        //                'value': '2022-05-28'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901806001 : 貧血',
        //                'value': '2'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901825001 : 母親情報',
        //                'value': '母親情報BBBB'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901827001 : 父親情報',
        //                'value': '父親情報CCCC'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901829001 : 保護者情報',
        //                'value': '保護者情報DDDD'
        //            }, {
        //                'inputtype': 2,
        //                'item': '101901815001 : 出生時身長（ｃｍ）',
        //                'value': 15.4
        //            }
        //        ],
        //    }, {
        //        'userid': '1',
        //        'regsisyo': '1',
        //        'token': 'c3ynXVSMb65oDefej4nWpg==',
        //        'bhsyurui': '1',
        //        'bhsyosaimenyucd': '102',
        //        'bhsyosaitabcd': '2',
        //        'atenano': '800000000000009',
        //        'kaisu': 0,
        //        'freeiteminfo': [{
        //                'inputtype': 31,
        //                'item': '101901871001 : 初回検査_検査年月日',
        //                'value': '2022-05-29'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901876001 : 検査方法（初回検査）',
        //                'value': '3'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901887001 : 精密検査_検査結果左耳',
        //                'value': '1'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901897001 : 検査結果（精密検査）3',
        //                'value': '2'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901894001 : 検査方法（精密検査）',
        //                'value': '2'
        //            }
        //        ],
        //    }]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        //////⑥詳細画面保存テスト用
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",

        //    };

        //    var jsonstr = @"[{
        //        'userid': '1',
        //        'regsisyo': '1',
        //        'token': 'c3ynXVSMb65oDefej4nWpg==',
        //        'bhsyurui': '2',
        //        'bhsyosaimenyucd': '101',
        //        'bhsyosaitabcd': '1',
        //        'atenano': '800000000000009',
        //        'kaisu': 0,
        //        'fixiteminfo': [{
        //                'inputtype': 1,
        //                'item': 'torokuno : 登録番号',
        //                'value': '2001'
        //            }, {
        //                'inputtype': 1,
        //                'item': 'torokunorenban : 登録番号連番',
        //                'value': '1'
        //            }, {
        //                'inputtype': 11,
        //                'item': 'hahaoyaatenano : 母親_宛名番号',
        //                'value': '800000000000011'
        //            }, {
        //                'inputtype': 11,
        //                'item': 'titioyaatenano : 父親_宛名番号',
        //                'value': '800000000000012'
        //            }, {
        //                'inputtype': 11,
        //                'item': 'hogosyaatenano : 保護者_宛名番号',
        //                'value': '800000000000013'
        //            }

        //        ],
        //        'freeiteminfo': [{
        //                'inputtype': 1,
        //                'item': '101901800001 : 出生順序',
        //                'value': '2'
        //            }, {
        //                'inputtype': 31,
        //                'item': '101901801001 : 把握日',
        //                'value': '2022-05-28'
        //            }, {
        //                'inputtype': 41,
        //                'item': '101901806001 : 貧血',
        //                'value': '2'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901825001 : 母親情報',
        //                'value': '母親情報BBBB'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901827001 : 父親情報',
        //                'value': '父親情報CCCC'
        //            }, {
        //                'inputtype': 27,
        //                'item': '101901829001 : 保護者情報',
        //                'value': '保護者情報DDDD'
        //            }, {
        //                'inputtype': 2,
        //                'item': '101901815001 : 出生時身長（ｃｍ）',
        //                'value': 15.4
        //            }
        //        ],
        //    }]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑦詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteRequest
        //    {
        //        userid = "0000000003",                            //ユーザーID
        //        delflg = false,                                    //削除フラグ　True：全ての詳細内容削除、False：選択中の履歷のみ削除
        //        bhsyosaimenyucd = "109",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "1",                              //母子詳細タブコード
        //        atenano = "800000000000009",                      //宛名番号
        //        kaisu = 3,                                        //履歴回数（新規の場合は0を設定する）
        //    };

        //    var res = _service.Delete(req);

        //    var str = res.ToString();
        //}
    }
}