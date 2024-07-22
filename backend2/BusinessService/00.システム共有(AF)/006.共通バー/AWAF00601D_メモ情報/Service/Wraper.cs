// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.07.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00601D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// メモ情報(明細部)
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows, List<string> sisyoList, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            return rows.Cast<DataRow>().Select(row => GetVM(db, row, sisyoList, dtl1, dtl2)).ToList();
        }

        /// <summary>
        /// メモ情報(1件)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row, List<string> sisyoList, List<tm_afhanyoDto> dtl1, List<tm_afhanyoDto> dtl2)
        {
            var vm = new SearchVM();

            vm.memoseq = row.CInt(nameof(SearchVM.memoseq));        //メモシーケンス
            vm.title = row.Wrap(nameof(SearchVM.title));            //件名（タイトル）
            //重要度
            var juyodo = row.Wrap(nameof(SearchVM.juyodo));
            vm.juyodo = DaSelectorService.GetCdNm(db, juyodo, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.重要度));
            vm.kigenymd = row.Wrap(nameof(SearchVM.kigenymd));      //期限日
            //登録事業（共通・各事業）
            var jigyokbn = row.Wrap(nameof(SearchVM.jigyokbn));
            vm.jigyokbn = DaHanyoService.GetCdNm(dtl1, Enum名称区分.名称, jigyokbn);
            //登録支所
            var regsisyo = row.Wrap(nameof(SearchVM.regsisyo));
            if (!string.IsNullOrEmpty(regsisyo))
            {
                vm.regsisyo = DaHanyoService.GetCdNm(dtl2, Enum名称区分.名称, regsisyo);
            }
            vm.memo = row.Wrap(nameof(SearchVM.memo));              //メモ（フリーテキスト）

            vm.regusernm = row.Wrap(nameof(SearchVM.regusernm));    //登録者
            vm.regdttm = row.CDate(nameof(SearchVM.regdttm));       //登録日時
            vm.updusernm = row.Wrap(nameof(SearchVM.updusernm));    //更新者
            vm.upddttm = row.CDate(nameof(SearchVM.upddttm));       //更新日時

            //更新権限フラグ
            vm.updflg = string.IsNullOrEmpty(regsisyo) || sisyoList.Contains(regsisyo);

            return vm;
        }
    }
}