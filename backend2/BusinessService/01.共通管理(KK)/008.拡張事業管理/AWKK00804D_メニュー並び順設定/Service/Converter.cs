// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メニュー並び順設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00804D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// メニューマスタ
        /// </summary>
        public static List<tm_afmenuDto> GetDtl(List<SaveVM> list, List<tm_afmenuDto> dtl)
        {
            var orderseq = 1;
            foreach (var vm in list)
            {
                var dto = dtl.Find(e => e.kinoid == vm.kinoid)!;
                dto.orderseq = orderseq++;  //並びシーケンス
            }

            return dtl;
        }
    }
}