// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 予防接種情報管理
// 　　　　　　サービス処理
// 作成日　　: 2024.06.18
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaHanyoService;
using static BCC.Affect.DataAccess.DaNameService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaStrPool;
using Org.BouncyCastle.Ocsp;

namespace BCC.Affect.Service.AWYS00101G
{
    [DisplayName("予防接種情報管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWYS00101G = "AWYS00101G";

        //定数定義
        private const string PROC_NAME_01 = "sp_awys00101g_01";     //接種情報（生涯1回／複数回）情報取得
        private const string PROC_NAME_02 = "sp_awys00101g_02";     //接種依頼情報一覧取得

        ///<summary>
        ///予防接種事業コード
        ///</summary>
        public class 予防接種事業コード
        {
            ///<summary>接種情報事業コード</summary>
            public const string _接種事業コード = "00001";
            ///<summary>接種依頼情報事業コード</summary>
            public const string _接種依頼事業コード = "00002";
            ///<summary>その他情報事業コード</summary>
            public const string _その他事業コード = "00003";
            ///<summary>風疹抗体情報事業コード</summary>
            public const string _風疹抗体事業コード = "00004";
        }

        ///<summary>
        ///詳細画面区分
        ///</summary>
        public class 詳細画面区分
        {
            ///<summary>接種情報_生涯1回</summary>
            public const string _生涯1回 = "1";
            ///<summary>接種情報_複数回</summary>
            public const string _複数回 = "2";
            ///<summary>接種依頼</summary>
            public const string _接種依頼 = "3";
            ///<summary>風疹抗体</summary>
            public const string _風疹抗体 = "4";
            ///<summary>その他情報</summary>
            public const string _その他 = "5";
        }

        ///<summary>
        ///接種間隔単位
        ///</summary>
        public class 接種間隔単位
        {
            ///<summary>日</summary>
            public const string _日 = "1";
            ///<summary>週</summary>
            public const string _週 = "2";
            ///<summary>月</summary>
            public const string _月 = "3";
            ///<summary>年</summary>
            public const string _年 = "4";
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(CommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitDetail(db, req.atenano, req.token, req.userid, req.regsisyo);
            });
        }

        [DisplayName("予防接種情報画面検索処理(検索画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("予防接種情報画面検索処理(情報一覧)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("接種情報（生涯1回）タブ画面検索処理(情報一覧)")]
        public SearchDetailOneResponse SearchDetailOne(SearchDetailOneRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetailOne(db, req);
            });
        }

        [DisplayName("接種情報（複数回）タブ画面検索処理(情報一覧)")]
        public SearchDetailMultiResponse SearchDetailMulti(SearchDetailMultiRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetailMulti(db, req);
            });
        }

        [DisplayName("接種情報（罹患情報）タブ画面検索処理(情報一覧)")]
        public SearchDetailRikanResponse SearchDetailRikan(SearchDetailRikanRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetailRikan(db, req);
            });
        }

        [DisplayName("接種依頼情報タブ画面検索処理(情報一覧)")]
        public SearchDetailIraiResponse SearchDetailIrai(SearchDetailIraiRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetailIrai(db, req);
            });
        }

        [DisplayName("その他情報タブ画面検索処理(情報一覧)")]
        public SearchDetailOtherResponse SearchDetailOther(SearchDetailOtherRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetailOther(db, req);
            });
        }

        [DisplayName("接種情報詳細画面検索処理")]
        public SearchSessyuDetailResponse SearchSessyuDetail(SearchSessyuDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSessyuDetail(db, req);
            });
        }

        [DisplayName("接種依頼情報詳細画面検索処理")]
        public SearchSessyuIraiDetailResponse SearchSessyuIraiDetail(SearchSessyuIraiDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSessyuIraiDetail(db, req);
            });
        }

        [DisplayName("風疹抗体検査情報詳細画面検索処理")]
        public SearchFusinDetailResponse SearchFusinDetail(SearchFusinDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchFusinDetail(db, req);
            });
        }

        [DisplayName("保存処理(接種情報)")]
        public SaveSessyuResponse SaveSessyu(SaveSessyuRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveSessyu(db, req);
            });
        }

        [DisplayName("保存処理(罹患情報)")]
        public SaveRikanResponse SaveRikan(SaveRikanRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveRikan(db, req);
            });
        }

        [DisplayName("保存処理(接種依頼情報)")]
        public CommonResponse SaveSessyuIrai(SaveSessyuIraiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveSessyuIrai(db, req);
            });
        }

        [DisplayName("保存処理(その他情報)")]
        public CommonResponse SaveOther(SaveOtherRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveOther(db, req);
            });
        }

        [DisplayName("保存処理(風疹抗体検査情報)")]
        public CommonResponse SaveFusin(SaveFusinRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return SaveFusin(db, req);
            });
        }

        [DisplayName("削除処理(接種情報)")]
        public CommonResponse DeleteSessyu(DeleteSessyuRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return DeleteSessyu(db, req);
            });
        }

        [DisplayName("削除処理(接種依頼情報)")]
        public CommonResponse DeleteSessyuIrai(DeleteSessyuIraiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return DeleteSessyuIrai(db, req);
            });
        }

        [DisplayName("削除処理(風疹抗体検査情報)")]
        public CommonResponse DeleteFusin(DeleteFusinRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return DeleteFusin(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        ///予防接種情報画面検索処理(検索画面)
        /// </summary>
        public SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {

            var res = new SearchListResponse();
            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し
            }

            //-------------------------------------------------------------
            //２.条件設定
            //-------------------------------------------------------------
            //個人番号復号化
            req.SetPersonalno();
            //固定の検索条件
            var fixedCondition = Common.Converter.GetFixedCondition(req);
            //詳細の検索条件
            var conditon = CmSearchUtil.GetSearchJyoken(db, AWYS00101G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //検索結果
            var result = DaFreeQuery.GetSessyuQuery(db, conditon, req.orderby, true);
            //総件数
            var total = result.Count;
            //結果一覧
            var pageData = result.Data;
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //ページャー設定
            res.SetPageInfo(total, req.pagesize);
            //画面項目設定
            res.kekkalist = Wraper.GetVMList(db, pageData.Rows, alertviewflg, adrsFlg);

            //正常返し
            return res;
        }

        /// <summary>
        ///初期化処理(詳細画面)
        /// </summary>
        public InitDetailResponse InitDetail(DaDbContext db, string atenano, string token, string userid, string? regsisyo)
        {
            var res = new InitDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //個人基本情報取得
            var dto = db.tt_afatena.GetDtoByKey(atenano);

            //存在チェック
            if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, token, userid, regsisyo);

            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, token, userid, regsisyo, AWYS00101G);

            //個人番号操作フラグ
            var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.headerinfo = Wraper.GetSessyuHeaderVM(db, dto, alertviewflg, adrsFlg, string.Empty);

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, atenano, pFlg, EnumAtenaActionType.検索);

            //正常返し
            return res;
        }

        /// <summary>
        ///予防接種情報画面検索処理(情報一覧)
        /// </summary>
        public SearchDetailResponse SearchDetail(DaDbContext db, SearchDetailRequest req)
        {
            var res = new SearchDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、ヘッダー情報を取得
            var hres = InitDetail(db, req.atenano, req.token, req.userid, req.regsisyo);
            res.headerinfo = hres.headerinfo;

            //B、接種種類フィルター区分（初期表示は生涯1回タブ）
            res.sessyufilterkbnlist = GetSessyuFilterKbnList(db, 詳細画面区分._生涯1回);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //C、予防接種情報一覧を取得する
            res.kekkalist = GetKekkaList(db, req.atenano, EnumHanyoKbn.接種種類詳細コード, req.rirekihyoji, (int)Enum生涯１回フラグ.生涯1回, req.pagenum, req.pagesize, req.orderby);

            //ページャー設定
            res.SetPageInfo(res.kekkalist.Count, req.pagesize);

            //履歴表示フラグ（リクエストでの履歴表示フラグをそのまま返す）
            res.rirekihyoji = req.rirekihyoji;

            //正常返し
            return res;
        }

        /// <summary>
        ///接種情報（生涯1回）タブ検索処理(情報一覧)
        /// </summary>
        public SearchDetailOneResponse SearchDetailOne(DaDbContext db, SearchDetailOneRequest req)
        {
            var res = new SearchDetailOneResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、接種種類フィルター区分
            res.sessyufilterkbnlist = GetSessyuFilterKbnList(db, 詳細画面区分._生涯1回);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //B、予防接種情報一覧を取得する
            res.kekkalist = GetKekkaList(db, req.atenano, EnumHanyoKbn.接種種類詳細コード, req.rirekihyoji, (int)Enum生涯１回フラグ.生涯1回, req.pagenum, req.pagesize, req.orderby);

            //C、ページャー設定
            res.SetPageInfo(res.kekkalist.Count, req.pagesize);

            //履歴表示フラグ（リクエストでの履歴表示フラグをそのまま返す）
            res.rirekihyoji = req.rirekihyoji;

            //正常返し
            return res;
        }

        /// <summary>
        ///接種情報（複数回）タブ検索処理(情報一覧)
        /// </summary>
        public SearchDetailMultiResponse SearchDetailMulti(DaDbContext db, SearchDetailMultiRequest req)
        {
            var res = new SearchDetailMultiResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、接種種類フィルター区分
            res.sessyufilterkbnlist = GetSessyuFilterKbnList(db, 詳細画面区分._複数回);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //B、予防接種情報一覧を取得する
            res.kekkalist = GetKekkaList(db, req.atenano, EnumHanyoKbn.接種種類詳細コード, true, (int)Enum生涯１回フラグ.生涯複数回, req.pagenum, req.pagesize, req.orderby);

            //C、ページャー設定
            res.SetPageInfo(res.kekkalist.Count, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        ///接種情報（罹患情報）タブ検索処理(情報一覧)
        /// </summary>
        public SearchDetailRikanResponse SearchDetailRikan(DaDbContext db, SearchDetailRikanRequest req)
        {
            var res = new SearchDetailRikanResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //罹患テーブル
            var dtl = db.tt_ysrikan.SELECT.WHERE.ByKey(req.atenano).GetDtoList().OrderBy(e => e.rikancd).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            res.kekkalist = Wraper.GetVMList(db, dtl, sisyoList);

            //正常返し
            return res;
        }

        /// <summary>
        ///接種依頼情報タブ検索処理(情報一覧)
        /// </summary>
        public SearchDetailIraiResponse SearchDetailIrai(DaDbContext db, SearchDetailIraiRequest req)
        {
            var res = new SearchDetailIraiResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、パラメータ取得
            var param = Converter.GetParameters(req.atenano);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //B、接種依頼情報一覧を取得する
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_02, param, req.pagenum, req.pagesize, req.orderby);

            //C、画面項目設定
            res.kekkalist = Wraper.GetIraiVMList(db, pageList.dataTable.Rows);       //接種依頼情報一覧

            //D、ページャー設定
            res.SetPageInfo(pageList.TotalCount, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        ///その他情報タブ検索処理(情報一覧) -- 個人
        /// </summary>
        public SearchDetailOtherResponse SearchDetailOther(DaDbContext db, SearchDetailOtherRequest req)
        {
            var res = new SearchDetailOtherResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、グループ１／グループ２設定
            res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.その他情報グループ1)).ToString());
            res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.その他情報グループ2)).ToString());

            //B、固定項目処理
            //データ操作区分取得
            var kbn = GetKojinKBN(db, req.atenano, 詳細画面区分._その他);

            //予防接種その他テーブルから該当宛名番号の情報を取得する
            var sonotadto = db.tt_yssonota.GetDtoByKey(req.atenano);

            //C、フリー項目処理
            //予防接種事業コードを取得
            var jigyocd = 予防接種事業コード._その他事業コード;

            //予防接種（フリー）項目コントロールマスタ情報を取得する
            var freeMstDtl = db.tm_ysfreeitem.SELECT.WHERE.ByKey(jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();              //表示順ソート：並び順

            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { req.atenano, item.itemcd });
            }

            //全項目データ
            var dataDtl = db.tt_yskojinfree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWYS00101G, 拡張_予約_保健指導業務区分._03);

            //編集フラグ
            res.editflg = string.IsNullOrEmpty(sonotadto?.regsisyo) || sisyoList.Contains(CStr(sonotadto?.regsisyo));

            //固定項目一覧（その他情報タブには固定項目がない為、設定していない）
            res.fixitemlist = new List<FixItemDispInfoVM>();

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWYS00101G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// 接種情報詳細画面検索処理
        /// </summary>
        private SearchSessyuDetailResponse SearchSessyuDetail(DaDbContext db, SearchSessyuDetailRequest req)
        {
            var res = new SearchSessyuDetailResponse();
            var sessyukenno = string.Empty;

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の個人情報を取得する
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //B、固定項目処理
            //データ操作区分取得
            var kbn = GetKBN(db, req.atenano, req.sessyucd, req.kaisu, req.edano);

            //新規の場合、最新枝番を取得
            if (kbn == EnumActionType.Insert && req.edano == 0) { req.edano = GetNewEdano(db, req.atenano, req.sessyucd, req.kaisu); }

            //予防接種テーブルから該当宛名番号指定した接種種類コード／回数／枝番の情報を取得する
            var sessyudto = db.tt_yssessyu.GetDtoByKey(req.atenano, req.sessyucd, req.kaisu, req.edano);
            if (sessyudto != null) { sessyukenno = sessyudto.sessyukenno; }

            //C、フリー項目処理
            //予防接種事業コードを取得
            var jigyocd = 予防接種事業コード._接種事業コード;

            //予防接種（フリー）項目コントロールマスタ
            var freeMstDtl = db.tm_ysfreeitem.SELECT.WHERE.ByKey(jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();          //表示順ソート：並び順

            //予防接種（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { req.atenano, req.sessyucd, req.kaisu, req.edano, item.itemcd });
            }

            //全項目データ
            var dataDtl = db.tt_yssessyufree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //ヘッダー部情報設定
            res.headerinfo = Wraper.GetSessyuHeaderVM(db, atenadto, alertviewflg, adrsFlg, sessyukenno!);

            //編集フラグ
            //編集可能なのは最大枝番のデータのみとする、※確定、削除ボタンは、最大枝番データまたは新規データの編集時のみ活性状態
            res.editflg = (string.IsNullOrEmpty(sessyudto?.regsisyo) || sisyoList.Contains(CStr(sessyudto?.regsisyo))) && IsMaxEdano(db, req);

            //固定項目のドロップダウンリスト初期化
            res.fixiteminfo = InitFixList(db, req.syougaiflg);

            //固定項目設定
            res.fixiteminfo = Wraper.GetSessyuFixVM(db, sessyudto, res.fixiteminfo, kbn);   //接種情報一覧（固定情報）

            //フリー項目設定
            if (req.syougaiflg.Equals(詳細画面区分._生涯1回)) 
            {
                res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種情報生涯1回グループ1)).ToString());
                res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種情報生涯1回グループ2)).ToString());
            }
            else
            {
                res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種情報複数回グループ1)).ToString());
                res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種情報複数回グループ2)).ToString());
            }

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWYS00101G, 拡張_予約_保健指導業務区分._03);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWYS00101G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// 接種依頼情報詳細画面検索処理
        /// </summary>
        private SearchSessyuIraiDetailResponse SearchSessyuIraiDetail(DaDbContext db, SearchSessyuIraiDetailRequest req)
        {
            var res = new SearchSessyuIraiDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の個人情報を取得する
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //B、固定項目処理
            //データ操作区分取得
            var kbn = GetKBN(db, req.atenano, req.edano);

            //新規の場合、最新枝番を取得
            if (kbn == EnumActionType.Insert && req.edano == 0) { req.edano = GetNewEdano(db, req.atenano); }

            //B．予防接種依頼テーブルから該当宛名番号指定した枝番の情報を取得する
            var sessyuiraidto = db.tt_yssessyuirai.GetDtoByKey(req.atenano, req.edano);

            //C、フリー項目処理
            //予防接種事業コードを取得
            var jigyocd = 予防接種事業コード._接種依頼事業コード;

            //予防接種（フリー）項目コントロールマスタ
            var freeMstDtl = db.tm_ysfreeitem.SELECT.WHERE.ByKey(jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();          //表示順ソート：並び順

            //予防接種（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { req.atenano, req.edano, item.itemcd });
            }

            //全項目データ（予防接種依頼（フリー項目）テーブル）
            var dataDtl = db.tt_yssessyuiraifree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //ヘッダー部情報設定
            res.headerinfo = Wraper.GetSessyuHeaderVM(db, atenadto, alertviewflg, adrsFlg, string.Empty);

            //編集フラグ
            //編集可能なのは最大枝番のデータのみとする、※確定、削除ボタンは、最大枝番データまたは新規データの編集時のみ活性状態
            res.editflg = (string.IsNullOrEmpty(sessyuiraidto?.regsisyo) || sisyoList.Contains(CStr(sessyuiraidto?.regsisyo))) && IsMaxEdano(db, req);

            //固定項目のドロップダウンリスト初期化
            res.fixiteminfo = InitFixList(db);

            //予防接種依頼サブテーブルから接種種類リストを取得
            res.fixiteminfo.sessyusublist = GetSessyuSubList(db, res.fixiteminfo.sessyulist, req);

            //固定項目設定
            res.fixiteminfo = Wraper.GetSessyuIraiFixVM(db, sessyuiraidto, res.fixiteminfo, kbn);   //接種情報一覧（固定情報）

            //フリー項目設定
            res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種依頼情報グループ1)).ToString());
            res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種依頼情報グループ2)).ToString());

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWYS00101G, 拡張_予約_保健指導業務区分._03);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWYS00101G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// 風疹抗体検査情報詳細画面検索処理
        /// </summary>
        private SearchFusinDetailResponse SearchFusinDetail(DaDbContext db, SearchFusinDetailRequest req)
        {
            var res = new SearchFusinDetailResponse();
            var sessyukenno = string.Empty;

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の個人情報を取得する
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //B、固定項目処理
            //データ操作区分取得
            var kbn = GetKojinKBN(db, req.atenano, 詳細画面区分._風疹抗体);

            //B．風疹抗体検査テーブルから該当宛名番号の情報を取得する
            var fusindto = db.tt_ysfusinkotai.GetDtoByKey(req.atenano);
            if (fusindto != null) { sessyukenno = fusindto.sessyukenno; }

            //C、フリー項目処理
            //予防接種事業コードを取得
            var jigyocd = 予防接種事業コード._風疹抗体事業コード;

            //予防接種（フリー）項目コントロールマスタ
            var freeMstDtl = db.tm_ysfreeitem.SELECT.WHERE.ByKey(jigyocd).GetDtoList();
            freeMstDtl = freeMstDtl.OrderBy(e => e.orderseq).ToList();          //表示順ソート：並び順

            //予防接種依頼（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { req.atenano, item.itemcd });
            }

            //全項目データ（風しん抗体検査（フリー項目）テーブル）
            var dataDtl = db.tt_ysfusinkotaifree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

            //ヘッダー部情報設定
            res.headerinfo = Wraper.GetSessyuHeaderVM(db, atenadto, alertviewflg, adrsFlg, sessyukenno);

            //編集フラグ
            res.editflg = string.IsNullOrEmpty(fusindto?.regsisyo) || sisyoList.Contains(CStr(fusindto?.regsisyo));

            //固定項目のドロップダウンリスト初期化
            res.fixiteminfo = InitFusinFixList(db);

            //固定項目設定
            res.fixiteminfo = Wraper.GetFusinFixVM(db, fusindto, res.fixiteminfo, kbn);   //風疹抗体検査情報一覧（固定情報）

            //フリー項目設定
            res.grouplist1 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.風しん抗体検査情報グループ1)).ToString());
            res.grouplist2 = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.風しん抗体検査情報グループ2)).ToString());

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWYS00101G, 拡張_予約_保健指導業務区分._03);

            //フリー項目一覧
            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWYS00101G, patternno);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(接種情報詳細画面)
        /// </summary>
        private SaveSessyuResponse SaveSessyu(DaDbContext db, SaveSessyuRequest req)
        {
            var res = new SaveSessyuResponse();

            //接種種類（7桁）から接種種類コード（5桁）と回数を取得
            if (!string.IsNullOrEmpty(GetCd(req.fixiteminfo.sessyu)) && (GetCd(req.fixiteminfo.sessyu).Length == 7))
            {
                req.fixiteminfo.sessyucd = req.fixiteminfo.sessyu.Substring(0, 5);
                req.fixiteminfo.kaisu = req.fixiteminfo.sessyu.Substring(5, 2);
            }
            
            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano);

            //新規の場合（最新枝番を取得）
            if (kbn == EnumActionType.Insert && req.fixiteminfo.edano == 0) { req.fixiteminfo.edano = GetNewEdano(db, req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu); }

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, kbn, res)) { return res; }      //異常返し
                return res;                                         //正常返し
            }

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            var olddto = new tt_yssessyuDto();                      //予防接種テーブル
            var oldfreedtl = new List<tt_yssessyufreeDto>();        //予防接種（フリー項目）接種テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //接種固定項目情報を取得
                olddto = db.tt_yssessyu.GetDtoByKey(req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano);

                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種", tt_yssessyuDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }

                //接種情報フリー項目一覧
                oldfreedtl = db.tt_yssessyufree.SELECT.WHERE.ByKey(req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_yssessyuDto();                      //予防接種テーブル
            var newfreedtl = new List<tt_yssessyufreeDto>();        //予防接種（フリー項目）接種テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //予防接種テーブル（固定項目）
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //接種情報フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_yssessyufreeDto();
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
                //予防接種テーブル（固定項目）
                newdto = Converter.GetDto(newdto, req, kbn);

                //接種情報フリー項目一覧
                foreach (var dt in req.freeiteminfo)
                {
                    var newfreedto = new tt_yssessyufreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_yssessyu.INSERT.Execute(newdto);          //予防接種依頼テーブル

                //予防接種（フリー項目）接種テーブル
                db.tt_yssessyufree.DELETE.WHERE.ByKey(req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano).Execute();
                db.tt_yssessyufree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_yssessyu.UPDATE.Execute(newdto);          //予防接種依頼テーブル
                db.tt_yssessyufree.UPDATE.Execute(newfreedtl);  //予防接種（フリー項目）接種テーブル
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(罹患情報詳細画面)
        /// </summary>
        private SaveRikanResponse SaveRikan(DaDbContext db, SaveRikanRequest req)
        {
            var res = new SaveRikanResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var newdtl = new List<tt_ysrikanDto>();             //罹患テーブル

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //罹患情報一覧
            foreach (var dt in req.kekkalist)
            {
                var newdto = Converter.GetDto(dt, req);
                newdtl.Add(newdto);
            }

            //-------------------------------------------------------------
            //３.DB削除処理
            //-------------------------------------------------------------
            //罹患テーブル削除処理
            var deldtl = GetRikanList(db, newdtl, req.atenano, DB変更区分._3);
            foreach (var dto in deldtl)
            {
                db.tt_ysrikan.DELETE.WHERE.ByKey(req.atenano, dto.rikancd).Execute();
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //罹患テーブル削除処理
            var upddtl = GetRikanList(db, newdtl, req.atenano, DB変更区分._2);
            db.tt_ysrikan.UPDATE.Execute(upddtl);

            //-------------------------------------------------------------
            //５.DB追加処理
            //-------------------------------------------------------------
            var adddtl = GetRikanList(db, newdtl, req.atenano, DB変更区分._1);
            db.tt_ysrikan.INSERT.Execute(adddtl);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(接種依頼情報詳細画面)
        /// </summary>
        private CommonResponse SaveSessyuIrai(DaDbContext db, SaveSessyuIraiRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.atenano, req.fixiteminfo.edano);

            //新規の場合（最新枝番を取得）
            if (kbn == EnumActionType.Insert && req.fixiteminfo.edano == 0) { req.fixiteminfo.edano = GetNewEdano(db, req.atenano); }

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, kbn, res)) { return res; }      //異常返し
                return res;                                         //正常返し
            }

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            var olddto = new tt_yssessyuiraiDto();                  //予防接種依頼テーブル
            var oldfreedtl = new List<tt_yssessyuiraifreeDto>();    //予防接種依頼（フリー項目）テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //接種依頼固定項目情報を取得
                olddto = db.tt_yssessyuirai.GetDtoByKey(req.atenano, req.fixiteminfo.edano);

                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種依頼", tt_yssessyuiraiDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }

                //接種依頼情報フリー項目一覧
                oldfreedtl = db.tt_yssessyuiraifree.SELECT.WHERE.ByKey(req.atenano, req.fixiteminfo.edano).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_yssessyuiraiDto();                  //予防接種依頼テーブル
            var newfreedtl = new List<tt_yssessyuiraifreeDto>();    //予防接種依頼（フリー項目）テーブル
            var newsubdtl = new List<tt_yssessyuirai_subDto>();     //予防接種依頼サブテーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //予防接種依頼テーブル（固定項目）
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //接種依頼情報フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_yssessyuiraifreeDto();
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
                //予防接種依頼テーブル（固定項目）
                newdto = Converter.GetDto(newdto, req, kbn);

                //接種依頼情報フリー項目一覧
                foreach (var dt in req.freeiteminfo)
                {
                    var newfreedto = new tt_yssessyuiraifreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //予防接種依頼サブテーブル
            foreach (var dt in req.fixiteminfo.sessyusublist)
            {
                var newsubdto = Converter.GetDto(req, dt);
                newsubdtl.Add(newsubdto);
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_yssessyuirai.INSERT.Execute(newdto);          //予防接種依頼テーブル

                //予防接種依頼（フリー項目）テーブル
                db.tt_yssessyuiraifree.DELETE.WHERE.ByKey(req.atenano, req.fixiteminfo.edano).Execute();
                db.tt_yssessyuiraifree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_yssessyuirai.UPDATE.Execute(newdto);          //予防接種依頼テーブル
                db.tt_yssessyuiraifree.UPDATE.Execute(newfreedtl);  //予防接種依頼（フリー項目）テーブル
            }

            //-------------------------------------------------------------
            //６.予防接種依頼サブテーブルを登録処理
            //-------------------------------------------------------------
            if (req.fixiteminfo.sessyusublist != null)
            {
                //予防接種依頼（フリー項目）テーブル
                db.tt_yssessyuirai_sub.DELETE.WHERE.ByKey(req.atenano, req.fixiteminfo.edano).Execute();
                db.tt_yssessyuirai_sub.INSERT.Execute(newsubdtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(その他情報詳細画面)
        /// </summary>
        private CommonResponse SaveOther(DaDbContext db, SaveOtherRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKojinKBN(db, req.atenano, 詳細画面区分._その他);

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, kbn, res)) { return res; }      //異常返し
                return res;                                         //正常返し
            }

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            var olddto = new tt_yssonotaDto();                      //予防接種その他テーブル
            var oldfreedtl = new List<tt_yskojinfreeDto>();         //予防接種（フリー項目）個人テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //接種依頼固定項目情報を取得
                olddto = db.tt_yssonota.GetDtoByKey(req.atenano);

                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種その他", tt_yssessyuiraiDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }

                //その他情報フリー項目一覧
                oldfreedtl = db.tt_yskojinfree.SELECT.WHERE.ByKey(req.atenano).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_yssonotaDto();                      //予防接種その他テーブル
            var newfreedtl = new List<tt_yskojinfreeDto>();         //予防接種（フリー項目）個人テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //予防接種その他テーブル（固定項目）
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //その他情報フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_yskojinfreeDto();
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
                //予防接種その他テーブル（固定項目）
                newdto = Converter.GetDto(newdto, req, kbn);

                //その他情報フリー項目一覧
                foreach (var dt in req.freeiteminfo)
                {
                    var newfreedto = new tt_yskojinfreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //５.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_yssonota.INSERT.Execute(newdto);              //予防接種その他テーブル

                //予防接種（フリー項目）個人テーブル
                db.tt_yskojinfree.DELETE.WHERE.ByKey(req.atenano).Execute();
                db.tt_yskojinfree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_yssonota.UPDATE.Execute(newdto);              //予防接種その他テーブル
                db.tt_yskojinfree.UPDATE.Execute(newfreedtl);       //予防接種（フリー項目）個人テーブル
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(風疹抗体検査情報詳細画面)
        /// </summary>
        private CommonResponse SaveFusin(DaDbContext db, SaveFusinRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKojinKBN(db, req.atenano, 詳細画面区分._風疹抗体);

            //-------------------------------------------------------------
            //２.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                //チェック処理
                if (!Check(db, req, kbn, res)) { return res; }      //異常返し
                return res;                                         //正常返し
            }

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            var olddto = new tt_ysfusinkotaiDto();                  //風疹抗体検査テーブル
            var oldfreedtl = new List<tt_ysfusinkotaifreeDto>();    //風疹抗体検査（フリー項目）テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //風疹抗体検査固定項目情報を取得
                olddto = db.tt_ysfusinkotai.GetDtoByKey(req.atenano);

                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "風疹抗体検査", tt_ysfusinkotaiDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }

                //風疹抗体検査情報フリー項目一覧
                oldfreedtl = db.tt_ysfusinkotaifree.SELECT.WHERE.ByKey(req.atenano).GetDtoList();
            }

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_ysfusinkotaiDto();                  //風疹抗体検査テーブル
            var newfreedtl = new List<tt_ysfusinkotaifreeDto>();    //風疹抗体検査（フリー項目）テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //風疹抗体検査テーブル（固定項目）
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //風疹抗体検査情報フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_ysfusinkotaifreeDto();
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
                //風疹抗体検査テーブル（固定項目）
                newdto = Converter.GetDto(newdto, req, kbn);

                //風疹抗体検査情報フリー項目一覧
                foreach (var dt in req.freeiteminfo)
                {
                    var newfreedto = new tt_ysfusinkotaifreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_ysfusinkotai.INSERT.Execute(newdto);          //風疹抗体検査テーブル

                //風疹抗体検査（フリー項目）テーブル
                db.tt_ysfusinkotaifree.DELETE.WHERE.ByKey(req.atenano).Execute();
                db.tt_ysfusinkotaifree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_ysfusinkotai.UPDATE.Execute(newdto);          //風疹抗体検査テーブル

                db.tt_ysfusinkotaifree.UPDATE.Execute(newfreedtl);  //風疹抗体検査（フリー項目）テーブル
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(接種情報詳細画面)
        /// </summary>
        private CommonResponse DeleteSessyu(DaDbContext db, DeleteSessyuRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //存在チェック
            if (!Check(db, req, res)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            //予防接種テーブル
            db.tt_yssessyu.DELETE.WHERE.ByKey(req.atenano, req.sessyucd, req.kaisu, req.edano).Execute();

            //予防接種（フリー項目）接種テーブル
            db.tt_yssessyufree.DELETE.WHERE.ByKey(req.atenano, req.sessyucd, req.kaisu, req.edano).Execute();

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(接種依頼情報詳細画面)
        /// </summary>
        private CommonResponse DeleteSessyuIrai(DaDbContext db, DeleteSessyuIraiRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //存在チェック
            if (!Check(db, req, res)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            //予防接種依頼テーブル
            db.tt_yssessyuirai.DELETE.WHERE.ByKey(req.atenano,req.edano).Execute();

            //予防接種依頼サブテーブル
            db.tt_yssessyuirai_sub.DELETE.WHERE.ByKey(req.atenano, req.edano).Execute();

            //予防接種依頼（フリー項目）テーブル
            db.tt_yssessyuiraifree.DELETE.WHERE.ByKey(req.atenano, req.edano).Execute();

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(風疹抗体検査情報詳細画面)
        /// </summary>
        private CommonResponse DeleteFusin(DaDbContext db, DeleteFusinRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //存在チェック
            if (!Check(db, req, res)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            //風疹抗体検査テーブル
            db.tt_ysfusinkotai.DELETE.WHERE.ByKey(req.atenano).Execute();

            //風疹抗体検査（フリー項目）テーブル
            db.tt_ysfusinkotaifree.DELETE.WHERE.ByKey(req.atenano).Execute();

            //正常返し
            return res;
        }

        //************************************************************** サブロジェック **************************************************************
        /// <summary>
        ///接種種類フィルター区分りすとを取得
        /// </summary>
        public List<SessyuOneVm> GetKekkaList(DaDbContext db, string atenano, EnumHanyoKbn Hanyokbn, bool rirekihyoji, int kbn, int pagenum, int pagesize, int orderby)
        {
            var list = new List<SessyuOneVm>();

            var maincd = ((long)Hanyokbn / DaNameService.MAINCODE_DIGIT).ToString();
            var subcd = (int)((long)Hanyokbn % DaNameService.MAINCODE_DIGIT);

            //A、パラメータ取得
            var param = Converter.GetParameters(atenano, maincd, subcd, rirekihyoji, kbn);

            //B、予防接種情報一覧を取得する
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_01, param, pagenum, pagesize, orderby);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            list = Wraper.GetVMList(db, pageList.dataTable.Rows);           //予防接種情報一覧

            return list;
        }

        /// <summary>
        /// 予防接種画面のデータ操作区分取得
        /// </summary>
        private EnumActionType? GetKBN(DaDbContext db, string atenano, string sessyucd, string kaisu, int edano)
        {
            if (edano == 0) { return EnumActionType.Insert; }

            EnumActionType? kbn = null;

            if (db.tt_yssessyu.SELECT.WHERE.ByKey(atenano, sessyucd, kaisu, edano).Exists())
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
        /// 予防接種依頼画面のデータ操作区分取得
        /// </summary>
        private EnumActionType? GetKBN(DaDbContext db, string atenano, int edano)
        {
            if (edano == 0) { return EnumActionType.Insert; }

            EnumActionType? kbn = null;

            if (db.tt_yssessyuirai.SELECT.WHERE.ByKey(atenano, edano).Exists())
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
        /// 風疹抗体検査画面のデータ操作区分取得
        /// </summary>
        private EnumActionType? GetKojinKBN(DaDbContext db, string atenano, string prockbn)
        {
            EnumActionType? kbn = null;

            if (prockbn.Equals(詳細画面区分._その他))
            {
                if (db.tt_yssonota.SELECT.WHERE.ByKey(atenano).Exists())
                {
                    kbn = EnumActionType.Update;        //編集フラグ☑=>更新
                }
                else
                {
                    kbn = EnumActionType.Insert;        //編集フラグ☑=>新規
                }
            }
            else if (prockbn.Equals(詳細画面区分._風疹抗体))
            {
                if (db.tt_ysfusinkotai.SELECT.WHERE.ByKey(atenano).Exists())
                {
                    kbn = EnumActionType.Update;        //編集フラグ☑=>更新
                }
                else
                {
                    kbn = EnumActionType.Insert;        //編集フラグ☑=>新規
                }
            }
            return kbn;
        }

        /// <summary>
        ///予防接種を新規登録する際に、枝番の付与は、該当宛名番号／接種種類コード／回数の最大枝番を取得
        /// </summary>
        private int GetNewEdano(DaDbContext db, string atenano, string sessyucd, string kaisu)
        {
            var mdtl = db.tt_yssessyu.SELECT.WHERE.ByKey(atenano, sessyucd, kaisu).GetDtoList();
            var maxedano = mdtl.Count == 0 ? 1 : mdtl.Select(e => e.edano).Max() + 1;
            return maxedano;
        }

        /// <summary>
        ///予防接種依頼を新規登録する際に、枝番の付与は、該当宛名番号の最大枝番を取得
        /// </summary>
        private int GetNewEdano(DaDbContext db, string atenano)
        {
            var mdtl = db.tt_yssessyuirai.SELECT.WHERE.ByKey(atenano).GetDtoList();
            var maxedano = mdtl.Count == 0 ? 1 : mdtl.Select(e => e.edano).Max() + 1;
            return maxedano;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// 保存前チェック（接種情報）
        /// </summary>
        private static bool Check(DaDbContext db, SaveSessyuRequest req, EnumActionType? kbn, SaveSessyuResponse res)
        {
            if (kbn == null) { return true; }

            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (CheckDataExist(db, req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"宛名番号 - 接種種類コード - 回数 - 枝番");
                    res.SetServiceError(msg);
                    return false;
                }

                //同一接種種類 かつ 同一回数 かつ 接種区分=接種 のデータが存在する場合、新規追加は不可とする
                if (GetCd(req.fixiteminfo.sessyukbn).Equals(接種区分._1) && CheckDataExist(db, req))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"同一接種種類 かつ 同一回数 かつ 接種区分=接種 のデータが存在する");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!CheckDataExist(db, req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano))
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }

            //予防接種入力チェック処理
            if (!InputCheck(db, req, res))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 保存前チェック（接種依頼情報）
        /// </summary>
        private static bool Check(DaDbContext db, SaveSessyuIraiRequest req, EnumActionType? kbn, CommonResponse res)
        {
            if (kbn == null) { return true; }

            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (CheckDataExist(db, req.atenano, req.fixiteminfo.edano))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"宛名番号 - 枝番");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!CheckDataExist(db, req.atenano, req.fixiteminfo.edano))
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種依頼テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存前チェック（その他情報）
        /// </summary>
        private static bool Check(DaDbContext db, SaveOtherRequest req, EnumActionType? kbn, CommonResponse res)
        {
            if (kbn == null) { return true; }

            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (CheckKojinDataExist(db, req.atenano, 詳細画面区分._その他))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"宛名番号");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!CheckKojinDataExist(db, req.atenano, 詳細画面区分._その他))
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "予防接種（フリー項目）個人テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 保存前チェック（風疹抗体検査情報）
        /// </summary>
        private static bool Check(DaDbContext db, SaveFusinRequest req, EnumActionType? kbn, CommonResponse res)
        {
            if (kbn == null) { return true; }

            //新規の場合
            if (kbn == EnumActionType.Insert)
            {
                //重複チェック
                if (CheckKojinDataExist(db, req.atenano, 詳細画面区分._風疹抗体))
                {
                    //E002003：既に使用されている{0}です。
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, $"宛名番号");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            else if (kbn == EnumActionType.Update)
            {
                //排他チェック
                if (!CheckKojinDataExist(db, req.atenano, 詳細画面区分._風疹抗体))
                {
                    //E004006：{0}は{1}に存在しません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "風疹抗体検査テーブル");
                    res.SetServiceError(msg);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 実施機関名取得
        /// </summary>
        public static string GetKikanNm(DaDbContext db, string kikancd)
        {
            if (string.IsNullOrEmpty(kikancd)) { return string.Empty; }

            var kikandto = db.tm_afkikan.GetDtoByKey(DaSelectorService.GetCd(kikancd));
            if (kikandto == null) { return string.Empty; }

            return $"{kikancd}{SPACE}{COLON}{SPACE}{kikandto.kikannm}";
        }

        /// <summary>
        /// 会場名取得
        /// </summary>
        public static string GetKaijyoNm(DaDbContext db, string kaijocd)
        {
            if (string.IsNullOrEmpty(kaijocd)) { return string.Empty; }

            var kaijodto = db.tm_afkaijo.GetDtoByKey(kaijocd);
            if (kaijodto == null) { return string.Empty; }

            return $"{kaijocd}{SPACE}{COLON}{SPACE}{kaijodto.kaijonm}";
        }

        /// <summary>
        /// 医師名取得
        /// </summary>
        public static string GetIsiNm(DaDbContext db, string isicd)
        {
            if (string.IsNullOrEmpty(isicd)) { return string.Empty; }

            var staffdto = db.tm_afstaff.GetDtoByKey(isicd);
            if (staffdto == null) { return string.Empty; }

            return $"{isicd}{SPACE}{COLON}{SPACE}{staffdto.staffsimei}";
        }

        /// <summary>
        /// 固定項目のドロップダウンリスト初期化（接種情報詳細画面）
        /// </summary>
        public static FixItemSessyuVM InitFixList(DaDbContext db, string syougaiflg)
        {
            var fixiteminfo = new FixItemSessyuVM();

            fixiteminfo.sessyulist = new List<DaSelectorModel>();

            //接種種類リスト
            var dtl = GetHanyoDtl(db, EnumHanyoKbn.接種種類詳細コード);
            if (dtl != null) 
            {
                //EnumHanyoKbn.接種種類詳細コード(1004 - 2)の説明
                //汎用区分1: 1桁目は表示タブ 1:接種情報（生涯1回）タブ 2:接種情報（複数回）タブ
                //汎用区分1: 2桁目は接種種類フィルター区分(1004 - 8)
                //汎用区分1: 3～5桁目は表示順
                var newdtl = dtl.FindAll(e => e.hanyokbn1!.Substring(0, 1) == syougaiflg).OrderBy(e => e.hanyokbn1!.Substring(2, 3)).ToList();
                foreach (var dto in newdtl)
                {
                    var vm = new DaSelectorModel()
                    {
                        value = CStr(dto.hanyocd),      //コード
                        label = CStr(dto.nm)            //名称
                    };
                    fixiteminfo.sessyulist.Add(vm);
                }
            }

            //接種区分リスト
            fixiteminfo.sessyukbnlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.接種区分)).ToString());

            //ワクチン名リスト
            fixiteminfo.vaccinenmlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.ワクチン)).ToString());

            //ワクチンメーカーリスト
            fixiteminfo.vaccinemakerlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.ワクチンメーカー)).ToString());

            //実施区分リスト
            fixiteminfo.jissikbnlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.予防接種の実施方式)).ToString());

            //法定区分リスト
            fixiteminfo.hoteikbnlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.予防接種区分)).ToString());

            //実施機関リスト
            var kikandtl = db.tm_afkikan.SELECT.WHERE.ByFilter($"{nameof(tm_afkikanDto.stopflg)}=false").GetDtoList().OrderBy(e => e.kikancd);
            fixiteminfo.jissikikanlist = new List<DaSelectorModel>();
            foreach (var dto in kikandtl)
            {
                var vm = new DaSelectorModel()
                {
                    value = CStr(dto.kikancd),
                    label = CStr(dto.kikannm)
                };
                fixiteminfo.jissikikanlist.Add(vm);
            }

            //会場リスト
            var kaijodtl = db.tm_afkaijo.SELECT.WHERE.ByFilter($"{nameof(tm_afkikanDto.stopflg)}=false").GetDtoList().OrderBy(e => e.kaijocd);
            fixiteminfo.kaijolist = new List<DaSelectorModel>();
            foreach (var dto in kaijodtl)
            {
                var vm = new DaSelectorModel()
                {
                    value = CStr(dto.kaijocd),
                    label = CStr(dto.kaijonm)
                };
                fixiteminfo.kaijolist.Add(vm);
            }

            //医師リスト（医師／歯科医師の場合）
            var isidtl = db.tm_afstaff.SELECT.WHERE.ByFilter($"{nameof(tm_afstaffDto.stopflg)}=false").GetDtoList().OrderBy(e => e.staffid);
            fixiteminfo.isilist = new List<DaSelectorModel>();
            foreach (var dto in isidtl)
            {
                if (dto.syokusyu.Equals(職種._01) || dto.syokusyu.Equals(職種._02))
                {
                    var vm = new DaSelectorModel()
                    {
                        value = CStr(dto.staffid),
                        label = CStr(dto.staffsimei)
                    };
                    fixiteminfo.isilist.Add(vm);
                }
            }

            //特別の事情リスト
            fixiteminfo.tokubetunojijyolist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.特別の事情)).ToString());

            return fixiteminfo;
        }

        /// <summary>
        /// 固定項目のドロップダウンリスト初期化（接種依頼情報詳細画面）
        /// </summary>
        public static FixItemSessyuIraiVM InitFixList(DaDbContext db)
        {
            var fixiteminfo = new FixItemSessyuIraiVM();

            //接種種類リスト
            fixiteminfo.sessyulist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, ((long)(EnumHanyoKbn.接種種類詳細コード)).ToString());

            return fixiteminfo;
        }


        /// <summary>
        /// 固定項目のドロップダウンリスト初期化（接種依頼情報詳細画面）
        /// </summary>
        public static List<SessyuVM> GetSessyuSubList(DaDbContext db, List<DaSelectorModel> sessyulist, SearchSessyuIraiDetailRequest req)
        {
            var dtl = db.tt_yssessyuirai_sub.SELECT.WHERE.ByKey(req.atenano, req.edano).GetDtoList().OrderBy(e => e.sessyucd).ThenBy(e => e.kaisu);
            var list = new List<SessyuVM>();

            foreach (var dto in dtl)
            {
                var vm = new SessyuVM()
                {
                    sessyucd = CStr(dto.sessyucd),
                    sessyu = GeSessyuCdNm(sessyulist, $"{CStr(dto.sessyucd)}{CStr(dto.kaisu)}"),     //接種種類
                    kaisu = dto.kaisu
                };
                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 固定項目のドロップダウンリスト初期化（風疹抗体検査情報詳細画面）
        /// </summary>
        public static FixItemFusinVM InitFusinFixList(DaDbContext db)
        {
            var fixiteminfo = new FixItemFusinVM();

            //抗体検査方法リスト
            fixiteminfo.kotaikensahoholist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.抗体検査方法)).ToString());

            //単位リスト（抗体価）
            fixiteminfo.tanilist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.単位)).ToString());

            //接種判定リスト
            fixiteminfo.sessyuhanteilist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.接種判定)).ToString());

            //実施機関リスト
            var kikandtl = db.tm_afkikan.SELECT.WHERE.ByFilter($"{nameof(tm_afkikanDto.stopflg)}=false").GetDtoList().OrderBy(e => e.kikancd);
            fixiteminfo.jissikikanlist = new List<DaSelectorModel>();
            foreach (var dto in kikandtl)
            {
                var vm = new DaSelectorModel()
                {
                    value = CStr(dto.kikancd),
                    label = CStr(dto.kikannm)
                };
                fixiteminfo.jissikikanlist.Add(vm);
            }

            //医師リスト（医師／歯科医師の場合）
            var isidtl = db.tm_afstaff.SELECT.WHERE.ByFilter($"{nameof(tm_afstaffDto.stopflg)}=false").GetDtoList().OrderBy(e => e.staffid);
            fixiteminfo.isilist = new List<DaSelectorModel>();
            foreach (var dto in isidtl)
            {
                if (dto.syokusyu.Equals(職種._01) || dto.syokusyu.Equals(職種._02))
                {
                    var vm = new DaSelectorModel()
                    {
                        value = CStr(dto.staffid),
                        label = CStr(dto.staffsimei)
                    };
                    fixiteminfo.isilist.Add(vm);
                }
            }

            //抗体検査番号リスト
            fixiteminfo.kotaikensanolist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.抗体検査番号)).ToString());

            return fixiteminfo;
        }

        /// <summary>
        /// リストから該当「項目コード : 名称」を取得
        /// </summary>
        public static string GeSessyuCdNm(List<DaSelectorModel> sessyulist, string itemcd)
        {
            var dto = sessyulist.Find(x => x.value == itemcd);
            if (dto == null) { return string.Empty; }
            return $"{dto.value}{SPACE}{COLON}{SPACE}{dto.label}";
        }

        /// <summary>
        /// リストから該当「項目コード : 名称」を取得
        /// </summary>
        public static List<DaSelectorModel> GetSessyuFilterKbnList(DaDbContext db, string kbn)
        {
            var list = new List<DaSelectorModel>();
            var newdtl = new List<tm_afhanyoDto>();

            var dtl = GetHanyoDtl(db, EnumHanyoKbn.接種種類フィルター区分);
            if (dtl == null) { return list; }

            if (kbn.Equals(詳細画面区分._生涯1回)) { newdtl = dtl.FindAll(x => x.hanyokbn1 == 詳細画面区分._生涯1回).OrderBy(e => e.hanyokbn2).ToList(); }
            else if (kbn.Equals(詳細画面区分._複数回)) { newdtl = dtl.FindAll(x => x.hanyokbn1 == 詳細画面区分._複数回).OrderBy(e => e.hanyokbn2).ToList(); }

            foreach (var item in newdtl)
            {
                var vm = new DaSelectorModel()
                {
                    value = item.hanyocd,
                    label = item.nm
                };
                list.Add(vm);
            }
            return list;
        }

        /// <summary>
        ///データ存在チェック（接種情報）
        /// </summary>
        private static bool IsMaxEdano(DaDbContext db, SearchSessyuDetailRequest req)
        {
            var maxedano = db.tt_yssessyu.SELECT.WHERE.ByKey(req.atenano, req.sessyucd, req.kaisu).GetDtoList().Select(e => e.edano).Max();
            return maxedano == req.edano ? true : false;
        }

        /// <summary>
        ///データ存在チェック（接種依頼情報）
        /// </summary>
        private static bool IsMaxEdano(DaDbContext db, SearchSessyuIraiDetailRequest req)
        {
            var maxedano = db.tt_yssessyuirai.SELECT.WHERE.ByKey(req.atenano).GetDtoList().Select(e => e.edano).Max();
            return maxedano == req.edano ? true : false;
        }

        /// <summary>
        ///データ存在チェック（接種情報）
        /// </summary>
        private static bool CheckDataExist(DaDbContext db, string atenano, string sessyucd, string kaisu, int edano)
        {
            //存在チェック
            if (db.tt_yssessyu.SELECT.WHERE.ByKey(atenano, sessyucd, kaisu, edano).Exists()) { return true; }
            return false;
        }

        /// <summary>
        ///データ存在チェック（接種依頼情報）
        /// </summary>
        private static bool CheckDataExist(DaDbContext db, string atenano, int edano)
        {
            //存在チェック
            if (db.tt_yssessyuirai.SELECT.WHERE.ByKey(atenano, edano).Exists()) { return true; }
            return false;
        }

        /// <summary>
        ///同一接種種類 かつ 同一回数 かつ 接種区分=接種 のデータが存在する場合、新規追加は不可とするの特別チェック（詳細仕様書により）
        /// </summary>
        private static bool CheckDataExist(DaDbContext db, SaveSessyuRequest req)
        {
            //存在チェック
            if (db.tt_yssessyu.SELECT.WHERE.ByFilter($"{nameof(tt_yssessyuDto.atenano)}=@atenano and " +
                                                     $"{nameof(tt_yssessyuDto.sessyucd)}=@sessyucd and " +
                                                     $"{nameof(tt_yssessyuDto.kaisu)}=@kaisu and " +
                                                     $"{nameof(tt_yssessyuDto.sessyukbn)}=@sessyukbn"
                                                     , req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, 接種区分._1).Exists()) { return true; }
            return false;
        }


        


        /// <summary>
        ///データ存在チェック（その他情報／風疹抗体検査）
        /// </summary>
        private static bool CheckKojinDataExist(DaDbContext db, string atenano, string prockbn)
        {
            //存在チェック
            if (prockbn.Equals(詳細画面区分._その他))
            {
                //予防接種その他テーブル
                if (db.tt_yssonota.SELECT.WHERE.ByKey(atenano).Exists()) { return true; }
            }
            else if (prockbn.Equals(詳細画面区分._風疹抗体))
            {
                //風疹抗体検査テーブル
                if (db.tt_ysfusinkotai.SELECT.WHERE.ByKey(atenano).Exists()) { return true; }
            }
            return false;
        }

        /// <summary>
        /// 予防接種入力チェック処理(接種情報詳細画面保存前チェック)
        /// </summary>
        private static bool InputCheck(DaDbContext db, SaveSessyuRequest req, SaveSessyuResponse res)
        {
            var msgkbn = EnumServiceResult.OK;
            var sessyu = $"{req.fixiteminfo.sessyucd}{req.fixiteminfo.kaisu}";

            res.inputcheckinfo = new YSInputCheckInfoVM()
            {
                sessyu = sessyu,                        //接種種類（7桁）
                sessyucd = req.fixiteminfo.sessyucd,    //接種種類コード（5桁）
                kaisu = req.fixiteminfo.kaisu,          //回数（2桁）
                msglist = new List<MessageVM>(),        //メッセージリスト（接種種類単位）
            };

            var dto = db.tm_ysnyuryokucheck.SELECT.WHERE.ByKey(req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu).GetDto();

            //A、接種済みチェック1(エラー)「sessyuchk1項目のチェック処理」
            if ($"{CStr(dto.sessyuchk1)},".Contains($"{sessyu},"))
            {
                //接種済みの場合、エラー
                var vm = new MessageVM()
                {
                    MessageKbn = EnumServiceResult.ServiceError,
                    Message = $"接種済みの場合、エラー{C_LF}（接種種類：{sessyu}）",
                };
                res.inputcheckinfo.msglist.Add(vm);
                msgkbn = EnumServiceResult.ServiceError;
            }

            //B、接種済みチェック2(警告)「sessyuchk2項目のチェック処理」
            if ($"{CStr(dto.sessyuchk2)},".Contains($"{sessyu},"))
            {
                //接種済みの場合、エラー
                var vm = new MessageVM()
                {
                    MessageKbn = EnumServiceResult.ServiceAlert,
                    Message = $"接種済みの場合、警告{C_LF}（接種種類：{sessyu}）",
                };
                res.inputcheckinfo.msglist.Add(vm);
                msgkbn = (msgkbn == EnumServiceResult.OK) ? EnumServiceResult.ServiceAlert : msgkbn;
            }

            //C、前回接種種類「zensessyu項目のチェック処理」
            //1、前回接種と同一接種日の場合、エラー
            var msgstr = CheckZensessyuDupliDay(db, req, CStr(dto.zensessyu));
            if (!string.IsNullOrEmpty(msgstr))
            {
                var vm = new MessageVM()
                {
                    MessageKbn = EnumServiceResult.ServiceError,
                    Message = $"前回接種と同一接種日の場合、エラー{C_LF}（{msgstr}）",
                };
                res.inputcheckinfo.msglist.Add(vm);
                msgkbn = EnumServiceResult.ServiceError;
            }

            //2、前回予防接種との接種間隔チェックでNGの場合、警告
            msgstr = CheckZensessyuInterval(db, req, CStr(dto.zensessyu), CInt(dto.kankakumin), CStr(dto.kankakutani));
            if (!string.IsNullOrEmpty(msgstr))
            {
                var vm = new MessageVM()
                {
                    MessageKbn = EnumServiceResult.ServiceAlert,
                    Message = $"前回予防接種との接種間隔チェックでNGの場合、警告{C_LF}（{msgstr}）",
                };
                res.inputcheckinfo.msglist.Add(vm);
                msgkbn = (msgkbn == EnumServiceResult.OK) ? EnumServiceResult.ServiceAlert : msgkbn;
            }

            //D、罹患済みチェック1(エラー)「rikanchk1項目のチェック処理」
            var rikandtl = db.tt_ysrikan.SELECT.WHERE.ByKey(req.atenano).GetDtoList();
            foreach(var rikandto in rikandtl)
            {
                if ($"{CStr(dto.rikanchk1)},".Contains($"{CStr(rikandto.rikancd)},"))
                {
                    msgstr = "";
                    var vm = new MessageVM()
                    {
                        MessageKbn = EnumServiceResult.ServiceError,
                        Message = $"罹患済みチェック1(エラー){C_LF}（罹患コード：{CStr(rikandto.rikancd)}）",
                    };
                    res.inputcheckinfo.msglist.Add(vm);
                    msgkbn = EnumServiceResult.ServiceError;
                }

                if ($"{CStr(dto.rikanchk2)},".Contains($"{CStr(rikandto.rikancd)},"))
                {
                    var vm = new MessageVM()
                    {
                        MessageKbn = EnumServiceResult.ServiceError,
                        Message = $"罹患済みチェック2(警告){C_LF}（罹患コード：{CStr(rikandto.rikancd)}）",
                    };
                    res.inputcheckinfo.msglist.Add(vm);
                    msgkbn = (msgkbn == EnumServiceResult.OK) ? EnumServiceResult.ServiceAlert : msgkbn;
                }
            }

            //E、ワクチンマスタでワクチンの存在チェック処理
            var vaccinemakercd = GetCd(req.fixiteminfo.vaccinemaker);
            var vaccinenmcd = GetCd(req.fixiteminfo.vaccinenm);
            if (!db.tm_ysvaccine.SELECT.WHERE.ByFilter($"{nameof(tm_ysvaccineDto.sessyucd)}=@sessyucd and " +
                                                       $"{nameof(tm_ysvaccineDto.vaccinemakercd)}=@vaccinemaker and " +
                                                       $"{nameof(tm_ysvaccineDto.vaccinenmcd)}=@vaccinenmcd and " +
                                                       $"{nameof(tm_ysvaccineDto.stopflg)}=false"
                                                       , req.fixiteminfo.sessyucd, vaccinemakercd, vaccinenmcd).Exists())
            {
                var msg = $"{C_LF}（接種種類コード：{req.fixiteminfo.sessyucd}、ワクチンメーカーコード：{vaccinemakercd}、ワクチン名コード：{vaccinenmcd}）";
                var vm = new MessageVM()
                {
                    MessageKbn = EnumServiceResult.ServiceError,
                    Message = $"{DaMessageService.GetMsg(EnumMessage.E004006, "ワクチン", tm_ysvaccineDto.TABLE_NAME)}{msg}",
                };
                res.inputcheckinfo.msglist.Add(vm);
                msgkbn = EnumServiceResult.ServiceError;
            }

            if (msgkbn == EnumServiceResult.ServiceAlert)
            {
                var msg = "警告あり";
                res.SetServiceAlert(msg);
                return false;
            }
            else if (msgkbn == EnumServiceResult.ServiceError)
            {
                var msg = "エラーあり";
                res.SetServiceAlert(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 前回接種と同一接種日のチェック処理
        /// 戻り値：空白：同一接種日ではない
        /// 　　　　空白ではない：前回接種種類：XXXXXXX（7桁）、実施日：YYYY-MM-DD
        /// </summary>
        private static string CheckZensessyuDupliDay(DaDbContext db, SaveSessyuRequest req, string zensessyu)
        {
            var arr = zensessyu.Split($"{COMMA}");
            if (arr.Length == 0) { return string.Empty; }

            var dto = db.tt_yssessyu.SELECT.WHERE.ByKey(req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano).GetDto();
            if (dto == null) { return string.Empty; }

            var jissiymd = CStr(dto.jissiymd);

            foreach (var str in arr)
            {
                //接種種類（7桁）から接種種類コード（5桁）と回数（2桁）を取得
                if (!string.IsNullOrEmpty(str) && (str.Length == 7))
                {
                    var sessyucd = str.Substring(0, 5);
                    var kaisu = str.Substring(5, 2);

                    var zendtl = db.tt_yssessyu.SELECT.WHERE.ByFilter($"{nameof(tt_yssessyuDto.atenano)}=@atenano and " +
                                                                      $"{nameof(tt_yssessyuDto.sessyucd)}=@sessyucd and " +
                                                                      $"{nameof(tt_yssessyuDto.kaisu)}=@kaisu "
                                                                      , req.atenano, sessyucd, kaisu).GetDtoList();
                    foreach (var zendto in zendtl)
                    {
                        if (zendto.jissiymd!.Equals(jissiymd))
                        {
                            return $"前回接種種類：{sessyucd}{zendto.kaisu}、枝番：{CStr(zendto.edano)}、実施日：{jissiymd}";
                        }
                    }
                }
            };

            return string.Empty;
        }

        /// <summary>
        /// 前回予防接種との接種間隔チェック処理、NGの場合：警告
        /// 戻り値：空白：同一接種日ではない
        /// 　　　　空白ではない：前回接種種類：XXXXXXX（7桁）、前回実施日：YYYY-MM-DD、今回実施日：YYYY-MM-DD、接種間隔：XX
        /// </summary>
        private static string CheckZensessyuInterval(DaDbContext db, SaveSessyuRequest req, string zensessyu, int kankakumin, string kankakutani)
        {
            var arr = zensessyu.Split($"{COMMA}");
            if (arr.Length == 0) { return string.Empty; }

            var dto = db.tt_yssessyu.SELECT.WHERE.ByKey(req.atenano, req.fixiteminfo.sessyucd, req.fixiteminfo.kaisu, req.fixiteminfo.edano).GetDto();
            if (dto == null) { return string.Empty; }

            var jissiymd = CStr(dto.jissiymd);          //今回実施日
            var fromday = string.Empty;                //比較開始日
            var today = string.Empty;                  //比較終了日
            DateTime refdate = DateTime.MinValue;      //比較参照日
            var tani = string.Empty;                   //単位（表示用）

            foreach (var str in arr)
            {
                //接種種類（7桁）から接種種類コード（5桁）と回数（2桁）を取得
                if (!string.IsNullOrEmpty(str) && (str.Length == 7))
                {
                    var sessyucd = str.Substring(0, 5);
                    var kaisu = str.Substring(5, 2);

                    var zendtl = db.tt_yssessyu.SELECT.WHERE.ByFilter($"{nameof(tt_yssessyuDto.atenano)}=@atenano and " +
                                                                      $"{nameof(tt_yssessyuDto.sessyucd)}=@sessyucd and " +
                                                                      $"{nameof(tt_yssessyuDto.kaisu)}=@kaisu "
                                                                      , req.atenano, sessyucd, kaisu).GetDtoList();
                    foreach (var zendto in zendtl)
                    {
                        if (jissiymd.CompareTo(zendto.jissiymd) < 0)
                        {
                            //今回実施日 < 前回実施日の場合
                            fromday = jissiymd;
                            today= CStr(zendto.jissiymd);
                        }
                        else
                        {
                            //今回実施日 >= 前回実施日の場合
                            fromday = CStr(zendto.jissiymd);
                            today = jissiymd;
                        }

                        DateTime fromdate = DateTime.ParseExact(fromday, "yyyy-MM-dd", null);
                        switch (kankakutani)
                        {
                            case 接種間隔単位._日:
                                refdate = fromdate.AddDays(kankakumin);
                                tani = "日";
                                break;
                            case 接種間隔単位._週:
                                refdate = fromdate.AddDays(kankakumin * 7);
                                tani = "週";
                                break;
                            case 接種間隔単位._月:
                                refdate = fromdate.AddMonths(kankakumin);
                                tani = "月";
                                break;
                            case 接種間隔単位._年:
                                refdate = fromdate.AddYears(kankakumin);
                                tani = "年";
                                break;
                            default:
                                break;
                        }
                        var refday = refdate.ToString("yyyy-MM-dd");

                        if (today.CompareTo(refday) < 0)
                        {
                            return $"前回接種種類：{sessyucd}{zendto.kaisu}、枝番：{CStr(zendto.edano)}、今回実施日：{jissiymd}、前回実施日：{zendto.jissiymd}、接種間隔：{CStr(kankakumin)}({tani})";
                        }

                    }
                }
            };

            return string.Empty;
        }

        /// <summary>
        /// 罹患テーブルから削除／更新すべき罹患情報を取得する
        /// </summary>
        public static List<tt_ysrikanDto> GetRikanList(DaDbContext db, List<tt_ysrikanDto> newdtl, string atenano, string kbn)
        {
            var list = new List<tt_ysrikanDto>();
            var dtl = db.tt_ysrikan.SELECT.WHERE.ByKey(atenano).GetDtoList();

            if (kbn.Equals(DB変更区分._1))
            {
                //追加処理の場合
                foreach (var dto in newdtl)
                {
                    var result = dtl.Find(e => e.rikancd == dto.rikancd);

                    if (result == null) { list.Add(dto); }                                  //追加処理
                }
            }
            else
            {
                //更新／削除処理の場合
                foreach (var dto in dtl)
                {
                    var result = newdtl.Find(e => e.rikancd == dto.rikancd);

                    if (kbn.Equals(DB変更区分._3) && (result == null)) { list.Add(dto); }   //削除処理
                    if (kbn.Equals(DB変更区分._2) && (result != null)) { list.Add(dto); }   //更新処理
                }
            }
            return list;
        }

        //************************************************************** 削除前チェック処理 **************************************************************
        /// <summary>
        /// 存在チェック(接種情報)
        /// </summary>
        private bool Check(DaDbContext db, DeleteSessyuRequest req, CommonResponse res)
        {
            //予防接種テーブル
            if (!db.tt_yssessyu.SELECT.WHERE.ByKey(req.atenano, req.sessyucd, req.kaisu, req.edano).Exists())
            {
                var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存在チェック(接種依頼情報)
        /// </summary>
        private bool Check(DaDbContext db, DeleteSessyuIraiRequest req, CommonResponse res)
        {
            //予防接種依頼テーブル
            if (!db.tt_yssessyuirai.SELECT.WHERE.ByKey(req.atenano, req.edano).Exists())
            {
                var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存在チェック(風疹抗体検査)
        /// </summary>
        private bool Check(DaDbContext db, DeleteFusinRequest req, CommonResponse res)
        {
            //風疹抗体検査テーブル
            if (!db.tt_ysfusinkotai.SELECT.WHERE.ByKey(req.atenano).Exists())
            {
                var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }
    }
}