// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: CSV出力項目選択
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 出力可能項目一覧
        /// </summary>
        public static List<RowVM> GetVMList(List<tm_eurptitemDto> dtl)
        {
            var list = new List<RowVM>();
            foreach (var dto in dtl)
            {
                //出力可能項目情報取得
                list.Add(GetVM(dto));
            }
            return list;
        }

        /// <summary>
        /// 出力可能項目情報取得(1件)
        /// </summary>
        private static RowVM GetVM(tm_eurptitemDto dto)
        {
            var vm = new RowVM();

            vm.reportitemid = dto.yosikiitemid;   //様式項目ID
            vm.reportitemnm = dto.reportitemnm;   //帳票項目名称

            return vm;
        }
    }
}