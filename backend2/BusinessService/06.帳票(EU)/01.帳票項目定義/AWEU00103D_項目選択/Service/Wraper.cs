// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 項目選択
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00103D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 大分類一覧
        /// </summary>
        public static List<TableVM> GetTableList(HashSet<string> list)
        {
            var list2 = list.ToList().OrderBy(x => x).ToList();
            var list3 = new List<TableVM>();
            var fmt = (list2.Count > 9) ? "00" : "0";
            for (int i = 0; i < list2.Count; i++)
            {
                list3.Add(new TableVM() { tablealias = (i + 1).ToString(fmt), tablenm = list2[i] });
            }
            return list3;
        }

        /// <summary>
        /// 項目一覧
        /// </summary>
        public static TableItemVM GetTableItemVM(tm_eutableitemDto dto)
        {
            var vm = new TableItemVM();
            vm.itemid = dto.itemid;                       //項目ID
            vm.itemhyojinm = dto.itemhyojinm;             //表示名称
            vm.sqlcolumn = dto.sqlcolumn;                 //SQLカラム
            vm.daibunrui = dto.daibunrui;                 //大分類
            vm.tyubunrui = dto.tyubunrui ?? string.Empty; //中分類
            vm.syobunrui = dto.syobunrui ?? string.Empty; //小分類
            return vm;
        }

        public static (List<TableVM>, List<TableItemVM>) GetTableItemVMListAndNextBunruiList(List<tm_eutableitemDto> tableitemDtl, SearchRequest req)
        {
            List<TableVM> nextBunruiList;
            if (string.IsNullOrEmpty(req.daibunrui))
            {
                nextBunruiList = tableitemDtl.Where(x => !string.IsNullOrEmpty(x.daibunrui)).GroupBy(x => x.daibunrui)
               .Select(group => group.First()).Select(x => new TableVM
               {
                   tablealias = x.tablealias,
                   tablenm = x.daibunrui
               }).ToList();
            }
            else if (!string.IsNullOrEmpty(req.daibunrui) && !string.IsNullOrEmpty(req.tyubunrui))
            {
                nextBunruiList = tableitemDtl.Where(x => x.daibunrui == req.daibunrui && x.tyubunrui == req.tyubunrui).GroupBy(x => x.syobunrui)
               .Select(group => group.First()).Select(x => new TableVM
               {
                   tablealias = x.tablealias,
                   tablenm = x.syobunrui!
               }).ToList();
            }
            else if (!string.IsNullOrEmpty(req.daibunrui))
            {
                nextBunruiList = tableitemDtl.Where(x => x.daibunrui == req.daibunrui).GroupBy(x => x.tyubunrui)
               .Select(group => group.First()).Select(x => new TableVM
               {
                   tablealias = x.tablealias,
                   tablenm = x.tyubunrui!
               }).ToList();
            }
            else
            {
                nextBunruiList = new List<TableVM>();
            }

            return (nextBunruiList, tableitemDtl.Select(GetTableItemVM).OrderBy(e => e.itemid).ToList());
        }

    }
}