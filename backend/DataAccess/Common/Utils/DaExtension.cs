// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DataRow拡張機能
//
// 作成日　　: 2022.12.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
using Microsoft.VisualBasic.CompilerServices;

namespace BCC.Affect.DataAccess
{
    public static class DaExtension
    {
        /// <summary>
        /// 画面表示にラッピング処理
        /// </summary>
        public static string Wrap(this DataRow dr, string name)
        {
            var obj = dr[name]!;
            if (obj is null || obj is DBNull) return string.Empty;
            if (obj is DateTime)
            {
                var column = dr.Table.Columns[name]!;
                string columnName = column.ColumnName;
                return FormatDate((DateTime)obj, columnName);
            }
            else
            {
                return obj.ToString()!.TrimEnd();
            }
        }

        /// <summary>
        /// 画面表示にラッピング処理
        /// </summary>
        public static string Wrap(this DataRow dr, string name1, string name2)
        {
            var obj = dr[name1];
            if (obj is null || obj is DBNull) return string.Empty;
            return Conversions.ToString(dr[name1]) + " " + Conversions.ToString(dr[name2]);
        }

        /// <summary>
        /// 日付編集
        /// </summary>
        private static string FormatDate(DateTime value, string name)
        {
            if (name.Contains("日時"))
            {
                return value.ToString(DaConst.JapanTimeFormat);
            }
            else
            {
                return value.ToString(DaConst.JapanDateFormat);
            }
        }

        public static string? ToNStr(this DataRow dr, string name)
        {
            var obj = dr[name];
            if (obj is null || obj is DBNull) return null;
            return Wrap(dr, name);
        }

        /// <summary>
        /// 日付編集
        /// </summary>
        public static string FormatDate(this DataRow dr, string name, string fmt)
        {
            var obj = dr[name];
            if (obj is null || obj is DBNull) return string.Empty;
            return AiDataUtil.FormatDate((DateTime)obj, fmt);
        }

        /// <summary>
        /// 日付編集
        /// </summary>
        public static string FormatKjYM(this DataRow dr, string name)
        {
            var obj = dr[name];
            if (obj is null || obj is DBNull) return string.Empty;
            return DaFormatUtil.FormatKjYM(obj.ToString()!.TrimEnd());
        }
        public static string CStr(this DataRow dr, string name) => DaConvertUtil.CStr(dr[name]);
        public static int CInt(this DataRow dr, string name) => DaConvertUtil.CInt(dr[name]);
        public static int? CNInt(this DataRow dr, string name) => DaConvertUtil.CNInt(dr[name]);
        public static long CLng(this DataRow dr, string name) => DaConvertUtil.CLng(dr[name]);
        public static long? CNLng(this DataRow dr, string name) => DaConvertUtil.CNLng(dr[name]);
        public static decimal CDec(this DataRow dr, string name) => DaConvertUtil.CDec(dr[name]);
        public static decimal? CNDec(this DataRow dr, string name) => DaConvertUtil.CNDec(dr[name]);
        public static DateTime CDate(this DataRow dr, string name) => DaConvertUtil.CDate(dr[name]);
        public static DateTime? CNDate(this DataRow dr, string name) => DaConvertUtil.CNDate(dr[name]);
        public static bool CBool(this DataRow dr, string name) => DaConvertUtil.CBool(dr[name]);
        public static bool? CNBool(this DataRow dr, string name) => DaConvertUtil.CNBool(dr[name]);
    }
}