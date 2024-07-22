// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基準値保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.16
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00205G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 基準値マスタ
        /// </summary>
        public static tm_kkkijunDto GetDto(tm_kkkijunDto dto, string gyomukbn, string kijunjigyocd,
                                        string itemcd, int edano, SaveMainVM vm)
        {
            dto.gyomukbn = gyomukbn;                                                                  //業務区分
            dto.kijunjigyocd = kijunjigyocd;                                                          //基準値事業コード
            dto.itemcd = itemcd;                                                                      //項目コード
            dto.edano = edano;                                                                        //枝番
            dto.yukoymdf = CStr(vm.yukoymdf);                                                         //有効年月日（開始）
            dto.yukoymdt = CStr(vm.yukoymdt);                                                         //有効年月日（終了）
            dto.agef = vm.agef;                                                                       //年齢（開始）
            dto.aget = vm.aget;                                                                       //年齢（終了）
            dto.sex = (EnumSex)CInt(vm.sex);                                                          //性別
            dto.kijunvaluehyoki = CStr(vm.kijunvaluehyoki);                                           //基準値表記
            dto.alertvaluehyoki = CStr(vm.alertvaluehyoki);                                           //注意値表記
            dto.errvaluehyoki = CStr(vm.errvaluehyoki);                                               //異常値表記
            if (vm.mainnumsetinfo != null)
            {
                dto.errvalue1t = vm.mainnumsetinfo.errvalue1t;                                        //異常値（数値）以下
                dto.alertvalue1f = vm.mainnumsetinfo.alertvalue1f;                                    //注意値（数値）開始
                dto.alertvalue1t = vm.mainnumsetinfo.alertvalue1t;                                    //注意値（数値）終了
                dto.kijunvaluef = vm.mainnumsetinfo.kijunvaluef;                                      //基準値（数値）開始   
                dto.kijunvaluet = vm.mainnumsetinfo.kijunvaluet;                                      //基準値（数値）終了
                dto.alertvalue2f = vm.mainnumsetinfo.alertvalue2f;                                    //注意値（数値）開始
                dto.alertvalue2t = vm.mainnumsetinfo.alertvalue2t;                                    //注意値（数値）終了
                dto.errvalue2f = vm.mainnumsetinfo.errvalue2f;                                        //異常値（数値）以上
            }
            dto.hanteicd = CStr(ListToCommaStr(vm.maincodesetinfo!.hanteicdlist));                    //基準値（コード）
            dto.alerthanteicd = CStr(ListToCommaStr(vm.maincodesetinfo.alerthanteicdlist));           //注意値（コード）
            dto.errhanteicd = CStr(ListToCommaStr(vm.maincodesetinfo.errhanteicdlist));               //異常値（コード）

            return dto;
        }
    }
}
