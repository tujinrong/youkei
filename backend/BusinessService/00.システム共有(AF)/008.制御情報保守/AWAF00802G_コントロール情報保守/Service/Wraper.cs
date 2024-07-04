// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロール情報保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00802G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// コントロールマスタ
        /// </summary>
        public static List<SearchVM> GetVMList(List<tm_afctrlDto> dtl)
        {
            return dtl.Select(GetVM).ToList();
        }

        /// <summary>
        /// ドロップダウンリスト取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afctrl_mainDto> dtl, Enum名称区分 kbn)
        {
            switch (kbn)
            {
                case Enum名称区分.名称:
                    return dtl.Select(d => new DaSelectorModel(d.ctrlsubcd.ToString(), d.ctrlsubcdnm)).ToList();
                case Enum名称区分.カナ:
                    return dtl.Select(d => new DaSelectorModel(d.ctrlsubcd.ToString(), d.kananm)).ToList();
                case Enum名称区分.略称:
                    return dtl.Select(d => new DaSelectorModel(d.ctrlsubcd.ToString(), d.shortnm)).ToList();
                default:
                    throw new Exception("Enum名称区分 error");
            }
        }

        /// <summary>
        /// コントロールマスタ
        /// </summary>
        private static SearchVM GetVM(tm_afctrlDto dto)
        {
            var vm = new SearchVM();
            vm.ctrlcd = dto.ctrlcd;      //コントロールコード
            vm.itemnm = dto.itemnm;      //項目名称
            vm.datatype = dto.datatype;  //データ型
            vm.rangeflg = dto.rangeflg;  //範囲フラグ
            object value = dto.rangeflg ? new ValueVM(dto.value1, dto.value2) : dto.value1!;
            vm.value = value;            //値
            vm.biko = CStr(dto.biko);    //備考
            vm.upddttm = dto.upddttm;    //更新日時
            return vm;
        }
    }
}
