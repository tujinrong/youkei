// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ホーム
// 　　　　　　サービス処理
// 作成日　　: 2023.01.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaCodeConst;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00301G
{
    [DisplayName("ホーム")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// お知らせ一覧抽出
        /// </summary>
        private const string INFO_PROC_NAME = "sp_awaf00301g_01";

        /// <summary>
        /// 処理状況一覧抽出
        /// </summary>
        private const string LOG_PROC_NAME = "sp_awaf00301g_02";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var year = DaControlService.GetRow(db, EnumCtrlKbn.config情報, コントロールマスタ.システム.config情報._02);     //システム年度                                  //システム年度
                var atenanolen = DaNameService.GetKbn1(db, EnumNmKbn.指定コード長さ, 名称マスタ.システム.指定コード長さ._1);    //宛名番号長さ
                var kikancdlen = DaNameService.GetKbn1(db, EnumNmKbn.指定コード長さ, 名称マスタ.システム.指定コード長さ._2);    //機関コート長さ

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.nendo = year?.IntValue1 ?? DaUtil.Now.Year;                     //システム年度
                res.atenanolen = CInt(atenanolen);                                  //宛名番号長さ
                res.kikancdlen = CInt(kikancdlen);                                  //医療機関コード長さ
                //処理区分
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.連携処理区分, req.kbn);
                res.kekkalist1 = GetInfoVMList(db, req.userid, Enum未読区分.未読);      //お知らせリスト
                res.kekkalist2 = GetGaibulogVMList(db);                                 //外部連携処理結果履歴リスト

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(お知らせ)")]
        public SearchInfoResponse SearchInfo(SearchInfoRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchInfoResponse();
                //画面項目設定
                res.kekkalist = GetInfoVMList(db, req.userid, req.readkbn);
                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(連携処理)")]
        public SearchLogResponse SearchLog(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchLogResponse();
                //画面項目設定
                res.kekkalist = GetGaibulogVMList(db);
                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                return GetGaibuFile(db, req);
            });
        }

        [DisplayName("メニュー取得処理")]
        public GetMenuResponse GetMenu(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new GetMenuResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //親階層リスト
                var foldDtl = DaNameService.GetNameList(db, EnumNmKbn.メニュー);
                //画面リスト
                var menuDtl = db.tm_afmenu.SELECT.ORDER.By(nameof(tm_afmenuDto.oyamenuid), nameof(tm_afmenuDto.orderseq)).GetDtoList();
                //画面一覧(アクセス可)
                var authList = CmLogicUtil.GetAuthList(db, req.token, req.userid, req.regsisyo).Where(e => e.programkbn == Enumプログラム区分.画面).ToList();
                //機能ID一覧
                var kinoDtl = db.tm_afkino.SELECT.GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //親階層リスト(フォルダー)
                res.menulist = Wraper.GetAllParentsMenu(foldDtl);

                //子階層リスト(画面)
                var pagelist = Wraper.GetAllChildrenMenu(menuDtl, kinoDtl, authList, res.menulist);
                res.menulist.AddRange(pagelist);
                //プログラムリスト
                res.programlist = Wraper.GetProgramList(menuDtl, kinoDtl);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// ダウンロード処理(外部連携ファイル)
        /// </summary>
        public CmDownloadResponseBase GetGaibuFile(DaDbContext db, DownloadRequest req)
        {
            CmDownloadResponseBase res;
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //処理結果履歴テーブル
            var dtl = db.tt_afgaibulog.SELECT.WHERE.ByKey(req.gaibulogseq).GetDtoList();

            //-------------------------------------------------------------
            //２.チェック処理
            //-------------------------------------------------------------
            //ファイルがない場合
            if (dtl == null || !dtl.Any())
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
            var files = Wraper.GetFileList(dtl);

            //-------------------------------------------------------------
            //４.ダウンロード処理
            //-------------------------------------------------------------
            //ダウンロード処理
            res = CmDownloadService.GetDownloadResponse(files);

            //正常返し
            return res;
        }

        /// <summary>
        /// お知らせリスト取得
        /// </summary>
        private List<InfoVM> GetInfoVMList(DaDbContext db, string userid, Enum未読区分 readkbn)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //パラメータ取得
            var param = Converter.GetParameters(userid, readkbn);

            //お知らせ一覧抽出
            var dt = DaDbUtil.GetProcedureData(db, INFO_PROC_NAME, param);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            return Wraper.GetInfoVMList(dt.Rows); //お知らせ
        }

        /// <summary>
        /// 外部連携処理結果履歴リスト取得
        /// </summary>
        private List<GaibulogVM> GetGaibulogVMList(DaDbContext db)
        {
            //-------------------------------------------------------------
            //１.データ取得
            //-------------------------------------------------------------
            //外部連携処理結果履歴一覧抽出
            var dt = DaDbUtil.GetProcedureData(db, LOG_PROC_NAME);

            //-------------------------------------------------------------
            //２.データ加工処理
            //-------------------------------------------------------------
            return Wraper.GetGaibuVMList(db, dt.Rows);    //外部連携処理結果履歴
        }
    }
}