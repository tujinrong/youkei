// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目ツリー参照
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00107D
{
    [DisplayName("項目ツリー参照")]
    public class Service : CmServiceBase
    {
        [DisplayName("一覧項目ツリー検索処理")]
        public SearchResponse SearchNormalTree(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var itemDtl = GetDatasourceItemDtl(db, req.datasourceid, Enum使用区分.一覧項目, Enum使用区分.併用);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //一覧項目ツリー
                res.itemtree = Wraper.GetSimpleNormalItemTree(itemDtl); 

                //正常返し
                return res;
            });
        }

        [DisplayName("集計項目ツリー検索処理")]
        public SearchResponse SearchStatisticTree(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var itemDtl = GetDatasourceItemDtl(db, req.datasourceid, Enum使用区分.集計項目, Enum使用区分.併用);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //集計項目ツリー
                res.itemtree = Wraper.GetSimpleStatisticsItemTree(itemDtl); 

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// データソース項目リストを取得
        /// </summary>
        private static IEnumerable<tm_eutableitemDto> GetDatasourceItemDtl(DaDbContext db, string datasourceId, params Enum使用区分[]? useKbns)
        {
            //EUCデータソース項目マスタからsqlcolumnリストを検索
            var sqlColumnList = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(datasourceId).GetDtoList()
                .Select(x => x.sqlcolumn)
                .ToList();

            //sqlcolumnを条件としてEUCテーブル項目マスタ から検索
            var tableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(sqlColumnList).ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList();
            return useKbns == null || !useKbns.Any() ? tableItemDtl : tableItemDtl.Where(x => useKbns.Contains(x.usekbn));
        }
    }
}