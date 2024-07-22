// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: SQL解析ツール
//             共通ツール
// 作成日　　: 2023.10.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using TSQL;
using TSQL.Elements;
using TSQL.Expressions;
using TSQL.Statements;
using TSQL.Tokens;

namespace BCC.Affect.Service.Common;

public static class SqlParseUtil
{
    /// <summary>
    /// SQLのSELECT文の解析
    /// </summary>
    public static SelectSqlItem ParseSelectSql(DaDbContext db, string sql)
    {
        //チェック
        var stmt = CheckSelectSql(db, sql);

        //selectパート
        var selectItems = stmt.Select.Columns.Select(x => new SelectPartItem(x)).ToList();
        //selectコメント
        var selectComments = stmt.Select.Tokens.Where(x => x.IsComment())
            .Select(x => x.AsComment)
            .Where(x => !string.IsNullOrEmpty(x?.Comment))
            .ToList();

        if (stmt.Where == null) return new SelectSqlItem(selectItems, stmt.From?.BeginPosition ?? stmt.Select.EndPosition + 1, selectComments);

        //whereパート
        var whereItems = ParseWherePartItems(stmt.Where.Tokens);
        //whereコメント
        var whereComments = stmt.Where.Tokens.Where(x => x.IsComment())
            .Select(x => x.AsComment)
            .Where(x => !string.IsNullOrEmpty(x?.Comment))
            .ToList();
        return new SelectSqlItem(selectItems, stmt.From?.BeginPosition ?? stmt.Select.EndPosition + 1, selectComments, whereItems, whereComments);
    }

    /// <summary>
    /// SQLの有効性のチェック
    /// </summary>
    private static TSQLSelectStatement CheckSelectSql(DaDbContext db, string sql)
    {
        if (string.IsNullOrEmpty(sql)) throw new ArgumentException("SQL文は空です。");
        var tsqlStatements = TSQLStatementReader.ParseStatements(sql, includeWhitespace: true);
        if (tsqlStatements is not { Count: 1 }) throw new Exception("SQL文の解析に失敗しました。");
        var tsqlStatement = tsqlStatements[0];
        if (tsqlStatement?.Type != TSQLStatementType.Select) throw new Exception("このSQL文はクエリー文ではありません。");
        var stmt = tsqlStatement.AsSelect;
        var explainSql = stmt.Where?.BeginPosition > 0 && stmt.Where.Tokens.Any(x => x.Type == TSQLTokenType.Variable)
            ? $"EXPLAIN {sql[..stmt.Where.BeginPosition]}"
            : $"EXPLAIN {sql}";
        //explain SQLの実行
        DaDbUtil.GetDataTable(db, explainSql);
        return stmt;
    }

    /// <summary>
    /// where条件の解析
    /// </summary>
    private static List<WherePartItem> ParseWherePartItems(IEnumerable<TSQLToken> whereTokens)
    {
        var wherePartItems = new List<WherePartItem>();

        var tokensExcludeComments = whereTokens.Where(x => !x.IsComment()).ToList();

        var indexedTokensExcludeComments = tokensExcludeComments.Select((value, index) => new { Value = value, Index = index }).ToList();

        //すべての変数とそのインデックス
        var variables = indexedTokensExcludeComments.Where(x => x.Value.Type == TSQLTokenType.Variable).ToList();

        //keywords
        var keywords = indexedTokensExcludeComments.Where(x =>
            x.Value.Type == TSQLTokenType.Keyword
            && x.Index + 2 < tokensExcludeComments.Count
            && tokensExcludeComments[x.Index + 2].Type == TSQLTokenType.Variable).ToList();

        //betweenとそのインデックスで始まるすべての変数
        var betweens = keywords.Where(x => nameof(TSQLKeywords.BETWEEN).Equals(x.Value.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var betweenVariableIndexs in betweens.Select(betweenToken => variables.Where(x => x.Index > betweenToken.Index)
                     .OrderBy(x => x.Index).Take(2).ToList()))
        {
            variables = variables.Where(x => !betweenVariableIndexs.Select(v => v.Index).Contains(x.Index)).ToList();
            wherePartItems.Add(new WherePartItem(betweenVariableIndexs.Select(x => x.Value.AsVariable).ToList()));
        }

        //likeとそのインデックスで始まるすべての変数
        var likes = keywords.Where(x => nameof(TSQLKeywords.LIKE).Equals(x.Value.Text, StringComparison.OrdinalIgnoreCase)).ToList();
        foreach (var likeVariableIndexs in likes.Select(likeToken => variables.Where(x => x.Index > likeToken.Index)
                     .OrderBy(x => x.Index).Take(1).ToList()))
        {
            variables = variables.Where(x => !likeVariableIndexs.Select(v => v.Index).Contains(x.Index)).ToList();
            wherePartItems.Add(new WherePartItem(likeVariableIndexs.Select(x => x.Value.AsVariable).ToList(), true));
        }

        wherePartItems.AddRange(variables.Select(x => new WherePartItem(x.Value.AsVariable)));
        wherePartItems = wherePartItems.OrderBy(x => x.EndPosition).ToList();

        return wherePartItems;
    }

    /// <summary>
    /// 冗長な空白をすべて削除
    /// </summary>
    internal static string TrimAll(string? str)
    {
        if (string.IsNullOrEmpty(str)) return string.Empty;
        str = str.Replace(DaStrPool.CRLF, DaStrPool.SPACE)
            .Replace(DaStrPool.C_LF, DaStrPool.C_SPACE)
            .Replace(DaStrPool.C_CR, DaStrPool.C_SPACE)
            .Replace(DaStrPool.C_TAB, DaStrPool.C_SPACE);
        while (str.Contains($"{DaStrPool.C_SPACE}{DaStrPool.C_SPACE}"))
        {
            str = str.Replace($"{DaStrPool.C_SPACE}{DaStrPool.C_SPACE}", DaStrPool.SPACE);
        }

        return str.Trim();
    }
}

public class SelectSqlItem
{
    public readonly List<SelectPartItem> SelectPartItems;
    public readonly List<WherePartItem> WherePartItems;
    public readonly int SelectPartEnd;

    public SelectSqlItem(List<SelectPartItem> selectPartItems, int selectPartEnd, List<TSQLComment>? selectComments = null, List<WherePartItem>? wherePartItems = null,
        List<TSQLComment>? whereComments = null)
    {
        selectComments ??= new List<TSQLComment>();
        wherePartItems ??= new List<WherePartItem>();
        whereComments ??= new List<TSQLComment>();
        SetSelectItemsComments(selectPartItems, selectComments);
        SetWhereItemsComments(wherePartItems, whereComments);
        SelectPartItems = selectPartItems;
        SelectPartEnd = selectPartEnd;
        WherePartItems = wherePartItems;
    }

    private static void SetSelectItemsComments(List<SelectPartItem> selectItems, List<TSQLComment> comments)
    {
        if (!selectItems.Any()) return;

        var tableIdItemIdsDic = selectItems.GroupBy(x => x.tableId)
            .ToDictionary(group => group.Key, group => group.Where(x => !string.IsNullOrEmpty(x.itemId)).Select(x => x.itemId).ToHashSet());

        comments = comments.Where(x => !string.IsNullOrEmpty(x.Comment?.Trim())).ToList();

        if (!comments.Any())
        {
            selectItems.ForEach(x =>
            {
                SetItemId(x, tableIdItemIdsDic);
                x.itemComment = $"{SelectPartItem.TEMP_RYASYO_PREFIX}{DaStrPool.C_UNDERLINE}{x.itemId}";
            });
            return;
        }

        if (selectItems.Count == comments.Count)
        {
            for (var i = 0; i < selectItems.Count; i++)
            {
                var selectItem = selectItems[i];
                selectItem.itemComment = comments[i].Comment.Trim();
                SetItemId(selectItem, tableIdItemIdsDic);
            }

            return;
        }

        var commentsDic = comments.ToDictionary(x => x.BeginPosition, x => x.Comment.Trim());

        for (var i = selectItems.Count - 1; i >= 0; i--)
        {
            var selectItem = selectItems[i];
            var commentKey = commentsDic.Keys
                .Where(k => k > selectItem.endPosition)
                .DefaultIfEmpty(-1)
                .Min();

            SetItemId(selectItem, tableIdItemIdsDic);

            if (commentsDic.TryGetValue(commentKey, out var comment))
            {
                selectItem.itemComment = comment;
                commentsDic.Remove(commentKey);
            }
            else
            {
                selectItem.itemComment = $"{SelectPartItem.TEMP_RYASYO_PREFIX}{DaStrPool.C_UNDERLINE}{selectItem.itemId}";
            }
        }
    }

    private static void SetWhereItemsComments(List<WherePartItem> whereItems, List<TSQLComment> comments)
    {
        if (!whereItems.Any()) return;

        comments = comments.Where(x => !string.IsNullOrEmpty(x.Comment?.Trim())).ToList();

        if (!comments.Any())
        {
            whereItems.ForEach(x => { x.Comment = $"{WherePartItem.TEMP_RYASYO_PREFIX}{DaStrPool.C_UNDERLINE}{x.VariableStr.Replace(DaStrPool.AT, string.Empty)}"; });
            return;
        }

        var commentsDic = comments.ToDictionary(x => x.BeginPosition, x => x.Comment.Trim());

        for (var i = whereItems.Count - 1; i >= 0; i--)
        {
            var whereItem = whereItems[i];
            var commentKey = commentsDic.Keys
                .Where(k => k > whereItem.EndPosition)
                .DefaultIfEmpty(-1)
                .Min();

            if (commentsDic.TryGetValue(commentKey, out var comment))
            {
                whereItem.Comment = comment;
                commentsDic.Remove(commentKey);
            }
            else
            {
                whereItem.Comment = $"{WherePartItem.TEMP_RYASYO_PREFIX}{DaStrPool.C_UNDERLINE}{whereItem.VariableStr.Replace(DaStrPool.AT, string.Empty)}";
            }
        }
    }

    private static void SetItemId(SelectPartItem selectPartItem, IReadOnlyDictionary<string, HashSet<string>> tableIdItemIdsDic)
    {
        if (!string.IsNullOrEmpty(selectPartItem.itemId)) return;
        var prefix = string.IsNullOrEmpty(selectPartItem.tableId) ? SelectPartItem.SQL_ITEM_ID_PREFIX : selectPartItem.tableId;
        selectPartItem.itemId = GetNextPrefixedId(prefix, tableIdItemIdsDic[selectPartItem.tableId]);
    }

    private static string GetNextPrefixedId(string prefix, ISet<string> existIds)
    {
        var n = existIds.Count + 1;
        var nextId = $"{prefix}{n.ToString().PadLeft(3, '0')}";
        while (existIds.Contains(nextId))
        {
            ++n;
            nextId = $"{prefix}{n.ToString().PadLeft(3, '0')}";
        }

        existIds.Add(nextId);
        return nextId;
    }
}

public class SelectPartItem
{
    public const string TEMP_RYASYO_PREFIX = "項目";
    public const string SQL_ITEM_ID_PREFIX = "SQL";
    public string tableId { get; } = string.Empty;
    public readonly string itemName;
    public string itemId { get; set; }
    public string itemComment { get; set; }
    public readonly int beginPosition;
    public readonly int endPosition;

    public SelectPartItem(TSQLSelectColumn column)
    {
        beginPosition = column.BeginPosition;
        endPosition = column.EndPosition;
        itemComment = string.Empty;
        itemId = column.ColumnAlias?.Text ?? string.Empty;
        switch (column.Expression.Type)
        {
            case TSQLExpressionType.Column:
            {
                tableId = column.Expression.AsColumn.TableReference?[0].Text ?? string.Empty;
                itemName = column.Expression.AsColumn.Column.Text;
                break;
            }
            case TSQLExpressionType.Subquery:
            {
                itemName = string.Join(string.Empty, column.Expression.AsSubquery.Tokens.Select(x => x.Text));
                break;
            }
            case TSQLExpressionType.Case:
                itemName = string.Join(string.Empty, column.Expression.AsCase.Tokens.Select(x => x.Text));
                break;
            case TSQLExpressionType.Multicolumn:
                throw new Exception("「SELECT * ...」や「SELECT t.* ...」のようなSQLはサポートされていません。");
            //todo others
            /*case TSQLExpressionType.Function:
                break;
            case TSQLExpressionType.Variable:
                break;
            case TSQLExpressionType.Operation:
                break;
            case TSQLExpressionType.Grouped:
                break;
            case TSQLExpressionType.Constant:
                break;
            case TSQLExpressionType.Logical:
                break;
            case TSQLExpressionType.VariableAssignment:
                break;
            case TSQLExpressionType.ValueAsType:
                break;
            case TSQLExpressionType.Null:
                break;
            case TSQLExpressionType.DuplicateSpecification:
                break;*/
            default:
                itemName = string.Join(string.Empty, column.Expression.Tokens.Select(x => x.Text));
                break;
        }

        itemName = SqlParseUtil.TrimAll(itemName);
    }

    public override string ToString()
    {
        var tableIdPart = string.IsNullOrEmpty(tableId) ? string.Empty : $"{tableId}{DaStrPool.C_DOT}";
        var asPart = string.IsNullOrEmpty(itemId) ? string.Empty : $"AS {itemId}";
        var commentPart = string.IsNullOrEmpty(itemComment) ? string.Empty : $"/* {itemComment} */";
        return SqlParseUtil.TrimAll($"{tableIdPart}{itemName} {asPart} {commentPart}");
    }
}

public class WherePartItem
{
    public const string TEMP_RYASYO_PREFIX = "条件";
    private readonly List<TSQLVariable> Variables;
    public readonly bool LikeFlg;
    public string Comment { get; set; }
    public bool RangeFlg => Variables is { Count: 2 };
    public string VariableStr => string.Join(DaStrPool.C_COMMA, Variables.Select(x => x.Text));
    public int EndPosition => Variables.Any() ? Variables[^1].EndPosition : -1;

    public WherePartItem(List<TSQLVariable> variables, bool likeFlg = false, string? comment = null)
    {
        Variables = variables;
        LikeFlg = likeFlg;
        Comment = comment ?? string.Empty;
    }

    public WherePartItem(TSQLVariable variable, bool likeFlg = false, string? comment = null)
    {
        Variables = new List<TSQLVariable> { variable };
        LikeFlg = likeFlg;
        Comment = comment ?? string.Empty;
    }

    public override string ToString()
    {
        var commentPart = string.IsNullOrEmpty(Comment) ? string.Empty : $"/* {Comment} */";
        return SqlParseUtil.TrimAll($"{Variables[^1].Text} {commentPart}");
    }
}