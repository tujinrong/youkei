// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 共通バー情報
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.04.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00603S
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 共通バー一覧情報
        /// </summary>
        public static List<InfoVM> GetVMList(DaDbContext db, List<tm_afmeisyoDto> dtl, DataRowCollection rows, List<GamenModel> auths, bool alertviewflg)
        {
            var rowlist = rows.Cast<DataRow>().ToList();
            return dtl.Select(d => GetVM(db, d, rowlist, auths, alertviewflg)).ToList();
        }

        /// <summary>
        /// 共通バー明細(1件)
        /// </summary>
        private static InfoVM GetVM(DaDbContext db, tm_afmeisyoDto dto, List<DataRow> rowlist, List<GamenModel> auths, bool alertviewflg)
        {
            var vm = new InfoVM();
            var nmcd = CInt(dto.nmcd);
            vm.barno = (Enum共通バー番号)nmcd;      //共通バー番号
            vm.barnm = dto.nm;                      //共通バー名称
            var attnflg = rowlist.Find(r => r.CInt(nameof(InfoVM.barno)) == nmcd)?.CBool(nameof(InfoVM.attnflg));
            vm.attnflg = attnflg ?? false;          //注意フラグ

            //機能ID
            var kinoid = DaNameService.GetKbn1(db, EnumNmKbn.共通バー番号_共通機能, nmcd.ToString());
            //権限取得
            var auth = auths.Find(e => e.menuid == kinoid);
            if (auth != null)
            {
                vm.enabled = true;                      //アクセス権限(権限がない場合:false)
                vm.addflg = auth.addflg;                //追加権限フラグ
                vm.updateflg = auth.updateflg;          //修正権限フラグ
                vm.deleteflg = auth.deleteflg;          //削除権限フラグ
                vm.personalnoflg = auth.personalnoflg;  //個人番号利用権限フラグ
            }
            //警告参照権限がない場合、共通バー使用不可
            if (vm.barno == Enum共通バー番号.警告情報照会 && (alertviewflg == false))
            {
                vm.enabled = false;                     //アクセス権限(権限がない場合:false)
            }

            return vm;
        }
    }
}