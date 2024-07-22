// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力履歴画面
//             サービス処理
// 作成日　　: 2023.09.05
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00305D
{
    public class Service : CmServiceBase
    {
        private const string PROC_NAME = "sp_aweu00305d_01";

        private static readonly Dictionary<Enum出力方式, EnumFileTypeKbn> FILE_TYPE_DICT = new()
        {
            { Enum出力方式.PDF, EnumFileTypeKbn.pdf },
            { Enum出力方式.EXCEL, EnumFileTypeKbn.xlsx },
            { Enum出力方式.CSV, EnumFileTypeKbn.csv }
        };

        [DisplayName("初期化処理(出力履歴検索)")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ取得
                var param = Converter.GetParameters(req);
                //検索実行
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);
                //DB項目から画面項目に変換
                res.kekkalist = Wraper.GetRirekiVMList(db, pageList.dataTable.Rows);

                //正常返し
                return res;
            });
        }

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new CmDownloadResponseBase();
                //EUC帳票出力履歴テーブル取得
                var rirekiDto = db.tt_eurireki.GetDtoByKey(req.rirekiseq);

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (rirekiDto == null!)
                {
                    var message = DaMessageService.GetMsg(EnumMessage.E003005, "帳票出力履歴");
                    res.SetServiceError(message);
                    return res;
                }

                if (rirekiDto.jyotaikbn != Enum履歴出力状態区分.処理完了)
                {
                    var message = DaMessageService.GetMsg(EnumMessage.DOWNLOAD_NOTEXIST_ERROR);
                    res.SetServiceError(message);
                    return res;
                }

                if (rirekiDto.filedata == null || !rirekiDto.filedata.Any())
                {
                    var message = DaMessageService.GetMsg(EnumMessage.DATA_NOTEXIST_ERROR, "結果ファイル", "ダウンロード");
                    res.SetServiceError(message);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var fileNameNoSuffix = !string.IsNullOrEmpty(rirekiDto.filenm) ? rirekiDto.filenm : DaUtil.Now.ToString("yyyyMMdd_HHmmss");
                var fileSuffix = $"{DaStrPool.C_DOT}{FILE_TYPE_DICT[rirekiDto.outputkbn]}";

                //正常返し
                return CmDownloadService.GetDownloadResponse(new DaFileModel(fileNameNoSuffix, fileSuffix, rirekiDto.filedata));
            });
        }
    }
}