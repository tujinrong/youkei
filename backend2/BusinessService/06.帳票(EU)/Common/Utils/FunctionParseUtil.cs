// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 関数解析ツール
//             共通ツール
// 作成日　　: 2023.10.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using System.Text;
using System.Text.RegularExpressions;
using TSQL;
using TSQL.Tokens;

namespace BCC.Affect.Service.Common;

public static class FunctionParseUtil
{
    private const string FUNCTION_TAG = "FUNCTION";
    private const string FUNCTION_NAME_PATTERN = @$"{FUNCTION_TAG}\s+(\w+)";
    private const string FUNCTION_PREFIX_PATTERN = @"^\s*CREATE\s+OR\s+REPLACE";

    /// <summary>
    /// プロシージャの解析
    /// </summary>
    public static FunctionVM ParseFunction(DaDbContext db, string functionStatement, string? beforeFuncName = null, string? necessaryPrefix = null)
    {
        var functionName = CheckAndGetFuctionName(functionStatement, check: true, necessaryPrefix: necessaryPrefix);

        if (String.IsNullOrEmpty(functionName) )
        {
            throw new Exception("プロシージャの名前を入力してください");
        }
        if (functionName.Length > 50)
        {
            throw new Exception("プロシージャの名前は 50 文字を超えています。再入力してください。");
        }

        //存在チェック
        var needCheckFunctionName = !functionName.Equals(beforeFuncName, StringComparison.OrdinalIgnoreCase);
        if (needCheckFunctionName && DaEucBasicService.IsFunctionExists(db, functionName, necessaryPrefix: necessaryPrefix)) throw new Exception($"「{functionName}」という名前の関数はすでに存在します。");

        //関数の作成
        DaDbUtil.RunSql(db, functionStatement);

        var functionVm = DaEucBasicService.RefreshCacheThenGetFunctionByName(db, functionName, necessaryPrefix);
        if (functionVm == null) throw new Exception($"「{functionName}」という名前の関数の作成に失敗しました。");
        return functionVm;
    }

    /// <summary>
    /// パラメータ項目の表示名称を取得
    /// </summary>
    public static Dictionary<string, string> GetParamItemName(string functionStatement)
    {
        var dic = new Dictionary<string, string>();

        string parameterPattern = @"FUNCTION\s+(\w+)\s*\(([^)]+)\)";
        Match parameterMatch = Regex.Match(functionStatement, parameterPattern, RegexOptions.Singleline);

        if (parameterMatch.Success)
        {
            string parameterContent = parameterMatch.Groups[2].Value;

            parameterContent = parameterContent.Trim();
            string fieldPattern = @"\s*(\w+)\s+[\w\s]+,\s*--\s*(.+)|\s*(\w+)\s+[\w\s]+--\s*(.+)";
            Regex fieldRegex = new Regex(fieldPattern, RegexOptions.Multiline);
            MatchCollection fieldMatches = fieldRegex.Matches(parameterContent);

            foreach (Match match in fieldMatches)
            {
                if(match.Groups.Count > 2 && !string.IsNullOrEmpty(match.Groups[1].Value.Trim()))
                {
                    string paramName = match.Groups[1].Value.Trim();
                    string description = match.Groups[2].Value.Trim();
                    dic[paramName] = description;
                }
                else if (match.Groups.Count > 4)
                {
                    string paramName = match.Groups[3].Value.Trim();
                    string description = match.Groups[4].Value.Trim();
                    dic[paramName] = description;
                }
            }
        }

        return dic;
    }

    /// <summary>
    /// 結果項目の表示名称を取得
    /// </summary>
    public static Dictionary<string, string> GetReturnItemName(string functionStatement)
    {
        var dic = new Dictionary<string, string>();

        string returnsTablePattern = @"RETURNS TABLE\s*\(([^)]+)\)";
        Match returnsTableMatch = Regex.Match(functionStatement, returnsTablePattern, RegexOptions.Singleline);

        if (returnsTableMatch.Success)
        {
            string returnsTableContent = returnsTableMatch.Groups[1].Value;

            string fieldPattern = @"(\w+)\s+[\w\s\(\),]+\s+--(.+)";
            Regex fieldRegex = new Regex(fieldPattern, RegexOptions.Multiline);
            MatchCollection fieldMatches = fieldRegex.Matches(returnsTableContent);

            foreach (Match match in fieldMatches)
            {
                string paramName = match.Groups[1].Value.Trim();
                string description = match.Groups[2].Value.Trim();
                dic[paramName] = description;
            }
        }

        return dic;
    }

    public static string CheckAndGetFuctionName(string functionStatement, bool check = true, string? necessaryPrefix = null)
    {
        if (!check) return Regex.Match(functionStatement, FUNCTION_NAME_PATTERN, RegexOptions.IgnoreCase).Groups[1].Value;

        if (string.IsNullOrEmpty(functionStatement)) throw new ArgumentException("関数定義が空。");

        var tsqlStatements = TSQLStatementReader.ParseStatements(functionStatement, includeWhitespace: true);

        if (!tsqlStatements.Any()) throw new ArgumentException("関数定義の解析に失敗しました。");

        if (!CheckFunctionPrefix(tsqlStatements[0].Tokens))
        {
            throw new ArgumentException("関数定義は「CREATE OR REPLACE」で始めなければならない。");
        }

        var match = Regex.Match(functionStatement, FUNCTION_NAME_PATTERN, RegexOptions.IgnoreCase);
        if (!match.Success) throw new ArgumentException("関数定義の解析に失敗しました。");

        var functionName = match.Groups[1].Value;
        if (!string.IsNullOrEmpty(necessaryPrefix) && !functionName.StartsWith(necessaryPrefix, StringComparison.OrdinalIgnoreCase))
            throw new ArgumentException($"関数名は「{necessaryPrefix}」で始まる必要があります。");

        return functionName;
    }

    private static bool CheckFunctionPrefix(IReadOnlyCollection<TSQLToken> tokens)
    {
        tokens = tokens.Where(token => !token.IsComment()).ToList();
        if (!tokens.Any()) return false;

        var sb = new StringBuilder();
        foreach (var token in tokens)
        {
            if (FUNCTION_TAG.Equals(token.Text, StringComparison.OrdinalIgnoreCase)) return false;
            sb.Append(token.Text);
            if (Regex.IsMatch(sb.ToString(), FUNCTION_PREFIX_PATTERN, RegexOptions.IgnoreCase)) return true;
        }

        return false;
    }
}