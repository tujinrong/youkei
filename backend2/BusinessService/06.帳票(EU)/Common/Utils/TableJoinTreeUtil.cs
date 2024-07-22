// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: テーブル・ジョイン・ツリー ツール
//             共通ツール
// 作成日　　: 2023.10.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.Common;

public static class TableJoinTreeUtil
{
    public static TableTree CreateTableJoinTree(string mainTableAlias, IEnumerable<tm_eudatasourcejoinDto> datasourceJoinDtl)
    {
        var root = new TableNode(mainTableAlias, string.Empty);
        var nodesDict = new Dictionary<string, TableNode>(StringComparer.OrdinalIgnoreCase) { { mainTableAlias, root } };
        var pendingJoins = datasourceJoinDtl.ToList();
        bool nodesAdded;
        do
        {
            nodesAdded = false;
            var remainingJoins = new List<tm_eudatasourcejoinDto>();
            foreach (var join in pendingJoins)
            {
                if (nodesDict.TryGetValue(join.kanrentablealias, out var parentNode))
                {
                    if (!nodesDict.TryGetValue(join.tablealias, out var childNode))
                    {
                        childNode = new TableNode(join.tablealias, join.kanrentablealias);
                        nodesDict[join.tablealias] = childNode;
                    }

                    parentNode.AddChild(childNode);
                    nodesAdded = true;
                }
                else
                {
                    remainingJoins.Add(join);
                }
            }

            pendingJoins = remainingJoins;
        } while (nodesAdded && pendingJoins.Any());

        return new TableTree(root);
    }

    public static List<tm_eutableDtoJoin> GetCanJoinTableDtl(DaDbContext db, string mainTableAlias)
    {
        var tableJoinDict = DaEucBasicService.GetAllTableJoinDtl(db)
            .Where(x => !mainTableAlias.Equals(x.tablealias, StringComparison.OrdinalIgnoreCase))
            .GroupBy(x => x.kanrentablealias)
            .ToDictionary(g => g.Key, g => g.ToList(), StringComparer.OrdinalIgnoreCase);

        var connectedTableDict = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        //BFS
        var queue = new Queue<string>();
        queue.Enqueue(mainTableAlias);
        while (queue.Any())
        {
            var currentTableAlias = queue.Dequeue();
            if (!tableJoinDict.TryGetValue(currentTableAlias, out var connected)) continue;
            foreach (var joinDto in connected.Where(x => connectedTableDict.TryAdd(x.tablealias, currentTableAlias)))
            {
                queue.Enqueue(joinDto.tablealias);
            }
        }

        return DaEucBasicService.GetTableDtl(db, connectedTableDict.Keys)
            .Select(x => new tm_eutableDtoJoin(x, connectedTableDict.GetValueOrDefault(x.tablealias, string.Empty)))
            .ToList();
    }
}

public class TableTree
{
    public readonly TableNode Root;

    public TableTree(TableNode root)
    {
        Root = root;
    }

    public HashSet<string> GetRemovedTableAliases(IEnumerable<string> removeTableAliases)
    {
        var toRemove = removeTableAliases.ToHashSet(StringComparer.OrdinalIgnoreCase);
        var removedTableNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        bool removed;
        do
        {
            removed = false;
            //BFS
            var queue = new Queue<TableNode>();
            if (Root != null)
            {
                queue.Enqueue(Root);
            }

            while (queue.Any())
            {
                var current = queue.Dequeue();
                for (var i = current.Children.Count - 1; i >= 0; i--)
                {
                    var child = current.Children[i];
                    if (child.IsLeaf() && toRemove.Contains(child.TableAlias))
                    {
                        current.Children.RemoveAt(i);
                        removed = true;
                        toRemove.Remove(child.TableAlias);
                        removedTableNames.Add(child.TableAlias);
                    }
                    else if (!child.IsLeaf())
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        } while (removed && toRemove.Any());

        return removedTableNames;
    }
}

public class TableNode
{
    public readonly string TableAlias;
    public readonly string JoinTableAlias;
    public readonly List<TableNode> Children;

    public bool IsLeaf() => !Children.Any();

    public TableNode(string tableAlias, string joinTableAlias)
    {
        TableAlias = tableAlias;
        JoinTableAlias = joinTableAlias;
        Children = new List<TableNode>();
    }

    public void AddChild(TableNode child)
    {
        Children.Add(child);
    }
}

public class tm_eutableDtoJoin : tm_eutableDto
{
    public string kanrentablealias { get; set; }

    public tm_eutableDtoJoin(tm_eutableDto tableDto, string kanrentablealias)
    {
        tablealias = tableDto.tablealias; //テーブル·別名
        tablenm = tableDto.tablenm; //テーブル物理名
        tablehyojinm = tableDto.tablehyojinm; //テーブル名称
        tablekbn = tableDto.tablekbn; //テーブル区分
        tableflg = tableDto.tableflg; //テーブルフラグ
        orderseq = tableDto.orderseq; //並びシーケンス
        this.kanrentablealias = kanrentablealias;
    }
}