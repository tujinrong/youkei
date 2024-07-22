// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理
// 　　　　　　サービス処理
// 作成日　　: 2024.02.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaNameService;
using static BCC.Affect.DataAccess.DaHanyoService;
using static BCC.Affect.DataAccess.DaStrPool;
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using Microsoft.VisualBasic;
using NPOI.SS.Formula.Functions;

namespace BCC.Affect.Service.AWBH00301G
{
    [DisplayName("妊産婦情報管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWBH00301G = "AWBH00301G";

        //妊産婦（フリー）項目テーブル
        public const string FREETABLE = "tt_bhnsfree";

        //母子保健事業コード
        public const string JIGYO_00001 = "00001";                                  //妊娠届出情報
        public const string JIGYO_00002 = "00002";     							    //妊娠届出アンケート
        public const string JIGYO_00003 = "00003";     							    //母子健康手帳交付情報
        public const string JIGYO_00004 = "00004";     							    //出産の状態に係る情報
        public const string JIGYO_00005 = "00005";     							    //妊婦健診結果
        public const string JIGYO_00006 = "00006";     							    //妊婦健診費用助成
        public const string JIGYO_00007 = "00007";     							    //妊産婦歯科健診結果
        public const string JIGYO_00008 = "00008";     							    //妊産婦歯科精健結果
        public const string JIGYO_00009 = "00009";     							    //妊婦精健結果
        public const string JIGYO_00010 = "00010";     							    //産婦健診結果
        public const string JIGYO_00011 = "00011";     							    //産婦健診費用助成
        public const string JIGYO_00012 = "00012";     							    //産婦精密健診結果
        public const string JIGYO_00013 = "00013";     							    //産後ケア事業情報
        public const string JIGYO_00032 = "00032";									//妊産婦歯科健診費用助成

        //固定テーブルパターン
        public const string PATTERN_1 = "1";                                        //宛名番号(atenano)、登録番号(torokuno)
        public const string PATTERN_2 = "2";                                        //宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
        public const string PATTERN_3 = "3";                                        //宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
        public const string PATTERN_4 = "4";                                        //宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
        public const string PATTERN_5 = "5";                                        //宛名番号(atenano)、登録番号(torokuno)、枝番(edano)

        //定数定義
        private const int ORDERBYCOUNT = 14;                                        //検索一覧の列数（非表示も含む）

        public static Dictionary<string, string> FixTblDic = new Dictionary<string, string>();          //固定テーブル名
        public static Dictionary<string, string> PatternDic = new Dictionary<string, string>();         //固定テーブルパターン
        public static Dictionary<string, string> FixItemDic = new Dictionary<string, string>();         //固定項目情報

        static Service()
        {
            var db = new DaDbContext();
            FixTblDic = GetBosiHanyokbnInfo(db, 母子種類._1, 汎用区分._2, null);                 //固定テーブル名（汎用区分２）辞書
            PatternDic = GetBosiHanyokbnInfo(db, 母子種類._1, 汎用区分._2, 辞書設定区分._P);     //固定テーブルパターン辞書
            FixItemDic = GetBosiHanyokbnInfo(db, 母子種類._1, 汎用区分._3, null);                //必須フラグ／固定項目ID／固定項目表示名称／入力タイプ／桁数（整数部分）／並びシーケンス（汎用区分３）辞書
        }

        //Todo：母子種類とボタン文字色は一時利用、後でDataAccess--Generated--DaCodeConstに移行する予定
        ///<summary>
        ///辞書設定区分
        ///</summary>
        public class 辞書設定区分
        {
            ///<summary>固定テーブルパターン</summary>
            public const string _P = "P";
            ///<summary>乳幼児健診コード</summary>
            public const string _N = "N";
        }

        ///<summary>
        ///汎用区分
        ///</summary>
        public class 汎用区分
        {
            ///<summary>汎用区分1</summary>
            public const string _1 = "1";
            ///<summary>汎用区分2</summary>
            public const string _2 = "2";
            ///<summary>汎用区分3</summary>
            public const string _3 = "3";
        }

        ///<summary>
        ///母子詳細メニューボタン文字色
        ///</summary>
        public class ボタン文字色
        {
            ///<summary>無色</summary>
            public const string _0 = "0";
            ///<summary>水色</summary>
            public const string _1 = "1";
        }

        [DisplayName("妊産婦画面検索処理(検索画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("妊産婦詳細画面検索処理(妊産婦一覧)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("妊産婦フリー項目検索処理")]
        public SearchSyosaiResponse SearchSyosai(SearchSyosaiRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSyosai(db, req);
            });
        }

        [DisplayName("医療機関検索処理")]
        public SearchKikanNMResponse SearchKikanNM(SearchKikanNMRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchKikanNM(db, req);
            });
        }

        [DisplayName("医師検索処理")]
        public SearchIshiNMResponse SearchIshiNM(SearchIshiNMRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchIshiNM(db, req);
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse SaveAll(SaveAllRequest reqall)
        {
            var result = new CommonResponse();

            return Transction(reqall, (DaDbContext db) =>
            {
                foreach (SaveRequest req in reqall.saveinfo)
                {

                    req.userid = reqall.userid;
                    req.regsisyo = reqall.regsisyo;
                    req.token = reqall.token;
                    req.checkflg = reqall.checkflg;

                    result = Save(db, req, result);
                    if (result.returncode != EnumServiceResult.OK) { return result; }   //異常返し
                }
                //正常返し
                return result;
            });
        }

        [DisplayName("削除処理")]
        public CommonResponse Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return Delete(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        /// ①妊産婦画面検索処理(検索画面)
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //特別処理（Distinctで検索するエラー発生しないように処理する）
            req.orderby = ProcOrderBy(req.orderby, ORDERBYCOUNT);

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック（E004006：{0}は{1}に存在しません。）
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) { return res; }  //異常返し
            }

            //個人番号
            if (!string.IsNullOrEmpty(req.personalno))
            {
                //Page個人番号復号化
                req.SetPersonalno();

                //DB個人番号AES暗号化
                var dbpersonalno = DaEncryptUtil.AesEncrypt(req.personalno);

                if (!db.tt_afatena.SELECT.WHERE.ByFilter("personalno = @personalno", dbpersonalno).Exists())
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "検索対象", "住民基本情報");
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }
            }

            //-------------------------------------------------------------
            //２.条件設定
            //-------------------------------------------------------------
            //固定の検索条件
            var fixedCondition = Converter.GetFixedCondition(req);

            //詳細の検索条件
            var condition = CmSearchUtil.GetSearchJyoken(db, AWBH00301G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);

            //総件数
            var total = GetResultTotalCount(db, req.bosikbn, condition, req.orderby, true);

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //検索結果
            var result = DaFreeQuery.GetBosiQuery(db, req.bosikbn, condition, req.orderby, true);

            //検索結果一覧
            var pageData = result.Data;

            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //メニュー名称文字列を取得
            res.syosaititle = GetMenuNameStr(db, req.bosikbn);

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.kekkalist = Wraper.GetNinSanPuVMList(db, pageData.Rows, req.bosikbn, alertviewflg);

            //ページャー設定
            res.SetPageInfo(total, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// ②③妊産婦詳細画面検索処理(妊産婦一覧)
        /// </summary>
        private SearchDetailResponse SearchDetail(DaDbContext db, SearchDetailRequest req)
        {
            var res = new SearchDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の住民情報を取得
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);
            if (atenadto == null) { throw new AiExclusiveException(); }

            //B、メニュー名称リストを取得
            var menudtl = db.tm_bhkksyosaimenyu.SELECT.WHERE.ByKey(req.bosikbn).GetDtoList().OrderBy(e => e.orderseq);

            var bhsyosaimenyucd = string.Empty;
            //todo:母子テーブル定義最新化
            if (menudtl != null)
            {
                var menudto = menudtl.FirstOrDefault();
                if (menudto != null) { bhsyosaimenyucd = menudto.bhsyosaimenyucd; }
            }

            var bhsyosaitabcd = string.Empty;
            var jigyocd = string.Empty;


            //C、該当メニュー項目のタブ名称リストを取得
            var tabdtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(req.bosikbn, bhsyosaimenyucd).GetDtoList().OrderBy(e => e.orderseq);
            if (tabdtl == null)
            {
                throw new AiExclusiveException();
            }
            else
            {
                var tabdto = tabdtl.FirstOrDefault();
                if (tabdto != null)
                {
                    bhsyosaitabcd = tabdto.bhsyosaitabcd;   //母子保健詳細タブコード
                    jigyocd = tabdto.jigyocd;               //母子保健事業コード
                }
            }

            //D、履歴回数リストを取得
            var kaisudtl = GetKaisuDtl(db, FREETABLE, jigyocd, req.atenano, req.torokuno, 0, 0, 0);

            //データ存在しない場合の登録番号連番／枝番／回数の初期値設定（パターン１の場合は0で固定、その以外の場合は1で設定する）
            var kaisu = (PatternDic[jigyocd] == PATTERN_1 ? 0 : 1);

            var dataexist = false;

            if (kaisudtl.Rows.Count > 0)
            {
                kaisu = CInt(kaisudtl.Compute("MIN(kaisu)", "true"));
                dataexist = true;
            }

            //E、妊産婦フリー項目を取得する
            var freeMstDtl = db.tm_bhkkfreeitem.SELECT.WHERE.ByKey(req.bosikbn, jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();              //表示順ソート：並び順

            //F、妊産婦フリーキー項目リストを用意する
            var keyList = GetKeyList(req, freeMstDtl, PatternDic[jigyocd], kaisu);

            //全項目データ
            var dataDtl = db.tt_bhnsfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //G、登録番号リストを再設定（必要ないかも）
            res.torokuno = req.torokuno;

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            res.headerinfo = Wraper.GetHeaderVM(db, atenadto, alertviewflg);                                //妊産婦ヘッダー情報
            res.menulist = Wraper.GetMenuInfoVMList(db, menudtl!, req.bosikbn, req.atenano, req.torokuno);  //メニュー名称リスト
            res.tablist = Wraper.GetTabInfoVMList(db, tabdtl!, req.atenano, req.torokuno);                  //タブ名称リスト

            if (!dataexist)
            {
                //存在しない場合
                res.maxkaisu = 0;                                                   //最大履歴回数を0で設定
                res.kaisulist = new List<KaisuInfoVM>();                            //履歴回数リスト
            }
            else
            {
                res.maxkaisu = CInt(kaisudtl.Compute("MAX(kaisu)", "true"));        //最大履歴回数
                res.kaisulist = Wraper.GetKaisuVMList(kaisudtl);                    //履歴回数リスト
            }

            //画面フリー項目設定
            //TODO：テストデータがないため、今概要設計書通りなっている、詳細成人保健と同じ取得方法にする予定
            res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊産婦グループID)).ToString());
            res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊産婦グループID2)).ToString());
            //res.grouplist1 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);
            //res.grouplist2 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWBH00301G, 拡_予約_保健指導業務区分._02);

            //固定項目一覧
            res.fixitemlist = GetFixItemList(db, jigyocd, req.atenano, req.torokuno, kaisu, FixTblDic[jigyocd], FixItemDic[jigyocd]);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWBH00301G, patternno);

            res.limitkaisu = GetLimitKaisu(db, jigyocd);

            //正常返し
            return res;
        }

        /// <summary>
        /// ④妊産婦フリー項目検索処理（メニュー選択／タブ選択／履歴回数選択の場合）
        /// ④新規ボタンを押下
        /// </summary>
        private SearchSyosaiResponse SearchSyosai(DaDbContext db, SearchSyosaiRequest req)
        {
            var res = new SearchSyosaiResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //B、データ操作区分取得
            var kbn = GetKBN(db, jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, req.kaisu);

            //C、該当宛名番号／メニュー項目のタブリストを取得
            var tabdtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(req.bosikbn, req.bhsyosaimenyucd).GetDtoList().OrderBy(e => e.orderseq);

            if (tabdtl == null) { throw new AiExclusiveException(); }

            //D、妊産婦フリー項目を取得する
            var freeMstDtl = db.tm_bhkkfreeitem.SELECT.WHERE.ByKey(req.bosikbn, jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();              //表示順ソート：並び順

            if (jigyocd.Equals(JIGYO_00005) && (kbn == EnumActionType.Update))
            {
                //妊婦健診結果(00005)の更新モードの場合：受診回数は利用回数リストに存在しないフリー項目は画面上表示しない。
                freeMstDtl = ProcRiyokaisu(freeMstDtl, req.kaisu);
            }

            //E、登録番号リストを再設定（必要ないかも）
            res.torokuno = req.torokuno;

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.tablist = Wraper.GetTabInfoVMList(db, tabdtl!, req.atenano, req.torokuno);        //タブ名称リスト

            //F、履歴回数リストを取得
            var kaisudtl = GetKaisuDtl(db, FREETABLE, jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, req.kaisu);

            var minkaisu = 0;
            var fixkaisu = 0;
            var dataexist = false;

            if (kaisudtl.Rows.Count > 0)
            {
                minkaisu = CInt(kaisudtl.Compute("MIN(kaisu)", "true"));
                dataexist = true;
            }

            if (!dataexist)
            {
                //存在しない場合
                res.maxkaisu = 0;                                                   //最大履歴回数を0で設定
                res.kaisulist = new List<KaisuInfoVM>();                            //登録番号連番リスト／申請枝番リスト／枝番リスト／履歴回数リスト
            }
            else
            {
                res.maxkaisu = CInt(kaisudtl.Compute("MAX(kaisu)", "true"));        //最大履歴回数
                res.kaisulist = Wraper.GetKaisuVMList(kaisudtl);                    //登録番号連番リスト／申請枝番リスト／枝番リスト／履歴回数リスト
            }

            //新規の場合
            if (kbn == EnumActionType.Insert && !PatternDic[jigyocd].Equals(PATTERN_1))
            {
                var maxkaisu = 0;

                if (ChkInsertFlag(PatternDic[jigyocd], req.torokunorenban, req.edano, req.kaisu))
                {
                    //自動採番必要な場合
                    maxkaisu = GetNewkaisu(db, jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, req.kaisu);
                }
                else
                {
                    //自動採番ではない場合
                    maxkaisu = GetMaxKaisu(req, PatternDic[jigyocd]);
                }

                if (maxkaisu > res.maxkaisu)
                {
                    var vm = new KaisuInfoVM();

                    vm.kaisu = maxkaisu;
                    res.maxkaisu = maxkaisu;                                        //最大履歴回数
                    res.kaisulist.Add(vm);                                          //履歴回数リスト
                }
            }

            //G、妊産婦フリーキー項目リストを用意する
            var keyList = GetKeyList(req, freeMstDtl, PatternDic[jigyocd], minkaisu);

            //全項目データ
            var dataDtl = db.tt_bhnsfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWBH00301G, 拡_予約_保健指導業務区分._02);

            //固定項目一覧
            if (req.torokunorenban == 0 && req.edano == 0 && CInt(req.kaisu) == 0) 
            {
                //メニュー側クリックまたは詳細タブクリックする場合
                fixkaisu = minkaisu;
            }
            else
            {
                //回数タブをクリックする場合
                fixkaisu = GetFixKaisu(PatternDic[jigyocd], req.torokunorenban, req.edano, req.kaisu);
            }

            res.fixitemlist = GetFixItemList(db, jigyocd, req.atenano, req.torokuno, fixkaisu, FixTblDic[jigyocd], FixItemDic[jigyocd]);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWBH00301G, patternno);

            res.limitkaisu = GetLimitKaisu(db, jigyocd);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑤医療機関検索処理
        /// </summary>
        private SearchKikanNMResponse SearchKikanNM(DaDbContext db, SearchKikanNMRequest req)
        {
            var res = new SearchKikanNMResponse();

            var cdnm = CmLogicUtil.GetFreeItemCdNm(db, req.kikancd, Enumフリーマスタ分類.母子, Enum入力タイプ.医療機関, null, null, null, Enum名称区分.名称, AWBH00301G, null);
            if (!string.IsNullOrEmpty(cdnm)) { res.KikanNM = GetNM(cdnm); }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑥医師検索処理
        /// </summary>
        private SearchIshiNMResponse SearchIshiNM(DaDbContext db, SearchIshiNMRequest req)
        {
            var res = new SearchIshiNMResponse();

            var dto = db.tm_afstaff.SELECT.WHERE.ByKey(req.staffid).GetDto();

            //医師／歯科医師の場合は名称を取得する
            if (dto != null && !dto.stopflg && (dto.syokusyu.Equals(職種._01) || dto.syokusyu.Equals(職種._02))) { res.ishinm = dto.staffsimei; }
            else { res.ishinm = string.Empty; }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑦保存処理(詳細画面--業務毎)
        /// </summary>
        private CommonResponse Save(DaDbContext db, SaveRequest req, CommonResponse res)
        {
            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //Todo：母子データリストコードを取得（必要ないと思う、詳細削除する可能性高い）
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //データ操作区分取得
            var kbn = GetKBN(db, jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, req.kaisu);

            //新規の場合（最新登録番号連番／受診回数／申請枝番／枝番を取得）
            if ((kbn == EnumActionType.Insert) && ChkInsertFlag(PatternDic[jigyocd], req.torokunorenban, req.edano, req.kaisu))
            {
                req = GetNewReq(db, req, jigyocd);
            }

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, jigyocd, kbn, res)) { return res; }    //異常返し

                //正常返し
                return res;
            }

            //フリー項目一覧
            var oldfreedtl = new List<tt_bhnsfreeDto>();                 //妊産婦（フリー）項目テーブル（フリーテーブル）

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //フリー項目一覧情報を取得
                oldfreedtl = db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newfreedtl = new List<tt_bhnsfreeDto>();                //妊産婦（フリー）項目テーブル（フリーテーブル）

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_bhnsfreeDto();
                    var row = req.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //フリー項目一覧
                foreach (var dt in req.freeiteminfo)
                {
                    var newfreedto = new tt_bhnsfreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1, jigyocd);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                //妊産婦（フリー）項目テーブル
                db.tt_bhnsfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).Execute();
                db.tt_bhnsfree.INSERT.Execute(newfreedtl);      //妊産婦（フリー）項目テーブル

                //該当業務の固定テーブルを登録処理
                if (!FixTblProc(db, req, jigyocd, kbn)) { return res; }     //異常返し
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_bhnsfree.UPDATE.Execute(newfreedtl);       //妊産婦（フリー）項目テーブル

                //該当業務の固定テーブルを更新処理
                if (!FixTblProc(db, req, jigyocd, kbn)) { return res; }     //異常返し
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            SaveJyosei(db, req);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑧削除処理(詳細画面)
        /// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req)
        {
            var res = new CommonResponse();

            //母子データリストコードを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名テーブル
            if (!Check(db, req, jigyocd, res)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.妊産婦（フリー）項目テーブルデータ削除処理
            //-------------------------------------------------------------
            //妊産婦（フリー）項目テーブル
            if (req.delflg)
            {
                //全ての詳細内容削除の場合
                db.tt_bhnsfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno).Execute();
            }
            else
            {
                //選択中の履歷のみ削除の場合
                db.tt_bhnsfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).Execute();
            }

            //-------------------------------------------------------------
            //３.固定テーブルデータ削除処理
            //-------------------------------------------------------------
            //該当業務の固定テーブルの削除処理
            if (!FixTblDel(db, req, jigyocd)) { return res; }   //異常返し

            //正常返し
            return res;
        }

        //************************************************************** サブ処理 **************************************************************
        /// <summary>
        ///妊産婦フリーキー項目リストを用意する
        /// </summary>
        private static List<object[]> GetKeyList(SearchDetailRequest req, List<tm_bhkkfreeitemDto> freeMstDtl, string pattern, int kaisu)
        {
            var keyList = new List<object[]>();

            foreach (var item in freeMstDtl)
            {
                //このインターフェースは検索画面から詳細画面へ遷移した場合のみ利用する為、
                //母子保健詳細メニューマスタの妊産婦の並びシーケンス一番目の母子保健事業コードを初期表示する
                switch (pattern)
                {
                    case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, CStr(kaisu), item.itemcd });
                        break;
                    case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                        //TODO：zhang20240617
                        //keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, kaisu, item.itemcd });
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, CStr(kaisu).PadLeft(2, '0'), item.itemcd });
                        break;
                    case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, kaisu, 0, "0", item.itemcd });
                        break;
                    case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                    case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, kaisu, "0", item.itemcd });
                        break;
                    default:
                        break;
                }
            }

            return keyList;
        }

        //************************************************************** サブ処理 **************************************************************
        /// <summary>
        ///妊産婦フリーキー項目リストを用意する
        /// </summary>
        private static List<object[]> GetKeyList(SearchSyosaiRequest req, List<tm_bhkkfreeitemDto> freeMstDtl, string pattern, int minkaisu)
        {
            var keyList = new List<object[]>();

            var refkaisu = 0;

            if (req.torokunorenban == 0 && req.edano == 0 && CInt(req.kaisu) == 0)
            {
                //メニュー側クリックまたは詳細タブクリックする場合
                refkaisu = minkaisu;
            }
            else
            {
                // 回数タブをクリックする場合
                switch (pattern)
                {
                    case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                        refkaisu = req.kaisu;
                        break;
                    case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                        refkaisu = req.torokunorenban;
                        break;
                    case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                    case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                        refkaisu = req.edano;
                        break;
                    default:
                        break;
                }
            }

            foreach (var item in freeMstDtl)
            {
                //このインターフェースは検索画面から詳細画面へ遷移した場合のみ利用する為、
                //母子保健詳細メニューマスタの妊産婦の並びシーケンス一番目の母子保健事業コードを初期表示する
                switch (pattern)
                {
                    case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, CStr(refkaisu), item.itemcd });
                        break;
                    case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                        //TODO：zhang20240617
                        //keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, kaisu, item.itemcd });
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, 0, CStr(refkaisu).PadLeft(2, '0'), item.itemcd });
                        break;
                    case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, refkaisu, 0, "0", item.itemcd });
                        break;
                    case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                    case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                        keyList.Add(new object[] { item.jigyocd, req.atenano, req.torokuno, 0, refkaisu, "0", item.itemcd });
                        break;
                    default:
                        break;
                }
            }

            return keyList;
        }

        /// <summary>
        ///該当業務の固定テーブルを登録処理
        /// </summary>
        private static bool FixTblProc(DaDbContext db, SaveRequest req, string jigyocd, EnumActionType? kbn)
        {
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める
            switch (jigyocd)
            {
                case JIGYO_00001:       // 妊娠届出情報（届出情報 101-1 -- 00001）
                    var freedtl_101 = new List<tt_bhnsninsintodokedeDto>();                     //妊娠届出（固定）テーブル
                    var dto_101 = new tt_bhnsninsintodokedeDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        todokedeymd = CStr(GetFixValue(req.fixiteminfo, "todokedeymd")),        //届出年月日
                        titioyaatenano = CStr(GetFixValue(req.fixiteminfo, "titioyaatenano")),  //父親_宛名番号
                    };
                    freedtl_101.Add(dto_101);
                    if (db.tt_bhnsninsintodokede.SELECT.WHERE.ByKey(req.atenano, req.torokuno).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninsintodokede.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute();
                            db.tt_bhnsninsintodokede.INSERT.Execute(freedtl_101);
                        }
                        else { db.tt_bhnsninsintodokede.UPDATE.Execute(freedtl_101); }          //更新の場合
                    }
                    else { db.tt_bhnsninsintodokede.INSERT.Execute(freedtl_101); }              //存在しない場合

                    break;

                case JIGYO_00002:       // 妊娠届出情報（アンケート 101-2 -- 00002）
                    var freedtl_102 = new List<tt_bhnsninsintodokedeanketoDto>();               //妊娠届出アンケート（固定）テーブル
                    var dto_102 = new tt_bhnsninsintodokedeanketoDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                    };
                    freedtl_102.Add(dto_102);
                    if (db.tt_bhnsninsintodokedeanketo.SELECT.WHERE.ByKey(req.atenano, req.torokuno).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninsintodokedeanketo.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute();
                            db.tt_bhnsninsintodokedeanketo.INSERT.Execute(freedtl_102);
                        }
                        else { db.tt_bhnsninsintodokedeanketo.UPDATE.Execute(freedtl_102); }    //更新の場合
                    }
                    else { db.tt_bhnsninsintodokedeanketo.INSERT.Execute(freedtl_102); }        //存在しない場合
                    break;

                case JIGYO_00003:       // 母子健康手帳交付情報（103-1 -- 00003)
                    var freedtl_103 = new List<tt_bhnsbosikenkotetyokofuDto>();                 //母子健康手帳交付（固定）テーブル
                    var dto_103 = new tt_bhnsbosikenkotetyokofuDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        torokunorenban = req.torokunorenban,                                    //登録番号連番
                        bositetyokofubi = CStr(GetFixValue(req.fixiteminfo, "bositetyokofubi")),//母子健康手帳交付日
                        bositetyokofuno = CStr(GetFixValue(req.fixiteminfo, "bositetyokofuno")),//母子健康手帳交付番号
                        bositetyokofunoedano = CInt(GetFixValue(req.fixiteminfo, "bositetyokofunoedano")),  //母子健康手帳交付番号枝番
                    };
                    freedtl_103.Add(dto_103);
                    if (db.tt_bhnsbosikenkotetyokofu.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsbosikenkotetyokofu.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Execute();
                            db.tt_bhnsbosikenkotetyokofu.INSERT.Execute(freedtl_103);
                        }
                        else { db.tt_bhnsbosikenkotetyokofu.UPDATE.Execute(freedtl_103); }      //更新の場合
                    }
                    else { db.tt_bhnsbosikenkotetyokofu.INSERT.Execute(freedtl_103); }          //存在しない場合
                    break;

                case JIGYO_00004:       // 出産の状態に係る情報（104-1 -- 00004)
                    var freedtl_104 = new List<tt_bhnssyussanjotaiDto>();                       //出産の状態に係る（固定）テーブル
                    var dto_104 = new tt_bhnssyussanjotaiDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        torokunorenban = req.torokunorenban,                                    //登録番号連番
                    };
                    freedtl_104.Add(dto_104);
                    if (db.tt_bhnssyussanjotai.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssyussanjotai.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Execute();
                            db.tt_bhnssyussanjotai.INSERT.Execute(freedtl_104);
                        }
                        else { db.tt_bhnssyussanjotai.UPDATE.Execute(freedtl_104); }            //更新の場合
                    }
                    else { db.tt_bhnssyussanjotai.INSERT.Execute(freedtl_104); }                //存在しない場合
                    break;

                case JIGYO_00005:       // 妊婦健診結果（105-1 -- 00005）
                    var freedtl_105 = new List<tt_bhnsninpukensinkekkaDto>();                   //妊婦健診結果（固定）テーブル
                    var dto_105 = new tt_bhnsninpukensinkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        jusinkaisu = skaisu,                                                    //受診回数（2桁文字列tm_afhanyo(1003-2)）
                        jusinymd = CStr(GetFixValue(req.fixiteminfo, "jusinymd")),              //受診日
                        jusinkbn = CStr(GetFixValue(req.fixiteminfo, "jusinkbn")),              //受診区分
                    };
                    freedtl_105.Add(dto_105);
                    if (db.tt_bhnsninpukensinkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, skaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, skaisu).Execute();
                            db.tt_bhnsninpukensinkekka.INSERT.Execute(freedtl_105);
                        }
                        else { db.tt_bhnsninpukensinkekka.UPDATE.Execute(freedtl_105); }        //更新の場合
                    }
                    else { db.tt_bhnsninpukensinkekka.INSERT.Execute(freedtl_105); }            //存在しない場合
                    break;

                case JIGYO_00006:       // 妊婦健診費用助成（105-2 -- 00006）
                    var freedtl_106 = new List<tt_bhnsninpukensinhiyojoseiDto>();               //妊婦健診費用助成（固定）テーブル
                    var dto_106 = new tt_bhnsninpukensinhiyojoseiDto()
                    {
                        jigyocd = jigyocd,                                                      //母子保健事業コード
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        sinseiedano = req.edano,                                                //枝番
                        sinseiymd = CStr(GetFixValue(req.fixiteminfo, "sinseiymd")),            //申請日
                    };
                    freedtl_106.Add(dto_106);
                    if (db.tt_bhnsninpukensinhiyojosei.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnsninpukensinhiyojosei.INSERT.Execute(freedtl_106);
                        }
                        else { db.tt_bhnsninpukensinhiyojosei.UPDATE.Execute(freedtl_106); }    //更新の場合
                    }
                    else { db.tt_bhnsninpukensinhiyojosei.INSERT.Execute(freedtl_106); }        //存在しない場合
                    break;

                case JIGYO_00009:       // 妊婦精健結果（107-1 -- 00009)
                    var freedtl_107 = new List<tt_bhnsninpuseikenkekkaDto>();                   //妊婦精健結果（固定）テーブル
                    var dto_107 = new tt_bhnsninpuseikenkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        seimitukensajissiymd = CStr(GetFixValue(req.fixiteminfo, "seimitukensajissiymd")),  //精密検査実施日
                    };
                    freedtl_107.Add(dto_107);
                    if (db.tt_bhnsninpuseikenkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnsninpuseikenkekka.INSERT.Execute(freedtl_107);
                        }
                        else { db.tt_bhnsninpuseikenkekka.UPDATE.Execute(freedtl_107); }        //更新の場合
                    }
                    else { db.tt_bhnsninpuseikenkekka.INSERT.Execute(freedtl_107); }            //存在しない場合
                    break;

                case JIGYO_00007:       // 妊産婦歯科健診結果（108-1 -- 00007）
                    var freedtl_108 = new List<tt_bhnssikakensinkekkaDto>();                    //妊産婦歯科健診結果（固定）テーブル
                    var dto_108 = new tt_bhnssikakensinkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        ninsanpusikajusinymd = CStr(GetFixValue(req.fixiteminfo, "ninsanpusikajusinymd")),  //妊産婦歯科健診受診日
                        ninsanpukbn = CStr(GetFixValue(req.fixiteminfo, "ninsanpukbn")),        //妊産婦区分
                    };
                    freedtl_108.Add(dto_108);
                    if (db.tt_bhnssikakensinkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssikakensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssikakensinkekka.INSERT.Execute(freedtl_108);
                        }
                        else { db.tt_bhnssikakensinkekka.UPDATE.Execute(freedtl_108); }         //更新の場合
                    }
                    else { db.tt_bhnssikakensinkekka.INSERT.Execute(freedtl_108); }             //存在しない場合
                    break;

                case JIGYO_00032:       //妊婦健診費用助成（108-2 -- 00032）
                    var freedtl_114 = new List<tt_bhnsninpukensinhiyojoseiDto>();               //妊婦健診費用助成（固定）テーブル
                    var dto_114 = new tt_bhnsninpukensinhiyojoseiDto()
                    {
                        jigyocd = jigyocd,                                                      //母子保健事業コード
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        sinseiedano = req.edano,                                                //申請枝番
                        sinseiymd = CStr(GetFixValue(req.fixiteminfo, "sinseiymd")),            //申請日
                    };
                    freedtl_114.Add(dto_114);
                    if (db.tt_bhnsninpukensinhiyojosei.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnsninpukensinhiyojosei.INSERT.Execute(freedtl_114);
                        }
                        else { db.tt_bhnsninpukensinhiyojosei.UPDATE.Execute(freedtl_114); }    //更新の場合
                    }
                    else { db.tt_bhnsninpukensinhiyojosei.INSERT.Execute(freedtl_114); }        //存在しない場合
                    break;

                case JIGYO_00008:       // 妊産婦歯科精健結果（109-1 -- 00009)
                    var freedtl_109 = new List<tt_bhnssikaseikenkekkaDto>();                    //妊産婦歯科精健結果（固定）テーブル
                    var dto_109 = new tt_bhnssikaseikenkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        seimitukensajissiymd = CStr(GetFixValue(req.fixiteminfo, "seimitukensajissiymd")),  //精密検査実施日
                    };
                    freedtl_109.Add(dto_109);
                    if (db.tt_bhnssikaseikenkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssikaseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssikaseikenkekka.INSERT.Execute(freedtl_109);
                        }
                        else { db.tt_bhnssikaseikenkekka.UPDATE.Execute(freedtl_109); }         //更新の場合
                    }
                    else { db.tt_bhnssikaseikenkekka.INSERT.Execute(freedtl_109); }             //存在しない場合
                    break;

                case JIGYO_00010:       //産婦健診結果（110-1 -- 00010）
                    var freedtl_110 = new List<tt_bhnssanpukensinkekkaDto>();                   //産婦健診結果（固定）テーブル
                    var dto_110 = new tt_bhnssanpukensinkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        jusinymd = CStr(GetFixValue(req.fixiteminfo, "jusinymd")),              //受診日
                        kensinsyubetu = CStr(GetFixValue(req.fixiteminfo, "kensinsyubetu")),    //健診種別
                    };
                    freedtl_110.Add(dto_110);
                    if (db.tt_bhnssanpukensinkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssanpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssanpukensinkekka.INSERT.Execute(freedtl_110);
                        }
                        else { db.tt_bhnssanpukensinkekka.UPDATE.Execute(freedtl_110); }        //更新の場合
                    }
                    else { db.tt_bhnssanpukensinkekka.INSERT.Execute(freedtl_110); }            //存在しない場合
                    break;

                case JIGYO_00011:       //妊婦健診費用助成（110-2 -- 00011）
                    var freedtl_111 = new List<tt_bhnssanpukensinhiyojoseiDto>();               //産婦健診費用助成（固定）テーブル
                    var dto_111 = new tt_bhnssanpukensinhiyojoseiDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        sinseiedano = req.edano,                                                //申請枝番
                        sinseiymd = CStr(GetFixValue(req.fixiteminfo, "sinseiymd")),            //申請日
                    };
                    freedtl_111.Add(dto_111);
                    if (db.tt_bhnssanpukensinhiyojosei.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssanpukensinhiyojosei.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssanpukensinhiyojosei.INSERT.Execute(freedtl_111);
                        }
                        else { db.tt_bhnssanpukensinhiyojosei.UPDATE.Execute(freedtl_111); }    //更新の場合
                    }
                    else { db.tt_bhnssanpukensinhiyojosei.INSERT.Execute(freedtl_111); }        //存在しない場合
                    break;

                case JIGYO_00012:       // 産婦精密健診結果（112-1 -- 00012)
                    var freedtl_112 = new List<tt_bhnssanpuseikenkekkaDto>();                   //産婦精密健診結果（固定）テーブル
                    var dto_112 = new tt_bhnssanpuseikenkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        seimitukensajissiymd = CStr(GetFixValue(req.fixiteminfo, "seimitukensajissiymd")),  //精密検査実施日
                    };
                    freedtl_112.Add(dto_112);
                    if (db.tt_bhnssanpuseikenkekka.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssanpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssanpuseikenkekka.INSERT.Execute(freedtl_112);
                        }
                        else { db.tt_bhnssanpuseikenkekka.UPDATE.Execute(freedtl_112); }        //更新の場合
                    }
                    else { db.tt_bhnssanpuseikenkekka.INSERT.Execute(freedtl_112); }            //存在しない場合
                    break;

                case JIGYO_00013:       // 産後ケア事業情報（113-1 -- 00013)
                    var freedtl_113 = new List<tt_bhnssangocarejigyoDto>();                     //産後ケア事業（固定）テーブル
                    var dto_113 = new tt_bhnssangocarejigyoDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        torokuno = req.torokuno,                                                //登録番号
                        edano = req.edano,                                                      //枝番
                        sinseiymd = CStr(GetFixValue(req.fixiteminfo, "sinseiymd")),            //精密検査実施日
                    };
                    freedtl_113.Add(dto_113);
                    if (db.tt_bhnssangocarejigyo.SELECT.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnssangocarejigyo.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
                            db.tt_bhnssangocarejigyo.INSERT.Execute(freedtl_113);
                        }
                        else { db.tt_bhnssangocarejigyo.UPDATE.Execute(freedtl_113); }          //更新の場合
                    }
                    else { db.tt_bhnssangocarejigyo.INSERT.Execute(freedtl_113); }              //存在しない場合
                    break;

                default:
                    break;
            }

            return true;
        }

        /// <summary>
        ///該当業務の固定テーブルを削除処理
        /// </summary>
        private static bool FixTblDel(DaDbContext db, DeleteRequest req, string jigyocd)
        {
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める
            switch (jigyocd)
            {
                case JIGYO_00001:       // 妊娠届出情報（届出情報 101-1 -- 00001）「妊娠届出（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninsintodokede.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                   //全て
                    else { db.tt_bhnsninsintodokede.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                              //選択中
                    break;
                case JIGYO_00002:       // 妊娠届出情報（アンケート 101-2 -- 00002）「妊娠届出アンケート（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninsintodokedeanketo.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }             //全て
                    else { db.tt_bhnsninsintodokedeanketo.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }             	        //選択中
                    break;
                case JIGYO_00003:       // 母子健康手帳交付情報（103-1 -- 00003)「母子健康手帳交付（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsbosikenkotetyokofu.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }               //全て
                    else { db.tt_bhnsbosikenkotetyokofu.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Execute(); }      //選択中
                    break;
                case JIGYO_00004:       // 出産の状態に係る情報（104-1 -- 00004)「出産の状態に係る（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssyussanjotai.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                     //全て
                    else { db.tt_bhnssyussanjotai.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.torokunorenban).Execute(); }	        //選択中
                    break;
                case JIGYO_00005:       // 妊婦健診結果（105-1 -- 00005）「妊婦健診結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                 //全て
                    else { db.tt_bhnsninpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, skaisu).Execute(); }		            //選択中
                    break;
                case JIGYO_00006:       // 妊婦健診費用助成（105-2 -- 00006）「妊婦健診費用助成（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno).Execute(); }    //全て
                    else { db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Execute(); }    //選択中
                    break;
                case JIGYO_00009:       // 妊婦精健結果（107-1 -- 00009)「妊婦精健結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                 //全て
                    else { db.tt_bhnsninpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;
                case JIGYO_00007:       // 妊産婦歯科健診結果（108-1 -- 00007）「妊産婦歯科健診結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssikakensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                  //全て
                    else { db.tt_bhnssikakensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;
                case JIGYO_00032:       //妊婦健診費用助成（108-2 -- 00032）「妊婦健診費用助成（固定）テーブル」
                    if (req.delflg) { db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno).Execute(); }    //全て
                    else { db.tt_bhnsninpukensinhiyojosei.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Execute(); }    //選択中
                    break;
                case JIGYO_00008:       // 妊産婦歯科精健結果（109-1 -- 00008)「妊産婦歯科精健結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssikaseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                  //全て
                    else { db.tt_bhnssikaseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;
                case JIGYO_00010:       //産婦健診結果（110-1 -- 00010）「産婦健診結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssanpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                 //全て
                    else { db.tt_bhnssanpukensinkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;
                case JIGYO_00011:       //妊婦健診費用助成（110-2 -- 00011）「産婦健診費用助成（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssanpukensinhiyojosei.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }             //全て
                    else { db.tt_bhnssanpukensinhiyojosei.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }		        //選択中
                    break;
                case JIGYO_00012:       // 産婦精密健診結果（112-1 -- 00012)「産婦精密健診結果（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssanpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                 //全て
                    else { db.tt_bhnssanpuseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;
                case JIGYO_00013:       // 産後ケア事業情報（113-1 -- 00013)「産後ケア事業（固定）テーブル」
                    if (req.delflg) { db.tt_bhnssangocarejigyo.DELETE.WHERE.ByKey(req.atenano, req.torokuno).Execute(); }                   //全て
                    else { db.tt_bhnssangocarejigyo.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute(); }			        //選択中
                    break;

                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// 保存処理(費用助成一覧)
        /// </summary>
        private void SaveJyosei(DaDbContext db, SaveRequest req)
        {
            if (req.jyoseilistinfo == null) { return; }

            //１、母子保健事業コードと処理パターンを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //-------------------------------------------------------------
            //２.親画面のキー情報でサブテーブルを全件削除
            //-------------------------------------------------------------
            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診結果-妊婦健診結果と妊産婦歯科健診結果の場合
                //妊婦健診費用助成（固定）サブテーブル
                db.tt_bhnsninpukensinhiyojosei_sub.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.edano).Execute();
            }
            else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診結果-産婦健診結果の場合
                //産婦健診費用助成（固定）サブテーブル
                db.tt_bhnssanpukensinhiyojosei_sub.DELETE.WHERE.ByKey(req.atenano, req.torokuno, req.edano).Execute();
            }

            //-------------------------------------------------------------
            //３.妊産婦（フリー項目）テーブルへ登録
            //-------------------------------------------------------------
            if (jigyocd.Equals(JIGYO_00006) || jigyocd.Equals(JIGYO_00032))
            {
                //妊婦健診結果-妊婦健診結果と妊産婦歯科健診結果の場合
                //妊婦健診費用助成（固定）サブテーブル
                var newdtl = new List<tt_bhnsninpukensinhiyojosei_subDto>();
                newdtl = Converter.GetDtl(newdtl, req, jigyocd);
                db.tt_bhnsninpukensinhiyojosei_sub.INSERT.Execute(newdtl);
            }
            else if (jigyocd.Equals(JIGYO_00011))
            {
                //産婦健診結果-産婦健診結果の場合
                //産婦健診費用助成（固定）サブテーブル
                var newdtl = new List<tt_bhnssanpukensinhiyojosei_subDto>();
                newdtl = Converter.GetDtl(newdtl, req);
                db.tt_bhnssanpukensinhiyojosei_sub.INSERT.Execute(newdtl);
            }
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 保存前チェック
        /// </summary>
        private static bool Check(DaDbContext db, SaveRequest req, string jigyocd, EnumActionType? kbn, CommonResponse res)
        {
            if (kbn == null) { return true; }

            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            ////妊産婦（フリー）項目テーブル
            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).Exists())
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"母子種類 - 母子保健事業コード - 宛名番号 - 登録番号 - 登録番号連番 - 枝番 - 履歴回数");
                    res.SetServiceError(msg);
                    return false;
                }

            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).Exists())
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "更新対象", "妊産婦（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }

            //対象年齢範囲内チェック
            switch (jigyocd)
            {
                case JIGYO_00001:     //妊娠届出情報
                case JIGYO_00002:     //妊娠届出アンケート
                case JIGYO_00003:     //母子健康手帳交付情報
                case JIGYO_00007:     //妊産婦歯科健診結果
                case JIGYO_00008:     //妊産婦歯科精健結果
                case JIGYO_00013:     //産後ケア事業情報
                    //TODO:対象年齢範囲内であるかチェックする。範囲内でなければ、エラーメッセージ(E002013)を表示する
                    //対象年齢範囲内判断の仕様未確定の為、一時的falseにする
                    if (CheckAgeRange(db, 0, "1"))
                    {
                        //E002013：未定。
                        //var msg = DaMessageService.GetMsg(EnumMessage.E002013, "更新対象", "母子保健項目テーブル");
                        var msg = string.Empty;
                        res.SetServiceError(msg);
                        return false;
                    }
                    break;
                default:
                    break;
            }

            //宛名テーブル
            var dto = db.tt_afatena.GetDtoByKey(req.atenano);

            //存在チェック
            if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "受診年月日時点で対象者", "市町村")) { return false; }  //異常返し

            return true;
        }

        /// <summary>
        /// 削除前チェック
        /// </summary>
        private static bool Check(DaDbContext db, DeleteRequest req, string jigyocd, CommonResponse res)
        {
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //妊産婦（フリー）項目テーブル
            if (req.delflg)
            {
                //全ての詳細内容削除の場合
                if (!db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno).Exists())
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "削除対象", "妊産婦（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else
            {
                //選択中の履歷のみ削除の場合
                if (!db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu).Exists())
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "削除対象", "妊産婦（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 詳細メニューの文字色を取得
        /// </summary>
        public static string GetMenuStatus(DaDbContext db, string bosikbn, string menucd, string atenano, long torokuno)
        {
            var syosaitabdtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(bosikbn, menucd).GetDtoList().Select(e => e.jigyocd);
            foreach (var jigyocd in syosaitabdtl)
            {
                //①対応したタブが１つでもデータ入力済みの場合、「詳細メニュー」ボタンの文字色を水色とする。
                if (db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, atenano, torokuno).Exists())
                {
                    return ボタン文字色._1;       //水色
                }
            }

            //ボタン文字色処理しない
            return ボタン文字色._0;               //無色
        }

        /// <summary>
        /// 詳細タブの文字色を取得
        /// </summary>
        public static string GetTabStatus(DaDbContext db, tm_bhkksyosaitabDto dto, string atenano, long torokuno)
        {
            //①対応したタブがデータ入力済みの場合、詳細タブの文字色を水色とする。
            if (db.tt_bhnsfree.SELECT.WHERE.ByKey(dto.jigyocd, atenano, torokuno).Exists())
            {
                return ボタン文字色._1;           //水色
            }

            //ボタン文字色処理しない
            return ボタン文字色._0;               //無色
        }

        /// <summary>
        /// 母子種類／母子詳細メニューコード／母子詳細タブコードから母子保健事業コードを取得（必要ない可能性が高い、将来削除かも）
        /// </summary>
        public static string GetJigyocd(DaDbContext db, string bosikbn, string bhsyosaimenyucd, string bhsyosaitabcd)
        {
            var tabdto = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(bosikbn, bhsyosaimenyucd, bhsyosaitabcd).GetDto();
            if (tabdto == null) { return string.Empty; }
            else { return tabdto.jigyocd; }
        }

        /// <summary>
        ///新規登録する際に、登録番号連番／受診回数／申請枝番／枝番を付与（最大＋１）
        /// </summary>
        private static SaveRequest GetNewReq(DaDbContext db, SaveRequest req, string jigyocd)
        {
            var mdtl = new List<tt_bhnsfreeDto>();                 //妊産婦（フリー）項目テーブル（フリーテーブル）

            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める
            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    req.torokunorenban = 0;
                    req.edano = 0;
                    req.kaisu = 0;
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.edano)}=@edano and " +
                                                                $"{nameof(tt_bhnsfreeDto.kaisu)}=@kaisu "
                                                                , jigyocd, req.atenano, req.torokuno, req.edano, skaisu).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0)
                    {
                        req.torokunorenban = 1;
                        req.edano = 0;
                        req.kaisu = 0;
                    }
                    else
                    {
                        req.torokunorenban = mdtl.Select(e => e.torokunorenban).Max() + 1;
                        req.edano = 0;
                        req.kaisu = 0;
                    }
                    break;
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokunorenban)}=@torokunorenban and " +
                                                                $"{nameof(tt_bhnsfreeDto.edano)}=@edano "
                                                                , jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0)
                    {
                        req.torokunorenban = 0;
                        req.edano = 0;
                        req.kaisu = 1;
                    }
                    else
                    {
                        req.torokunorenban = 0;
                        req.edano = 0;
                        //TODO：zhang20240617
                        //req.kaisu = mdtl.Select(e => e.kaisu).Max() + 1;
                        var maxkaisu = mdtl.Select(e => e.kaisu).Max();
                        if (Information.IsNumeric(maxkaisu)) { req.kaisu = CInt(maxkaisu) + 1; }
                        else { req.kaisu = 0; }
                    }
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokunorenban)}=@torokunorenban and " +
                                                                $"{nameof(tt_bhnsfreeDto.kaisu)}=@kaisu "
                                                                , jigyocd, req.atenano, req.torokuno, req.torokunorenban, skaisu).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0)
                    {
                        req.torokunorenban = 0;
                        req.edano = 1;
                        req.kaisu = 0;
                    }
                    else
                    {
                        req.torokunorenban = 0;
                        req.edano = mdtl.Select(e => e.edano).Max() + 1;
                        req.kaisu = 0;
                    }
                    break;
                default:
                    break;
            }
            return req;
        }

        /// <summary>
        ///新規登録する際に、履歴回数を付与（最大＋１）
        /// </summary>
        private static int GetNewkaisu(DaDbContext db, string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, int kaisu)
        {
            var mdtl = new List<tt_bhnsfreeDto>();                 //妊産婦（フリー）項目テーブル（フリーテーブル）

            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(kaisu).PadLeft(2, '0') : CStr(kaisu);   //妊婦健診結果(00005)の場合頭0を埋める
            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    return (0);
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokunorenban)}=@torokunorenban and " +
                                                                $"{nameof(tt_bhnsfreeDto.edano)}=@edano "
                                                                , jigyocd, atenano, torokuno, torokunorenban, edano).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0) { return (1); }

                    //TODO：zhang20240617
                    //return (mdtl.Select(e => e.kaisu).Max() + 1);
                    var maxkaisu = mdtl.Select(e => e.kaisu).Max();
                    if (Information.IsNumeric(maxkaisu)) { return CInt(maxkaisu) + 1; }
                    else { return 0; }

                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.edano)}=@edano and " +
                                                                $"{nameof(tt_bhnsfreeDto.kaisu)}=@kaisu "
                                                                , jigyocd, atenano, torokuno, edano, skaisu).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0) { return (1); }
                    return (mdtl.Select(e => e.torokunorenban).Max() + 1);
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    mdtl = db.tt_bhnsfree.SELECT.WHERE.ByFilter($"{nameof(tt_bhnsfreeDto.jigyocd)}=@jigyocd and " +
                                                                $"{nameof(tt_bhnsfreeDto.atenano)}=@atenano and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokuno)}=@torokuno and " +
                                                                $"{nameof(tt_bhnsfreeDto.torokunorenban)}=@torokunorenban and " +
                                                                $"{nameof(tt_bhnsfreeDto.kaisu)}=@kaisu "
                                                                , jigyocd, atenano, torokuno, torokunorenban, skaisu).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0) { return (1); }
                    return (mdtl.Select(e => e.edano).Max() + 1);
                default:
                    return (1);
            }
        }

        /// <summary>
        ///パターンから固定項目用登録番号連番／枝番／回数としての回数を取得
        /// </summary>
        private static int GetFixKaisu(string pattern, int torokunorenban, int edano, int kaisu)
        {
            switch (pattern)
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    return (0);
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    return (kaisu);
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    return (torokunorenban);
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    return (edano);
                default:
                    return (0);
            }
        }

        /// <summary>
        ///自動採番必要かどうかの判断　True：自動採番する、False：自動採番しない
        /// </summary>
        private static bool ChkInsertFlag(string pattern, int torokunorenban, int edano, int kaisu)
        {
            var flag = false;

            switch (pattern)
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    if (torokunorenban == 0) { flag = true; }
                    break;
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    if (kaisu == 0) { flag = true; }
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    if (edano == 0) { flag = true; }
                    break;
                default:
                    break;
            }

            return flag;
        }

        /// <summary>
        ///Front側渡した登録番号連番／枝番／回数を最大回数として返す
        /// </summary>
        private static int GetMaxKaisu(SearchSyosaiRequest req, string pattern)
        {
            var maxkaisu = 0;

            switch (pattern)
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    maxkaisu = req.torokunorenban;
                    break;
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    maxkaisu = req.kaisu;
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    maxkaisu = req.edano;
                    break;
                default:
                    break;
            }
            return maxkaisu;
        }

        /// <summary>
        /// 画面のデータ操作区分取得
        /// </summary>
        private static EnumActionType? GetKBN(DaDbContext db, string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, int kaisu)
        {
            EnumActionType? kbn = null;

            //TODO：zhang20240617
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(kaisu).PadLeft(2, '0') : CStr(kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //メニュー側クリックまたは詳細タブクリックする場合
            if (torokunorenban == 0 && edano == 0 && CInt(kaisu) == 0) 
            { 
                if (!PatternDic[jigyocd].Equals(PATTERN_1)) { return EnumActionType.Update; }
            }

            //回数タブをクリックする場合
            if (db.tt_bhnsfree.SELECT.WHERE.ByKey(jigyocd, atenano, torokuno, torokunorenban, edano, skaisu).Exists())
            {
                kbn = EnumActionType.Update;        //編集フラグ☑=>更新
            }
            else
            {
                kbn = EnumActionType.Insert;        //編集フラグ☑=>新規
            }
            return kbn;
        }

        /// <summary>
        ///母子詳細メニュー名称文字列を取得
        /// </summary>
        public static string GetMenuNameStr(DaDbContext db, string bosikbn)
        {
            var str = string.Empty;
            var dtl = db.tm_bhkksyosaimenyu.SELECT.WHERE.ByKey(bosikbn).GetDtoList().OrderBy(e => e.orderseq);
            foreach (var dto in dtl)
            {
                if (string.IsNullOrEmpty(str))
                {
                    str = $"{dto.bhsyosaimenyushortnm}";
                }
                else
                {
                    str = $"{str}|{dto.bhsyosaimenyushortnm}";
                }
            }
            return str;
        }

        /// <summary>
        ///コード : 名称から名称を取得
        /// </summary>
        private static string GetNM(string str)
        {
            var arr = str.Split($"{SPACE}{COLON}{SPACE}");
            if (arr.Length > 1) { return arr[1]; }
            return string.Empty;
        }

        /// <summary>
        ///特別処理（Distinctで検索するBUGを避ける為、最初列をソートの場合、一番最後のソート用列に変更する）
        /// </summary>
        public static int ProcOrderBy(int orderby, int maxorder)
        {
            var neworderby = 0;
            if (orderby == 1) { neworderby = maxorder; }
            else if (orderby == -1) { neworderby = -maxorder; }
            else { neworderby = orderby; }
            return neworderby;
        }

        /// <summary>
        /// 妊産婦の詳細内容を取得
        /// </summary>
        public static string GetSyosaiStr(DaDbContext db, string bosikbn, string atenano, long torokuno)
        {
            Dictionary<string, string> MenuDic = new Dictionary<string, string>();
            Dictionary<string, string> JigyoDic = new Dictionary<string, string>();

            FrResult result = new FrResult();

            var str = string.Empty;
            var tableid = string.Empty;

            var menudtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(bosikbn).GetDtoList().OrderBy(e => e.orderseq);
            if (menudtl == null) { return string.Empty; }

            //辞書を初期設定
            foreach (var dto in menudtl)
            {
                if (!MenuDic.ContainsKey(dto.bhsyosaimenyucd)) { MenuDic.Add(dto.bhsyosaimenyucd, "　　　　"); }
                JigyoDic.Add(dto.jigyocd, dto.bhsyosaimenyucd);
            }

            foreach (tm_bhkksyosaitabDto dto in menudtl)
            {
                tableid = FixTblDic[CStr(dto.jigyocd)];             //固定テーブル名

                var sql = GetDataCountSql(db, tableid, atenano, torokuno);
                DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));
                if (CInt(dt.Rows[0][0]) > 0)
                {
                    var menuid = JigyoDic[CStr(dto.jigyocd)];
                    MenuDic[menuid] = "　　〇　";
                }
            }

            var dtl = db.tm_bhkksyosaimenyu.SELECT.WHERE.ByKey(bosikbn).GetDtoList().OrderBy(e => e.orderseq);
            foreach (var dto in dtl)
            {
                if (string.IsNullOrEmpty(str)) { str = $"{MenuDic[dto.bhsyosaimenyucd]}"; }
                else { str = $"{str}|{MenuDic[dto.bhsyosaimenyucd]}"; }
            }

            return str;
        }

        /// <summary>
        /// 対象年齢範囲内であるかのチェック処理
        /// True：範囲内、False：範囲外
        /// 例：SELECT fn_afgetagerangeflg(23, '6-10,20-30')
        /// </summary>
        public static bool CheckAgeRange(DaDbContext db, int age, string agerange)
        {
            FrResult result = new FrResult();
            var sql = $"SELECT{SPACE}fn_afgetagerangeflg({age}, '{agerange}'){C_LF}";
            DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));
            if (dt.Rows.Count == 0) { return false; }
            if (CBool(dt.Rows[0][0])) { return true; }
            else { return false; }
        }

        /// <summary>
        /// 検索結果の総件数を取得
        /// </summary>
        public static int GetResultTotalCount(DaDbContext db, string bosikbn, FrCondition condition, int orderColumn, bool noCheck)
        {
            var pageno = condition.PageNo;
            var pagesize = condition.PageRowCount;
            condition.PageRowCount = -1;
            //検索結果
            var result = DaFreeQuery.GetBosiQuery(db, bosikbn, condition, orderColumn, true);
            condition.PageNo = pageno;
            condition.PageRowCount = pagesize;

            return result.Data.Rows.Count;
        }

        /// <summary>
        ///画面上回数リストを取得
        /// </summary>
        public static DataTable GetKaisuDtl(DaDbContext db, string freetable, string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, int kaisu)
        {
            FrResult result = new FrResult();

            var sql = GetKaisuListSql(db, freetable, jigyocd, atenano, torokuno, torokunorenban, edano, kaisu);
            DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            return dt;
        }

        //================================================== SQL文取得 ==================================================
        /// <summary>
        ///データの存在チェック（検索一覧の詳細内容）
        /// </summary>
        public static string GetDataCountSql(DaDbContext db, string freetable, string atenano, long torokuno)
        {
            var sql = string.Empty;

            sql = $"{sql}SELECT{SPACE}Count(*){SPACE}AS{SPACE}CNT{C_LF}";
            sql = $"{sql}FROM{SPACE}{freetable}{C_LF}";
            sql = $"{sql}WHERE{SPACE}1=1{C_LF}";
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            if (torokuno > 0) { sql = $"{sql}AND{SPACE}torokuno{SPACE}={SPACE}{torokuno}{C_LF}"; }

            return sql;
        }

        /// <summary>
        ///回数リストを取得SQL
        /// </summary>
        private static string GetKaisuListSql(DaDbContext db, string freetable, string jigyocd, string atenano, long torokuno, int torokunorenban, int edano, int kaisu)
        {
            var sql = string.Empty;

            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    sql = $"{sql}SELECT{SPACE}DISTINCT{SPACE}kaisu{SPACE}AS{SPACE}kaisu{C_LF}";
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    sql = $"{sql}SELECT{SPACE}DISTINCT{SPACE}torokunorenban{SPACE}AS{SPACE}kaisu{C_LF}";
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    sql = $"{sql}SELECT{SPACE}DISTINCT{SPACE}edano{SPACE}AS{SPACE}kaisu{C_LF}";
                    break;
                default:
                    sql = $"{sql}SELECT{SPACE}DISTINCT{SPACE}kaisu{SPACE}AS{SPACE}kaisu{C_LF}";
                    break;
            }
            sql = $"{sql}FROM{SPACE}{freetable}{C_LF}";
            sql = $"{sql}WHERE{SPACE}1=1{C_LF}";
            sql = $"{sql}AND{SPACE}jigyocd{SPACE}={SPACE}'{jigyocd}'{C_LF}";
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            sql = $"{sql}AND{SPACE}torokuno{SPACE}={SPACE}{torokuno}{C_LF}";
            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    sql = $"{sql}AND{SPACE}torokunorenban{SPACE}={SPACE}{torokunorenban}{C_LF}";
                    sql = $"{sql}AND{SPACE}edano{SPACE}={SPACE}{edano}{C_LF}";
                    sql = $"{sql}ORDER BY{SPACE}kaisu{C_LF}";
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    sql = $"{sql}AND{SPACE}edano{SPACE}={SPACE}{edano}{C_LF}";
                    //TODO：zhang20240617
                    //sql = $"{sql}AND{SPACE}kaisu{SPACE}={SPACE}{kaisu}{C_LF}";
                    sql = $"{sql}AND{SPACE}kaisu{SPACE}={SPACE}'{kaisu}'{C_LF}";
                    sql = $"{sql}ORDER BY{SPACE}torokunorenban{C_LF}";
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    sql = $"{sql}AND{SPACE}torokunorenban{SPACE}={SPACE}{torokunorenban}{C_LF}";
                    //TODO：zhang20240617
                    //sql = $"{sql}AND{SPACE}kaisu{SPACE}={SPACE}{kaisu}{C_LF}";
                    sql = $"{sql}AND{SPACE}kaisu{SPACE}={SPACE}'{kaisu}'{C_LF}";
                    sql = $"{sql}ORDER BY{SPACE}edano{C_LF}";
                    break;
                default:
                    break;
            }

            return sql;
        }

        /// <summary>
        /// フリー項目の数値項目値を取得
        /// </summary>
        private static object GetFreeNumValue(DaDbContext db, SaveRequest req, string jigyocd, string itemcd)
        {
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //乳幼児（フリー）項目テーブル
            var dto = db.tt_bhnsfree.GetDtoByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu, itemcd);

            if (dto != null) { return dto.numvalue!; }
            else { return 0; }
        }

        /// <summary>
        /// フリー項目の文字項目値を取得
        /// </summary>
        private static string GetFreeStrValue(DaDbContext db, SaveRequest req, string jigyocd, string itemcd)
        {
            var skaisu = jigyocd.Equals(JIGYO_00005) ? CStr(req.kaisu).PadLeft(2, '0') : CStr(req.kaisu);   //妊婦健診結果(00005)の場合頭0を埋める

            //乳幼児（フリー）項目テーブル
            var dto = db.tt_bhnsfree.GetDtoByKey(jigyocd, req.atenano, req.torokuno, req.torokunorenban, req.edano, skaisu!, itemcd);

            if (dto != null) { return dto.strvalue!; }
            else { return string.Empty; }
        }

        /// <summary>
        ///妊産婦特定業務の固定項目情報リストを取得
        /// </summary>
        private static List<FixItemDispInfoVM> GetFixItemList(DaDbContext db, string jigyocd, string atenano, long? torokuno, int kaisu, string fixtable, string fixitem)
        {
            var list = new List<FixItemDispInfoVM>();
            if (string.IsNullOrEmpty(fixitem)) { return list; }

            //表示順番初期化
            var i = 1;

            var arr = fixitem.Split($"{COMMA}");
            foreach (var str in arr)
            {
                //固定項目情報取得
                var vm = GetFixItem(db, fixtable, str, PatternDic[jigyocd], atenano, torokuno, kaisu, i);

                if (vm == null) { return list; }
                list.Add(vm);
                i++;
            };

            return list;
        }

        /// <summary>
        ///妊産婦固定項目情報リストを取得
        /// </summary>
        private static FixItemDispInfoVM GetFixItem(DaDbContext db, string tableid, string itemcdnm, string pattern, string atenano, long? torokuno, int kaisu, int no)
        {
            var vm = new FixItemDispInfoVM();

            var itemcd = string.Empty;

            var arr = itemcdnm.Split($"{COLON}");
            if (arr.Length != 5) { return vm; }

            vm.inputtypekbn = (Enum入力タイプ)Enum.Parse(typeof(Enum入力タイプ), arr[2]);     //入力タイプ


            if (!arr[3].Equals("0")) { vm.keta1 = CInt(arr[3]); }   //入力桁
            if (arr[0].IndexOf('*') >= 0)
            {
                vm.hissuflg = true;                                 //必須項目設定
                arr[0] = arr[0].Replace("*", "");
            }

            vm.itemcd = $"{arr[0]}";                                //項目コード（例：torokuno）
            vm.itemnm = $"{arr[1]}";                                //項目名（例：登録番号）
            vm.inputflg = true;                                     //入力フラグ
            vm.msgkbn = EnumMsgCtrlKbn.非表示;                      //メッセージ区分
            vm.biko = vm.itemnm;                                    //備考
            vm.orderseq = CInt(arr[4]);                             //並びシーケンス

            FrResult result = new FrResult();

            var sql = string.Empty;
            sql = $"{sql}SELECT{SPACE}{arr[0]}{SPACE}AS{SPACE}value{C_LF}";
            sql = $"{sql}FROM{SPACE}{tableid}{C_LF}";
            sql = $"{sql}WHERE{SPACE}1=1{C_LF}";
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            if (torokuno != null) { sql = $"{sql}AND{SPACE}torokuno{SPACE}={SPACE}{torokuno}{C_LF}"; }

            switch (pattern)
            {
                case PATTERN_1:     // 宛名番号(atenano)、登録番号(torokuno)
                    break;
                case PATTERN_2:     // 宛名番号(atenano)、登録番号(torokuno)、登録番号連番(torokunorenban)
                    sql = $"{sql}AND{SPACE}torokunorenban{SPACE}={SPACE}{kaisu}{C_LF}";
                    break;
                case PATTERN_3:     // 宛名番号(atenano)、登録番号(torokuno)、受診回数(jusinkaisu)
                    //妊婦健診結果の場合、回数は前0を埋めて受診回数項目と比較する必要tm_afhanyo(1003-2)
                    var jusinkaisu = CStr(kaisu).PadLeft(2, '0');
                    sql = $"{sql}AND{SPACE}jusinkaisu{SPACE}={SPACE}'{jusinkaisu}'{C_LF}";
                    break;
                case PATTERN_4:     // 宛名番号(atenano)、登録番号(torokuno)、申請枝番(sinseiedano)
                    sql = $"{sql}AND{SPACE}sinseiedano{SPACE}={SPACE}{kaisu}{C_LF}";
                    break;
                case PATTERN_5:     // 宛名番号(atenano)、登録番号(torokuno)、枝番(edano)
                    sql = $"{sql}AND{SPACE}edano{SPACE}={SPACE}{kaisu}{C_LF}";
                    break;
                default:
                    break;
            }

            DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));
            if (dt.Rows.Count > 0) { vm.value = CStr(dt.Rows[0][0]).Trim(); }    //値

            return vm;
        }

        /// <summary>
        ///固定項目名称から固定項目値を取得する
        /// </summary>
        private static object? GetFixValue(List<FreeItemInfoVM> list, string fixitem)
        {
            var result = list.Find(e => GetCd(e.item) == fixitem);
            if (result != null) { return result.value; }
            return null;
        }

        /// <summary>
        ///妊婦健診結果（固定）テーブルの受診回数は母子保健（フリー）項目コントロールマスタの利用回数に存在するフリー項目のみ返す
        /// </summary>
        private static List<tm_bhkkfreeitemDto> ProcRiyokaisu(List<tm_bhkkfreeitemDto> freeMstDtl, int kaisu)
        {
            var jusinkaisu = CStr(kaisu).PadLeft(2, '0');
            var newDtl = new List<tm_bhkkfreeitemDto>();

            foreach (var dto in freeMstDtl)
            {
                if (dto.riyokaisu.Contains(jusinkaisu)) { newDtl.Add(dto); }
            }
            return newDtl;
        }

        /// <summary>
        ///汎用マスタから母子保健事業コードの汎用区分（汎用区分1／汎用区分2／汎用区分3）情報を取得する
        /// </summary>
        public static Dictionary<string, string> GetBosiHanyokbnInfo(DaDbContext db, string bosikbn, string hanyokbn, string? kbn)
        {
            var dtl = GetHanyoDtl(db, EnumHanyoKbn.母子保健事業コード);
            var dic = new Dictionary<string, string>();

            var paranum = 0;

            if (bosikbn.Equals(母子種類._1)) { paranum = 2; }           //妊産婦の場合、汎用区分2のパラメータ数は2個（固定テーブル名,パラメータ）
            else if (bosikbn.Equals(母子種類._2)) { paranum = 3; }      //乳幼児の場合、汎用区分2のパラメータ数は3個（固定テーブル名,パラメータ,乳幼児健診コード）
            else { return dic; }                                        //異常の場合

            foreach (var dto in dtl)
            {
                if (CStr(dto.hanyokbn1).Equals(bosikbn))
                {
                    if (hanyokbn.Equals(汎用区分._1)) { dic[dto.hanyocd] = CStr(dto.hanyokbn1); }
                    else if (hanyokbn.Equals(汎用区分._2))
                    {
                        var arr = CStr(dto.hanyokbn2).Split($"{COMMA}");
                        if (arr.Length == paranum)
                        {
                            if (string.IsNullOrEmpty(kbn)) { dic[dto.hanyocd] = CStr(arr[0]); }
                            else if (kbn.Equals(辞書設定区分._P)) { dic[dto.hanyocd] = CStr(arr[1]); }
                            else if (kbn.Equals(辞書設定区分._N)) { dic[dto.hanyocd] = CStr(arr[2]); }
                            else { dic[dto.hanyocd] = string.Empty; }
                        }
                    }
                    else if (hanyokbn.Equals(汎用区分._3)) { dic[dto.hanyocd] = CStr(dto.hanyokbn3); }
                }
            }
            return dic;
        }

        /// <summary>
        ///妊産婦特定業務の固定項目情報リストを取得
        /// </summary>
        private static int GetLimitKaisu(DaDbContext db, string jigyocd)
        {
            var limitkaisu = 0; 
            switch (jigyocd)
            {
                case JIGYO_00005:   //妊婦健診結果
                    limitkaisu = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦健診名)).ToString()).Count;
                    break;
                case JIGYO_00010:   //産婦健診結果
                    limitkaisu = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.産婦健診名)).ToString()).Count;
                    break;
                case JIGYO_00007:   //妊産婦歯科健診結果
                    limitkaisu = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.妊婦歯科健診名)).ToString()).Count;
                    break;
                default:
                    break;
            }

            return limitkaisu;
        }

    }
}