// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　日付フォーマットチェック共通関数
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using System.Globalization;
using System.Text.RegularExpressions;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImFormatUtil
    {
        /// <summary>
        /// 不詳年(不明年)
        /// </summary>
        public const string UNKNOWN_YEAR = "不明年";
        /// <summary>
        /// 不詳年(0000)
        /// </summary>
        public const string UNKNOWN_YEAR_0000 = "0000";

        /// <summary>
        /// 不詳月
        /// </summary>
        public static readonly Dictionary<string, string> UnknownMonthTagsDic = new Dictionary<string, string>
                                    {
                                        { "春", "A1" } ,
                                        { "夏", "A2" },
                                        { "秋", "A3" },
                                        { "冬", "A4" },
                                        { "不明月", "00" }
                                    };
        /// <summary>
        /// 不詳日
        /// </summary>
        public static readonly Dictionary<string, string> UnknownDayTagsDic = new Dictionary<string, string>
                                    {
                                        { "上旬", "A1" } ,
                                        { "中旬", "A2" },
                                        { "下旬", "A3" },
                                        { "不明日", "00" }
                                    };

        /// <summary>
        /// 年号
        /// </summary>
        public static readonly Dictionary<string, string> GGEraDic = new Dictionary<string, string>
                                                                    {
                                                                        { "5", "令和" },
                                                                        { "4", "平成" },
                                                                        { "3", "昭和" },
                                                                        { "2", "大正" },
                                                                        { "1", "明治" }
                                                                    };
        /// <summary>
        /// 年号
        /// </summary>
        public static readonly List<string> GEraList = new List<string>() { "R", "H", "S", "T", "M" };

        // 不詳月(春|夏|秋|冬|不明月)
        private static readonly string MonthFusyo = "(" + string.Join("|", UnknownMonthTagsDic.Keys) + ")";
        // 不詳月(A1|A2|A3|A4|00)
        private static readonly string MonthFusyoA = "(" + string.Join("|", UnknownMonthTagsDic.Values) + ")";
        // 不詳日(上旬|中旬|下旬|不明日)
        private static readonly string DayFusyo = "(" + string.Join("|", UnknownDayTagsDic.Keys) + ")";
        // 不詳日(A1|A2|A3|00)
        private static readonly string DayFusyoA = "(" + string.Join("|", UnknownDayTagsDic.Values) + ")";

        // gg(令和|平成|昭和|大正|明治)
        private static readonly string gg = "(" + string.Join("|", GGEraDic.Values) + ")";
        // g(R|H|S|T|M)
        private static readonly string g = "(" + string.Join("|", GEraList) + ")";
        // ynum(5|4|3|2|1)
        private static readonly string ynum = "(" + string.Join("|", GGEraDic.Keys) + ")";
        // y
        private static readonly string y = @"([1-9]\d?)";
        // yy          
        private static readonly string yy = @"(0[1-9]|[1-9]\d)";
        // yyyy               
        private static readonly string yyyy = @"((?!0{4})\d{4})";
        // M               
        private static readonly string M = @"([1-9]|1[0-2])";
        // d               
        private static readonly string d = @"([1-9]|[12][0-9]|3[01])";
        // MM               
        private static readonly string MM = @"(0[1-9]|1[0-2])";
        // dd               
        private static readonly string dd = @"(0[1-9]|[12][0-9]|3[01])";
        // H
        private static readonly string H = @"([0-9]|1[0-9]|2[0-3])";
        // m
        private static readonly string m = @"([0-9]|[1-5]?[0-9])";
        // s
        private static readonly string s = @"([0-9]|[1-5]?[0-9])";
        // HH
        private static readonly string HH = @"(0[0-9]|1[0-9]|2[0-3])";
        // mm
        private static readonly string mm = @"(0[0-9]|[1-5]?[0-9])";
        // ss
        private static readonly string ss = @"(0[0-9]|[1-5]?[0-9])";

        #region 日付フォーマット
        /// <summary>
        /// ggy年
        /// </summary>
        public static readonly string DatePattern1 = $@"^{gg}{y}年$";
        /// <summary>
        /// ggyy年             
        /// </summary>
        public static readonly string DatePattern2 = $@"^{gg}{yy}年$";
        /// <summary>
        /// gy                 
        /// </summary>
        public static readonly string DatePattern3 = $@"^{g}{y}$";
        /// <summary>
        /// gyy                
        /// </summary>
        public static readonly string DatePattern4 = $@"^{g}{yy}$";
        /// <summary>
        /// yy                 
        /// </summary>
        public static readonly string DatePattern5 = $@"^{ynum}{yy}$";
        /// <summary>
        /// yyyy               
        /// </summary>
        public static readonly string DatePattern6 = $@"^{yyyy}$";
        /// <summary>
        /// yyyy年             
        /// </summary>
        public static readonly string DatePattern7 = $@"^{yyyy}年$";

        /// <summary>
        /// ggy年M月           
        /// </summary>
        public static readonly string DatePattern8 = $@"^{gg}{y}年{M}月$";
        /// <summary>
        /// ggyy年MM月         
        /// </summary>
        public static readonly string DatePattern9 = $@"^{gg}{yy}年{MM}月$";
        /// <summary>
        /// gy.M         
        /// </summary>
        public static readonly string DatePattern10 = $@"^{g}{y}.{M}$";
        /// <summary>
        /// gyy.MM         
        /// </summary>
        public static readonly string DatePattern11 = $@"^{g}{yy}.{MM}$";
        /// <summary>
        /// yyMM      
        /// </summary>
        public static readonly string DatePattern12 = $@"^{ynum}{yy}{MM}$";
        /// <summary>
        /// yyyy年M月  
        /// </summary>
        public static readonly string DatePattern13 = $@"^{yyyy}年{M}月$";
        /// <summary>
        /// yyyy年MM月  
        /// </summary>
        public static readonly string DatePattern14 = $@"^{yyyy}年{MM}月$";
        /// <summary>
        /// yyyy/M  
        /// </summary>
        public static readonly string DatePattern15 = $@"^{yyyy}/{M}$";
        /// <summary>
        /// yyyy/MM  
        /// </summary>
        public static readonly string DatePattern16 = $@"^{yyyy}/{MM}$";
        /// <summary>
        /// yyyyMM  
        /// </summary>
        public static readonly string DatePattern17 = $@"^{yyyy}{MM}$";

        /// <summary>
        /// ggy年M月d日        
        /// </summary>
        public static readonly string DatePattern18 = $@"^{gg}{y}年{M}月{d}日$";
        /// <summary>
        /// ggyy年MM月dd日     
        /// </summary>
        public static readonly string DatePattern19 = $@"^{gg}{yy}年{MM}月{dd}日$";
        /// <summary>
        /// gy.M.d             
        /// </summary>
        public static readonly string DatePattern20 = $@"^{g}{y}.{M}.{d}$";
        /// <summary>
        /// gyy.MM.dd            
        /// </summary>
        public static readonly string DatePattern21 = $@"^{g}{yy}.{MM}.{dd}$";
        /// <summary>
        /// yyMMdd            
        /// </summary>
        public static readonly string DatePattern22 = $@"^{ynum}{yy}{MM}{dd}$";
        /// <summary>
        /// yyyy年M月d日           
        /// </summary>
        public static readonly string DatePattern23 = $@"^{yyyy}年{M}月{d}日$";
        /// <summary>
        /// yyyy年MM月dd日         
        /// </summary>
        public static readonly string DatePattern24 = $@"^{yyyy}年{MM}月{dd}日$";
        /// <summary>
        /// yyyy/M/d           
        /// </summary>
        public static readonly string DatePattern25 = $@"^{yyyy}/{M}/{d}$";
        /// <summary>
        /// yyyy/MM/dd         
        /// </summary>
        public static readonly string DatePattern26 = $@"^{yyyy}/{MM}/{dd}$";
        /// <summary>
        /// yyyyMMdd         
        /// </summary>
        public static readonly string DatePattern27 = $@"^{yyyy}{MM}{dd}$";
        /// <summary>
        /// ggy年M月d日 H時m分s秒       
        /// </summary>
        public static readonly string DatePattern28 = $@"^{gg}{y}年{M}月{d}日\s{H}時{m}分{s}秒$";
        /// <summary>
        /// ggyy年MM月dd日 HH時mm分ss秒     
        /// </summary>
        public static readonly string DatePattern29 = $@"^{gg}{yy}年{MM}月{dd}日\s{HH}時{mm}分{ss}秒$";
        /// <summary>
        /// gy.M.d H:m:s      
        /// </summary>
        public static readonly string DatePattern30 = $@"^{g}{y}.{m}.{d}\s{H}:{m}:{s}$";
        /// <summary>
        /// gyy.MM.dd HH:mm:ss
        /// </summary>
        public static readonly string DatePattern31 = $@"^{g}{yy}.{MM}.{dd}\s{HH}:{mm}:{ss}$";
        /// <summary>
        /// yyyy年M月d日 H時m分s秒       
        /// </summary>
        public static readonly string DatePattern32 = $@"^{yyyy}年{M}月{d}日\s{H}時{m}分{s}秒$";
        /// <summary>
        /// yyyy年MM月dd日 HH時mm分ss秒    
        /// </summary>
        public static readonly string DatePattern33 = $@"^{yyyy}年{MM}月{dd}日\s{HH}時{mm}分{ss}秒$";
        /// <summary>
        /// yyyy/M/d H:m:s      
        /// </summary>
        public static readonly string DatePattern34 = $@"^{yyyy}/{M}/{d}\s{H}:{m}:{s}$";
        /// <summary>
        /// yyyy/MM/dd HH:mm:ss    
        /// </summary>
        public static readonly string DatePattern35 = $@"^{yyyy}/{MM}/{dd}\s{HH}:{mm}:{ss}$";
        /// <summary>
        /// yyyyMMddHHmmss    
        /// </summary>
        public static readonly string DatePattern36 = $@"^{yyyy}{MM}{dd}{HH}{mm}{ss}$";
        #endregion

        #region 不祥日付フォーマット
        /// <summary>
        /// ggy年
        /// </summary>
        public static readonly string FusyoDatePattern1 = $@"^(({UNKNOWN_YEAR})|({gg}{y}年))$";
        /// <summary>
        /// ggyy年             
        /// </summary>
        public static readonly string FusyoDatePattern2 = $@"^(({UNKNOWN_YEAR})|({gg}{yy}年))$";
        /// <summary>
        /// yyyy               
        /// </summary>
        public static readonly string FusyoDatePattern6 = $@"^(({UNKNOWN_YEAR_0000})|({yyyy}))$";
        /// <summary>
        /// yyyy年             
        /// </summary>
        public static readonly string FusyoDatePattern7 = $@"^(({UNKNOWN_YEAR_0000})|({yyyy}))年$";
        /// <summary>
        /// ggy年M月           
        /// </summary>
        public static readonly string FusyoDatePattern8 = $@"^(({UNKNOWN_YEAR})|({gg}{y}年))({MonthFusyo}|({M}月))$";
        /// <summary>
        /// ggyy年MM月         
        /// </summary>
        public static readonly string FusyoDatePattern9 = $@"^(({UNKNOWN_YEAR})|({gg}{yy}年))({MonthFusyo}|({MM}月))$";
        /// <summary>
        /// yyyy年M月  
        /// </summary>
        public static readonly string FusyoDatePattern13 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})年({MonthFusyoA}|{M})月$";
        /// <summary>
        /// yyyy年MM月  
        /// </summary>
        public static readonly string FusyoDatePattern14 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})年({MonthFusyoA}|{MM})月$";
        /// <summary>
        /// yyyy/M  
        /// </summary>
        public static readonly string FusyoDatePattern15 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})/({MonthFusyoA}|{M})$";
        /// <summary>
        /// yyyy/MM  
        /// </summary>
        public static readonly string FusyoDatePattern16 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})/({MonthFusyoA}|{MM})$";
        /// <summary>
        /// yyyyMM  
        /// </summary>
        public static readonly string FusyoDatePattern17 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})({MonthFusyoA}|{MM})$";
        /// <summary>
        /// ggy年M月d日        
        /// </summary>
        public static readonly string FusyoDatePattern18 = $@"^(({UNKNOWN_YEAR})|({gg}{y}年))({MonthFusyo}|({M}月))({DayFusyo}|({d}日))$";
        /// <summary>
        /// ggyy年MM月dd日     
        /// </summary>
        public static readonly string FusyoDatePattern19 = $@"^(({UNKNOWN_YEAR})|({gg}{yy}年))({MonthFusyo}|({MM}月))({DayFusyo}|({dd}日))$";
        /// <summary>
        /// yyyy年M月d日           
        /// </summary>
        public static readonly string FusyoDatePattern23 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})年({MonthFusyoA}|{M})月({DayFusyoA}|{d})日$";
        /// <summary>
        /// yyyy年MM月dd日         
        /// </summary>
        public static readonly string FusyoDatePattern24 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})年({MonthFusyoA}|{MM})月({DayFusyoA}|{dd})日$";
        /// <summary>
        /// yyyy/M/d           
        /// </summary>
        public static readonly string FusyoDatePattern25 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})/({MonthFusyoA}|{M})/({DayFusyoA}|{d})$";
        /// <summary>
        /// yyyy/MM/dd         
        /// </summary>
        public static readonly string FusyoDatePattern26 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})/({MonthFusyoA}|{MM})/({DayFusyoA}|{dd})$";
        /// <summary>
        /// yyyyMMdd         
        /// </summary>
        public static readonly string FusyoDatePattern27 = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})({MonthFusyoA}|{MM})({DayFusyoA}|{dd})$";

        /// <summary>
        /// yyyy-MM-dd         
        /// </summary>
        public static readonly string FusyoDateFormat = $@"^(({UNKNOWN_YEAR_0000})|{yyyy})-({MonthFusyoA}|{MM})-({DayFusyoA}|{dd})$";
        #endregion

        /// <summary>
        /// 不詳年(0000)を取得する
        /// </summary>
        /// <param name="value">不明年/0000</param>
        /// <returns>不詳年(0000)</returns>
        public static string GetFusyoYear(string value)
        {
            if (value == UNKNOWN_YEAR || value == UNKNOWN_YEAR_0000)
            {
                return UNKNOWN_YEAR_0000;
            }
            return string.Empty;
        }

        /// <summary>
        /// 西暦の年を取得する
        /// <param name="era">元号の文字列</param>
        /// <param name="eraYear">和暦の年</param>
        /// <returns>西暦の年</returns>
        private static string GetYear(string era, string eraYear)
        {
            CultureInfo culture = new CultureInfo("ja-JP", true);
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();

            string warekiDate = era + eraYear + "/12/31";

            DateTime date = DateTime.Parse(warekiDate, culture.DateTimeFormat);

            return date.Year.ToString();   // 西暦の年
        }

        /// <summary>
        /// 不詳年(yyyy)を変換取得
        /// </summary>
        /// <param name="value">不詳和暦年</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年(yyyy)</returns>
        public static string GetFusyoWarekiDateY(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 5)
            {
                var yearFusyo = match.Groups[2].Value;  //不詳年
                var era = match.Groups[4].Value;        //元号の文字列
                var eraYear = match.Groups[5].Value;    //和暦の年

                var year = !string.IsNullOrEmpty(yearFusyo) ? UNKNOWN_YEAR_0000 : GetYear(era, eraYear);

                return year;
            }
            return string.Empty;
        }

        /// <summary>
        /// 不詳年月(yyyyMM)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">不詳和暦年月</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年月(yyyyMM)</returns>
        public static string GetFusyoWarekiDateYM(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 9)
            {
                var yearFusyo = match.Groups[2].Value;  //不詳年
                var era = match.Groups[4].Value;        //元号の文字列
                var eraYear = match.Groups[5].Value;    //和暦の年
                var monthFusyo = match.Groups[7].Value; //不詳月
                var month = match.Groups[9].Value;      //月

                var year = !string.IsNullOrEmpty(yearFusyo) ? UNKNOWN_YEAR_0000 : GetYear(era, eraYear);
                month = !string.IsNullOrEmpty(monthFusyo) ? UnknownMonthTagsDic[monthFusyo] : month.PadLeft(2, '0');

                return year + month;
            }
            return string.Empty;
        }

        /// <summary>
        /// 不詳年月日(yyyy-MM-dd)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">不詳和暦年月日</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年月日(yyyy-MM-dd)</returns>
        public static string GetFusyoWarekiDateYMD(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 13)
            {
                var yearFusyo = match.Groups[2].Value;  //不詳年
                var era = match.Groups[4].Value;        //元号の文字列
                var eraYear = match.Groups[5].Value;    //和暦の年
                var monthFusyo = match.Groups[7].Value; //不詳月
                var month = match.Groups[9].Value;      //月
                var dayFusyo = match.Groups[11].Value;  //不詳日
                var day = match.Groups[13].Value;       //日

                var year = !string.IsNullOrEmpty(yearFusyo) ? UNKNOWN_YEAR_0000 : GetYear(era, eraYear);
                month = !string.IsNullOrEmpty(monthFusyo) ? UnknownMonthTagsDic[monthFusyo] : month.PadLeft(2, '0');
                day = !string.IsNullOrEmpty(dayFusyo) ? UnknownDayTagsDic[dayFusyo] : day.PadLeft(2, '0');

                //yyyy-MM-dd
                return year + "-" + month + "-" + day;
            }

            return string.Empty;
        }

        /// <summary>
        /// 不詳年(yyyy)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">不詳西暦年</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年(yyyy)</returns>
        public static string GetFusyoDateY(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 3)
            {
                var yearFusyo = match.Groups[2].Value;//不詳年(0000)
                var year = match.Groups[3].Value;//西暦年

                year = !string.IsNullOrEmpty(yearFusyo) ? yearFusyo : year;

                //yyyy
                return year;
            }

            return string.Empty;
        }

        /// <summary>
        /// 不詳年月(yyyyMM)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">不詳西暦年月</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年月(yyyyMM)</returns>
        public static string GetFusyoDateYM(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 6)
            {
                var yearFusyo = match.Groups[2].Value;//不詳年(0000)
                var year = match.Groups[3].Value;//西暦年
                var monthFusyo = match.Groups[5].Value;//不詳月
                var month = match.Groups[6].Value;//月

                year = !string.IsNullOrEmpty(yearFusyo) ? yearFusyo : year;
                month = !string.IsNullOrEmpty(monthFusyo) ? monthFusyo : month.PadLeft(2, '0');

                //yyyyMM
                return year + month;
            }

            return string.Empty;
        }

        /// <summary>
        /// 不詳年月日(yyyy-MM-dd)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">不詳西暦年月日</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>不詳年月日(yyyy-MM-dd)</returns>
        public static string GetFusyoDateYMD(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 9)
            {
                var yearFusyo = match.Groups[2].Value;      //不詳年(0000)
                var year = match.Groups[3].Value;           //西暦年
                var monthFusyo = match.Groups[5].Value;     //不詳月
                var month = match.Groups[6].Value;          //月
                var dayFusyo = match.Groups[8].Value;       //不詳日
                var day = match.Groups[9].Value;            //日

                year = !string.IsNullOrEmpty(yearFusyo) ? yearFusyo : year;
                month = !string.IsNullOrEmpty(monthFusyo) ? monthFusyo : month.PadLeft(2, '0');
                day = !string.IsNullOrEmpty(dayFusyo) ? dayFusyo : day.PadLeft(2, '0');

                //yyyy-MM-dd
                return year + "-" + month + "-" + day;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年(yyyy)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">和暦年</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年(yyyy)</returns>
        public static string GetWarekiDateY(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 2)
            {
                var era = match.Groups[1].Value;                    //元号の文字列
                var eraYear = match.Groups[2].Value;                //和暦の年
                var year = GetYear(era, eraYear);                   //西暦の年

                //yyyy
                return year;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月(yyyyMM)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">和暦年月</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年月(yyyyMM)</returns>
        public static string GetWarekiDateYM(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 3)
            {
                var era = match.Groups[1].Value;                    //元号の文字列
                var eraYear = match.Groups[2].Value;                //和暦の年
                var year = GetYear(era, eraYear);                   //西暦の年
                var month = match.Groups[3].Value.PadLeft(2, '0');  //月

                //yyyyMM
                return year + month;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月日(yyyy-MM-dd)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">和暦年月日</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年月日(yyyy-MM-dd)</returns>
        public static string GetWarekiDateYMD(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 4)
            {
                var era = match.Groups[1].Value;                    //元号の文字列
                var eraYear = match.Groups[2].Value;                //和暦の年
                var year = GetYear(era, eraYear);                   //西暦の年
                var month = match.Groups[3].Value.PadLeft(2, '0');  //月
                var day = match.Groups[4].Value.PadLeft(2, '0');    //日

                //yyyy-MM-dd
                return year + "-" + month + "-" + day;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年(yyyy)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">西暦年</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年(yyyy)</returns>
        public static string GetDateY(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 1)
            {
                var year = match.Groups[1].Value;                   //西暦の年

                //yyyy
                return year;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月(yyyyMM)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">西暦年月</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年月(yyyyMM)</returns>
        public static string GetDateYM(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 2)
            {
                var year = match.Groups[1].Value;                   //西暦の年
                var month = match.Groups[2].Value.PadLeft(2, '0');  //月

                //yyyyMM
                return year + month;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月日(yyyy-MM-dd)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">西暦年月日</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年月日(yyyy-MM-dd)</returns>
        public static string GetDateYMD(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 3)
            {
                var year = match.Groups[1].Value;                   //西暦の年
                var month = match.Groups[2].Value.PadLeft(2, '0');  //月
                var day = match.Groups[3].Value.PadLeft(2, '0');    //日

                //yyyy-MM-dd
                return year + "-" + month + "-" + day;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月日時間(yyyy/MM/dd HH:mm:ss)を変換取得（和暦から変換）
        /// </summary>
        /// <param name="value">和暦年月日時間</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>西暦年月日時間(yyyy/MM/dd HH:mm:ss)</returns>
        public static string GetWarekiDateYMDHMS(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 7)
            {
                var era = match.Groups[1].Value;                        //元号の文字列
                var eraYear = match.Groups[2].Value;                    //和暦の年
                var year = GetYear(era, eraYear);                       //西暦の年
                var month = match.Groups[3].Value.PadLeft(2, '0');      //月
                var day = match.Groups[4].Value.PadLeft(2, '0');        //日
                var hour = match.Groups[5].Value.PadLeft(2, '0');       //時
                var minute = match.Groups[6].Value.PadLeft(2, '0');     //分
                var second = match.Groups[7].Value.PadLeft(2, '0');     //秒

                //yyyy/MM/dd HH:mm:ss
                return year + "/" + month + "/" + day + " " + hour + ":" + minute + ":" + second;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年月日時間(yyyy/MM/dd HH:mm:ss)を変換取得（西暦から変換）
        /// </summary>
        /// <param name="value">西暦年月日時間</param>
        /// <param name="pattern">フォーマット</param>
        /// <returns>年月日時間(yyyy/MM/dd HH:mm:ss)</returns>
        public static string GetDateYMDHMS(string value, string pattern)
        {
            var match = Regex.Match(value, pattern);
            if (match.Success && match.Groups.Count > 6)
            {
                var year = match.Groups[1].Value;                       //西暦の年
                var month = match.Groups[2].Value.PadLeft(2, '0');      //月
                var day = match.Groups[3].Value.PadLeft(2, '0');        //日
                var hour = match.Groups[4].Value.PadLeft(2, '0');       //時
                var minute = match.Groups[5].Value.PadLeft(2, '0');     //分
                var second = match.Groups[6].Value.PadLeft(2, '0');     //秒

                //yyyy/MM/dd HH:mm:ss
                return year + "/" + month + "/" + day + " " + hour + ":" + minute + ":" + second;
            }

            return string.Empty;
        }

        /// <summary>
        /// 年度取得
        /// </summary>
        public static int GetNendo(DateTime day)
        {
            var nendo = day.Year;
            if (day.Month < 4)
            {
                nendo -= 1;
            }

            return nendo;
        }
    }
}