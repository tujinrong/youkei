// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 会場保守
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.02
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00202G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 会場情報一覧
        /// </summary>
        public static List<RowVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            return rows.Cast<DataRow>().Select(r => GetVM(db, r)).ToList();
        }

        /// <summary>
        /// 会場情報(地区区分と地区一覧)
        /// </summary>
        public static List<TikuOneInitVM> GetVMList(DaDbContext db, List<tm_afkaijo_subDto> dtl, List<tm_afmeisyoDto> tikuList)
        {
            var list = new List<TikuOneInitVM>();
            foreach (var tikukbn in tikuList)
            {
                var vm = new TikuOneInitVM();
                vm.tikukbn = (Enum地区区分)CInt(tikukbn.nmcd);                                                                                  //名称テーブルに設定地区区分
                vm.tikukbnnm = tikukbn.nm;　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　          //タイトル地区区分表示名称
                vm.tikucdList = dtl.Where(e => e.tikukbn == vm.tikukbn).Select(e => e.tikucd).ToList();　　　　　　　　　　　　　　　　         //会場サーブマスタに各地区区分の設定地区情報
                vm.tikucdnmList = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.地区情報マスタ, false, tikukbn.nmcd); //地区マスタに各地区区分の設定地区情報

                list.Add(vm);
            }

            return list;
        }

        /// <summary>
        /// 会場情報(詳細画面)
        /// </summary>
        public static MainInfoVM GetVM(tm_afkaijoDto dto)
        {
            var vm = new MainInfoVM();
            vm.kaijocd = dto.kaijocd;                         //会場コード
            vm.kaijonm = dto.kaijonm;                         //会場名
            vm.kanakaijonm = CStr(dto.kanakaijonm);           //会場名(カナ)
            vm.stopflg = dto.stopflg;                         //利用停止
            vm.adrs = dto.adrs;                               //住所
            vm.katagaki = dto.katagaki;                       //方書
            vm.kaijorenrakusaki = dto.kaijorenrakusaki;       //会場連絡先
            vm.gyoseikucd = dto.gyoseikucd!;                  //行政区
            vm.upddttm = dto.upddttm;                         //更新日時

            return vm;
        }

        /// <summary>
        /// 会場情報(一覧)
        /// </summary>
        private static RowVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new RowVM();

            vm.kaijocd = row.Wrap(nameof(vm.kaijocd));                              //会場コード
            vm.kaijonm = row.Wrap(nameof(vm.kaijonm));                              //会場名
            vm.kanakaijonm = row.Wrap(nameof(vm.kanakaijonm));                      //会場名(カナ)
            vm.kaijorenrakusaki = row.Wrap(nameof(RowVM.kaijorenrakusaki));         //会場連絡先
            var adrs = row.Wrap("adrs");
            var katagaki = row.Wrap("katagaki");
            vm.adrskatagaki = adrs + katagaki;                                      //住所方書
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                       //行政区
            var stopflg = BoolToStr(row.CBool(nameof(RowVM.stopflg)));
            vm.stopflg = DaNameService.GetName(db, EnumNmKbn.停止フラグ, stopflg);  //停止状態

            return vm;
        }
    }
}
