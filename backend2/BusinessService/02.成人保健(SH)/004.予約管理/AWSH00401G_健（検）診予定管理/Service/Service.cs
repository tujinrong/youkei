// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診予定管理
// 　　　　　　サービス処理
// 作成日　　: 2024.02.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00401G
{
    [DisplayName("健（検）診予定管理")]
    public class Service : CmServiceBase
    {
        private const string AWSH00401G = "AWSH00401G";
        private const string YOYAKU = "0";  //検査方法なしの場合予約分類コードの設定値

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return GetInitListResponse(db, AWSH00401G);
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //検診事業検査方法一覧
                var keyList = new List<object[]>();
                //検診事業一覧(検査方法あり)
                var cdList = new List<string>();
                //検診事業略称一覧(検査方法なし)
                var nmList1 = new List<object[]>();
                //予約分類名一覧
                var nmList2 = new List<object[]>();
                //関連データ取得
                GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2);

                //検診予約列一覧(名称)
                var keyList1 = GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.名称関係);
                //関係性一覧(検診事業、予約分類、検査方法)
                var keyList2 = GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係);

                //-------------------------------------------------------------
                //２.条件設定
                //-------------------------------------------------------------
                //固定の検索条件
                var fixedCondition = Converter.GetFixedCondition(req);
                //詳細の検索条件(なし)
                var conditon = CmSearchUtil.GetSearchJyoken(db, null, null, fixedCondition, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果
                var result = DaFreeQuery.GetKensinYoyakuQuery(db, req.nendo, req.staffid, keyList1, keyList2, conditon, req.orderby, true);
                //総件数
                var total = result.Count;
                //結果一覧
                var pageData = result.Data;

                //成人健（検）診予約日程事業一覧
                var selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, true);
                //会場一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //ページャー設定
                res.SetPageInfo(total, req.pagesize);
                //列情報設定
                res.columnInfos = Wraper.GetVMList(pageData.Columns, 2);
                //キーリスト
                var keyList3 = res.columnInfos.Select(e => e.key).ToList();
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(pageData.Rows, keyList3, selectorlist1, selectorlist2, selectorlist3);

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
                //健（検）診予定テーブル
                tt_shkensinyoteiDto? dto = null;
                //健（検）診予定詳細テーブル
                var dtl1 = new List<tt_shkensinyoteisyosaiDto>();
                //健（検）診予定担当者テーブル
                var dtl2 = new List<tt_shkensinyotei_staffDto>();
                //成人健（検）診予約日程事業サブマスタ
                var dtl3 = new List<tm_shyoyakujigyo_subDto>();

                if (req.editkbn == Enum編集区分.変更 || (req.editkbn == Enum編集区分.新規 && req.copyflg))
                {
                    //健（検）診予定テーブル
                    dto = db.tt_shkensinyotei.GetDtoByKey(req.nendo, req.nitteino!.Value);
                    //健（検）診予定詳細テーブル
                    dtl1 = db.tt_shkensinyoteisyosai.SELECT.WHERE.ByKey(req.nendo, req.nitteino).GetDtoList();
                    //健（検）診予定担当者テーブル
                    dtl2 = db.tt_shkensinyotei_staff.SELECT.WHERE.ByKey(req.nendo, req.nitteino).GetDtoList();
                    //成人健（検）診予約日程事業サブマスタ
                    dtl3 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo, dto.jigyocd).GetDtoList();
                }

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);
                //登録支所
                var dtl4 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

                //検診事業検査方法一覧
                var keyList = new List<object[]>();
                //検診事業一覧(検査方法あり)
                var cdList = new List<string>();
                //検診事業略称一覧(検査方法なし)
                var nmList1 = new List<object[]>();
                //予約分類名一覧
                var nmList2 = new List<object[]>();
                //関連データ取得
                GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2);
                //検診予約列一覧(名称)
                var keyList1 = GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.名称関係);
                //関係性一覧(検診事業、予約分類、検査方法)
                var keyList2 = GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係);
                //選択年度の予約日程事業一覧
                var jigyocds = db.tm_shyoyakujigyo.SELECT.WHERE.ByKey(req.nendo).GetDtoList().Select(e => e.jigyocd).Distinct().ToList();
                //医療機関事業一覧
                var jigyocds2 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.医療機関, AWSH00401G, Enum事業コードパターン.DB設定, null, false);
                //事業従事者事業一覧
                var jigyocds3 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, AWSH00401G, Enum事業コードパターン.DB設定, null, false);

                //成人健（検）診予約日程事業一覧
                var selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, true).
                                    Where(e => jigyocds.Contains(e.value)).ToList();
                //会場一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true, CStr(ListToCommaStr(jigyocds2)));
                //担当者一覧
                var selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, CStr(ListToCommaStr(jigyocds3)));
                
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //成人健（検）診予約日程事業一覧
                res.selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, false).
                                    Where(e => jigyocds.Contains(e.value)).ToList();
                //会場一覧
                res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ);
                //医療機関一覧
                res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, false, CStr(ListToCommaStr(jigyocds2)));
                //担当者一覧
                res.selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, false, CStr(ListToCommaStr(jigyocds3)));
                //予定メイン情報
                if (req.copyflg)
                {
                    res.maininfo = Wraper.GetVM(dto, dtl2, dtl4, res.selectorlist1, res.selectorlist2, res.selectorlist3, res.selectorlist4);
                }
                else
                {
                    res.maininfo = Wraper.GetVM(dto, dtl2, dtl4, selectorlist1, selectorlist2, selectorlist3, selectorlist4);
                }
                //予定定員情報一覧
                res.kekkalist = Wraper.GetVMList(dtl1, keyList1);
                //予定定員情報一覧(制御用)
                res.editlist = Wraper.GetVMList(dtl3, keyList2);
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

        [DisplayName("編集可能予約一覧取得処理(詳細画面)")]
        public GetEditYoyakuResponse GetEditYoyaku(GetEditYoyakuRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetEditYoyakuResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //成人健（検）診予約日程事業サブマスタ
                var dtl = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo, req.jigyocd).GetDtoList();

                //検診事業検査方法一覧
                var keyList = new List<object[]>();
                //検診事業一覧(検査方法あり)
                var cdList = new List<string>();
                //検診事業略称一覧(検査方法なし)
                var nmList1 = new List<object[]>();
                //予約分類名一覧
                var nmList2 = new List<object[]>();
                //関連データ取得
                GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2);
                //関係性一覧(検診事業、予約分類、検査方法)
                var list = GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //予定定員情報一覧(制御用)
                res.editlist = Wraper.GetVMList(dtl, list);

                //正常返し
                return res;
            });
        }
        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //健（検）診予定テーブル
                var dto = new tt_shkensinyoteiDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //健（検）診予定テーブル
                    dto = db.tt_shkensinyotei.GetDtoByKey(req.nendo, req.nitteino!.Value);
                }
                //日程番号
                int nitteino = CInt(req.nitteino);
                if (req.editkbn == Enum編集区分.新規)
                {
                    nitteino = db.tt_shkensinyotei.SELECT.WHERE.ByKey(req.nendo).GetMax<int>(nameof(tt_shkensinyoteiDto.nitteino)) + 1;
                }

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.変更 && dto.jigyocd != DaSelectorService.GetCd(req.maininfo.jigyocdnm))
                {
                    //存在チェック
                    var flg = db.tt_shkensinyoyakukibosya.SELECT.WHERE.ByKey(req.nendo, req.nitteino!).Exists();
                    //予約データ存在する場合
                    if (flg)
                    {
                        res.SetServiceError(EnumMessage.E014004, "予約希望者", "事業名変更");
                        //異常返し
                        return res;
                    }
                }
                //利用停止データ登録チェック
                if (req.editkbn == Enum編集区分.新規)
                {
                    var jigyocd = DaSelectorService.GetCd(req.maininfo.jigyocdnm);
                    if (DaHanyoService.GetHanyoDto(db, EnumHanyoKbn.成人健_検_診予約日程事業名, jigyocd).stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "事業");
                        //異常返し
                        return res;
                    }
                    var kaijocd = DaSelectorService.GetCd(req.maininfo.kaijocdnm);
                    if (db.tm_afkaijo.SELECT.WHERE.ByKey(kaijocd).GetDto().stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "会場");
                        //異常返し
                        return res;
                    }
                    var kikancd = DaSelectorService.GetCd(req.maininfo.kikancdnm);
                    if (!string.IsNullOrEmpty(kikancd) && db.tm_afkikan.SELECT.WHERE.ByKey(kikancd).GetDto().stopflg)
                    {
                        res.SetServiceError(EnumMessage.K000001, "使用停止のデータがあります。", "医療機関");
                        //異常返し
                        return res;
                    }
                }
                //重複チェック
                var flg2 = db.tt_shkensinyotei.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_shkensinyoteiDto.nendo)} = @{nameof(tt_shkensinyoteiDto.nendo)} and 
                                        {nameof(tt_shkensinyoteiDto.jigyocd)} = @{nameof(tt_shkensinyoteiDto.jigyocd)} and 
                                        {nameof(tt_shkensinyoteiDto.yoteiymd)} = @{nameof(tt_shkensinyoteiDto.yoteiymd)} and 
                                        {nameof(tt_shkensinyoteiDto.tmf)} = @{nameof(tt_shkensinyoteiDto.tmf)} and 
                                        {nameof(tt_shkensinyoteiDto.kaijocd)} = @{nameof(tt_shkensinyoteiDto.kaijocd)} and 
                                        {nameof(tt_shkensinyoteiDto.nitteino)} != @{nameof(tt_shkensinyoteiDto.nitteino)}",
                                        req.nendo, DaSelectorService.GetCd(req.maininfo.jigyocdnm), req.maininfo.yoteiymd, req.maininfo.timef,
                                        DaSelectorService.GetCd(req.maininfo.kaijocdnm), nitteino).
                                        Exists();
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
                //健（検）診予定テーブル
                dto = Converter.GetDto(dto, req.nendo, nitteino, req.maininfo);
                //健（検）診予定詳細テーブル
                var dtl1 = Converter.GetDtl(req.nendo, nitteino, req.kekkalist);

                //担当者一覧
                var selectorlist5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, string.Empty);

                //担当者名称をIDに変換
                for (int i = 0; i < req.maininfo.staffids.Count; i++)
                {
                    if (!Regex.IsMatch(req.maininfo.staffids[i], @"^[0-9a-zA-Z]+$"))
                    {
                        var item = selectorlist5.Find(e => e.label == req.maininfo.staffids[i]);
                        if (item != null)
                        {
                            req.maininfo.staffids[i] = item.value;
                        }
                    }
                }

                //健（検）診予定担当者テーブル
                var dtl2 = Converter.GetDtl(req.nendo, nitteino, req.maininfo.staffids);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                if (req.editkbn == Enum編集区分.新規)
                {
                    //健（検）診予定テーブル
                    db.tt_shkensinyotei.INSERT.Execute(dto);
                }
                else
                {
                    //健（検）診予定テーブル
                    db.tt_shkensinyotei.UpdateDto(dto, req.upddttm!.Value);
                }

                //健（検）診予定詳細テーブル
                db.tt_shkensinyoteisyosai.UPDATE.WHERE.ByKey(req.nendo, nitteino).Execute(dtl1);
                //健（検）診予定担当者テーブル
                db.tt_shkensinyotei_staff.UPDATE.WHERE.ByKey(req.nendo, nitteino).Execute(dtl2);

                //正常返し
                return res;
            });
        }
        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //存在チェック
                var flg = db.tt_shkensinyoyakukibosya.SELECT.WHERE.ByKey(req.nendo, req.nitteino).Exists();
                //予約データ存在する場合
                if (flg)
                {
                    res.SetServiceError(EnumMessage.E014001, "予約希望者");
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //健（検）診予定テーブル
                db.tt_shkensinyotei.DeleteByKey(req.nendo, req.nitteino, req.upddttm);
                //健（検）診予定詳細テーブル
                db.tt_shkensinyoteisyosai.DELETE.WHERE.ByKey(req.nendo, req.nitteino).Execute();
                //健（検）診予定担当者テーブル
                db.tt_shkensinyotei_staff.DELETE.WHERE.ByKey(req.nendo, req.nitteino).Execute();

                //正常返し
                return res;
            });
        }
        /// <summary>
        /// 初期化処理(共通)
        /// </summary>
        public static InitListResponse GetInitListResponse(DaDbContext db, string kinoid)
        {
            var res = new InitListResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //医療機関事業一覧
            var jigyocds1 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.医療機関, kinoid, Enum事業コードパターン.DB設定, null, false);
            //事業従事者事業一覧
            var jigyocds2 = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, kinoid, Enum事業コードパターン.DB設定, null, false);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //成人健（検）診予約日程事業一覧
            res.selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, true);
            //会場一覧
            res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
            //医療機関一覧
            res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true, CStr(ListToCommaStr(jigyocds1)));
            //担当者一覧
            res.selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, CStr(ListToCommaStr(jigyocds2)));

            //正常返し
            return res;
        }
        /// <summary>
        /// 予約関係データ取得
        /// </summary>
        public static void GetData(DaDbContext db, int nendo, out List<object[]> keys, out List<string> cds,
                                    out List<object[]> nmList1, out List<object[]> nmList2, string? jigyocd = null)
        {
            //検診事業一覧
            var dtl1 = db.tm_shkensinjigyo.SELECT.GetDtoList().Where(e => e.kensahoho_setflg).ToList();
            //検診事業一覧(検査方法あり)
            var cdList = dtl1.Select(e => e.jigyocd).OrderBy(e => e).ToList();

            //検診事業略称一覧(検査方法なし)
            nmList1 = DaHanyoService.GetHanyoDtl(db, EnumHanyoKbn.検診種別).
                            Where(e => !cdList.Contains(e.hanyocd)).
                            Select(e => new object[] { e.hanyocd, e.shortnm! }).ToList();
            //成人健（検）診予約日程事業サブマスタ
            var dtl2 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(nendo).GetDtoList().
                        OrderBy(e => e.kensin_jigyocd).ThenBy(e => e.kensahohocd).ToList();
            //日程事業確定の場合(日程詳細画面)
            if (!string.IsNullOrEmpty(jigyocd))
            {
                dtl2 = dtl2.Where(e => e.jigyocd == jigyocd).ToList();
            }
            //検診事業検査方法一覧
            var keyList = dtl2.Select(e => new object[] { e.kensin_jigyocd, e.kensahohocd }).ToList();
            //予約分類汎用マスタキー
            var keyList2 = dtl1.Select(e => new object[] { e.yoyakubunrui_maincd!, e.yoyakubunrui_subcd!.Value }).ToList();
            //予約分類名一覧
            var hanyoList = new List<tm_afhanyoDto>();
            foreach (var item in keyList2)
            {
                hanyoList.AddRange(DaHanyoService.GetHanyoDtl(db, CStr(item[0]), CInt(item[1])));
            }
            nmList2 = hanyoList.Where(e => Check(e, keyList)).Select(e => new object[] { e.hanyosubcd, e.hanyocd, e.hanyokbn1!, e.shortnm! }).ToList();
            //変数設定
            keys = keyList; //検診事業検査方法一覧
            cds = cdList;   //検診事業一覧(検査方法あり)
        }
        /// <summary>
        /// 予約関係取得
        /// </summary>
        public static List<object[]> GetKeyList(List<object[]> keyList, List<string> cdList, List<object[]> nmList1, List<object[]> nmList2, Enum予約関係分類 kbn)
        {
            var list = new List<object[]>();
            foreach (var key in keyList)
            {
                //予約分類なしの場合
                var jigyocd = CStr(key[0]);
                if (!cdList.Contains(jigyocd))
                {
                    var nm = CStr(nmList1.Find(e => CStr(e[0]) == jigyocd)![1]);
                    object[] obj;
                    switch (kbn)
                    {
                        case Enum予約関係分類.名称関係:
                            obj = new object[] { jigyocd, YOYAKU, nm };
                            if (!list.Exists(e => e.SequenceEqual(obj)))
                            {
                                list.Add(obj);
                            }
                            break;
                        case Enum予約関係分類.検査方法コード関係:
                            obj = new object[] { jigyocd, YOYAKU, AWSH00301G.Service.KENSAHOHOCD };
                            if (!list.Exists(e => e.SequenceEqual(obj)))
                            {
                                list.Add(obj);
                            }
                            break;
                        default:
                            throw new Exception("Enum予約関係分類 error");
                    }
                }
                //予約分類ありの場合
                else
                {
                    var kensahohocd = CStr(key[1]);
                    var subcd = CInt(CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, jigyocd));
                    var hanyo = nmList2.Find(e => CInt(e[0]) == subcd && CommaStrToList(CStr(e[2])).Contains(kensahohocd))!;
                    var yoyakubunruicd = YOYAKU;
                    var nm2 = AWSH00301G.Service.KENSAHOHOCD;
                    if (hanyo != null)
                    {
                        yoyakubunruicd = CStr(hanyo[1]);
                        nm2 = CStr(hanyo[3]);
                    }
                    var obj = new object[] { jigyocd, yoyakubunruicd, nm2 };
                    switch (kbn)
                    {
                        case Enum予約関係分類.名称関係:
                            if (!list.Exists(e => e.SequenceEqual(obj)))
                            {
                                list.Add(obj);
                            }
                            break;
                        case Enum予約関係分類.検査方法コード関係:
                            list.Add(new object[] { jigyocd, yoyakubunruicd, kensahohocd });
                            break;
                        default:
                            throw new Exception("Enum予約関係分類 error");
                    }
                }
            }
            if (kbn == Enum予約関係分類.名称関係)
            {
                list = list.OrderBy(e => CStr(e[0])).ThenBy(e => CStr(e[1])).ToList();
            }

            return list;
        }

        /// <summary>
        /// 予約分類使用チェック
        /// </summary>
        private static bool Check(tm_afhanyoDto dto, List<object[]> keyList)
        {
            var cdList = keyList.Where(e => CmLogicUtil.GetHanyoSubcd(Enum検診関連汎用マスタ区分.予約分類, CStr(e[0])) == dto.hanyosubcd).
                        Select(e => CStr(e[1])).ToList();
            var cdList2 = CommaStrToList(dto.hanyokbn1!);
            foreach (var cd in cdList)
            {
                if (cdList2.Contains(cd)) {
                    return true;
                }
            }
            return false;
        }
    }
}