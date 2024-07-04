// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ヘルプ
//             サービス処理
// 作成日　　: 2023.02.24
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00203S
{
    [DisplayName("ヘルプ")]
    public class Service : CmServiceBase
    {
        private const string CTRL_MSG_ID = "AF_HelpDownload";

        [DisplayName("ダウンロード処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                CmDownloadResponseBase res;
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //ヘルプドキュメントマスタ
                var dtl = db.tm_afhelpdoc.SELECT.WHERE.ByItem(nameof(tm_afhelpdocDto.kinoid), req.kinoid).GetDtoList();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //ファイルがない場合
                if (dtl == null || !dtl.Any())
                {
                    //異常返し
                    return DaMsgControlService.GetNotOkResponse<CmDownloadResponseBase>(db, CTRL_MSG_ID);
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                //ファイルデータを取得
                var files = Wraper.GetFileList(dtl);

                //-------------------------------------------------------------
                //４.ダウンロード処理
                //-------------------------------------------------------------
                res = CmDownloadService.GetDownloadResponse(files);

                //正常返し
                return res;
            });
        }
    }
}