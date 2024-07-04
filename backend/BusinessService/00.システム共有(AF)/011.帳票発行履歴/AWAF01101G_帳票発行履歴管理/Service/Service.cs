// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行履歴管理
// 　　　　　　サービス処理
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using NPOI.SS.Formula.Functions;
using Org.BouncyCastle.Ocsp;
using System;
using System.Threading.Tasks;
using static NPOI.HSSF.Util.HSSFColor;

namespace BCC.Affect.Service.AWAF01101G
{
    [DisplayName("帳票発行履歴管理")]
    public class Service : CmServiceBase
    {

        private const string AWAF01101G = "AWAF01101G";
        private const string PROC_NAME01 = "sp_awaf01101g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitListResponse InitList(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitListResponse();
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(帳票名)
                res.selectorlist1 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUC帳票マスタ);

                //ドロップダウンリスト(様式名)
                res.selectorlist2 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.EUC様式詳細マスタ);

                //ドロップダウンリスト(抽出対象)
                res.selectorlist3 = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumシステムマスタ区分.帳票発行抽出対象マスタ);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchListResponse SearchList(SearchListRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchListResponse();                

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var parameters = Converter.GetParameters(req);

                //一覧データ取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME01, parameters, req.pagenum, req.pagesize);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //タスクスケジュール情報一覧
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                return res;
            });
        }
    }
}
