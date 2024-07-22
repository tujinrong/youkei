// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
// 　　　　　　サービス処理
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaNameService;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.Service.AWBH00301G.Service;
using AIplus.FreeQuery.Common;

namespace BCC.Affect.Service.AWBH00401G
{
    [DisplayName("")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWBH00401G = "AWBH00401G";

        //乳幼児（フリー）項目テーブル
        private const string FREETABLE = "tt_bhnyfree";

        //母子保健事業コード
        private const string JIGYO_00014 = "00014";     					    //出生時情報
        private const string JIGYO_00015 = "00015";     						//新生児聴覚検査結果
        private const string JIGYO_00016 = "00016";     						//新生児聴覚スクリーニング検査費用助成
        private const string JIGYO_00017 = "00017";     						//乳幼児健診対象者（仕様がない為、未使用）
        private const string JIGYO_00018 = "00018";     						//3～4か月児健診結果
        private const string JIGYO_00019 = "00019";     						//3～4か月児健診アンケート
        private const string JIGYO_00020 = "00020";     						//1歳6か月児健診結果
        private const string JIGYO_00021 = "00021";     						//1歳6か月児健診アンケート
        private const string JIGYO_00022 = "00022";     						//1歳6か月児歯科健診結果
        private const string JIGYO_00023 = "00023";     						//3歳児健診結果
        private const string JIGYO_00024 = "00024";     						//3歳児健診アンケート
        private const string JIGYO_00025 = "00025";     						//3歳児歯科健診結果
        private const string JIGYO_00026 = "00026";     						//健診受診履歴
        private const string JIGYO_00027 = "00027";     						//精密健診の依頼
        private const string JIGYO_00028 = "00028";     						//乳幼児精密健診結果
        private const string JIGYO_00029 = "00029";     						//未受診者勧奨情報

        //固定テーブルパターン
        public const string PATTERN_1 = "1";                                    //宛名番号(atenano)
        public const string PATTERN_2 = "2";                                    //宛名番号(atenano)、枝番(edano)
        public const string PATTERN_3 = "3";                                    //乳幼児健診コード(nykensincd)、宛名番号(atenano)、枝番(edano)

        //定数定義
        private const int ORDERBYCOUNT = 12;                                    //検索一覧の列数（非表示も含む）

        public static Dictionary<string, string> FixTblDic = new Dictionary<string, string>();          //固定テーブル名
        public static Dictionary<string, string> PatternDic = new Dictionary<string, string>();         //固定テーブルパターン
        public static Dictionary<string, string> NykensinDic = new Dictionary<string, string>();        //乳幼児健診コード
        public static Dictionary<string, string> FixItemDic = new Dictionary<string, string>();         //固定項目情報

        static Service()
        {
            var db = new DaDbContext();
            FixTblDic = GetBosiHanyokbnInfo(db, AWBH00301G.母子種類._2, 汎用区分._2, null);                 //固定テーブル名（汎用区分２）辞書
            PatternDic = GetBosiHanyokbnInfo(db, AWBH00301G.母子種類._2, 汎用区分._2, 辞書設定区分._P);     //固定テーブルパターン辞書
            NykensinDic = GetBosiHanyokbnInfo(db, AWBH00301G.母子種類._2, 汎用区分._2, 辞書設定区分._N);    //乳幼児健診コード辞書
            FixItemDic = GetBosiHanyokbnInfo(db, AWBH00301G.母子種類._2, 汎用区分._3, null);                //必須フラグ／固定項目ID／固定項目表示名称／入力タイプ／桁数（整数部分）／並びシーケンス（汎用区分３）辞書
        }

        [DisplayName("乳幼児画面検索処理(検索画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("乳幼児詳細画面検索処理(乳幼児一覧)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("乳幼児フリー項目検索処理")]
        public SearchSyosaiResponse SearchSyosai(SearchSyosaiRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSyosai(db, req);
            });
        }

        [DisplayName("父母親情報検索処理")]
        public SearchAtenaInfoResponse SearchAtenaInfo(SearchAtenaInfoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchAtenaInfo(db, req);
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
                    result = Save(db, req);
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
        /// ①乳幼児画面検索処理(検索画面)
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //特別処理（Distinctで検索するBUG発生しないように処理する）
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
            var condition = CmSearchUtil.GetSearchJyoken(db, AWBH00401G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);

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
            res.kekkalist = Wraper.GetNyuYouJiVMList(db, pageData.Rows, req.bosikbn, alertviewflg);

            //ページャー設定
            res.SetPageInfo(total, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// ②③乳幼児詳細画面検索処理(乳幼児一覧)
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
            var kaisudtl = GetKaisuDtl(db, FREETABLE, jigyocd, req.atenano);

            //データ存在しない場合の枝番の初期値設定（パターン１の場合は0で固定、その以外の場合は1で設定する）
            var kaisu = (PatternDic[jigyocd] == PATTERN_1 ? 0 : 1);

            var dataexist = false;

            if (kaisudtl.Rows.Count > 0)
            {
                kaisu = CInt(kaisudtl.Compute("MIN(kaisu)", "true"));
                dataexist = true;
            }

            //E、乳幼児フリー項目を取得する
            var freeMstDtl = db.tm_bhkkfreeitem.SELECT.WHERE.ByKey(req.bosikbn, jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();              //表示順ソート：並び順

            var keyList = new List<object[]>();

            foreach (var item in freeMstDtl)
            {
                //このインターフェースは検索画面から詳細画面へ遷移した場合のみ利用する為、
                //母子保健詳細メニューマスタの乳幼児部分の並びシーケンス一番目の母子保健事業コードを初期表示する
                keyList.Add(new object[] { item.jigyocd, req.atenano, kaisu, item.itemcd });
            }
            //全項目データ
            var dataDtl = db.tt_bhnyfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            res.headerinfo = Wraper.GetHeaderVM(db, atenadto, alertviewflg);        //乳幼児ヘッダー情報

            res.menulist = Wraper.GetMenuInfoVMList(db, menudtl!, req.bosikbn, req.atenano);    //メニュー名称リスト

            res.tablist = Wraper.GetTabInfoVMList(db, tabdtl!, req.atenano);        //タブ名称リスト

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
            res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.乳幼児グループID)).ToString());
            res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.乳幼児グループID2)).ToString());
            //res.grouplist1 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);
            //res.grouplist2 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno("AWBH00401G", 拡_予約_保健指導業務区分._02);

            //固定項目一覧
            res.fixitemlist = GetFixItemList(db, jigyocd, req.atenano, kaisu, FixTblDic[jigyocd], FixItemDic[jigyocd]);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWBH00401G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// ④乳幼児フリー項目検索処理（メニュー選択／タブ選択／履歴回数選択の場合）
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
            var kbn = GetKBN(db, FREETABLE, jigyocd, req.atenano, req.kaisu);

            //C、該当宛名番号／メニュー項目のタブリストを取得
            var tabdtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(req.bosikbn, req.bhsyosaimenyucd).GetDtoList().OrderBy(e => e.orderseq);

            if (tabdtl == null) { throw new AiExclusiveException(); }

            //D、乳幼児フリー項目を取得する
            var freeMstDtl = db.tm_bhkkfreeitem.SELECT.WHERE.ByKey(req.bosikbn, jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();              //表示順ソート：並び順

            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                //このインターフェースは検索画面から詳細画面へ遷移した場合のみ利用する為、履歴回数は1で固定する
                keyList.Add(new object[] { item.jigyocd, req.atenano, req.kaisu, item.itemcd });
            }
            //全項目データ
            var dataDtl = db.tt_bhnyfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.tablist = Wraper.GetTabInfoVMList(db, tabdtl!, req.atenano);        //タブ名称リスト

            //D、履歴回数リストを取得
            var kaisudtl = GetKaisuDtl(db, FREETABLE, jigyocd, req.atenano);

            var dataexist = false;

            if (kaisudtl.Rows.Count > 0)
            {
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

                if (req.kaisu == 0)
                {
                    //自動採番が必要な場合
                    maxkaisu = GetNewkaisu(db, jigyocd, req.atenano);
                }
                else
                {
                    //自動採番ではない場合
                    maxkaisu = req.kaisu;
                }

                if (maxkaisu > res.maxkaisu)
                {
                    var vm = new KaisuInfoVM();

                    vm.kaisu = maxkaisu;
                    res.maxkaisu = maxkaisu;                                        //最大履歴回数
                    res.kaisulist.Add(vm);                                          //履歴回数リスト
                }
            }

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno("AWBH00401G", 拡_予約_保健指導業務区分._02);

            //固定項目一覧
            res.fixitemlist = GetFixItemList(db, jigyocd, req.atenano, req.kaisu, FixTblDic[jigyocd], FixItemDic[jigyocd]);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWBH00401G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑤父母親情報検索処理
        /// </summary>
        private SearchAtenaInfoResponse SearchAtenaInfo(DaDbContext db, SearchAtenaInfoRequest req)
        {
            var res = new SearchAtenaInfoResponse();

            var dto = db.tt_afatena.SELECT.WHERE.ByKey(req.atenano).GetDto();
            if (dto == null) { res.AtenaInfo = string.Empty; }

            res.AtenaInfo = Wraper.GetAtenaInfo(db, dto!);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑥保存処理
        /// </summary>
        private CommonResponse SaveAll(DaDbContext db, SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return Save(db, req);
            });
        }

        /// <summary>
        /// ⑥保存処理(詳細画面--業務毎)
        /// </summary>
        private CommonResponse Save(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //Todo：母子データリストコードを取得（必要ないと思う、詳細削除する可能性高い）
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //データ操作区分取得
            var kbn = GetKBN(db, FREETABLE, jigyocd, req.atenano, req.kaisu);

            //新規の場合（最新登録番号連番／受診回数／申請枝番／枝番を取得）
            if (kbn == EnumActionType.Insert && req.kaisu == 0)
            {
                req.kaisu = GetMaxEdano(db, req, jigyocd);
            }

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, jigyocd, kbn, res)) { return res; }     //異常返し

                //正常返し
                return res;
            }

            //フリー項目一覧
            var oldfreedtl = new List<tt_bhnyfreeDto>();                    //乳幼児（フリー）項目テーブル

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //tt_bhnyfreeDto
                oldfreedtl = db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.kaisu).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newfreedtl = new List<tt_bhnyfreeDto>();                //乳幼児（フリー）項目テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_bhnyfreeDto();
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
                    var newfreedto = new tt_bhnyfreeDto();
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
                //乳幼児（フリー）項目テーブル
                db.tt_bhnyfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.kaisu).Execute();
                db.tt_bhnyfree.INSERT.Execute(newfreedtl);          //乳幼児（フリー）項目テーブル

                //該当業務の固定テーブルを登録処理
                if (!FixTblProc(db, req, jigyocd, kbn)) { return res; }     //異常返し
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_bhnyfree.UPDATE.Execute(newfreedtl);          //乳幼児（フリー）項目テーブル

                //該当業務の固定テーブルを更新処理
                if (!FixTblProc(db, req, jigyocd, kbn)) { return res; }     //異常返し
            }

            //正常返し
            return res;
        }

        ///// <summary>
        ///// 削除処理(詳細画面)
        ///// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req)
        {
            var res = new CommonResponse();

            //母子データリストコードを取得
            var jigyocd = GetJigyocd(db, req.bosikbn, req.bhsyosaimenyucd, req.bhsyosaitabcd);

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名テーブル
            if (!Check(db, req, jigyocd, res)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.乳幼児（フリー）項目テーブルデータ削除処理
            //-------------------------------------------------------------
            //乳幼児（フリー）項目テーブル
            if (req.delflg)
            {
                //全ての詳細内容削除の場合
                db.tt_bhnyfree.DELETE.WHERE.ByKey(jigyocd, req.atenano).Execute();
            } else
            {
                //選択中の履歷のみ削除の場合
                db.tt_bhnyfree.DELETE.WHERE.ByKey(jigyocd, req.atenano, req.kaisu).Execute();
            }

            //-------------------------------------------------------------
            //３.固定テーブルデータ削除処理
            //-------------------------------------------------------------
            //該当業務の固定テーブルの削除処理
            if (!FixTblDel(db, req, jigyocd)) { return res; }   //異常返し

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 保存前チェック
        /// </summary>
        private static bool Check(DaDbContext db, SaveRequest req, string jigyocd, EnumActionType? kbn, CommonResponse res)
        {
            if (kbn == null) { return true; }

            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (CheckDataExist(db, FREETABLE, jigyocd, req.atenano, req.kaisu))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"母子種類 - 母子保健事業コード - 宛名番号 - 枝番");
                    res.SetServiceError(msg);
                    return false;
                }

            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!CheckDataExist(db, FREETABLE, jigyocd, req.atenano, req.kaisu))
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "乳幼児（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }

            //対象年齢範囲内チェック
            switch (jigyocd)
            {
                case JIGYO_00014:           // 出生時
                case JIGYO_00015:           // 聴覚検査結果
                case JIGYO_00018:           // 3～4か月児健診（健診結果）
                case JIGYO_00019:           // 3～4か月児健診（アンケート）
                case JIGYO_00020:           // 1歳6か月児健診（健診結果）
                case JIGYO_00021:           // 1歳6か月児健診（アンケート）
                case JIGYO_00022:           // 1歳6か月児健診（歯科結果）
                case JIGYO_00023:           // 3歳児健診（健診結果）
                case JIGYO_00024:           // 3歳児健診（アンケート）
                case JIGYO_00025:           // 3歳児健診（歯科結果）
                    //TODO:対象年齢範囲内であるかチェックする。範囲内でなければ、エラーメッセージ(E002013)を表示する
                    //対象年齢範囲内判断の仕様未確定の為、一時的falseにする
                    if (CheckAgeRange(db, 0, "1"))
                    {
                        //E002013：未定。
                        //var msg = DaMessageService.GetMsg(EnumMessage.E002013, "対象年齢");
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
            //乳幼児（フリー）項目テーブル
            if (req.delflg)
            {
                //全ての詳細内容削除の場合
                if (!db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, req.atenano).Exists())
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "削除対象", "乳幼児（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else
            {
                //選択中の履歷のみ削除の場合
                if (!db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, req.atenano, req.kaisu).Exists())
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "削除対象", "乳幼児（フリー）項目テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 詳細メニューの文字色を取得
        /// </summary>
        public static string GetMenuStatus(DaDbContext db, string bosikbn, string menucd, string atenano)
        {
            var syosaitabdtl = db.tm_bhkksyosaitab.SELECT.WHERE.ByKey(bosikbn, menucd).GetDtoList().Select(e => e.jigyocd);
            foreach (var jigyocd in syosaitabdtl)
            {
                //①対応したタブが１つでもデータ入力済みの場合、「詳細メニュー」ボタンの文字色を水色とする。
                if (db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, atenano).Exists())
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
        public static string GetTabStatus(DaDbContext db, tm_bhkksyosaitabDto dto, string atenano)
        {
            //①対応したタブがデータ入力済みの場合、詳細タブの文字色を水色とする。
            if (db.tt_bhnyfree.SELECT.WHERE.ByKey(dto.jigyocd, atenano).Exists())
            {
                return ボタン文字色._1;           //水色
            }

            //ボタン文字色処理しない
            return ボタン文字色._0;               //無色
        }

        /// <summary>
        ///新規登録する際に、履歴回数を付与（最大＋１）
        /// </summary>
        private static int GetNewkaisu(DaDbContext db, string jigyocd, string atenano)
        {
            //乳幼児（フリー）項目テーブル（フリーテーブル）
            var mdtl = db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, atenano).GetDtoList();
            if (mdtl == null || mdtl.Count == 0) { return (1); }
            return (mdtl.Select(e => e.edano).Max() + 1);
        }

        /// <summary>
        /// フリー項目の数値項目値を取得
        /// </summary>
        private static object GetFreeNumValue(DaDbContext db, SaveRequest req, string jigyocd, string itemcd)
        {
            //乳幼児（フリー）項目テーブル
            var dto = db.tt_bhnyfree.GetDtoByKey(jigyocd, req.atenano, req.kaisu, itemcd);

            if (dto != null) { return dto.numvalue!; }
            else { return 0; }
        }

        /// <summary>
        /// フリー項目の文字項目値を取得
        /// </summary>
        private static string GetFreeStrValue(DaDbContext db, SaveRequest req, string jigyocd, string itemcd)
        {
            //乳幼児（フリー）項目テーブル
            var dto = db.tt_bhnyfree.GetDtoByKey(jigyocd, req.atenano, req.kaisu, itemcd);

            if (dto != null) { return dto.strvalue!; }
            else { return string.Empty; }
        }

        /// <summary>
        ///新規登録する際に、枝番を付与（最大＋１）
        /// </summary>
        private static int GetMaxEdano(DaDbContext db, SaveRequest req, string jigyocd)
        {
            var edano = 0;

            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     //宛名番号(atenano)
                    break;

                case PATTERN_2:     //宛名番号(atenano)、枝番(edano)
                case PATTERN_3:     //乳幼児健診コード(nykensincd)、宛名番号(atenano)、枝番(edano)
                    //乳幼児（フリー）項目テーブル
                    var mdtl = db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, req.atenano).GetDtoList();
                    if (mdtl == null || mdtl.Count == 0) { edano = 1; }
                    edano = mdtl.Select(e => e.edano).Max() + 1;
                    break;
                 default:
                    break;
            }
            return edano;
        }

        /// <summary>
        /// 画面のデータ操作区分取得
        /// </summary>
        public static EnumActionType? GetKBN(DaDbContext db, string freetable, string jigyocd, string atenano, int kaisu)
        {
            EnumActionType? kbn = null;

            if (CheckDataExist(db, freetable, jigyocd, atenano, kaisu))
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
        ///データの存在チェック（検索一覧の詳細内容）
        /// </summary>
        public static string GetDataCountSql(DaDbContext db, string freetable, string nykensincd, string atenano)
        {
            var sql = string.Empty;

            sql = $"{sql}SELECT{SPACE}Count(*){SPACE}AS{SPACE}CNT{C_LF}";
            sql = $"{sql}FROM{SPACE}{freetable}{C_LF}";
            sql = $"{sql}WHERE{SPACE}1=1{C_LF}";
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            if (!string.IsNullOrEmpty(nykensincd)) { sql = $"{sql}AND{SPACE}nykensincd{SPACE}={SPACE}'{nykensincd}'{C_LF}"; }

            return sql;
        }

        /// <summary>
        /// 乳幼児の詳細内容を取得
        /// </summary>
        public static string GetSyosaiStr(DaDbContext db, string bosikbn, string atenano, long torokuno)
        {
            Dictionary<string, string> MenuDic = new Dictionary<string, string>();
            Dictionary<string, string> JigyoDic = new Dictionary<string, string>();

            FrResult result = new FrResult();

            var str = string.Empty;

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
                var tableid = FixTblDic[CStr(dto.jigyocd)];             //固定テーブル名
                var nykensincd = NykensinDic[CStr(dto.jigyocd)];        //乳幼児健診コード

                if (string.IsNullOrEmpty(tableid)) { continue; }

                var sql = GetDataCountSql(db, tableid, nykensincd, atenano);
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
        ///データ存在チェック
        /// </summary>
        private static bool CheckDataExist(DaDbContext db, string freetable, string jigyocd, string atenano, int kaisu)
        {
            //存在チェック
            if (db.tt_bhnyfree.SELECT.WHERE.ByKey(jigyocd, atenano, kaisu).Exists()) { return true; }

            return false;
        }

        /// <summary>
        ///画面上回数リストを取得
        /// </summary>
        public static DataTable GetKaisuDtl(DaDbContext db, string freetable, string jigyocd, string atenano)
        {
            FrResult result = new FrResult();

            var sql = GetKaisuListSql(db, freetable, jigyocd, atenano);
            DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            return dt;
        }

        //================================================== SQL文取得 ==================================================
        /// <summary>
        ///回数リストを取得SQL
        /// </summary>
        private static string GetKaisuListSql(DaDbContext db, string freetable, string jigyocd, string atenano)
        {
            var sql = string.Empty;

            switch (PatternDic[jigyocd])
            {
                case PATTERN_1:     // 宛名番号(atenano)
                    sql = $"{sql}SELECT{SPACE}0{SPACE}AS{SPACE}kaisu{C_LF}";
                    return sql;
                case PATTERN_2:     // 宛名番号(atenano)、枝番(edano)
                case PATTERN_3:     // 乳幼児健診コード(nykensincd)、宛名番号(atenano)、枝番(edano)
                    sql = $"{sql}SELECT{SPACE}DISTINCT{SPACE}edano{SPACE}AS{SPACE}kaisu{C_LF}";
                    break;
                default:
                    sql = $"{sql}SELECT{SPACE}0{SPACE}AS{SPACE}kaisu{C_LF}";
                    return sql;
            }
            sql = $"{sql}FROM{SPACE}{freetable}{C_LF}";
            sql = $"{sql}WHERE{SPACE}1=1{C_LF}";
            sql = $"{sql}AND{SPACE}jigyocd{SPACE}={SPACE}'{jigyocd}'{C_LF}";
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            sql = $"{sql}ORDER BY{SPACE}edano{C_LF}";

            return sql;
        }

        /// <summary>
        ///該当業務の固定テーブルを登録処理
        /// </summary>
        private static bool FixTblProc(DaDbContext db, SaveRequest req, string jigyocd, EnumActionType? kbn)
        {
            var nykensincd = NykensinDic[CStr(jigyocd)];        //乳幼児健診コード

            switch (jigyocd)
            {
                case JIGYO_00014:       // 出生時
                    var freedtl_101 = new List<tt_bhnysyussyojijokyoDto>();
                    var dto_101 = new tt_bhnysyussyojijokyoDto() 
                    {
                        atenano = req.atenano,
                        torokuno = CLng(GetFixValue(req.fixiteminfo, "torokuno")),
                        torokunorenban = CInt(GetFixValue(req.fixiteminfo, "torokunorenban")),
                        hahaoyaatenano = CStr(GetFixValue(req.fixiteminfo, "hahaoyaatenano")),
                        titioyaatenano = CStr(GetFixValue(req.fixiteminfo, "titioyaatenano")),
                        hogosyaatenano = CStr(GetFixValue(req.fixiteminfo, "hogosyaatenano")),
                    };

                    freedtl_101.Add(dto_101);
                    if (db.tt_bhnysyussyojijokyo.SELECT.WHERE.ByKey(req.atenano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnysyussyojijokyo.DELETE.WHERE.ByKey(req.atenano).Execute();
                            db.tt_bhnysyussyojijokyo.INSERT.Execute(freedtl_101);
                        }
                        else { db.tt_bhnysyussyojijokyo.UPDATE.Execute(freedtl_101); }  //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnysyussyojijokyo.INSERT.Execute(freedtl_101);
                    }
                    break;

                case JIGYO_00016:     //スクリーニング検査費用助成（103 -- 00016）
                    var freedtl_103 = new List<tt_bhnytyokakukensahiyojoseiDto>();
                    var dto_103 = new tt_bhnytyokakukensahiyojoseiDto()
                    {
                        atenano = req.atenano,
                        edano = req.kaisu,
                        sinseiymd = CStr(GetFixValue(req.fixiteminfo, "sinseiymd")),
                    };
                    freedtl_103.Add(dto_103);
                    if (db.tt_bhnytyokakukensahiyojosei.SELECT.WHERE.ByKey(req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnytyokakukensahiyojosei.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute();
                            db.tt_bhnytyokakukensahiyojosei.INSERT.Execute(freedtl_103);
                        }
                        else { db.tt_bhnytyokakukensahiyojosei.UPDATE.Execute(freedtl_103); }   //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnytyokakukensahiyojosei.INSERT.Execute(freedtl_103);
                    }
                    break;

                case JIGYO_00015:     //聴覚検査結果（102 -- 00015）
                    var freedtl_102 = new List<tt_bhnytyokakukensakekkaDto>();
                    var dto_102 = new tt_bhnytyokakukensakekkaDto()
                    {
                        atenano = req.atenano,
                    };
                    freedtl_102.Add(dto_102);
                    if (db.tt_bhnytyokakukensakekka.SELECT.WHERE.ByKey(req.atenano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnytyokakukensakekka.DELETE.WHERE.ByKey(req.atenano).Execute();
                            db.tt_bhnytyokakukensakekka.INSERT.Execute(freedtl_102);
                        }
                        else { db.tt_bhnytyokakukensakekka.UPDATE.Execute(freedtl_102); }   //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnytyokakukensakekka.INSERT.Execute(freedtl_102); 
                    }
                    break;

                case JIGYO_00018:       // 3～4か月児健診（104 -- 健診結果）
                case JIGYO_00020:       // 1歳6か月児健診（106 -- 健診結果）
                case JIGYO_00023:       // 3歳児健診（109 -- 健診結果）
                    //健診結果（00018／00020／00023）
                    var freedtl_1 = new List<tt_bhnykensinkekkaDto>();                      //乳幼児健診結果（固定項目）テーブル
                    var dto_1 = new tt_bhnykensinkekkaDto()
                    {
                        nykensincd = nykensincd,                                            //乳幼児健診コード
                        atenano = req.atenano,                                              //宛名番号
                        edano = req.kaisu,                                                  //枝番
                        jusinymd = CStr(GetFixValue(req.fixiteminfo, "jusinymd")),          //健診受診日
                    };
                    freedtl_1.Add(dto_1);
                    if (db.tt_bhnykensinkekka.SELECT.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnykensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute();
                            db.tt_bhnykensinkekka.INSERT.Execute(freedtl_1);
                        }
                        else { db.tt_bhnykensinkekka.UPDATE.Execute(freedtl_1); }           //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnykensinkekka.INSERT.Execute(freedtl_1);
                    }
                    break;

                case JIGYO_00019:       // 3～4か月児健診（105 -- アンケート）
                case JIGYO_00021:       // 1歳6か月児健診（107 -- アンケート）
                case JIGYO_00024:       // 3歳児健診（110 -- アンケート）
                    var freedtl_2 = new List<tt_bhnykensinanketoDto>();                     //乳幼児健診アンケート（固定項目）テーブル
                    var dto_2 = new tt_bhnykensinanketoDto()
                    {
                        nykensincd = nykensincd,                                            //乳幼児健診コード
                        atenano = req.atenano,                                              //宛名番号
                        edano = req.kaisu,                                                  //枝番
                    };
                    freedtl_2.Add(dto_2);
                    if (db.tt_bhnykensinanketo.SELECT.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnykensinanketo.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute();
                            db.tt_bhnykensinanketo.INSERT.Execute(freedtl_2);
                        }
                        else { db.tt_bhnykensinanketo.UPDATE.Execute(freedtl_2); }          //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnykensinanketo.INSERT.Execute(freedtl_2); 
                    }
                    break;

                case JIGYO_00022:       // 1歳6か月児健診（108 -- アンケート）
                case JIGYO_00025:       // 3歳児健診（111 -- アンケート）
                    var freedtl_3 = new List<tt_bhnysikakensinkekkaDto>();                  //乳幼児歯科健診結果（固定項目）テーブル
                    var dto_3 = new tt_bhnysikakensinkekkaDto()
                    {
                        nykensincd = nykensincd,                                            //乳幼児健診コード
                        atenano = req.atenano,                                              //宛名番号
                        edano = req.kaisu,                                                  //枝番
                        sikajusinymd = CStr(GetFixValue(req.fixiteminfo, "sikajusinymd")),  //歯科健診受診日
                    };
                    freedtl_3.Add(dto_3);
                    if (db.tt_bhnysikakensinkekka.SELECT.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnysikakensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute();
                            db.tt_bhnysikakensinkekka.INSERT.Execute(freedtl_3);
                        }
                        else { db.tt_bhnysikakensinkekka.UPDATE.Execute(freedtl_3); }   //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnysikakensinkekka.INSERT.Execute(freedtl_3);
                    }
                    break;

                case JIGYO_00026:       // 健診受診履歴-健診履歴（112)
                    var freedtl_112 = new List<tt_bhnykensinjusinrekiDto>();                        //健診受診履歴（固定項目）テーブル
                    var dto_112 = new tt_bhnykensinjusinrekiDto()
                    {
                        atenano = req.atenano,                                                      //宛名番号
                        haakuymd = CStr(GetFixValue(req.fixiteminfo, "haakuymd")),                  //把握日
                    };
                    freedtl_112.Add(dto_112);
                    if (db.tt_bhnykensinjusinreki.SELECT.WHERE.ByKey(req.atenano).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnykensinjusinreki.DELETE.WHERE.ByKey(req.atenano).Execute();
                            db.tt_bhnykensinjusinreki.INSERT.Execute(freedtl_112);
                        }
                        else { db.tt_bhnykensinjusinreki.UPDATE.Execute(freedtl_112); }             //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnykensinjusinreki.INSERT.Execute(freedtl_112);
                    }
                    break;

                case JIGYO_00027:       // 精密健診--依頼（113）

                    //依頼（113 -- 00029）
                    var freedtl_113 = new List<tt_bhnyseikeniraiDto>();                         //精密健診の依頼（固定項目）テーブル
                    var dto_113 = new tt_bhnyseikeniraiDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        edano = req.kaisu,                                                      //枝番
                        haakukeiro = CStr(GetFixValue(req.fixiteminfo, "haakukeiro")),          //把握経路
                    };
                    freedtl_113.Add(dto_113);
                    if (db.tt_bhnyseikenirai.SELECT.WHERE.ByKey(req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnyseikenirai.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute();
                            db.tt_bhnyseikenirai.INSERT.Execute(freedtl_113);
                        }
                        else { db.tt_bhnyseikenirai.UPDATE.Execute(freedtl_113); }              //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnyseikenirai.INSERT.Execute(freedtl_113);
                    }
                    break;

                case JIGYO_00028:       // 精密健診--健診結果（114）
                    var freedtl_114 = new List<tt_bhnyseikenkekkaDto>();
                    var dto_114 = new tt_bhnyseikenkekkaDto()
                    {
                        atenano = req.atenano,                                                  //宛名番号
                        edano = req.kaisu,                                                      //枝番
                        seikenjissiymd = CStr(GetFixValue(req.fixiteminfo, "seikenjissiymd")),  //精密健診実施日
                        haakukeiro = CStr(GetFixValue(req.fixiteminfo, "haakukeiro")),          //把握経路
                    };
                    freedtl_114.Add(dto_114);
                    if (db.tt_bhnyseikenkekka.SELECT.WHERE.ByKey(req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnyseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute();
                            db.tt_bhnyseikenkekka.INSERT.Execute(freedtl_114);
                        }
                        else { db.tt_bhnyseikenkekka.UPDATE.Execute(freedtl_114); }             //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnyseikenkekka.INSERT.Execute(freedtl_114);
                    }
                    break;

                case JIGYO_00029:     // 未受診者勧奨（115)
                    var freedtl_115 = new List<tt_bhnymijusinsyakansyoDto>();                       //未受診者勧奨（固定項目）テーブル
                    var dto_115 = new tt_bhnymijusinsyakansyoDto()
                    {
                        atenano = req.atenano,                                                      //宛名番号
                        edano = req.kaisu,                                                          //枝番
                        mijusinhaakuymd = CStr(GetFixValue(req.fixiteminfo, "mijusinhaakuymd")),    //未受診把握日
                        mijusinjigyo = CStr(GetFixValue(req.fixiteminfo, "mijusinjigyo")),          //未受診事業

                    };
                    freedtl_115.Add(dto_115);
                    if (db.tt_bhnymijusinsyakansyo.SELECT.WHERE.ByKey(req.atenano, req.kaisu).Exists())
                    {   //存在する場合
                        if (kbn == EnumActionType.Insert)
                        {
                            //新規の場合、先ず削除してから追加
                            db.tt_bhnymijusinsyakansyo.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute();
                            db.tt_bhnymijusinsyakansyo.INSERT.Execute(freedtl_115);
                        }
                        else { db.tt_bhnymijusinsyakansyo.UPDATE.Execute(freedtl_115); }            //更新の場合
                    }
                    else
                    {
                        //存在しない場合
                        db.tt_bhnymijusinsyakansyo.INSERT.Execute(freedtl_115);
                    }
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
            var nykensincd = NykensinDic[CStr(jigyocd)];        //乳幼児健診コード

            switch (jigyocd)
            {
                case JIGYO_00014:       // 出生時「出生時状況（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnysyussyojijokyo.DELETE.WHERE.ByKey(req.atenano).Execute(); }             //全て
                    else { db.tt_bhnysyussyojijokyo.DELETE.WHERE.ByKey(req.atenano).Execute(); }                        //選択中
                    break;
                case JIGYO_00016:     //スクリーニング検査費用助成（103 -- 00016）「新生児聴覚スクリーニング検査費用助成（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnytyokakukensahiyojosei.DELETE.WHERE.ByKey(req.atenano).Execute(); }      //全て
                    else { db.tt_bhnytyokakukensahiyojosei.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute(); }      //選択中
                    break;
                case JIGYO_00015:     //聴覚検査結果（102 -- 00015）「新生児聴覚検査結果（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnytyokakukensakekka.DELETE.WHERE.ByKey(req.atenano).Execute(); }          //全て
                    else { db.tt_bhnytyokakukensakekka.DELETE.WHERE.ByKey(req.atenano).Execute(); }                     //選択中
                    break;
                case JIGYO_00018:       // 3～4か月児健診（104 -- 健診結果）
                case JIGYO_00020:       // 1歳6か月児健診（106 -- 健診結果）
                case JIGYO_00023:       // 3歳児健診（109 -- 健診結果） 「乳幼児健診結果（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnykensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano).Execute(); }    //全て
                    else { db.tt_bhnykensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute(); }	//選択中
                    break;
                case JIGYO_00019:       // 3～4か月児健診（105 -- アンケート）
                case JIGYO_00021:       // 1歳6か月児健診（107 -- アンケート）
                case JIGYO_00024:       // 3歳児健診（110 -- アンケート）「乳幼児健診アンケート（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnykensinanketo.DELETE.WHERE.ByKey(nykensincd, req.atenano).Execute(); }   //全て
                    else { db.tt_bhnykensinanketo.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute(); }   //選択中
                    break;
                case JIGYO_00022:       // 1歳6か月児健診（108 -- アンケート）
                case JIGYO_00025:       // 3歳児健診（111 -- アンケート）「乳幼児歯科健診結果（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnysikakensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano).Execute(); }//全て
                    else { db.tt_bhnysikakensinkekka.DELETE.WHERE.ByKey(nykensincd, req.atenano, req.kaisu).Execute(); }//選択中
                    break;
                case JIGYO_00026:       // 健診受診履歴-健診履歴（112)「健診受診履歴（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnykensinjusinreki.DELETE.WHERE.ByKey(req.atenano).Execute(); }            //全て
                    else { db.tt_bhnykensinjusinreki.DELETE.WHERE.ByKey(req.atenano).Execute(); }                       //選択中
                    break;
                case JIGYO_00027:       // 精密健診--依頼（113）「精密健診の依頼（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnyseikenirai.DELETE.WHERE.ByKey(req.atenano).Execute(); }                 //全て
                    else { db.tt_bhnyseikenirai.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute(); }                 //選択中
                    break;
                case JIGYO_00028:       // 精密健診--健診結果（114）「乳幼児精密健診結果（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnyseikenkekka.DELETE.WHERE.ByKey(req.atenano).Execute(); }                //全て
                    else { db.tt_bhnyseikenkekka.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute(); }                //選択中
                    break;
                case JIGYO_00029:     // 未受診者勧奨（115)「未受診者勧奨（固定項目）テーブル」
                    if (req.delflg) { db.tt_bhnymijusinsyakansyo.DELETE.WHERE.ByKey(req.atenano).Execute(); }           //全て
                    else { db.tt_bhnymijusinsyakansyo.DELETE.WHERE.ByKey(req.atenano, req.kaisu).Execute(); }           //選択中
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        ///乳幼児固定項目情報リストを取得
        /// </summary>
        private static FixItemDispInfoVM GetFixItem(DaDbContext db, string tableid, string itemcdnm, string pattern, string nykensincd, string atenano, int edano, int no)
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
            if (!string.IsNullOrEmpty(nykensincd))
            {
                sql = $"{sql}AND{SPACE}nykensincd{SPACE}={SPACE}'{nykensincd}'{C_LF}";
            }
            sql = $"{sql}AND{SPACE}atenano{SPACE}={SPACE}'{atenano}'{C_LF}";
            if (!pattern.Equals(PATTERN_1))
            {
                sql = $"{sql}AND{SPACE}edano{SPACE}={SPACE}{edano}{C_LF}";
            }

            DataTable dt = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));
            if (dt.Rows.Count > 0) { vm.value = dt.Rows[0][0]; }    //値

            return vm;
        }

        /// <summary>
        ///乳幼児特定業務の固定項目情報リストを取得
        /// </summary>
        private static List<FixItemDispInfoVM> GetFixItemList(DaDbContext db, string jigyocd, string atenano, int kaisu, string fixtable, string fixitem)
        {
            var list = new List<FixItemDispInfoVM>();
            if (string.IsNullOrEmpty(fixitem)) { return list; }

            //乳幼児健診コードを取得
            var nykensincd = NykensinDic[CStr(jigyocd)];        //乳幼児健診コード

            //表示順番初期化
            var i = 1;

            var arr = fixitem.Split($"{COMMA}");
            foreach (var str in arr)
            {
                //固定項目情報取得
                var vm = GetFixItem(db, fixtable, str, PatternDic[jigyocd], nykensincd, atenano, kaisu, i);

                if (vm == null) { return list; }
                list.Add(vm);
                i++;
            };

            return list;
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
    }
}