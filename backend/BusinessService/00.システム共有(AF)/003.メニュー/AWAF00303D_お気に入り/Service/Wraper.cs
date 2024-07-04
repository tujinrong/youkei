// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お気に入り
// 　　　　　　DB項目から画面項目に変換
// 作成日　　: 2023.02.15
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00303D
{
    public class Wraper : CmWraperBase
    {
        /// <summary>
        /// 機能IDリスト取得
        /// </summary>
        public static List<string> GetKinoidList(List<tt_afokiniiriDto> dtl)
        {
            return dtl.Select(dto => dto.kinoid).ToList();
        }
    }
}