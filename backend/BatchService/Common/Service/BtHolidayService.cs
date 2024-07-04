// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: バッチサービス
//            祝日管理
// 作成日　　: 2023.03.12
// 作成者　　: 屠
// 変更履歴　: 
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using NPOI.SS.Formula.Functions;
using System.Globalization;

namespace BCC.Affect.BatchService
{
    public class BtHolidayService
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;

        /// <summary>
        /// 祝日
        /// </summary>
        public static bool IsHoliday(DaDbContext db, DateTime date)
        {
            if (date.DayOfWeek == DayOfWeek.Sunday) return true;

            var holiday = GetHoliday(db);
            return (holiday.Contains(date));
        }

        /// <summary>
        /// 次の稼働日
        /// </summary>
        public static DateTime GetNextWorkDay(DaDbContext db, DateTime date)
        {
            for (int i = 1; i <= 30; i++)
            {
                var d = date.AddDays(i);
                if (!IsHoliday(db, d)) return d;
            }
            return date;
        }


        private static List<DateTime> GetHoliday(DaDbContext db)
        {
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }
            List<DateTime> data;
            var key = "Holiday";
            if (!_cache.TryGetValue(key, out data!))
            {
                var maincd = "1000";
                var subcd = 8;
                var dtl = db.tm_afhanyo.SELECT.WHERE.ByKey(maincd, subcd).GetDtoList();
                data=new List<DateTime>();
                foreach (var dt in dtl)
                {
                    var date = dt.hanyocd!;
                    DateTime dateAdd;
                    if (DateTime.TryParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        dateAdd = parsedDate;
                    }
                    else 
                    {
                        dateAdd = DateTime.Parse(date);
                    }
                    data.Add(dateAdd);

                }
                _cache.Set(key, data, TimeSpan.FromMinutes(CACHE_MINIUTE));
            }
            return data;
        }

    }
}
