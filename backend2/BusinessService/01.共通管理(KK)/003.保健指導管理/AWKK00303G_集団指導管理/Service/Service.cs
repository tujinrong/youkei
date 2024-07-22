// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 集団指導管理
// 　　　　　　サービス処理
// 作成日　　: 2023.12.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.システム;
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaStrPool;
using static BCC.Affect.DataAccess.DaNameService;
using AIplus.FreeQuery.Common;
using static BCC.Affect.Service.AWKK00301G.Service;
using System.Collections.Generic;

namespace BCC.Affect.Service.AWKK00303G
{
    [DisplayName("集団指導管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00303G = "AWKK00303G";

        //定数定義
        private const string PROC_NAME_01 = "sp_awkk00303g_01"; //②集団指導一覧画面検索処理(一覧画面)用
        private const string SANKASYA_TABKBN = "3";             //参加者タブ区分
        private const int GRPKBN2LEN = 5;                       //保健指導・集団指導項目グループ用汎用区分2内容の固定長さ


        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return InitDetail(db, req);
            });
        }

        [DisplayName("集団一覧画面検索処理(検索画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchList(db, req);
            });
        }

        [DisplayName("指導情報検索処理")]
        public SearchDetailResponse SearchDetail(SearchDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchDetail(db, req);
            });
        }

        [DisplayName("参加者情報検索処理")]
        public SearchSankasyaListResponse SearchSankasyaList(SearchSankasyaListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSankasyaList(db, req);
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

        [DisplayName("参加者詳細画面検索処理")]
        public SearchSankasyaDetailResponse SearchSankasyaDetail(SearchSankasyaDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return SearchSankasyaDetail(db, req);
            });
        }

        [DisplayName("参加者保存処理")]
        public CommonResponse SaveSankasya(SaveSankasyaRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //Todo：kinoidから事業コード取得、共通関数があれば入れ替える
                var jigyocd = GetJigyocd(req.kinoid!);

                //正常返し
                return SaveSankasya(db, req, jigyocd, req.kinoid!);
            });
        }

        [DisplayName("参加者削除処理")]
        public CommonResponse DeleteSankasya(DeleteSankasyaRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //正常返し
                return DeleteSankasya(db, req, string.Empty);
            });
        }

        //************************************************************** 処理ロジェック **************************************************************
        /// <summary>
        /// ①初期化処理(詳細画面)
        /// </summary>
        private InitDetailResponse InitDetail(DaDbContext db, DaRequestBase req)
        {
            var res = new InitDetailResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //事業リストの初期化処理（使用停止フラグ無視:false）
            var jigyolist = GetJigyoList(db, 指導区分._3, string.Empty, false);      //申込タブ用

            //実施場所（会場）リスト
            var kaijodto = db.tm_afkaijo.SELECT.WHERE.ByFilter($"({nameof(tm_afkaijoDto.stopflg)}='{停止フラグ._0}')").GetDtoList().OrderBy(e => e.kaijocd);
            var kaijodtl = kaijodto.Select(e => new DaSelectorModel(e.kaijocd, e.kaijonm)).ToList();

            //事業従事者（担当者）リスト
            var staffdto = db.tm_afstaff.SELECT.WHERE.ByFilter($"({nameof(tm_afstaffDto.stopflg)}='{停止フラグ._0}')").GetDtoList().OrderBy(e => e.staffid);
            var staffdtl = staffdto.Select(e => new StaffListVM() { staffid = e.staffid, staffsimei = e.staffsimei }).ToList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            res.initdetail = Wraper.GetVM(db, jigyolist, kaijodtl, staffdtl);

            //正常返し
            return res;
        }

        /// <summary>
        /// ②集団一覧画面検索処理(検索画面)
        /// </summary>
        private SearchListResponse SearchList(DaDbContext db, SearchListRequest req)
        {
            var res = new SearchListResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //宛名番号
            if (!string.IsNullOrEmpty(req.atenano))
            {
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) { return res; }  //異常返し
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            //集団指導一覧情報を取得する
            //パラメータ取得
            var param = Converter.GetParameters(req);

            //集団指導情報一覧取得
            var pageList = DaDbUtil.GetListData(db, PROC_NAME_01, param, req.pagenum, req.pagesize, req.orderby);

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //画面項目設定
            res.kekkalist = Wraper.GetSyudanVMList(db, pageList.dataTable.Rows);   //集団指導一覧

            //ページャー設定
            res.SetPageInfo(pageList.TotalCount, req.pagesize);

            //正常返し
            return res;
        }

        /// <summary>
        /// ③個別入力画面検索処理(集団指導管理の検索結果一覧の行をクリックした場合)
        /// ③新規ボタンを押下の場合
        /// ④指導情報検索処理テスト用（個別入力画面のタブを選択（申込／結果））
        /// </summary>
        private SearchDetailResponse SearchDetail(DaDbContext db, SearchDetailRequest req)
        {
            var res = new SearchDetailResponse();

            var kaijonm = string.Empty;
            var mosidto = new tt_kksyudansido_mosikomiDto();         //集団指導申込情報（固定項目）テーブル
            var kekkadto = new tt_kksyudansido_kekkaDto();           //集団指導結果情報（固定項目）テーブル

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、データ操作区分取得
            var kbn = GetKBN(db, req.gyomukbn, req.edano, req.mosikomikekkakbn);
            //新規の場合
            if (kbn == EnumActionType.Insert && req.edano == 0) { req.edano = GetNewEdano(db, req.gyomukbn); }    //1.最新枝番を取得

            //B、業務／枝番毎の集団指導申込／結果固定項目を取得する
            if (req.mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //申込タブを選択した場合
                mosidto = db.tt_kksyudansido_mosikomi.GetDtoByKey(req.gyomukbn, req.edano);
                if (mosidto != null) { kaijonm = GetKaijyoNm(db, CStr(mosidto.kaijocd)); }      //2.会場名
            }
            else
            {
                //結果タブを選択した場合
                kekkadto = db.tt_kksyudansido_kekka.GetDtoByKey(req.gyomukbn, req.edano);
                if (kekkadto != null) { kaijonm = GetKaijyoNm(db, CStr(kekkadto.kaijocd)); }    //2.会場名
            }

            //3.事業従事者リスト取得
            List<StaffListVM> stafflist = GetStaffList(db, req.gyomukbn, req.edano, req.mosikomikekkakbn);

            //C、業務／枝番毎の集団指導フリー項目を取得する
            var freeMstDtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(指導区分._3, req.gyomukbn, req.mosikomikekkakbn, フリー項目用途区分._1).GetDtoList();
            
            //TODO_CNC_20240502_DB定義生成_UP217
            //freeMstDtl = freeMstDtl.Where(e => e.hyojiflg == true)                              //表示フラグがtrueの項目のみ表示
            //                       .OrderBy(e => e.orderseq).ToList();                          //表示順ソート：並び順

            //集団指導（フリー項目）テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { item.gyomukbn, req.edano, EnumToStr(item.mosikomikekkakbn), item.itemcd });
            }
            //全項目データ
            var dataDtl = db.tt_kksyudansidofree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

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
                res.fixinfo = Wraper.GetMosikomiBaseVM(db, mosidto!, kaijonm, stafflist, req.regsisyo!, kbn);   //申込固定情報
            }
            else
            {
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(kekkadto?.regsisyo) || sisyoList.Contains(CStr(kekkadto?.regsisyo));

                //結果タブを選択した場合
                res.fixinfo = Wraper.GetKekkaBaseVM(db, kekkadto!, kaijonm, stafflist, req.regsisyo!, kbn);     //結果固定情報
            }

            res.grouplist1 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);
            res.grouplist2 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.事業用);

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWKK00303G, req.gyomukbn);

            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWKK00303G, patternno);        //集団指導（フリー項目）一覧


            //事業リストの初期化処理（使用停止フラグも判断:true）
            res.fixinfo.jigyolist = GetJigyoList(db, 指導区分._3, req.gyomukbn, true);

            //申込情報入力設定
            if (kbn == EnumActionType.Update)
            {
                res.fixinfo.inputflg = true;
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑤参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ））
        /// </summary>
        private SearchSankasyaListResponse SearchSankasyaList(DaDbContext db, SearchSankasyaListRequest req)
        {
            var res = new SearchSankasyaListResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、該当業務／枝番の事業情報を取得（コード : 名称）
            res.jigyo = AWKK00301G.Service.GetJigyoCdNm(db, req.jigyocd);                       //事業（コード : 名称）

            //B、該当業務／枝番毎参加者一覧を取得
            FrResult result = new FrResult();
            var sql = GetAtenaSql(req);
            DataTable dto = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //画面項目設定
            res.sankasyalist = Wraper.GetSankasyaInfoVMList(db, dto, alertviewflg);             //参加者一覧

            //参加者情報入力設定
            res.inputflg = res.sankasyalist.Count > 0 ? true : false;

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑥保存処理(個別入力画面)
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
                    res = Save_M(db, req);
                    if (!res.returncode.Equals(EnumServiceResult.OK)) { return res; }
                }
                else
                {
                    //申込情報入力フラグがチェックしない場合、申込情報の削除処理を行う
                    var delreq = GetDelReq(req);
                    var delres = Delete(db, delreq, 申込結果区分._1);
                    if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //結果タブの場合
            if (req.maininfo.kekkainfo != null)
            {
                if (req.maininfo.kekkainfo.inputflg)
                {
                    //結果情報入力フラグがチェックする場合、登録処理を行う
                    res = Save_K(db, req);
                }
                else
                {
                    //結果情報入力フラグがチェックしない場合、結果情報の削除処理を行う
                    var delreq = GetDelReq(req);
                    var delres = Delete(db, delreq, 申込結果区分._2);
                    if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //参加者タブの場合
            if (req.maininfo.sankasyainfo != null)
            {
                if (req.maininfo.sankasyainfo.inputflg)
                {
                    //参加者情報入力フラグがチェックする場合、登録処理を行う
                    res = Save_S(db, req);
                    if (!res.returncode.Equals(EnumServiceResult.OK)) { return res; }
                }
                else
                {
                    //参加者情報入力フラグがチェックしない場合、集団指導参加者情報の削除処理を行う
                    var delreq = GetDelReq(req);
                    var delres = Delete(db, delreq, SANKASYA_TABKBN);
                    if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(個別入力画面)--申込タブ
        /// </summary>
        private CommonResponse Save_M(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1);

            //新規の場合
            if (kbn == EnumActionType.Insert && req.maininfo.edano == 0) { req.maininfo.edano = GetNewEdano(db, req.maininfo.gyomukbn); }      //最新枝番を取得

            var olddto = new tt_kksyudansido_mosikomiDto();         //集団指導申込情報（固定項目）テーブル
            //申込フリー項目一覧
            var oldfreedtl = new List<tt_kksyudansidofreeDto>();    //集団指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //申込情報を取得
                olddto = db.tt_kksyudansido_mosikomi.GetDtoByKey(req.maininfo.gyomukbn, req.maininfo.edano);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "申込情報", tt_kksyudansido_mosikomiDto.TABLE_NAME);
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
                oldfreedtl = db.tt_kksyudansidofree.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                                          $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                                          , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_kksyudansido_mosikomiDto();             //集団指導申込情報（固定項目）テーブル
            var newfreedtl = new List<tt_kksyudansidofreeDto>();        //集団指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //集団指導申込情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //申込フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_kksyudansidofreeDto();
                    var row = req.maininfo.mosikomiinfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));    //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //集団指導申込情報（固定項目）テーブル
                newdto = Converter.GetDto(newdto, req, kbn);

                //申込フリー項目一覧
                foreach (var dt in req.maininfo.mosikomiinfo.freeiteminfo)
                {
                    var newfreedto = new tt_kksyudansidofreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));     //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1, req.maininfo.edano, 申込結果区分._1);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_kksyudansido_mosikomi.INSERT.Execute(newdto);         //集団指導申込情報（固定項目）テーブル

                //集団指導事業（フリー項目）入力情報テーブル（申込情報）
                db.tt_kksyudansidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                             , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1).Execute();
                db.tt_kksyudansidofree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kksyudansido_mosikomi.UPDATE.Execute(newdto);         //集団指導申込情報（固定項目）テーブル
                db.tt_kksyudansidofree.UPDATE.Execute(newfreedtl);          //集団指導事業（フリー項目）入力情報テーブル（申込情報）
            }

            //集団指導担当者テーブルを登録
            //①予定者リストを削除する
            db.tt_kksyudansido_staff.DELETE.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1).Execute();
            //②予定者リストを登録する
            if (req.maininfo.mosikomiinfo.stafflist != null)
            {
                var staffdtl = new List<tt_kksyudansido_staffDto>();
                foreach (var item in req.maininfo.mosikomiinfo.stafflist)
                {
                    var staffdto = new tt_kksyudansido_staffDto();
                    staffdto = Converter.GetDto(staffdto, item, req, req.maininfo.edano, 申込結果区分._1);
                    staffdtl.Add(staffdto);
                }

                db.tt_kksyudansido_staff.INSERT.Execute(staffdtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑥保存処理(個別入力画面)--結果タブ
        /// </summary>
        private CommonResponse Save_K(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetKBN(db, req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2);

            //新規の場合
            if (kbn == EnumActionType.Insert && req.maininfo.edano == 0) { req.maininfo.edano = GetNewEdano(db, req.maininfo.gyomukbn); }      //最新枝番を取得

            var olddto = new tt_kksyudansido_kekkaDto();                //集団指導結果情報（固定項目）テーブル
            //結果フリー項目一覧
            var oldfreedtl = new List<tt_kksyudansidofreeDto>();        //集団指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //結果情報を取得
                olddto = db.tt_kksyudansido_kekka.GetDtoByKey(req.maininfo.gyomukbn, req.maininfo.edano);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    //E004006：'{0}は{1}に存在しません。'
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "結果情報", tt_kksyudansido_kekkaDto.TABLE_NAME);
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
                oldfreedtl = db.tt_kksyudansidofree.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                                          $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                                          , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_kksyudansido_kekkaDto();                //集団指導結果情報（固定項目）テーブル
            var newfreedtl = new List<tt_kksyudansidofreeDto>();        //集団指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //集団指導結果情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetDto(newdto, req, kbn);

                //結果フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_kksyudansidofreeDto();
                    var row = req.maininfo.kekkainfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));    //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //集団指導結果情報（固定項目）テーブル
                newdto = Converter.GetDto(newdto, req, kbn);

                //結果フリー項目一覧
                foreach (var dt in req.maininfo.kekkainfo.freeiteminfo)
                {
                    var newfreedto = new tt_kksyudansidofreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));     //汎用区分1
                    newfreedto = Converter.GetDto(newfreedto, req, dt, hanyokbn1, req.maininfo.edano, 申込結果区分._2);
                    newfreedtl.Add(newfreedto);
                }
            }

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            if (kbn == EnumActionType.Insert)
            {
                //新規の場合
                db.tt_kksyudansido_kekka.INSERT.Execute(newdto);            //集団指導結果情報（固定項目）テーブル

                //集団指導事業（フリー項目）入力情報テーブル（結果情報）
                db.tt_kksyudansidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                             , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2).Execute();
                db.tt_kksyudansidofree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kksyudansido_kekka.UPDATE.Execute(newdto);            //集団指導結果情報（固定項目）テーブル
                db.tt_kksyudansidofree.UPDATE.Execute(newfreedtl);          //集団指導事業（フリー項目）入力情報テーブル（結果情報）
            }

            //集団指導担当者テーブルを登録
            //①実施者リストを削除する
            db.tt_kksyudansido_staff.DELETE.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2).Execute();
            //②実施者リストを登録する
            if (req.maininfo.kekkainfo.stafflist != null)
            {
                var staffdtl = new List<tt_kksyudansido_staffDto>();
                foreach (var item in req.maininfo.kekkainfo.stafflist)
                {
                    var staffdto = new tt_kksyudansido_staffDto();
                    staffdto = Converter.GetDto(staffdto, item, req, req.maininfo.edano, 申込結果区分._2);
                    staffdtl.Add(staffdto);
                }
                db.tt_kksyudansido_staff.INSERT.Execute(staffdtl);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(個別入力画面)--参加者タブ
        /// </summary>
        private CommonResponse Save_S(DaDbContext db, SaveRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var newdtl = new List<tt_kksyudansido_sankasyaDto>();           //集団指導参加者テーブル

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------

            //集団指導参加者一覧
            foreach (var dt in req.maininfo.sankasyainfo.sankasyalist)
            {
                var newdto = Converter.GetDto(dt, req);
                newdtl.Add(newdto);
            }

            //-------------------------------------------------------------
            //３.DB削除処理
            //-------------------------------------------------------------
            var dellist = new List<string>();
            //A、集団指導参加者テーブル削除処理
            db.tt_kksyudansido_sankasya.DELETE.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano).Execute();

            //B、集団指導参加者（フリー項目）入力情報テーブル削除処理
            dellist = GetSankasyafreeDelList(db, req);
            foreach (var atenano in dellist)
            {
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                      , req.maininfo.gyomukbn, req.maininfo.edano, atenano).Execute();
            }

            //C、集団指導参加者申込情報（固定項目）テーブル削除処理
            dellist = GetSankasyamosikomiDelList(db, req);
            foreach (var atenano in dellist)
            {
                db.tt_kksyudansido_sankasyamosikomi.DELETE.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano, atenano).Execute();
            }

            //D、集団指導参加者結果情報（固定項目）テーブル削除処理
            dellist = GetSankasyakekkaDelList(db, req);
            foreach (var atenano in dellist)
            {
                db.tt_kksyudansido_sankasyakekka.DELETE.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano, atenano).Execute();
            }

            //-------------------------------------------------------------
            //４.DB追加処理
            //-------------------------------------------------------------
            db.tt_kksyudansido_sankasya.INSERT.Execute(newdtl);

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑦削除処理(個別入力画面)
        /// </summary>
        private CommonResponse Delete(DaDbContext db, DeleteRequest req, string mosikomikekkakbn)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //1.集団指導申込情報（固定項目）テーブル
                db.tt_kksyudansido_mosikomi.DELETE.WHERE.ByKey(req.gyomukbn, req.edano).Execute();

                //3.集団指導事業（フリー項目）入力情報テーブル
                db.tt_kksyudansidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                             , req.gyomukbn, req.edano, 申込結果区分._1).Execute();

                //4.集団指導担当者テーブル
                db.tt_kksyudansido_staff.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                               $"{nameof(tt_kksyudansido_staffDto.edano)}=@edano and " +
                                                               $"{nameof(tt_kksyudansido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                               , req.gyomukbn, req.edano, 申込結果区分._1).Execute();
            }

            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._2))
            {
                //2.集団指導結果情報（固定項目）テーブル
                db.tt_kksyudansido_kekka.DELETE.WHERE.ByKey(req.gyomukbn, req.edano).Execute();

                //3.集団指導事業（フリー項目）入力情報テーブル
                db.tt_kksyudansidofree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansidofreeDto.gyomukbn)}=@gyomukbn and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.edano)}=@edano and " +
                                                             $"{nameof(tt_kksyudansidofreeDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                             , req.gyomukbn, req.edano, 申込結果区分._2).Execute();

                //4.集団指導担当者テーブル
                db.tt_kksyudansido_staff.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                               $"{nameof(tt_kksyudansido_staffDto.edano)}=@edano and " +
                                                               $"{nameof(tt_kksyudansido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                               , req.gyomukbn, req.edano, 申込結果区分._2).Execute();
            }

            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(SANKASYA_TABKBN))
            {
                //5.集団指導参加者テーブル
                db.tt_kksyudansido_sankasya.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyaDto.gyomukbn)}=@gyomukbn and " +
                                                                  $"{nameof(tt_kksyudansido_sankasyaDto.edano)}=@edano"
                                                                  , req.gyomukbn, req.edano).Execute();

                //6.集団指導参加者申込情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyamosikomi.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyamosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansido_sankasyamosikomiDto.edano)}=@edano"
                                                                          , req.gyomukbn, req.edano).Execute();

                //7.集団指導参加者結果情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyakekka.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyakekkaDto.gyomukbn)}=@gyomukbn and " +
                                                                       $"{nameof(tt_kksyudansido_sankasyakekkaDto.edano)}=@edano"
                                                                       , req.gyomukbn, req.edano).Execute();

                //8.集団指導参加者（フリー項目）入力情報テーブル
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano"
                                                                      , req.gyomukbn, req.edano).Execute();
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑧参加者詳細画面検索処理（参加者情報一覧のリンクをクリック）
        /// ⑨参加者詳細情報検索処理（タブ切り替え）
        /// </summary>
        private SearchSankasyaDetailResponse SearchSankasyaDetail(DaDbContext db, SearchSankasyaDetailRequest req)
        {
            var res = new SearchSankasyaDetailResponse();

            var mosidto = new tt_kksyudansido_sankasyamosikomiDto();        //集団指導参加者申込情報（固定項目）テーブル
            var kekkadto = new tt_kksyudansido_sankasyakekkaDto();          //集団指導参加者結果情報（固定項目）テーブル

            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //A、データ操作区分取得
            var kbn = GetSankasyaKBN(db, req.gyomukbn, req.edano, req.atenano, req.mosikomikekkakbn);

            //B、該当宛名番号の住民情報を取得
            var atenadto = db.tt_afatena.GetDtoByKey(req.atenano);

            //C、該当宛名番号の出欠区分を取得
            var syukketukbn = string.Empty;
            var sankasyadto = db.tt_kksyudansido_sankasya.GetDtoByKey(req.gyomukbn, req.edano, req.atenano);
            if (sankasyadto != null) { syukketukbn = sankasyadto.syukketukbn; }

            //D、業務／枝番／宛名番号毎の参加者申込／結果固定項目を取得する
            if (req.mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //申込タブを選択した場合
                mosidto = db.tt_kksyudansido_sankasyamosikomi.GetDtoByKey(req.gyomukbn, req.edano, req.atenano);
            }
            else
            {
                //結果タブを選択した場合
                kekkadto = db.tt_kksyudansido_sankasyakekka.GetDtoByKey(req.gyomukbn, req.edano, req.atenano);
            }

            //E、業務／枝番／宛名番号毎の参加者フリー項目を取得する
            var freeMstDtl = db.tm_kksidofreeitem.SELECT.WHERE.ByKey(指導区分._3, req.gyomukbn, req.mosikomikekkakbn, フリー項目用途区分._2).GetDtoList();
           
            //TODO_CNC_20240502_DB定義生成_UP217
            //freeMstDtl = freeMstDtl.Where(e => e.hyojiflg == true)          //表示フラグがtrueの項目のみ表示
            //                       .OrderBy(e => e.orderseq).ToList();      //表示順ソート：並び順

            //集団指導参加者（フリー項目）入力情報テーブル
            var keyList = new List<object[]>();
            foreach (var item in freeMstDtl)
            {
                keyList.Add(new object[] { item.gyomukbn, req.edano, EnumToStr(item.mosikomikekkakbn), item.itemcd, req.atenano });
            }
            //全項目データ
            var dataDtl = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //F、警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //G、画面項目設定
            //参加者詳細画面ヘッダー情報
            res.headerinfo = Wraper.GetHeaderVM(db, atenadto, syukketukbn, alertviewflg);

            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //固定情報設定
            if (req.mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(mosidto?.regsisyo) || sisyoList.Contains(CStr(mosidto?.regsisyo));

                //申込タブを選択した場合
                res.fixinfo = Wraper.GetMosikomiBaseVM(db, mosidto!, req.regsisyo!, kbn);            //申込固定情報
            }
            else
            {
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(kekkadto?.regsisyo) || sisyoList.Contains(CStr(kekkadto?.regsisyo));

                //結果タブを選択した場合
                res.fixinfo = Wraper.GetKekkaBaseVM(db, kekkadto!, req.regsisyo!, kbn);              //結果固定情報
            }

            res.grouplist1 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.参加者用);
            res.grouplist2 = AWKK00301G.Service.GetHokensidoGroupList(db, Enumフリー項目グループNo.グループ2, EnumToStr(Enum指導区分.集団指導), req.gyomukbn, req.mosikomikekkakbn, Enum項目用途区分.参加者用);

            //集約コードパターン
            var patternno = CmLogicUtil.GetPatternno(AWKK00303G, req.gyomukbn);

            res.freeitemlist = Wraper.GetFreeItemVMList(db, freeMstDtl, dataDtl, AWKK00303G, patternno);   //参加者フリー項目一覧

            //事業コードを取得
            res.fixinfo.jigyo = GetJigyo(db, req);

            //申込情報入力設定
            if (kbn == EnumActionType.Update)
            {
                res.fixinfo.inputflg = true;
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑩参加者保存処理(参加者詳細画面)
        /// </summary>
        private CommonResponse SaveSankasya(DaDbContext db, SaveSankasyaRequest req, string jigyocd, string kinoid)
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

            //参加者申込タブの場合
            if (req.maininfo.mosikomiinfo != null)
            {
                if (req.maininfo.mosikomiinfo.inputflg)
                {
                    //申込情報入力フラグがチェックする場合、登録処理を行う
                    res = SaveSankasya_M(db, req);
                    if (!res.returncode.Equals(EnumServiceResult.OK)) { return res; }
                }
                else
                {
                    //申込情報入力フラグがチェックしない場合、申込情報の削除処理を行う
                    var delreq = GetSankasyaDelReq(req);
                    var delres = DeleteSankasya(db, delreq, 申込結果区分._1);
                    if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //参加者結果タブの場合
            if (req.maininfo.kekkainfo != null)
            {
                if (req.maininfo.kekkainfo.inputflg)
                {
                    //結果情報入力フラグがチェックする場合、登録処理を行う
                    res = SaveSankasya_K(db, req);
                }
                else
                {
                    //結果情報入力フラグがチェックしない場合、結果情報の削除処理を行う
                    var delreq = GetSankasyaDelReq(req);
                    var delres = DeleteSankasya(db, delreq, 申込結果区分._2);
                    if (!delres.returncode.Equals(EnumServiceResult.OK)) { return delres; }
                }
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑩参加者保存処理(参加者詳細画面)--申込タブ
        /// </summary>
        private CommonResponse SaveSankasya_M(DaDbContext db, SaveSankasyaRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetSankasyaKBN(db, req.maininfo.gyomukbn, req.maininfo.edano, req.maininfo.atenano!, 申込結果区分._1);

            var olddto = new tt_kksyudansido_sankasyamosikomiDto();          //集団指導参加者申込情報（固定項目）テーブル
            var oldfreedtl = new List<tt_kksyudansido_sankasyafreeDto>();    //集団指導参加者（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //参加者申込情報を取得
                olddto = db.tt_kksyudansido_sankasyamosikomi.GetDtoByKey(req.maininfo.gyomukbn, req.maininfo.edano, req.maininfo.atenano!);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "申込情報", tt_kksyudansido_sankasyamosikomiDto.TABLE_NAME);
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
                //参加者申込フリー項目一覧情報を取得
                oldfreedtl = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                                   , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1, req.maininfo.atenano!).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_kksyudansido_sankasyamosikomiDto();          //集団指導参加者申込情報（固定項目）テーブル
            var newfreedtl = new List<tt_kksyudansido_sankasyafreeDto>();    //集団指導参加者（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //集団指導参加者申込情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetSankasyaDto(newdto, req, kbn);

                //参加者申込フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_kksyudansido_sankasyafreeDto();
                    var row = req.maininfo.mosikomiinfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));    //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //集団指導参加者申込情報（固定項目）テーブル
                newdto = Converter.GetSankasyaDto(newdto, req, kbn);

                //参加者申込フリー項目一覧
                foreach (var dt in req.maininfo.mosikomiinfo.freeiteminfo)
                {
                    var newfreedto = new tt_kksyudansido_sankasyafreeDto();
                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));     //汎用区分1
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
                db.tt_kksyudansido_sankasyamosikomi.INSERT.Execute(newdto);      //集団指導参加者申込情報（固定項目）テーブル

                //集団指導参加者（フリー項目）入力情報テーブル
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                      , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._1, req.maininfo.atenano!).Execute();
                db.tt_kksyudansido_sankasyafree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kksyudansido_sankasyamosikomi.UPDATE.Execute(newdto);     //集団指導参加者申込情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyafree.UPDATE.Execute(newfreedtl);     //集団指導参加者（フリー項目）入力情報テーブル
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑩参加者保存処理(参加者詳細画面)---結果タブ
        /// </summary>
        private CommonResponse SaveSankasya_K(DaDbContext db, SaveSankasyaRequest req)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.チェック処理
            //-------------------------------------------------------------
            //データ操作区分取得
            var kbn = GetSankasyaKBN(db, req.maininfo.gyomukbn, req.maininfo.edano, req.maininfo.atenano!, 申込結果区分._2);

            var olddto = new tt_kksyudansido_sankasyakekkaDto();                //集団指導参加者結果情報（固定項目）テーブル
            var oldfreedtl = new List<tt_kksyudansido_sankasyafreeDto>();       //集団指導参加者（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //参加者結果情報を取得
                olddto = db.tt_kksyudansido_sankasyakekka.GetDtoByKey(req.maininfo.gyomukbn, req.maininfo.edano, req.maininfo.atenano!);
                //存在チェック=>排他とする
                if (olddto == null)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E004006, "結果情報", tt_kksyudansido_sankasyakekkaDto.TABLE_NAME);
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
                //参加者結果フリー項目一覧情報を取得
                oldfreedtl = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                                   $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                                   , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2, req.maininfo.atenano!).GetDtoList();
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            var newdto = new tt_kksyudansido_sankasyakekkaDto();                //集団指導参加者結果情報（固定項目）テーブル
            var newfreedtl = new List<tt_kksyudansido_sankasyafreeDto>();       //集団指導事業（フリー項目）入力情報テーブル

            //更新の場合
            if (kbn == EnumActionType.Update)
            {
                //集団指導参加者結果情報（固定項目）テーブル
                newdto = olddto!;
                newdto = Converter.GetSankasyaDto(newdto, req, kbn);

                //参加者結果フリー項目一覧
                foreach (var dt in oldfreedtl)
                {
                    var newfreedto = new tt_kksyudansido_sankasyafreeDto();
                    var row = req.maininfo.kekkainfo.freeiteminfo.Find(x => GetCd(x.item) == dt.itemcd);
                    if (row == null) { continue; }

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(row.inputtype));    //汎用区分1
                    newfreedto = Converter.GetDto(dt, row, hanyokbn1);
                    newfreedtl.Add(newfreedto);
                }
            }
            else
            //新規の場合
            {
                //集団指導参加者結果情報（固定項目）テーブル
                newdto = Converter.GetSankasyaDto(newdto, req, kbn);

                //結果フリー項目一覧
                foreach (var dt in req.maininfo.kekkainfo.freeiteminfo)
                {
                    var newfreedto = new tt_kksyudansido_sankasyafreeDto();

                    var hanyokbn1 = GetKbn1(db, EnumNmKbn.フリー項目データタイプ, CStr(dt.inputtype));     //汎用区分1
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
                db.tt_kksyudansido_sankasyakekka.INSERT.Execute(newdto);        //集団指導参加者結果情報（固定項目）テーブル

                //集団指導参加者（フリー項目）入力情報テーブル
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                      , req.maininfo.gyomukbn, req.maininfo.edano, 申込結果区分._2, req.maininfo.atenano!).Execute();
                db.tt_kksyudansido_sankasyafree.INSERT.Execute(newfreedtl);
            }
            else if (kbn == EnumActionType.Update)
            {
                //更新の場合
                db.tt_kksyudansido_sankasyakekka.UPDATE.Execute(newdto);        //集団指導参加者結果情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyafree.UPDATE.Execute(newfreedtl);     //集団指導参加者（フリー項目）入力情報テーブル
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// ⑪参加者削除処理(参加者詳細画面)
        /// </summary>
        private CommonResponse DeleteSankasya(DaDbContext db, DeleteSankasyaRequest req, string mosikomikekkakbn)
        {
            var res = new CommonResponse();

            //-------------------------------------------------------------
            //１.削除チェック処理
            //-------------------------------------------------------------
            //存在チェック
            if (!CheckSankasya(db, req, res, mosikomikekkakbn)) { return res; }   //異常返し

            //-------------------------------------------------------------
            //２.DB削除処理
            //-------------------------------------------------------------
            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._1))
            {
                //1.集団指導参加者申込情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyamosikomi.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyamosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansido_sankasyamosikomiDto.edano)}=@edano and " +
                                                                          $"{nameof(tt_kksyudansido_sankasyamosikomiDto.atenano)}=@atenano"
                                                                          , req.gyomukbn, req.edano, req.atenano).Execute();

                //3.集団指導参加者（フリー項目）入力情報テーブル
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                      , req.gyomukbn, req.edano, 申込結果区分._1, req.atenano).Execute();
            }

            if (string.IsNullOrEmpty(mosikomikekkakbn) || mosikomikekkakbn.Equals(申込結果区分._2))
            {
                //2.集団指導参加者結果情報（固定項目）テーブル
                db.tt_kksyudansido_sankasyakekka.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyakekkaDto.gyomukbn)}=@gyomukbn and " +
                                                                       $"{nameof(tt_kksyudansido_sankasyakekkaDto.edano)}=@edano and " +
                                                                       $"{nameof(tt_kksyudansido_sankasyakekkaDto.atenano)}=@atenano"
                                                                       , req.gyomukbn, req.edano, req.atenano).Execute();

                //3.集団指導参加者（フリー項目）入力情報テーブル
                db.tt_kksyudansido_sankasyafree.DELETE.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyafreeDto.gyomukbn)}=@gyomukbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.edano)}=@edano and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.mosikomikekkakbn)}=@mosikomikekkakbn and " +
                                                                      $"{nameof(tt_kksyudansido_sankasyafreeDto.atenano)}=@atenano"
                                                                      , req.gyomukbn, req.edano, 申込結果区分._2, req.atenano).Execute();
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
        private static bool Check(DaDbContext db, DeleteRequest req, CommonResponse res, string mosikomikekkakbn)
        {
            if (string.IsNullOrEmpty(mosikomikekkakbn)) { return true; }

            var err1 = false; var err2 = false;

            //集団指導申込情報（固定項目）テーブル
            if (!db.tt_kksyudansido_mosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_mosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                   $"{nameof(tt_kksyudansido_mosikomiDto.edano)}=@edano"
                                                                   , req.gyomukbn, req.edano).Exists()) { err1 = true; }
            //集団指導結果情報（固定項目）テーブル
            if (!db.tt_kksyudansido_kekka.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_kekkaDto.gyomukbn)}=@gyomukbn and " +
                                                                $"{nameof(tt_kksyudansido_kekkaDto.edano)}=@edano"
                                                                , req.gyomukbn, req.edano).Exists()) { err2 = true; }
            if (err1 && err2)
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E014008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登録チェック（個別入力画面）
        /// </summary>
        private static bool Check(DaDbContext db, SaveRequest req, CommonResponse res)
        {
            if ((req.maininfo.mosikomiinfo != null && req.maininfo.mosikomiinfo.inputflg) && (req.maininfo.kekkainfo != null && req.maininfo.kekkainfo.inputflg))
            {
                //申込／結果情報両方存在している場合、登録チェックを行う
                if (!req.maininfo.mosikomiinfo.jigyo.Equals(req.maininfo.kekkainfo.jigyo))
                {
                    //E014009：申込／結果／参加者情報の事業コードが一致していません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E014009);
                    res.SetServiceError(msg);
                    return false;
                }
            }

            if ((req.maininfo.mosikomiinfo != null && req.maininfo.mosikomiinfo.inputflg) && (req.maininfo.sankasyainfo != null && req.maininfo.sankasyainfo.inputflg))
            {
                //申込／結果情報両方存在している場合、登録チェックを行う
                if (!req.maininfo.mosikomiinfo.jigyo.Equals(req.maininfo.sankasyainfo.jigyo))
                {
                    //E014009：申込／結果／参加者情報の事業コードが一致していません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E014009);
                    res.SetServiceError(msg);
                    return false;
                }
            }

            if ((req.maininfo.kekkainfo != null && req.maininfo.kekkainfo.inputflg) && (req.maininfo.sankasyainfo != null && req.maininfo.sankasyainfo.inputflg))
            {
                //申込／結果情報両方存在している場合、登録チェックを行う
                if (!req.maininfo.kekkainfo.jigyo.Equals(req.maininfo.sankasyainfo.jigyo))
                {
                    //E014009：申込／結果／参加者情報の事業コードが一致していません。
                    var msg = DaMessageService.GetMsg(EnumMessage.E014009);
                    res.SetServiceError(msg);
                    return false;
                }
            }

            if ((req.maininfo.mosikomiinfo == null && req.maininfo.kekkainfo == null) ||
                ((req.maininfo.mosikomiinfo != null && !req.maininfo.mosikomiinfo.inputflg) &&
                 (req.maininfo.kekkainfo != null && !req.maininfo.kekkainfo.inputflg)))
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E014008);
                res.SetServiceError(msg);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 登録チェック（個別詳細画面）
        /// </summary>
        private static bool Check(DaDbContext db, SaveSankasyaRequest req, CommonResponse res)
        {
            if (req.maininfo.edano == 0 || (req.maininfo.mosikomiinfo == null && req.maininfo.kekkainfo == null))
            {
                //E014008：参加者情報のみ登録できません。申込、あるいは結果情報を先に登録してください。
                var msg = DaMessageService.GetMsg(EnumMessage.E014008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 存在チェック(参加者削除)
        /// </summary>
        private static bool CheckSankasya(DaDbContext db, DeleteSankasyaRequest req, CommonResponse res, string mosikomikekkakbn)
        {
            if (string.IsNullOrEmpty(mosikomikekkakbn)) { return true; }

            var err1 = false; var err2 = false;

            //集団指導参加者申込情報（固定項目）テーブル
            if (!db.tt_kksyudansido_sankasyamosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyamosikomiDto.gyomukbn)}=@gyomukbn and " +
                                                                           $"{nameof(tt_kksyudansido_sankasyamosikomiDto.edano)}=@edano and " +
                                                                           $"{nameof(tt_kksyudansido_sankasyamosikomiDto.atenano)}=@atenano"
                                                                           , req.gyomukbn, req.edano, req.atenano).Exists()) { err1 = true; }
            //集団指導参加者結果情報（固定項目）テーブル
            if (!db.tt_kksyudansido_sankasyakekka.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_sankasyakekkaDto.gyomukbn)}=@gyomukbn and " +
                                                                        $"{nameof(tt_kksyudansido_sankasyakekkaDto.edano)}=@edano and " +
                                                                        $"{nameof(tt_kksyudansido_sankasyakekkaDto.atenano)}=@atenano"
                                                                        , req.gyomukbn, req.edano, req.atenano).Exists()) { err2 = true; }
            if (err1 && err2)
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E014008);
                res.SetServiceError(msg);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 参加者情報一覧を取得SQL
        /// </summary>
        private static string GetAtenaSql(SearchSankasyaListRequest req)
        {
            var sql = string.Empty;

            sql = $"";
            sql = $"{sql}{SPACE}SELECT{C_LF}";
            sql = $"{sql}{SPACE}S.syukketukbn{C_LF}";
            sql = $"{sql}{SPACE},S.atenano{C_LF}";
            sql = $"{sql}{SPACE},A.simei_yusen{C_LF}";
            sql = $"{sql}{SPACE},A.simei_kana_yusen{C_LF}";
            sql = $"{sql}{SPACE},A.sex{C_LF}";
            sql = $"{sql}{SPACE},A.bymd{C_LF}";
            sql = $"{sql}{SPACE},A.bymd_fusyoflg{C_LF}";
            sql = $"{sql}{SPACE},A.bymd_fusyohyoki{C_LF}";
            sql = $"{sql}{SPACE},A.juminkbn{C_LF}";
            sql = $"{sql}{SPACE},A.siensotikbn{C_LF}";
            sql = $"{sql}{SPACE}FROM{SPACE}tt_kksyudansido_sankasya{SPACE}S{C_LF}";
            sql = $"{sql}{SPACE}LEFT{SPACE}JOIN{SPACE}tt_afatena{SPACE}A{C_LF}";
            sql = $"{sql}{SPACE}ON{SPACE}A.atenano=S.atenano{C_LF}";
            sql = $"{sql}{SPACE}WHERE{C_LF}";
            sql = $"{sql}{SPACE}S.gyomukbn='{req.gyomukbn}'{C_LF}";
            sql = $"{sql}{SPACE}AND{SPACE}S.edano={req.edano}{C_LF}";
            sql = $"{sql}{SPACE}ORDER BY{C_LF}";
            sql = $"{sql}{SPACE}CASE WHEN {req.orderby}{SPACE}={SPACE}0{SPACE}THEN{SPACE}S.atenano END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}1{SPACE}THEN{SPACE}S.syukketukbn END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-1{SPACE}THEN{SPACE}S.syukketukbn END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}2{SPACE}THEN{SPACE}S.atenano END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-2{SPACE}THEN{SPACE}S.atenano END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}3{SPACE}THEN{SPACE}A.simei_yusen  END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-3{SPACE}THEN{SPACE}A.simei_yusen END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}4{SPACE}THEN{SPACE}A.simei_kana_yusen END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-4{SPACE}THEN{SPACE}A.simei_kana_yusen END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}5{SPACE}THEN{SPACE}A.sex END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-5{SPACE}THEN{SPACE}A.sex END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}6{SPACE}THEN{SPACE}A.bymd END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-6{SPACE}THEN{SPACE}A.bymd END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}7{SPACE}THEN{SPACE}A.juminkbn END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-7{SPACE}THEN{SPACE}A.juminkbn END DESC{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}8{SPACE}THEN{SPACE}A.siensotikbn END{C_LF}";
            sql = $"{sql}{SPACE},CASE WHEN {req.orderby}{SPACE}={SPACE}-8{SPACE}THEN{SPACE}A.siensotikbn END DESC{C_LF}";

            return sql;
        }

        /// <summary>
        /// 会場名取得
        /// </summary>
        private static string GetKaijyoNm(DaDbContext db, string kaijocd)
        {
            if (string.IsNullOrEmpty(kaijocd)) { return string.Empty; }

            var kaijodto = db.tm_afkaijo.GetDtoByKey(kaijocd);
            if (kaijodto == null) { return string.Empty; }

            return $"{kaijocd}{SPACE}{COLON}{SPACE}{kaijodto.kaijonm}";

        }

        /// <summary>
        /// 名称マスタ、専用マスタから名称を取得
        /// </summary>
        private static string GetNm(DaDbContext db, string maincd, int subcd, string nmCd)
        {
            var dto = db.tm_afmeisyo.GetDtoByKey(maincd, subcd, nmCd);

            if (dto == null) { return string.Empty; }

            return CStr(dto.nm);
        }

        /// <summary>
        ///新規登録する際に、枝番の付与は、該当指導区分＋業務区分の申込・結果の最大枝番を取得う
        /// </summary>
        private static int GetNewEdano(DaDbContext db, string gyomukbn)
        {
            var mmaxedano = db.tt_kksyudansido_mosikomi.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_mosikomiDto.gyomukbn)}=@gyomukbn", gyomukbn).GetDtoList().Select(e => e.edano).Max();
            var kmaxedano = db.tt_kksyudansido_kekka.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_kekkaDto.gyomukbn)}=@gyomukbn", gyomukbn).GetDtoList().Select(e => e.edano).Max();
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
        ///集団指導担当者テーブルから全ての予定者／実施者を取得する、,区切り
        /// </summary>
        private static string GetStaffStr(DaDbContext db, string gyomukbn, int edano, string kbn)
        {
            var staffdto = db.tt_kksyudansido_staff.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansido_staffDto.edano)}=@edano and " +
                                                                          $"{nameof(tt_kksyudansido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn)"
                                                                          , gyomukbn, edano, kbn).GetDtoList();
            var staffStr = string.Empty;
            foreach (var staff in staffdto)
            {
                if (!string.IsNullOrEmpty(staffStr)) { staffStr = $"{staffStr}{COMMA}"; }
                staffStr = $"{staffStr}{CStr(staff)}";
            }

            return staffStr;
        }

        /// <summary>
        ///集団指導担当者テーブルから全ての予定者／実施者を取得
        /// </summary>
        private static List<StaffListVM> GetStaffList(DaDbContext db, string gyomukbn, int edano, string mosikomikekkakbn)
        {
            List<StaffListVM> list = new List<StaffListVM>();
            var staffdto = db.tt_kksyudansido_staff.SELECT.WHERE.ByFilter($"{nameof(tt_kksyudansido_staffDto.gyomukbn)}=@gyomukbn and " +
                                                                          $"{nameof(tt_kksyudansido_staffDto.edano)}=@edano and " +
                                                                          $"{nameof(tt_kksyudansido_staffDto.mosikomikekkakbn)}=@mosikomikekkakbn"
                                                                          , gyomukbn, edano, mosikomikekkakbn).GetDtoList().OrderBy(e => e.staffid);
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
        /// 個別入力画面のデータ操作区分取得
        /// </summary>
        private static EnumActionType? GetKBN(DaDbContext db, string gyomukbn, int edano, string mosikomikbn)
        {
            if (edano == 0) { return EnumActionType.Insert; }

            EnumActionType? kbn = null;

            if (mosikomikbn.Equals(申込結果区分._1))
            {
                if (db.tt_kksyudansido_mosikomi.SELECT.WHERE.ByKey(gyomukbn, edano).Exists())
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
                if (db.tt_kksyudansido_kekka.SELECT.WHERE.ByKey(gyomukbn, edano).Exists())
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
        /// 参加者詳細画面のデータ操作区分取得
        /// </summary>
        private static EnumActionType? GetSankasyaKBN(DaDbContext db, string gyomukbn, int? edano, string? atenano, string mosikomikbn)
        {
            EnumActionType? kbn = null;

            if (mosikomikbn.Equals(申込結果区分._1))
            {
                if (db.tt_kksyudansido_sankasyamosikomi.SELECT.WHERE.ByKey(gyomukbn, edano!, atenano!).Exists())
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
                if (db.tt_kksyudansido_sankasyakekka.SELECT.WHERE.ByKey(gyomukbn, edano!, atenano!).Exists())
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
        private static DeleteRequest GetDelReq(SaveRequest req)
        {
            var delreq = new DeleteRequest()
            {
                gyomukbn = req.maininfo.gyomukbn,           //業務区分
                edano = req.maininfo.edano,                 //枝番
            };

            return delreq;
        }

        /// <summary>
        ///保存処理のリクエスト内容から削除処理のリクエストを設定
        /// </summary>
        private static DeleteSankasyaRequest GetSankasyaDelReq(SaveSankasyaRequest req)
        {
            var delreq = new DeleteSankasyaRequest()
            {
                gyomukbn = req.maininfo.gyomukbn,           //業務区分
                edano = req.maininfo.edano,                 //枝番
                atenano = CStr(req.maininfo.atenano),       //宛名番号
            };

            return delreq;
        }

        /// <summary>
        ///その他日程事業・保健指導事業マスタから事業リストを取得
        /// </summary>
        private static List<DaSelectorModel> GetJigyoList(DaDbContext db, string hokensidokbn, string gyomukbn, bool stopflg)
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
            else if (hokensidokbn.Equals(指導区分._3))
            {
                sql = $"{sql}{SPACE}AND syudanriyoflg=true";        //集団指導の場合
            }
            if (!string.IsNullOrEmpty(gyomukbn))
            {
                sql = $"{sql}{SPACE}AND gyomukbn = '{gyomukbn}'"; 　//業務区分ありの場合
            }
            if (stopflg)
            {
                sql = $"{sql}{SPACE}AND stopflg=true";              //個人詳細画面の場合
            }

            DataTable jigyodto = (result.Data = AiDbUtil.GetDataTable(db.Session, sql));

            var list = Wraper.GetJigyoVMList(db, jigyodto);         //事業リスト

            return list;
        }

        /// <summary>
        /// 集団指導フリー項目グループを取得（初期化時）
        /// </summary>
        public static List<DaSelectorModel> GetSyudansidoGroupList(DaDbContext db, Enumフリー項目グループNo group, Enum項目用途区分 itemyotokbn)
        {
            var dtlGrp = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.保健指導_集団指導項目グループ);
            var listGrp = new List<DaSelectorModel>();
            foreach (var dtoHanyo in dtlGrp)
            {
                var hanyokbn2Arr = dtoHanyo.hanyokbn2!.ToArray();
                if (hanyokbn2Arr.Length == GRPKBN2LEN)
                {
                    //項目のグループ値を取得
                    if (dtoHanyo.hanyokbn1 == EnumToStr(group)
                            && (CStr(hanyokbn2Arr[0]) == EnumToStr(Enum指導区分.集団指導))
                            && CStr(hanyokbn2Arr[4]) == EnumToStr(itemyotokbn))
                    {
                        listGrp.Add(new DaSelectorModel(dtoHanyo.hanyocd, CStr(dtoHanyo.nm)));
                    }
                }
            }
            listGrp = listGrp.OrderBy(e => e.value).ToList();

            return listGrp;
        }

        /// <summary>
        /// 集団指導参加者テーブルから該当参加者の事業コード : 名称を取得
        /// </summary>
        public static string GetJigyo(DaDbContext db, SearchSankasyaDetailRequest req)
        {
            var dto = db.tt_kksyudansido_sankasya.GetDtoByKey(req.gyomukbn, req.edano, req.atenano);
            if (dto == null) { return string.Empty; }
            return GetJigyoCdNm(db, dto.jigyocd);
        }

        /// <summary>
        /// 集団指導参加者（フリー項目）入力情報テーブルから削除すべき宛名番号リストを取得する
        /// </summary>
        public static List<string> GetSankasyafreeDelList(DaDbContext db, SaveRequest req)
        {
            var dellist = new List<string>();
            var dtl = db.tt_kksyudansido_sankasyafree.SELECT.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano).GetDtoList().DistinctBy(e => e.atenano);
            foreach (var dto in dtl)
            {
                var result = req.maininfo.sankasyainfo.sankasyalist.Find(e => e.atenano == dto.atenano);
                if (result == null) { dellist.Add(dto.atenano); }
            }
            return dellist;
        }

        /// <summary>
        /// 集団指導参加者申込情報（固定項目）テーブルから削除すべき宛名番号リストを取得する
        /// </summary>
        public static List<string> GetSankasyamosikomiDelList(DaDbContext db, SaveRequest req)
        {
            var dellist = new List<string>();
            var dtl = db.tt_kksyudansido_sankasyamosikomi.SELECT.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano).GetDtoList();
            foreach (var dto in dtl)
            {
                var result = req.maininfo.sankasyainfo.sankasyalist.Find(e => e.atenano == dto.atenano);
                if (result == null) { dellist.Add(dto.atenano); }
            }
            return dellist;
        }

        /// <summary>
        /// 集団指導参加者（フリー項目）入力情報テーブルから削除すべき宛名番号リストを取得する
        /// </summary>
        public static List<string> GetSankasyakekkaDelList(DaDbContext db, SaveRequest req)
        {
            var dellist = new List<string>();
            var dtl = db.tt_kksyudansido_sankasyakekka.SELECT.WHERE.ByKey(req.maininfo.gyomukbn, req.maininfo.edano).GetDtoList();
            foreach (var dto in dtl)
            {
                var result = req.maininfo.sankasyainfo.sankasyalist.Find(e => e.atenano == dto.atenano);
                if (result == null) { dellist.Add(dto.atenano); }
            }
            return dellist;
        }
    }
}