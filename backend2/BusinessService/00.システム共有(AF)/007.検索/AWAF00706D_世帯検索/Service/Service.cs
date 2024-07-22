// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 世帯検索
// 　　　　　　サービス処理
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00706D
{
    [DisplayName("世帯検索")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        private const string PROC_NAME = "sp_awaf00706d_01";

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータ取得
                var param = Converter.GetParameters(req);

                //世帯情報一覧取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(db, pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }
    }
}