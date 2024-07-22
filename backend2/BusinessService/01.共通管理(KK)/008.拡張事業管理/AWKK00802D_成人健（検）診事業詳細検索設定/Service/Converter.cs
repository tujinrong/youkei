// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人健（検）診事業詳細検索設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.15
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00802D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 詳細条件設定テーブル(全部)
        /// </summary>
        public static List<tt_affilterDto> GetDtl(List<SaveVM> list, List<tt_affilterDto> dtl)
        {
            dtl = GetDtl(list, dtl, Enum詳細検索条件区分.共通);
            dtl = GetDtl(list, dtl, Enum詳細検索条件区分.独自);

            return dtl;
        }
        /// <summary>
        /// 詳細条件設定テーブル(左部分/右部分)
        /// </summary>
        private static List<tt_affilterDto> GetDtl(List<SaveVM> list, List<tt_affilterDto> dtl, Enum詳細検索条件区分 jyokbn)
        {
            var sort = 1;
            var vmList = list.Where(e => e.jyokbn == jyokbn).ToList();
            foreach (var vm in vmList)
            {
                var dto = dtl.Find(e => e.jyokbn == vm.jyokbn && e.jyoseq == vm.jyoseq)!;
                dto.hyojiflg = vm.hyojiflg; //表示フラグ
                dto.sort = sort++;      //並び順
            }

            return dtl;
        }
    }
}