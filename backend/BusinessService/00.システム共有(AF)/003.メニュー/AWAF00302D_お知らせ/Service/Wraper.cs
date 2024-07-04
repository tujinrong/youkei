// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お知らせ
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.01.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00302D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索ページのお知らせ一覧を取得
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows, string userid)
        {
            List<SearchVM> list = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row, userid));
            }
            return list;
        }

        /// <summary>
        /// お知らせ(件単位)を取得
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row, string userid)
        {
            SearchVM vm = new SearchVM();
            var juyodo = row.Wrap(nameof(SearchVM.juyodo));
            //重要度
            vm.juyodo = DaSelectorService.GetCdNm(db, juyodo, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(EnumNmKbn.重要度));
            vm.syosai = row.Wrap(nameof(SearchVM.syosai));              //詳細
            vm.kigenymd = row.CDate(nameof(SearchVM.kigenymd));         //提示期限
            vm.infoseq = row.CLng(nameof(SearchVM.infoseq));            //シーケンス番号
            vm.upddttm = row.CDate(nameof(SearchVM.upddttm));           //更新日時
            vm.readflg = row.CBool(nameof(SearchVM.readflg));           //既読フラグ(true:既読　false:未読)
            vm.regusernm = row.Wrap(nameof(SearchVM.regusernm));        //登録操作者名
            vm.regdttm = row.CDate(nameof(SearchVM.regdttm));           //登録日時
            var reguserid = row.Wrap(nameof(tt_afinfoDto.reguserid));
            vm.editflg = (userid == reguserid);                         //編集フラグ
            vm.atesakiflg = row.CBool(nameof(SearchVM.atesakiflg));     //宛先指定フラグ(true:指定　false:未指定)
            if (vm.atesakiflg)
            {
                var atesaki = row.Wrap(nameof(tt_afinfoDto.atesaki));   //宛先
                vm.userlist = atesaki.Split(DaStrPool.COMMA).ToList();  //宛先一覧(ユーザーID)
            }

            return vm;
        }
    }
}