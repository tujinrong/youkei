// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログ情報管理
// 　　　　　　サービス処理
// 作成日　　: 2023.08.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;

namespace BCC.Affect.Service.AWAF00803G
{
    [DisplayName("ログ情報管理")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00803G = "AWAF00803G";

        //検索処理(一覧画面)
        private const string PROC_NAME1 = "sp_awaf00803g_01";

        //検索処理(詳細画面:通信ログ情報)
        private const string PROC_NAME2 = "sp_awaf00803g_02";

        //検索処理(詳細画面:バッチログ情報)
        private const string PROC_NAME3 = "sp_awaf00803g_03";

        //検索処理(詳細画面:連携ログ情報)
        private const string PROC_NAME4 = "sp_awaf00803g_04";

        //検索処理(詳細画面:DB操作ログ情報)
        private const string PROC_NAME5 = "sp_awaf00803g_05";

        //検索処理(詳細画面:項目値変更情報)
        private const string PROC_NAME6 = "sp_awaf00803g_06";

        //検索処理(詳細画面:宛名番号ログ情報)
        private const string PROC_NAME7 = "sp_awaf00803g_07";

        //出力処理(ログメイン)
        private const string PROC_NAME8 = "sp_awaf00803g_08";
        //出力処理(ログ通信)
        private const string PROC_NAME9 = "sp_awaf00803g_09";
        //出力処理(ログバッチ)
        private const string PROC_NAME10 = "sp_awaf00803g_10";
        //出力処理(ログ連携)
        private const string PROC_NAME11 = "sp_awaf00803g_11";
        //出力処理(ログDB)
        private const string PROC_NAME12 = "sp_awaf00803g_12";
        //出力処理(ログ項目値)
        private const string PROC_NAME13 = "sp_awaf00803g_13";
        //出力処理(ログ宛名)
        private const string PROC_NAME14 = "sp_awaf00803g_14";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //処理一覧
                var dtl = DaNameService.GetNameList(db, EnumNmKbn.処理一覧_ログ画面用);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(ログ区分)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.ログ区分, Enum名称区分.名称);
                //ドロップダウンリスト(処理結果)
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.処理結果コード, Enum名称区分.名称);
                //ドロップダウンリスト(機能)
                res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.機能マスタ);
                //ドロップダウンリスト(処理)
                res.selectorlist4 = dtl.Select(e => new DaSelectorKeyModel(e.hanyokbn2, e.shortnm, e.hanyokbn1)).ToList();
                //ドロップダウンリスト(操作者)
                res.selectorlist5 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.ユーザーマスタ, true);
                //システム
                res.selectorlist5.Add(new DaSelectorModel(DaConst.SYSTEM, DaConst.SYSTEM));

                //CSV出力フラグ
                res.csvoutflg = CmLogicUtil.GetCsvoutflg(db, req.token, req.userid, req.regsisyo, AWAF00803G);

                //正常返し
                return res;
            });
        }

        //TODO
        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            //TODO:５回実行後、Cmd.Excute()エラー
            return Nolock2(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人番号復号化
                req.SetPersonalno();
                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);

                //個人番号権限取得
                var pnoAuthFlg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWAF00803G);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ログ情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, pnoAuthFlg);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

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
                //メインログテーブル
                var logDto = db.tt_aflog.GetDtoByKey(req.sessionseq);
                //存在チェック
                if (!CmCheckService.CheckDeleted(res, logDto, EnumMessage.E004006, "参照ログ", "データベース"))
                {
                    return res;   //異常返し
                }

                //ユーザーマスタ
                var userDto = new tm_afuserDto();
                if (logDto.reguserid != DaConst.SYSTEM)
                {
                    userDto = db.tm_afuser.GetDtoByKey(logDto.reguserid);
                }

                //宛名番号ログテーブル
                var pnoflg = db.tt_aflogatena.SELECT.WHERE.ByFilter($@"{nameof(tt_aflogatenaDto.sessionseq)} = @{nameof(tt_aflogatenaDto.sessionseq)} AND 
                                                                       {nameof(tt_aflogatenaDto.pnouseflg)} = @{nameof(tt_aflogatenaDto.pnouseflg)}",
                                                                       req.sessionseq, true).Exists();

                //個人番号権限取得
                var pnoAuthFlg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWAF00803G);

                //通信ログテーブル
                var tab1flg = db.tt_aftusinlog.SELECT.WHERE.ByItem(nameof(tt_aftusinlogDto.sessionseq), req.sessionseq).Exists();
                //バッチログテーブル
                var tab2flg = db.tt_afbatchlog.SELECT.WHERE.ByItem(nameof(tt_afbatchlogDto.sessionseq), req.sessionseq).Exists();
                //外部連携処理結果履歴テーブル
                var tab3flg = db.tt_afgaibulog.SELECT.WHERE.ByItem(nameof(tt_afgaibulogDto.sessionseq), req.sessionseq).Exists();
                //DB操作ログテーブル
                var tab4flg = db.tt_aflogdb.SELECT.WHERE.ByItem(nameof(tt_aflogdbDto.sessionseq), req.sessionseq).Exists();
                //テーブル項目値変更ログテーブル
                var tab5flg = db.tt_aflogcolumn.SELECT.WHERE.ByItem(nameof(tt_aflogcolumnDto.sessionseq), req.sessionseq).Exists();
                //宛名番号ログテーブル
                var tab6flg = db.tt_aflogatena.SELECT.WHERE.ByItem(nameof(tt_aflogatenaDto.sessionseq), req.sessionseq).Exists();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //通信ログ情報一覧
                res.headerinfo = Wraper.GetVM(db, logDto, userDto, pnoflg, pnoAuthFlg);

                res.existflg1 = tab1flg;    //通信ログ操作状況
                res.existflg2 = tab2flg;    //バッチログ操作状況
                res.existflg3 = tab3flg;    //外部連携ログ操作状況
                res.existflg4 = tab4flg;    //DB操作ログ操作状況
                res.existflg5 = tab5flg;    //項目値変更ログ操作状況
                res.existflg6 = tab6flg;    //宛名番号ログ操作状況

                //正常返し
                return res;
            });
        }

        [DisplayName("初期化処理(詳細画面:項目値変更情報)")]
        public InitColumDetailResponse InitColumDetail(InitDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitColumDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //テーブル項目情報一覧
                var tblInfoList = AiGlobal.DbInfoProvider.GetTableList(db.Session);
                //項目値変更情報
                var dtl = db.tt_aflogcolumn.SELECT.WHERE.ByItem(nameof(tt_aflogcolumnDto.sessionseq), req.sessionseq).GetDtoList();

                //テーブル一覧(項目値変更情報)
                var list1 = dtl.Select(e => e.tablenm).Distinct().OrderBy(e => e).ToList();
                //変更項目一覧(項目値変更情報)
                var list2 = dtl.Select(e => new DaSelectorKeyModel(e.itemnm, null, e.tablenm)).DistinctBy(e => new { e.key, e.value }).OrderBy(e => e.key).ThenBy(e => e.value).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(変更テーブル)
                res.selectorlist1 = Wraper.GetTableList(tblInfoList, list1);
                //ドロップダウンリスト(変更項目)
                res.selectorlist2 = Wraper.GetItemList(db, list2);
                //ドロップダウンリスト(変更区分)
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.DB変更区分, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:通信ログ情報)")]
        public SearchTusinDetailResponse SearchTusinDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchTusinDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req.sessionseq);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME2, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //通信ログ情報一覧
                res.kekkalist = Wraper.GetTusinVMList(pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:バッチログ情報)")]
        public SearchBatchDetailResponse SearchBatchDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchBatchDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req.sessionseq);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME3, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //バッチログ情報一覧
                res.kekkalist = Wraper.GetBatchVMList(pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:連携ログ情報)")]
        public SearchGaibuDetailResponse SearchGaibuDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchGaibuDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req.sessionseq);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME4, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //連携ログ情報一覧
                res.kekkalist = Wraper.GetGaibuVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:DB操作ログ情報)")]
        public SearchDBDetailResponse SearchDBDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchDBDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req.sessionseq);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME5, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //DB操作ログ情報一覧
                res.kekkalist = Wraper.GetDBVMList(pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:項目値変更情報)")]
        public SearchColumnDetailResponse SearchColumnDetail(SearchColumnDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchColumnDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME6, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //項目値変更情報情報一覧
                res.kekkalist = Wraper.GetColumnVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(詳細画面:宛名番号ログ情報)")]
        public SearchAtenaDetailResponse SearchAtenaDetail(SearchCommonRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchAtenaDetailResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req.sessionseq);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME7, parameters, req.pagenum, req.pagesize, req.orderby);

                //個人番号権限取得
                var pnoAuthFlg = CmLogicUtil.GetPersonalflg(db, req.token, req.userid, req.regsisyo, AWAF00803G);
                //住所表記フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //宛名番号ログ情報一覧
                res.kekkalist = Wraper.GetAtenaVMList(db, pageList.dataTable.Rows, pnoAuthFlg, adrsFlg);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(AWAF00301G.DownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWAF00301G.Service();
                return service.GetGaibuFile(db, req);
            });
        }

        [DisplayName("CSV出力処理")]
        public CmDownloadResponseBase Output(OutputRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                CmDownloadResponseBase res;
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = Converter.GetParameters(req);
                //ログメイン
                DataTable? dt0 = null;
                if (req.mainflg) dt0 = DaDbUtil.GetProcedureData(db, PROC_NAME8, parameters);
                //ログ通信
                DataTable? dt1 = null;
                if (req.tusinflg) dt1 = DaDbUtil.GetProcedureData(db, PROC_NAME9, parameters);
                //ログバッチ
                DataTable? dt2 = null;
                if (req.batchflg) dt2 = DaDbUtil.GetProcedureData(db, PROC_NAME10, parameters);
                //ログ連携
                DataTable? dt3 = null;
                if (req.gaibuflg) dt3 = DaDbUtil.GetProcedureData(db, PROC_NAME11, parameters);
                //ログDB
                DataTable? dt4 = null;
                if (req.dbflg) dt4 = DaDbUtil.GetProcedureData(db, PROC_NAME12, parameters);
                //ログ項目値
                DataTable? dt5 = null;
                if (req.columnflg) dt5 = DaDbUtil.GetProcedureData(db, PROC_NAME13, parameters);
                //ログ宛名
                DataTable? dt6 = null;
                if (req.atenaflg) dt6 = DaDbUtil.GetProcedureData(db, PROC_NAME14, parameters);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //ファイルがない場合
                if ((dt0 == null || dt0.Rows.Count == 0) &&
                    (dt1 == null || dt1.Rows.Count == 0) && (dt2 == null || dt2.Rows.Count == 0) && (dt3 == null || dt3.Rows.Count == 0) &&
                    (dt4 == null || dt4.Rows.Count == 0) && (dt5 == null || dt5.Rows.Count == 0) && (dt6 == null || dt6.Rows.Count == 0))
                {
                    res = new CmDownloadResponseBase();
                    //エラーメッセージ設定
                    res.SetServiceError(EnumMessage.DOWNLOAD_NOTEXIST_ERROR);

                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //ファイルデータを取得
                var files = Wraper.GetFileList(dt0, dt1, dt2, dt3, dt4, dt5, dt6,
                                               req.mainflg, req.tusinflg, req.batchflg, req.gaibuflg, req.dbflg, req.columnflg, req.atenaflg);

                //-------------------------------------------------------------
                //４.ダウンロード処理
                //-------------------------------------------------------------
                //ダウンロード処理
                res = CmDownloadService.GetDownloadResponse(files);

                //正常返し
                return res;
            });
        }
    }
}