// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(通常)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;
using TSQL;

namespace BCC.Affect.Service.AWEU00105D
{
    [DisplayName("検索条件編集(通常)")]
    public class Service : CmServiceBase
    {
        [DisplayName("初期化処理")]
        public InitResponse Init(InitRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new InitResponse();

                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //年度ロップダウンリスト
                res.toshilist = DaNameService.GetNameList(db, EnumNmKbn.年度範囲区分);
                //検索区分ダウンリスト
                res.kensakukbnlist = DaNameService.GetSelectorList(db, EnumNmKbn.検索区分,Enum名称区分.名称);
                //データソースとプロシージャがシーンを共有する。プロシージャには datasourceid がありません。年度を返すだけです
                if (string.IsNullOrEmpty(req.datasourceid) )
                {
                    return res;
                }
                //EUCデータソース項目マスタ
                var sqlColumnList = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Where(x => !x.sqlcolumn.StartsWith(DaStrPool.C_AT))
                    .Select(x => x.sqlcolumn)
                    .ToList();

                //EUCテーブル項目マスタ
                var tableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(sqlColumnList).ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList();
                //項目名称を取得
                var itemNameDtl = DaEucBasicService.GetTableItemNameDtl(db);

                //マスタsqlを取得
                var sql = GetMasterSql(itemNameDtl);
                //マスタデータを取得
                var rows = DaDbUtil.GetDataTable(db, sql).Rows;

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //項目大分類リスト
                res.itemdaibunruilist = Wraper.GetItemDaibunruiVMList(tableItemDtl);
                //コントロールドロップダウンリスト
                res.selectorlist = EucConstant.CONTROL_OPTIONS;
                //マスタリスト
                res.masterlist = Wraper.GetMasterVMList(db, itemNameDtl, rows);

                //正常返し
                return res;
            });
        }

        [DisplayName("検索処理")]
        public SearchResponse Search(SearchRequest req)
        {
            return Nolock(req, db =>
            {
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUCデータソース検索マスタ
                var jyokenDto = db.tm_eudatasourcekensaku.GetDtoByKey(req.datasourceid, req.jyokenid);
                //EUCテーブル項目情報を取得
                var tableItemDto = GetTableItem(db, jyokenDto.sqlcolumn);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                var res = Wraper.GetSearchItem(tableItemDto, jyokenDto);

                //関連チェック
                const string filter =
                    $"{nameof(tm_eurptkensakuDto.datasourceid)} = @{nameof(tm_eurptkensakuDto.datasourceid)} " +
                    $"AND {nameof(tm_eurptkensakuDto.jyokenid)} = @{nameof(tm_eurptkensakuDto.jyokenid)} ";

                //EUC帳票検索マスタ
                var isExist = db.tm_eurptkensaku.SELECT.WHERE.ByFilter(filter, req.datasourceid, req.jyokenid).Exists();
                if (isExist)
                {
                    res.shiyoFlg = true;
                }

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
                if (req.checkflg)
                {
                    return CheckKodororu(db, req);
                }

                //条件名重複チェック
                if (!CheckJyokenLabel(db, req.datasourceid, req.jyokenlabel))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "検索条件名");
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //EUCテーブル項目情報を取得
                var tableItemDto = GetTableItem(db, req.sqlcolumn);
                //EUCデータソース検索マスタ
                var maxJyokenId = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKey(req.datasourceid).GetMax<int>(nameof(tm_eudatasourcekensakuDto.jyokenid));
                
                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var dto = Converter.GetAddDto(req, tableItemDto, ++maxJyokenId);
                
                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                db.tm_eudatasourcekensaku.INSERT.Execute(dto);

                //正常返し
                return res;
            });
        }

        [DisplayName("選択条件")]
        public SearchJokenDetailResponse SearchJokenDetail(SearchJokenDetailRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SearchJokenDetailResponse();
                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //選択情報を取得する

                if (req.controlkbn != null && req.controlkbn == (int)Enumコントロール.選択)
                {
                    //選択情報を取得する
                    res.selectlist = Wraper.GetReportAddJokenVm(db, req);
                }
                if (req.controlkbn != null && req.controlkbn == (int)Enumコントロール.日付入力)
                {
                    //日付情報を取得する
                    List<DaSelectorModel> selectlist = new List<DaSelectorModel>
                    {
                        new DaSelectorModel { value = "NENDOF", label = "年度開始日" },
                        new DaSelectorModel { value = "NENDOT", label = "年度終了日" },
                        new DaSelectorModel { value = "TODAY",  label = "システム日付" }
                    };
                    res.selectlist = selectlist;
                }
                if (req.controlkbn != null && req.controlkbn == (int)Enumコントロール.日付範囲)
                {
                    //日付範囲情報を取得する
                    List<DaSelectorModel> selectlist = new List<DaSelectorModel>
                    {
                        new DaSelectorModel { value = "NENDOF",  label = "年度開始日" },
                        new DaSelectorModel { value = "MONTHF",  label = "当月開始日" }
                    };
                    res.selectlist = selectlist;
                }
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
                //１.チェック処理
                //-------------------------------------------------------------
                if (req.checkflg)
                {
                    return CheckKodororu(db, req);
                }

                //条件名重複チェック
                if (!CheckJyokenLabel(db, req.datasourceid, req.jyokenlabel, req.jyokenid))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "検索条件名");
                    res.SetServiceError(msg);
                    return res;
                }

                //排他チェックTODOi

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //EUCテーブル項目情報を取得
                var tableItemDto = GetTableItem(db, req.sqlcolumn);

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var dto = Converter.GetUpdateDto(req, tableItemDto);
                
                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                db.tm_eudatasourcekensaku.UpdateDto(dto, req.upddttm!.Value);

                //正常返し
                return res;
            });
        }

        [DisplayName("削除処理")]
        public DaResponseBase Delete(DeleteRequest req)
        {
            return Transction(req, db =>
            {
                var res = new DaResponseBase();

                //-------------------------------------------------------------
                //１.チェック処理
                //-------------------------------------------------------------
                //関連チェック
                const string filter =
                    $"{nameof(tm_eurptkensakuDto.datasourceid)} = @{nameof(tm_eurptkensakuDto.datasourceid)} " +
                    $"AND {nameof(tm_eurptkensakuDto.jyokenid)} = @{nameof(tm_eurptkensakuDto.jyokenid)} " +
                    $"AND {nameof(tm_eurptkensakuDto.jyokenkbn)} = @{nameof(tm_eurptkensakuDto.jyokenkbn)}";

                //EUC帳票検索マスタ
                var isExist = db.tm_eurptkensaku.SELECT.WHERE.ByFilter(filter, req.datasourceid, req.jyokenid, req.jyokenkbn).Exists();
                if (isExist)
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E014001, "検索条件");
                    res.SetServiceError(msg);
                    return res;
                }

                //排他チェックTODOi

                //-------------------------------------------------------------
                //２.DB更新処理
                //-------------------------------------------------------------

                //EUCデータソース検索マスタ
                db.tm_eudatasourcekensaku.DeleteByKey(req.datasourceid, req.jyokenid, req.upddttm);

                //正常返し
                return res;
            });
        }

        [DisplayName("条件SQL取得")]
        public SqlResponse GetSql(SqlRequest req)
        {
            return Nolock(req, db =>
            {
                var res = new SqlResponse();
                //-------------------------------------------------------------
                //１.データ取得
                //-------------------------------------------------------------
                //EUCテーブル項目情報を取得
                var tableItemDto = GetTableItem(db, req.sqlcolumn);

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                res.sql = Converter.GetConditionSql(tableItemDto, req.controlkbn); //SQL

                //正常返し
                return res;
            });
        }

        /// <summary>
        /// マスタsqlを取得
        /// </summary>
        public static string GetMasterSql(IEnumerable<tm_eutableitemnameDto> itemNameDtl)
        {
            var valueTuples = itemNameDtl.Where(x => !string.IsNullOrEmpty(x.maincd) || !string.IsNullOrEmpty(x.subcd))
                .Select(x => (x.tablenm, x.maincd, x.subcd))
                .Distinct()
                .ToList();

            var sqlList = new List<string>(valueTuples.Count);
            foreach (var (tablenm, maincd, subcd) in valueTuples)
            {
                var arg1 = $"'{string.Join("','", new HashSet<string?> { maincd, subcd }.Where(s => !string.IsNullOrEmpty(s)))}'";
                sqlList.Add(string.Format(GetSql(), $"'{tablenm}'", arg1));
            }

            return string.Join($"{DaStrPool.C_LF}{nameof(TSQLKeywords.UNION)}{DaStrPool.C_LF}", sqlList);
        }

        /// <summary>
        /// 条件ラベル重複チェック
        /// </summary>
        private static bool CheckJyokenLabel(DaDbContext db, string datasourceId, string jyokenLabel, int? jyokenid = null)
        {
            var filter = jyokenid == null
                ? $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                $"AND {nameof(tm_eudatasourcekensakuDto.jyokenlabel)} = @{nameof(tm_eudatasourcekensakuDto.jyokenlabel)}"
                : $"{nameof(tm_eudatasourcekensakuDto.datasourceid)} = @{nameof(tm_eudatasourcekensakuDto.datasourceid)} " +
                $"AND {nameof(tm_eudatasourcekensakuDto.jyokenlabel)} = @{nameof(tm_eudatasourcekensakuDto.jyokenlabel)} " +
                $"AND {nameof(tm_eudatasourcekensakuDto.jyokenid)} != {jyokenid}";
            return !db.tm_eudatasourcekensaku.SELECT.WHERE.ByFilter(filter, datasourceId, jyokenLabel).Exists();
        }

        /// <summary>
        /// EUCテーブル項目情報を取得
        /// </summary>
        private tm_eutableitemDto GetTableItem(DaDbContext db, string sqlcolumn)
        {
            var tableitemDto = DaEucBasicService.GetTableItemDtoBySqlColumn(db, sqlcolumn);
            if (tableitemDto == null)
            {
                tableitemDto = db.tm_eutableitem.GetDtoByKey(sqlcolumn);
            }
            return tableitemDto;
        }

        /// <summary>
        /// sqlを取得
        /// </summary>
        private static string GetSql()
        {
            string sql = @"
            SELECT c.relname AS tablenm,
                   a.attname AS columnnm,
                   col_description(a.attrelid, a.attnum) AS columncomment
            FROM pg_catalog.pg_class c
                JOIN pg_catalog.pg_attribute a ON a.attrelid = c.oid
                JOIN pg_catalog.pg_namespace n ON c.relnamespace = n.oid
            WHERE c.relname = {0}
              AND a.attname IN ({1})
              AND n.nspname = 'public' 
              AND c.relkind = 'r'".Trim();
            return sql;  
        }

        /// <summary>
        /// 検証コントロール
        /// </summary>
        private DaResponseBase CheckKodororu(DaDbContext db, SaveRequest req)
        {
            var res = new DaResponseBase();
            var ret = DaEucService.CheckItemSQL(db, req.sqlcolumn);
            if (ret != null)
            {
                res.SetServiceError(ret);
                return res;
            }
            if (!String.IsNullOrEmpty(req.syokiti) && !Converter.IsParameterValid(req.controlkbn, req.syokiti))
            {
                var msg = DaMessageService.GetMsg(EnumMessage.ITEM_NOTEQUAL_ERROR, $"{req.syokiti}がコントロールのデータ種類");
                res.SetServiceError(msg);
                return res;
            }
            return res;
        }
    }
}