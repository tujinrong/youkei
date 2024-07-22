// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目選択
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00103D
{
    [DisplayName("項目選択")]
    public class Service : CmServiceBase
    {
        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //修正分類
                ReviseBunrui(req);

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //テーブル項目情報リストを取得
                //var selectableItemDtl = GetTableItemInfo(db, req);
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                //var canJoinTableAliasSet = DaEucBasicService.GetAllTableJoinDtl(db).Select(x => x.tablealias).ToHashSet();
                //TableJoinTreeUtil.GetCanJoinTableDtl(db, maintablealias).Select(x => x.tablealias).ToHashSet();
                var canJoinTableAliasSet = GetTableList(db, maintablealias);

                //EUCデータソース項目マスタ
                var existSqlColumnSet = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Select(x => x.sqlcolumn)
                    .ToHashSet();
                var allTableAliasSet = new HashSet<string>(canJoinTableAliasSet) { maintablealias };


                if (string.IsNullOrEmpty(req.daibunrui))
                {
                    var bunruiList = GetDaiBuruiList(db, canJoinTableAliasSet);
                    res.nextbunruilist = Wraper.GetTableList(bunruiList);
                    res.tableitemlist = GetItemList(db, existSqlColumnSet, bunruiList).Select(e => Wraper.GetTableItemVM(e)).ToList();
                }
                else if (string.IsNullOrEmpty(req.tyubunrui))
                {
                    res.nextbunruilist = Wraper.GetTableList(GetTyuBuruiList(db, canJoinTableAliasSet, req.daibunrui));
                    res.tableitemlist = GetItemList(db, existSqlColumnSet, req.daibunrui).Select(e => Wraper.GetTableItemVM(e)).ToList();
                }
                else if (string.IsNullOrEmpty(req.syobunrui))
                {
                    res.nextbunruilist = Wraper.GetTableList(GetSyoBuruiList(db, canJoinTableAliasSet, req.daibunrui, req.tyubunrui));
                    res.tableitemlist = GetItemList(db, existSqlColumnSet, req.daibunrui, req.tyubunrui).Select(e => Wraper.GetTableItemVM(e)).ToList();
                }
                else 
                {
                    res.nextbunruilist = new List<TableVM>();
                    res.tableitemlist = GetItemList(db, existSqlColumnSet, req.daibunrui, req.tyubunrui, req.syobunrui).Select(e => Wraper.GetTableItemVM(e)).ToList();
                }


                //EUCデータソース項目マスタ
                //var existSqlColumnSet = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(req.datasourceid).GetDtoList()
                //    .Select(x => x.sqlcolumn)
                //    .ToHashSet();
                //var allTableAliasSet = new HashSet<string>(canJoinTableAliasSet) { maintablealias };

                //const string filter = $"{nameof(tm_eutableitemDto.sqlcolumn)} != ALL(@{nameof(tm_eutableitemDto.sqlcolumn)}) " +
                //                    $"AND {nameof(tm_eutableitemDto.tablealias)} = ANY(@{nameof(tm_eutableitemDto.tablealias)})";

                //EUCテーブル項目マスタ
                //var selectableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByFilter(filter, existSqlColumnSet.ToArray(), allTableAliasSet.ToArray()).GetDtoList()
                //.Where(x => (string.IsNullOrEmpty(req.daibunrui) || req.daibunrui.Equals(x.daibunrui, StringComparison.OrdinalIgnoreCase)) &&
                //(string.IsNullOrEmpty(req.tyubunrui) || req.tyubunrui.Equals(x.tyubunrui, StringComparison.OrdinalIgnoreCase)) &&
                //(string.IsNullOrEmpty(req.syobunrui) || req.syobunrui.Equals(x.syobunrui, StringComparison.OrdinalIgnoreCase)))
                //.OrderBy(x => x.tablealias)
                //.ThenBy(x => x.orderseq).ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //(res.nextbunruilist, res.tableitemlist) = Wraper.GetTableItemVMListAndNextBunruiList(selectableItemDtl, req);

                //正常返し
                return res;
            });
        }

        private HashSet<string> GetDaiBuruiList(DaDbContext db, HashSet<string> tables)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            var list = new HashSet<string>();
            foreach (var item in dtl)
            {
                if (tables.Contains(item.tablealias) || tables.Contains(item.tablealias2 ?? ""))
                {
                    if (list.Contains(item.daibunrui) == false)
                    {
                        if (!string.IsNullOrEmpty(item.daibunrui))
                        {
                            list.Add(item.daibunrui);
                        }
                    }
                }
            }
            return list;
        }

        private HashSet<string> GetTyuBuruiList(DaDbContext db, HashSet<string> tables, string daiBunrui)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            var list = new HashSet<string>();
            foreach (var item in dtl)
            {
                if (tables.Contains(item.tablealias) || tables.Contains(item.tablealias2 ?? ""))
                {
                    if (item.daibunrui == daiBunrui && list.Contains(item.tyubunrui!) == false)
                    {
                        if (!string.IsNullOrEmpty(item.tyubunrui))
                        {
                            list.Add(item.tyubunrui!);
                        }
                    }
                }
            }
            return list;
        }

        private HashSet<string> GetSyoBuruiList(DaDbContext db, HashSet<string> tables, string daiBunrui, string tyuBunrui)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            var list = new HashSet<string>();
            foreach (var item in dtl)
            {
                if (tables.Contains(item.tablealias) || tables.Contains(item.tablealias2 ?? ""))
                {
                    if (item.daibunrui == daiBunrui && item.tyubunrui == tyuBunrui && list.Contains(item.tyubunrui) == false)
                    {
                        if (!string.IsNullOrEmpty(item.syobunrui))
                        {
                            list.Add(item.syobunrui!);
                        }
                    }
                }
            }
            return list;
        }

        private List<tm_eutableitemDto> GetItemList(DaDbContext db, HashSet<string> existSqlColumnSet, HashSet<string> buruilist)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db).Where(e=> !existSqlColumnSet.Contains(e.sqlcolumn) && buruilist.Contains(e.daibunrui)).OrderBy(e=>e.itemid).ToList();
            return dtl;
        }
        private List<tm_eutableitemDto> GetItemList(DaDbContext db, HashSet<string> existSqlColumnSet, string daiBunrui)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            return dtl.Where(e => !existSqlColumnSet.Contains(e.sqlcolumn) && e.daibunrui == daiBunrui).OrderBy(e=>e.orderseq).ThenBy(e=>e.itemid).ToList();
        }
        private List<tm_eutableitemDto> GetItemList(DaDbContext db, HashSet<string> existSqlColumnSet, string daiBunrui, string tyuBunrui)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            return dtl.Where(e => !existSqlColumnSet.Contains(e.sqlcolumn) && e.daibunrui == daiBunrui && e.tyubunrui == tyuBunrui).OrderBy(e => e.orderseq).ThenBy(e => e.itemid).ToList();
        }
        private List<tm_eutableitemDto> GetItemList(DaDbContext db, HashSet<string> existSqlColumnSet, string daiBunrui, string tyuBunrui, string syoBunrui)
        {
            var dtl = DaEucCacheService.GetEutableitemDtoList(db);
            return dtl.Where(e =>!existSqlColumnSet.Contains(e.sqlcolumn) && e.daibunrui == daiBunrui && e.tyubunrui == tyuBunrui && e.syobunrui == syoBunrui).OrderBy(e => e.orderseq).ThenBy(e => e.itemid).ToList();
        }

        private HashSet<string> GetTableList(DaDbContext db, string mainTableAlias)
        {
            return DaEucService.GetAllJoinTables(db, mainTableAlias).ToHashSet();

            //var dtl = DaEucCacheService.GetEutablejoinDtoList(db);
            //var list = new HashSet<string>();
            //list.Add(mainTableAlias);
            //var listAll = new HashSet<string>();
            //listAll.Add(mainTableAlias);
            //for (int i = 0; i < 6; i++)
            //{
            //    var list2 = new HashSet<string>();
            //    foreach (var alias in list)
            //    {
            //        var subTables = dtl.Where(e => e.kanrentablealias == alias);
            //        if (subTables.Any())
            //        {
            //            var tables = subTables.Where(e => e.tablealias.EndsWith("_nm") == false).Select(e => e.tablealias).ToList();
            //            foreach (string table in tables)
            //            {
            //                if (listAll.Contains(table) == false)
            //                {
            //                    list2.Add(table);
            //                    listAll.Add(table);
            //                }
            //            }
            //        }
            //    }
            //    if (!list2.Any())
            //    {
            //        return listAll;
            //    }
            //    list = list2;
            //}
            //return listAll;
        }

        [DisplayName("保存処理")]
        public DaResponseBase Save(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                var canJoinTableDtl = TableJoinTreeUtil.GetCanJoinTableDtl(db, maintablealias);
                var tablejoinDtl = DaEucBasicService.GetAllTableJoinDtl(db)
                    .Where(x => canJoinTableDtl.Any(c => x.tablealias == c.tablealias && x.kanrentablealias == c.kanrentablealias))
                    .ToList();

                //sqlcolumns 使用してEUCデータソース項目マスタを検索します  
                var tableitemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(req.sqlcolumns.ToList()).GetDtoList();
                var tablealiasWithoutMainSet = tableitemDtl.Select(x => x.tablealias).Where(x => x != maintablealias).ToHashSet();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                //データソーステーブル結合チェック
                if (req.checkflg)
                {
                    // SQLColumn,検索条件SQLのチェック
                    bool hasError = false;
                    var errors = new List<string>();  // すべてのエラーメッセージを保存するために使用されます
                    foreach (var sqlcolumn in req.sqlcolumns)
                    {
                        var ret = DaEucService.CheckItemSQL(db, sqlcolumn);
                        if (ret != null)
                        {
                            hasError = true;
                            errors.Add(ret);
                        }
                    }
                    if (hasError)
                    {
                        var errorString = string.Join(",", errors);
                        res.SetServiceError(errorString);
                        return res;
                    }

                    var msg = CheckTablejoin(db, req.datasourceid, maintablealias, tablealiasWithoutMainSet, tablejoinDtl);
                    if (!string.IsNullOrEmpty(msg))
                    {
                        res.SetServiceError(msg);
                        return res;
                    }
                    return res;
                }
                
                string checkfilter = $"{nameof(tm_eudatasourceitemDto.datasourceid)} = @{nameof(tm_eudatasourceitemDto.datasourceid)} " +
                                    $"AND {nameof(tm_eudatasourceitemDto.sqlcolumn)} = ANY(@{nameof(tm_eudatasourceitemDto.sqlcolumn)})";
                //EUCデータソース項目マスタ
                var isExist = db.tm_eudatasourceitem.SELECT.WHERE.ByFilter(checkfilter, req.datasourceid, req.sqlcolumns.ToArray()).Exists();
                if (isExist)
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var keyList = tablealiasWithoutMainSet.Select(x => new object[] { req.datasourceid, x }).ToList();
                //EUCデータソース結合マスタ情報を取得
                var datasourceJoinDtl = Converter.GetDatasourceJoinDtl(req.datasourceid, tablejoinDtl, tablealiasWithoutMainSet);
                //EUCデータソース項目マスタを取得
                var datasourceItemDtl = Converter.GetDatasourceItemDtl(req.datasourceid, tableitemDtl);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //EUCデータソース結合マスタ
                db.tm_eudatasourcejoin.UPDATE.WHERE.ByKeyList(keyList).Execute(datasourceJoinDtl); //差分更新
                //EUCデータソース項目マスタ
                db.tm_eudatasourceitem.INSERT.Execute(datasourceItemDtl); //新規処理

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// データソーステーブル結合チェック
        /// </summary>
        private string CheckTablejoin(DaDbContext db, string datasourceid, string maintablealias, HashSet<string> tablealiasWithoutMainSet, List<tm_eutablejoinDto> tablejoinDtl)
        {
            //EUCテーブル結合マスタに存在
            var newTablealiasList = tablejoinDtl.Where(e => tablealiasWithoutMainSet.Contains(e.tablealias)).ToList();

            foreach (var tablealias in tablealiasWithoutMainSet)
            {
                if (!newTablealiasList.Any(d => d.tablealias == tablealias))
                {
                    //データソーステーブル結合チェックエラーメッセージを取得
                    return GetTableJoinErrorMsg(db, tablealias);
                }
            }

            //EUCデータソース結合マスタ
            var datasourcejoinList = db.tm_eudatasourcejoin.SELECT.WHERE.ByKey(datasourceid).GetDtoList();

            foreach (var tableDto in newTablealiasList)
            {
                if (tableDto.kanrentablealias != maintablealias
                && !tablealiasWithoutMainSet.Contains(tableDto.kanrentablealias)
                && !datasourcejoinList.Exists(e => e.tablealias == tableDto.kanrentablealias))
                {
                    //データソーステーブル結合チェックエラーメッセージを取得
                    return GetTableJoinErrorMsg(db, tableDto.tablealias);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// データソーステーブル結合チェックエラーメッセージを取得
        /// </summary>
        private string GetTableJoinErrorMsg(DaDbContext db, string tablealias)
        {
            var dto = db.tm_eutable.GetDtoByKey(tablealias);
            var tablehyojinm = dto == null ? tablealias : dto.tablehyojinm;
            return DaMessageService.GetMsg(EnumMessage.E004006, $"「{tablehyojinm}」", "メインテーブルの関連付け");
        }

        /// <summary>
        /// テーブル項目情報リストを取得
        /// </summary>
        //private List<tm_eutableitemDto> GetTableItemInfo(DaDbContext db, SearchRequest req)
        //{


        //    return selectableItemDtl;
        //}

        /// <summary>
        /// 修正分類
        /// </summary>
        private static void ReviseBunrui(SearchRequest req)
        {
            if (string.IsNullOrEmpty(req.daibunrui))
            {
                req.tyubunrui = null;
                req.syobunrui = null;
                return;
            }

            if (string.IsNullOrEmpty(req.tyubunrui))
            {
                req.syobunrui = null;
            }
        }
    }
}