// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 型変換共通関数
//
// 作成日　　: 2023.06.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;

namespace BCC.Affect.DataAccess
{
    public static class DaConvertUtil
    {
        /// <summary>
        /// objectを文字列に変換
        /// </summary>
        public static string CStr(object? obj)
        {
            if (obj is null || obj == System.Convert.DBNull) return string.Empty;
            if (obj is string) return (string)obj;
            return obj.ToString()!.TrimEnd();
        }

        /// <summary>
        /// objectをnull許容型文字列に変換
        /// </summary>
        public static string? CNStr(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if (obj is string)
            {
                if (string.IsNullOrEmpty(CStr(obj))) return null;
                return (string)obj;
            }
            return obj.ToString()!.TrimEnd();
        }

        /// <summary>
        /// objectを数字に変換、nullの場合、０にする
        /// </summary>
        public static int CInt(object? obj)
        {
            if (obj is null || obj is DBNull) return 0;
            if ((object)obj is int) return (int)obj;
            return (int.TryParse(obj.ToString(), out int i)) ? i : 0;
        }

        /// <summary>
        /// objectをnull許容型整数に変換
        /// </summary>
        public static int? CNInt(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if ((object)obj is int or Enum) return (int)obj;
            return int.TryParse(obj.ToString(), out int i) ? i : null;
        }

        /// <summary>
        /// objectをdoubleに変換。NULL及び変換できない場合、０にする
        /// </summary>
        public static double CDbl(object? obj)
        {
            if (obj is null || obj is DBNull) return 0d;
            if (obj is double) return (double)obj;
            return double.TryParse(obj.ToString(), out double i) ? i : 0d;
        }

        /// <summary>
        /// objectをdoubleに変換。NULL及び変換できない場合、NULLにする
        /// </summary>
        public static double? CNDbl(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if (obj is double) return (double)obj;
            return double.TryParse(obj.ToString(), out double i) ? i : null;
        }

        /// <summary>
        /// objectをDecimalに変換。NULL及び変換できない場合、0にする
        /// </summary>
        public static decimal CDec(object? obj)
        {
            if (obj is null || obj is DBNull) return 0;
            if (obj is decimal) return (decimal)obj;
            return decimal.TryParse(obj.ToString(), out decimal i) ? i : 0;
        }

        /// <summary>
        /// objectをDecimalに変換。NULL及び変換できない場合、nullにする
        /// </summary>
        public static decimal? CNDec(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if (obj is decimal) return (decimal)obj;
            return decimal.TryParse(obj.ToString(), out decimal i) ? i : null;
        }
        /// <summary>
        /// objectをLongに変換。NULL及び変換できない場合、０にする
        /// </summary>
        public static long CLng(object? obj)
        {
            if (obj is null || obj is DBNull) return 0L;
            if (obj is long) return (long)obj;
            return long.TryParse(obj.ToString(), out long i) ? i : 0L;
        }

        /// <summary>
        /// objectをLongに変換。NULL及び変換できない場合、nullにする
        /// </summary>
        public static long? CNLng(object? obj)
        {
            if (obj is null || obj is DBNull) return 0L;
            if (obj is long) return (long)obj;
            return long.TryParse(obj.ToString(), out long i) ? i : null;
        }


        /// <summary>
        /// objectをfloatに変換。NULL及び変換できない場合、０にする
        /// </summary>
        public static float CSng(object? obj)
        {
            if (obj is null || obj is DBNull) return 0f;
            if (obj is float) return (float)obj;
            return float.TryParse(obj.ToString(), out float i) ? i : 0f;
        }
        /// <summary>
        /// objectをfloatに変換。NULL及び変換できない場合、Nullにする
        /// </summary>
        public static float? CNSng(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if (obj is float) return (float)obj;
            return float.TryParse(obj.ToString(), out float i) ? i : null;
        }

        /// <summary>
        /// objectを日付に変換、NULL及び変換できない場合、DateTime最小値にする
        /// </summary>
        public static DateTime CDate(object? obj)
        {
            if (obj is null || obj is DBNull) return new DateTime();
            if (obj is DateTime) return (DateTime)obj;
            return DateTime.TryParse(obj.ToString(), out DateTime i) ? i : new DateTime();
        }

        /// <summary>
        /// objectを日付に変換、NULL及び変換できない場合、Nullにする
        /// </summary>
        public static DateTime? CNDate(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if ((object)obj is DateTime) return (DateTime)obj;
            return DateTime.TryParse(obj.ToString(), out DateTime i) ? i : null;
        }

        /// <summary>
        /// objectをTimeSpanに変換、NULL及び変換できない場合、TimeSpan最小値にする
        /// </summary>
        public static TimeSpan CTimeSpan(object? obj)
        {
            if (obj is null || obj is DBNull) return new TimeSpan();
            if (obj is TimeSpan) return (TimeSpan)obj;
            return TimeSpan.TryParse(obj.ToString(), out TimeSpan i) ? i : new TimeSpan();
        }

        /// <summary>
        /// objectをTimeSpanに変換、NULL及び変換できない場合、Nullにする
        /// </summary>
        public static TimeSpan? CNTimeSpan(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            return TimeSpan.TryParse(obj.ToString(), out TimeSpan i) ? i : null;
        }


        /// <summary>
        /// object対象を論理値に変換。NULL及び変換できない場合、falseにする
        /// </summary>
        public static bool CBool(object? obj)
        {
            if (obj is null || obj is DBNull) return false;
            if (obj is bool) return (bool)obj;
            if (obj.ToString() == "1") return true;
            if (obj.ToString() == "0") return false;
            return bool.TryParse(obj.ToString(), out bool i) ? i : false;
        }

        /// <summary>
        /// object対象を論理値に変換。NULL及び変換できない場合、NULLにする
        /// </summary>
        public static bool? CNBool(object? obj)
        {
            if (obj is null || obj is DBNull) return null;
            if (obj is bool) return (bool)obj;
            if (obj.ToString() == "1") return true;
            if (obj.ToString() == "0") return false;
            return bool.TryParse(obj.ToString(), out bool i) ? i : null;
        }

        /// <summary>
        /// Enum型へ変換
        /// </summary>
        public static TEnum ParseEnum<TEnum>(string enumString) where TEnum : struct, Enum
        {
            if (Enum.TryParse(enumString, out TEnum enumValue))
            {
                return enumValue;
            }
            else
            {
                throw new ArgumentException($"Invalid enum value: {enumString}");
            }
        }

        /// <summary>
        /// Enum型から文字に変換
        /// </summary>
        public static string EnumToStr(Enum? obj)
        {
            if (obj is null) return string.Empty;
            var i = Convert.ToInt64(obj);
            if (i == -1) return string.Empty;
            return i.ToString();
        }

        /// <summary>
        /// Enum型から文字に変換
        /// </summary>
        public static string? EnumToNStr(Enum? obj)
        {
            if (obj is null) return null;
            return EnumToStr(obj);
        }

        /// <summary>
        /// 空白文字からnothingに変換
        /// </summary>
        public static string? ToNStr(string str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return str;
        }

        /// <summary>
        /// 数値から文字へ変換
        /// </summary>
        public static string ToStr(int i)
        {
            if (i == 0) return string.Empty;
            return i.ToString();
        }

        /// <summary>
        /// 空白ないリスト取得
        /// </summary>
        public static List<string> NzStrList(string str, List<string> list)
        {
            if (!string.IsNullOrEmpty(str)) list.Add(str);
            return list;
        }

        /// <summary>
        /// コードリスト取得(「,」区切り文字列から)
        /// </summary>
        public static List<string> CommaStrToList(string? str)
        {
            var list = new List<string>();
            if (!string.IsNullOrEmpty(str))
            {
                list = str.Split(DaStrPool.COMMA).ToList();
            }
            return list;
        }

        /// <summary>
        /// 「,」区切り文字列取得(コードリストから)
        /// </summary>
        public static string? ListToCommaStr(List<string> cdList, bool sortFlg = true)
        {
            string? cd = null;
            if (sortFlg) cdList.Sort();
            if (cdList.Count > 0)
            {
                cd = string.Join(DaStrPool.COMMA, cdList);
            }

            return cd;
        }

        /// <summary>
        /// 「、」区切り文字列取得(名称リストから)
        /// </summary>
        public static string? ListToCommaStr2(List<string> nmList)
        {
            string? nm = null;
            if (nmList.Count > 0)
            {
                nm = string.Join(DaStrPool.C_COMMA2, nmList);
            }

            return nm;
        }

        /// <summary>
        /// 「、」区切り文字列取得(「,」区切り文字列から)
        /// </summary>
        public static string? CommaStrToCommaStr2(string? str, List<DaSelectorModel> nmList, bool sortFlg = false)
        {
            List<string> cds = CommaStrToList(str);
            if (sortFlg) cds.Sort();
            var nms = nmList.Where(e => cds.Contains(e.value)).Select(e => e.label).ToList();
            return ListToCommaStr2(nms);
        }

        /// <summary>
        /// 論理値から文字型に変換
        /// </summary>
        public static string BoolToStr(bool flg)
        {
            if (flg) return "1";
            return "0";
        }
        #region カナ変換
        /// <summary>
        /// unicode差分(カタカナ-ひらがな)
        /// </summary>
        private static readonly int offset = 'ァ' - 'ぁ';

        private static StringBuilder builder = new StringBuilder();

        private static Regex re = new Regex(@"[ｦ-ﾝ]ﾞ|[ｦ-ﾝ]ﾟ|[ｦ-ﾝ]");

        public static string ToKana(string str)
        {
            //ひらがなからカタカナへ変換
            str = ToKatakana(str);
            //半角カタカナから全角カタカナへ変換
            str = ToFullKataKana(str);
            return str;
        }

        public static string? ToNKana(string? str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return ToKana(str);
        }

        public static string? ToNSeionKana(string? str)
        {
            if (string.IsNullOrEmpty(str)) return null;
            return ToSeion(ToKana(str));
        }

        /// <summary>
        /// カナ変換(ひらがな=>カタカナ)
        /// </summary>
        public static string ToKatakana(string str)
        {
            builder.Clear();
            foreach (var c in str)
            {
                builder.Append(IsHiragana(c) ? (char)(c + offset) : c);
            }
            return builder.ToString();
        }

        /// <summary>
        /// カナ変換(カタカナ=>ひらがな)
        /// </summary>
        public static string ToHiragana(string str)
        {
            builder.Clear();
            foreach (var c in str)
            {
                builder.Append(IsKatakana(c) ? (char)(c - offset) : c);
            }
            return builder.ToString();
        }

        /// <summary>
        /// カナ変換(半角カタカナ=>全角カタカナ)
        /// </summary>
        public static string ToFullKataKana(string str)
        {
            string output = re.Replace(str, match =>
            {//Matchした場合の処理
                if (KanaChangeMap.ContainsKey(match.Value))
                {//辞書にあれば辞書にある値を返す
                    return KanaChangeMap[match.Value];
                }
                else
                {//辞書になければつまり半角カタカナでなければ変換せずに返す
                    return match.Value;
                }
            });
            return output;
        }

        /// <summary>
        /// 清音化
        /// </summary>
        public static string ToSeion(string str)
        {
            str = str.Replace(DaStrPool.SPACE, "").
                      Replace(DaStrPool.SPACE_FULL, "").
                      Replace("ﾞ", "").
                      Replace("ﾟ", "").
                      Replace("ヴァ", "バ").
                      Replace("ヴィ", "ビ").
                      Replace("ヴ", "ブ").
                      Replace("ハ", "ワ").
                      Replace("ガ", "カ").
                      Replace("ギ", "キ").
                      Replace("グ", "ク").
                      Replace("ゲ", "ケ").
                      Replace("ゴ", "コ").
                      Replace("ザ", "サ").
                      Replace("ジ", "シ").
                      Replace("ズ", "ス").
                      Replace("ゼ", "セ").
                      Replace("ゾ", "ソ").
                      Replace("ダ", "タ").
                      Replace("ヂ", "シ").
                      Replace("ヅ", "ス").
                      Replace("デ", "テ").
                      Replace("ド", "ト").
                      Replace("バ", "ワ").
                      Replace("パ", "ワ").
                      Replace("ビ", "ヒ").
                      Replace("ピ", "ヒ").
                      Replace("ブ", "フ").
                      Replace("プ", "フ").
                      Replace("ベ", "ヘ").
                      Replace("ペ", "ヘ").
                      Replace("ボ", "ホ").
                      Replace("ポ", "ホ").
                      Replace("ヲ", "オ").
                      Replace("ヷ", "ワ").
                      Replace("ヸ", "ヰ").
                      Replace("ヹ", "ヱ").
                      Replace("ヺ", "オ").
                      Replace("ヾ", "ヽ").
                      Replace("オウ", "オオ").
                      Replace("コウ", "コオ").
                      Replace("ソウ", "ソオ").
                      Replace("トウ", "トオ").
                      Replace("ノウ", "ノオ").
                      Replace("ホウ", "ホオ").
                      Replace("モウ", "モオ").
                      Replace("ヨウ", "ヨオ").
                      Replace("ロウ", "ロオ").
                      Replace("ァ", "ア").
                      Replace("ィ", "イ").
                      Replace("ゥ", "ウ").
                      Replace("ェ", "エ").
                      Replace("ォ", "オ").
                      Replace("ッ", "ツ").
                      Replace("ャ", "ヤ").
                      Replace("ュ", "ユ").
                      Replace("ョ", "ヨ").
                      Replace("ヮ", "ワ").
                      Replace("ヵ", "カ").
                      Replace("ヶ", "ケ");
            return str;
        }

        /// <summary>
        /// ひらがな範囲判断
        /// </summary>
        private static bool IsHiragana(char c)
        {
            //ひらがな範囲
            return c >= '\u3040' && c <= '\u309F';
        }

        /// <summary>
        /// カタカナ範囲判断
        /// </summary>
        private static bool IsKatakana(char c)
        {
            //カタカナ範囲
            return c >= '\u30A0' && c <= '\u30FF';
        }
        /// <summary>
        /// 変換関係(半角カタカナ=>全角カタカナ)
        /// </summary>
        private static readonly Dictionary<string, string> KanaChangeMap = new Dictionary<string, string>
        {
            {"ｱ","ア"},
            {"ｨ","ィ"},
            {"ｲ","イ"},
            {"ｩ","ゥ"},
            {"ｳ","ウ"},
            {"ｪ","ェ"},
            {"ｴ","エ"},
            {"ｫ","ォ"},
            {"ｵ","オ"},
            {"ｶ","カ"},
            {"ｶﾞ","ガ"},
            {"ｷ","キ"},
            {"ｷﾞ","ギ"},
            {"ｸ","ク"},
            {"ｸﾞ","グ"},
            {"ｹ","ケ"},
            {"ｹﾞ","ゲ"},
            {"ｺ","コ"},
            {"ｺﾞ","ゴ"},
            {"ｻ","サ"},
            {"ｻﾞ","ザ"},
            {"ｼ","シ"},
            {"ｼﾞ","ジ"},
            {"ｽ","ス"},
            {"ｽﾞ","ズ"},
            {"ｾ","セ"},
            {"ｾﾞ","ゼ"},
            {"ｿ","ソ"},
            {"ｿﾞ","ゾ"},
            {"ﾀ","タ"},
            {"ﾀﾞ","ダ"},
            {"ﾁ","チ"},
            {"ﾁﾞ","ヂ"},
            {"ｯ","ッ"},
            {"ﾂ","ツ"},
            {"ﾂﾞ","ヅ"},
            {"ﾃ","テ"},
            {"ﾃﾞ","デ"},
            {"ﾄ","ト"},
            {"ﾄﾞ","ド"},
            {"ﾅ","ナ"},
            {"ﾆ","ニ"},
            {"ﾇ","ヌ"},
            {"ﾈ","ネ"},
            {"ﾉ","ノ"},
            {"ﾊ","ハ"},
            {"ﾊﾞ","バ"},
            {"ﾊﾟ","パ"},
            {"ﾋ","ヒ"},
            {"ﾋﾞ","ビ"},
            {"ﾋﾟ","ピ"},
            {"ﾌ","フ"},
            {"ﾌﾞ","ブ"},
            {"ﾌﾟ","プ"},
            {"ﾍ","ヘ"},
            {"ﾍﾞ","ベ"},
            {"ﾍﾟ","ペ"},
            {"ﾎ","ホ"},
            {"ﾎﾞ","ボ"},
            {"ﾎﾟ","ポ"},
            {"ﾏ","マ"},
            {"ﾐ","ミ"},
            {"ﾑ","ム"},
            {"ﾒ","メ"},
            {"ﾓ","モ"},
            {"ｬ","ャ"},
            {"ﾔ","ヤ"},
            {"ｭ","ュ"},
            {"ﾕ","ユ"},
            {"ｮ","ョ"},
            {"ﾖ","ヨ"},
            {"ﾗ","ラ"},
            {"ﾘ","リ"},
            {"ﾙ","ル"},
            {"ﾚ","レ"},
            {"ﾛ","ロ"},
            {"ﾜ","ワ"},
            {"ｦ","ヲ"},
            {"ﾝ","ン"},
            {"ｰ","ー"}
        };
    }
    #endregion
}