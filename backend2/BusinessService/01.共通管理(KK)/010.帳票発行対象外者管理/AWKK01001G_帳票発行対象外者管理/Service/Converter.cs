// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行対象外者管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.12.22
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK01001G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 帳票発行対象外者テーブルリスト
        /// </summary>
        public static List<tt_kkrpthakkotaisyogaisyaDto> GetDtl(List<SaveVM> savelist, List<tt_kkrpthakkotaisyogaisyaDto> oldDtl, string atenano)
        {
            var dtl = new List<tt_kkrpthakkotaisyogaisyaDto>();
            foreach (var vm in savelist)
            {
                var dto = oldDtl.Find(e => e.rptgroupid == vm.rptgroupid);
                if (dto == null)
                {
                    dto = new tt_kkrpthakkotaisyogaisyaDto();
                }
                dtl.Add(GetDto(vm, dto, atenano, vm.rptgroupid));
            }
            return dtl;
        }

        /// <summary>
        /// 帳票発行対象外者テーブル
        /// </summary>
        private static tt_kkrpthakkotaisyogaisyaDto GetDto(SaveVM vm, tt_kkrpthakkotaisyogaisyaDto dto, string atenano, string rptgroupid)
        {
            dto.atenano = atenano;                          //宛名番号
            dto.rptgroupid = rptgroupid;                    //帳票グループID
            dto.uketukeymd = vm.uketukeymd;                 //受付日
            dto.taisyogairiyu = ToNStr(vm.taisyogairiyu);   //対象外理由

            return dto;
        }
    }
}