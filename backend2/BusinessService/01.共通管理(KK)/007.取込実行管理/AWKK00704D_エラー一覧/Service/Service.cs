// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行.エラー一覧
// 　　　　　　サービス処理
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using NPOI.SS.UserModel;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00704D
{
    [DisplayName("取込実行")]
    public class Service : CmServiceBase
    {
        //機能ID
        private const string AWKK00704D = "AWKK00704D";

        //初期検索処理
        private const string PROC_NAME1 = "sp_awkk00704d_01";

        [DisplayName("初期化処理(エラー一覧(行のエラー明細）)")]
        public InitListResponse InitList(InitListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ設定
                var parameters = GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME1, parameters, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //取込データエラー情報リストを取得する
                res.kimpErrList = Wraper.GetKimpErrRowVMList(pageList.dataTable);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }

        [DisplayName("エラー出力処理")]
        public CmDownloadResponseBase Download(DownloadRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new CmDownloadResponseBase();

                var rowIndex = 0; var colIndex = 0;                     //一時変数宣言
                var tempFileName = Path.GetTempFileName() + ".xlsx";    //一時出力ファイル名取得
                var excelReprot = new ExcelLogger();

                //※取込データエラー情報を出力
                //定数定義
                var sheetName = "エラー一覧";
                var sStr0 = "No,行,宛名番号,氏名,項目名,項目値,エラー内容";
                var bOpen = excelReprot.Open(tempFileName, sheetName, true);
                ICellStyle headStyle = excelReprot.CreateHeadStyle();
                ICellStyle bodyStyle = excelReprot.CreateBodyStyle();

                //ヘッダー
                var sArr = sStr0.Split(",");
                for (colIndex = 0; colIndex < sArr.Length; colIndex++)
                {
                    excelReprot.WriteCell(headStyle, colIndex, rowIndex, sArr[colIndex], true, true);
                }
                rowIndex = 1;

                //取込データエラー情報リスト
                List<KimpErrRowVM> kimpErrList = req.kimpErrList;
                for (var i = 0; i < kimpErrList.Count; i++)
                {
                    colIndex = 0;
                    var data = kimpErrList[i];
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, i + 1);              //№
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, data.rowno);         //行
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, CStr(data.atenano)); //宛名番号
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, CStr(data.shimei));  //氏名
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, CStr(data.itemnm));  //項目名
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, CStr(data.val));     //項目値
                    excelReprot.WriteCell(bodyStyle, colIndex++, rowIndex, data.msg);           //メッセージ(エラー内容)

                    rowIndex++;
                }
                excelReprot.Close();

                //Excelファイルからbyte[]に変換
                FileStream fs = File.OpenRead(tempFileName);
                byte[] bytebuffer;
                bytebuffer = new byte[fs.Length];
                fs.Read(bytebuffer, 0, (int)fs.Length);
                fs.Close();
                //出力ファイル名
                var fileName = $"取込エラー_{DaUtil.Now.ToString("yyyyMMddhhmmss")}";
                res = CmDownloadService.GetDownloadResponse(new DaFileModel(fileName, ".xlsx", bytebuffer));

                File.Delete(tempFileName); File.Delete(tempFileName + ".xlsx");

                //出力
                return res;

            });
        }

        /// <summary>
        /// 検索パラメータを取得
        /// </summary>
        public List<AiKeyValue> GetParameters(InitListRequest req)
        {
            var paras = new List<AiKeyValue> {
                new($"{nameof(tt_kktorinyuryoku_errDto.impjikkoid)}_in", req.impexeid)    //取込実行ID
            };

            return paras;
        }

    }
}