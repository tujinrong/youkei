// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フォロー管理(共通バー)
// 　　　　　　サービス処理
// 作成日　　: 2023.12.26
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00401G;
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00609D
{
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWAF00609D = "AWAF00609D";

        //フォロー管理検索(内容画面)
        private const string PROC_NAME1 = "sp_awkk00401g_01";

        //フォロー管理検索(結果画面)
        private const string PROC_NAME2 = "sp_awkk00401g_02";

        [DisplayName("検索処理(内容画面)")]
        public SearchFollowNaiyoListResponse SearchFollowNaiyoList(SearchFollowNaiyoListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchFollowNaiyoListResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //登録事業(表示範囲)
                var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.フォロー事業, req.kinoid!, req.patternno, false);

                var parameters = Converter.GetParameters(req, keyList);

                //一覧データ取得
                var dt = DaDbUtil.GetProcedureData(db, PROC_NAME1, parameters);

                //住民情報取得(ヘッダー部)
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //警告参照フラグ取得
                var alertviewflg = CmLogicUtil.GetAlertviewflg(db, req.token, req.userid, req.regsisyo);
                //住所フラグ
                var adrsFlg = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._03).BoolValue1;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト初期化
                GetFollowContentInitList(db, res);

                //住民情報
                res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.CommonBarHeaderBase3VM(), dto, alertviewflg, adrsFlg);

                //内容情報一覧
                res.kekkalist = Wraper.GetFollowContentVMList(db, dt.Rows);

                //正常返し
                return res;
            });
        }

        [DisplayName("新規処理(結果画面)")]
        public InitFollowNaiyoResponse InitFollowNaiyo(InitFollowNaiyoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return Nolock(req, (DaDbContext db) =>
                {
                    var service = new AWKK00401G.Service();
                    return service.GetInitFollowNaiyoResponse(db, req);
                });
            });
        }

        [DisplayName("検索処理(結果画面)")]
        public SearchFollowNaiyoResponse SearchFollowNaiyo(SearchFollowNaiyoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.GetSearchFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("新規処理(詳細画面)")]
        public InitFollowDetailResponse InitFollowDetail(InitFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.GetInitFollowDetailResponse(db, req);
            });
        }

        [DisplayName("検索処理(詳細画面)")]
        public SearchFollowDetailResponse SearchFollowDetail(SearchFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.GetSearchFollowDetailResponse(db, req);
            });
        }

        [DisplayName("前回結果情報セット処理(詳細画面)")]
        public FollowDetailPreKekkaResponse SearchFollowDetailPreKekka(SearchFollowDetailRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.GetSearchFollowDetailPreKekkaResponse(db, req);
            });
        }

        [DisplayName("予定情報セット処理(詳細画面)")]
        public FollowDetailKekkaResponse SearchFollowDetailKekka(SearchFollowDetailPreKekkaRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.GetSearchFollowDetailKekkaResponse(db, req);
            });
        }

        [DisplayName("保存処理(結果画面)")]
        public DaResponseBase SaveFollowNaiyo(SaveFollowNaiyoRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.SaveFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("保存処理(詳細画面)")]
        public DaResponseBase SaveFollowDetail(SaveFollowDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.SaveFollowDetailResponse(db, req);
            });
        }

        [DisplayName("削除処理(結果画面)")]
        public DaResponseBase DeleteFollowNaiyo(DeleteFollowNaiyoRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.DeleteFollowNaiyoResponse(db, req);
            });
        }

        [DisplayName("削除処理(詳細画面)")]
        public DaResponseBase DeleteFollowDetail(DeleteFollowDetailRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                var service = new AWKK00401G.Service();
                return service.DeleteFollowDetailResponse(db, req);
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
            res.haakujigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.フォロー把握事業コード));
            //ドロップダウンリスト(フォロー状況)
            res.followstatusList = DaNameService.GetSelectorList(db, EnumNmKbn.フォロー状況, Enum名称区分.名称);
            //ドロップダウンリスト(フォロー事業)
            res.followjigyoList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(EnumHanyoKbn.フォロー事業コード));
        }
    }
}