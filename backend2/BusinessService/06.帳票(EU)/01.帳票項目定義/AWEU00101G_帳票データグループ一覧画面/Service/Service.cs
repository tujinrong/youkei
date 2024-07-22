// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票データグループ一覧
//             サービス処理
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00101G
{
    [DisplayName("帳票データグループ一覧")]
    public class Service : CmServiceBase
    {
        #region 一覧画面

        //検索処理
        private const string PROC_NAME = "sp_aweu00101g_01";

        [DisplayName("初期化処理(一覧画面)")]
        public InitResponse Init(DaRequestBase req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //業務区分
                res.selectorlist = DaNameService.GetSelectorList(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理(一覧画面)")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //パラメータを取得
                var param = Converter.GetParameters(req);
                //検索実行
                var pageList = DaDbUtil.GetListData(db, PROC_NAME, param, req.pagenum, req.pagesize, req.orderby);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //設定総ページ数、総件数
                res.SetPageInfo(pageList.TotalCount, req.pagesize);
                //DB項目から画面項目に変換
                res.kekkalist = Wraper.GetSearchVMList(pageList.dataTable.Rows);

                //正常返し
                return res;
            });
        }

        #endregion

        #region 詳細画面テーブルタブ

        [DisplayName("初期化処理(データソース詳細)")]
        public InitDetailTabResponse InitDetailTab(InitDetailTabRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitDetailTabResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUCデータソースマスタ
                var datasourceDto = db.tm_eudatasource.GetDtoByKey(req.datasourceid);

                //EUCデータソース結合マスタ検索マスタを取得
                var datasourceTableDtl = db.tm_eudatasourcejoin.SELECT.SetSelectItems(nameof(tm_eudatasourcejoinDto.tablealias))
                    .WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Where(x => !x.tablealias.Equals(datasourceDto.maintablealias, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                //EUCデータソース項目マスタ検索マスタを取得
                var sqlColumn2UpddttmDic = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn), nameof(tm_eudatasourceitemDto.upddttm))
                    .WHERE.ByKey(req.datasourceid).GetDtoList()
                    .ToDictionary(x => x.sqlcolumn, x => x.upddttm, StringComparer.OrdinalIgnoreCase);

                //EUCテーブル項目マスタ検索マスタを取得
                var tablealias2ItemsDic = db.tm_eutableitem.SELECT.WHERE.ByKeyList(sqlColumn2UpddttmDic.Keys.ToList()).ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList()
                    .GroupBy(x => x.tablealias)
                    .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

                //データ統合
                var tableAlias2TableDtoDic = DaEucBasicService.GetTableDtl(db, tablealias2ItemsDic.Keys)
                    .ToDictionary(x => x.tablealias, x => x, StringComparer.OrdinalIgnoreCase);

                var tableAliasComparer = DatasourceTableAliasComparer.CreareIntance(db);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //データソースID
                res.datasourceid = req.datasourceid;
                //メインテーブル別名
                res.maintablealias = datasourceDto.maintablealias;
                //データソース名称
                res.datasourcenm = datasourceDto.datasourcenm;
                //更新日時
                res.upddttm = datasourceDto.upddttm;
                //業務
                res.gyoumu = DaNameService.GetCdNm(db, EnumNmKbn.EUC業務区分, Enum名称区分.名称, datasourceDto.gyoumucd);
                //メインテーブル
                res.maindata = Wraper.GetDatasourceMainTableVM(datasourceDto, tablealias2ItemsDic, tableAlias2TableDtoDic, sqlColumn2UpddttmDic);
                //結合テーブル
                res.joindata = Wraper.GetDatasourceTableVMList(datasourceTableDtl, tablealias2ItemsDic, tableAlias2TableDtoDic,
                                                    sqlColumn2UpddttmDic, EnumTableKbn.トランザクション, tableAliasComparer);
                //マスタテーブル
                res.masterdata = Wraper.GetDatasourceTableVMList(datasourceTableDtl, tablealias2ItemsDic, tableAlias2TableDtoDic,
                                                    sqlColumn2UpddttmDic, EnumTableKbn.マスタ, tableAliasComparer);
                //フリーテーブル
                res.freedata = Wraper.GetDatasourceTableVMList(datasourceTableDtl, tablealias2ItemsDic, tableAlias2TableDtoDic,
                                                    sqlColumn2UpddttmDic, EnumTableKbn.フリー, tableAliasComparer);
                //View
                res.viewdata = Wraper.GetDatasourceTableVMList(datasourceTableDtl, tablealias2ItemsDic, tableAlias2TableDtoDic,
                                                    sqlColumn2UpddttmDic, EnumTableKbn.VIEW, tableAliasComparer);

                //正常返し
                return res;
            });
        }

        [DisplayName("項目削除処理(テーブルタブ)")]
        public DaResponseBase DeleteItems(DeleteItemsRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                var deleteSqlColumnSet = req.deleteitemlist.Select(x => x.sqlcolumn).ToHashSet();
                if (req.checkflg)
                {
                    //削除前占有されているかどうかを確認する
                    var sqlVerifyMsg = CommonUtil.GetSqlColnumVerification(db, req.datasourceid, deleteSqlColumnSet);
                    if (!string.IsNullOrEmpty(sqlVerifyMsg))
                    {
                        res.SetServiceError(sqlVerifyMsg);
                        return res;
                    }
                    return res;
                }
                
                //datasourceid以外のdeleteSqlColumnSetクエリデータ
                const string filter = $"{nameof(tm_eudatasourceitemDto.datasourceid)} != @{nameof(tm_eudatasourceitemDto.datasourceid)} " +
                                    $"AND {nameof(tm_eudatasourceitemDto.sqlcolumn)} = ANY(@{nameof(tm_eudatasourceitemDto.sqlcolumn)})";
                //EUCデータソース項目マスタ
                var cantDeleteSqlColumnSet = db.tm_eudatasourceitem.SELECT.WHERE.ByFilter(filter, req.datasourceid, deleteSqlColumnSet.ToArray()).GetDtoList()
                    .Select(x => x.sqlcolumn)
                    .ToHashSet();

                //EUCデータソース項目マスタ
                var datasourceAllItemDtl = db.tm_eudatasourceitem.SELECT.WHERE.ByKey(req.datasourceid).GetDtoList();
                //データソースの全てSQLカラムリスト
                var datasourceAllSqlColumnList = datasourceAllItemDtl.Select(x => x.sqlcolumn).ToList();

                //EUCテーブル項目マスタ
                var tableitemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(datasourceAllSqlColumnList).GetDtoList();

                var canDeleteSqlColumnSet = deleteSqlColumnSet.Except(cantDeleteSqlColumnSet).ToHashSet();

                //削除SQLカラムリスト
                var deleteSqlColumnList = tableitemDtl.Where(x =>
                        canDeleteSqlColumnSet.Contains(x.sqlcolumn)
                        && int.TryParse(x.itemid.Split(DaStrPool.C_UNDERLINE, StringSplitOptions.TrimEntries)[0], out var num)
                        && num is >= tm_eutableitemDto.EDITABLE_ITEM_ID_MIN_PREFIX and <= tm_eutableitemDto.EDITABLE_ITEM_ID_MAX_PREFIX)
                    .Select(x => x.sqlcolumn)
                    .ToList();

                //テーブル別名(削除前)
                var beforeDeleteExistTableAliasSet = tableitemDtl.Select(x => x.tablealias).ToHashSet();
                //テーブル別名(削除後)
                var afterDeleteExistTableAliasSet = tableitemDtl.Where(x => !deleteSqlColumnSet.Contains(x.sqlcolumn)).Select(x => x.tablealias).ToHashSet();

                //SQLカラムリスト
                var currentExistDtl = datasourceAllItemDtl.Where(x => deleteSqlColumnSet.Contains(x.sqlcolumn)).ToList();
                //削除データソーステーブル別名
                var shouldDeleteTableAliasSet = beforeDeleteExistTableAliasSet.Except(afterDeleteExistTableAliasSet).ToHashSet();

                //-------------------------------------------------------------
                //２.チェック処理
                //-------------------------------------------------------------
                if (!Check(req.deleteitemlist, currentExistDtl))
                {
                    throw new AiExclusiveException();
                }

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                //すべての datasourceid をコレクションとして取得する
                var itemKeyList = deleteSqlColumnSet.Select(x => new object[] { req.datasourceid, x }).ToList();

                //EUCデータソース項目マスタを削除
                db.tm_eudatasourceitem.DELETE.WHERE.ByKeyList(itemKeyList).Execute();

                if (shouldDeleteTableAliasSet.Any())
                {
                    // 検索メインテーブル別名
                    var maintablealias = db.tm_eudatasource.GetDtoByKey(req.datasourceid).maintablealias;
                    //datasourceidを使用してEUCデータソース結合マスタを検索します 
                    var datasourceJoinDtl = db.tm_eudatasourcejoin.SELECT.WHERE.ByKey(req.datasourceid).ORDER.By(nameof(tm_eudatasourcejoinDto.orderseq)).GetDtoList();
                    var removedTableAliases = TableJoinTreeUtil.CreateTableJoinTree(maintablealias, datasourceJoinDtl).GetRemovedTableAliases(shouldDeleteTableAliasSet);
                    var keyList = removedTableAliases.Select(x => new object[] { req.datasourceid, x }).ToList();

                    //EUCデータソース結合マスタを削除
                    db.tm_eudatasourcejoin.DELETE.WHERE.ByKeyList(keyList).Execute();
                }

                if (deleteSqlColumnList.Any())
                {
                    //EUCテーブル項目マスタを削除
                    db.tm_eutableitem.DELETE.WHERE.ByKeyList(deleteSqlColumnList).Execute();
                }

                //正常返し
                return res;
            });
        }

        #endregion

        #region 詳細画面検索条件タブ



        [DisplayName("検索処理(詳細画面:検索条件タブ(通常))")]
        public SearchConditionTabResponse SearchConditionTab(SearchConditionTabRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchConditionTabResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                /// <summary>
                /// 検索条件フィルター(通常)
                /// </summary>
                string normalSearchFilter =
                     $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                     $"AND {nameof(tm_eudatasourcekensakuDto.jyokenkbn)} = @{nameof(tm_eudatasourcekensakuDto.jyokenkbn)}";

                //EUCデータソース検索マスタ
                var dtl = db.tm_eudatasourcekensaku.SELECT
                    .WHERE.ByFilter(normalSearchFilter, req.datasourceid, (int)Enum検索条件区分.通常条件)
                    .ORDER.By(nameof(tm_eudatasourcekensakuDto.jyokenid))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検索条件(通常)リスト
                res.conditionlist = Wraper.GetConditionVMList(dtl);

                //正常返し
                return res;
            });
        }

        #endregion

        #region 詳細画面その他条件タブ

        /// <summary>
        /// 検索条件検索処理(その他条件)
        /// </summary>
        private static readonly string OTHER_FILTER = "other";


        [DisplayName("検索処理(詳細画面:検索条件(その他条件))")]
        public SearchOtherConditionTabResponse SearchOtherConditionTab(SearchConditionTabRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchOtherConditionTabResponse();

                var fixeds = req.status == OTHER_FILTER ? $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                $"AND {nameof(tm_eudatasourcekensakuDto.jyokenkbn)} IN({string.Join(DaStrPool.C_COMMA, EucConstant.FIXED_JYOKEN_KBNS.Select(x => (int)x))})"
                : $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                $"AND {nameof(tm_eudatasourcekensakuDto.jyokenkbn)} = '{(int)Enum検索条件区分.固定条件}'";

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUCデータソース検索マスタ
                var dtl = db.tm_eudatasourcekensaku.SELECT
                    .WHERE.ByFilter(fixeds, req.datasourceid)
                    .ORDER.By(nameof(tm_eudatasourcekensakuDto.jyokenid))
                    .GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //検索条件(その他条件)リスト
                res.fixedconditionlist = Wraper.GetFixedConditionVMList(dtl);

                //正常返し
                return res;
            });
        }

        #endregion


        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //EUC帳票マスタ
                var eurptDtl = db.tm_eurpt.SELECT
                            .WHERE.ByFilter($"{nameof(tm_eurptDto.datasourceid)} = @{nameof(tm_eurptDto.datasourceid)}", req.datasourceid).GetDtoList();
                if (eurptDtl.Count != 0 || eurptDtl.Any())
                {
                    res.SetServiceError(EnumMessage.E014001, "データソース");
                    //異常返す
                    return res;
                }
                var isExist = db.tm_euyosikisyosai.SELECT.WHERE.ByItem(nameof(tm_euyosikisyosaiDto.datasourceid), req.datasourceid).Exists();
                if (isExist)
                {
                    throw new AiExclusiveException();
                }
                //EUCデータソースマスタ
                var dtoOld = db.tm_eudatasource.SELECT.WHERE.ByKey(req.datasourceid).GetDto();
                //排他チェック
                if (dtoOld == null || dtoOld.upddttm != req.upddttm)
                {
                    throw new AiExclusiveException();
                }

                //①データソースIdよりEUCデータソース項目マスタからSQLカラムリストを取得
                var deleteSqlColumnSet = db.tm_eudatasourceitem.SELECT.WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Select(x => x.sqlcolumn)
                    .ToHashSet();

                //datasourceid以外のdeleteSqlColumnSetクエリデータ
                const string filter =
                    $"{nameof(tm_eudatasourceitemDto.datasourceid)} != @{nameof(tm_eudatasourceitemDto.datasourceid)} " +
                    $"AND {nameof(tm_eudatasourceitemDto.sqlcolumn)} = ANY(@{nameof(tm_eudatasourceitemDto.sqlcolumn)})";

                //②　①のデータソースId以外　EUCデータソース項目マスタからSQLカラムを取得
                var cantDeleteSqlColumnSet = db.tm_eudatasourceitem.SELECT.WHERE.ByFilter(filter, req.datasourceid, deleteSqlColumnSet.ToArray()).GetDtoList()
                    .Select(x => x.sqlcolumn)
                    .ToHashSet();

                deleteSqlColumnSet.ExceptWith(cantDeleteSqlColumnSet);

                //EUCテーブル項目マスタを取得
                var itemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(deleteSqlColumnSet.ToList()).GetDtoList();

                //SQLカラムリストを取得
                var deleteSqlColumnList = itemDtl.Where(x => int.TryParse(x.itemid.Split(DaStrPool.C_UNDERLINE, StringSplitOptions.TrimEntries)[0], out var num) &&
                                num is >= tm_eutableitemDto.EDITABLE_ITEM_ID_MIN_PREFIX and <= tm_eutableitemDto.EDITABLE_ITEM_ID_MAX_PREFIX)
                    .Select(x => x.sqlcolumn)
                    .ToList();

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------

                //関連データを削除 
                //EUCデータソース検索マスタ
                db.tm_eudatasourcekensaku.DELETE.WHERE.ByKey(req.datasourceid).Execute();
                //EUCデータソース項目マスタ
                db.tm_eudatasourceitem.DELETE.WHERE.ByKey(req.datasourceid).Execute();
                //EUCデータソース結合マスタ
                db.tm_eudatasourcejoin.DELETE.WHERE.ByKey(req.datasourceid).Execute();
                if (deleteSqlColumnList.Any())
                {
                    //EUCテーブル項目マスタ
                    db.tm_eutableitem.DELETE.WHERE.ByKeyList(deleteSqlColumnList).Execute();
                }

                //EUCデータソースマスタ
                db.tm_eudatasource.DeleteByKey(req.datasourceid, req.upddttm);

                //正常返し
                return res;
            });
        }

        [DisplayName("保存処理")]
        public SaveResponse Save(SaveRequest req)
        {
            return Transction(req, db =>
            {
                var res = new SaveResponse();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //排他チェック
                //EUCデータソースマスタ
                var dtoOld = db.tm_eudatasource.SELECT.WHERE.ByKey(req.datasourceid).GetDto();
                if (dtoOld == null)
                {
                    throw new AiExclusiveException();
                }

                //データソース名称重複チェック
                const string filter =
                    $"{nameof(tm_eudatasourceDto.datasourcenm)} = @{nameof(tm_eudatasourceDto.datasourcenm)}";
                //EUCデータソースマスタ
                var dto = db.tm_eudatasource.SELECT.WHERE.ByFilter(filter, req.datasourcenm).GetDto();
                if (dto != null && dto.datasourceid != req.datasourceid)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "データソース名称");
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                dtoOld = Converter.GetDataSourceDto(dtoOld, req);

                //-------------------------------------------------------------
                //３.DB更新処理
                //-------------------------------------------------------------
                db.tm_eudatasource.UpdateDto(dtoOld, req.upddttm);
                //更新時刻はクエリ後に返されます（ページが更新されないため）
                var dtoNew = db.tm_eudatasource.SELECT.WHERE.ByKey(req.datasourceid).GetDto();
                if (dtoNew != null)
                {
                    res.upddttm = dtoNew.upddttm;
                }
                //正常返し
                return res;
            });
        }


        /// <summary>
        /// 排他チェック
        /// </summary>
        private static bool Check(IReadOnlyCollection<DeleteTableItemVM> deleteitemlist, IReadOnlyCollection<tm_eudatasourceitemDto> currentExistDtl)
        {
            return deleteitemlist.Count == currentExistDtl.Count && deleteitemlist.All(x => currentExistDtl.Any(c => c.sqlcolumn == x.sqlcolumn && c.upddttm == x.upddttm));
        }
    }
}