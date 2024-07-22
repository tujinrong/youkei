// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 世帯検索
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.11.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00706D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 世帯情報一覧
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows)
        {
            List<SearchVM> list = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row));
            }
            return list;
        }

        /// <summary>
        /// 世帯情報(1件)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row)
        {
            var vm = new SearchVM();
            vm.setaino = row.Wrap(nameof(SearchVM.setaino));            //世帯番号
            vm.atenano = row.Wrap(nameof(SearchVM.atenano));            //宛名番号
            vm.name = row.Wrap(nameof(SearchVM.name));                  //氏名
            var sex = row.Wrap(nameof(tt_afatenaDto.sex));              //性別（コード）
            vm.sex = MNm(db, sex, EnumNmKbn.性別_システム共有);         //性別
            vm.bymd = ToNStr(GetBymd(row));                             //生年月日
            var juminkbn = row.Wrap(nameof(SearchVM.juminkbn));         
            vm.juminkbn =  MNm(db, juminkbn, EnumNmKbn.住民区分);       //住民区分
            vm.adrs_yubin = row.Wrap(nameof(SearchVM.adrs_yubin));      //郵便番号
            vm.adrs = row.Wrap(nameof(SearchVM.adrs));                  //住所

            return vm;
        }

        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        private static string MNm(DaDbContext db, String cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }

        /// <summary>
        /// 生年月日表記取得（不詳フラグ=falseまたは生年月日=nullの場合空白で戻る）
        /// </summary>
        private static string GetBymd(DataRow row)
        {
            //生年月日_不詳フラグ
            var bymd_fusyoflg = row.CNBool(nameof(tt_afatenaDto.bymd_fusyoflg));
            //生年月日
            var bymd = row.CStr(nameof(tt_afatenaDto.bymd));
            //生年月日_不詳表記
            var bymd_fusyohyoki = row.CStr(nameof(tt_afatenaDto.bymd_fusyohyoki));

            //不詳フラグ=falseまたは生年月日=nullの場合空白で戻る
            if (!CBool(bymd_fusyoflg) && string.IsNullOrEmpty(bymd.Trim())) { return string.Empty; }

            return CmLogicUtil.GetYMDStr(bymd_fusyoflg, bymd, bymd_fusyohyoki);
        }
    }
}