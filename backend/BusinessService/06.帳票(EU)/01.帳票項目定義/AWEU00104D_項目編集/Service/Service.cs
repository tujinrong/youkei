// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目編集
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.Common;
using NPOI.SS.Formula.Functions;

namespace BCC.Affect.Service.AWEU00104D
{
    [DisplayName("項目編集")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();
                if (!string.IsNullOrEmpty(req.sqlcolumn))
                { 
                    return res; 
                }

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //メインテーブル別名
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                //EUC テーブルマスタ　tm_eutable 　
                var mainTableDto = DaEucBasicService.GetTable(db, maintablealias)!;
                var canJoinTableDtl = TableJoinTreeUtil.GetCanJoinTableDtl(db, maintablealias)
                    .Where(x => x.tablealias.Equals(x.tablenm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                //テーブル物理名
                var allTableData = db.tm_eutable.SELECT.GetDtoList().ToList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //テーブルリスト
                res.tablelist = Wraper.GetTableVMList(mainTableDto, canJoinTableDtl);
                //ドロップダウンリスト(使用区分)
                res.selectorlist1 = EucConstant.USE_KBN_OPTIONS;
                //ドロップダウンリスト(集計項目区分)
                res.selectorlist2 = EucConstant.SYUKEI_KBN_OPTIONS;
                //ドロップダウンリスト(データ型)
                res.selectorlist3 = DaNameService.GetSelectorList(db, EnumNmKbn.データ型, Enum名称区分.名称);
                //テーブル物理名リスト
                res.tableNamelist = allTableData.Select(e => e.tablenm).Distinct().ToList();
                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //メインテーブル別名
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                //検索EUCデータソース項目マスタ
                var dto = db.tm_eudatasourceitem.GetDtoByKey(req.datasourceid, req.sqlcolumn);
                //EUCテーブル項目情報を取得
                var tableitemDto = GetTableItem(db, req.sqlcolumn);
                //EUCデータソース結合マスタ
                var joinDict = db.tm_eudatasourcejoin.SELECT.WHERE.ByKey(req.datasourceid).GetDtoList()
                    .ToDictionary(x => x.tablealias, x => x.kanrentablealias);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //関連テーブル別名
                if(tableitemDto.tablealias == maintablealias)
                {
                    res.kanrentablealias = string.Empty;
                }
                else
                {
                    res.kanrentablealias = joinDict.GetValueOrDefault(tableitemDto.tablealias, string.Empty);
                }
                
                //更新日時
                res.upddttm = dto.upddttm; 
                //項目情報をセット
                Wraper.SetSearchItem(res, tableitemDto);

                //正常返し
                return res;
            });
        }

        [DisplayName("新規処理")]
        public DaResponseBase Add(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                // SQLColumn,検索条件SQLのチェック
                if (req.checkflg)
                {
                    return CheckSql(db, req.sqlcolumn);
                }

                if (!SaveCheck(db, Enum編集区分.新規, req, res))
                {
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //メインテーブル別名
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                //最大orderseq
                var maxOrderSeq = db.tm_eutableitem.SELECT.GetMax<int>(nameof(tm_eutableitemDto.orderseq));

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //データ処理
                var datasourceItemDto = Converter.GetDatasourceItemDto(req.datasourceid, req.sqlcolumn);
                var tableItemDto = Converter.GetTableItemDto(req, ++maxOrderSeq);
                //EUCデータソース項目マスタを登録
                db.tm_eudatasourceitem.INSERT.Execute(datasourceItemDto);
                //EUCテーブル項目マスタを登録
                db.tm_eutableitem.INSERT.Execute(tableItemDto);

                //TODOi
                //EUCデータソース結合マスタを更新
                UpdateDatasourcejoin(db, req, maintablealias);

                //正常返し
                return res;
            });
        }

        [DisplayName("更新処理")]
        public DaResponseBase Update(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                // SQLColumn,検索条件SQLのチェック
                if (req.checkflg)
                {
                    return CheckSql(db, req.sqlcolumn);
                }

                var tableItemDto = db.tm_eutableitem.GetDtoByKey(req.oldsqlcolumn!);
                //sqlcolumn等しいかどうかを判断する
                var sqlColumnChangeFlg = !req.sqlcolumn.Equals(req.oldsqlcolumn, StringComparison.OrdinalIgnoreCase);

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!SaveCheck(db, Enum編集区分.変更, req, res))
                {
                    return res;
                }

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var datasourceItemDto = sqlColumnChangeFlg ? Converter.GetDatasourceItemDto(req.datasourceid, req.sqlcolumn) : db.tm_eudatasourceitem.GetDtoByKey(req.datasourceid, req.sqlcolumn);
                tableItemDto = Converter.GetTableItemDto(req, tableItemDto);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                if (sqlColumnChangeFlg)
                {
                    //EUCデータソース項目マスタ
                    db.tm_eudatasourceitem.DeleteByKey(req.datasourceid, req.oldsqlcolumn!, req.upddttm!.Value);
                    db.tm_eudatasourceitem.INSERT.Execute(datasourceItemDto);
                    //EUCテーブル項目マスタ
                    db.tm_eutableitem.DeleteByKey(req.oldsqlcolumn!, tableItemDto.upddttm);
                    db.tm_eutableitem.INSERT.Execute(tableItemDto);
                }
                else
                {
                    //EUCデータソース項目マスタ
                    db.tm_eudatasourceitem.UpdateDto(datasourceItemDto, req.upddttm!.Value);
                    //EUCテーブル項目マスタ
                    db.tm_eutableitem.UpdateDto(tableItemDto, tableItemDto.upddttm);
                }

                //メインテーブル別名
                var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                //EUCデータソース結合マスタを更新
                UpdateDatasourcejoin(db, req, maintablealias);
                
                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, db =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //削除前占有されているかどうかを確認する
                var res = new DaResponseBase();
                HashSet<string> deleteSqlColumnSet = new HashSet<string> { req.sqlcolumn };
                var sqlVerifyMsg = CommonUtil.GetSqlColnumVerification(db, req.datasourceid, deleteSqlColumnSet);
                if (!string.IsNullOrEmpty(sqlVerifyMsg))
                {
                    res.SetServiceError(sqlVerifyMsg);
                    return res;
                }

                var beforeDeleteSqlColumnList = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Select(x => x.sqlcolumn)
                    .ToList();
                //EUCテーブル項目マスタ検索
                var tableitemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(beforeDeleteSqlColumnList).GetDtoList();

                var beforeDeleteTableAliasSet = tableitemDtl.Select(x => x.tablealias).ToHashSet();
                var afterDeleteTableAliasSet = tableitemDtl.Where(x => x.sqlcolumn != req.sqlcolumn).Select(x => x.tablealias).ToHashSet();
                var shouldDeleteTableAliasSet = beforeDeleteTableAliasSet.Except(afterDeleteTableAliasSet).ToHashSet();
                //EUCデータソース項目マスタ検索
                const string filter =
                    $"{nameof(tm_eudatasourceitemDto.datasourceid)} != @{nameof(tm_eudatasourceitemDto.datasourceid)} AND {nameof(tm_eudatasourceitemDto.sqlcolumn)} = @{nameof(tm_eudatasourceitemDto.sqlcolumn)}";
                var canDeleteTableItem = !db.tm_eudatasourceitem.SELECT.WHERE.ByFilter(filter, req.datasourceid, req.sqlcolumn).Exists();

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------
                if (shouldDeleteTableAliasSet.Any())
                {
                    var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                    var datasourceJoinDtl = db.tm_eudatasourcejoin.SELECT.WHERE.ByKey(req.datasourceid).ORDER.By(nameof(tm_eudatasourcejoinDto.orderseq)).GetDtoList();
                    var removedTableAliases = TableJoinTreeUtil.CreateTableJoinTree(maintablealias, datasourceJoinDtl).GetRemovedTableAliases(shouldDeleteTableAliasSet);
                    var keyList = removedTableAliases.Select(x => new object[] { req.datasourceid, x }).ToList();
                    //EUCデータソース結合マスタ
                    db.tm_eudatasourcejoin.DELETE.WHERE.ByKeyList(keyList).Execute();
                }
                //データ存在の場合
                if (canDeleteTableItem)
                {
                    var tableItemDto = tableitemDtl.FirstOrDefault(x =>
                        x.sqlcolumn == req.sqlcolumn
                        && int.TryParse(x.itemid.Split(DaStrPool.C_UNDERLINE, StringSplitOptions.TrimEntries)[0], out var num) &&
                        num is >= tm_eutableitemDto.EDITABLE_ITEM_ID_MIN_PREFIX and <= tm_eutableitemDto.EDITABLE_ITEM_ID_MAX_PREFIX);

                    if (tableItemDto != null)
                    {
                        //EUCテーブル項目マスタ削除処理
                        db.tm_eutableitem.DeleteByKey(req.sqlcolumn, tableItemDto.upddttm);
                    }
                }

                //EUCデータソース項目マスタ削除処理
                db.tm_eudatasourceitem.DeleteByKey(req.datasourceid, req.sqlcolumn, req.upddttm);

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// 保存チェック処理
        /// </summary>
        private static bool SaveCheck(DaDbContext db, Enum編集区分 editkbn, SaveRequest req, DaResponseBase res)
        {
            //EUCデータソース項目マスタ
            //判断SQLカラム存在の場合
            var datasourceitemdto = db.tm_eudatasourceitem.SELECT.WHERE.ByKey(req.datasourceid, req.sqlcolumn).GetDto();
            if (datasourceitemdto != null && (editkbn == Enum編集区分.新規 || datasourceitemdto.sqlcolumn != req.oldsqlcolumn))
            {
                var msg = DaMessageService.GetMsg(EnumMessage.E002003, "SQLカラム");
                res.SetServiceError(msg);
                return false;
            }

            var existTableItemDtl = db.tm_eutableitem.SELECT.SetSelectItems(nameof(tm_eutableitemDto.sqlcolumn), nameof(tm_eutableitemDto.itemid))
                .WHERE.ByFilter($"{nameof(tm_eutableitemDto.sqlcolumn)} = @{nameof(tm_eutableitemDto.sqlcolumn)} OR {nameof(tm_eutableitemDto.itemid)} = @{nameof(tm_eutableitemDto.itemid)}",
                    req.sqlcolumn, req.itemid)
                .GetDtoList();

            //EUCテーブル項目マスタ
            foreach (var dto in existTableItemDtl)
            {
                if (dto.sqlcolumn.Equals(req.sqlcolumn, StringComparison.OrdinalIgnoreCase)
                     && (editkbn == Enum編集区分.新規 || dto.sqlcolumn != req.oldsqlcolumn))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "SQLカラム");
                    res.SetServiceError(msg);
                    return false;
                }

                if (dto.itemid.Equals(req.itemid, StringComparison.OrdinalIgnoreCase)
                     && (editkbn == Enum編集区分.新規 || (dto.sqlcolumn != req.oldsqlcolumn && dto.sqlcolumn != req.sqlcolumn)))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "項目ID");
                    res.SetServiceError(msg);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// EUCテーブル項目情報を取得
        /// </summary>
        private tm_eutableitemDto GetTableItem(DaDbContext db, string sqlcolumn)
        {
            return db.tm_eutableitem.GetDtoByKey(sqlcolumn);
        }

        /// <summary>
        /// EUCデータソース結合マスタを更新
        /// </summary>
        /// <param name="db"></param>
        /// <param name="req"></param>
        /// <param name="maintablealias"></param>
        private void UpdateDatasourcejoin(DaDbContext db, SaveRequest req, string maintablealias)
        {
            if (!maintablealias.Equals(req.tablealias, StringComparison.OrdinalIgnoreCase))
            {
                var tablejoinDto = DaEucBasicService.GetTableJoinDto(db, req.tablealias, maintablealias);
                if (tablejoinDto == null)
                {
                    var canJoinTableDto = TableJoinTreeUtil.GetCanJoinTableDtl(db, maintablealias)
                        .FirstOrDefault(x => x.tablealias == req.tablealias);
                    tablejoinDto = DaEucBasicService.GetTableJoinDto(db, req.tablealias, canJoinTableDto?.kanrentablealias);
                }
                else
                {
                    var singleKeyList = new List<object[]> { new object[] { req.datasourceid, req.tablealias } };
                    //EUCデータソース結合マスタ
                    var tableJoinSingleDtl = Converter.GetDatasourceJoinSingleDtl(req.datasourceid, tablejoinDto);
                    //EUCデータソース結合マスタを更新
                    db.tm_eudatasourcejoin.UPDATE.WHERE.ByKeyList(singleKeyList).Execute(tableJoinSingleDtl); //差分更新
                }
            }
        }

        /// <summary>
        /// SQLColumn,検索条件SQLのチェック
        /// </summary>
        private DaResponseBase CheckSql(DaDbContext db, string sqlcolumn)
        {
            var res = new DaResponseBase();
            if (!string.IsNullOrEmpty(sqlcolumn))
            {
                var ret = DaEucService.CheckItemSQL(db, sqlcolumn);
                if (ret != null)
                {
                    res.SetServiceError(ret);
                    return res;
                }
            }
            return res;
        }
    }
}