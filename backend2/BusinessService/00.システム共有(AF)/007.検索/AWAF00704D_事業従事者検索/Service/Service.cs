// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者検索
// 　　　　　　サービス処理
// 作成日　　: 2023.10.20
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaStrPool;
namespace BCC.Affect.Service.AWAF00704D
{
    [DisplayName("事業従事者検索")]
    public class Service : CmServiceBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        private const string PROC_NAME = "sp_awaf00704d_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, (DaDbContext db) =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //ドロップダウンリスト(機能)
                res.selectorlist1 = DaNameService.GetSelectorList(db, EnumNmKbn.職種, Enum名称区分.名称);
                res.selectorlist2 = DaNameService.GetSelectorList(db, EnumNmKbn.活動区分, Enum名称区分.名称);

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
                //実施事業(表示範囲)
                var keyList = new List<string>();
                if (string.IsNullOrEmpty(req.jigyocds))
                {
                    keyList = CmLogicUtil.GetJigyocdList(db, Enum事業コード区分.事業従事者, req.kinoid!, req.patternno, false);
                }
                else
                {
                    keyList = new List<string>(req.jigyocds.Split(C_COMMA));
                }

                //パラメータ取得
                var param = Converter.GetParameters(req, keyList);

                //事業従事者情報一覧取得
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
