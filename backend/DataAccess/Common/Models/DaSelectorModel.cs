// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ドロップダウンリスト
//
// 作成日　　: 2023.03.14
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.DataAccess
{
    public class DaSelectorModel
    {
        public string value { get; set; }   //コード
        public string label { get; set; }   //名称

        /// <summary>
        /// Cacheに使用
        /// </summary>
        public DaSelectorModel() { }

        public DaSelectorModel(string? value, string? label)
        {
            this.value = value ?? string.Empty;
            this.label = label ?? string.Empty;
        }

        public override string ToString()
        {
            return $"{value}{DaConst.SELECTOR_DELIMITER}{label}";
        }
    }
    public class DaSelectorKeyModel : DaSelectorModel
    {
        public string key { get; set; }   //キー項目(連動フィルター用)
        public DaSelectorKeyModel(string? value, string? label, string? key) : base(value, label)
        {
            this.key = key ?? string.Empty;
        }
    }

    public class DaSelectorDisabledModel : DaSelectorModel
    {
        public bool disabled { get; set; }   //無効属性
        public DaSelectorDisabledModel(string? value, string? label, bool? disabled = false) : base(value, label)
        {
            this.disabled = CBool(disabled);
        }
    }

    public class DaSelectorTreeModel<T> : DaSelectorModel where T : DaSelectorModel
    {
        public List<T> children { get; set; } //サブレベルオプション

        public DaSelectorTreeModel(string? value, string? label, IEnumerable<T>? children = null) : base(value, label)
        {
            this.children = children?.ToList() ?? new List<T>();
        }
    }
}