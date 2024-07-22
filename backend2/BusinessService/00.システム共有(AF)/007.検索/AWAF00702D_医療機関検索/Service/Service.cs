// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 医療機関検索
// 　　　　　　サービス処理
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.Service.AWAF00702D
{
    [DisplayName("医療機関検索")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        private const string PROC_NAME = "sp_awaf00702d_01";

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //実施事業(表示範囲)
                var keyList = new List<string>();
                if (string.IsNullOrEmpty(req.jigyocds))
                {
                    keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.医療機関, req.kinoid!, req.patternno, false);
                }
                else
                {
                    keyList = new List<string>(req.jigyocds.Split(C_COMMA));
                }

                //パラメータ取得
                var param = Converter.GetParameters(req, keyList);

                //医療機関一覧取得
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //画面項目設定
                res.kekkalist = Wraper.GetVMList(pageList.dataTable.Rows);

                //ページャー設定
                res.SetPageInfo(pageList.TotalCount, req.pagesize);

                //正常返し
                return res;
            });
        }
    }
}