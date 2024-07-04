// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 成人健（検）診事業詳細検索設定
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.01.15
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00802D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 画面一覧取得
        /// </summary>
        public static List<SearchVM> GetVMList(List<tt_affilterDto> dtl, Enum詳細検索条件区分 jyokbn)
        {
            var list = new List<SearchVM>();
            var dtl2 = dtl.Where(e => e.jyokbn == jyokbn).OrderByDescending(e => e.hyojiflg).ThenBy(e => CInt(e.sort)).ThenBy(e => e.jyoseq).ToList();
            foreach (var dto in dtl2)
            {
                list.Add(GetVM(dto));
            }

            return list;
        }

        /// <summary>
        /// 画面明細(1行)
        /// </summary>
        private static SearchVM GetVM(tt_affilterDto dto)
        {
            var vm = new SearchVM();
            vm.jyokbn = dto.jyokbn;     //条件区分
            vm.jyoseq = dto.jyoseq;     //条件シーケンス
            vm.hyojiflg = dto.hyojiflg; //表示フラグ
            vm.hyojinm = dto.hyojinm;   //詳細条件表示名

            return vm;
        }
    }
}