// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.変換区分管理画面
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2024.03.06
// 作成者　　: 高
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00609D
{
    public class Wraper : CmWraperBase
    {

        /// <summary>
        /// ドロップダウンリストを取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afhanyo_mainDto> dtl)
        {
            return dtl.Select(d => new DaSelectorModel(d.hanyosubcd.ToString(), d.hanyosubcdnm)).ToList();
        }

        /// <summary>
        /// ドロップダウンリストを取得
        /// </summary>
        public static List<DaSelectorModel> GetSelectorList(List<tm_afmeisyo_mainDto> dtl)
        {
            return dtl.Select(d => new DaSelectorModel(d.nmsubcd.ToString(), d.nmsubcdnm)).ToList();
        }
    }
}
