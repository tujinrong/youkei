// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業予約希望者管理
// 　　　　　　サービス処理
// 作成日　　: 2024.03.07
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWKK00902G
{
    [DisplayName("事業予約希望者管理")]
    public class Service : CmServiceBase
    {
        private const string PROC_NAME1 = "sp_awkk00902g_01";
        private const string PROC_NAME2 = "sp_awkk00902g_02";

        [DisplayName("初期化処理(日程一覧画面)")]
        public InitNitteiListResponse InitNitteiList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = (InitNitteiListResponse)AWKK00901G.Service.GetInitListResponse(db, req.kinoid!, new InitNitteiListResponse(), true);
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業予定コーステーブル
                var dtl = db.tt_kkjigyoyoteicourse.SELECT.GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //コース一覧
                res.selectorlist6 = dtl.Select(e => new DaSelectorModel(CStr(e.courseno), e.coursenm)).ToList();

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(日程一覧画面)")]
        public SearchNitteiListResponse SearchNitteiList(SearchNitteiListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchNitteiListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize);

                //会場一覧
                var selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日程情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, selectorlist1, selectorlist2);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(コース一覧画面)")]
        public InitCourseListResponse InitCourseList(CourseListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitCourseListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req.courseno);

                //一覧データ取得
                var pageList = DaDbUtil.GetProcedureData(db, PROC_NAME2, parameters);

                //事業予定コーステーブル
                var dto = db.tt_kkjigyoyoteicourse.GetDtoByKey(req.courseno);

                //会場一覧
                var selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //コース情報(ヘッダー)
                res.headerinfo = Wraper.GetHeaderVM(db, dto, pageList.Rows[0]);
                //コース日程情報一覧
                res.kekkalist = Wraper.GetVMList(pageList.Rows, selectorlist1, selectorlist2);
                //日程番号一覧
                var keyList = res.kekkalist.Where(e => CInt(e.kaisu) != 1).Select(e => e.nitteino).ToList();
                //編集フラグ(コピーボタン)
                res.editflg = GetCopyFlg(db, keyList);

                //正常返し
                return res;
            });
        }

        [DisplayName("コピー処理")]
        public DaResponseBase Copy(CourseListRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //事業予定テーブル
                var dtl1 = db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), req.courseno).GetDtoList();
                //日程番号
                var nitteino = dtl1.Find(e => CInt(e.kaisu) == 1)!.nitteino;
                //事業予約希望者テーブル
                var dtl2 = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(nitteino).GetDtoList();
                //存在フラグ
                var flg1 = dtl2.Count > 0;
                //予約データ存在しない場合
                if (!flg1)
                {
                    res.SetServiceError(EnumMessage.DATA_NOTEXIST_ERROR, "予約希望者", "コピー");
                    //異常返し
                    return res;
                }

                //日程番号一覧
                var keyList = dtl1.Where(e => CInt(e.kaisu) != 1).Select(e => e.nitteino).ToList();
                //コピー可能フラグ
                var flg2 = GetCopyFlg(db, keyList);
                //予約データ存在する場合
                if (!flg2)
                {
                    res.SetServiceError(EnumMessage.E014004, "予約希望者", "コピー");
                    //異常返し
                    return res;
                }

                //1回目より2回目以降が定員数が少ない、且つ1回目の予約が満員の場合
                var teiin1 = dtl1.Find(e => CInt(e.kaisu) == 1)?.teiin;
                var lessThanFirst = false;
                foreach (int key in keyList) {
                    var dto = db.tt_kkjigyoyotei.SELECT.WHERE.ByKey(key).GetDto();
                    if (dto != null && dto.teiin < teiin1) {
                        lessThanFirst = true;
                        break;
                    }
                }
                if (lessThanFirst && dtl2.Count == teiin1) {
                    res.SetServiceError(EnumMessage.E014004, "定員オーバー", "コピー");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                var dtl3 = Converter.GetDtl(keyList, dtl2);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                db.tt_kkjigyoyoyakukibosya.INSERT.Execute(dtl3);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(予約者一覧画面)")]
        public InitPersonListResponse InitPersonList(InitPersonListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitPersonListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業予定テーブル
                var dto1 = db.tt_kkjigyoyotei.GetDtoByKey(req.nitteino);
                //事業予定担当者テーブル：担当者一覧
                var staffids = db.tt_kkjigyoyotei_staff.SELECT.WHERE.ByKey(req.nitteino).GetDtoList().Select(e => e.staffid).OrderBy(e => e).ToList();
                //その他日程事業・保健指導事業マスタ
                var dto2 = db.tm_kksonotasidojigyo.GetDtoByKey(dto1.jigyocd);
                //事業予定コーステーブル
                tt_kkjigyoyoteicourseDto? dto3 = null;
                if (dto1.courseno != null)
                {
                    dto3 = db.tt_kkjigyoyoteicourse.GetDtoByKey(dto1.courseno!.Value);
                }

                //会場一覧
                var selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);
                //担当者一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //事業予約希望者テーブル
                var dtl1 = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(req.nitteino).GetDtoList().OrderBy(e => e.atenano).ToList();
                //宛名番号一覧
                var keyList = dtl1.Select(e => e.atenano).ToList();
                //宛名テーブル
                var dtl2 = db.tt_afatena.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日程基本情報(ヘッダー)
                res.headerinfo = Wraper.GetHeaderVM(db, dto1, dto2, dto3, staffids, selectorlist1, selectorlist2, selectorlist3);
                //日程基本情報(明細)
                res.detailinfo = Wraper.GetVM(dto1, dtl1);
                //結果一覧
                res.kekkalist = Wraper.GetVMList(db, dtl1, dtl2, alertviewflg);

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理(予約者一覧画面)")]
        public DaResponseBase DeletePersonList(DeletePersonListRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var keyList = new List<object[]>();
                foreach (var item in req.locklist)
                {
                    keyList.Add(new object[] { item.nitteino, item.atenano });
                }
                //事業予約希望者テーブル
                var dtl = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(dtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                db.tt_kkjigyoyoyakukibosya.DELETE.WHERE.ByKeyList(keyList).Execute();

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業予定テーブル
                var dto1 = db.tt_kkjigyoyotei.GetDtoByKey(req.nitteino);
                //事業予定担当者テーブル：担当者一覧
                var staffids = db.tt_kkjigyoyotei_staff.SELECT.WHERE.ByKey(req.nitteino).GetDtoList().Select(e => e.staffid).OrderBy(e => e).ToList();
                //その他日程事業・保健指導事業マスタ
                var dto2 = db.tm_kksonotasidojigyo.GetDtoByKey(dto1.jigyocd);
                //事業予定コーステーブル
                tt_kkjigyoyoteicourseDto? dto3 = null;
                if (dto1.courseno != null)
                {
                    dto3 = db.tt_kkjigyoyoteicourse.GetDtoByKey(CInt(dto1.courseno));
                }

                //会場一覧
                var selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);
                //担当者一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //個人基本情報取得
                var dto4 = db.tt_afatena.GetDtoByKey(req.atenano);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //事業予約希望者テーブル
                var dto5 = new tt_kkjigyoyoyakukibosyaDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto5 = db.tt_kkjigyoyoyakukibosya.GetDtoByKey(req.nitteino, req.atenano);
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日程基本情報(ヘッダー)
                res.headerinfo = Wraper.GetHeaderVM(db, dto1, dto2, dto3, staffids, selectorlist1, selectorlist2, selectorlist3);
                //希望者情報
                res.personinfo = Common.Wraper.GetHeaderVM(db, new Common.CommonBarHeaderBase3VM(), dto4, alertviewflg, adrsFlg);
                //予約情報
                res.detailinfo = Wraper.GetVM(dto5);

                if (req.editkbn == Enum編集区分.変更)
                {
                    //更新日時(排他用)
                    res.upddttm = dto5.upddttm;
                }

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("定員チェック処理(詳細画面)")]
        public CheckResponse Check(CheckRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CheckResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                var dto1 = new tt_kkjigyoyoyakukibosyaDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto1 = db.tt_kkjigyoyoyakukibosya.GetDtoByKey(req.nitteino, req.atenano);
                }

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //定員チェック必要ない場合、返す
                if (!(!req.taikiflg && (req.editkbn == Enum編集区分.新規 || (req.editkbn == Enum編集区分.変更 && dto1.cancelmatiflg == Enum待機フラグ.希望する))))
                {
                    //正常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //事業予定テーブル
                var dto2 = db.tt_kkjigyoyotei.GetDtoByKey(req.nitteino);

                //予約済人数
                var ct = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.
                            ByFilter($@"{nameof(tt_kkjigyoyoyakukibosyaDto.nitteino)} = @{nameof(tt_kkjigyoyoyakukibosyaDto.nitteino)} and 
                                        {nameof(tt_kkjigyoyoyakukibosyaDto.cancelmatiflg)} = @{nameof(tt_kkjigyoyoyakukibosyaDto.cancelmatiflg)}",
                                        req.nitteino, EnumToStr(Enum待機フラグ.希望しない)).GetCount();

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //定員オーバーフラグ
                res.overflg = (ct + 1 > dto2.teiin);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理(詳細画面)")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //悲観排他
                db.tt_kkjigyoyoyakukibosya.SELECT.WaitRecord(req.nitteino);

                //事業予約希望者テーブル
                var dto = new tt_kkjigyoyoyakukibosyaDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //事業予約希望者テーブル
                    dto = db.tt_kkjigyoyoyakukibosya.GetDtoByKey(req.nitteino, req.atenano);
                }
                //予約番号
                int yoyakuno = CInt(dto.yoyakuno);
                if (req.editkbn == Enum編集区分.新規)
                {
                    //予約番号(悲観排他で取得)
                    yoyakuno = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(req.nitteino).
                                GetMax<int>(nameof(tt_kkjigyoyoyakukibosyaDto.yoyakuno)) + 1;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                dto = Converter.GetDto(dto, req.detailinfo, req.nitteino, req.atenano, yoyakuno);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //宛名ログ記録用
                var kbn = EnumAtenaActionType.更新;
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //事業予約希望者テーブル：ベースで主キー重複チェック
                    db.tt_kkjigyoyoyakukibosya.INSERT.Execute(dto);
                    kbn = EnumAtenaActionType.追加;
                }
                //変更の場合
                else
                {
                    //事業予約希望者テーブル：排他チェック
                    db.tt_kkjigyoyoyakukibosya.UpdateDto(dto, req.upddttm!.Value);
                }

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, kbn);

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("削除処理(詳細画面)")]
        public DaResponseBase DeleteDetail(DeleteDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.DB更新処理
                //-------------------------------------------------------------
                //事業予約希望者テーブル
                db.tt_kkjigyoyoyakukibosya.DeleteByKey(req.nitteino, req.atenano, req.upddttm);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 編集フラグ(コピーボタン)取得
        /// </summary>
        private static bool GetCopyFlg(DaDbContext db, List<int> keyList)
        {
            var count = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKeyList(keyList).GetDtoList().Count;
            return (keyList.Count > 0) && (count == 0);
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<tt_kkjigyoyoyakukibosyaDto> oldDtl, List<LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                   oldDtl.All(dto => locklist.Exists(e => e.atenano == dto.atenano && e.upddttm == dto.upddttm));
        }
    }
}