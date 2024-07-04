// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診予約希望者管理
// 　　　　　　サービス処理
// 作成日　　: 2024.02.19
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00402G
{
    [DisplayName("健（検）診予約希望者管理")]
    public class Service : CmServiceBase
    {
        private const string AWSH00402G = "AWSH00402G";
        private const int YOYAKUPERSON_MAX = 10000; //予約人数上限(定員設定上限)
        private const string PROC_NAME = "sp_awsh00402g_01";

        private const string KANEN = "02"; //肝炎
        private const string KANEN_B = "101901239001"; //Ｂ型肝炎ウイルス検査判定
        private const string KANEN_C = "101901241001"; //Ｃ型肝炎ウイルス検査判定

        [DisplayName("初期化処理(日程一覧画面)")]
        public AWSH00401G.InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                //正常返し
                return AWSH00401G.Service.GetInitListResponse(db, AWSH00402G);
            });
        }

        [DisplayName("検索処理(日程一覧画面)")]
        public AWSH00401G.SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new AWSH00401G.SearchListResponse();
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
                AWSH00401G.Service.GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2);

                //検診予約列一覧(名称)
                var keyList1 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.名称関係);
                //関係性一覧(検診事業、予約分類、検査方法)
                var keyList2 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係);

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
                var result = DaFreeQuery.GetKensinYoyakuPersonQuery(db, req.nendo, req.staffid, keyList1, keyList2, conditon, req.orderby, true);
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
                res.columnInfos = Wraper.GetVMList(pageData.Columns, keyList1.Count() * 3 + 9);
                //キーリスト
                var keyList3 = res.columnInfos.Select(e => e.key).ToList();
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(pageData.Rows, keyList3, selectorlist1, selectorlist2, selectorlist3);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(予約者一覧画面)")]
        public InitPersonListResponse InitDetailPersonList(InitPersonListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitPersonListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //健（検）診予定テーブル
                var dto = db.tt_shkensinyotei.GetDtoByKey(req.nendo, req.nitteino);
                //担当者一覧
                var staffids = db.tt_shkensinyotei_staff.SELECT.WHERE.ByKey(req.nendo, req.nitteino).GetDtoList().
                                Select(e => e.staffid).OrderBy(e => e).ToList();

                //検診事業検査方法一覧
                var keyList = new List<object[]>();
                //検診事業一覧(検査方法あり)
                var cdList = new List<string>();
                //検診事業略称一覧(検査方法なし)
                var nmList1 = new List<object[]>();
                //予約分類名一覧
                var nmList2 = new List<object[]>();
                //関連データ取得
                AWSH00401G.Service.GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2, dto.jigyocd);

                //検診予約列一覧(名称)
                var keyList1 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.名称関係);
                //関係性一覧(検診事業、予約分類、検査方法)
                var keyList2 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係);

                //成人健（検）診予約日程事業一覧
                var selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, true);
                //会場一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);
                //担当者一覧
                var selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //-------------------------------------------------------------
                //２.条件設定
                //-------------------------------------------------------------
                //固定の検索条件(予約者一覧画面：予約情報)
                var fixedCondition = Converter.GetFixedCondition(req.nendo, req.nitteino);
                //詳細の検索条件(なし)
                var conditon = CmSearchUtil.GetSearchJyoken(db, null, null, fixedCondition, 1, 1);

                //固定の検索条件(予約者一覧画面：予約者情報)
                var fixedCondition2 = Converter.GetFixedCondition2(req);
                //詳細の検索条件(なし)
                var conditon2 = CmSearchUtil.GetSearchJyoken(db, null, null, fixedCondition2, 1, YOYAKUPERSON_MAX);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果(予約者一覧画面：予約情報)
                var result1 = DaFreeQuery.GetKensinYoyakuPersonQuery2(db, req.nendo, keyList1, keyList2, conditon);
                //結果一覧
                var pageData1 = result1.Data;

                //検索結果(予約者一覧画面：予約者情報)
                var result2 = DaFreeQuery.GetKensinYoyakuPersonQuery3(db, req.nendo, req.nitteino, keyList1, keyList2, conditon2);
                //結果一覧
                var pageData2 = result2.Data;

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //日程基本情報
                res.headerinfo = Wraper.GetHeaderVM(dto, staffids, selectorlist1, selectorlist2, selectorlist3, selectorlist4);
                //結果一覧(予約情報)
                res.kekkalist1 = Wraper.GetVMList(pageData1.Rows[0], keyList1);
                //列情報設定
                res.columnInfos = Wraper.GetVMList(pageData2.Columns, 2);
                //キーリスト
                var keyList3 = res.columnInfos.Select(e => e.key).ToList();
                //画面項目設定
                res.kekkalist2 = Wraper.GetVMList(db, pageData2.Rows, keyList3, alertviewflg);

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
                var dto = db.tt_shkensinyotei.GetDtoByKey(req.nendo, req.nitteino);
                //担当者一覧
                var staffids = db.tt_shkensinyotei_staff.SELECT.WHERE.ByKey(req.nendo, req.nitteino).GetDtoList().
                                Select(e => e.staffid).OrderBy(e => e).ToList();
                //成人健（検）診予約日程事業一覧
                var selectorlist1 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.成人健_検_診予約日程事業名, Enum名称区分.名称, true);
                //会場一覧
                var selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ, true);
                //医療機関一覧
                var selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.医療機関マスタ, true);
                //担当者一覧
                var selectorlist4 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true);

                //個人基本情報取得
                var dto2 = db.tt_afatena.GetDtoByKey(req.atenano);
                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto2, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //健（検）診予約希望者テーブル
                var dto3 = new tt_shkensinyoyakukibosyaDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    dto3 = db.tt_shkensinyoyakukibosya.GetDtoByKey(req.nendo, req.nitteino, req.atenano);
                }

                //検診事業一覧
                var dtl = db.tm_shkensinjigyo.SELECT.GetDtoList();
                //検診事業一覧(検査方法あり)
                var dtl1 = dtl.Where(e => e.kensahoho_setflg).ToList();
                //キーリスト(検査方法あり)
                var keyList = dtl1.Select(e => new object[] { e.kensahoho_maincd!, e.kensahoho_subcd! }).ToList();
                //検診事業コードリスト(検査方法あり)
                var cdList = dtl1.Select(e => e.jigyocd).ToList();
                //検査方法一覧
                var dtl2 = new List<tm_afhanyoDto>();
                foreach (var item in keyList)
                {
                    dtl2.AddRange(DaHanyoService.GetHanyoDtl(db, CStr(item[0]), CInt(item[1])));
                }
                //検診事業略称一覧
                var selectorlist5 = DaHanyoService.GetSelectorList(db, EnumHanyoKbn.検診種別, Enum名称区分.略称, false);
                //健（検）診予約希望者詳細テーブル
                var dtl3 = db.tt_shkensinkibosyasyosai.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)} and 
                                        {nameof(tt_shkensinkibosyasyosaiDto.atenano)} = @{nameof(tt_shkensinkibosyasyosaiDto.atenano)}",
                                        req.nendo, req.atenano).GetDtoList();
                //健（検）診予定テーブル
                var dtl4 = db.tt_shkensinyotei.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                //成人健（検）診予約日程事業コード
                var jigyocd = dtl4.Find(e => e.nitteino == req.nitteino)!.jigyocd;
                //成人健（検）診予約日程事業サブマスタ
                var dtl5 = db.tm_shyoyakujigyo_sub.SELECT.WHERE.ByKey(req.nendo, jigyocd).GetDtoList();

                //パラメータ取得
                var param = Converter.GetParameters(req.nendo, req.atenano, dto.yoteiymd);
                //一覧抽出
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME, param);

                //年度マスタ:エラーメッセージ区分
                var dtl6 = db.tm_shnendo.SELECT.WHERE.ByKey(req.nendo).GetDtoList();

                //発券情報
                List<tt_kkhakkenDto> dtl9 = db.tt_kkhakken.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_kkhakkenDto.nendo)} = @{nameof(tt_kkhakkenDto.nendo)} and 
                                        {nameof(tt_kkhakkenDto.atenano)} = @{nameof(tt_kkhakkenDto.atenano)}",
                                        req.nendo, req.atenano).GetDtoList();

                //成人保健一次検診結果（固定項目）
                var dtl10 = db.tt_shkensin.SELECT.WHERE.ByItem(nameof(tt_kkhakkenDto.atenano), req.atenano).GetDtoList();
                //B型肝炎
                var existB = db.tt_shfree.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_shfreeDto.jigyocd)} = @{nameof(tt_shfreeDto.jigyocd)} and 
                                        {nameof(tt_shfreeDto.atenano)} = @{nameof(tt_shfreeDto.atenano)} and
                                        {nameof(tt_shfreeDto.nendo)} = @{nameof(tt_shfreeDto.nendo)} and
                                        {nameof(tt_shfreeDto.itemcd)} = @{ nameof(tt_shfreeDto.itemcd)}",
                                        KANEN, req.atenano, req.nendo, KANEN_B).Exists();
                //C型肝炎
                var existC = db.tt_shfree.SELECT.WHERE.
                            ByFilter(@$"{nameof(tt_shfreeDto.jigyocd)} = @{nameof(tt_shfreeDto.jigyocd)} and 
                                        {nameof(tt_shfreeDto.atenano)} = @{nameof(tt_shfreeDto.atenano)} and
                                        {nameof(tt_shfreeDto.nendo)} = @{nameof(tt_shfreeDto.nendo)} and
                                        {nameof(tt_shfreeDto.itemcd)} = @{nameof(tt_shfreeDto.itemcd)}",
                                        KANEN, req.atenano, req.nendo, KANEN_C).Exists();
                //対象サイン
                var signList = AWSH00404D.Service.SearchResult(db, new AWSH00404D.SearchRequest() { nendo = req.nendo, atenano = req.atenano, nitteino = req.nitteino }).kekkalist;
               
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //日程基本情報
                res.headerinfo = Wraper.GetHeaderVM(dto, staffids, selectorlist1, selectorlist2, selectorlist3, selectorlist4);
                //希望者情報
                res.personinfo = Wraper.GetVM(db, dto2, alertviewflg, adrsFlg);

                if (req.editkbn == Enum編集区分.変更)
                {
                    //備考
                    res.biko = CStr(dto3.biko);
                    //更新日時(排他用)
                    res.upddttm = dto3.upddttm;
                }
                else 
                {
                    res.biko = string.Empty;
                }
                //予約一覧
                res.kekkalist = Wraper.GetVMList(db, selectorlist5, dtl, dtl2, dtl3, dtl4, dtl5, dtl6, dtl9, dtl10, cdList, req.nitteino, existB, existC, signList, dt.Rows);
                //予約中データ(待機を除く)
                var vmList = res.kekkalist.Where(e => e.nitteino != null && !e.taikiflg).
                                Select(e => new AWSH00403D.MoneyKeyBase3VM()
                                {
                                    jigyocd = e.jigyocd,
                                    kensahohocd = cdList.Contains(e.jigyocd) ? DaSelectorService.GetCd(e.kensahohocdnm) : AWSH00301G.Service.KENSAHOHOCD,
                                    nitteino = CInt(e.nitteino)
                                }).ToList();

                //自己負担金情報
                var kekkalist = AWSH00403D.Service.Calculate(db, req.nendo, vmList, dto2, dtl, dtl4);
                res.moneyinfo = Wraper.GetVM(kekkalist);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("計算処理(詳細画面)")]
        public CalculateResponse Calculate(CalculateRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CalculateResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //宛名テーブル
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);
                //検診事業一覧
                var dtl = db.tm_shkensinjigyo.SELECT.GetDtoList();
                //健（検）診予定テーブル
                var dtl2 = db.tt_shkensinyotei.SELECT.WHERE.ByKey(req.nendo).GetDtoList();
                //検診事業コードリスト(検査方法あり)
                var cdList = dtl.Where(e => e.kensahoho_setflg).ToList().Select(e => e.jigyocd).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var vmList = req.kekkalist.Select(e => new AWSH00403D.MoneyKeyBase3VM()
                {
                    jigyocd = e.jigyocd,
                    kensahohocd = cdList.Contains(e.jigyocd) ? DaSelectorService.GetCd(e.kensahohocdnm) : AWSH00301G.Service.KENSAHOHOCD,
                    nitteino = CInt(e.nitteino)
                }).ToList();

                //自己負担金情報
                var kekkalist = AWSH00403D.Service.Calculate(db, req.nendo, vmList, dto, dtl, dtl2);
                res.moneyinfo = Wraper.GetVM(kekkalist);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("定員チェック処理(詳細画面)")]
        public CheckTeiinResponse CheckTeiin(CheckTeiinRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CheckTeiinResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //健（検）診予定テーブル
                var dto = db.tt_shkensinyotei.GetDtoByKey(req.nendo, req.nitteino);

                //検診事業検査方法一覧
                var keyList = new List<object[]>();
                //検診事業一覧(検査方法あり)
                var cdList = new List<string>();
                //検診事業略称一覧(検査方法なし)
                var nmList1 = new List<object[]>();
                //予約分類名一覧
                var nmList2 = new List<object[]>();
                //関連データ取得
                AWSH00401G.Service.GetData(db, req.nendo, out keyList, out cdList, out nmList1, out nmList2, dto.jigyocd);

                //定員チェック必要がある検査方法
                var vmList = req.kekkalist.Select(e => new AWSH00403D.MoneyKeyBase3VM()
                {
                    jigyocd = e.jigyocd,
                    kensahohocd = cdList.Contains(e.jigyocd) ? DaSelectorService.GetCd(e.kensahohocdnm) : AWSH00301G.Service.KENSAHOHOCD,
                    nitteino = CInt(req.nitteino)
                }).ToList();

                //関係性一覧(検診事業、予約分類、検査方法)
                var keyList2 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.検査方法コード関係).
                                Where(e => vmList.Exists(x => x.jigyocd == CStr(e[0]) && x.kensahohocd == CStr(e[2]))).ToList();
                //検診予約列一覧(名称)
                var keyList1 = AWSH00401G.Service.GetKeyList(keyList, cdList, nmList1, nmList2, Enum予約関係分類.名称関係).
                                Where(e => keyList2.Exists(x => CStr(x[0]) == CStr(e[0]) && CStr(x[1]) == CStr(e[1]))).ToList();

                //-------------------------------------------------------------
                //２.条件設定
                //-------------------------------------------------------------
                //固定の検索条件(予約者一覧画面：予約情報)
                var fixedCondition = Converter.GetFixedCondition(req.nendo, req.nitteino);
                //詳細の検索条件(なし)
                var conditon = CmSearchUtil.GetSearchJyoken(db, null, null, fixedCondition, 1, 1);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果(予約者一覧画面：予約情報)
                var result = DaFreeQuery.GetKensinYoyakuPersonQuery2(db, req.nendo, keyList1, keyList2, conditon);
                //結果一覧
                var pageData = result.Data;

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //待機変更必要検診事業一覧
                res.kekkalist = Wraper.GetCheckVMList(pageData.Rows[0], keyList1);
                //全体定員オーバーフラグ
                res.overflg = Wraper.GetOverflg(pageData.Rows[0], req.editkbn);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //悲観排他
                db.tt_shkensinyoyakukibosya.SELECT.WaitRecord(req.nendo, req.nitteino);

                //健（検）診予約希望者テーブル
                var dto = new tt_shkensinyoyakukibosyaDto();
                if (req.editkbn == Enum編集区分.変更)
                {
                    //健（検）診予約希望者テーブル
                    dto = db.tt_shkensinyoyakukibosya.GetDtoByKey(req.nendo, req.nitteino, req.atenano);
                }
                //予約番号
                int yoyakuno = CInt(dto.yoyakuno);
                if (req.editkbn == Enum編集区分.新規)
                {
                    //予約番号(悲観排他で取得)
                    yoyakuno = db.tt_shkensinyoyakukibosya.SELECT.WHERE.ByKey(req.nendo, req.nitteino).
                                GetMax<int>(nameof(tt_shkensinyoyakukibosyaDto.yoyakuno)) + 1;
                }
                //日程番号一覧(編集中日程を除く)
                var keyList = req.kekkalist.Where(e => e.nitteino != req.nitteino).GroupBy(e => e.nitteino).Select(e => e.First()).
                                Select(e => new object[] { req.nendo, e.nitteino!, req.atenano }).ToList();
                //健（検）診予約希望者テーブル
                var dtl1 = db.tt_shkensinyoyakukibosya.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //検診事業コードリスト(検査方法あり)
                var cdList = db.tm_shkensinjigyo.SELECT.GetDtoList().
                            Where(e => e.kensahoho_setflg).ToList().
                            Select(e => e.jigyocd).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //健（検）診予約希望者テーブル
                dto = Converter.GetDto(dto, req.biko, req.nendo, req.nitteino, req.atenano, yoyakuno);
                dtl1.Add(dto);
                //健（検）診予約希望者詳細テーブル
                var dtl2 = Converter.GetDtl(req.nendo, req.atenano, req.kekkalist, cdList);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //健（検）診予約希望者テーブル
                db.tt_shkensinyoyakukibosya.UPDATE.WHERE.
                    ByFilter(@$"{nameof(tt_shkensinyoyakukibosyaDto.nendo)} = @{nameof(tt_shkensinyoyakukibosyaDto.nendo)} and 
                                {nameof(tt_shkensinyoyakukibosyaDto.atenano)} = @{nameof(tt_shkensinyoyakukibosyaDto.atenano)}",
                                req.nendo, req.atenano).Execute(dtl1);
                //健（検）診予約希望者詳細テーブル
                db.tt_shkensinkibosyasyosai.UPDATE.WHERE.
                    ByFilter(@$"{nameof(tt_shkensinkibosyasyosaiDto.nendo)} = @{nameof(tt_shkensinkibosyasyosaiDto.nendo)} and 
                                {nameof(tt_shkensinkibosyasyosaiDto.atenano)} = @{nameof(tt_shkensinkibosyasyosaiDto.atenano)}",
                                req.nendo, req.atenano).Execute(dtl2);

                //宛名ログ記録
                var kbn = EnumAtenaActionType.更新;
                if (req.editkbn == Enum編集区分.新規) kbn = EnumAtenaActionType.追加;
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, kbn);

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.DB更新処理
                //-------------------------------------------------------------
                //健（検）診予約希望者テーブル
                db.tt_shkensinyoyakukibosya.DeleteByKey(req.nendo, req.nitteino, req.atenano, req.upddttm);
                //健（検）診予約希望者詳細テーブル
                db.tt_shkensinkibosyasyosai.DELETE.WHERE.ByKey(req.nendo, req.nitteino, req.atenano).Execute();

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.削除);

                //正常返し
                return res;
            });
        }
    }
}