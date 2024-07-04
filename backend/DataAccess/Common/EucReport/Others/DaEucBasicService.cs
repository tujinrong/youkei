// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票テーブル
//
// 作成日　　: 2023.04.07
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using Microsoft.Extensions.Caching.Memory;
using NpgsqlTypes;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using static BCC.Affect.DataAccess.DaStrPool;

namespace BCC.Affect.DataAccess
{
    [SuppressMessage("ReSharper", "InconsistentlySynchronizedField")]
    public static class DaEucBasicService
    {
        public static MemoryCache _memoryCache = new(new MemoryCacheOptions { ExpirationScanFrequency = TimeSpan.FromMinutes(5) });

        public static tm_eutableDto? GetTable(DaDbContext db, string? tablealias)
        {
            if (string.IsNullOrEmpty(tablealias)) return null;
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableList.Find(x => tablealias.Equals(x.tablealias, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        public static List<tm_eutableDto> GetTableDtl(DaDbContext db, IEnumerable<string?> tablealiasColl)
        {
            var tablealiasSet = tablealiasColl.Where(x => !string.IsNullOrEmpty(x)).ToHashSet(StringComparer.OrdinalIgnoreCase);
            if (!tablealiasSet.Any()) return new List<tm_eutableDto>();
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableList.Where(x => tablealiasSet.Contains(x.tablealias)).ToList()
                : new List<tm_eutableDto>();
        }

        //public static string GetTableHyojiNm(DaDbContext db, string? tablealias)
        //{
        //    return GetTable(db, tablealias)?.tablehyojinm ?? string.Empty;
        //}

        public static tm_eutableitemDto? GetTableItemDtoBySqlColumn(DaDbContext db, string? sqlcolumn)
        {
            if (string.IsNullOrEmpty(sqlcolumn)) return null;
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableItemList.Find(x => sqlcolumn.Equals(x.sqlcolumn, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        //public static List<tm_eutableitemDto> GetTableItemDtlBySqlColumns(DaDbContext db, IEnumerable<string?> sqlcolumns)
        //{
        //    var sqlcolumnsSet = sqlcolumns.Where(x => !string.IsNullOrEmpty(x)).ToHashSet(StringComparer.OrdinalIgnoreCase);
        //    if (!sqlcolumnsSet.Any()) return new List<tm_eutableitemDto>();
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? cache.TableItemList.Where(x => sqlcolumnsSet.Contains(x.sqlcolumn)).ToList()
        //        : new List<tm_eutableitemDto>();
        //}

        public static tm_eutableitemDto? GetTableItemDtoByItemCd(DaDbContext db, string? itemcd)
        {
            if (string.IsNullOrEmpty(itemcd)) return null;
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableItemList.FirstOrDefault(x => itemcd.Equals(x.sqlcolumn, StringComparison.OrdinalIgnoreCase))
                : null;
        }

        //public static string GetTableItemHyojiNm(DaDbContext db, string? sqlcolumn)
        //{
        //    return GetTableItemDtoBySqlColumn(db, sqlcolumn)?.itemhyojinm ?? string.Empty;
        //}

        public static List<tm_eutableDto> GetAllTables(DaDbContext db)
        {
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableList
                : new List<tm_eutableDto>();
        }

        //public static List<tm_eutableDtoExt> GetAllTablesWithItems(DaDbContext db)
        //{
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? cache.TableExtList
        //        : new List<tm_eutableDtoExt>();
        //}

        //public static List<tm_eutableDtoExt> GetManyTablesWithItems(DaDbContext db, IEnumerable<string?> tablealiasColl)
        //{
        //    var notEmptyTablealiasList = tablealiasColl.Where(x => !string.IsNullOrEmpty(x)).ToList();
        //    if (!notEmptyTablealiasList.Any()) return new List<tm_eutableDtoExt>();
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    if (!_memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) || cache == null) return new List<tm_eutableDtoExt>();
        //    return notEmptyTablealiasList.Join(cache.TableExtList, tableAlias => tableAlias, tableExtDto => tableExtDto.tablealias, (_, tableExtDto) => tableExtDto).ToList();
        //}

        //public static List<tm_eutableitemDto> GetAllItemList(DaDbContext db)
        //{
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? cache.TableItemList
        //        : new List<tm_eutableitemDto>();
        //}

        //public static List<tm_eutableitemDto> GetTableItemDtl(DaDbContext db, params string?[] tablealiasArray)
        //{
        //    var tableitemDtl = new List<tm_eutableitemDto>();
        //    if (!tablealiasArray.Any()) return tableitemDtl;
        //    var tablealiasDistinctList = tablealiasArray.Where(x => !string.IsNullOrEmpty(x)).Distinct(StringComparer.OrdinalIgnoreCase).ToList();
        //    if (!tablealiasDistinctList.Any()) return tableitemDtl;
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    if (!_memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) || cache == null) return tableitemDtl;

        //    foreach (var tableAlias in tablealiasDistinctList)
        //    {
        //        if (cache.TableAlias2ItemsDic.TryGetValue(tableAlias!, out var items))
        //        {
        //            tableitemDtl.AddRange(items);
        //        }
        //    }

        //    return tableitemDtl;
        //}

        //public static List<tm_eutableitemDto> GetManyTableItemList(DaDbContext db, IEnumerable<string?> tablealiasColl)
        //{
        //    var notEmptyTablealiasList = tablealiasColl.Where(x => !string.IsNullOrEmpty(x)).ToList();
        //    if (!notEmptyTablealiasList.Any()) return new List<tm_eutableitemDto>();
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? notEmptyTablealiasList.Select(tablealias => cache.TableAlias2ItemsDic.GetValueOrDefault(tablealias!)).Where(x => x != null && x.Any()).SelectMany(list => list!).ToList()
        //        : new List<tm_eutableitemDto>();
        //}

        public static List<tm_eutablejoinDto> GetAllTableJoinDtl(DaDbContext db)
        {
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableJoinList
                : new List<tm_eutablejoinDto>();
        }

        //public static List<tm_eutablejoinDto> GetTableJoinDtl(DaDbContext db, string? tablealias)
        //{
        //    if (string.IsNullOrEmpty(tablealias)) return new List<tm_eutablejoinDto>();
        //    RefreshEucTableCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? cache.TableAlias2JoinsDic.GetValueOrDefault(tablealias, new List<tm_eutablejoinDto>())
        //        : new List<tm_eutablejoinDto>();
        //}

        public static tm_eutablejoinDto? GetTableJoinDto(DaDbContext db, string? tablealias, string? kanrentablealias)
        {
            if (string.IsNullOrEmpty(tablealias) || string.IsNullOrEmpty(kanrentablealias)) return null;
            RefreshEucTableCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableAlias2JoinsDic.GetValueOrDefault(tablealias, new List<tm_eutablejoinDto>()).FirstOrDefault(x => x.kanrentablealias == kanrentablealias)
                : null;
        }

        public static List<FunctionVM> GetFunctionListPrefixed(DaDbContext db, string? functionNamePrefix = null)
        {
            RefreshFunctionCacheInfoIfExpired(db, functionNamePrefix);
            return _memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? string.IsNullOrEmpty(functionNamePrefix) ? cache.FunctionList : cache.FunctionList.Where(x => x.name.StartsWith(functionNamePrefix, StringComparison.OrdinalIgnoreCase)).ToList()
                : new List<FunctionVM>();
        }

        public static FunctionVM? GetFunctionByName(DaDbContext db, string? functionName, string? functionNamePrefix = null)
        {
            if (string.IsNullOrEmpty(functionName)) return null;
            RefreshFunctionCacheInfoIfExpired(db, functionNamePrefix);
            return _memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.FunctionDic.GetValueOrDefault(functionName)
                : null;
        }

        public static FunctionVM? RefreshCacheThenGetFunctionByName(DaDbContext db, string? functionName, string? necessaryPrefix = null)
        {
            if (string.IsNullOrEmpty(functionName)) return null;
            ForceRefreshFunctionInfoCacheInfo(db, necessaryPrefix);
            return _memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.FunctionDic.GetValueOrDefault(functionName)
                : null;
        }

        public static FunctionVM? GetFunctionVMByName(DaDbContext db, string? functionName, string? necessaryPrefix = null)
        {
            if (_memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null)
            {
                return cache!.FunctionDic!.GetValueOrDefault(functionName);
            }
            else
            {
                return RefreshCacheThenGetFunctionByName(db, functionName, necessaryPrefix);
            }
        }

        public static bool IsFunctionExists(DaDbContext db, string? functionName, string? necessaryPrefix = null)
        {
            if (string.IsNullOrEmpty(functionName)) return false;
            RefreshFunctionCacheInfoIfExpired(db, necessaryPrefix);
            return _memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null && cache.FunctionDic.ContainsKey(functionName);
        }

        //public static EucTemplateFileInfo GetExcelTemplateInfo(DaDbContext db, string? siyokbn) //todo siyokbn
        //{
        //    if (string.IsNullOrEmpty(siyokbn)) return EucTemplateFileInfo.EMPTY;
        //    RefreshEucTemplateCacheInfoIfExpired(db);
        //    return _memoryCache.TryGetValue<EucTemplateCacheInfo>(EucTemplateCacheInfo.CACHE_KEY, out var cache) && cache != null
        //        ? cache.TemplateDic.GetValueOrDefault(siyokbn, EucTemplateFileInfo.EMPTY)
        //        : EucTemplateFileInfo.EMPTY;
        //}

        public static List<tm_eutableitemnameDto> GetTableItemNameDtl(DaDbContext db)
        {
            RefreshEucTableItemNameCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableItemNameCacheInfo>(EucTableItemNameCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableItemNameList
                : new List<tm_eutableitemnameDto>();
        }

        public static tm_eutableitemnameDto? GetTableItemNameDtoByMastercd(DaDbContext db, string? mastercd)
        {
            if (mastercd == null) return null;
            RefreshEucTableItemNameCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<EucTableItemNameCacheInfo>(EucTableItemNameCacheInfo.CACHE_KEY, out var cache) && cache != null
                ? cache.TableItemNameDic.GetValueOrDefault(mastercd)
                : null;
        }

        public static List<DaSelectorKeyModel>? GetMainCdSelectorList(DaDbContext db, string? masterTableName)
        {
            if (masterTableName == null || !SpecialMasterCacheInfo.HAS_MAIN_CD_TABLES.Contains(masterTableName)) return null;
            RefreshSpecialMasterCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<SpecialMasterCacheInfo>(SpecialMasterCacheInfo.CACHE_KEY, out var cache) && cache != null ? cache.GetMainCdSelectorList(masterTableName) : null;
        }

        public static List<DaSelectorKeyModel>? GetSubCdSelectorList(DaDbContext db, string? masterTableName)
        {
            if (masterTableName == null || !SpecialMasterCacheInfo.HAS_SUB_CD_TABLES.Contains(masterTableName)) return null;
            RefreshSpecialMasterCacheInfoIfExpired(db);
            return _memoryCache.TryGetValue<SpecialMasterCacheInfo>(SpecialMasterCacheInfo.CACHE_KEY, out var cache) && cache != null ? cache.GetSubCdSelectorList(masterTableName) : null;
        }

        /// <summary>
        /// refresh the euc table cache if it's expired
        /// </summary>
        private static void RefreshEucTableCacheInfoIfExpired(DaDbContext db)
        {
            if (_memoryCache.TryGetValue<EucTableCacheInfo>(EucTableCacheInfo.CACHE_KEY, out var cache) && cache != null) return;
            lock (EucTableCacheInfo.LockObj)
            {
                if (_memoryCache.TryGetValue(EucTableCacheInfo.CACHE_KEY, out cache) && cache != null) return;
                ForceRefreshEucTableInfoCacheInfo(db);
            }
        }

        /// <summary>
        /// refresh euc table item name cache if it's expired
        /// </summary>
        private static void RefreshEucTableItemNameCacheInfoIfExpired(DaDbContext db)
        {
            if (_memoryCache.TryGetValue<EucTableItemNameCacheInfo>(EucTableItemNameCacheInfo.CACHE_KEY, out var cache) && cache != null) return;
            lock (EucTableItemNameCacheInfo.LockObj)
            {
                if (_memoryCache.TryGetValue(EucTableItemNameCacheInfo.CACHE_KEY, out cache) && cache != null) return;
                ForceRefreshEucTableItemNameCacheInfo(db);
            }
        }

        /// <summary>
        /// refresh the function cache if it's expired
        /// </summary>
        private static void RefreshFunctionCacheInfoIfExpired(DaDbContext db, string? functionNamePrefix = null)
        {
            if (_memoryCache.TryGetValue<FunctionCacheInfo>(FunctionCacheInfo.CACHE_KEY, out var cache) && cache != null) return;
            lock (FunctionCacheInfo.LockObj)
            {
                if (_memoryCache.TryGetValue(FunctionCacheInfo.CACHE_KEY, out cache) && cache != null) return;
                ForceRefreshFunctionInfoCacheInfo(db, functionNamePrefix);
            }
        }

        /// <summary>
        /// refresh the euc template cache if it's expired
        /// </summary>
        //private static void RefreshEucTemplateCacheInfoIfExpired(DaDbContext db)
        //{
        //    if (_memoryCache.TryGetValue<EucTemplateCacheInfo>(EucTemplateCacheInfo.CACHE_KEY, out var cache) && cache != null) return;
        //    lock (EucTemplateCacheInfo.LockObj)
        //    {
        //        if (_memoryCache.TryGetValue(EucTemplateCacheInfo.CACHE_KEY, out cache) && cache != null) return;
        //        ForceRefreshEucTemplateCacheInfo(db);
        //    }
        //}

        /// <summary>
        /// refresh the special master cache if it's expired
        /// </summary>
        private static void RefreshSpecialMasterCacheInfoIfExpired(DaDbContext db)
        {
            if (_memoryCache.TryGetValue<SpecialMasterCacheInfo>(SpecialMasterCacheInfo.CACHE_KEY, out var cache) && cache != null) return;
            lock (SpecialMasterCacheInfo.LockObj)
            {
                if (_memoryCache.TryGetValue(SpecialMasterCacheInfo.CACHE_KEY, out cache) && cache != null) return;
                ForceRefreshSpecialMasterCacheInfo(db);
            }
        }

        /// <summary>
        /// force refresh euc table cache
        /// </summary>
        private static void ForceRefreshEucTableInfoCacheInfo(DaDbContext db)
        {
            var tableList = db.tm_eutable.SELECT.ORDER.By(nameof(tm_eutableDto.orderseq),nameof(tm_eutableDto.tablehyojinm)).GetDtoList();
            var tableItemList = db.tm_eutableitem.SELECT.ORDER.By(nameof(tm_eutableitemDto.orderseq)).GetDtoList()
                .Where(x => !int.TryParse(x.itemid.Split(C_UNDERLINE, StringSplitOptions.TrimEntries)[0], out var num) || num < tm_eutableitemDto.EDITABLE_ITEM_ID_MIN_PREFIX ||
                            num > tm_eutableitemDto.EDITABLE_ITEM_ID_MAX_PREFIX)
                .ToList();
            var tableJoinList = db.tm_eutablejoin.SELECT.ORDER.By(nameof(tm_eutablejoinDto.tablealias), nameof(tm_eutablejoinDto.orderseq)).GetDtoList();
            _memoryCache.Set(EucTableCacheInfo.CACHE_KEY, new EucTableCacheInfo(tableList, tableItemList, tableJoinList), TimeSpan.FromMinutes(EucTableCacheInfo.CACHE_EXPIRE_MINIUTE));
        }

        /// <summary>
        /// force refresh euc table item name cache
        /// </summary>
        private static void ForceRefreshEucTableItemNameCacheInfo(DaDbContext db)
        {
            var tableitemnameDtl = db.tm_eutableitemname.SELECT.ORDER.By(nameof(tm_eutableitemnameDto.mastercd)).GetDtoList();
            _memoryCache.Set(EucTableItemNameCacheInfo.CACHE_KEY, new EucTableItemNameCacheInfo(tableitemnameDtl), TimeSpan.FromMinutes(EucTableItemNameCacheInfo.CACHE_EXPIRE_MINIUTE));
        }

        /// <summary>
        /// force refresh function cache
        /// </summary>
        private static void ForceRefreshFunctionInfoCacheInfo(DaDbContext db, string? functionNamePrefix = null)
        {
            List<AiKeyValue>? param = GetParameters(functionNamePrefix);

            var functionList = DaDbUtil.GetProcedureData(db, FunctionVM.PROC_NAME, param).Rows.Cast<DataRow>().Select(x => new FunctionVM(x));
            _memoryCache.Set(FunctionCacheInfo.CACHE_KEY, new FunctionCacheInfo(functionList), TimeSpan.FromMinutes(FunctionCacheInfo.CACHE_EXPIRE_MINIUTE));
        }

        private static List<AiKeyValue> GetParameters(string? functionNamePrefix = null)
        {
            List<AiKeyValue>? param = null;
            if (!string.IsNullOrEmpty(functionNamePrefix))
            {
                param = new List<AiKeyValue> { new($"proname_in", $"{functionNamePrefix}%") };
            }
            else
            {
                param = new List<AiKeyValue> { new($"proname_in", null) };
            }
            return param;
        }

        /// <summary>
        /// force refresh euc template cache
        /// </summary>
        //private static void ForceRefreshEucTemplateCacheInfo(DaDbContext db)
        //{
        //    var templateFileDtl = db.tm_eutemplatefile.SELECT.GetDtoList();
        //    _memoryCache.Set(EucTemplateCacheInfo.CACHE_KEY, new EucTemplateCacheInfo(templateFileDtl), TimeSpan.FromMinutes(EucTemplateCacheInfo.CACHE_EXPIRE_MINIUTE));
        //}

        /// <summary>
        /// force refresh euc special master cache
        /// </summary>
        private static void ForceRefreshSpecialMasterCacheInfo(DaDbContext db)
        {
            var tikuDtl = db.tm_aftiku.SELECT.SetSelectItems(nameof(tm_aftikuDto.tikukbn)).SetDistinct().WHERE.ByItem(nameof(tm_aftikuDto.stopflg), false).ORDER.By(nameof(tm_aftikuDto.tikukbn))
                .GetDtoList();
            _memoryCache.Set(SpecialMasterCacheInfo.CACHE_KEY, new SpecialMasterCacheInfo(db, tikuDtl),
                TimeSpan.FromMinutes(SpecialMasterCacheInfo.CACHE_EXPIRE_MINIUTE));
        }
    }

    internal class EucTableCacheInfo
    {
        public const string CACHE_KEY = nameof(EucTableCacheInfo);
        public const int CACHE_EXPIRE_MINIUTE = 5;
        public static readonly object LockObj = new();

        public readonly List<tm_eutableDto> TableList;
        public readonly List<tm_eutableDtoExt> TableExtList;
        public readonly List<tm_eutableitemDto> TableItemList;
        public readonly List<tm_eutablejoinDto> TableJoinList;
        public readonly Dictionary<string, List<tm_eutableitemDto>> TableAlias2ItemsDic;
        public readonly Dictionary<string, List<tm_eutablejoinDto>> TableAlias2JoinsDic;

        public EucTableCacheInfo(List<tm_eutableDto> tableList, List<tm_eutableitemDto> tableItemList, List<tm_eutablejoinDto> tableJoinList)
        {
            TableList = tableList;
            TableItemList = tableItemList;
            TableJoinList = tableJoinList;

            TableAlias2ItemsDic = tableList.ToDictionary(
                x => x.tablealias,
                x => tableItemList.Where(item => x.tablealias.Equals(item.tablealias, StringComparison.OrdinalIgnoreCase)).ToList(),
                StringComparer.OrdinalIgnoreCase);

            TableAlias2JoinsDic = tableJoinList.GroupBy(x => x.tablealias).ToDictionary(g => g.Key, g => g.ToList());

            TableExtList = tableList.Select(x => tm_eutableDtoExt.ToDtoExt(x, TableAlias2ItemsDic.GetValueOrDefault(x.tablealias, new List<tm_eutableitemDto>()))).ToList();
        }
    }

    internal class EucTableItemNameCacheInfo
    {
        public const string CACHE_KEY = nameof(EucTableItemNameCacheInfo);
        public const int CACHE_EXPIRE_MINIUTE = 10;
        public static readonly object LockObj = new();

        public readonly List<tm_eutableitemnameDto> TableItemNameList;
        public readonly Dictionary<string, tm_eutableitemnameDto> TableItemNameDic;

        public EucTableItemNameCacheInfo(IReadOnlyCollection<tm_eutableitemnameDto> tableItemNameDtl)
        {
            TableItemNameList = tableItemNameDtl.ToList();
            TableItemNameDic = tableItemNameDtl.ToDictionary(x => x.mastercd, x => x);
        }
    }

    internal class FunctionCacheInfo
    {
        public const string CACHE_KEY = nameof(FunctionCacheInfo);
        public const int CACHE_EXPIRE_MINIUTE = 10;
        public static readonly object LockObj = new();

        public readonly List<FunctionVM> FunctionList;
        public readonly Dictionary<string, FunctionVM> FunctionDic;

        public FunctionCacheInfo(IEnumerable<FunctionVM> functionList)
        {
            FunctionList = functionList.DistinctBy(x => x.name).ToList();
            FunctionDic = FunctionList.ToDictionary(x => x.name, x => x, StringComparer.OrdinalIgnoreCase);
        }
    }

    internal class EucTemplateCacheInfo
    {
        public const string CACHE_KEY = nameof(EucTemplateCacheInfo);
        public const int CACHE_EXPIRE_MINIUTE = 60;
        public static readonly object LockObj = new();

        public readonly List<EucTemplateFileInfo> TemplateList;
        public readonly Dictionary<string, EucTemplateFileInfo> TemplateDic; //todo 使用区分

        public EucTemplateCacheInfo(IReadOnlyCollection<tm_eutemplatefileDto> dtl)
        {
            TemplateList = new List<EucTemplateFileInfo>(dtl.Count);
            TemplateDic = new Dictionary<string, EucTemplateFileInfo>(dtl.Count);
            foreach (var dto in dtl)
            {
                var info = new EucTemplateFileInfo(dto);
                TemplateList.Add(info);
                TemplateDic.TryAdd(dto.siyokbn, info);
            }
        }
    }

    internal class SpecialMasterCacheInfo
    {
        public const string CACHE_KEY = nameof(SpecialMasterCacheInfo);
        public const int CACHE_EXPIRE_MINIUTE = 10;
        public static readonly object LockObj = new();
        public static readonly HashSet<string> HAS_MAIN_CD_TABLES = new(StringComparer.OrdinalIgnoreCase) { tm_afmeisyoDto.TABLE_NAME, tm_afhanyoDto.TABLE_NAME, tm_aftikuDto.TABLE_NAME, tm_afctrlDto.TABLE_NAME };
        public static readonly HashSet<string> HAS_SUB_CD_TABLES = new(StringComparer.OrdinalIgnoreCase) { tm_afmeisyoDto.TABLE_NAME, tm_afhanyoDto.TABLE_NAME, tm_afctrlDto.TABLE_NAME };

        private readonly Dictionary<string, List<DaSelectorKeyModel>> MainCdSelectorListDict;
        private readonly Dictionary<string, List<DaSelectorKeyModel>> SubCdSelectorListDict;

        public SpecialMasterCacheInfo(DaDbContext db, List<tm_aftikuDto> tikuDtl)
        {
            var meisyomaincdList = DaNameService.GetSelectorList(db, EnumNmKbn.名称マスタメインコード, Enum名称区分.名称);
            var hanyomaincdList = DaNameService.GetSelectorList(db, EnumNmKbn.汎用マスタメインコード, Enum名称区分.名称);
            var ctrlmaincdList = DaNameService.GetSelectorList(db, EnumNmKbn.コントロールマスタメインコード, Enum名称区分.名称);

            var meisyoMainDtl = db.tm_afmeisyo_main.SELECT.SetSelectItems(nameof(tm_afmeisyo_mainDto.nmmaincd)
                                                                    , nameof(tm_afmeisyo_mainDto.nmsubcd)
                                                                    , nameof(tm_afmeisyo_mainDto.nmsubcdnm)).GetDtoList();
            var hanyoMainDtl = db.tm_afhanyo_main.SELECT.SetSelectItems(nameof(tm_afhanyo_mainDto.hanyomaincd)
                                                                    , nameof(tm_afhanyo_mainDto.hanyosubcd)
                                                                    , nameof(tm_afhanyo_mainDto.hanyosubcdnm)).GetDtoList();
            var ctrlMainDtl = db.tm_afctrl_main.SELECT.SetSelectItems(nameof(tm_afctrl_mainDto.ctrlmaincd)
                                                                    , nameof(tm_afctrl_mainDto.ctrlsubcd)
                                                                    , nameof(tm_afctrl_mainDto.ctrlsubcdnm)).GetDtoList();

            MainCdSelectorListDict = new Dictionary<string, List<DaSelectorKeyModel>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    tm_afmeisyoDto.TABLE_NAME,
                    meisyomaincdList.Select(x => new DaSelectorKeyModel(x.value, x.label, string.Empty)).ToList()
                },
                {
                    tm_afhanyoDto.TABLE_NAME,
                    hanyomaincdList.DistinctBy(x => x.value).Select(x => new DaSelectorKeyModel(x.value, x.label, string.Empty)).ToList()
                },
                {
                    tm_aftikuDto.TABLE_NAME,
                    tikuDtl.DistinctBy(x => x.tikukbn).Select(x => new DaSelectorKeyModel(DaConvertUtil.EnumToStr(x.tikukbn), x.tikukbn.ToString(), string.Empty)).ToList()
                },
                {
                    tm_afctrlDto.TABLE_NAME,
                    ctrlmaincdList.DistinctBy(x => x.value).Select(x => new DaSelectorKeyModel(x.value, x.label, string.Empty)).ToList()
                }
            };

            SubCdSelectorListDict = new Dictionary<string, List<DaSelectorKeyModel>>(StringComparer.OrdinalIgnoreCase)
            {
                {
                    tm_afmeisyoDto.TABLE_NAME,
                    meisyoMainDtl.Select(x => new DaSelectorKeyModel(x.nmsubcd.ToString(), x.nmsubcdnm, x.nmmaincd)).OrderBy(o =>DaConvertUtil.CInt(o.value)).ToList()
                },
                {
                    tm_afhanyoDto.TABLE_NAME,
                    hanyoMainDtl.Select(x => new DaSelectorKeyModel(x.hanyosubcd.ToString(), x.hanyosubcdnm, x.hanyomaincd)).OrderBy(o => DaConvertUtil.CInt(o.value)).ToList()
                },
                {
                    tm_afctrlDto.TABLE_NAME,
                    ctrlMainDtl.Select(x => new DaSelectorKeyModel(x.ctrlsubcd.ToString(), x.ctrlsubcdnm, x.ctrlmaincd)).OrderBy(o => DaConvertUtil.CInt(o.value)).ToList()
                }
            };
        }

        public List<DaSelectorKeyModel>? GetMainCdSelectorList(string? tableName)
        {
            return string.IsNullOrEmpty(tableName) ? null : MainCdSelectorListDict.GetValueOrDefault(tableName);
        }

        public List<DaSelectorKeyModel>? GetSubCdSelectorList(string? tableName)
        {
            return string.IsNullOrEmpty(tableName) ? null : SubCdSelectorListDict.GetValueOrDefault(tableName);
        }

        private static string GetMeisyoMainCdName(string nmmaincd)
        {
            return Enum.TryParse<EnumMainCd>(nmmaincd, out var m) ? m.ToString() : nmmaincd;
        }

        private static string GetHanyoMainCdName(string hanyomaincd)
        {
            return Enum.TryParse<EnumMainCd>(hanyomaincd, out var m) ? m.ToString() : hanyomaincd;
        }
    }

    public class tm_eutableDtoExt : tm_eutableDto
    {
        public List<tm_eutableitemDto> tableitems { get; set; } = new(); //テーブル項目

        public static tm_eutableDtoExt ToDtoExt(tm_eutableDto dto, List<tm_eutableitemDto> tableitems)
        {
            var ext = new tm_eutableDtoExt();
            ext.tablealias = dto.tablealias; //テーブル·別名
            ext.tablenm = dto.tablenm; //テーブル物理名
            ext.tablehyojinm = dto.tablehyojinm; //テーブル名称
            ext.tablekbn = dto.tablekbn; //テーブル区分
            ext.tableflg = dto.tableflg; //テーブルフラグ
            ext.orderseq = dto.orderseq; //並びシーケンス
            ext.tableitems = tableitems; //テーブル項目
            return ext;
        }
    }

    public class EucTemplateFileInfo
    {
        private const int MIN_ROW = 15;
        private const int MIN_COL = 1;
        private const int ROW_LIMIT = ushort.MaxValue;
        private const int COL_LIMIT = 1 << 14;

        public static readonly EucTemplateFileInfo EMPTY = new();

        public readonly string siyokbn; //todo 使用区分
        public readonly string filenm; //ファイル名
        public readonly EnumFileTypeKbn filetype; //ファイルタイプ
        public readonly byte[] filedata; //ファイルデータ
        public readonly int endrow; //最終行
        public readonly int endcol; //最終列

        public EucTemplateFileInfo(tm_eutemplatefileDto dto)
        {
            siyokbn = dto.siyokbn;
            filenm = dto.filenm;
            filetype = dto.filetype;
            filedata = dto.filedata;

            using var stream = new MemoryStream(dto.filedata);
            IWorkbook workbook = new XSSFWorkbook(stream);
            var sheet = workbook.GetSheetAt(0);
            endrow = Math.Min(Math.Max(MIN_ROW, sheet.LastRowNum + 1), ROW_LIMIT);

            var maxCol = MIN_COL;
            for (var rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                var row = sheet.GetRow(rowIndex);
                if (row == null) continue;
                maxCol = Math.Max(maxCol, row.LastCellNum);
                if (maxCol >= COL_LIMIT)
                {
                    break;
                }
            }

            endcol = Math.Min(maxCol, COL_LIMIT);
        }

        private EucTemplateFileInfo()
        {
            siyokbn = string.Empty;
            filenm = string.Empty;
            filetype = EnumFileTypeKbn.xlsx;
            filedata = Array.Empty<byte>();
            endrow = MIN_ROW;
            endcol = MIN_COL;
        }
    }

    public class FunctionVM
    {
        internal const string PROC_NAME = "sp_common_get_func_info";
        private int prorettype { get; } //関数の戻り値の型
        private List<int> proargtypes { get; } //関数の入力タイプ
        private List<int> proallargtypes { get; } //関数のすべてのパラメータ型
        private List<string> proargnames { get; } //関数の全パラメータの名前

        public string name { get; } //関数名
        public string src { get; } //関数のソース
        public List<Param> conditionparams { get; private set; } = new(); //条件パラメータ
        public List<Param> returnparams { get; private set; } = new(); //戻り値
        public string description { get; } //関数説明
        public string simpletemplate { get; private set; } //簡易SQLテンプレート
        public string sqltemplate { get; } //SQLテンプレート

        public FunctionVM(DataRow row)
        {
            name = row.Wrap(nameof(name));
            src = InitSrc(row.Wrap(nameof(src)));
            description = row.Wrap(nameof(description));

            prorettype = row.CInt(nameof(prorettype));
            proargtypes = ParseProargtypes(row.Wrap(nameof(proargtypes)));
            proallargtypes = ParseProallargtypes(row.Wrap(nameof(proallargtypes)));
            proargnames = ParseProargnames(row.Wrap(nameof(proargnames)));

            InitParams();

            simpletemplate = GetSimpleSqlTemplate();
            sqltemplate = GetSqlTemplate();
        }

        private void InitParams()
        {
            //all in-parameters
            conditionparams = proargtypes.Select((x, index) =>
            {
                var dbDataType = OidNpgsqlDbTypeConst.GetDbDataTypeByOid(x);
                if (dbDataType == null) throw new ArgumentException();
                var paraName = string.IsNullOrEmpty(proargnames[index]) ? $"{Param.AUTO_NAME_PREFIX}{index + 1}" : proargnames[index];
                return new Param(paraName, dbDataType.Value, false, index + 1);
            }).ToList();

            //out-parameters
            if (proallargtypes.Any())
            {
                var proreturnrgtypes = proallargtypes.Skip(proargtypes.Count).ToList();
                var proreturnargnames = proargnames.Skip(proargtypes.Count).ToList();
                returnparams = proreturnrgtypes.Select((x, index) => new Param(proreturnargnames[index], OidNpgsqlDbTypeConst.GetDbDataTypeByOid(x)!.Value, true, index + 1)).ToList();
            }
            else
            {
                if (prorettype != 2278)
                {
                    returnparams = new List<Param> { new($"{Param.AUTO_NAME_PREFIX}{1}", OidNpgsqlDbTypeConst.GetDbDataTypeByOid(prorettype)!.Value, true, 1) };
                }
            }
        }

        private static string InitSrc(string? src)
        {
            if (string.IsNullOrEmpty(src)) return string.Empty;
            var index = src.IndexOf(C_LEFT_BRACKET_HALF);
            return index <= 0 ? src : $"{src[..index].Replace("public.", string.Empty, StringComparison.OrdinalIgnoreCase)}{src[index..]}";
        }

        private static List<int> ParseProargtypes(string? proargtypesStr)
        {
            return string.IsNullOrEmpty(proargtypesStr) ? new List<int>() : proargtypesStr.Split(C_SPACE, StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
        }

        private static List<int> ParseProallargtypes(string? proallargtypesStr)
        {
            if (string.IsNullOrEmpty(proallargtypesStr)) return new List<int>();
            proallargtypesStr = proallargtypesStr.Trim(C_DELIM_START, C_DELIM_END);
            return string.IsNullOrEmpty(proallargtypesStr) ? new List<int>() : proallargtypesStr.Split(C_COMMA, StringSplitOptions.TrimEntries).Select(int.Parse).ToList();
        }

        private static List<string> ParseProargnames(string? proargnamesStr)
        {
            if (string.IsNullOrEmpty(proargnamesStr)) return new List<string>();
            proargnamesStr = proargnamesStr.Trim(C_DELIM_START, C_DELIM_END);
            return string.IsNullOrEmpty(proargnamesStr) ? new List<string>() : proargnamesStr.Split(C_COMMA, StringSplitOptions.TrimEntries).ToList();
        }

        private string GetSimpleSqlTemplate()
        {
            var conditionParamsStr = conditionparams.Any()
                ? $"{C_AT}{string.Join($"{C_COMMA}{C_SPACE}{C_AT}", conditionparams.Select(x => x.Name))}"
                : string.Empty;
            return $"{name}({conditionParamsStr})";
        }

        private string GetSqlTemplate()
        {
            simpletemplate = string.IsNullOrEmpty(simpletemplate) ? GetSimpleSqlTemplate() : simpletemplate;
            var returnParamsStr = $"{string.Join($"{C_COMMA}{C_SPACE}", returnparams.Select(x => x.Name))}";
            returnParamsStr = string.IsNullOrEmpty(returnParamsStr) ? ASTERISK : returnParamsStr;
            return $"(SELECT {returnParamsStr} FROM {simpletemplate})";
        }

        public class Param
        {
            internal const string AUTO_NAME_PREFIX = "param_";
            private const string AUTO_ITEM_ID_PREFIX = "FUNC_ITEM_";

            /// <summary>
            /// 項目ID
            /// </summary>
            public string Id { get; }
            /// <summary>
            /// 項目名
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// SQLカラム
            /// </summary>
            public string Sqlcolumn { get; set; }
            public NpgsqlDbType DbType { get; }
            public EnumDataType? DataType { get; }


            public Param(string name, (NpgsqlDbType DbType, EnumDataType? DataType) dbDataType, bool isReturnParam = false, int? id = null)
            {
                Name = name;
                Sqlcolumn = name;
                DbType = dbDataType.DbType;
                DataType = dbDataType.DataType;
                var sid = id == null ? "001" : id!.ToString()!.PadLeft(3, '0');
                Id = $"{sid}_{Sqlcolumn}";
            }

            //TODO
            private Dictionary<string, string> DICNAME_SUFFIX = new Dictionary<string, string>
                                    {
                                        { "nm", "（名称）" },
                                        { "kodo", "（ＣＤ）" },
                                        { "cdnm", "（ＣＤ：名称）" },
                                        { "cnt", "合計" },
                                        { "num", "数" },
                                        { "f", "開始" },
                                        { "t", "終了" }
                                    };
            private Dictionary<string, string> DICNAME = new Dictionary<string, string>
                                    {
                                        { "hokokusyo", "事業報告書" },
                                        { "bango", "番号" },
                                        { "follow", "フォロー" },
                                        { "kaijo", "会場" },
                                        //{ "tantosya", "担当者" },
                                        { "jusho", "住所" },
                                        //{ "kbn", "区分" },
                                        { "wareki", "（和暦）" },
                                        { "nengetsu", "年月" },
                                        { "staff", "従事者" },
                                        //{ "jyumin", "住民" },
                                        { "kekka", "結果" },
                                        { "yotei", "予定" },
                                        { "jigyou", "事業" },
                                        //{ "hoho", "方法" }
                                        { "gyoseiku", "行政区" }
                                    };

            /// <summary>
            /// 項目名称をセット
            /// </summary>
            public void SetName(Dictionary<string, string> dicDBName)
            {
                string newname = "";
                string[] variants = new string[]
                {
                    Name,
                    Name.Replace("_in", "")
                };

                newname = dicDBName.FirstOrDefault(kv => variants.Contains(kv.Key)).Value;

                if (!string.IsNullOrEmpty(newname))
                {
                    Name = newname;
                }
                else
                {
                    var mainname = Regex.Replace(Name, "[0-9]", "");
                    var strnum = Name.Replace(mainname, "");

                    mainname = mainname.EndsWith("_in") ? mainname.Replace("_in", "") : mainname;

                    if (dicDBName.ContainsKey(mainname))
                    {
                        newname = dicDBName[mainname];
                    }

                    if (string.IsNullOrEmpty(newname))
                    {
                        var names = mainname.Split('_');
                        var namelist = new List<string>();
                        foreach (var name in names)
                        {
                            namelist.Add(GetSubName(name, dicDBName));
                        }

                        newname = string.Join("", namelist.ToArray());
                    }

                    Name = $"{newname}{strnum}";
                }
            }

            private string GetSubName(string mainname, Dictionary<string, string> dicDBName)
            {
                var descname = GetDescName(mainname, dicDBName);

                if (!string.IsNullOrEmpty(descname))
                {
                    return descname;
                }

                var subname = DICNAME.Keys.FirstOrDefault(key => mainname.Contains(key));
                if (!string.IsNullOrEmpty(subname))
                {
                    var names = SplitString(mainname, subname);
                    var namelist = new List<string>();
                    foreach (var name in names)
                    {
                        descname = GetSubName(name, dicDBName);

                        namelist.Add(descname ?? name);
                    }

                    return string.Join("", namelist.ToArray());
                }
                else
                {
                    var suffix = DICNAME_SUFFIX.Keys.FirstOrDefault(key => mainname.EndsWith(key));
                    if (suffix != null)
                    {
                        var baseName = mainname.Substring(0, mainname.Length - suffix.Length);
                        descname = GetDescName(baseName, dicDBName) ?? baseName;
                        return $"{descname}{DICNAME_SUFFIX[suffix]}";
                    }
                }

                return mainname;
            }

            private string? GetDescName(string name, Dictionary<string, string> dicDBName)
            {
                if (DICNAME.ContainsKey(name))
                {
                    return DICNAME[name];
                }

                if (dicDBName.ContainsKey(name))
                {
                    return dicDBName[name];
                }

                return null;
            }

            static List<string> SplitString(string mainString, string subString)
            {
                List<string> resultList = new List<string>();

                // サブ文字列の位置を取得
                int index = mainString.IndexOf(subString);
                if (index != -1 && !string.IsNullOrEmpty(subString))
                {
                    // サブ文字列が見つかった場合、メインの文字列を3つの部分に分割し、リストに追加
                    // サブ文字列の前の部分
                    resultList.Add(mainString.Substring(0, index));
                    // サブ文字列
                    resultList.Add(subString);
                    // サブ文字列の後の部分
                    resultList.Add(mainString.Substring(index + subString.Length));
                    resultList.RemoveAll(string.IsNullOrEmpty);
                }
                else
                {
                    // サブ文字列が見つからない場合、メインの文字列をそのままリストに追加
                    resultList.Add(mainString);
                }

                return resultList;
            }

            public bool EqualsParam(object obj)
            {
                if (obj == null || obj.GetType() != GetType())
                    return false;

                Param other = (Param)obj;
                return Id == other.Id
                    && Name == other.Name
                    && Sqlcolumn == other.Sqlcolumn
                    && DbType == other.DbType
                    && DataType == other.DataType;
            }
        }
    }
    public static class OidNpgsqlDbTypeConst
    {
        #region Base

        private static readonly Dictionary<int, (NpgsqlDbType DbType, EnumDataType? DataType)> BaseOidDbDataTypeDic = new()
        {
            #region Numeric Types

            { 20, (NpgsqlDbType.Smallint, EnumDataType.整数) },
            { 701, (NpgsqlDbType.Double, EnumDataType.小数) },
            { 23, (NpgsqlDbType.Integer, EnumDataType.整数) },
            { 1700, (NpgsqlDbType.Numeric, EnumDataType.小数) },
            { 21, (NpgsqlDbType.Smallint, EnumDataType.整数) },

            #endregion

            #region Boolean Type

            { 16, (NpgsqlDbType.Boolean, EnumDataType.フラグ) },

            #endregion

            #region Character Types

            { 1042, (NpgsqlDbType.Char, EnumDataType.文字列) },
            { 25, (NpgsqlDbType.Text, EnumDataType.文字列) },
            { 1043, (NpgsqlDbType.Varchar, EnumDataType.文字列) },

            #endregion

            #region Date/Time Types

            { 1082, (NpgsqlDbType.Date, EnumDataType.日付) },
            { 1083, (NpgsqlDbType.Time, EnumDataType.文字列) },
            { 1114, (NpgsqlDbType.Date, EnumDataType.日付) },

            #endregion
        };

        #endregion

        #region Array

        private static readonly Dictionary<int, (NpgsqlDbType DbType, EnumDataType? DataType)> ArrayOidDbTypeDic = new()
        {
            #region Numeric Types

            { 1016, (NpgsqlDbType.Smallint, EnumDataType.整数) },
            { 1022, (NpgsqlDbType.Double, EnumDataType.小数) },
            { 1007, (NpgsqlDbType.Integer, EnumDataType.整数) },
            { 1231, (NpgsqlDbType.Numeric, EnumDataType.小数) },
            { 1005, (NpgsqlDbType.Smallint, EnumDataType.整数) },

            #endregion

            #region Boolean Type

            { 1000, (NpgsqlDbType.Boolean, EnumDataType.フラグ) },

            #endregion

            #region Character Types

            { 1014, (NpgsqlDbType.Char, EnumDataType.文字列) },
            { 1009, (NpgsqlDbType.Text, EnumDataType.文字列) },
            { 1015, (NpgsqlDbType.Varchar, EnumDataType.文字列) },

            #endregion

            #region Date/Time Types

            { 1182, (NpgsqlDbType.Date, EnumDataType.日付) },
            { 1183, (NpgsqlDbType.Time, EnumDataType.文字列) },
            { 1114, (NpgsqlDbType.Date, EnumDataType.日付) },

            #endregion
        };

        #endregion

        public static (NpgsqlDbType, EnumDataType?)? GetDbDataTypeByOid(int oid)
        {
            return GetBaseDbDataTypeByOid(oid) ?? GetArrayDbDataTypeByOid(oid);
        }

        public static (NpgsqlDbType, EnumDataType?)? GetBaseDbDataTypeByOid(int oid)
        {
            return BaseOidDbDataTypeDic.TryGetValue(oid, out var dbType) ? dbType : null;
        }

        public static (NpgsqlDbType, EnumDataType?)? GetArrayDbDataTypeByOid(int oid)
        {
            return ArrayOidDbTypeDic.TryGetValue(oid, out var dbType) ? dbType : null;
        }
    }
}