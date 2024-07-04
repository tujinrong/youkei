// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 連絡先
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00605D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 連絡先テーブル
        /// </summary>
        public static tt_afrenrakusakiDto GetDto(SaveVM vm, tt_afrenrakusakiDto dto, string jigyocd)
        {
            dto.atenano = vm.atenano;                   //宛名番号
            dto.jigyocd = jigyocd;                      //利用事業コード
            dto.tel = ToNStr(vm.tel);                   //電話番号
            dto.keitaitel = ToNStr(vm.keitaitel);       //携帯番号
            dto.emailadrs = ToNStr(vm.emailadrs);       //E-mailアドレス
            dto.emailadrs2 = ToNStr(vm.emailadrs2);     //E-mailアドレス2
            dto.syosai = ToNStr(vm.syosai);             //連絡先詳細

            return dto;
        }
    }
}