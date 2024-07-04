// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: パーセンタイル値保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.06.01
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaSelectorService;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWBH00501G
{
    public class Wraper : CmWraperBase
    {
        //一時的利用
        public enum BosiEnumNmKbn : long
        {
            部位 = 1003 * 100000000L + 4,
        }

        /// <summary>
        /// 初期化処理（ドロップダウンリストの初期化）
        /// </summary>
        public static InitListResponse GetVM(DaDbContext db)
        {
            var vm = new InitListResponse();

            //ドロップダウンリスト初期設定
            vm.buicdlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(BosiEnumNmKbn.部位)).ToString());
            vm.sexlist = GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.名称マスタ, false, ((long)(EnumNmKbn.性別_住民基本台帳)).ToString());

            return vm;
        }

        /// <summary>
        /// パーセンタイル値情報一覧（月・日単位）
        /// </summary>
        public static List<PasentairuListVM> GetPasentairuVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GeSyudanVM(db, r)).ToList();
        }

        /// <summary>
        /// パーセンタイル値情報（一行）（月・日単位）
        public static PasentairuListVM GeSyudanVM(DaDbContext db, DataRow row)
        {
            var vm = new PasentairuListVM();
            var pvm = new ProcedureVM();

            vm.buicd = CStr(row.Wrap(nameof(pvm.buicode)));                             //部位コード（キー項目、非表示）
            vm.sex = CStr(row.Wrap(nameof(pvm.sexcode)));                               //性別（コード）（キー項目、非表示）
            vm.prockbn = CInt(row.Wrap(nameof(vm.prockbn)));                            //処理区分（非表示）

            vm.month = CInt(row.Wrap(nameof(pvm.tuki)));                                //月
            vm.date = CInt(row.Wrap(nameof(pvm.bi)));                                   //日
            vm.pasentairustd = CInt(row.Wrap(nameof(vm.pasentairustd)));                //パーセンタイル標準 
            vm.pasentairu3p = CInt(row.Wrap(nameof(vm.pasentairu3p)));                  //パーセンタイル3P 
            vm.pasentairu10p = CInt(row.Wrap(nameof(vm.pasentairu10p)));                //パーセンタイル10P
            vm.pasentairu25p = CInt(row.Wrap(nameof(vm.pasentairu25p)));                //パーセンタイル25P
            vm.pasentairu50p = CInt(row.Wrap(nameof(vm.pasentairu50p)));                //パーセンタイル50P
            vm.pasentairu75p = CInt(row.Wrap(nameof(vm.pasentairu75p)));                //パーセンタイル75P
            vm.pasentairu90p = CInt(row.Wrap(nameof(vm.pasentairu90p)));                //パーセンタイル90P
            vm.pasentairu97p = CInt(row.Wrap(nameof(vm.pasentairu97p)));                //パーセンタイル97P

            return vm;
        }
    }
}