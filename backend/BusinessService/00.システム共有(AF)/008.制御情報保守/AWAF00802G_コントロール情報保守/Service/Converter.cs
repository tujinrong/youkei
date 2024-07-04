// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロール情報保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json.Linq;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF00802G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// コントロールキーリスト(排他用)
        /// </summary>
        public static List<object[]> GetKeyList(string ctrlmaincd, int ctrlsubcd, List<SaveVM> ctrlcdList)
        {
            return ctrlcdList.Select(vm => new object[]
            {
                ctrlmaincd, //コントロールメインコード
                ctrlsubcd,  //コントロールサブコード
                vm.ctrlcd   //コントロールコード
            }).ToList();
        }

        /// <summary>
        /// コントロールデータ情報一覧
        /// </summary>
        public static List<tm_afctrlDto> GetDtl(List<SaveVM> savelist, List<tm_afctrlDto> oldDtl)
        {
            return oldDtl.Select(x => GetDto(x, savelist)).ToList();
        }

        /// <summary>
        /// コントロールデータ情報(1件)
        /// </summary>
        private static tm_afctrlDto GetDto(tm_afctrlDto dto, List<SaveVM> savelist)
        {
            var vm = savelist.Find(x => x.ctrlcd == dto.ctrlcd)!;
            if (dto.rangeflg)
            {
                if (vm.value is not JObject jObject)
                {
                    throw new ArgumentException("JObject error");
                }
                dto.value1 = ToNStr(CStr(jObject[nameof(ValueVM.value1)])); //値１
                dto.value2 = ToNStr(CStr(jObject[nameof(ValueVM.value2)])); //値２
            }
            else
            {
                dto.value1 = ToNStr(CStr(vm.value));    //値１
                dto.value2 = null;                      //値２
            }
            dto.biko = ToNStr(vm.biko);                 //備考
            return dto;
        }
    }
}