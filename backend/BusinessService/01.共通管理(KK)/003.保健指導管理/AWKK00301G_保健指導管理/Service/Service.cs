// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導管理
// 　　　　　　サービス処理
// 作成日　　: 2023.12.13
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaNameService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using AIplus.FreeQuery.Common;
using static BCC.Affect.DataAccess.DaCodeConst;

using AIplus.FreeQuery.Where;
using Org.BouncyCastle.Ocsp;

namespace BCC.Affect.Service.AWKK00301G
{
    [DisplayName("保健指導管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00301G = "AWKK00301G";
        private const string DISPLAYFLG_1 = "1";
        private const int GRPKBN2LEN = 5;                       //保健指導・集団指導項目グループ用汎用区分2内容の固定長さ

        //定数定義
        private const string PROC_NAME_01 = "sp_awkk00301g_01"; //世帯構成員一覧情報取得②③
        private const string PROC_NAME_02 = "sp_awkk00301g_02"; //保健指導一覧情報取得④⑤

        //定数定義
        private const int ORDERBYCOUNT = 15;                    //検索一覧の列数（非表示も含む）

        [DisplayName("住民一覧画面検索処理(検索画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("住民詳細画面検索処理(住民一覧)")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("世帯詳細画面検索処理(世帯一覧)")]
        public SearchSetaiDetailResponse SearchSetaiDetail(SearchSetaiDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSetaiDetail(db, req);
            });
        }

        [DisplayName("世帯詳細画面検索処理(タブ選択)")]
        public SearchShidouDetailResponse SearchShidouDetail(SearchShidouDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchShidouDetail(db, req);
            });
        }

        [DisplayName("個人詳細画面検索処理(個人一覧)")]
        public SearchPersonDetailResponse SearchPersonDetail(SearchPersonDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchPersonDetail(db, req);
            });
        }

        [DisplayName("個人詳細画面検索処理(タブ選択)")]
        public SearchPersonShidouResponse SearchPersonShidou(SearchPersonDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchPersonShidou(db, req);
            });
        }

        [DisplayName("保存処理")]
        public CommonResponse Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //Todo：kinoidから事業コード取得、共通関数があれば入れ替える
                var jigyocd = GetJigyocd(req.kinoid!);

                //正常返し
                return Save(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("削除処理")]
        public CommonResponse Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return Delete(db, req, string.Empty);
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitDetail(db, req);
            });
        }

        [DisplayName("実施日時点年齢取得処理")]
        public GetAgeResponse GetAge(GetAgeRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return GetAge(db, req);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        /// ①住民一覧画面検索処理(検索画面)
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

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民情報")) { return res; }  //異常返し
            }

            //-------------------------------------------------------------
            //２.条件設定
            //-------------------------------------------------------------
            //固定の検索条件
            var fixedCondition = Converter.GetFixedCondition(req);
            //詳細の検索条件（テスト用）
            var condition = CmSearchUtil.GetSearchJyoken(db, AWKK00301G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
            //連絡先の事業コード
            var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, AWKK00301G);

            //総件数
            var total = GetResultTotalCount(db, renraku_jigyocd, condition, req.orderby, true);

            //-------------------------------------------------------------
            //３.データ取得
            //-------------------------------------------------------------
            //検索結果
            var result = DaFreeQuery.GetSidoQuery(db, renraku_jigyocd, condition, req.orderby, true);

            //結果一覧
            var pageData = result.Data;
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //住所表記フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;
            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.kekkalist = Wraper.GetJyuminVMList(db, pageData.Rows, alertviewflg, adrsFlg);
            //ページャー設定
            res.SetPageInfo(total, req.pagesize);
            //検索結果が一人の場合、詳細画面へ遷移する
            res.transflg = total > 0 && res.kekkalist.DistinctBy(e => e.atenano).Count() == 1;

            //正常返し
            return res;
        }

        /// <summary>
        /// ②③住民詳細画面検索処理(住民一覧)
        /// </summary>
        private SearchDetailResponse SearchDetail(DaDbContext db, SearchDetailRequest req)
        {
            var res = new SearchDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の世帯番号を取得する
            var setaino = db.tt_afatena.GetDtoByKey(req.atenano).setaino;

            //世帯成員一覧取得
            var setaidtl = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.setaino), setaino).GetDtoList();

            //世帯主の宛名番号取得
            var fixinfodto = new tt_afatenaDto();
            var atenano = setaidtl.Find(x => x.zokucd1 == 続柄._02 || x.zokucd2 == 続柄._02 || x.zokucd3 == 続柄._02 || x.zokucd4 == 続柄._02)?.atenano ?? string.Empty;
            if (string.IsNullOrEmpty(atenano))
            {
                //世帯主が存在していない場合、同世帯の一員を取得する
                fixinfodto = db.tt_afatena.SELECT.WHERE.ByFilter($"{nameof(tt_afatenaDto.setaino)}=@setaino", setaino)
                                          .GetDtoList().OrderByDescending(e => e.atenano).FirstOrDefault();
                if (fixinfodto == null) { throw new AiExclusiveException(); }

                fixinfodto.simei_yusen = string.Empty;
                fixinfodto.simei_kana_yusen = string.Empty;
            }
            else
            {
                //B、Aで取得した世帯番号から世帯情報（固定部分）を取得する
                fixinfodto = db.tt_afatena.GetDtoByKey(atenano);
            }

            //C、該当宛名番号の世帯情報（地区情報）を取得する
            var maxno = 10;          //最大地区数

            FrResult result = new FrResult();
            var sql = GetTikuSql(req.atenano, maxno, EnumNmKbn.地区区分);
            DataTable tikudto = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            //D、該当世帯の世帯構成員情報を取得する
            //パラメータ取得
            var param = Converter.GetParameters(setaino);

            //世帯情報一覧取得
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_01, param, req.pagenum, req.pagesize, req.orderby);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            res.setaibaseinfo = Wraper.GetSetaiVM(db, fixinfodto);                              //世帯情報（固定部分）
            res.setaitikulist = Wraper.GetTikuVMList(db, tikudto);                              //世帯地区情報一覧
            res.setailist = Wraper.GetSetaiVMList(db, pageList.dataTable.Rows, alertviewflg);   //世帯構成員一覧

            //ページャー設定
            res.SetPageInfo(pageList.TotalCount, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// ④世帯詳細画面検索処理(世帯一覧)
        /// </summary>
        private SearchSetaiDetailResponse SearchSetaiDetail(DaDbContext db, SearchSetaiDetailRequest req)
        {
            var res = new SearchSetaiDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当宛名番号の個人情報を取得する
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //B、該当宛名番号の保健指導情報を取得する
            //パラメータ取得
            var param = Converter.GetParameters(req.atenano, req.hokensidokbn, null, null);

            //世帯情報一覧取得
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_02, param, req.pagenum, req.pagesize, req.orderby);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            res.personalheaderinfo = Wraper.GetPersonalHeaderVM(db, atenadto, alertviewflg);    //個人一覧（ヘッダー情報）
            res.shidouinfolist = Wraper.GetHoumonVMList(db, pageList.dataTable.Rows);           //指導一覧

            //ページャー設定
            res.SetPageInfo(pageList.TotalCount, req.pagesize);

            //業務リストの初期化処理
            res.gyomulist = GetGyomuList(db);
            //事業リストの初期化処理（使用停止フラグを排除）
            res.h_jigyolist = GetJigyoList(db, req.hokensidokbn, 基準値業務区分._01);          //申込タブ用
            res.k_jigyolist = GetJigyoList(db, req.hokensidokbn, 基準値業務区分._02);          //結果タブ用

            return res;
        }

        /// <summary>
        /// ⑤世帯詳細画面検索処理(指導情報絞込)
        /// </summary>
        private SearchShidouDetailResponse SearchShidouDetail(DaDbContext db, SearchShidouDetailRequest req)
        {
            var res = new SearchShidouDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //該当宛名番号の保健指導情報を取得する
            //パラメータ取得
            var param = Converter.GetParameters(req.atenano, req.hokensidokbn, req.gyomukbn, req.jigyocd);

            //世帯情報一覧取得
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_02, param, req.pagenum, req.pagesize, req.orderby);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.shidouinfolist = Wraper.GetHoumonVMList(db, pageList.dataTable.Rows);         //指導一覧

            //業務リストの初期化処理
            res.gyomulist = GetGyomuList(db);

            //事業リストの初期化処理（使用停止フラグを排除）
            res.h_jigyolist = GetJigyoList(db, req.hokensidokbn, 基準値業務区分._01);          //申込タブ用
            res.k_jigyolist = GetJigyoList(db, req.hokensidokbn, 基準値業務区分._02);          //結果タブ用

            return res;
        }

        /// <summary>
        /// ⑥個人詳細画面検索処理(個人一覧)
        /// </summary>
        private SearchPersonDetailResponse SearchPersonDetail(DaDbContext db, SearchPersonDetailRequest req)
        {
            var res = new SearchPersonDetailResponse();

            //データ操作区分取得
            var kbn = GetKBN(db, req.hokensidokbn, req.gyomukbn, req.atenano, req.edano, req.mosikomikekkakbn);

            //⑦個人詳細画面検索処理機能を呼び出す
            var newres = SearchPersonShidou(db, req);

            res.personalfixinfo = newres.personalfixinfo;
            res.editflg = newres.editflg;
            res.grouplist1 = newres.grouplist1;
            res.grouplist2 = newres.grouplist2;
            res.freeitemlist = newres.freeitemlist;
            res.message = newres.message;
            res.returncode = newres.returncode;

            //A、該当宛名番号の個人情報を取得する
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
            //画面項目設定
            res.personalheaderinfo = Wraper.GetPersonalHeaderVM(db, atenadto, alertviewflg);    //個人一覧（ヘッダー情報）

            //地域保健集計区分リスト初期化
            var keys = EnumToStr(EnumNmKbn.地域保健集計区分);
            var maincd = (CLng(keys) / DaNameService.MAINCODE_DIGIT).ToString();
            var subcd = CInt((CLng(keys) % DaNameService.MAINCODE_DIGIT).ToString());

            var syukeikbndto = db.tm_afmeisyo.SELECT.WHERE.ByFilter($"{nameof(tm_afmeisyoDto.nmmaincd)}=@nmmaincd and " +
                                                                    $"{nameof(tm_afmeisyoDto.nmsubcd)}=@nmsubcd and " +
                                                                    $"{nameof(tm_afmeisyoDto.hanyokbn1)}=@hanyokbn1 and " +
                                                                    $"{nameof(tm_afmeisyoDto.hanyokbn2)}=@hanyokbn2"
                                                                    , maincd, subcd, req.hokensidokbn, req.gyomukbn).GetDtoList().OrderBy(e => e.nmcd);
            res.personalfixinfo.syukeikbnlist = syukeikbndto.Select(e => new DaSelectorModel(e.nmcd, e.nm)).ToList();

            if (kbn == EnumActionType.Update)
            {
                res.personalfixinfo.inputflg = true;
            }

            return res;
        }

        /// <summary>
        /// ⑦個人詳細画面検索処理(個人一覧)
        /// </summary>
        private SearchPersonShidouResponse SearchPersonShidou(DaDbContext db, SearchPersonDetailRequest req)
        {
            var res = new SearchPersonShidouResponse();
            var kaijonm = string.Empty;
            var mosidto = new tt_kkhokensido_mosikomiDto();
            var kekkadto = new tt_kkhokensido_kekkaDto();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.hokensidokbn, req.gyomukbn, req.atenano, req.edano, req.mosikomikekkakbn);
            //新規の場合、最新枝番を取得
            if (kbn == EnumActionType.Insert && req.edano == 0) { req.edano = GetNewEdano(db, req.hokensidokbn, req.gyomukbn, req.atenano); }

            //１．該当宛名番号の指定した保健指導区分・業務毎の個人明細部申込／結果固定項目を取得する
            if (req.mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //申込タブを選択した場合
                mosidto = db.tt_kkhokensido_mosikomi.GetDtoByKey(req.hokensidokbn, req.gyomukbn, req.atenano, req.edano);
                if (mosidto != null) { kaijonm = GetKaijyoNm(db, CStr(mosidto.kaijocd)); }      //2.会場名
            }
            else
            {
                //結果タブを選択した場合
                kekkadto = db.tt_kkhokensido_kekka.GetDtoByKey(req.hokensidokbn, req.gyomukbn, req.atenano, req.edano);
                if (kekkadto != null) { kaijonm = GetKaijyoNm(db, CStr(kekkadto.kaijocd)); }    //2.会場名
            }

            //3.事業従事者リスト取得
            var staffvm = new StaffSearchVM()
            {
                hokensidokbn = GetCd(req.hokensidokbn)!,
                gyomukbn = GetCd(req.gyomukbn)!,
                atenano = req.atenano,
                edano = req.edano,
                mosikomikekkakbn = GetCd(req.mosikomikekkakbn)!,
            };

            List<StaffListVM> stafflist = GetStaffList(db, staffvm);

            //フリー項目マスタ
            var freeMstDtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(req.hokensidokbn, req.gyomukbn, req.mosikomikekkakbn, "0").GetDtoList();
            
            //TODO_CNC劉_20240502_DB定義生成_UP217
            //freeMstDtl = freeMstDtl.Where(e => e.hyojiflg == true)          //表示フラグがtrueの項目のみ表示
            //                       .OrderBy(e => e.orderseq).ToList();      //表示順ソート：並び順

            //保健指導（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { EnumToStr(item.sidokbn), item.gyomukbn, EnumToStr(item.mosikomikekkakbn), item.itemcd, req.atenano, req.edano });
            }
            //全項目データ
            var dataDtl = db.tt_kkhokensidofree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            if (req.mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(mosidto?.regsisyo) || sisyoList.Contains(CStr(mosidto?.regsisyo));

                //申込タブを選択した場合
                res.personalfixinfo = Wraper.GetMosikomiBaseVM(db, mosidto!, kaijonm, stafflist, req.regsisyo!, kbn);   //個人一覧（申込固定情報）
            }
            else
            {
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(kekkadto?.regsisyo) || sisyoList.Contains(CStr(kekkadto?.regsisyo));

                //結果タブを選択した場合
                res.personalfixinfo = Wraper.GetKekkaBaseVM(db, kekkadto!, kaijonm, stafflist, req.regsisyo!, kbn);     //個人一覧（結果固定情報）
            }

            res.grouplist1 = GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ, req.hokensidokbn, req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.集団以外);
            res.grouplist2 = GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2, req.hokensidokbn, req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.集団以外);

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWKK00301G, req.gyomukbn);

            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWKK00301G, patternno);    //保健指導（フリー項目）一覧

            //事業リストの初期化処理（使用停止フラグを排除）
            res.personalfixinfo.jigyolist = GetJigyoList(db, req.hokensidokbn, req.gyomukbn);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(詳細画面)
        /// </summary>
        private CommonResponse Save(DaDbContext db, SaveRequest req, string jigyocd, string kinoid)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.登録チェック処理
            //-------------------------------------------------------------
            //業務チェック
            if (req.checkflg)
            {
                if (!Check(db, req, res))
                {
                    //異常返し
                    return res;
                }

                //正常返し
                return res;
            }

            //申込タブの場合
            if (req.maininfo.mosikomiinfo != null)
            {
                if (req.maininfo.mosikomiinfo.inputflg)
                {
                    //申込情報入力フラグがチェックする場合、登録処理を行う
                    res = Save_Mosikomi(db, req);
                    if (!res.returncode.Equals(EnumServiceResult.OK)) { return res; }
                }
                else
                {
                    //申込情報入力フラグがチェックしない場合、削除処理を行う
                    var delreq = GetDelReq(req);
                    var delres = Delete(db, delreq, 申込結果区分._1);
                    //if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //結果タブの場合
            if (req.maininfo.kekkainfo != null)
            {
                if (req.maininfo.kekkainfo.inputflg)
                {
                    //結果情報入力フラグがチェックする場合、登録処理を行う
                    res = Save_Kekka(db, req);
                }
                else
                {
                    //結果情報入力フラグがチェックしない場合、削除処理を行う
                    var delreq = GetDelReq(req);
                    var delres = Delete(db, delreq, 申込結果区分._2);
                    //if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(詳細画面)--申込タブ
        /// </summary>
        private CommonResponse Save_Mosikomi(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano, 申込結果区分._1);

            //新規の場合、最新枝番を取得
            if (kbn == EnumActionType.Insert && req.maininfo.edano == 0) { req.maininfo.edano = GetNewEdano(db, req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano); }

            var olddto = new tt_kkhokensido_mosikomiDto();                      //保健指導申込情報（固定項目）テーブル
            //申込フリー項目一覧
            var oldfreedtl = new List<tt_kkhokensidofreeDto>();                 //保健指導事業（フリー項目）入力情報テーブル


            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //申込情報を取得
                olddto = db.tt_kkhokensido_mosikomi.GetDtoByKey(req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "申込情報", tt_kkhokensido_mosikomiDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //申込フリー項目一覧情報を取得
                oldfreedtl = db.tt_kkhokensidofree.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                                         , req.maininfo.hokensidokbn, req.maininfo.gyomukbn, 申込結果区分._1, req.maininfo.atenano, req.maininfo.edano).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_kkhokensido_mosikomiDto();                  //保健指導申込情報（固定項目）テーブル
            var newfreedtl = new List<tt_kkhokensidofreeDto>();             //保健指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //保健指導申込情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //申込フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_kkhokensidofreeDto();
                    var row = req.maininfo.mosikomiinfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //保健指導申込情報（固定項目）テーブル
                newdto = Converter.GetDto(newdto, req, kbn);
                //申込フリー項目一覧
                foreach (var dt in req.maininfo.mosikomiinfo.freeiteminfo)
                {
                    var newfreedto = new tt_kkhokensidofreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1, 申込結果区分._1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_kkhokensido_mosikomi.INSERT.Execute(newdto);      //保健指導申込情報（固定項目）テーブル

                //保健指導事業（フリー項目）入力情報テーブル（申込情報）
                db.tt_kkhokensidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                            , req.maininfo.hokensidokbn, req.maininfo.gyomukbn, 申込結果区分._1, req.maininfo.atenano, req.maininfo.edano).Execute();
                db.tt_kkhokensidofree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kkhokensido_mosikomi.UPDATE.Execute(newdto);      //保健指導申込情報（固定項目）テーブル
                db.tt_kkhokensidofree.UPDATE.Execute(newfreedtl);       //保健指導事業（フリー項目）入力情報テーブル（申込情報）
            }


            //保健指導担当者テーブルを登録
            //①予定者リストを削除する
            db.tt_kkhokensido_staff.DELETE.WHERE.ByKey(req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano, 申込結果区分._1).Execute();
            //②予定者リストを登録する
            if (req.maininfo.mosikomiinfo.stafflist != null)
            {
                var staffdtl = new List<tt_kkhokensido_staffDto>();
                foreach (var item in req.maininfo.mosikomiinfo.stafflist)
                {
                    var staffdto = new tt_kkhokensido_staffDto();
                    staffdto = Converter.GetDto(staffdto, item, req, 申込結果区分._1);
                    staffdtl.Add(staffdto);
                }

                db.tt_kkhokensido_staff.INSERT.Execute(staffdtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(詳細画面)--結果タブ
        /// </summary>
        private CommonResponse Save_Kekka(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano, 申込結果区分._2);

            //新規の場合、最新枝番を取得
            if (kbn == EnumActionType.Insert && req.maininfo.edano == 0) { req.maininfo.edano = GetNewEdano(db, req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano); }

            var olddto = new tt_kkhokensido_kekkaDto();             //保健指導結果情報（固定項目）テーブル
            //結果フリー項目一覧
            var oldfreedtl = new List<tt_kkhokensidofreeDto>();     //保健指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //結果情報を取得
                olddto = db.tt_kkhokensido_kekka.GetDtoByKey(req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "結果情報", tt_kkhokensido_kekkaDto.TABLE_NAME);
                    res.SetServiceError(msg);
                    return res;   //異常返し
                }
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //結果フリー項目一覧情報を取得
                oldfreedtl = db.tt_kkhokensidofree.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                                         $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                                         , req.maininfo.hokensidokbn, req.maininfo.gyomukbn, 申込結果区分._2, req.maininfo.atenano, req.maininfo.edano).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------

            var newdto = new tt_kkhokensido_kekkaDto();             //保健指導結果情報（固定項目）テーブル
            var newfreedtl = new List<tt_kkhokensidofreeDto>();     //保健指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //保健指導結果情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //結果フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    if (dt == null) { continue; }

                    var newfreedto = new tt_kkhokensidofreeDto();
                    var row = req.maininfo.kekkainfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));  //汎用区分1

                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //保健指導結果情報（固定項目）テーブル
                newdto = Converter.GetDto(newdto, req, kbn);
                //結果フリー項目一覧
                foreach (var dt in req.maininfo.kekkainfo.freeiteminfo)
                {
                    var newfreedto = new tt_kkhokensidofreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));  //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1, 申込結果区分._2);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_kkhokensido_kekka.INSERT.Execute(newdto);         //保健指導結果情報（固定項目）テーブル

                //保健指導事業（フリー項目）入力情報テーブル（結果情報）
                db.tt_kkhokensidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                            , req.maininfo.hokensidokbn, req.maininfo.gyomukbn, 申込結果区分._2, req.maininfo.atenano, req.maininfo.edano).Execute();
                db.tt_kkhokensidofree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kkhokensido_kekka.UPDATE.Execute(newdto);         //保健指導結果情報（固定項目）テーブル
                db.tt_kkhokensidofree.UPDATE.Execute(newfreedtl);       //保健指導事業（フリー項目）入力情報テーブル（結果情報）
            }


            //保健指導担当者テーブルを登録
            //①予定者リストを削除する
            db.tt_kkhokensido_staff.DELETE.WHERE.ByKey(req.maininfo.hokensidokbn, req.maininfo.gyomukbn, req.maininfo.atenano, req.maininfo.edano, 申込結果区分._2).Execute();
            //②予定者リストを登録する
            if (req.maininfo.kekkainfo.stafflist != null)
            {
                var staffdtl = new List<tt_kkhokensido_staffDto>();
                foreach (var item in req.maininfo.kekkainfo.stafflist)
                {
                    var staffdto = new tt_kkhokensido_staffDto();
                    staffdto = Converter.GetDto(staffdto, item, req, 申込結果区分._2);
                    staffdtl.Add(staffdto);
                }
                db.tt_kkhokensido_staff.INSERT.Execute(staffdtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(詳細画面)
        /// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req, string mosikomikekkakbn)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //存在チェック
            if (!Check(db, req, res, mosikomikekkakbn)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //申込タブの場合
                //保健指導申込情報（固定項目）テーブル
                db.tt_kkhokensido_mosikomi.DELETE.WHERE.ByKey(req.hokensidokbn, req.gyomukbn, req.atenano, req.edano).Execute();

                //保健指導事業（フリー項目）入力情報テーブル（申込タブ）
                db.tt_kkhokensidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                            , req.hokensidokbn, req.gyomukbn, 申込結果区分._1, req.atenano, req.edano).Execute();

                //保健指導担当者テーブル（申込タブ）
                db.tt_kkhokensido_staff.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensido_staffDto.hokensidokbn)}=@hokensidokbn and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.atenano)}=@atenano and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.edano)}=@edano and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                              , req.hokensidokbn, req.gyomukbn, req.atenano, req.edano, 申込結果区分._1).Execute();
            }

            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._2))
            {
                //結果タブの場合
                //保健指導結果情報（固定項目）テーブル
                db.tt_kkhokensido_kekka.DELETE.WHERE.ByKey(req.hokensidokbn, req.gyomukbn, req.atenano, req.edano).Execute();

                //保健指導事業（フリー項目）入力情報テーブル（結果タブ）
                db.tt_kkhokensidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensidofreeDto.hokensidokbn)}=@hokensidokbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.atenano)}=@atenano and " +
                                                            $"{nameof(tt_kkhokensidofreeDto.edano)}=@edano"
                                                            , req.hokensidokbn, req.gyomukbn, 申込結果区分._2, req.atenano, req.edano).Execute();

                //保健指導担当者テーブル（結果タブ）
                db.tt_kkhokensido_staff.DELETE.WHERE.ByFilter($"{nameof(tt_kkhokensido_staffDto.hokensidokbn)}=@hokensidokbn and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.atenano)}=@atenano and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.edano)}=@edano and " +
                                                              $"{nameof(tt_kkhokensido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                              , req.hokensidokbn, req.gyomukbn, req.atenano, req.edano, 申込結果区分._2).Execute();
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 初期化処理(詳細画面)
        /// </summary>
        private InitDetailResponse InitDetail(DaDbContext db, DaRequestBase req)
        {
            var res = new InitDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //事業リスト　※：事業リストの初期化処理は「個人一覧」画面と「個人詳細」画面で保健指導区分、業務区分、使用停止フラグにより動的設定する

            //実施場所（会場）リスト
            var kaijodto = db.tm_afkaijo.SELECT.WHERE.ByFilter($"({nameof(tm_afkaijoDto.stopflg)}='{停止フラグ._0}')").GetDtoList().OrderBy(e => e.kaijocd);
            var kaijodtl = kaijodto.Select(e => new DaSelectorModel(e.kaijocd, e.kaijonm)).ToList();

            //事業従事者（担当者）リスト
            var staffdto = db.tm_afstaff.SELECT.WHERE.ByFilter($"({nameof(tm_afstaffDto.stopflg)}='{停止フラグ._0}')").GetDtoList().OrderBy(e => e.staffid);
            var staffdtl = staffdto.Select(e => new DaSelectorModel(e.staffid, e.staffsimei)).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.initdetail = Wraper.GetVM(db, kaijodtl, staffdtl);

            //正常返し
            return res;
        }

        /// <summary>
        /// 実施日時点年齢取得処理
        /// </summary>
        private GetAgeResponse GetAge(DaDbContext db, GetAgeRequest req)
        {
            var res = new GetAgeResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民情報")) { return res; }  //異常返し

                res.nenrei = Wraper.GetVM(db, dto, req.yoteiymd);
            }

            //正常返し
            return res;
        }

        //************************************************************** 関数 **************************************************************
        /// <summary>
        /// kinoidから事業コード取得
        /// </summary>
        private string GetJigyocd(string kinoid)
        {
            return "090";
        }

        /// <summary>
        /// 存在チェック(削除)
        /// </summary>
        private bool Check(DaDbContext db, DeleteRequest req, CommonResponse res, string mosikomikekkakbn)
        {
            if (string.IsNullOrEmpty(mosikomikekkakbn)) { return true; }

            var err1 = false; var err2 = false;

            //保健指導申込情報（固定項目）テーブル
            if (!db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_mosikomiDto.hokensidokbn)}=@hokensidokbn and " +
                                                                  $"{nameof(tt_kkhokensido_mosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                  $"{nameof(tt_kkhokensido_mosikomiDto.atenano)}=@atenano and " +
                                                                  $"{nameof(tt_kkhokensido_mosikomiDto.edano)}=@edano"
                                                                  , req.hokensidokbn, req.gyomukbn, req.atenano, req.edano).Exists()) { err1 = true; }
            //保健指導結果情報（固定項目）テーブル
            if (!db.tt_kkhokensido_kekka.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_kekkaDto.hokensidokbn)}=@hokensidokbn and " +
                                                               $"{nameof(tt_kkhokensido_kekkaDto.gyomukbn)}=@gyomukbn and " +
                                                               $"{nameof(tt_kkhokensido_kekkaDto.atenano)}=@atenano and " +
                                                               $"{nameof(tt_kkhokensido_kekkaDto.edano)}=@edano"
                                                               , req.hokensidokbn, req.gyomukbn, req.atenano, req.edano).Exists()) { err2 = true; }
            if (err1 && err2)
            {
                var msg = DaMessageService.GetMsg(EnumMessage.A000008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登録チェック（個人詳細画面）
        /// </summary>
        private static bool Check(DaDbContext db, SaveRequest req, CommonResponse res)
        {
            if ((req.maininfo.mosikomiinfo != null && req.maininfo.mosikomiinfo.inputflg) && (req.maininfo.kekkainfo != null && req.maininfo.kekkainfo.inputflg))
            {
                //申込／結果情報両方存在している場合、登録チェックを行う
                if (!req.maininfo.mosikomiinfo.jigyo.Equals(req.maininfo.kekkainfo.jigyo))
                {
                    //E014009：申込と結果情報の事業コードが一致していません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E014009);
                    res.SetServiceError(msg);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 世帯情報（地区情報）を取得SQL
        /// </summary>
        private string GetTikuSql(string atenano, int maxno, EnumNmKbn kbn)
        {
            var sql = string.Empty;

            var kbnstr = EnumToStr(kbn);
            var nmmaincd_in = (CLng(kbnstr) / MAINCODE_DIGIT).ToString();
            var nmsubcd_in = (CLng(kbnstr) % MAINCODE_DIGIT).ToString();
            var hanyokbn1_in = DISPLAYFLG_1;

            sql = $"select X.nm as tikukbn, X.tikunm as tiku{C_LF}";
            sql = $"{sql}  from({C_LF}";

            for (int i = 1; i <= maxno; i++)
            {
                sql = $"{sql}{SPACE}select M.nmcd, M.nm, A.tikukanricd{i} AS tikukanricd, B.tikunm{C_LF}";
                sql = $"{sql}{SPACE}from tt_afatena A{C_LF}";
                sql = $"{sql}{SPACE}left join tm_aftiku B{C_LF}";
                sql = $"{sql}{SPACE}on B.tikucd = A.tikukanricd{i}{C_LF}";
                sql = $"{sql}{SPACE}left join tm_afmeisyo M{C_LF}";
                sql = $"{sql}{SPACE}on M.nmmaincd = '{nmmaincd_in}' and M.nmsubcd = {nmsubcd_in} and M.nmcd = '{i}'{C_LF}";
                sql = $"{sql}{SPACE}and(B.tikukbn is null OR M.nmcd = CAST(B.tikukbn AS TEXT)) and M.hanyokbn1 = '{hanyokbn1_in}'{C_LF}";
                sql = $"{sql}{SPACE}where A.atenano = '{atenano}'{C_LF}";

                if (i < maxno)
                {
                    sql = $"{sql}{SPACE}union{C_LF}";
                }
            }

            sql = $"{sql}{SPACE}) X{C_LF}";
            sql = $"{sql}{SPACE}where X.nmcd is not null{C_LF}";
            sql = $"{sql}{SPACE}order by lpad(X.nmcd, 2, '0'){C_LF}";

            return sql;
        }

        /// <summary>
        /// 会場名取得
        /// </summary>
        private string GetKaijyoNm(DaDbContext db, string kaijocd)
        {
            if (string.IsNullOrEmpty(kaijocd)) { return string.Empty; }

            var kaijodto = db.tm_afkaijo.GetDtoByKey(kaijocd);
            if (kaijodto == null) { return string.Empty; }

            return $"{kaijocd}{SPACE}{COLON}{SPACE}{kaijodto.kaijonm}";

        }

        /// <summary>
        ///新規登録する際に、枝番の付与は、該当指導区分＋業務区分＋宛名番号の申込・結果の最大枝番を取得う
        /// </summary>
        private int GetNewEdano(DaDbContext db, string hokensidokbn, string gyomukbn, string atenano)
        {
            int mmaxedano = 0;
            int kmaxedano = 0;

            var mdtl = db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_mosikomiDto.hokensidokbn)}=@hokensidokbn and " +
                                                                             $"{nameof(tt_kkhokensido_mosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                             $"{nameof(tt_kkhokensido_mosikomiDto.atenano)}=@atenano "
                                                                             , hokensidokbn, gyomukbn, atenano).GetDtoList();
            if (mdtl.Count == 0)
            {
                mmaxedano = 1;
            }
            else
            {
                mmaxedano = mdtl.Select(e => e.edano).Max();
            }

            var kdtl = db.tt_kkhokensido_kekka.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_kekkaDto.hokensidokbn)}=@hokensidokbn and " +
                                                                          $"{nameof(tt_kkhokensido_kekkaDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kkhokensido_kekkaDto.atenano)}=@atenano"
                                                                          , hokensidokbn, gyomukbn, atenano).GetDtoList();
            if (kdtl.Count == 0)
            {
                kmaxedano = 1;
            }
            else
            {
                kmaxedano = kdtl.Select(e => e.edano).Max();
            }

            if (mmaxedano > kmaxedano)
            {
                return mmaxedano + 1;
            }
            else
            {
                return kmaxedano + 1;
            }
        }

        /// <summary>
        ///保健指導担当者テーブルから全ての予定者／実施者を取得する、,区切り
        /// </summary>
        private List<StaffListVM> GetStaffList(DaDbContext db, StaffSearchVM req)
        {
            List<StaffListVM> list = new List<StaffListVM>();

            var staffdto = db.tt_kkhokensido_staff.SELECT.WHERE.ByFilter($"{nameof(tt_kkhokensido_staffDto.hokensidokbn)}=@hokensidokbn and " +
                                                                         $"{nameof(tt_kkhokensido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                                         $"{nameof(tt_kkhokensido_staffDto.atenano)}=@atenano and " +
                                                                         $"{nameof(tt_kkhokensido_staffDto.edano)}=@edano and " +
                                                                         $"{nameof(tt_kkhokensido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn",
                                                                         req.hokensidokbn, req.gyomukbn, req.atenano, req.edano, req.mosikomikekkakbn).GetDtoList();
            foreach (var staff in staffdto)
            {
                var vm = new StaffListVM();

                vm.staffid = staff.staffid;
                if (!string.IsNullOrEmpty(vm.staffid)) { vm.staffsimei = db.tm_afstaff.GetDtoByKey(vm.staffid).staffsimei; }

                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 画面のデータ操作区分取得
        /// </summary>
        private EnumActionType? GetKBN(DaDbContext db, string hokensidokbn, string gyomukbn, string atenano, int edano, string mosikomikbn)
        {
            if (edano == 0) { return EnumActionType.Insert; }

            EnumActionType? kbn = null;

            if (mosikomikbn.Equals(申込結果区分._1))
            {
                if (db.tt_kkhokensido_mosikomi.SELECT.WHERE.ByKey(hokensidokbn, gyomukbn, atenano, edano).Exists())
                {
                    kbn = EnumActionType.Update;        //編集フラグ☑=>更新
                }
                else
                {
                    kbn = EnumActionType.Insert;        //編集フラグ☑=>新規
                }
            }
            else
            {
                if (db.tt_kkhokensido_kekka.SELECT.WHERE.ByKey(hokensidokbn, gyomukbn, atenano, edano).Exists())
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
        ///保存処理のリクエスト内容から削除処理のリクエストを設定
        /// </summary>
        private DeleteRequest GetDelReq(SaveRequest req)
        {
            var delreq = new DeleteRequest()
            {
                atenano = req.maininfo.atenano,             //宛名番号
                hokensidokbn = req.maininfo.hokensidokbn,   //保健指導区分
                gyomukbn = req.maininfo.gyomukbn,           //業務区分
                edano = req.maininfo.edano,                 //枝番
            };

            return delreq;
        }

        /// <summary>
        ///その他日程事業・保健指導事業マスタから事業リストを取得
        /// </summary>
        private List<DaSelectorModel> GetJigyoList(DaDbContext db, string hokensidokbn, string gyomukbn)
        {
            FrResult result = new FrResult();
            var sql = string.Empty;

            sql = $"{sql}{SPACE}SELECT jigyocd, jigyonm{C_LF}";
            sql = $"{sql}{SPACE}FROM tm_kksonotasidojigyo{C_LF}";
            sql = $"{sql}{SPACE}WHERE 1=1{C_LF}";

            if (hokensidokbn.Equals(指導区分._1))
            {
                sql = $"{sql}{SPACE}AND homonriyoflg=true";         //訪問指導の場合
            }
            else if (hokensidokbn.Equals(指導区分._2))
            {
                sql = $"{sql}{SPACE}AND sodanriyoflg=true";         //個別指導の場合
            }
            if (!string.IsNullOrEmpty(gyomukbn))
            {
                sql = $"{sql}{SPACE}AND gyomukbn = '{gyomukbn}'"; 　//業務区分ありの場合         
            }
            sql = $"{sql}{SPACE}AND stopflg=false";

            DataTable jigyodto = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            var list = Wraper.GetJigyoVMList(db, jigyodto);         //事業リスト

            return list;
        }

        /// <summary>
        ///事業コードから事業（コード : 名称）を取得
        /// </summary>
        public static string GetJigyoCdNm(DaDbContext db, string jigyocd)
        {
            if (string.IsNullOrEmpty(jigyocd)) { return string.Empty; }

            var dto = db.tm_kksonotasidojigyo.GetDtoByKey(jigyocd);
            if (dto == null) { return string.Empty; }
            return $"{dto.jigyocd} : {dto.jigyonm}";
        }

        /// <summary>
        ///事業コードから事業（名称）を取得
        /// </summary>
        public static string GetJigyoNm(DaDbContext db, string jigyocd)
        {
            if (string.IsNullOrEmpty(jigyocd)) { return string.Empty; }

            var dto = db.tm_kksonotasidojigyo.GetDtoByKey(jigyocd);
            if (dto == null) { return string.Empty; }
            return dto.jigyonm;
        }

        /// <summary>
        ///保健指導用業務リストを取得
        /// </summary>
        private static List<DaSelectorModel> GetGyomuList(DaDbContext db)
        {
            var list = Wraper.MList(db, EnumNmKbn.拡張_予約_保健指導業務区分);
            var gyomulist = new List<DaSelectorModel>();

            foreach (var item in list)
            {
                if (item.value.Equals(基準値業務区分._01) || (item.value.Equals(基準値業務区分._02)))
                {
                    gyomulist.Add(item);
                }
            }

            return gyomulist;
        }

        /// <summary>
        /// 保健指導フリー項目グループを取得（初期化時）
        /// </summary>
        public static List<DaSelectorModel> GetHokensidoGroupList(DaDbContext db, Enumフリー項目グループNo group)
        {
            var dtlGrp = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.保健指導_集団指導項目グループ);
            var listGrp = new List<DaSelectorModel>();
            foreach (var dtoHanyo in dtlGrp)
            {
                var hanyokbn2Arr = dtoHanyo.hanyokbn2!.ToArray();
                if (hanyokbn2Arr.Length == GRPKBN2LEN)
                {
                    if (dtoHanyo.hanyokbn1 == EnumToStr(group)
                            && (CStr(hanyokbn2Arr[0]) == EnumToStr(Enum指導区分.個別指導)
                                || CStr(hanyokbn2Arr[0]) == EnumToStr(Enum指導区分.訪問指導)))
                    {
                        listGrp.Add(new DaSelectorModel(dtoHanyo.hanyocd, CStr(dtoHanyo.nm)));
                    }
                }
            }
            listGrp = listGrp.OrderBy(e => e.value).ToList();

            return listGrp;
        }

        /// <summary>
        /// 保健指導フリー項目グループを取得（保健指導：個別指導、訪問指導）
        /// </summary>
        public static List<DaSelectorModel> GetHokensidoGroupList(DaDbContext db, Enumフリー項目グループNo group, string hokensidokbn, string gyomukbn, string mosikomikekkakbn, Enum項目用途区分 itemyotokbn)
        {
            var dtlGrp = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.保健指導_集団指導項目グループ);
            var listGrp = new List<DaSelectorModel>();
            foreach (var dtoHanyo in dtlGrp)
            {
                var hanyokbn2Arr = dtoHanyo.hanyokbn2!.ToArray();
                if (hanyokbn2Arr.Length == GRPKBN2LEN)
                {
                    if (
                        dtoHanyo.hanyokbn1 == EnumToStr(group) &&                         //グループ
                        CStr(hanyokbn2Arr[0]) == hokensidokbn &&                          //指導区分（1:訪問指導　2:個別指導　3:集団指導）
                        $"{CStr(hanyokbn2Arr[1])}{CStr(hanyokbn2Arr[2])}" == gyomukbn &&  //業務区分（01:成人保健　02:母子保健）
                        CStr(hanyokbn2Arr[3]) == mosikomikekkakbn &&                      //申込結果区分（1:申込　2:結果）
                        CStr(hanyokbn2Arr[4]) == EnumToStr(itemyotokbn)                   //項目用途区分（0:集団指導以外の場合　1:集団指導事業用　2:集団指導参加者用）
                       )
                    {
                        listGrp.Add(new DaSelectorModel(dtoHanyo.hanyocd, CStr(dtoHanyo.nm)));
                    }
                }
            }
            listGrp = listGrp.OrderBy(e => e.value).ToList();

            return listGrp;
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
        /// 検索結果の総件数を取得
        /// </summary>
        public static int GetResultTotalCount(DaDbContext db, string bhsyurui, FrCondition condition, int orderColumn, bool noCheck)
        {
            var pageno = condition.PageNo;
            var pagesize = condition.PageRowCount;
            condition.PageRowCount = -1;
            //検索結果
            var result = DaFreeQuery.GetSidoQuery(db, bhsyurui, condition, orderColumn, true);
            condition.PageNo = pageno;
            condition.PageRowCount = pagesize;

            return result.Data.Rows.Count;
        }
    }
}