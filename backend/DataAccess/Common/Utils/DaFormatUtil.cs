// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 型変換共通関数
//
// 作成日　　: 2023.06.12
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public static class DaFormatUtil
    {
        #region 西暦
        /// <summary>
        /// 日付編集
        /// </summary>
        public static string FormatYMD(DateTime? value)
        {
            if (value == null) return string.Empty;
            return FormatYMD(value, DaConst.DateFormat);
        }

        /// <summary>
        /// 日付編集
        /// </summary>
        public static string? NFormatYMD(DateTime? value)
        {
            if (value == null) return null;
            return FormatYMD(value, DaConst.DateFormat);
        }

        /// <summary>
        /// 日付編集
        /// </summary>
        public static string FormatYMD(DateTime? value, string format)
        {
            if (value == null) return string.Empty;
            return ((DateTime)value).ToString(format);
        }

        /// <summary>
        /// 時間表示
        /// </summary>
        public static string FormatTime(DateTime? value)
        {
            if (value == null) return string.Empty;
            return FormatTime((DateTime)value);
        }
        /// <summary>
        /// 時間表示
        /// </summary>
        public static string FormatTime(DateTime value)
        {
            return value.ToString("HH:mm:ss");
        }
        /// <summary>
        /// 時間表示(HHmm=>HH:mm)
        /// </summary>
        public static string FormatTime(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            return value.Insert(2, DaStrPool.COLON);
        }
        /// <summary>
        /// 時間範囲表示(HH:mm～HH:mm)
        /// </summary>
        public static string FormatTimeRange(string? tmf, string? tmt)
        {
            return $"{FormatTime(tmf)}{DaStrPool.C_TILDE_FULL}{FormatTime(tmt)}";
        }
        /// <summary>
        /// 日付範囲表示(和暦～和暦)
        /// </summary>
        public static string FormatWaKjYMDRange(string? ymdf, string? ymdt)
        {
            return $"{FormatWaKjYMD(ymdf)}{DaStrPool.C_TILDE_FULL}{FormatWaKjYMD(ymdt)}";
        }
        /// <summary>
        /// 時間表示
        /// </summary>
        public static string FormatTime2(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
        /// <summary>
        /// 時間表示
        /// </summary>
        public static string FormatTime(TimeSpan value)
        {
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3:D3}", value.Hours, value.Minutes, value.Seconds, value.Milliseconds);
        }
        #endregion

        #region 西暦漢字
        /// <summary>
        /// 年月編集
        /// </summary>
        public static string FormatKjYM(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Length != 6) return string.Empty;
            string strLeft = value.Substring(0, 4);
            string strRight = value.Substring(4, 2);
            return $"{strLeft}年{strRight}月";
        }

        /// <summary>
        /// 年月日編集
        /// </summary>
        public static string FormatKjYMD(DateTime value)
        {
            return value.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 年月日編集
        /// </summary>
        public static string FormatKjYMD(DateTime? value)
        {
            if (value == null) return string.Empty;
            return FormatKjYMD((DateTime)value!);
        }

        /// <summary>
        /// 年月日編集
        /// </summary>
        public static string FormatKjYMD(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Length == 10)
            {
                return $"{value.Substring(0, 4)}年{value.Substring(5, 2)}月{value.Substring(8, 2)}日";
            }
            else if (value.Length == 8)
            {
                return $"{value.Substring(0, 4)}年{value.Substring(4, 2)}月{value.Substring(6, 2)}日";
            }
            else
            {
                return "ERROR";
            }
        }

        #endregion

        #region 和暦

        /// <summary>
        /// 年月編集
        /// </summary>
        public static string FormatWaKjYM(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (value.Length != 6) return string.Empty;
            int y = DaConvertUtil.CInt(value.Substring(0, 4));
            int m = DaConvertUtil.CInt(value.Substring(4, 2));
            DateTime dt = new DateTime(y, m, 1);
            return AiDataUtil.FormatDate(dt, "ggyy年MM月");
        }

        /// <summary>
        /// 和暦日付
        /// </summary>
        public static string FormatWaKjYMD(DateTime? value)
        {
            if (value == null) return string.Empty;
            return AiDataUtil.FormatDate(value!.Value, DaConst.JapanDateFormat);
        }

        /// <summary>
        /// 和暦日付
        /// </summary>
        public static string FormatWaKjYMD(DateTime value)
        {
            return AiDataUtil.FormatDate(value, DaConst.JapanDateFormat);
        }

        /// <summary>
        /// 和暦日付
        /// </summary>
        public static string FormatWaKjYMD(string? value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;
            if (DateTime.TryParse(value, out DateTime dt))
            {
                return AiDataUtil.FormatDate(dt, DaConst.JapanDateFormat);
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 和暦日時
        /// </summary>
        public static string FormatWaKjDttm(DateTime? value)
        {
            if (value == null) return string.Empty;
            return AiDataUtil.FormatDate(value!.Value, DaConst.JapanTimeFormat);
        }

        /// <summary>
        /// 和暦日時
        /// </summary>
        public static string FormatWaKjDttm(DateTime value)
        {
            return AiDataUtil.FormatDate(value, DaConst.JapanTimeFormat);
        }
        /// <summary>
        /// 和暦日時
        /// </summary>
        public static string FormatWaKjDttm2(DateTime value)
        {
            return AiDataUtil.FormatDate(value, DaConst.JapanTimeFormat2);
        }
        #endregion

        /// <summary>
        /// 記号変換
        /// </summary>
        public static string FormatFlgStr(bool flg)
        {
            return flg ? "○" : string.Empty;
        }

        /// <summary>
        /// 郵便番号変換
        /// </summary>
        public static string FormatYubin(string yubin)
        {
            if (yubin.Length == 7 && int.TryParse(yubin, out _))
            {
                //郵便番号をハイフン「-」で表示
                return $"{yubin.Substring(0, 3)}-{yubin.Substring(3)}";
            }

            return string.Empty;
        }
    }
}