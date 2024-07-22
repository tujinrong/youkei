// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人検診事業項目並び順設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00805D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 成人保健検診結果（フリー）項目コントロールマスタ
        /// </summary>
        public static List<tm_shfreeitemDto> GetDtl(List<SaveVM> list1, List<SaveVM> list2, List<tm_shfreeitemDto> dtl)
        {
            //固定項目一覧(左)
            dtl = GetDtl(list1, dtl, true);
            //フリー項目一覧(右)
            dtl = GetDtl(list2, dtl, false);

            return dtl;
        }

        /// <summary>
        /// 成人保健検診結果（フリー）項目コントロールマスタ
        /// </summary>
        private static List<tm_shfreeitemDto> GetDtl(List<SaveVM> list, List<tm_shfreeitemDto> dtl, bool haitiflg)
        {
            var orderseq = 1;
            foreach (var vm in list)
            {
                var dto = dtl.Find(e => e.itemcd == vm.itemcd)!;
                dto.orderseq = orderseq++;          //並びシーケンス
                dto.haitiflg = haitiflg;            //画面配置フラグ
            }

            return dtl;
        }
    }
}