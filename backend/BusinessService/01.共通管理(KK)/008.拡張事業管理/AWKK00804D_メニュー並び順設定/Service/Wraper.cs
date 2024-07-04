// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メニュー並び順設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.12.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00804D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 画面一覧取得
        /// </summary>
        public static List<SearchVM> GetVMList(List<tm_afmenuDto> dtl1, List<tm_afkinoDto> dtl2)
        {
            var list = new List<SearchVM>();
            foreach (var dto in dtl1)
            {
                var dto2 = dtl2.Find(e => e.kinoid == dto.kinoid)!;
                list.Add(GetVM(dto, dto2));
            }

            return list;
        }

        /// <summary>
        /// 画面明細(1行)
        /// </summary>
        private static SearchVM GetVM(tm_afmenuDto dto, tm_afkinoDto dto2)
        {
            var vm = new SearchVM();
            vm.kinoid = dto.kinoid;     //機能ID
            vm.hyojinm = dto2.hyojinm;  //機能表示名称

            return vm;
        }
    }
}