// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住民情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00102D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 住民情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afjumin_rekiDto> dtl)
        {
            var rirekinum = 0;
            var list = new List<RowVM>();
            foreach (var dto in dtl)
            {
                list.Add(GetVM(db, dto, ++rirekinum));
            }
            return list;
        }
        /// <summary>
        /// 住民情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afjumin_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                   //履歴No.
            vm.kojinrirekino = dto.kojinrirekino;                                                       //個人履歴番号
            vm.kojinrireki_edano = dto.kojinrireki_edano;                                               //個人履歴番号_枝番号
            vm.name = dto.simei_yusen;                                                                  //氏名
            vm.juminjotai = DaNameService.GetName(db, EnumNmKbn.住民状態_住民基本台帳, dto.juminjotai); //住民状態
            vm.idoymd = CmLogicUtil.GetYMDStr(dto.idoymd_fusyoflg, dto.idoymd, dto.idoymd_fusyohyoki);  //異動年月日
            //異動事由
            var idojiyu1 = DaNameService.GetName(db, EnumNmKbn.記載の事由, dto.idojiyu);
            var idojiyu2 = DaNameService.GetName(db, EnumNmKbn.消除の事由, dto.idojiyu);
            var idojiyu3 = DaNameService.GetName(db, EnumNmKbn.修正の事由, dto.idojiyu);
            vm.idojiyu = $"{idojiyu1}{idojiyu2}{idojiyu3}";
            vm.adrs = $"{dto.adrs_tyoaza}{dto.adrs_bantihyoki}{dto.adrs_katagaki}";                     //住所(住所_町字、住所_番地号表記、住所_方書)
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                 //最新フラグ

            return vm;
        }
    }
}