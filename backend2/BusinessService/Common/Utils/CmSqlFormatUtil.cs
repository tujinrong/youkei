// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: SQLフォーマッタ
//
// 作成日　　: 2023.09.19
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using SqlFormatterLib;
using SqlFormatterLib.Formatters;
using SqlFormatterLib.Interfaces;
using SqlFormatterLib.Parsers;
using SqlFormatterLib.Tokenizers;

namespace BCC.Affect.Service;

public static class CmSqlFormatUtil
{
    public static string Format(string sql, bool isFunction = false, FormatOption formatOption = FormatOption.Standard)
    {
        //SQLタガー
        var tokenizedSql = new TSqlStandardTokenizer().TokenizeSQL(sql, sql.Length);
        //SQL解析
        var parsedSql = new TSqlStandardParser().ParseSQL(tokenizedSql);
        //SQLフォーマッタ
        var defaultFormatter = GetDefaultFormatter(formatOption);

        var formatedSql = defaultFormatter.FormatSQLTree(parsedSql);

        if (!formatedSql.StartsWith(MessagingConstants.FormatErrorDefaultMessage, StringComparison.OrdinalIgnoreCase)) return NewLineAfterFunctionName(formatedSql, isFunction);

        //todo 複雑なストアドプロシージャはフォーマットエラーが発生する可能性があります
        foreach (var option in Enum.GetValues<FormatOption>().Where(x => x != formatOption))
        {
            formatedSql = GetDefaultFormatter(option).FormatSQLTree(parsedSql);
            if (!formatedSql.StartsWith(MessagingConstants.FormatErrorDefaultMessage, StringComparison.OrdinalIgnoreCase))
            {
                return NewLineAfterFunctionName(formatedSql, isFunction);
            }
        }

        return Utils.TrimEachLineEnd(NewLineAfterFunctionName(sql, isFunction));
    }

    /// <summary>
    /// 関数名の後に改行を追加する
    /// </summary>
    private static string NewLineAfterFunctionName(string sql, bool isFunction = true)
    {
        return isFunction ? sql.Insert(sql.IndexOf(DaStrPool.C_LEFT_BRACKET_HALF), Environment.NewLine) : sql;
    }

    private static ISqlTreeFormatter GetDefaultFormatter(FormatOption formatOption = FormatOption.Standard)
    {
        return formatOption switch
        {
            FormatOption.NoFormat => GetIdentityFormatter(),
            FormatOption.Minify => GetObfuscatingFormatter(),
            _ => GetStandardFormatter()
        };
    }

    private static ISqlTreeFormatter GetStandardFormatter(TSqlStandardFormatterOptions? formatterOptions = null)
    {
        return new TSqlStandardFormatter(formatterOptions ?? TSqlStandardFormatterOptions.DEFAULT_OPTIONS);
    }

    private static ISqlTreeFormatter GetIdentityFormatter(bool htmlColoring = false)
    {
        return new TSqlIdentityFormatter(htmlColoring);
    }

    private static ISqlTreeFormatter GetObfuscatingFormatter(bool randomizeCase = false, bool randomizeColor = false, bool randomizeLineLength = false, bool preserveComments = false,
        bool subtituteKeywords = false)
    {
        return new TSqlObfuscatingFormatter(randomizeCase, randomizeColor, randomizeLineLength, preserveComments, subtituteKeywords);
    }
}

public enum FormatOption
{
    Standard,
    NoFormat,
    Minify
}