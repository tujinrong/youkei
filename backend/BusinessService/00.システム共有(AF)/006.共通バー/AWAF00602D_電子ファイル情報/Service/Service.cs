// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 電子ファイル情報
// 　　　　　　サービス処理
// 作成日　　: 2023.03.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00602D
{
    [DisplayName("電子ファイル情報")]
    public class Service : CmServiceBase
    {
        //検索処理
        private const string PROC_NAME = "sp_awaf00602d_01";

        //時間の書式設定
        internal const string TimeFormat = "yyyyMMddHHmmss";

        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //登録事業
                res.selectorlist = CmLogicUtil.GetJigyocdSelectorList(db, Enum事業コード区分.電子ファイル, req.kinoid!, req.kbn, req.patternno, false);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人基本情報取得(ヘッダー部)
                var dto = db.tt_afatena.GetDtoByKey(req.atenano);

                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.E004006, "検索対象", "住民基本情報")) return res;   //異常返し

                //登録事業(表示範囲)
                var keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.電子ファイル, req.kinoid!, req.patternno, false);

                //パラメータ取得
                var param = Converter.GetParameters(req, keyList);

                //電子ファイル情報一覧取得(明細部)
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //更新可能支所一覧
                var sisyoList = CmLogicUtil.GetSisyoList(db, req.token, req.userid, req.regsisyo);

                //登録事業
                var dtl1 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.電子ファイル事業コード);
                //登録支所
                var dtl2 = DaHanyoService.GetHanyoNoDelDtl(db, EnumHanyoKbn.部署_支所);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定(ヘッダー部)
                res.headerinfo = Common.Wraper.GetHeaderVM(db, new Common.CommonBarHeaderBaseVM(), dto);

                //画面項目設定(明細部)
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows, sisyoList, dtl1, dtl2);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //宛名ログ記録
                DaDbLogService.WriteAtenaLog(db, req.atenano, false, EnumAtenaActionType.検索);

                //正常返し
                return res;
            });
        }

        [DisplayName("プレビュー処理")]
        public CmPreviewResponseBase Preview(PreviewRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CmPreviewResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //個人ドキュメントテーブル
                var dto = db.tt_afkojindoc.GetDtoByKey(req.atenano, req.docseq);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //存在チェック
                if (!CmCheckService.CheckDeleted(res, dto, EnumMessage.DATA_NOTEXIST_ERROR, "プレビュー対象", "プレビュー")) return res;   //異常返し

                //-------------------------------------------------------------
                //３.プレビュー処理
                //-------------------------------------------------------------
                var file = Wraper.GetFile(dto);
                res = CmPreviewService.GetPreviewResponseBase(file);

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
                //個人ドキュメントテーブル
                tt_afkojindocDto dto;

                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //最大ドキュメントシーケンス
                    var maxSeq = db.tt_afkojindoc.SELECT.WHERE.ByKey(req.atenano).GetMax<int>(nameof(tt_afkojindocDto.docseq));
                    dto = new tt_afkojindocDto { docseq = ++maxSeq };
                }
                //更新の場合
                else
                {
                    dto = db.tt_afkojindoc.GetDtoByKey(req.atenano, req.savevm.docseq);
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                dto = Converter.GetDto(req, dto);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //新規の場合
                if (req.editkbn == Enum編集区分.新規)
                {
                    //個人ドキュメントテーブル
                    db.tt_afkojindoc.INSERT.SetDiffLogParameter(null).Execute(dto);
                }
                //更新の場合
                else
                {
                    //個人ドキュメントテーブル
                    db.tt_afkojindoc.UPDATE.SetDiffLogParameter(null).SetLock(req.savevm.upddttm!.Value).Execute(dto);
                }

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //キーリスト取得
                var keyList = Converter.GetKeyList(req.atenano, req.locklist);        //キーリスト(削除)
                var oldDtl = db.tt_afkojindoc.SELECT.WHERE.ByKeyList(keyList).GetDtoList(); //削除前

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(oldDtl, req.locklist)) throw new AiExclusiveException();

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //個人ドキュメントテーブル
                db.tt_afkojindoc.DELETE.SetDiffLogParameter(null).WHERE.ByKeyList(keyList).Execute();

                //正常返し
                return new DaResponseBase();
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                CmDownloadResponseBase res;
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //キーリスト取得
                var keyList = Converter.GetKeyList(req.atenano, req.docseqs);

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //個人ドキュメントテーブル
                var dtl = db.tt_afkojindoc.SELECT.WHERE.ByKeyList(keyList).GetDtoList();

                //-------------------------------------------------------------
                //３.チェック処理
                //-------------------------------------------------------------
                //ファイルがない場合
                if (!dtl.Any())
                {
                    res = new CmDownloadResponseBase();
                    res.SetServiceError(EnumMessage.DOWNLOAD_NOTEXIST_ERROR);

                    //異常返し
                    return res;
                }

                //-------------------------------------------------------------
                //４.ダウンロード処理
                //-------------------------------------------------------------
                var files = Wraper.GetFileList(dtl);
                res = CmDownloadService.GetDownloadResponse(files, DaUtil.Now.ToString(TimeFormat));

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(List<tt_afkojindocDto> oldDtl, List<LockVM> locklist)
        {
            return oldDtl.Count == locklist.Count &&
                oldDtl.All(dto => locklist.Exists(k => k.docseq == dto.docseq && k.upddttm == dto.upddttm));
        }
    }
}