// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 医療機関保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.6
// 作成者　　: CNC加恒
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00201G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 医療機関保守情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        ///実施事業情報
        /// </summary>
        public static List<JissijigyoModel> GetSubVM(DaDbContext db, DataRowCollection rows)
        {
            var jissijigyoSelectorList = new List<JissijigyoModel>();

            foreach (DataRow row in rows)
            {
                var model = new JissijigyoModel();

                model.jissijigyo = row.Wrap(nameof(tm_afhanyoDto.hanyocd));
                model.jissijigyonm = row.Wrap(nameof(tm_afhanyoDto.nm));
                model.checkflg = row.CBool("checkflg");
                model.hanyokbn1 = row.Wrap(nameof(tm_afhanyoDto.hanyokbn1));

                jissijigyoSelectorList.Add(model);
            }

            return jissijigyoSelectorList;
        }

        /////// <summary>
        /////// 医療機関保守情報(詳細画面)
        /////// </summary>
        public static MainInfoVM GetVM(tm_afkikanDto dto)
        {
            var vm = new MainInfoVM();
            vm.kikancd = dto.kikancd;                                   //医療機関コード
            vm.hokenkikancd = dto.hokenkikancd;                         //保険医療機関コード
            vm.kikannm = dto.kikannm;                                   //医療機関名
            vm.kanakikannm = CStr(dto.kanakikannm);                     //医療機関名(カナ)
            vm.stopflg = dto.stopflg;                                   //利用停止
            vm.adrs = dto.adrs;                                         //住所
            vm.katagaki = CStr(dto.katagaki);                           //方書
            vm.tel = CStr(dto.tel);                                     //電話番号
            vm.yubin = dto.yubin;                                       //郵便番号
            vm.fax = CStr(dto.fax);                                     //FAX番号
            vm.syozokuisikai = CStr(dto.syozokuisikai);                 //所属医師会

            return vm;
        }

        /////// <summary>
        /////// 医療機関保守情報(一覧)
        /////// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();

            vm.kikancd = row.Wrap(nameof(vm.kikancd));                                      //医療機関コード
            vm.hokenkikancd = row.Wrap(nameof(vm.hokenkikancd));                            //保険医療機関コード
            vm.kikannm = row.Wrap(nameof(vm.kikannm));                                      //医療機関名
            vm.kanakikannm = row.Wrap(nameof(vm.kanakikannm));                              //医療機関名(カナ)
            vm.tel = row.Wrap(nameof(vm.tel));                                              //電話番号
            vm.yubin = row.Wrap(nameof(vm.yubin));                                          //郵便番号
            vm.adrs = row.Wrap(nameof(vm.adrs));                                            //住所
            var stopflg = BoolToStr(row.CBool(nameof(RowVM.stopflg)));
            vm.stopflg = DaNameService.GetName(db, EnumNmKbn.停止フラグ, stopflg);          //利用状態

            return vm;
        }
    }
}
