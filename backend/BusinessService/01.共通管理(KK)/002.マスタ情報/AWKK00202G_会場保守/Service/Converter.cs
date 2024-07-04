// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 会場保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.11.02
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00202G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tm_afkaijoDto.kaijocd)}_in", CmLogicUtil.GetSearchPara(req.kaijocd)));    //会場コード

            return paras;
        }

        /// <summary>
        /// 会場情報マスタ
        /// </summary>
        public static tm_afkaijoDto GetDto(tm_afkaijoDto dto, MainInfoVM vm, string kaijocd)
        {
            dto.kaijocd = kaijocd;                         //会場コード
            dto.kaijonm = vm.kaijonm;                      //会場名
            dto.kanakaijonm = ToKana(vm.kanakaijonm);      //会場名(カナ)
            dto.adrs = vm.adrs;                            //住所
            dto.katagaki = vm.katagaki;                    //方書
            dto.kaijorenrakusaki = vm.kaijorenrakusaki;    //会場連絡先
            dto.stopflg = vm.stopflg;                      //使用停止フラグ
            dto.gyoseikucd = ToNStr(vm.gyoseikucd);        //行政区

            return dto;
        }

        /// <summary>
        /// 会場情報サブマスタ
        /// </summary>
        public static List<tm_afkaijo_subDto> GetDtl(List<TikuOneSaveVM> tikusaveList, string kaijocd)
        {
            var dtl = new List<tm_afkaijo_subDto>();
            foreach (var key in tikusaveList)
            {
                foreach (var tikucd in key.tikucdList)
                {
                    dtl.Add(new tm_afkaijo_subDto
                    {
                        kaijocd = kaijocd,      //会場コード
                        tikukbn = key.tikukbn,  //地区区分
                        tikucd = tikucd         //地区コード
                    });
                }
            }

            return dtl;
        }
    }
}
