// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 受診拒否設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.06
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00303D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 受診拒否理由情報一覧取得
        /// </summary>
        public static List<InitRowVM> GetVMList(List<string> cdList, List<tt_shjyusinkyohiriyuDto> dtl1, List<tm_afhanyoDto> dtl2, List<DaSelectorModel> cdnmList)
        {
            var list = new List<InitRowVM>();
            foreach (var cd in cdList)
            {
                var dto = dtl1.Find(e => e.jigyocd == cd);
                var nm = cdnmList.Find(e => e.value == cd)!.label;
                list.Add(GetVM(dto, cd, nm, dtl2));
            }
            return list;
        }

        /// <summary>
        /// 受診拒否理由情報(1行)
        /// </summary>
        private static InitRowVM GetVM(tt_shjyusinkyohiriyuDto? dto, string cd, string nm, List<tm_afhanyoDto> dtl)
        {
            var vm = new InitRowVM();
            vm.jigyocd = cd;                                                                          //成人健（検）診事業コード
            vm.jigyonm = nm;                                                                          //成人健（検）診事業名
            vm.kyohiriyucdnm = DaHanyoService.GetCdNm(dtl, Enum名称区分.名称, CStr(dto?.kyohiriyu));  //受診拒否理由(コード：名称)

            return vm;
        }
    }
}