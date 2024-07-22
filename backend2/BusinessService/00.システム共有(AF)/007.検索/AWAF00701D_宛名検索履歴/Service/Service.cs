// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 宛名検索履歴
// 　　　　　　サービス処理
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
{
    [DisplayName("宛名検索履歴")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        private const string PROC_NAME = "sp_awaf00701d_01";

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

                //宛名番号検索履歴一覧取得
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

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, (DaDbContext db) =>
            {
                //-------------------------------------------------------------
                //１.データ加工処理
                //-------------------------------------------------------------
                //宛名番号検索履歴テーブル
                var dtl = Converter.GetDtl(req);

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                //宛名番号検索履歴テーブル
                db.tt_afatenalog.UPDATE.WHERE.ByKey(req.userid, req.kinoid, req.atenano).Execute(dtl);   //差分更新

                //正常返し
                return new DaResponseBase();
            });
        }
    }
}