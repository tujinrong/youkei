// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 検索条件編集(固定)
//             サービス処理
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.Common;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00106D
{
    [DisplayName("検索条件編集(固定)")]
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
                //EUCデータソース項目マスタ
                var sqlColumnList = db.tm_eudatasourceitem.SELECT.SetSelectItems(nameof(tm_eudatasourceitemDto.sqlcolumn)).WHERE.ByKey(req.datasourceid).GetDtoList()
                    .Where(x => !x.sqlcolumn.StartsWith(DaStrPool.C_AT))
                    .Select(x => x.sqlcolumn)
                    .ToList();
                //EUCテーブル項目マスタ
                var tableItemDtl = db.tm_eutableitem.SELECT.WHERE.ByKeyList(sqlColumnList).ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList();

                //-------------------------------------------------------------
                //２.データ加工処理
                //-------------------------------------------------------------
                //項目大分類リスト
                res.itemdaibunruilist = Wraper.GetItemDaibunruiVMList(tableItemDtl);
                //ドロップダウンリスト(固定検索条件区分)
                res.selectorlist = EucConstant.FIXED_JYOKEN_KBN_OPTIONS;

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
                    return CheckSql(db, req.sqlcolumn);
                }

                //条件ラベル重複チェック
                if (!CheckJyokenLabel(db, req.datasourceid, req.jyokenlabel))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "条件名");
                    res.SetServiceError(msg);
                    return res;
                }

                //-------------------------------------------------------------
                //２.データ取得
                //-------------------------------------------------------------
                //EUCテーブル項目情報を取得
                var tableItemDto = GetTableItem(db, req.sqlcolumn);
                //EUCデータソース検索マスタから最大条件IDを取得
                var maxJyokenId = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKey(req.datasourceid).GetMax<int>(nameof(tm_eudatasourcekensakuDto.jyokenid));

                //-------------------------------------------------------------
                //３.データ加工処理
                //-------------------------------------------------------------
                var dto = Converter.GetAddDto(req, tableItemDto, ++maxJyokenId);

                //-------------------------------------------------------------
                //４.DB更新処理
                //-------------------------------------------------------------
                //EUCデータソース検索マスタを登録
                db.tm_eudatasourcekensaku.INSERT.Execute(dto);

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
                //１.チェック処理
                //-------------------------------------------------------------
                // SQLColumn,検索条件SQLのチェック
                if (req.checkflg)
                {
                    return CheckSql(db, req.sqlcolumn);
                }

                //条件ラベル重複チェック
                if (!CheckJyokenLabel(db, req.datasourceid, req.jyokenlabel, req.jyokenid))
                {
                    var msg = DaMessageService.GetMsg(EnumMessage.E002003, "条件名");
                    res.SetServiceError(msg);
                    return res;
                }

                //既に使用されている固定条件チェック
                var tm_eudatasourcekensaku = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKey(req.datasourceid, req.jyokenid).GetDto();
                if (tm_eudatasourcekensaku.jyokenkbn == Enum検索条件区分.固定条件 && req.jyokenkbn != Enum検索条件区分.固定条件) 
                {
                    string[] itemNames = new string[] { nameof(tm_eurptkensakuDto.datasourceid), nameof(tm_eurptkensakuDto.jyokenid), nameof(tm_eurptkensakuDto.jyokenkbn) };
                    List<object[]> valuesList = new() { new object[] { req.datasourceid, req.jyokenid, DaConvertUtil.EnumToStr(Enum検索条件区分.固定条件) } };
                    var isExist = db.tm_eurptkensaku.SELECT.WHERE.ByItemList(itemNames, valuesList).Exists();
                    if (isExist)
                    {
                        var msg = DaMessageService.GetMsg(EnumMessage.E002003, "固定条件");
                        res.SetServiceError(msg);
                        return res;
                    }
                }
                
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
                //EUCデータソース検索マスタ
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
                res.sql = Converter.GetConditionSql(tableItemDto, req.value); //SQL

                //正常返し
                return res;
            });
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

            //EUCデータソース検索マスタ
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