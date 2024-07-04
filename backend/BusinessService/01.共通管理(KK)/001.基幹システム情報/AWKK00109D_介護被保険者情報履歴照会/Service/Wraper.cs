// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 介護被保険者情報履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00109D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 介護情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afkaigo_rekiDto> dtl)
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
        /// 介護情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afkaigo_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                                                                         //履歴No.
            vm.sikakurirekino = dto.sikakurirekino;                                                                           //資格履歴番号
            vm.kaigohokensyano = dto.kaigohokensyano;                                                                         //介護保険者番号
            vm.hihokensyano = dto.hihokensyano;                                                                               //被保険者番号
            vm.sikakusyutokuymd = FormatWaKjYMD(CDate(dto.sikakusyutokuymd));                                                 //資格取得日
            vm.sikakusosituymd = FormatWaKjYMD(CDate(dto.sikakusosituymd));                                                   //資格喪失日
            vm.yokaigojotaikbnnm = DaNameService.GetName(db, EnumNmKbn.要介護状態区分コード, CStr(dto.yokaigojotaikbncd));    //要介護状態区分(名称)
            vm.yokaigoninteiymd = FormatWaKjYMD(CNDate(dto.yokaigoninteiymd));                                                //要介護認定日
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                                                                        //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                                                                       //最新フラグ

            return vm;
        }
    }
}