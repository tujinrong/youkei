// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: データグループ新規作成
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00102D
{
    [DisplayName("データグループ新規作成")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var tableDtl = DaEucBasicService.GetAllTables(db);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //メインテーブルリスト
                res.tablelist = Wraper.GetTableVMList(tableDtl);
                //業務区分リスト
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("メインテーブル選択変更時検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var list = db.Session.Query<string>($"SELECT DISTINCT {nameof(tm_eutableitemDto.daibunrui)} FROM tm_eutableitem " +
                                                                    $"WHERE {nameof(tm_eutableitemDto.tablealias)}='{req.tablealias}'  and {nameof(tm_eutableitemDto.daibunrui)} IS NOT NULL ");
                list = list.Where(x => !string.IsNullOrEmpty(x)).ToList();
                if (!list.Any())
                {
                    return res;
                }
                var dtl = db.Session.Query<tm_eutableitemDto>($"SELECT * FROM tm_eutableitem WHERE {nameof(tm_eutableitemDto.daibunrui)}='{list[0]}' ORDER BY {nameof(tm_eutableitemDto.itemid)}");
                res.tableitemlist = Wraper.GetTableItemVMList(dtl);
                res.daibunruilist = list;
                return res;
            });
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                if (!Check(db, req, res))
                {
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //TODOi
                var canJoinTableDtl = TableJoinTreeUtil.GetCanJoinTableDtl(db, req.maintablealias);
                var joinTableAliasSet = canJoinTableDtl.Select(x => x.tablealias).ToHashSet();
                var tableJoinDtl = DaEucBasicService.GetAllTableJoinDtl(db)
                    .Where(x => canJoinTableDtl.Any(c => c.tablealias == x.tablealias && c.kanrentablealias == x.kanrentablealias))
                    .ToList();

                var allTableAliasSet = new HashSet<string>(joinTableAliasSet) { req.maintablealias };
                //allTableAliasSetとsqlcolumns使用してEUCテーブル項目マスタを検索します  
                const string filter =
                    $"{nameof(tm_eutableitemDto.sqlcolumn)} = ANY(@{nameof(tm_eutableitemDto.sqlcolumn)}) " +
                    $"AND {nameof(tm_eutableitemDto.tablealias)} = ANY(@{nameof(tm_eutableitemDto.tablealias)})";
                var tableitemDtl = db.tm_eutableitem.SELECT.WHERE.ByFilter(filter, req.sqlcolumns.ToArray(), allTableAliasSet.ToArray())
                    .GetDtoList();

                var datasourceTableAliasSet = allTableAliasSet.Intersect(tableitemDtl.Select(x => x.tablealias)).ToHashSet();
                //最大orderseq
                var maxSeq = db.tm_eudatasource.SELECT.GetMax<int>(nameof(tm_eudatasourceDto.orderseq));

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var datasourceDto = Converter.GetDatasourceDto(req, ++maxSeq);
                //todo find all join info
                var datasourceJoinDtl = Converter.GetDatasourceJoinDtl(req.datasourceid, tableJoinDtl.Where(x => datasourceTableAliasSet.Contains(x.tablealias)));
                var datasourceItemDtl = Converter.GetDatasourceItemDtl(req.datasourceid, tableitemDtl);
                
                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //EUCデータソースマスタを登録
                db.tm_eudatasource.INSERT.Execute(datasourceDto);
                //EUCデータソース項目マスタを登録
                db.tm_eudatasourceitem.INSERT.Execute(datasourceItemDtl); 
                if (datasourceJoinDtl.Any())
                {
                    //EUCデータソース結合マスタを登録
                    db.tm_eudatasourcejoin.INSERT.Execute(datasourceJoinDtl); 
                }

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// チェック
        /// </summary>
        private static bool Check(DaDbContext db, SaveRequest req, DaResponseBase res)
        {
            //データソースIDの存在チェック
            if (db.tm_eudatasource.SELECT.WHERE.ByKey(req.datasourceid).Exists())
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E002003, "データソースID");
                res.SetServiceError(msg);
                return false;
            }

            //データソース名称の存在チェック
            if (db.tm_eudatasource.SELECT.WHERE.ByItem(nameof(tm_eudatasourceDto.datasourcenm), req.datasourcenm).Exists())
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E002003, "データソース名称");
                res.SetServiceError(msg);
                return false;
            }

            return true;
        }
    }
}