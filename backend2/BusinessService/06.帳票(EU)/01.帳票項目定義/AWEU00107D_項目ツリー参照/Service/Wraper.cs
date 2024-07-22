// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目ツリー参照
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00107D
{
    public class Wraper : CmWraperBase
    {
        public delegate ItemTreeNode<T> LeafTreeNodeDelegate<T>(tm_eutableitemDto dto, Enum集計区分? crosskbn = null) where T : SimpleItemVM;

        public delegate ItemTreeNode<T> NotLeafTreeNodeDelegate<T>(string burui, List<ItemTreeNode<T>> children) where T : SimpleItemVM;

        /// <summary>
        /// 一覧項目ツリー
        /// </summary>
        public static List<ItemTreeNode<SimpleItemVM>> GetSimpleNormalItemTree(IEnumerable<tm_eutableitemDto> dtl)
        {
            return GetNormalItemTree(dtl, GetLeafTreeNode, GetNotLeafTreeNode);
        }

        /// <summary>
        /// 集計項目ツリー
        /// </summary>
        public static List<ItemTreeNode<SimpleItemVM>> GetSimpleStatisticsItemTree(IEnumerable<tm_eutableitemDto> dtl)
        {
            return GetStatisticsItemTree(dtl, GetLeafTreeNode, GetNotLeafTreeNode);
        }

        /// <summary>
        /// スケーラブル一覧項目ツリー
        /// </summary>
        public static List<ItemTreeNode<T>> GetNormalItemTree<T>(IEnumerable<tm_eutableitemDto> dtl, LeafTreeNodeDelegate<T> leafTreeNodeFunc, NotLeafTreeNodeDelegate<T> notLeafTreeNodeFunc)
            where T : SimpleItemVM
        {
            
            var itemTreeVms = new List<ItemTreeNode<T>>();
            var buruiDic = new Dictionary<BuruiKey, List<ItemTreeNode<T>>>();

            dtl = dtl.Where(x => x.usekbn is Enum使用区分.一覧項目 or Enum使用区分.併用).ToList();
            foreach (var dto in dtl)
            {
                if (string.IsNullOrEmpty(dto.daibunrui))
                {
                    itemTreeVms.Add(leafTreeNodeFunc(dto));
                }
                else
                {
                    if (string.IsNullOrEmpty(dto.tyubunrui))
                    {
                        var burui1Key = new BuruiKey(dto.daibunrui, null, null);
                        if (buruiDic.TryGetValue(burui1Key, out var value))
                        {
                            value.Add(leafTreeNodeFunc(dto));
                        }
                        else
                        {
                            var burui1List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                            buruiDic.Add(burui1Key, burui1List);
                            itemTreeVms.Add(notLeafTreeNodeFunc(dto.daibunrui, burui1List));
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dto.syobunrui))
                        {
                            var burui2Key = new BuruiKey(dto.daibunrui, dto.tyubunrui, null);
                            if (buruiDic.TryGetValue(burui2Key, out var value))
                            {
                                value.Add(leafTreeNodeFunc(dto));
                            }
                            else
                            {
                                var burui1Key = new BuruiKey(dto.daibunrui, null, null);
                                if (buruiDic.TryGetValue(burui1Key, out var value1))
                                {
                                    var burui2List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                                    value1.Add(notLeafTreeNodeFunc(dto.tyubunrui, burui2List));
                                    buruiDic.Add(burui2Key, burui2List);
                                }
                                else
                                {
                                    var burui2List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                                    var burui1List = new List<ItemTreeNode<T>> { notLeafTreeNodeFunc(dto.tyubunrui, burui2List) };
                                    buruiDic.Add(burui1Key, burui1List);
                                    buruiDic.Add(burui2Key, burui2List);
                                    itemTreeVms.Add(notLeafTreeNodeFunc(dto.daibunrui, burui1List));
                                }
                            }
                        }
                        else
                        {
                            var burui3Key = new BuruiKey(dto.daibunrui, dto.tyubunrui, dto.syobunrui);
                            if (buruiDic.TryGetValue(burui3Key, out var value3))
                            {
                                value3.Add(leafTreeNodeFunc(dto));
                            }
                            else
                            {
                                var burui2Key = new BuruiKey(dto.daibunrui, dto.tyubunrui, null);
                                if (buruiDic.TryGetValue(burui2Key, out var value2))
                                {
                                    var burui3List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                                    value2.Add(notLeafTreeNodeFunc(dto.syobunrui, burui3List));
                                    buruiDic.Add(burui3Key, burui3List);
                                }
                                else
                                {
                                    var burui1Key = new BuruiKey(dto.daibunrui, null, null);
                                    if (buruiDic.TryGetValue(burui1Key, out var value1))
                                    {
                                        var burui3List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                                        var burui2List = new List<ItemTreeNode<T>> { notLeafTreeNodeFunc(dto.syobunrui, burui3List) };
                                        value1.Add(notLeafTreeNodeFunc(dto.tyubunrui, burui2List));
                                        buruiDic.Add(burui2Key, burui2List);
                                        buruiDic.Add(burui3Key, burui3List);
                                    }
                                    else
                                    {
                                        var burui3List = new List<ItemTreeNode<T>> { leafTreeNodeFunc(dto) };
                                        var burui2List = new List<ItemTreeNode<T>> { notLeafTreeNodeFunc(dto.syobunrui, burui3List) };
                                        var burui1List = new List<ItemTreeNode<T>> { notLeafTreeNodeFunc(dto.tyubunrui, burui2List) };
                                        buruiDic.Add(burui1Key, burui1List);
                                        buruiDic.Add(burui2Key, burui2List);
                                        buruiDic.Add(burui3Key, burui3List);
                                        itemTreeVms.Add(notLeafTreeNodeFunc(dto.daibunrui, burui1List));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return itemTreeVms;
        }

        /// <summary>
        /// スケーラブル集計項目ツリー
        /// </summary>
        public static List<ItemTreeNode<T>> GetStatisticsItemTree<T>(IEnumerable<tm_eutableitemDto> dtl, LeafTreeNodeDelegate<T> leafTreeNodeFunc, NotLeafTreeNodeDelegate<T> notLeafTreeNodeFunc)
            where T : SimpleItemVM
        {
            dtl = dtl.Where(x => x.usekbn is Enum使用区分.集計項目 or Enum使用区分.併用).ToList();

            var groupByDtl = dtl.Where(x => Enum.TryParse<Enum集計項目区分>(x.syukeikbn, out var kbn) && kbn is Enum集計項目区分.GroupBy).ToList();
            var statisticsDtl = dtl.Where(x => Enum.TryParse<Enum集計項目区分>(x.syukeikbn, out var kbn) && kbn is Enum集計項目区分.Count or Enum集計項目区分.Sum).ToList();
            var statisticsNodes = statisticsDtl.Select(x => leafTreeNodeFunc(x)).ToList();

            var itemTreeNodes = new List<ItemTreeNode<T>>(2);
            if (groupByDtl.Any())
            {
                itemTreeNodes.Add(notLeafTreeNodeFunc("項目集計", groupByDtl.Select(x => leafTreeNodeFunc(x)).ToList()));
            }

            if (statisticsNodes.Any())
            {
                itemTreeNodes.Add(notLeafTreeNodeFunc("集計項目", statisticsNodes));
            }

            return itemTreeNodes;
        }


        /// <summary>
        /// リーフノードの取得
        /// </summary>
        private static ItemTreeNode<SimpleItemVM> GetLeafTreeNode(tm_eutableitemDto dto, Enum集計区分? crosskbn = null)
        {
            return new ItemTreeNode<SimpleItemVM>(GetSimpleLeafItemVM(dto));
        }

        /// <summary>
        /// 非リーフノードの取得
        /// </summary>
        private static ItemTreeNode<SimpleItemVM> GetNotLeafTreeNode(string burui, List<ItemTreeNode<SimpleItemVM>> children)
        {
            return new ItemTreeNode<SimpleItemVM>(GetSimpleNotLeafItemVM(burui), children);
        }

        /// <summary>
        /// リーフ項目の取得
        /// </summary>
        private static SimpleItemVM GetSimpleLeafItemVM(tm_eutableitemDto dto)
        {
            return new SimpleItemVM(dto.sqlcolumn, dto.itemid, dto.itemhyojinm, true);
        }

        /// <summary>
        /// 非リーフ項目の取得
        /// </summary>
        private static SimpleItemVM GetSimpleNotLeafItemVM(string burui)
        {
            return new SimpleItemVM(string.Empty, string.Empty, burui, false);
        }
    }
}