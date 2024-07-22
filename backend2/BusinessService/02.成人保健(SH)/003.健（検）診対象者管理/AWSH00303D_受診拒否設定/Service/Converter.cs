// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 受診拒否設定
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.06
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00303D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 受診拒否理由テーブルリスト
        /// </summary>
        public static List<tt_shjyusinkyohiriyuDto> GetDtl(List<SaveRowVM> vmList, int nendo, string atenano)
        {
            var dtl = new List<tt_shjyusinkyohiriyuDto>();
            foreach (var vm in vmList)
            {
                dtl.Add(GetDto(vm, nendo, atenano));
            }
            return dtl;
        }

        /// <summary>
        /// 受診拒否理由テーブル
        /// </summary>
        private static tt_shjyusinkyohiriyuDto GetDto(SaveRowVM vm, int nendo, string atenano)
        {
            var dto = new tt_shjyusinkyohiriyuDto();
            dto.nendo = nendo;                                          //年度
            dto.atenano = atenano;                                      //宛名番号
            dto.jigyocd = vm.jigyocd;                                   //成人健（検）事業コード
            dto.kyohiriyu = DaSelectorService.GetCd(vm.kyohiriyucdnm);  //受診拒否理由

            return dto;
        }
    }
}