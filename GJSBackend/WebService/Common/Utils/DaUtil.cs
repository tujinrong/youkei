// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 共通関数
//
// 作成日　　: 2024.07.17
// 作成者　　: AIPlus
// 変更履歴　:
// *******************************************************************
using System.ComponentModel;
using System.Reflection;

namespace Jbd.Gjs.Common
{
    public class DaUtil
    {
        /// <summary>
        /// 現在日時
        /// </summary>
        public static DateTime Now;
            //.InZone(DaConst.TOKYO_TIME_ZONE).ToDateTimeUnspecified();

        /// <summary>
        /// 今日
        /// </summary>
        public static DateTime Today => Now.Date;

        /// <summary>
        /// 年度取得
        /// </summary>
        public static int GetNendo(DateTime day)
        {
            var nendo = day.Year;
            if (day.Month >= 4)
            {
                nendo += 1;
            }

            return nendo;
        }

        /// <summary>
        /// 年度末の取得
        /// </summary>
        public static DateTime GetNendoLastday()
        {
            return GetNendoLastday(Today);
        }

        /// <summary>
        /// 年度末の取得
        /// </summary>
        public static DateTime GetNendoLastday(DateTime date)
        {
            return new DateTime(GetNendo(Today), 3, 31);
        }

        /// <summary>
        /// 年齡計算
        /// </summary>
        //public static int GetAge(DateTime birthday, DateTime kijunday)
        //{
        //    var localBirthday = LocalDate.FromDateTime(birthday);
        //    var localKijunday = LocalDate.FromDateTime(kijunday);
        //    var age = Period.Between(localBirthday, localKijunday).Years;
        //    if (localBirthday.PlusYears(age) > localKijunday)
        //    {
        //        age--;
        //    }

        //    return age;
        //}

        /// <summary>
        /// 年齡計算(本日)
        /// </summary>
        //public static int GetAge(DateTime birthday)
        //{
        //    return GetAge(birthday, Today);
        //}

        /// <summary>
        /// メソッド説明を取得
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetMethodDesc(MethodBase method)
        {
            //MethodBase method = new StackTrace().GetFrame(2)!.GetMethod()!;
            try
            {
                var attribute = method.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
                return attribute.DisplayName;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// サービスクラスの説明を取得
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetServiceDesc(MethodBase method)
        {
            Type type = method.DeclaringType!;
            try
            {
                var attribute = type.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
                return attribute.DisplayName;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 機能IDを取得
        /// </summary>
        public static string GetKinoid(MethodBase method)
        {
            Type type = method.DeclaringType!;
            var ns = type.Namespace!;
            return ns.Substring(ns.LastIndexOf('.') + 1);
        }

        /// <summary>
        /// 四捨五入
        /// </summary>
        public static double Round(double d, int n)
        {
            double num = Math.Pow(10d, n);
            double i = d * num;
            double r = Math.Round(i, MidpointRounding.AwayFromZero);
            return r / num;
        }
    }
}