// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票データ情報
//
// 作成日　　: 2024.02.21
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************
using AdvanceSoftware.VBReport;
using AIplus.AiReport.Common;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace BCC.Affect.DataAccess
{
    public class DaEucCacheService
    {
        // メモリキャシュー
        private const int CACHE_EXPIRE_MINIUTE = 5;
        private static readonly MemoryCache EucMemoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE) });
        //private static readonly object objLock = new();

        /// <summary>
        /// EUCテーブル項目マスタ
        /// </summary>
        public static Dictionary<string, tm_eutableitemDto> GetEutableitemDtoDic(DaDbContext db)
        {
            var dtl = GetEutableitemDtoList(db);
            return dtl.ToDictionary(x => x.sqlcolumn);
        }

        /// <summary>
        /// EUCフォント設定
        /// </summary>
        public static string[][] GetEUDCFiles(DaDbContext db)
        {
            var key = $"GetEUDCFiles";
            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null) return (string[][])cache;

            var dtl = DaControlService.GetList(db, "1006", 5);
            var list = new List<string[]>();
            foreach (var dto in dtl)
            {
                //string baseDirectory = AppContext.BaseDirectory;
                //string fontRelativePath1 = ".\\Resources\\acgjm.ttf";              //追加のファイル（移動待ち）
                //string fullPath1 = Path.Combine(baseDirectory, fontRelativePath1);
                //string fontRelativePath2 = ".\\Resources\\EUDC.TTE";               //その他フォントのファイル（移動待ち）
                //string fullPath2 = Path.Combine(baseDirectory, fontRelativePath2);

                //if (File.Exists(fullPath1) == false || File.Exists(fullPath2) == false)
                //    throw new Exception("Font file not exist");
                string fontName = dto.value1 ?? "";
                string fontPath = dto.value2 ?? "";
                if (fontPath != "")
                {
                    string baseDirectory = AppContext.BaseDirectory;
                    fontPath = Path.Combine(baseDirectory, fontPath);
                    if (!File.Exists(fontPath)) 
                    {
                        fontPath = "";
                    }
                }
              
                var row = new string[] { fontName, fontPath};
                list.Add(row);
            }
            var files = list.ToArray();
            EucMemoryCache.Set(key, files, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return files;
        }

        /// <summary>
        /// EUCテーブル項目マスタ
        /// </summary>
        public static List<tm_eutableDto> GetEutableDtoList(DaDbContext db)
        {
            var key = $"{nameof(tm_eutableDto)}";
            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null) return (List<tm_eutableDto>)cache;

            var dtl = db.tm_eutable.SELECT.GetDtoList();
            EucMemoryCache.Set(key, dtl, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return dtl;
        }

        /// <summary>
        /// EUCテーブル項目マスタ
        /// </summary>
        public static List<tm_eutableitemDto> GetEutableitemDtoList(DaDbContext db)
        {
            var key = $"{nameof(tm_eutableitemDto)}";
            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null) return (List<tm_eutableitemDto>)cache;

            var dtl = db.tm_eutableitem.SELECT.GetDtoList();
            EucMemoryCache.Set(key, dtl, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return dtl;
        }

        /// <summary>
        /// EUCテーブル結合マスタ
        /// </summary>
        public static List<tm_eutablejoinDto> GetEutablejoinDtoList(DaDbContext db)
        {
            var key = $"{nameof(tm_eutablejoinDto)}";
            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null) return (List<tm_eutablejoinDto>) cache;

            var dtl = db.tm_eutablejoin.SELECT.GetDtoList();
            EucMemoryCache.Set(key, dtl, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return dtl;
        }

        ///// <summary>
        ///// EUC帳票マスタ
        ///// </summary>
        //public static tm_eurptDto? GetTm_eurptByRptID(DaDbContext db, string? rptID)
        //{
        //    if (string.IsNullOrWhiteSpace(rptID)) return null;
        //    if (EucMemoryCache.TryGetValue($"{tm_eurptDto.TABLE_NAME}{nameof(tm_eurptDto.rptid)}{rptID}", out var cache) && cache != null) return (tm_eurptDto)cache;

        //    var mTm_eurptDto = db.tm_eurpt.SELECT.WHERE.ByKey(rptID).GetDto();
        //    EucMemoryCache.Set($"{ tm_eurptDto.TABLE_NAME}{nameof(tm_eurptDto.rptid)}{rptID}", mTm_eurptDto, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
        //    return mTm_eurptDto;
        //}

        /// <summary>
        /// EUCテーブルマスタ
        /// </summary>
        public static tm_eutableDto? GetTm_eutableByTablealias(DaDbContext db, string? tablealias)
        {
            if (string.IsNullOrWhiteSpace(tablealias)) return null;
            if (EucMemoryCache.TryGetValue($"{tm_eutableDto.TABLE_NAME}{nameof(tm_eutableDto.tablealias)}{tablealias}", out var cache) && cache != null) return (tm_eutableDto)cache;

            var mTm_eutableDto = db.tm_eutable.SELECT.WHERE.ByKey(tablealias).GetDto();
            EucMemoryCache.Set($"{tm_eutableDto.TABLE_NAME}{nameof(tm_eutableDto.tablealias)}{tablealias}", mTm_eutableDto, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return mTm_eutableDto;
        }

        /// <summary>
        /// EUCデータソースマスタ
        /// </summary>
        public static tm_eudatasourceDto? GetTm_eudatasourceByDataSourceID(DaDbContext db, string? dataSourceID)
        {
            if (string.IsNullOrWhiteSpace(dataSourceID)) return null;
            if (EucMemoryCache.TryGetValue($"{tm_eudatasourceDto.TABLE_NAME}{nameof(tm_eudatasourceDto.datasourceid)}{dataSourceID}", out var cache) && cache != null) return (tm_eudatasourceDto)cache;

            var mTm_eudatasourceDto = db.tm_eudatasource.SELECT.WHERE.ByKey(dataSourceID).GetDto();
            EucMemoryCache.Set($"{tm_eudatasourceDto.TABLE_NAME}{nameof(tm_eudatasourceDto.datasourceid)}{dataSourceID}", mTm_eudatasourceDto, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return mTm_eudatasourceDto;
        }

        /// <summary>
        /// EUCデータソース検索マスタ
        /// </summary>
        public static tm_eudatasourcekensakuDto? GetTm_eudatasourcekensakuByDoubleID(DaDbContext db, string? dataSourceID, int? jyokenid)
        {
            if (string.IsNullOrWhiteSpace(dataSourceID) || !jyokenid.HasValue) return null;
            //if (EucMemoryCache.TryGetValue($"{tm_eudatasourcekensakuDto.TABLE_NAME}{nameof(tm_eudatasourcekensakuDto.datasourceid)}{nameof(tm_eudatasourcekensakuDto.jyokenid)}{dataSourceID}_{jyokenid}", out var cache) && cache != null) return (tm_eudatasourcekensakuDto)cache;

            var mTm_eudatasourcekensakuDto = db.tm_eudatasourcekensaku.SELECT.WHERE.ByKey(dataSourceID, jyokenid).GetDto();
            //EucMemoryCache.Set($"{tm_eudatasourcekensakuDto.TABLE_NAME}{nameof(tm_eudatasourcekensakuDto.datasourceid)}{nameof(tm_eudatasourcekensakuDto.jyokenid)}{dataSourceID}_{jyokenid}", mTm_eudatasourcekensakuDto, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return mTm_eudatasourcekensakuDto;
        }

        /// <summary>
        /// 汎用マスタ(自治体情報（1001-1-01）課名（1001－2）係名（1001－3）問い合わせ内容コード（1001ー4）)
        /// </summary>
        public static string Gettm_afhanyoInfo(DaDbContext db, string? hanyomaincd, int? hanyosubcd, string? hanyocd)
        {
            if (string.IsNullOrWhiteSpace(hanyomaincd) || !hanyosubcd.HasValue ||  string.IsNullOrWhiteSpace(hanyocd)) return string.Empty;
            if (EucMemoryCache.TryGetValue($"{tm_afhanyoDto.TABLE_NAME}{nameof(tm_afhanyoDto.hanyomaincd)}{nameof(tm_afhanyoDto.hanyosubcd)}{nameof(tm_afhanyoDto.hanyocd)}{hanyomaincd}_{hanyosubcd}_{hanyocd}", out var cache) && cache != null) return (string)cache;
            tm_afhanyoDto mTm_afhanyoDto = (tm_afhanyoDto)db.tm_afhanyo.SELECT.WHERE.ByKey(hanyomaincd, hanyosubcd, hanyocd).GetDto();
            string nm = string.Empty;
            if (mTm_afhanyoDto != null) nm = mTm_afhanyoDto.nm;
            EucMemoryCache.Set($"{tm_afhanyoDto.TABLE_NAME}{nameof(tm_afhanyoDto.hanyomaincd)}{nameof(tm_afhanyoDto.hanyosubcd)}{nameof(tm_afhanyoDto.hanyocd)}{hanyomaincd}_{hanyosubcd}_{hanyocd}", nm, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return nm;
        }

        /// <summary>
        /// EUCテーブル項目名称マスタ
        /// </summary>
        public static tm_eutableitemnameDto GetEutableitemnameDto(DaDbContext db, string mastercd)
        {
            if (string.IsNullOrWhiteSpace(mastercd)) return null;
            if (EucMemoryCache.TryGetValue($"{tm_eutableitemnameDto.TABLE_NAME}{nameof(tm_eutableitemnameDto.mastercd)}{mastercd}", out var cache) && cache != null) return (tm_eutableitemnameDto)cache;

            var mTm_eutableitemnameDto = db.tm_eutableitemname.SELECT.WHERE.ByKey(mastercd).GetDto();
            EucMemoryCache.Set($"{tm_eutableitemnameDto.TABLE_NAME}{nameof(tm_eutableitemnameDto.mastercd)}{mastercd}", mTm_eutableitemnameDto, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return mTm_eutableitemnameDto;
        }

        /// <summary>
        /// 項目名称情報
        /// </summary>
        public static List<ValueCaptionModel> LstValueCaptionModel(DaDbContext db, tm_eutableitemnameDto tblItemName, tm_eurptitemDto item)
        {
            var key = $"ValueCaptionModel{tm_eutableitemnameDto.TABLE_NAME}{nameof(tm_eutableitemnameDto.mastercd)}{item.mastercd}{item.masterpara}";
            if (string.IsNullOrWhiteSpace(item.mastercd)) return new List<ValueCaptionModel>();
            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null) return (List<ValueCaptionModel>)cache;
            var sql = $@"
SELECT 
 T.{tblItemName.keynm} AS value,          --Values
 T.{tblItemName.meisyonm} AS caption      --Captions
FROM {tblItemName.tablenm} T ";

            if (!string.IsNullOrWhiteSpace(item.masterpara))
            {
                string[] paras = item.masterpara.Split(',');
                if (paras.Length == 1 && !string.IsNullOrWhiteSpace(tblItemName.maincd))
                {
                    sql = sql + $@" WHERE T.{tblItemName.maincd} = '{paras[0]}' ";
                }
                else if (paras.Length == 2 && !string.IsNullOrWhiteSpace(tblItemName.maincd) && !string.IsNullOrWhiteSpace(tblItemName.subcd))
                {
                    sql = sql + $@" WHERE T.{tblItemName.maincd} = '{paras[0]}'  AND T.{tblItemName.subcd} = '{paras[1]}' ";
                }
            }

            //ソート順
            sql = sql + $@" ORDER BY value, caption ";

            List<ValueCaptionModel> LstVC = db.Session.Query<ValueCaptionModel>(sql);
            EucMemoryCache.Set(key, LstVC, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));
            return LstVC;
        }

        /// <summary>
        /// データベース内のすべてのテーブルのフィールド名とそれに対応するフィールドの説明（コメント）を取得する
        /// </summary>
        public static Dictionary<string, string> GetColumnDescDic(DaDbContext db)
        {
            string key = "GetColumnDescDic";

            if (EucMemoryCache.TryGetValue(key, out var cache) && cache != null)
            {
                return (Dictionary<string, string>)cache;
            }

            string sql = $@"SELECT
                                a.attname AS value                    -- カラム名
                                , max(d.description) AS caption      -- カラムのコメント
                            FROM
                                pg_catalog.pg_class c 
                                JOIN pg_catalog.pg_namespace n 
                                    ON n.oid = c.relnamespace 
                                JOIN pg_catalog.pg_attribute a 
                                    ON a.attrelid = c.oid 
                                LEFT JOIN pg_catalog.pg_description d 
                                    ON d.objoid = a.attrelid 
                                    AND d.objsubid = a.attnum 
                            WHERE
                                c.relkind = 'r'                             -- 'r' は通常のテーブルを示す
                                AND a.attnum > 0                            -- 有効なテーブルフィールドであること
                                AND NOT a.attisdropped                      -- 削除されていないフィールドであること
                                AND n.nspname = 'public' 
                                AND (c.relname like 'tt_%' or c.relname like 'tm_%') 
                                AND c.relname NOT SIMILAR TO 'tt_eu%|tm_eu%|tm_kktori%|tt_kktori%'
                                AND d.description is not null 
                            group by
                                a.attname
                            ";

            List<ValueCaptionModel> listVC = db.Session.Query<ValueCaptionModel>(sql);

            var dic = listVC.ToDictionary(x => x.value, x => x.caption);

            EucMemoryCache.Set(key, dic, TimeSpan.FromMinutes(CACHE_EXPIRE_MINIUTE));

            return dic;
        }
    }
}