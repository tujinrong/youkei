// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 生活保護受給情報履歴履歴照会
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;
using static BCC.Affect.DataAccess.DaFormatUtil;

namespace BCC.Affect.Service.AWKK00108D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 生保情報履歴一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, List<tt_afseiho_rekiDto> dtl)
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
        /// 生保情報履歴(1行)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, tt_afseiho_rekiDto dto, int rirekinum)
        {
            var vm = new RowVM();
            vm.rirekinum = rirekinum;                                       //履歴No.
            vm.sinseirirekino = dto.sinseirirekino;                         //申請履歴番号
            vm.fukusijimusyocd = dto.fukusijimusyocd;                       //福祉事務所コード
            vm.caseno = dto.caseno;                                         //ケース番号
            vm.ketteirirekino = dto.ketteirirekino;                         //決定履歴番号
            vm.inno = dto.inno;                                             //員番号
            vm.seihoymdf = FormatWaKjYMD(CDate(dto.seihoymdf));             //生活保護開始年月日
            vm.teisiymd = FormatWaKjYMD(CDate(dto.teisiymd));               //停止年月日
            vm.teisikaijoymd = FormatWaKjYMD(CNDate(dto.teisikaijoymd));    //停止解除年月日
            vm.haisiymd = FormatWaKjYMD(CNDate(dto.haisiymd));              //廃止年月日
            vm.upddttm = FormatWaKjDttm2(dto.upddttm);                      //更新日時
            vm.saisinflg = FormatFlgStr(dto.saisinflg);                     //最新フラグ

            return vm;
        }
    }
}