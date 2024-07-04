// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目ツリー参照
//             ビューモデル定義
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00107D
{
    /// <summary>
    /// ツリーノード
    /// </summary>
    public class ItemTreeNode<T> where T : SimpleItemVM
    {
        private static readonly List<ItemTreeNode<T>> EMPTY_CHILDREN = new();
        public T value { get; }                                                    //ツリーノード
        public List<ItemTreeNode<T>> children { get; }                             //次のレベル

        public ItemTreeNode(T value, List<ItemTreeNode<T>>? children = null)
        {
            this.value = value;
            this.children = children ?? EMPTY_CHILDREN;
        }
    }

    /// <summary>
    /// 簡単項目
    /// </summary>
    public class SimpleItemVM
    {
        public string sqlcolumn { get; }                         //SQLカラム
        public string itemid { get; }                            //項目ID
        public string itemhyojinm { get; }                       //表示名称
        public bool isleaf { get; }                              //リーフノードフラグ

        public SimpleItemVM(string sqlcolumn, string itemid, string itemhyojinm, bool isleaf)
        {
            this.sqlcolumn = sqlcolumn;
            this.itemid = itemid;
            this.itemhyojinm = itemhyojinm;
            this.isleaf = isleaf;
        }
    }

    /// <summary>
    /// 分類キー
    /// </summary>
    internal class BuruiKey
    {
        private readonly string daibunrui;                       //大分類
        private readonly string tyubunrui;                       //中分類
        private readonly string syobunrui;                       //小分類

        public BuruiKey(string? daibunrui, string? tyubunrui, string? syobunrui)
        {
            this.daibunrui = string.IsNullOrEmpty(daibunrui) ? string.Empty : daibunrui;
            this.tyubunrui = string.IsNullOrEmpty(tyubunrui) ? string.Empty : tyubunrui;
            this.syobunrui = string.IsNullOrEmpty(syobunrui) ? string.Empty : syobunrui;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 31 + daibunrui.GetHashCode();
                hash = hash * 31 + tyubunrui.GetHashCode();
                hash = hash * 31 + syobunrui.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            var other = (BuruiKey)obj;
            return daibunrui == other.daibunrui && tyubunrui == other.tyubunrui && syobunrui == other.syobunrui;
        }
    }
}