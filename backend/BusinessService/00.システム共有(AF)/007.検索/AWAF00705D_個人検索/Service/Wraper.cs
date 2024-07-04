// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人検索
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00705D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 個人情報一覧
        /// </summary>
        public static List<SearchVM> GetVMList(DaDbContext db, DataRowCollection rows, bool alertviewflg, bool adrsFlg)
        {
            var list = new List<SearchVM>();
            foreach (DataRow row in rows)
            {
                list.Add(GetVM(db, row, alertviewflg, adrsFlg));
            }
            return list;
        }

        /// <summary>
        /// 個人情報(1件)
        /// </summary>
        private static SearchVM GetVM(DaDbContext db, DataRow row, bool alertviewflg, bool adrsFlg)
        {
            var vm = new SearchVM();
            vm.atenano = row.Wrap(nameof(tt_afatenaDto.atenano));                            //宛名番号
            vm.name = row.Wrap(nameof(tt_afatenaDto.simei_yusen));                           //氏名
            vm.kname = row.Wrap(nameof(tt_afatenaDto.simei_kana_yusen));                     //カナ氏名
            var sex = row.Wrap(nameof(tt_afatenaDto.sex));                                   
            vm.sex = GetNM(db, sex, EnumNmKbn.性別_システム共有);                            //性別
            vm.bymd = CmLogicUtil.GetBymd(row);                                              //生年月日
            vm.adrs = CmLogicUtil.GetAdrs(row, adrsFlg);                                     //住所
            vm.gyoseiku = CmLogicUtil.GetGyoseikuNm(db, row);                                //行政区
            vm.juminkbn = CmLogicUtil.GetJuminkbn(db, row);                                  //住民区分
            var hokenkbn = row.Wrap(nameof(tt_afatenaDto.hokenkbn));
            vm.hokenkbn = DaNameService.GetName(db, EnumNmKbn.保険区分_共通管理, hokenkbn);  //保険区分
            var siensotikbn = row.Wrap(nameof(tt_afatenaDto.siensotikbn));                   //支援措置区分
            vm.keikoku = CmLogicUtil.GetKeikoku(db, siensotikbn, alertviewflg);              //警告内容

            return vm;
        }

        /// <summary>
        /// 名称マスタから名称取得
        /// </summary>
        private static string GetNM(DaDbContext db, String cd, EnumNmKbn kbn)
        {
            return DaSelectorService.GetName(db, cd, Enum名称区分.名称, Enumマスタ区分.名称マスタ, EnumToStr(kbn));
        }
    }
}