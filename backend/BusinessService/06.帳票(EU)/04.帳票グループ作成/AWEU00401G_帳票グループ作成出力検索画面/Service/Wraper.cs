// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票グループ作成検索画面	
// 　　　  　　DB項目から画面項目に変換 
// 作成日　　: 2023.10.31
// 作成者　　:  
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWEU00401G
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 検索情報リストを取得
        /// </summary>
        public static List<SearchVM> GetSearchVmList(DaDbContext db, DataRowCollection rows)
        {
            var vmList = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                vmList.Add(GetSearchVm(db, row));
            }
            return vmList;
        }

        /// <summary>
        /// 検索情報を取得
        /// </summary>
        private static SearchVM GetSearchVm(DaDbContext db, DataRow row)
        {
            var vm = new SearchVM();

            //帳票グループID
            vm.rptgroupid = row.Wrap(nameof(tm_eurptgroupDto.rptgroupid));
            //帳票グループ名
            vm.rptgroupnm = row.Wrap(nameof(tm_eurptgroupDto.rptgroupnm));

            //個人連絡先
            var kojinrenrakusakicd = row.Wrap(nameof(tm_eurptgroupDto.kojinrenrakusakicd));
            vm.kojinrenrakusakicd = GetHanyoName(db, EnumHanyoKbn.連絡先用事業コード, kojinrenrakusakicd);
            //メモ情報
            var memocd = row.Wrap(nameof(tm_eurptgroupDto.memocd));
            vm.memocd = GetHanyoName(db, EnumHanyoKbn.メモ事業コード, memocd);
            //電子ファイル情報
            var electronfilecd = row.Wrap(nameof(tm_eurptgroupDto.electronfilecd));
            vm.electronfilecd = GetHanyoName(db, EnumHanyoKbn.電子ファイル事業コード, electronfilecd);
            //フォロー管理
            var followmanage = row.Wrap(nameof(tm_eurptgroupDto.followmanage));
            vm.followmanage = GetHanyoName(db, EnumHanyoKbn.フォロー把握事業コード, followmanage);

            return vm;
        }

        /// <summary>
        /// 汎用データ名称を取得
        /// </summary>
        private static string GetHanyoName(DaDbContext db, EnumHanyoKbn kbn, string cd)
        {
            //汎用データ一覧
            var hanyoDtl = DaSelectorService.GetSelectorList(db, Enum名称区分.名称, Enumマスタ区分.汎用マスタ, false, EnumToStr(kbn)).ToList();

            var cdList = new List<string>(cd.Split(','));
            var nameList = hanyoDtl.OrderBy(e => cdList.IndexOf(e.value)).Where(e => cdList.Contains(e.value)).Select(e => e.label).ToList();

            if (nameList != null && nameList.Count > 0)
            {
                //名称
                return string.Join(',', nameList);
            }

            return string.Empty;
        }
    }
}