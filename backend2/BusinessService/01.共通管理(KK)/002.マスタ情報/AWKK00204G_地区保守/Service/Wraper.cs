// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 地区保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.09.22
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00204G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 地区情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// 地区情報(ヘッダー)
        /// </summary>
        public static SaveMainVM GetVM(tm_aftikuDto dto)
        {
            var vm = new SaveMainVM();

            vm.tikucd = dto.tikucd;             //地区コード
            vm.stopflg = dto.stopflg;           //使用停止フラグ
            vm.tikunm = dto.tikunm;             //地区名
            vm.kanatikunm = dto.kanatikunm;     //地区名(カナ)
            vm.upddttm = dto.upddttm;           //更新日時(排他用)

            return vm;
        }

        /// <summary>
        /// 地区担当者情報一覧
        /// </summary>
        public static List<SubInfoVM> GetVMList(DaDbContext db, List<tm_afstaffDto> dtl)
        {
            var list = new List<SubInfoVM>();
            foreach (tm_afstaffDto dto in dtl)
            {
                list.Add(GetVM(db, dto));
            }

            return list;
        }

        /// <summary>
        /// 地区担当者情報(1行)
        /// </summary>
        public static SubInfoVM GetVM(DaDbContext db, tm_afstaffDto dto)
        {
            var vm = new SubInfoVM();
            vm.staffid = dto.staffid;                                                   //事業従事者ID
            vm.staffsimei = dto.staffsimei;                                             //事業従事者氏名
            vm.kanastaffsimei = dto.kanastaffsimei;                                     //事業従事者カナ氏名
            var syokusyu = dto.syokusyu;
            vm.syokusyu = DaNameService.GetName(db, EnumNmKbn.職種, syokusyu);          //職種
            var katudokbn = dto.katudokbn;
            vm.katudokbn = DaNameService.GetName(db, EnumNmKbn.活動区分, katudokbn);    //活動区分

            return vm;
        }

        /// <summary>
        /// 地区情報(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();

            vm.tikukbn = row.Wrap("kbn");                                               //地区区分コード
            vm.tikukbnnm = DaNameService.GetName(db, EnumNmKbn.地区区分, vm.tikukbn);   //地区区分名称
            vm.tikucd = row.Wrap("cd");                                                 //地区コード
            vm.tikunm = row.Wrap(nameof(RowVM.tikunm));                                 //地区名
            vm.kanatikunm = row.Wrap(nameof(RowVM.kanatikunm));                         //地区名(カナ)
            vm.staffnm = row.Wrap(nameof(RowVM.staffnm));                               //地区担当者(「,」区切り)
            var stopflg = BoolToStr(row.CBool(nameof(RowVM.stopflg)));
            vm.stopflg = DaNameService.GetName(db, EnumNmKbn.停止フラグ, stopflg);      //停止状態

            return vm;
        }
    }
}