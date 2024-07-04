// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 基幹系他システム情報照会
// 　　　　　　サービス処理
// 作成日　　: 2023.10.02
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaCodeConst.名称マスタ.標準版;

namespace BCC.Affect.Service.AWKK00101G
{
    [DisplayName("基幹系他システム情報照会")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00101G = "AWKK00101G";

        //検索処理(詳細画面：税額控除タブ)
        private const string PROC_NAME = "sp_awkk00101g_01";

        [DisplayName("検索処理(一覧画面)")]
        public SearchPersonListResponse SearchPersonList(Common.PersonSearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchPersonListResponse();
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
                var conditon = CmSearchUtil.GetSearchJyoken(db, AWKK00101G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
                //連絡先の事業コード
                var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, AWKK00101G);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果
                var result = DaFreeQuery.GetAtenaQuery(db, renraku_jigyocd, conditon, req.orderby, true);
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
            });
        }

        [DisplayName("検索処理(世帯一覧)")]
        public SearchSetaiListResponse SearchSetaiList(CommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchSetaiListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人基本情報取得
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //世帯成員一覧取得
                var dtl = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.setaino), dto.setaino).GetDtoList().
                            OrderBy(e => CmLogicUtil.CIntJuminjotaiSort(e.juminjotai)). //住民状態
                            ThenBy(e => e.jutokbn).                                     //住登区分
                            ThenBy(e => e.zokucd1).                                     //続柄コード1
                            ThenBy(e => e.zokucd2).                                     //続柄コード2
                            ThenBy(e => e.zokucd3).                                     //続柄コード3
                            ThenBy(e => e.zokucd4).                                     //続柄コード4
                            ThenBy(e => e.bymd).                                        //生年月日
                            ThenBy(e => e.atenano).                                     //宛名番号
                            ToList();

                //世帯主の宛名番号取得
                var atenano = CmLogicUtil.GetSetainushi(dtl);

                //世帯主基本情報取得(ヘッダー部)
                var setaiDto = db.tt_afatena.GetDtoByKey(atenano);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;
                //地区区分ラベルリスト
                var tikuList = DaNameService.GetNameList(db, EnumNmKbn.地区区分).Where(e => CBool(e.hanyokbn1) == true).OrderBy(e => CInt(e.nmcd)).ToList();

                //地区リスト
                var keyList = tikuList.Select(e => CInt(e.nmcd)).ToList();
                //地区情報マスタ
                var tikuDtl = db.tm_aftiku.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //世帯主情報
                res.headerinfo = Wraper.GetVM(db, setaiDto, tikuList, tikuDtl, adrsFlg);

                //世帯成員一覧
                res.kekkalist = Wraper.GetVMList(db, dtl, alertviewflg);

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面)")]
        public InitDetailResponse InitDetail(CommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人基本情報取得
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

                //権限関連
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWKK00101G);
                //個人番号操作フラグ
                var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.headerinfo = Wraper.GetHeaderVM(db, dto, alertviewflg);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面：住基タブ)")]
        public SearchJuminDetailResponse SearchJuminDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchJuminDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得(全履歴)
                //-------------------------------------------------------------
                //【住民基本台帳】住民情報履歴テーブル
                var dtl = db.tt_afjumin_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                            OrderByDescending(e => e.saisinflg).        //最新フラグ
                            ThenByDescending(e => e.kojinrirekino).     //個人履歴番号
                            ThenByDescending(e => e.kojinrireki_edano). //個人履歴番号_枝番号
                            ToList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //ページャー設定
                res.rirekitotal = dtl.Count;
                if (dtl.Count == 0)
                {
                    res.rirekinum = 0;
                    //正常返し
                    return res;
                }
                else if (req.rirekinum > dtl.Count)
                {
                    res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ取得(表示履歴)
                //-------------------------------------------------------------
                //【住民基本台帳】住民情報履歴テーブル
                var dto = dtl[req.rirekinum - 1];

                //世帯成員一覧取得
                var dtl2 = db.tt_afatena.SELECT.WHERE.ByItem(nameof(tt_afatenaDto.setaino), dto.setaino).GetDtoList();

                //世帯主の宛名番号取得
                var atenano = dtl2.Find(x => x.zokucd1 == 続柄._02 || x.zokucd2 == 続柄._02 || x.zokucd3 == 続柄._02 || x.zokucd4 == 続柄._02)?.atenano ?? string.Empty;

                //世帯主基本情報取得(ヘッダー部)
                var senusinm = db.tt_afatena.GetDtoByKey(atenano).simei_yusen;

                //地区区分ラベルリスト
                var tikuList = DaNameService.GetNameList(db, EnumNmKbn.地区区分).Where(e => CBool(e.hanyokbn1) == true).OrderBy(e => CInt(e.nmcd)).ToList();

                //地区リスト
                var keyList = tikuList.Select(e => CInt(e.nmcd)).ToList();
                //地区情報マスタ
                var tikuDtl = db.tm_aftiku.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //権限関連
                var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWKK00101G);

                //暗号化
                var publickey = string.Empty;   //公開キー(暗号化)
                var privatekey = string.Empty;  //秘密キー(復号化)
                //キー取得
                DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

                //-------------------------------------------------------------
                //４.データ加工処理
                //-------------------------------------------------------------
                //住民情報
                res.detailinfo = Wraper.GetVM(db, dto, tikuList, tikuDtl, senusinm, personalflg, publickey);

                //履歴番号
                res.rirekinum = req.rirekinum;

                //rsaキー
                res.rsaprivatekey = privatekey;

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面：課税・納税義務者タブ_課税)")]
        public SearchKaZeiDetailResponse SearchKaZeiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKaZeiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：課税・納税義務者タブ_納税)")]
        public SearchNoZeiDetailResponse SearchNoZeiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchNoZeiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：税額控除タブ)")]
        public SearchKojoDetailResponse SearchKojoDetail(SearchKojoDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKojoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：税額控除タブ_明細)")]
        public SearchKojoDetailRowsResponse SearchKojoDetailRows(SearchKojoDetailRowsRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKojoDetailRowsResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：国保タブ)")]
        public SearchKokuhoDetailResponse SearchKokuhoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKokuhoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：後期タブ)")]
        public SearchKokiDetailResponse SearchKokiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKokiDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：生保タブ)")]
        public SearchSeihoDetailResponse SearchSeihoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchSeihoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：介護タブ)")]
        public SearchKaigoDetailResponse SearchKaigoDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchKaigoDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面：福祉タブ)")]
        public SearchSyogaiDetailResponse SearchSyogaiDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchSyogaiDetailResponse(db, req);
            });
        }

        /// <summary>
        /// 検索処理(詳細画面：課税・納税義務者タブ_課税)
        /// </summary>
        public SearchKaZeiDetailResponse GetSearchKaZeiDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchKaZeiDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【個人住民税】個人住民税課税情報履歴テーブル
            var dtl = db.tt_afkojinzeikazei_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).        //最新フラグ
                        ThenByDescending(e => e.kazeinendo).        //課税年度
                        ThenByDescending(e => e.kazeirirekino).     //課税情報履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【個人住民税】個人住民税課税情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //課税情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：課税・納税義務者タブ_納税)
        /// </summary>
        public SearchNoZeiDetailResponse GetSearchNoZeiDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchNoZeiDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【個人住民税】納税義務者情報履歴テーブル
            var dtl = db.tt_afkojinzeigimusya_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).        //最新フラグ
                        ThenByDescending(e => e.kazeinendo).        //課税年度
                        ThenByDescending(e => e.kojinrirekino).     //個人履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【個人住民税】納税義務者情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];
            //市区町村マスタ
            var dtl2 = db.tm_afsikutyoson.SELECT.GetDtoList();

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //納税義務者情報
            res.detailinfo = Wraper.GetVM(db, dto, dtl2);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：税額控除タブ)
        /// </summary>
        public SearchKojoDetailResponse GetSearchKojoDetailResponse(DaDbContext db, SearchKojoDetailRequest req)
        {
            var res = new SearchKojoDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【個人住民税】個人住民税税額控除情報履歴テーブル：履歴単位
            var dtl = db.tt_afkojinzeikojo_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).        //最新フラグ
                        ThenByDescending(e => e.kazeinendo).        //課税年度
                        ThenByDescending(e => e.kojorirekino).      //税額控除情報履歴番号
                        ThenByDescending(e => e.upddttm).           //更新日時
                        GroupBy(e => new { e.kazeinendo, e.kojorirekino }).
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【個人住民税】個人住民税税額控除情報履歴テーブル
            List<tt_afkojinzeikojo_rekiDto> dtl2 = dtl[req.rirekinum - 1].ToList();

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //控除情報(ヘッダー)
            res.detailheaderinfo = Wraper.GetVM(db, dtl2[0]);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //-------------------------------------------------------------
            //５.その他処理(明細データ取得)
            //-------------------------------------------------------------
            SetRes(res, db, req.atenano, dtl2[0].kazeinendo, dtl2[0].kojorirekino, req.pagenum, req.pagesize, req.orderby);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：税額控除タブ_明細)
        /// </summary>
        public SearchKojoDetailRowsResponse GetSearchKojoDetailRowsResponse(DaDbContext db, SearchKojoDetailRowsRequest req)
        {
            var res = new SearchKojoDetailResponse();
            //明細データ取得
            SetRes(res, db, req.atenano, req.kazeinendo, req.kojorirekino, req.pagenum, req.pagesize, req.orderby);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：国保タブ)
        /// </summary>
        public SearchKokuhoDetailResponse GetSearchKokuhoDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchKokuhoDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【国民健康保険】国保資格情報履歴テーブル
            var dtl = db.tt_afkokuho_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).            //最新フラグ
                        ThenByDescending(e => e.hihokensyarirekino).    //被保険者履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【国民健康保険】国保資格情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //国保情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：後期タブ)
        /// </summary>
        public SearchKokiDetailResponse GetSearchKokiDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchKokiDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【後期高齢者医療】被保険者情報履歴テーブル
            var dtl = db.tt_afkokihoken_reki.SELECT.WHERE.ByItem(nameof(tt_afkokihoken_rekiDto.atenano), req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).                //最新フラグ
                        ThenByDescending(e => e.hiho_sikakusyutokuymd).     //被保険者資格取得年月日
                        ThenByDescending(e => e.hiho_sikakusosituymd).      //被保険者資格喪失年月日
                        ThenBy(e => e.hihokensyano).                        //被保険者番号
                        ThenByDescending(e => e.rirekino).                  //履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【後期高齢者医療】被保険者情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //後期情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：生保タブ)
        /// </summary>
        public SearchSeihoDetailResponse GetSearchSeihoDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchSeihoDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【生活保護】生活保護受給情報履歴テーブル
            var dtl = db.tt_afseiho_reki.SELECT.WHERE.ByItem(nameof(tt_afseiho_rekiDto.atenano), req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).        //最新フラグ
                        ThenByDescending(e => e.sinseirirekino).    //申請履歴番号
                        ThenBy(e => e.fukusijimusyocd).             //福祉事務所コード
                        ThenByDescending(e => e.ketteirirekino).    //決定履歴番号
                        ThenByDescending(e => e.caseno).            //ケース番号
                        ThenBy(e => e.inno).                        //員番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【生活保護】生活保護受給情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //生保情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：介護タブ)
        /// </summary>
        public SearchKaigoDetailResponse GetSearchKaigoDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchKaigoDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【介護保険】被保険者情報履歴テーブル
            var dtl = db.tt_afkaigo_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).        //最新フラグ
                        ThenByDescending(e => e.sikakusyutokuymd).  //資格取得日
                        ThenByDescending(e => e.sikakusosituymd).   //資格喪失日
                        ThenBy(e => e.kaigohokensyano).             //介護保険者番号
                        ThenBy(e => e.hihokensyano).                //被保険者番号
                        ThenByDescending(e => e.sikakurirekino).    //資格履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【介護保険】被保険者情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //介護情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面：福祉タブ)
        /// </summary>
        public SearchSyogaiDetailResponse GetSearchSyogaiDetailResponse(DaDbContext db, SearchCommonRequest req)
        {
            var res = new SearchSyogaiDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得(全履歴)
            //-------------------------------------------------------------
            //【障害者福祉】身体障害者手帳等情報履歴テーブル
            var dtl = db.tt_afsyogaitetyo_reki.SELECT.WHERE.ByKey(req.atenano).GetDtoList().
                        OrderByDescending(e => e.saisinflg).    //最新フラグ
                        ThenByDescending(e => e.rirekino).      //履歴番号
                        ToList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ページャー設定
            res.rirekitotal = dtl.Count;
            if (dtl.Count == 0)
            {
                res.rirekinum = 0;
                //正常返し
                return res;
            }
            else if (req.rirekinum > dtl.Count)
            {
                res.SetServiceError(DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "履歴", "参照"));
                //異常返し
                return res;
            }

            //-------------------------------------------------------------
            //３.データ取得(表示履歴)
            //-------------------------------------------------------------
            //【障害者福祉】身体障害者手帳等情報履歴テーブル
            var dto = dtl[req.rirekinum - 1];

            //-------------------------------------------------------------
            //４.データ加工処理
            //-------------------------------------------------------------
            //障害情報
            res.detailinfo = Wraper.GetVM(db, dto);

            //履歴番号
            res.rirekinum = req.rirekinum;

            //正常返し
            return res;
        }

        /// <summary>
        /// 税額控除明細取得
        /// </summary>
        private void SetRes(SearchKojoDetailRowsResponse res, DaDbContext db, string atenano, int kazeinendo, int kojorirekino, int pagenum, int pagesize, int orderby)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //パラメータ取得
            var param = Converter.GetParameters(atenano, kazeinendo, kojorirekino);

            //控除情報一覧取得(明細部)
            var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, pagenum, pagesize, orderby);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //控除情報(明細)
            res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

            //ページャー設定
            res.SetPageInfo(pageList.TotalCount, pagesize);
        }
    }
}