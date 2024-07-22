// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: フリー項目管理サービス
//
// 作成日　　: 2024.01.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using Microsoft.Extensions.Caching.Memory;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaFreeItemService
    {
        private static MemoryCache _cache;
        const int CACHE_MINIUTE = 5;

        /// <summary>
        /// キャシュークリア
        /// </summary>
        public static void ClearCache()
        {
            _cache?.Clear();
        }

        /// <summary>
        /// フリー項目情報の取得
        /// </summary>
        public static List<tm_shfreeitemDto> GetKensinList(DaDbContext db, string jigyo)
        {
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            var key = $"{nameof(GetKensinList)}_{jigyo}";
            List<tm_shfreeitemDto> data;
            if (!_cache.TryGetValue(key, out data!))
            {
                string sql = $"SELECT * FROM {tm_shfreeitemDto.TABLE_NAME} WHERE {nameof(tm_shfreeitemDto.jigyocd)} = '{jigyo}'  ";
                data = db.Session.Query<tm_shfreeitemDto>(sql);
                _cache.Set(key, data, TimeSpan.FromMinutes(CACHE_MINIUTE));
            }
            return data;
        }

        /// <summary>
        /// フリー項目情報の取得
        /// </summary>
        public static List<tm_kksidofreeitemDto> GetSidoList(DaDbContext db, Enum項目用途区分 kbn)
        {
            var itemyotokbn = EnumToStr(kbn);
            if (_cache == null)
            {
                _cache = new MemoryCache(new MemoryCacheOptions());
            }

            var key = $"{nameof(GetSidoList)}_{itemyotokbn}";
            List<tm_kksidofreeitemDto> data;
            if (!_cache.TryGetValue(key, out data!))
            {
                string sql = $"SELECT * FROM {tm_kksidofreeitemDto.TABLE_NAME} WHERE {nameof(tm_kksidofreeitemDto.itemyotokbn)} = '{itemyotokbn}'";
                data = db.Session.Query<tm_kksidofreeitemDto>(sql);
                _cache.Set(key, data, TimeSpan.FromMinutes(CACHE_MINIUTE));
            }
            return data;
        }

        /// <summary>
        /// 事業コード、項目コードを指定し、フリー項目情報の取得
        /// </summary>
        public static tm_shfreeitemDto? GetKensinItemInfo(DaDbContext db, string jigyo, string itemcd)
        {
            var list = GetKensinList(db, jigyo);
            return list.Find(e => e.itemcd == itemcd);
        }


        /// <summary>
        /// 事業コード、項目コードを指定し、フリー項目情報の取得
        /// </summary>
        public static tm_kksidofreeitemDto? GetSidoItemInfo(DaDbContext db, Enum項目用途区分 itemyotokbn, string itemcd)
        {
            var list = GetSidoList(db, itemyotokbn);
            return list.Find(e => e.itemcd == itemcd);
        }

    }
}