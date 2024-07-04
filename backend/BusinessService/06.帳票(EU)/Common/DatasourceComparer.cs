namespace BCC.Affect.Service.Common;

/// <summary>
/// データソーテーブル別名比較器
/// </summary>
public class DatasourceTableAliasComparer : IComparer<string>
{
    private readonly DaDbContext db;

    private DatasourceTableAliasComparer(DaDbContext? db = null)
    {
        this.db = db ?? new DaDbContext();
    }

    public static DatasourceTableAliasComparer CreareIntance(DaDbContext? db = null)
    {
        return new DatasourceTableAliasComparer(db);
    }

    public int Compare(string? x, string? y)
    {
        if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y)) return 0;
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y)) return string.IsNullOrEmpty(x) ? 1 : -1;
        if (x.Equals(y, StringComparison.OrdinalIgnoreCase)) return 0;

        var tableX = DaEucBasicService.GetTable(db, x);
        var tableY = DaEucBasicService.GetTable(db, y);

        if (tableX == null && tableY == null) return 0;
        if (tableX == null || tableY == null) return tableX == null ? 1 : -1;

        var tableKbnCompare = tableX.tablekbn.CompareTo(tableY.tablekbn);
        return tableKbnCompare != 0 ? tableKbnCompare : tableX.orderseq.CompareTo(tableY.orderseq);
    }
}

/// <summary>
/// SQLカラム比較器
/// </summary>
public class DatasourceSqlColumnComparer : IComparer<string>
{
    private readonly DaDbContext db;

    private DatasourceSqlColumnComparer(DaDbContext? db = null)
    {
        this.db = db ?? new DaDbContext();
    }

    public static DatasourceSqlColumnComparer CreareIntance(DaDbContext? db = null)
    {
        return new DatasourceSqlColumnComparer(db);
    }

    public int Compare(string? x, string? y)
    {
        if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y)) return 0;
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y)) return string.IsNullOrEmpty(x) ? 1 : -1;
        if (x.Equals(y, StringComparison.OrdinalIgnoreCase)) return 0;

        var itemX = DaEucBasicService.GetTableItemDtoBySqlColumn(db, x);
        var itemY = DaEucBasicService.GetTableItemDtoBySqlColumn(db, y);

        if (itemX == null && itemY == null) return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        if (itemX == null || itemY == null) return itemX == null ? 1 : -1;

        var tableAliasCompare = DatasourceTableAliasComparer.CreareIntance(db).Compare(itemX.tablealias, itemY.tablealias);
        return tableAliasCompare != 0 ? tableAliasCompare : itemX.orderseq.CompareTo(itemY.orderseq);
    }
}

/// <summary>
/// タソース項目ID比較器
/// </summary>
public class DatasourceItemIdComparer : IComparer<string>
{
    private readonly DaDbContext db;

    private DatasourceItemIdComparer(DaDbContext? db = null)
    {
        this.db = db ?? new DaDbContext();
    }

    public static DatasourceItemIdComparer CreareIntance(DaDbContext? db = null)
    {
        return new DatasourceItemIdComparer(db);
    }

    public int Compare(string? x, string? y)
    {
        if (string.IsNullOrEmpty(x) && string.IsNullOrEmpty(y)) return 0;
        if (string.IsNullOrEmpty(x) || string.IsNullOrEmpty(y)) return string.IsNullOrEmpty(x) ? 1 : -1;
        if (x.Equals(y, StringComparison.OrdinalIgnoreCase)) return 0;

        var itemX = DaEucBasicService.GetTableItemDtoByItemCd(db, x);
        var itemY = DaEucBasicService.GetTableItemDtoByItemCd(db, y);

        if (itemX == null && itemY == null) return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        if (itemX == null || itemY == null) return itemX == null ? 1 : -1;

        var tableAliasCompare = DatasourceTableAliasComparer.CreareIntance(db).Compare(itemX.tablealias, itemY.tablealias);
        return tableAliasCompare != 0 ? tableAliasCompare : itemX.orderseq.CompareTo(itemY.orderseq);
    }
}