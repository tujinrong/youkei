// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: フォロー管理
// 　　　　　　サービス処理
// 作成日　　: 2023.11.24
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaCodeConst.コントロールマスタ.システム;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00401G
{
    [DisplayName("フォロー管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00401G = "AWKK00401G";

        //フォロー管理検索(内容画面)
        private const string PROC_NAME1 = "sp_awkk00401g_01";

        //フォロー管理検索(結果画面)
        private const string PROC_NAME2 = "sp_awkk00401g_02";

        //枝番新規利用
        private static int sinkiEdano = 0;

        //フォロー内容枝番新規利用
        private static int sinkiFollownaiyoedano = 0;

        //フォロー情報(詳細画面)
        private static FollowDetailVM followdetailvm = new FollowDetailVM();

        [DisplayName("検索処理(管理画面)")]
        public SearchFollowListResponse SearchFollowList(Common.PersonSearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchFollowListResponse();
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
                var conditon = CmSearchUtil.GetSearchJyoken(db, AWKK00401G, req.syosailist, fixedCondition, req.pagenum, req.pagesize);
                //連絡先の事業コード
                var renraku_jigyocd = CmLogicUtil.GetRenrakujigyocd(db, AWKK00401G);

                //-------------------------------------------------------------
                //３.データ取得
                //-------------------------------------------------------------
                //検索結果
                var result = DaFreeQuery.GetFollowQuery(db, renraku_jigyocd, conditon, req.orderby, true);
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

        [DisplayName("検索処理(内容画面)")]
        public SearchFollowNaiyoListResponse SearchFollowNaiyoList(SearchFollowNaiyoListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchFollowNaiyoListResponse(db, req);
            });
        }

        [DisplayName("新規処理(結果画面)")]
        public InitFollowNaiyoResponse InitFollowNaiyo(InitFollowNaiyoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetInitFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("検索処理(結果画面)")]
        public SearchFollowNaiyoResponse SearchFollowNaiyo(SearchFollowNaiyoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("新規処理(詳細画面)")]
        public InitFollowDetailResponse InitFollowDetail(InitFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetInitFollowDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchFollowDetailResponse SearchFollowDetail(SearchFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchFollowDetailResponse(db, req);
            });
        }

        [DisplayName("前回結果情報セット処理(詳細画面)")]
        public FollowDetailPreKekkaResponse SearchFollowDetailPreKekka(SearchFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchFollowDetailPreKekkaResponse(db, req);
            });
        }

        [DisplayName("予定情報セット処理(詳細画面)")]
        public FollowDetailKekkaResponse SearchFollowDetailKekka(SearchFollowDetailPreKekkaRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetSearchFollowDetailKekkaResponse(db, req);
            });
        }

        [DisplayName("保存処理(結果画面)")]
        public DaResponseBase SaveFollowNaiyo(SaveFollowNaiyoRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                return SaveFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("保存処理(詳細画面)")]
        public DaResponseBase SaveFollowDetail(SaveFollowDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                return SaveFollowDetailResponse(db, req);
            });
        }

        [DisplayName("削除処理(結果画面)")]
        public DaResponseBase DeleteFollowNaiyo(DeleteFollowNaiyoRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                return DeleteFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("削除処理(詳細画面)")]
        public DaResponseBase DeleteFollowDetail(DeleteFollowDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                return DeleteFollowDetailResponse(db, req);
            });
        }

        /// <summary>
        /// 内容画面ドロップダウンリスト初期化
        /// </summary>
        private void GetFollowContentInitList(DaDbContext db, SearchFollowNaiyoListResponse res)
        {
            //ドロップダウンリスト(把握経路)
            res.haakukeiroList = DaNameService.GetSelectorList(db, EnumNmKbn.把握経路_フォロー状況情報, Enum名称区分.名称);
            //ドロップダウンリスト(把握事業)
            res.haakujigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, true, EnumToStr(EnumHanyoKbn.フォロー把握事業コード));
            //ドロップダウンリスト(フォロー状況)
            res.followstatusList = DaNameService.GetSelectorList(db, EnumNmKbn.フォロー状況, Enum名称区分.名称);
            //ドロップダウンリスト(フォロー事業)
            res.followjigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, true, EnumToStr(EnumHanyoKbn.フォロー事業コード));
        }

        /// <summary>
        /// 結果画面ドロップダウンリスト初期化
        /// </summary>
        private void GetFollowKekkaInitList(DaDbContext db, InitFollowNaiyoResponse res, List<string> keyList)
        {
            //ドロップダウンリスト(把握経路)
            res.haakukeiroList = DaNameService.GetSelectorList(db, EnumNmKbn.把握経路_フォロー状況情報, Enum名称区分.名称);
            //ドロップダウンリスト(把握事業)
            res.haakujigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, true, EnumToStr(EnumHanyoKbn.フォロー把握事業コード));
            //ドロップダウンリスト(フォロー状況)
            res.followstatusList = DaNameService.GetSelectorList(db, EnumNmKbn.フォロー状況, Enum名称区分.名称);
            //ドロップダウンリスト(フォロー事業)
            res.followjigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, true, EnumToStr(EnumHanyoKbn.フォロー事業コード));
            //ドロップダウンリスト(担当)
            res.followstaffidList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, true, string.Join(DaStrPool.COMMA, keyList));
        }

        /// <summary>
        /// 詳細画面ドロップダウンリスト初期化
        /// </summary>
        private void GetFollowDetailInitList(DaDbContext db, InitFollowDetailResponse res, List<string> keyList)
        {
            //ドロップダウンリスト(フォロー事業)
            res.followjigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.フォロー事業コード));
            //ドロップダウンリスト(フォロー予定情報  フォロー方法)
            res.followhoho_yoteiList = DaNameService.GetSelectorList(db, EnumNmKbn.フォロー方法, Enum名称区分.名称);

            //ドロップダウンリスト(フォロー予定情報  フォロー会場)
            res.followkaijocd_yoteiList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ);
            //ドロップダウンリスト(フォロー予定情報  フォロー担当者)
            res.followstaffid_yoteiList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, false, string.Join(DaStrPool.COMMA, keyList));
            //ドロップダウンリスト(フォロー結果情報  フォロー方法)
            res.followhohoList = DaNameService.GetSelectorList(db, EnumNmKbn.フォロー方法, Enum名称区分.名称);

            //ドロップダウンリスト(フォロー結果情報  フォロー会場)
            res.followkaijocdList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.会場情報マスタ);
            //ドロップダウンリスト(フォロー結果情報  フォロー担当者)
            res.followstaffidList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.事業従事者担当者情報マスタ, false, string.Join(DaStrPool.COMMA, keyList));
        }

        /// <summary>
        /// 検索処理(内容画面)
        /// </summary>
        public SearchFollowNaiyoListResponse GetSearchFollowNaiyoListResponse(DaDbContext db, SearchFollowNaiyoListRequest req)
        {
            var res = new SearchFollowNaiyoListResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var parameters = Converter.GetParameters(req);

            //一覧データ取得
            var dt = DaDbUtil.GetProcedureData(db, PROC_NAME1, parameters);

            //住民情報取得(ヘッダー部)
            var dto = db.tt_afatena.GetDtoByKey(req.atenano);

            //警告参照フラグ取得
            var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);

            //権限関連
            var personalflg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWKK00401G);
            //個人番号操作フラグ
            var pFlg = personalflg && !string.IsNullOrEmpty(dto.personalno);
            //住所フラグ
            var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._03).BoolValue1;

            //暗号化
            var publickey = string.Empty;   //公開キー(暗号化)
            var privatekey = string.Empty;  //秘密キー(復号化)
            //キー取得
            DaEncryptUtil.GeneratePemRsaKeyPair(out publickey, out privatekey);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //ドロップダウンリスト初期化
            GetFollowContentInitList(db, res);

            //住民情報
            res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.GamenHeaderBase2VM(), dto, pFlg, publickey, alertviewflg, adrsFlg);

            //内容情報一覧
            res.kekkalist = Wraper.GetFollowContentVMList(db, dt.Rows);

            //rsaキー
            res.rsaprivatekey = privatekey;

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, pFlg, EnumAtenaActionType.検索);

            //正常返し
            return res;
        }

        /// <summary>
        /// 新規処理(結果画面)
        /// </summary>
        public InitFollowNaiyoResponse GetInitFollowNaiyoResponse(DaDbContext db, InitFollowNaiyoRequest req)
        {
            var res = new InitFollowNaiyoResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //支所一覧
            var dtl = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);
            //表示フラグ(登録支所)
            res.showflg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._05).BoolValue1;

            //新規の場合、ログインユーザーの登録支所を取得
            res.regsisyo = res.showflg && !string.IsNullOrEmpty(req.regsisyo)
               ? DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, Enum名称区分.名称, req.regsisyo)
               : string.Empty;

            sinkiFollownaiyoedano = db.tt_kkfollownaiyo.SELECT.WHERE.ByKey(req.atenano).GetMax<int>(nameof(tt_kkfollownaiyoDto.follownaiyoedano)) + 1;
            res.follownaiyoedano = sinkiFollownaiyoedano;

            //登録事業(表示範囲)
            var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, req.kinoid!, Enum事業コードパターン.DB設定, null, false);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //ドロップダウンリスト初期化
            GetFollowKekkaInitList(db, res, keyList);

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(結果画面)
        /// </summary>
        public SearchFollowNaiyoResponse GetSearchFollowNaiyoResponse(DaDbContext db, SearchFollowNaiyoRequest req)
        {
            var res = new SearchFollowNaiyoResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            var parameters = Converter.GetParameters(req);

            //一覧データ取得
            var dt = DaDbUtil.GetProcedureData(db, PROC_NAME2, parameters);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            var dto = db.tt_kkfollownaiyo.GetDtoByKey(req.atenano, req.follownaiyoedano);
            var dtl = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano, req.follownaiyoedano).GetDtoList();
            var dto2 = dtl.Find(e => e.edano == dtl.Max(e => e.edano));

            //フォロー内容情報
            res.followkekkavm = Wraper.GetFollowKekkaVM(db, dto, dto2, sisyoList);

            if (dto is not null)
            {
                //表示フラグ(登録支所)
                res.showflg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, config情報._05).BoolValue1;

                //編集の場合、フォロー内容テーブルの登録支所を取得
                res.regsisyo = res.showflg && !string.IsNullOrEmpty(dto.regsisyo)
                   ? DaHanyoService.GetName(db, EnumHanyoKbn.部署_支所, Enum名称区分.名称, dto.regsisyo)
                   : string.Empty;
            }

            //フォロー管理情報一覧
            res.kekkalist = Wraper.GetFollowKekkaDetailVMList(db, dt.Rows);

            //正常返し
            return res;
        }

        /// <summary>
        /// 新規処理(詳細画面)
        /// </summary>
        public InitFollowDetailResponse GetInitFollowDetailResponse(DaDbContext db, InitFollowDetailRequest req)
        {
            var res = new InitFollowDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            sinkiEdano = 0;
            followdetailvm = new FollowDetailVM();

            //コピーの場合
            if (req.editkbn == Enum編集区分.新規 || req.copyflg == true)
            {
                var edanoyoteisinki = db.tt_kkfollowyotei.SELECT.WHERE.ByKey(req.atenano,
                       req.follownaiyoedano).GetMax<int>(nameof(tt_kkfollowyoteiDto.edano)) + 1;
                var edanokekkasinki = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano,
                       req.follownaiyoedano).GetMax<int>(nameof(tt_kkfollowkekkaDto.edano)) + 1;
                sinkiEdano = edanoyoteisinki > edanokekkasinki ? edanoyoteisinki : edanokekkasinki;
            }

            var dto = db.tt_kkfollownaiyo.GetDtoByKey(req.atenano, req.follownaiyoedano) ?? new tt_kkfollownaiyoDto();                //フォロー内容情報

            //支所一覧
            var dtl = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

            //登録事業(表示範囲)
            var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, req.kinoid!, Enum事業コードパターン.DB設定, null, false);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //ドロップダウンリスト初期化
            GetFollowDetailInitList(db, res, keyList);

            //「前回結果情報セット」押す可能フラグ
            res.zenkaisetflg = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano, req.follownaiyoedano, sinkiEdano - 1).Exists();

            //フォロー内容情報
            res.followdetailvm = Wraper.GetFollowDetailNaiyoVM(db, dto, sinkiEdano);
            followdetailvm = res.followdetailvm;

            //正常返し
            return res;
        }

        /// <summary>
        /// 検索処理(詳細画面)
        /// </summary>
        public SearchFollowDetailResponse GetSearchFollowDetailResponse(DaDbContext db, SearchFollowDetailRequest req)
        {
            var res = new SearchFollowDetailResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            var parameters = Converter.GetParameters(req);

            //更新可能支所一覧
            var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

            //支所一覧
            var dtl = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

            var dto = db.tt_kkfollownaiyo.GetDtoByKey(req.atenano, req.follownaiyoedano) ?? new tt_kkfollownaiyoDto();                //フォロー内容情報
            var dto2 = db.tt_kkfollowyotei.GetDtoByKey(req.atenano, req.follownaiyoedano, req.edano) ?? new tt_kkfollowyoteiDto();    //フォロー予定情報
            var dto3 = db.tt_kkfollowkekka.GetDtoByKey(req.atenano, req.follownaiyoedano, req.edano) ?? new tt_kkfollowkekkaDto();    //フォロー結果情報

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //フォロー管理詳細画面
            res.followdetailvm = Wraper.GetFollowDetailVM(db, dto, dto2, dto3, sisyoList, dtl, sinkiEdano, followdetailvm);
            followdetailvm = res.followdetailvm;

            //「前回結果情報セット」押す可能フラグ
            res.zenkaisetflg = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano, req.follownaiyoedano, req.edano -1).Exists();

            //正常返し
            return res;
        }

        /// <summary>
        /// 前回結果情報セット処理(詳細画面)
        /// </summary>
        public FollowDetailPreKekkaResponse GetSearchFollowDetailPreKekkaResponse(DaDbContext db, SearchFollowDetailRequest req)
        {
            var res = new FollowDetailPreKekkaResponse();
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //前回（最大枝番）のフォロー結果情報
            var maxedano = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano,
                       req.follownaiyoedano).GetMax<int>(nameof(tt_kkfollowkekkaDto.edano));
            var dto = new tt_kkfollowkekkaDto();
            //編集の場合
            if (req.edano <= maxedano)
            {
                dto = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano, req.follownaiyoedano, req.edano - 1).GetDto();  //フォロー結果情報
            }
            else
            {
                //新規の場合
                dto = db.tt_kkfollowkekka.GetDtoByKey(req.atenano, req.follownaiyoedano, maxedano);  //フォロー結果情報
            }

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            //フォロー管理詳細画面
            res.yoteiinputflg = true;                                           //フォロー予定情報 フォロー予定入力フラグ
            res.followhoho_yotei = dto.followhoho;                              //フォロー予定情報 フォロー方法
            res.followyoteiymd = dto.followjissiymd;                            //フォロー予定情報  予定日
            res.followtm_yotei = dto.followtm;                                  //フォロー予定情報  時間
            res.followkaijocd_yotei = dto.followkaijocd;                        //フォロー予定情報  会場
            res.followstaffid_yotei = dto.followstaffid;                        //フォロー予定情報  担当者
            var dtoafstaff = db.tm_afstaff.GetDtoByKey(CStr(dto.followstaffid));
            res.followstaffid_yoteinm = dtoafstaff?.staffsimei;                 //フォロー予定情報  担当者名称

            //「前回結果情報セット」押す可能フラグ
            res.zenkaisetflg = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.atenano, req.follownaiyoedano, req.edano - 1).Exists();

            //正常返し
            return res;
        }

        /// <summary>
        /// 予定情報セット処理(詳細画面)
        /// </summary>
        public FollowDetailKekkaResponse GetSearchFollowDetailKekkaResponse(DaDbContext db, SearchFollowDetailPreKekkaRequest req)
        {
            var res = new FollowDetailKekkaResponse();
            //-------------------------------------------------------------
            //１.データ加工処理
            //-------------------------------------------------------------
            //フォロー管理詳細画面
            res.kekkadetailinfovm = Wraper.GetFollowDetailKekkaVM(req.detailyoteiinfovm, followdetailvm);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(結果画面)
        /// </summary>
        public DaResponseBase SaveFollowNaiyoResponse(DaDbContext db, SaveFollowNaiyoRequest req)
        {
            var res = new DaResponseBase();
            //-------------------------------------------------------------
            //１.チェック処理(事前)
            //-------------------------------------------------------------
            var flg = db.tt_kkfollownaiyo.SELECT.WHERE.ByKey(req.rowfollowkekka.atenano, req.rowfollowkekka.follownaiyoedano).Exists();
            if (req.editkbn == Enum編集区分.新規 && flg)
            {
                res.SetServiceError(EnumMessage.E002003, "フォロー内容枝番");
                //異常返す
                return res;
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            var dto = new tt_kkfollownaiyoDto();     //フォロー内容情報
            var dto2 = new tt_kkfollowyoteiDto();    //フォロー予定情報
                                                     //更新の場合
            if (req.editkbn == Enum編集区分.変更)
            {
                dto = db.tt_kkfollownaiyo.GetDtoByKey(req.rowfollowkekka.atenano, req.rowfollowkekka.follownaiyoedano);
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //フォロー内容情報
            dto = Converter.GetDto(dto, req.rowfollowkekka);

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                db.tt_kkfollownaiyo.INSERT.SetDiffLogParameter(null).Execute(dto);   //フォロー内容情報テーブル
            }
            //更新の場合
            else
            {
                db.tt_kkfollownaiyo.UpdateDto(dto, req.rowfollowkekka.upddttm!.Value);   //フォロー内容情報テーブル
            }

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.rowfollowkekka.atenano, false, EnumAtenaActionType.更新);

            //正常返し
            return res;
        }

        /// <summary>
        /// 保存処理(詳細画面)
        /// </summary>
        public DaResponseBase SaveFollowDetailResponse(DaDbContext db, SaveFollowDetailRequest req)
        {
            var res = new DaResponseBase();
            //-------------------------------------------------------------
            //１.チェック処理(事前)
            //-------------------------------------------------------------
            var yoteiinputflg = req.yoteiinputflg;          //フォロー予定入力フラグ
            var kekkainputflg = req.kekkainputflg;          //フォロー結果入力フラグ

            var flg_yotei = db.tt_kkfollowyotei.SELECT.WHERE.ByKey(req.followdetailvm.atenano,
                                                         req.followdetailvm.follownaiyoedano,
                                                         req.followdetailvm.sinkiEdano > 0 ?
                                                         req.followdetailvm.sinkiEdano : req.followdetailvm.edano).Exists();
            var flg_kekka = db.tt_kkfollowkekka.SELECT.WHERE.ByKey(req.followdetailvm.atenano,
                                                             req.followdetailvm.follownaiyoedano,
                                                             req.followdetailvm.sinkiEdano > 0 ?
                                                             req.followdetailvm.sinkiEdano : req.followdetailvm.edano).Exists();


            if (req.editkbn == Enum編集区分.新規 && ((flg_yotei && yoteiinputflg) || (flg_kekka && kekkainputflg)))
            {
                res.SetServiceError(EnumMessage.E002003, "枝番");
                //異常返す
                return res;
            }

            //-------------------------------------------------------------
            //２.データ取得
            //-------------------------------------------------------------
            var dto = db.tt_kkfollownaiyo.GetDtoByKey(req.followdetailvm.atenano, req.followdetailvm.follownaiyoedano) ?? new tt_kkfollownaiyoDto();     //フォロー内容情報
            var dto2 = new tt_kkfollowyoteiDto();    //フォロー予定情報
            var dto3 = new tt_kkfollowkekkaDto();    //フォロー結果情報

            if (req.editkbn == Enum編集区分.変更)
            {
                if (yoteiinputflg)
                {
                    dto2 = db.tt_kkfollowyotei.GetDtoByKey(req.followdetailvm.atenano, req.followdetailvm.follownaiyoedano, req.followdetailvm.edano);
                    //存在チェック
                    if (!CmCheckService.CheckDeleted(res, dto2, EnumMessage.E004006, "検索対象", "フォロー予定情報テーブル")) return res;   //異常返し
                }

                if (kekkainputflg)
                {
                    dto3 = db.tt_kkfollowkekka.GetDtoByKey(req.followdetailvm.atenano, req.followdetailvm.follownaiyoedano, req.followdetailvm.edano);
                    //存在チェック
                    if (!CmCheckService.CheckDeleted(res, dto3, EnumMessage.E004006, "検索対象", "フォロー結果情報テーブル")) return res;   //異常返し
                }
            }

            //-------------------------------------------------------------
            //３.データ加工処理
            //-------------------------------------------------------------
            //フォロー予定情報
            dto2 = Converter.GetYoteiDetailDto(dto2, req.followdetailvm, yoteiinputflg);
            //フォロー結果情報
            dto3 = Converter.GetKekkaDetailDto(dto3, req.followdetailvm, kekkainputflg);

            //-------------------------------------------------------------
            //４.DB更新処理
            //-------------------------------------------------------------
            //新規の場合
            if (req.editkbn == Enum編集区分.新規)
            {
                if (sinkiEdano > 0)
                {
                    //フォロー予定情報テーブル フォロー内容枝番、枝番+1
                    dto2.edano = sinkiEdano;
                    //フォロー結果情報テーブル フォロー内容枝番、枝番+1
                    dto3.edano = sinkiEdano;
                }

                db.tt_kkfollowyotei.INSERT.SetDiffLogParameter(null).Execute(dto2);  //フォロー予定情報テーブル
                db.tt_kkfollowkekka.INSERT.SetDiffLogParameter(null).Execute(dto3);  //フォロー結果情報テーブル
            }
            //更新の場合
            else
            {
                db.tt_kkfollowyotei.UpdateDto(dto2, req.followdetailvm.upddttmyotei!.Value);  //フォロー予定情報テーブル
                db.tt_kkfollowkekka.UpdateDto(dto3, req.followdetailvm.upddttmkekka!.Value);  //フォロー結果情報テーブル

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.followdetailvm.atenano, false, EnumAtenaActionType.更新);
            }

            //正常返し
            return res;
        }

        /// <summary>
        /// 削除処理(結果画面)
        /// </summary>
        public DaResponseBase DeleteFollowNaiyoResponse(DaDbContext db, DeleteFollowNaiyoRequest req)
        {
            //-------------------------------------------------------------
            //１.DB更新処理
            //-------------------------------------------------------------
            //フォロー内容情報テーブル
            db.tt_kkfollownaiyo.DeleteByKey(req.atenano, req.follownaiyoedano, req.upddttm);
            db.tt_kkfollowkekka.DELETE.WHERE.ByKey(req.atenano, req.follownaiyoedano).Execute();
            db.tt_kkfollowyotei.DELETE.WHERE.ByKey(req.atenano, req.follownaiyoedano).Execute();

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.削除);

            //正常返し
            return new DaResponseBase();
        }

        /// <summary>
        /// 削除処理(詳細画面)
        /// </summary>
        public DaResponseBase DeleteFollowDetailResponse(DaDbContext db, DeleteFollowDetailRequest req)
        {
            //-------------------------------------------------------------
            //１.DB更新処理
            //-------------------------------------------------------------
            //フォロー予定情報テーブル
            db.tt_kkfollowyotei.DeleteByKey(req.atenano, req.follownaiyoedano, req.edano, req.upddttmyotei!.Value);
            //フォロー結果情報テーブル
            db.tt_kkfollowkekka.DeleteByKey(req.atenano, req.follownaiyoedano, req.edano, req.upddttmkekka!.Value);

            //宛名ログ記録
            DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.削除);

            //正常返し
            return new DaResponseBase();
        }
    }
}
