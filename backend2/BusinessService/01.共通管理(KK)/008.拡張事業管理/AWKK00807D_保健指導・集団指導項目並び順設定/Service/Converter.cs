// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導・集団指導項目並び順設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00805D;

namespace BCC.Affect.Service.AWKK00807D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 指導（フリー項目）コントロールマスタ
        /// </summary>
        public static List<tm_kksidofreeitemDto> GetDtl(List<SaveVM> list, List<tm_kksidofreeitemDto> dtl)
        {
            var orderseq = 1;
            foreach (var vm in list)
            {
                var dto = dtl.Find(e => e.itemcd == vm.itemcd)!;
                dto.orderseq = orderseq++;          //並びシーケンス
            }

            return dtl;
        }
    }
}