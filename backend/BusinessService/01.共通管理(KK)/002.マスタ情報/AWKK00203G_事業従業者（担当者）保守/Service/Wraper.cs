// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業従事者（担当者）保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.4
// 作成者　　: 劉誠
// 変更履歴　:
// *******************************************************************


namespace BCC.Affect.Service.AWKK00203G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 事業従事者（担当者）情報(一覧画面)
        /// </summary>
        public static List<StaffRowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<StaffRowVM>();
            foreach (DataRow row in rows)
            {
                var vm = new StaffRowVM();
                var syokusyu = row.Wrap(nameof(tm_afstaffDto.syokusyu));                        //職種
                vm.syokusyunm = DaNameService.GetName(db, EnumNmKbn.職種, syokusyu);

                var katudokbn = row.Wrap(nameof(tm_afstaffDto.katudokbn));                      //活動区分
                vm.katudokbnnm = DaNameService.GetName(db, EnumNmKbn.活動区分, katudokbn);

                vm.staffid = row.Wrap(nameof(StaffRowVM.staffid));                              //事業従業者ID
                vm.staffsimei = row.Wrap(nameof(StaffRowVM.staffsimei));                        //事業従事者氏名
                vm.kanastaffsimei = row.Wrap(nameof(StaffRowVM.kanastaffsimei));                //事業従事者カナ氏名
                var stopflg = DaConvertUtil.BoolToStr(row.CBool(nameof(StaffRowVM.stopflg)));
                vm.stopflg = DaNameService.GetName(db, EnumNmKbn.停止フラグ, stopflg); ;         //使用停止フラグ
                vmList.Add(vm);
            }
            return vmList;
        }

        /// <summary>
        /// 事業従事者（担当者）情報
        /// </summary>
        public static MainInfoVM GetVM(tm_afstaffDto dto)
        {
            var vm = new MainInfoVM();

            vm.staffid = dto.staffid;                   //事業従業者ID
            vm.staffsimei = dto.staffsimei;             //事業従事者氏名
            vm.kanastaffsimei = dto.kanastaffsimei;     //事業従事者カナ氏名
            vm.katudokbn = dto.katudokbn;               //活動区分
            vm.syokusyu = dto.syokusyu;                 //職種
            vm.stopflg = dto.stopflg;                   //フラグ

            return vm;
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

        /// <summary>
        /// 医療機関情報
        /// </summary>
        public static List<DaSelectorKeyModel> GetKikanSelector(List<tm_afkikanDto> kikanSelectorList)
        {
            var kikanlist = kikanSelectorList.Select(e => new DaSelectorKeyModel(e.kikancd, e.kikannm, e.stopflg ? "0" : "1")).ToList();
            return kikanlist;
        }

    }

}
