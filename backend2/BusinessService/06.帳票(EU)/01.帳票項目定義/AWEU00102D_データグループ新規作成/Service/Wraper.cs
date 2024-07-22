// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: データグループ新規作成
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00102D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 初期化処理
        /// </summary>
        public static List<TableVM> GetTableVMList(IEnumerable<tm_eutableDto> tableDtl)
        {
            return tableDtl.Where(x => x.tableflg && (x.tablekbn == EnumTableKbn.トランザクション || x.tablekbn == EnumTableKbn.マスタ
            || x.tablekbn == EnumTableKbn.VIEW)).Select(GetTableVM).OrderBy(x => x.orderseq).ThenBy(x => x.tablenm).ToList();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        public static List<TableItemVM> GetTableItemVMList(IEnumerable<tm_eutableitemDto> tableitemDtl)
        {
            return tableitemDtl.Select(GetTableItemVM).ToList();
        }

        /// <summary>
        /// 初期化処理
        /// </summary>
        private static TableVM GetTableVM(tm_eutableDto dto)
        {
            var vm = new TableVM();
            vm.tablealias = dto.tablealias; 　　　//テーブル·別名
            vm.tablenm = dto.tablenm; 　　　　　　//テーブル物理名
            vm.tablehyojinm = dto.tablehyojinm; 　//テーブル名称
            vm.orderseq = dto.orderseq; 　        //並びシーケンス
            return vm;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        private static TableItemVM GetTableItemVM(tm_eutableitemDto dto)
        {
            var vm = new TableItemVM();
            vm.sqlcolumn = dto.sqlcolumn; 　　　　　　　　　//SQLカラム
            vm.itemid = dto.itemid; 　　　　　　　　　　　　//項目ID
            vm.itemhyojinm = dto.itemhyojinm; 　　　　　　　//表示名称
            vm.daibunrui = dto.daibunrui; 　　　　　　　　　//大分類
            vm.tyubunrui = dto.tyubunrui ?? string.Empty; 　//中分類
            vm.syobunrui = dto.syobunrui ?? string.Empty; 　//小分類
            vm.tablealias = dto.tablealias; 　　　　　　　　//テーブル·別名
            return vm;
        }
    }
}