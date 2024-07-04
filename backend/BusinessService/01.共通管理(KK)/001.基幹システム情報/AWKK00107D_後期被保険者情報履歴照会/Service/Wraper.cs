// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 後期被保険者情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00107D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 後期情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afkokihoken_rekiDto> dtl)
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
        /// 後期情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afkokihoken_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                                                   //履歴No.
            vm.rirekino = dto.rirekino;                                                                                                 //履歴番号
            vm.hihokensyano = dto.hihokensyano;                                                                                         //被保険者番号
            vm.hiho_sikakusyutokuymd = FormatWaKjYMD(CDate(dto.hiho_sikakusyutokuymd));                                                 //被保険者資格取得年月日
            vm.hiho_sikakusosituymd = FormatWaKjYMD(CNDate(dto.hiho_sikakusosituymd));                                                  //被保険者資格喪失年月日
            vm.hiho_sikakusyutokujiyunm = DaNameService.GetName(db, EnumNmKbn.資格取得事由コード, dto.hiho_sikakusyutokujiyucd);        //被保険者資格取得事由(名称)
            vm.hiho_sikakusositujiyunm = DaNameService.GetName(db, EnumNmKbn.資格喪失事由コード, CStr(dto.hiho_sikakusositujiyucd));    //被保険者資格喪失事由(名称)
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                                  //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                                 //最新フラグ

            return vm;
        }
    }
}