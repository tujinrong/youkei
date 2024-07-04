using BCC.Affect.DataAccess;
using BCC.Affect.Service.AWAF00703D;
using Newtonsoft.Json;
using System.Collections.Generic;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00301G
{
    [TestClass]
    public class AWBH00301G_Test
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
        //        orderby = 6,

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
        ////②③詳細画面検索テスト用
        //public void SearchDetailTest()
        //{
        //    var req = new SearchDetailRequest
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
        //        torokuno = 2001,                                //登録番号
        //    };

        //    var res = _service.SearchDetail(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////④フリー検索テスト用
        ////④新規ボタンテスト用
        //public void SearchSyosaiTest()
        //{
        //    var req = new SearchSyosaiRequest
        //    {
        //        userid = "1",                                     //ユーザーID
        //        regsisyo = "1",
        //        //token = "rgXSSiJqkvLLFSzWyEuKWA ==",              //alertviewflg=true 4835
        //        //token = "yyZhazJhfqDgVlho5f1Iog==",               //alertviewflg=true 4083
        //        token = "Vwdu6wgvN/pJZCJV9S0sCA==",               //alertviewflg=false 4084

        //        pagesize = 0,
        //        pagenum = 0,

        //        bhsyosaimenyucd = "110",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "1",                              //母子詳細タブコード
        //        atenano = "800000000000009",                      //宛名番号
        //        torokuno = 2001,                                  //登録番号
        //        torokunorenban = 0,                               //登録番号連番（多胎管理でない場合は0）

        //        edano = 1,                                        //枝番（履歴回数管理でない場合は0）
        //        kaisu = 0,                                        //履歴回数（履歴回数管理でない場合は0）
        //    };

        //    var res = _service.SearchSyosai(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑤医療機関検索処理テスト用
        //public void SearchKikanNMTest()
        //{
        //    var req = new SearchKikanNMRequest
        //    {
        //        kikancd = "0102",                                   //医療機関コード
        //    };

        //    var res = _service.SearchKikanNM(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        ////⑤医師検索処理テスト用
        //public void SearchIshiNMTest()
        //{
        //    var req = new SearchIshiNMRequest
        //    {
        //        staffid = "0000000002",                              //医師コード
        //    };

        //    var res = _service.SearchIshiNM(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////101-1/102-2テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""101"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 31,
        //                ""item"": ""101901520001 : 出産予定日"",
        //                ""value"": ""2022-03-11""
        //            },
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901521001 : 届出時妊娠週数"",
        //                ""value"": ""7""
        //            },
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901522001 : 届出時妊娠月数"",
        //                ""value"": ""9""
        //            },
        //            {
        //                ""inputtype"": 26,
        //                ""item"": ""101901523001 : 届出者氏名"",
        //                ""value"": null
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901524001 : 届出者続柄"",
        //                ""value"": ""3""
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901525001 : 届出時期（不詳含む）"",
        //                ""value"": ""3""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 0
        //    },
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""101"",
        //        ""bhsyosaitabcd"": ""2"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 31,
        //                ""item"": ""101901554001 : 面接日"",
        //                ""value"": ""2022-05-15""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 0
        //    }

        //        ]";



        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////101-1/102-2テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""101"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        'fixiteminfo': [{
        //                'inputtype': 1,
        //                'item': 'todokedeymd : 届出年月日',
        //                'value': '2022-04-14'
        //            }, {
        //                'inputtype': 11,
        //                'item': 'titioyaatenano : 父親_宛名番号',
        //                'value': '800000000000011'
        //            }
        //        ],
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 31,
        //                ""item"": ""101901520001 : 出産予定日"",
        //                ""value"": ""2022-03-15""
        //            },
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901521001 : 届出時妊娠週数"",
        //                ""value"": ""6""
        //            },
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901522001 : 届出時妊娠月数"",
        //                ""value"": ""7""
        //            },
        //            {
        //                ""inputtype"": 26,
        //                ""item"": ""101901523001 : 届出者氏名"",
        //                ""value"": null
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901524001 : 届出者続柄"",
        //                ""value"": ""3""
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901525001 : 届出時期（不詳含む）"",
        //                ""value"": ""3""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 0
        //    }

        //        ]";



        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////105-1(00005)テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""105"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 7,
        //        'fixiteminfo': [{
        //                'inputtype': 1,
        //                'item': 'jusinymd : 受診日',
        //                'value': '2022-04-11'
        //            }, {
        //                'inputtype': 41,
        //                'item': 'jusinkbn : 受診区分',
        //                'value': '2'
        //            }
        //        ],
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 70,
        //                ""item"": ""101901583001 : 医療機関コード"",
        //                ""value"": ""0101""
        //            },
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901586001 : 妊娠週数"",
        //                ""value"": ""6""
        //            },
        //            {
        //                ""inputtype"": 2,
        //                ""item"": ""101901589001 : 健診時体重"",
        //                ""value"": ""22""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 0
        //    }

        //        ]";



        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}

        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////107-1 00009テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = true,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""107"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        'fixiteminfo': [{
        //                'inputtype': 31,
        //                'item': 'seimitukensajissiymd : 精密検査実施日',
        //                'value': '2022-04-25'
        //            }
        //        ],
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 70,
        //                ""item"": ""101901702001 : 精密検査実施機関コード"",
        //                ""value"": ""0102""
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901704001 : 医療機関等へ委託"",
        //                ""value"": ""2""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 6
        //    }

        //        ]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////109-1 00008テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""109"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        'fixiteminfo': [{
        //                'inputtype': 31,
        //                'item': 'seimitukensajissiymd : 精密検査実施日',
        //                'value': '2022-04-24'
        //            }
        //        ],
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 70,
        //                ""item"": ""101901685001 : 精密検査実施機関コード"",
        //                ""value"": ""0101""
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901687001 : 医療機関等へ委託"",
        //                ""value"": ""0""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 0
        //    }

        //        ]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////108-1 00007テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[
        //    {
        //        ""bosikbn"": ""1"",
        //        ""bhsyosaimenyucd"": ""108"",
        //        ""bhsyosaitabcd"": ""1"",
        //        ""atenano"": ""800000000000009"",
        //        ""kaisu"": 0,
        //        'fixiteminfo': [{
        //                'inputtype': 31,
        //                'item': 'ninsanpusikajusinymd : 妊産婦歯科健診受診日',
        //                'value': '2022-04-25'
        //            },{
        //                'inputtype': 41,
        //                'item': 'ninsanpukbn : 妊産婦区分',
        //                'value': '2'
        //            }
        //        ],
        //        ""freeiteminfo"": [
        //            {
        //                ""inputtype"": 1,
        //                ""item"": ""101901665001 : 妊娠週数"",
        //                ""value"": ""11""
        //            },
        //            {
        //                ""inputtype"": 41,
        //                ""item"": ""101901668001 : 要治療のむし歯有無"",
        //                ""value"": ""2""
        //            }
        //        ],
        //        ""torokunorenban"": 0,
        //        ""torokuno"": 2001,
        //        ""edano"": 8
        //    }

        //        ]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}



        //    [TestMethod]
        //    ////⑥詳細画面保存テスト用
        //    /////107-1 00009テストデータ
        //    ///
        //    public void SaveTest()
        //    {
        //        var req = new SaveAllRequest
        //        {
        //            userid = "1",
        //            regsisyo = "1",
        //            token = "c3ynXVSMb65oDefej4nWpg==",
        //            checkflg = false,
        //        };


        //        var jsonstr = @"[{""bosikbn"":""1"",""bhsyosaimenyucd"":""101"",""bhsyosaitabcd"":""1"",""atenano"":""800000000000009"",""kaisu"":0,
        //""freeiteminfo"":[{""inputtype"":31,""item"":""101901520001 : 出産予定日"",""value"":""2022-03-15""}
        //,{""inputtype"":1,""item"":""101901521001 : 届出時妊娠週数"",""value"":6}
        //,{""inputtype"":1,""item"":""101901522001 : 届出時妊娠月数"",""value"":7}
        //,{""inputtype"":26,""item"":""101901523001 : 届出者氏名"",""value"":null}
        //,{""inputtype"":41,""item"":""101901524001 : 届出者続柄"",""value"":""3 : : : : ""}
        //,{""inputtype"":41,""item"":""101901525001 : 届出時期（不詳含む）"",""value"":""3 : 満20週～27週(第6月～第7月) : : : ""}
        //,{""inputtype"":41,""item"":""101901527001 : 医師又は助産師の診断又は保健指導の有無"",""value"":null}
        //,{""inputtype"":70,""item"":""101901528001 : 医療機関コード"",""value"":null}
        //,{""inputtype"":26,""item"":""101901529001 : 医療機関名"",""value"":null}
        //,{""inputtype"":26,""item"":""200300001001 : 医療機関名（その他）"",""value"":null}
        //,{""inputtype"":26,""item"":""101901530001 : 医師氏名"",""value"":null}
        //,{""inputtype"":26,""item"":""200300002001 : 医師氏名（その他）"",""value"":null}
        //,{""inputtype"":26,""item"":""101901531001 : 職業"",""value"":null}
        //,{""inputtype"":42,""item"":""101901532001 : ハイリスク"",""value"":null}
        //,{""inputtype"":41,""item"":""101901533001 : 妊娠歴"",""value"":null}
        //,{""inputtype"":1,""item"":""101901534001 : 妊娠回数"",""value"":null}
        //,{""inputtype"":41,""item"":""101901535001 : 出産歴"",""value"":null}
        //,{""inputtype"":1,""item"":""101901536001 : 出産回数"",""value"":null}
        //,{""inputtype"":41,""item"":""101901537001 : 性病に関する健康診断の有無"",""value"":null}
        //,{""inputtype"":41,""item"":""101901538001 : 結核に関する健康診断の有無"",""value"":null}
        //,{""inputtype"":41,""item"":""101901539001 : 届出事由"",""value"":null}
        //,{""inputtype"":42,""item"":""101901540001 : 届出場所"",""value"":null}
        //,{""inputtype"":26,""item"":""101901542001 : 父親氏名"",""value"":null}
        //,{""inputtype"":41,""item"":""101901543001 : 多胎の有無"",""value"":null}
        //,{""inputtype"":26,""item"":""200300006001 : 精密検査実施機関名（その他）"",""value"":null}
        //,{""inputtype"":26,""item"":""200300007001 : 精密検査実施機関名（その他）"",""value"":null}
        //,{""inputtype"":26,""item"":""200300010001 : 精密検査実施機関名（その他）"",""value"":null}
        //]
        //, ""torokunorenban"" :0
        //, ""torokuno"" :2001
        //, ""edano"" :0
        //, ""fixiteminfo"" :[{""inputtype"":31,""item"":""todokedeymd : 届出年月日"",""value"":""2024-06-28""},{""inputtype"":11,""item"":""titioyaatenano : 父親_宛名番号"",""value"":""""}]
        // } ]";

        //        req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //        var res = _service.SaveAll(req);

        //        var str = res.ToString();
        //    }



        //[TestMethod]
        ////⑦詳細画面削除テスト用
        //public void DeleteTest()
        //{
        //    //削除の場合
        //    var req = new DeleteRequest
        //    {
        //        userid = "0000000003",                            //ユーザーID

        //        delflg = false,                                    //削除フラグ　True：全ての詳細内容削除、False：選択中の履歷のみ削除
        //        bhsyosaimenyucd = "105",                          //母子詳細メニューコード
        //        bhsyosaitabcd = "1",                              //母子詳細タブコード
        //        atenano = "800000000000009",                      //宛名番号
        //        torokuno = 2001,                                  //登録番号
        //        torokunorenban = 0,                               //登録番号連番
        //        edano = 0,                                        //枝番
        //        kaisu = 4,                                        //履歴回数
        //    };

        //    var res = _service.Delete(req);

        //    var str = res.ToString();
        //}


        //[TestMethod]
        //////⑥詳細画面保存テスト用
        ///////107-1 00009テストデータ
        /////
        //public void SaveTest()
        //{
        //    var req = new SaveAllRequest
        //    {
        //        userid = "1",
        //        regsisyo = "1",
        //        token = "c3ynXVSMb65oDefej4nWpg==",
        //        checkflg = false,
        //    };


        //    var jsonstr = @"[{""bosikbn"":""1"",""bhsyosaimenyucd"":""101"",""bhsyosaitabcd"":""1"",""atenano"":""800000000000009"",""kaisu"":0,""freeiteminfo"":[{""inputtype"":31,""item"":""101901520001 : 出産予定日"",""value"":""2024-06-06""},{""inputtype"":1,""item"":""101901521001 : 届出時妊娠週数"",""value"":null},{""inputtype"":1,""item"":""101901522001 : 届出時妊娠月数"",""value"":null},{""inputtype"":26,""item"":""101901523001 : 届出者氏名"",""value"":null},{""inputtype"":41,""item"":""101901524001 : 届出者続柄"",""value"":null},{""inputtype"":41,""item"":""101901525001 : 届出時期（不詳含む）"",""value"":null},{""inputtype"":41,""item"":""101901527001 : 医師又は助産師の診断又は保健指導の有無"",""value"":null},{""inputtype"":70,""item"":""101901528001 : 医療機関コード"",""value"":null},{""inputtype"":70,""item"":""101901529001 : 医療機関名"",""value"":null},{""inputtype"":26,""item"":""200300001001 : 医療機関名（その他）"",""value"":null},{""inputtype"":71,""item"":""101901530001 : 医師氏名"",""value"":null},{""inputtype"":26,""item"":""200300002001 : 医師氏名（その他）"",""value"":null},{""inputtype"":26,""item"":""101901531001 : 職業"",""value"":null},{""inputtype"":42,""item"":""101901532001 : ハイリスク"",""value"":null},{""inputtype"":41,""item"":""101901533001 : 妊娠歴"",""value"":null},{""inputtype"":1,""item"":""101901534001 : 妊娠回数"",""value"":null},{""inputtype"":41,""item"":""101901535001 : 出産歴"",""value"":null},{""inputtype"":1,""item"":""101901536001 : 出産回数"",""value"":null},{""inputtype"":41,""item"":""101901537001 : 性病に関する健康診断の有無"",""value"":null},{""inputtype"":41,""item"":""101901538001 : 結核に関する健康診断の有無"",""value"":null},{""inputtype"":41,""item"":""101901539001 : 届出事由"",""value"":null},{""inputtype"":42,""item"":""101901540001 : 届出場所"",""value"":null},{""inputtype"":26,""item"":""101901542001 : 父親氏名"",""value"":null},{""inputtype"":41,""item"":""101901543001 : 多胎の有無"",""value"":null},{""inputtype"":26,""item"":""200300006001 : 精密検査実施機関名（その他）"",""value"":null},{""inputtype"":26,""item"":""200300007001 : 精密検査実施機関名（その他）"",""value"":null},{""inputtype"":26,""item"":""200300010001 : 精密検査実施機関名（その他）"",""value"":null}],""torokunorenban"":0,""torokuno"":""2001"",""edano"":0,""fixiteminfo"":[{""inputtype"":31,""item"":""todokedeymd : 届出年月日"",""value"":""2024-06-01""},{""inputtype"":11,""item"":""titioyaatenano : 父親_宛名番号"",""value"":null}]}]";

        //    req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

        //    var res = _service.SaveAll(req);

        //    var str = res.ToString();
        //}

        [TestMethod]
        ////⑥詳細画面保存テスト用
        /////107-1 00009テストデータ
        ///
        public void SaveTest()
        {
            var req = new SaveAllRequest
            {
                userid = "1",
                regsisyo = "1",
                token = "c3ynXVSMb65oDefej4nWpg==",
                checkflg = false,
            };


            var jsonstr = @"[{""bosikbn"":""1"",""bhsyosaimenyucd"":""110"",""bhsyosaitabcd"":""2"",""atenano"":""800000000000009"",""kaisu"":0,""freeiteminfo"":[{""inputtype"":31,""item"":""101903131001 : 受理日"",""value"":""2024-06-01""},{""inputtype"":70,""item"":""101903132001 : 医療機関コード"",""value"":""1""},{""inputtype"":26,""item"":""101903133001 : 医療機関名"",""value"":""1""},{""inputtype"":26,""item"":""200300009001 : 医療機関名（その他）"",""value"":""1""},{""inputtype"":26,""item"":""101903134001 : 医療機関住所"",""value"":""1""},{""inputtype"":26,""item"":""101903135001 : 医療機関方書"",""value"":""1""},{""inputtype"":31,""item"":""101903139001 : 決定日"",""value"":""2024-06-01""},{""inputtype"":41,""item"":""101903140001 : 承認区分"",""value"":""1""},{""inputtype"":27,""item"":""101903141001 : 支給不可理由"",""value"":""1""},{""inputtype"":1,""item"":""101903143001 : 助成金額（総額）"",""value"":35000}],""torokunorenban"":0,""torokuno"":2001,""edano"":1,""fixiteminfo"":[{""inputtype"":31,""item"":""sinseiymd : 申請日"",""value"":""2024-06-01""}],""jyoseilistinfo"":[{""no"":""1"",""joseikensyurui"":""1"",""jusinymd"":""2022-01-01"",""siharaikingaku"":11000,""joseikingaku"":6500},{""no"":""2"",""joseikensyurui"":""2"",""jusinymd"":""2022-01-02"",""siharaikingaku"":12000,""joseikingaku"":6500},{""no"":""3"",""joseikensyurui"":""3"",""jusinymd"":""2022-01-03"",""siharaikingaku"":13000,""joseikingaku"":6500},{""no"":""4"",""joseikensyurui"":""4"",""jusinymd"":""2022-01-04"",""siharaikingaku"":14000,""joseikingaku"":6500},{""no"":""5"",""joseikensyurui"":""5"",""jusinymd"":""2024-06-12"",""siharaikingaku"":5000,""joseikingaku"":5000},{""no"":""6"",""joseikensyurui"":""6"",""jusinymd"":""2024-06-12"",""siharaikingaku"":4000,""joseikingaku"":4000}]}]";

            req.saveinfo = JsonConvert.DeserializeObject<List<SaveRequest>>(jsonstr)!;

            var res = _service.SaveAll(req);

            var str = res.ToString();
        }
    }
}