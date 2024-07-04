// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予定管理
// 　　　　　　サービス処理
// 作成日　　: 2024.03.01
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00901G
{
    [DisplayName("事業予定管理")]
    public class Service : CmServiceBase
    {
        //検索処理(一覧画面：日程)
        private const string PROC_NAME1 = "sp_awkk00901g_01";
        //検索処理(一覧画面：コース)
        private const string PROC_NAME2 = "sp_awkk00901g_02";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return GetInitListResponse(db, req.kinoid!, new InitListResponse(), true);
            });
        }

        [DisplayName("検索処理(一覧画面：日程)")]
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
                //担当者一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日程情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, selectorlist1, selectorlist2, selectorlist3);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面：コース)")]
        public SearchCourseListResponse SearchCourseList(SearchCourseListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchCourseListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME2, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //コース情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面：日程)")]
        public InitNitteiDetailResponse InitDetailNittei(InitNitteiDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト設定
                var res = (InitNitteiDetailResponse)GetInitListResponse(db, req.kinoid!, new InitNitteiDetailResponse(), false);

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //事業予定テーブル
                tt_kkjigyoyoteiDto? dto = null;
                //担当者(複数)
                var staffids = new List<string>();
                //登録支所名
                var regsisyonm = string.Empty;
                //予約者存在フラグ
                var flg = false;
                if (req.editkbn == Enum編集区分.変更 || (req.editkbn == Enum編集区分.新規 && req.copyflg))
                {
                    //事業予定テーブル
                    dto = db.tt_kkjigyoyotei.GetDtoByKey(req.nitteino!.Value);
                    //事業予定担当者テーブル
                    staffids = db.tt_kkjigyoyotei_staff.SELECT.WHERE.ByKey(req.nitteino!.Value).GetDtoList().Select(e => e.staffid).OrderBy(e => e).ToList();
                    //登録支所名
                    regsisyonm = DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, Enum名称区分.名称, CStr(dto.regsisyo));
                    if (req.editkbn == Enum編集区分.変更)
                    {
                        //事業予約希望者テーブル
                        flg = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(req.nitteino!.Value).Exists();
                    }
                }

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //日程情報(ヘッダー)
                res.headerinfo = Wraper.GetHeaderVM(res.selectorlist2, dto, regsisyonm);
                
                //ドロップダウンリスト(全データ)
                var restemp = (InitNitteiDetailResponse)GetInitListResponse(db, req.kinoid!, new InitNitteiDetailResponse(), true);

                //日程情報(明細)
                if (req.copyflg)
                {
                    res.detailinfo = Wraper.GetVM(new NitteiDetailVM(), dto, staffids, flg, res.selectorlist2, res.selectorlist3, res.selectorlist4, res.selectorlist5);
                }
                else
                {
                    res.detailinfo = Wraper.GetVM(new NitteiDetailVM(), dto, staffids, flg, restemp.selectorlist2, restemp.selectorlist3, restemp.selectorlist4, restemp.selectorlist5);
                }
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(dto?.regsisyo) || sisyoList.Contains(CStr(dto?.regsisyo));

                //更新日時(排他用)
                if (req.editkbn == Enum編集区分.変更)
                {
                    res.upddttm = dto!.upddttm;
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面：コース)")]
        public InitCourseDetailResponse InitDetailCourse(InitCourseDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト設定
                var res = (InitCourseDetailResponse)GetInitListResponse(db, req.kinoid!, new InitCourseDetailResponse(), false);

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //事業予定コーステーブル
                tt_kkjigyoyoteicourseDto? dto = null;
                //事業予定テーブル
                var dtl1 = new List<tt_kkjigyoyoteiDto>();
                //事業予定担当者テーブル
                var dtl2 = new List<tt_kkjigyoyotei_staffDto>();
                //事業予約希望者テーブル
                var dtl3 = new List<tt_kkjigyoyoyakukibosyaDto>();
                //その他日程事業・保健指導事業コード
                string? jigyocd = null;
                //登録支所名
                var regsisyonm = string.Empty;
                if (req.editkbn == Enum編集区分.変更 || (req.editkbn == Enum編集区分.新規 && req.copyflg))
                {
                    //事業予定コーステーブル
                    dto = db.tt_kkjigyoyoteicourse.GetDtoByKey(req.courseno!.Value);
                    //事業予定テーブル
                    dtl1 = db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), req.courseno!.Value).GetDtoList().
                            OrderBy(e => e.kaisu).ToList();
                    //その他日程事業・保健指導事業コード
                    jigyocd = dtl1[0].jigyocd;
                    //日程リスト
                    var keyList = dtl1.Select(e => e.nitteino).ToList();
                    //事業予定担当者テーブル
                    dtl2 = db.tt_kkjigyoyotei_staff.SELECT.WHERE.ByKeyList(keyList).GetDtoList();
                    //登録支所名
                    regsisyonm = DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, Enum名称区分.名称, CStr(dto.regsisyo));
                    if (req.editkbn == Enum編集区分.変更)
                    {
                        //事業予約希望者テーブル
                        dtl3 = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKeyList(keyList).GetDtoList();
                    }
                }

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //コース情報(ヘッダー)
                res.headerinfo = Wraper.GetHeaderVM(res.selectorlist2, dto, jigyocd, regsisyonm);
                
                //ドロップダウンリスト(全データ)
                var restemp = (InitNitteiDetailResponse)GetInitListResponse(db, req.kinoid!, new InitNitteiDetailResponse(), true);

                //コース情報(明細)
                if (req.copyflg)
                {
                    res.detailinfo = Wraper.GetVMList(dtl1, dtl2, dtl3, req.copyflg, res.selectorlist2, res.selectorlist3, res.selectorlist4, res.selectorlist5);
                }
                else 
                {
                    res.detailinfo = Wraper.GetVMList(dtl1, dtl2, dtl3, req.copyflg, restemp.selectorlist2, restemp.selectorlist3, restemp.selectorlist4, restemp.selectorlist5);
                }
                //編集フラグ
                res.editflg = string.IsNullOrEmpty(dto?.regsisyo) || sisyoList.Contains(CStr(dto?.regsisyo));

                //更新日時(排他用)
                if (req.editkbn == Enum編集区分.変更)
                {
                    res.upddttm = dto!.upddttm;
                }

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理(詳細画面：日程)")]
        public DaResponseBase SaveNittei(SaveNitteiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //悲観排他：日程番号取得して、差分更新
                db.tt_kkjigyoyotei.SELECT.WaitTable();
                //事業予定テーブル
                var dto = new tt_kkjigyoyoteiDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //事業予定テーブル
                    dto = db.tt_kkjigyoyotei.GetDtoByKey(req.nitteino!.Value);
                }
                //日程番号
                int nitteino = CInt(req.nitteino);
                if (req.editkbn == Enum編集区分.新規)
                {
                    nitteino = db.tt_kkjigyoyotei.SELECT.GetMax<int>(nameof(tt_kkjigyoyoteiDto.nitteino)) + 1;
                }

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.変更 && dto.jigyocd != DaSelectorService.GetCd(req.detailinfo.jigyocdnm))
                {
                    //存在チェック
                    var flg = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(req.nitteino!.Value).Exists();
                    //予約データ存在する場合
                    if (flg)
                    {
                        res.SetServiceError(EnumMessage.E014004, "予約希望者", "変更");
                        //異常返し
                        return res;
                    }
                }
                //利用停止データ登録チェック
                if (req.editkbn == Enum編集区分.新規)
                {
                    var jigyocd = DaSelectorService.GetCd(req.detailinfo.jigyocdnm);
                    if (db.tm_kksonotasidojigyo.SELECT.WHERE.ByKey(jigyocd).GetDto().stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "事業");
                        //異常返し
                        return res;
                    }
                    var kaijocd = DaSelectorService.GetCd(req.detailinfo.kaijocdnm);
                    if (db.tm_afkaijo.SELECT.WHERE.ByKey(kaijocd).GetDto().stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "会場");
                        //異常返し
                        return res;
                    }
                    var kikancd = DaSelectorService.GetCd(req.detailinfo.kikancdnm);
                    if (!string.IsNullOrEmpty(kikancd) && db.tm_afkikan.SELECT.WHERE.ByKey(kikancd).GetDto().stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "医療機関");
                        //異常返し
                        return res;
                    }
                }
                //重複チェック
                var flg2 = db.tt_kkjigyoyotei.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_kkjigyoyoteiDto.jigyocd)} = @{nameof(tt_kkjigyoyoteiDto.jigyocd)} and 
                                        {nameof(tt_kkjigyoyoteiDto.jissiyoteiymd)} = @{nameof(tt_kkjigyoyoteiDto.jissiyoteiymd)} and 
                                        {nameof(tt_kkjigyoyoteiDto.tmf)} = @{nameof(tt_kkjigyoyoteiDto.tmf)} and 
                                        {nameof(tt_kkjigyoyoteiDto.kaijocd)} = @{nameof(tt_kkjigyoyoteiDto.kaijocd)} and 
                                        {nameof(tt_kkjigyoyoteiDto.nitteino)} != @{nameof(tt_kkjigyoyoteiDto.nitteino)}",
                                        DaSelectorService.GetCd(req.detailinfo.jigyocdnm), req.detailinfo.jissiyoteiymd, req.detailinfo.tmf,
                                        DaSelectorService.GetCd(req.detailinfo.kaijocdnm),
                                        nitteino).Exists();
                //重複データ存在する場合
                if (flg2)
                {
                    res.SetServiceError(EnumMessage.E001008, "事業名、実施予定日、開始時間、会場");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //事業予定テーブル
                dto = Converter.GetDto(req.detailinfo, nitteino);

                //担当者一覧
                var selectorlist5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, string.Empty);

                //担当者名称をIDに変換
                for (int i = 0; i < req.detailinfo.staffids.Count; i++) 
                {
                    if (!Regex.IsMatch(req.detailinfo.staffids[i], @"^[0-9a-zA-Z]+$")) 
                    {
                        var item = selectorlist5.Find(e => e.label == req.detailinfo.staffids[i]);
                        if (item != null) {
                            req.detailinfo.staffids[i] = item.value;
                        }
                    }
                }
               
                //事業予定担当者テーブル
                var dtl = Converter.GetDtl(nitteino, req.detailinfo.staffids);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //事業予定テーブル：ベースで主キー重複チェック
                    db.tt_kkjigyoyotei.INSERT.Execute(dto);
                }
                //変更の場合
                else
                {
                    //事業予定テーブル：排他チェック
                    db.tt_kkjigyoyotei.UpdateDto(dto, req.upddttm!.Value);
                }
                //事業予定担当者テーブル
                db.tt_kkjigyoyotei_staff.UPDATE.WHERE.ByKey(nitteino).Execute(dtl);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理(詳細画面：コース)")]
        public DaResponseBase SaveCourse(SaveCourseRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //悲観排他：日程番号取得して、差分更新
                db.tt_kkjigyoyotei.SELECT.WaitTable();

                //コース番号
                int courseno = CInt(req.courseno);
                //DB更新用キーリスト
                List<int>? keyList = null;
                if (req.editkbn == Enum編集区分.新規)
                {
                    //事業予定コーステーブル
                    courseno = db.tt_kkjigyoyoteicourse.SELECT.GetMax<int>(nameof(tt_kkjigyoyoteicourseDto.courseno)) + 1;
                }
                else
                {
                    //事業予定テーブル
                    keyList = db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), req.courseno!.Value).GetKeyList().Select(e => e[0]).Cast<int>().ToList();
                }
                //日程番号最大値
                var nitteino = db.tt_kkjigyoyotei.SELECT.GetMax<int>(nameof(tt_kkjigyoyoteiDto.nitteino)) + 1;

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //日程番号リスト(画面DB両方存在)
                var keyList1 = req.detailinfo.Where(e => e.nitteino != null).Select(e => CInt(e.nitteino)).ToList();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //事業予定テーブル
                    var dtl1 = db.tt_kkjigyoyotei.SELECT.WHERE.ByKeyList(keyList1).GetDtoList();
                    //日程番号リスト(事業コード変更)
                    var keyList2 = dtl1.Where(e => req.detailinfo.Exists(x => x.nitteino == e.nitteino && DaSelectorService.GetCd(x.jigyocdnm) != e.jigyocd)).Select(e => e.nitteino).ToList();
                    if (keyList2.Count > 0)
                    {
                        //存在チェック
                        var flg = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKeyList(keyList2).Exists();
                        //予約データ存在する場合
                        if (flg)
                        {
                            res.SetServiceError(EnumMessage.E014004, "予約希望者", "変更");
                            //異常返し
                            return res;
                        }
                    }
                }

                //利用停止データ登録チェック
                if (req.editkbn == Enum編集区分.新規) { 
                    foreach (var row in req.detailinfo)
                    {
                        var jigyocd = DaSelectorService.GetCd(row.jigyocdnm);
                        if (db.tm_kksonotasidojigyo.SELECT.WHERE.ByKey(jigyocd).GetDto().stopflg)
                        {
                            res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "事業");
                            //異常返し
                            return res;
                        }
                        var kaijocd = DaSelectorService.GetCd(row.kaijocdnm);
                        if (db.tm_afkaijo.SELECT.WHERE.ByKey(kaijocd).GetDto().stopflg)
                        {
                            res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "会場");
                            //異常返し
                            return res;
                        }
                        var kikancd = DaSelectorService.GetCd(row.kikancdnm);
                        if (!string.IsNullOrEmpty(kikancd) && db.tm_afkikan.SELECT.WHERE.ByKey(kikancd).GetDto().stopflg)
                        {
                            res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "医療機関");
                            //異常返し
                            return res;
                        }
                    }
                }
                //重複チェック
                //重複項目リスト
                var keyList3 = new List<object?[]>();
                foreach (var row in req.detailinfo)
                {
                    keyList3.Add(new object?[] { DaSelectorService.GetCd(row.jigyocdnm), row.jissiyoteiymd, row.tmf,
                                                DaSelectorService.GetCd(row.kaijocdnm)});
                }
                //キーリスト
                var keys = new string[] { nameof(tt_kkjigyoyoteiDto.jigyocd), nameof(tt_kkjigyoyoteiDto.jissiyoteiymd),
                                        nameof(tt_kkjigyoyoteiDto.tmf),nameof(tt_kkjigyoyoteiDto.kaijocd)};
                //事業予定テーブル(項目重複)
                var dtl2 = db.Session.GetDtoListByItemList<tt_kkjigyoyoteiDto>(keys, keyList3);
                //回数リスト(項目重複：画面側)
                var keyList4 = req.detailinfo.Where(e => dtl2.Exists(x => x.nitteino != e.nitteino &&
                                                                    x.jigyocd == DaSelectorService.GetCd(e.jigyocdnm) &&
                                                                    x.jissiyoteiymd == e.jissiyoteiymd &&
                                                                    x.tmf == e.tmf &&
                                                                    x.kaijocd == DaSelectorService.GetCd(e.kaijocdnm))).
                                                                    Select(e => e.kaisu).ToList();
                //重複データ存在する場合
                if (keyList4.Count > 0)
                {
                    res.SetServiceError(EnumMessage.E001008, "事業名、実施予定日、開始時間、会場");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //事業予定コーステーブル
                var dto = Converter.GetDto(courseno, req.coursenm);
                //日程番号設定
                req.detailinfo = Wraper.GetVMList(req.detailinfo.OrderBy(e => e.kaisu).ToList(), nitteino);

                //担当者一覧
                var selectorlist5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, string.Empty);

                //担当者名称をIDに変換
                foreach (var record in req.detailinfo)
                {
                    for (int i = 0; i < record.staffids.Count; i++)
                    {
                        if (!Regex.IsMatch(record.staffids[i], @"^[0-9a-zA-Z]+$"))
                        {
                            var item = selectorlist5.Find(e => e.label == record.staffids[i]);
                            if (item != null)
                            {
                                record.staffids[i] = item.value;
                            }
                        }
                    }
                }

                //事業予定テーブル
                var dtl3 = Converter.GetDtl(courseno, req.detailinfo);
                //事業予定担当者テーブル
                var dtl4 = Converter.GetDtl(req.detailinfo);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //事業予定コーステーブル：ベースで主キー重複チェック
                    db.tt_kkjigyoyoteicourse.INSERT.Execute(dto);
                }
                //変更の場合
                else
                {
                    //事業予定コーステーブル：排他チェック
                    db.tt_kkjigyoyoteicourse.UpdateDto(dto, req.upddttm!.Value);
                }

                //事業予定テーブル
                db.tt_kkjigyoyotei.UPDATE.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), courseno).Execute(dtl3);
                //画面日程番号リスト
                var keyList5 = req.detailinfo.Select(e => CInt(e.nitteino)).ToList();
                //差分更新キーリスト
                if (keyList != null)
                {
                    keyList = keyList.Concat(keyList5).Distinct().ToList();
                }
                else
                {
                    keyList = keyList5;
                }
                //事業予定担当者テーブル
                db.tt_kkjigyoyotei_staff.UPDATE.WHERE.ByKeyList(keyList).Execute(dtl4);

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理(詳細画面：日程)")]
        public DaResponseBase DeleteNittei(DeleteNitteiRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //存在チェック
                var flg = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKey(req.nitteino).Exists();
                //予約データ存在する場合
                if (flg)
                {
                    res.SetServiceError(EnumMessage.E014004, "予約希望者", "削除");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //事業予定テーブル
                db.tt_kkjigyoyotei.DeleteByKey(req.nitteino, req.upddttm);
                //事業予定担当者テーブル
                db.tt_kkjigyoyotei_staff.DELETE.WHERE.ByKey(req.nitteino).Execute();

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理(詳細画面：コース)")]
        public DaResponseBase DeleteCourse(DeleteCourseRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //事業予定テーブル
                var keyList = db.tt_kkjigyoyotei.SELECT.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), req.courseno).GetKeyList().Select(e => e[0]).Cast<int>().ToList();
                //存在チェック
                var flg = db.tt_kkjigyoyoyakukibosya.SELECT.WHERE.ByKeyList(keyList).Exists();
                //予約データ存在する場合
                if (flg)
                {
                    res.SetServiceError(EnumMessage.E014004, "予約希望者", "削除");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //事業予定コーステーブル
                db.tt_kkjigyoyoteicourse.DeleteByKey(req.courseno, req.upddttm);
                //事業予定テーブル
                db.tt_kkjigyoyotei.DELETE.WHERE.ByItem(nameof(tt_kkjigyoyoteiDto.courseno), req.courseno).Execute();
                //事業予定担当者テーブル
                db.tt_kkjigyoyotei_staff.DELETE.WHERE.ByKeyList(keyList).Execute();

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// ドロップダウンリスト設定
        /// </summary>
        public static InitListResponse GetInitListResponse(DaDbContext db, string kinoid, InitListResponse res, bool hasStopFlg)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //その他日程事業・保健指導事業マスタ
            var dtl = db.tm_kksonotasidojigyo.SELECT.WHERE.
                        ByFilter($@"{nameof(tm_kksonotasidojigyoDto.yoyakuriyoflg)} = @{nameof(tm_kksonotasidojigyoDto.yoyakuriyoflg)}", true).
                        GetDtoList();
            if (!hasStopFlg)
            {
                dtl = dtl.Where(e => e.stopflg == false).ToList();
            }
            //医療機関事業一覧
            var jigyocds1 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, null, false);
            //事業従事者事業一覧
            var jigyocds2 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, null, false);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //業務区分一覧
            res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.拡張_予約_保健指導業務区分, Enum名称区分.名称);
            //予約事業一覧
            res.selectorlist2 = Wraper.GetSelectorList(dtl);
            //会場一覧
            res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, hasStopFlg);
            //医療機関一覧
            res.selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, hasStopFlg, CStr(ListToCommaStr(jigyocds1)));
            //担当者一覧
            res.selectorlist5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, hasStopFlg, CStr(ListToCommaStr(jigyocds2)));

            //正常返し
            return res;
        }
    }
}