// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　データ型チェック共通関数
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImDataTypeUtil
    {
        /// <summary>
        /// データ型チェック
        /// </summary>
        public static bool CheckDataType(string type, string value)
        {
            switch (ParseEnum<Enum入力方法>(type))
            {
                case Enum入力方法.数値_整数:
                    //数値（整数）
                    return IsUInteger(value);
                case Enum入力方法.数値_小数点付き実数:
                    //数値（小数点付き実数）
                    return IsValidNumber(value);
                case Enum入力方法.数値_符号付き整数:
                    //数値（符号付き整数）
                    return IsSignedInteger(value);
                case Enum入力方法.半角文字_半角数字:
                    //半角文字（半角数字）
                    return IsHalfWidthNumber(value);
                case Enum入力方法.半角文字_半角英数字:
                    //半角文字（半角英数字）
                    return CheckHalfWidthAlphanumeric(value);
                case Enum入力方法.半角文字_時刻:
                    //半角文字（時刻）
                    return IsHalfWidthTime(value);
                case Enum入力方法.半角文字_半角:
                    //半角文字（半角）
                    return ContainsHalfWidthCharacters(value);
                case Enum入力方法.全角文字_全角_改行不可:
                    //全角文字（全角）※改行不可
                    return ContainsFullWidthCharacters21(value);
                    //return true;
                case Enum入力方法.全角文字_全角_改行可:
                    //全角文字（全角）※改行可
                    return ContainsFullWidthCharacters22(value);
                    //return true;
                case Enum入力方法.全角半角文字_全角半角_改行不可:
                    //全角半角文字（全角半角）※改行不可
                    return ContainsFullHalfWidthCharacters26(value);
                    //return true;
                case Enum入力方法.全角半角文字_全角半角_改行可:
                    //全角半角文字（全角半角）※改行可
                    return ContainsFullHalfWidthCharacters27(value);
                    //return true;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 数値（整数）
        /// </summary>
        public static bool IsUInteger(string value)
        {
            if (uint.TryParse(value, out uint uintValue))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 数値（小数点付き実数）
        /// </summary>
        public static bool IsValidNumber(string value)
        {
            // 数値（小数点付き実数）を確認する正規表現
            string pattern = @"^\d+(\.\d+)?$";

            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 符号つき整数かどうか
        /// </summary>
        public static bool IsSignedInteger(string value)
        {
            if (int.TryParse(value, out int intValue))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 半角文字（半角数字）
        /// </summary>
        public static bool IsHalfWidthNumber(string value)
        {
            // 正規表現パターン：半角数字（0から9）
            string pattern = "^[0-9]+$";

            // パラメータを文字列に変換して正規表現でマッチングを試みます
            if (value != null)
            {
                return Regex.IsMatch(value, pattern);
            }

            return false; // パラメータが null の場合、半角数字ではありません。
        }

        /// <summary>
        /// 半角文字（半角英数字）
        /// </summary>
        public static bool CheckHalfWidthAlphanumeric(string value)
        {
            // 正規表現パターン：半角英数字
            string pattern = "^[a-zA-Z0-9]*$";

            // 正規表現でチェック
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 半角文字（年）
        /// </summary>
        public static bool IsHalfWidthYear(string value)
        {
            // 正規表現パターンを定義：4桁の半角数字
            string pattern = @"^\d{4}$";

            // 正規表現パターンと一致するかを検証
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// ハイフン区切りの半角文字列（年月）をチェックする関数
        /// </summary>
        public static bool CheckHalfWidthYearMonth(string value)
        {
            // 正規表現パターン：4桁の年（000と月（01-12）にマッチ
            string pattern = @"^\d{4}-(0[1-9]|1[0-2])$";

            // 正規表現でチェック
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 半角文字（時刻）
        /// </summary>
        public static bool IsHalfWidthTime(string value)
        {
            // 正規表現パターンを定義：hh:mm 形式の時刻を検査
            string pattern = @"^(0[0-9]|1[0-9]|2[0-3])[:]?([0-5][0-9])$";

            // 正規表現でパターンに一致するか検査
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 半角文字（半角）
        /// </summary>
        public static bool ContainsHalfWidthCharacters(string value)
        {
            // 正規表現を使用して半角文字を検出
            return Regex.IsMatch(value, @"^[\x00-\x7F]*$");
        }

        /// <summary>
        /// 全角文字（全角）※改行不可
        /// </summary>
        public static bool ContainsFullWidthCharacters21(string value)
        {
            // 改行検査
            if (value.Contains("\r\n") || value.Contains("\r") || value.Contains("\n"))
            {
                return false;
            }
            // 正規表現パターンを使用して半角の文字が含まれているかどうかを検査
            string halfPattern = @"[\x00-\x7F]";
            if(Regex.IsMatch(value, halfPattern))
            {
                return false;
            }
            //正規表現パターンを使って、全角文字が含まれているかどうかを検査
            string pattern = @"[^\x01-\x7F\xFF]";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// 全角文字（全角）※改行可
        /// </summary>
        public static bool ContainsFullWidthCharacters22(string value)
        {
            // 正規表現パターンを使って、全角文字や改行文字が含まれているかどうかを検査
            string pattern = @"^[^\x00-\x7F]*((\r\n|\r|\n)*[^\x00-\x7F]*)*$";
            if (Regex.IsMatch(value, pattern)) return true;
            return false;
            
        }

        /// <summary>
        /// 全角半角文字（全角半角）※改行不可
        /// </summary>
        public static bool ContainsFullHalfWidthCharacters26(string value)
        {
            // 改行検査
            if (value.Contains("\r\n") || value.Contains("\r") || value.Contains("\n"))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 全角半角文字（全角半角）※改行可
        /// </summary>
        public static bool ContainsFullHalfWidthCharacters27(string value)
        {
            return true;
        }
    }
}