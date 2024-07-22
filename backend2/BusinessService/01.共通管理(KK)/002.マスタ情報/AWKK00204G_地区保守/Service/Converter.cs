// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 地区保守
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.09.22
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWKK00204G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();
            paras.Add(new AiKeyValue($"{nameof(tm_aftikuDto.tikukbn)}_in", CmLogicUtil.GetSearchPara(req.tikukbn)));        //地区区分
            paras.Add(new AiKeyValue($"{nameof(tm_aftikuDto.tikucd)}_in", CmLogicUtil.GetSearchPara(req.tiku)));            //地区コード
            paras.Add(new AiKeyValue($"{nameof(tm_aftiku_subDto.staffid)}_in", CmLogicUtil.GetSearchPara(req.staff)));      //地区担当者ID

            return paras;
        }

        /// <summary>
        /// 地区情報マスタ
        /// </summary>
        public static tm_aftikuDto GetDto(tm_aftikuDto dto, SaveMainVM vm, string tikukbn)
        {
            dto.tikukbn = (Enum地区区分)CInt(tikukbn);    //地区区分
            dto.tikucd = vm.tikucd;                 //地区コード
            dto.stopflg = vm.stopflg;               //使用停止フラグ
            dto.tikunm = vm.tikunm;                 //地区名
            dto.kanatikunm = ToKana(vm.kanatikunm); //地区名（カナ）

            return dto;
        }

        /// <summary>
        /// 地区情報サブマスタ
        /// </summary>
        public static List<tm_aftiku_subDto> GetDtl(List<string> keyList, string tikukbn, string tikucd)
        {
            var dtl = new List<tm_aftiku_subDto>();
            foreach (var key in keyList)
            {
                dtl.Add(new tm_aftiku_subDto
                {
                    tikukbn = tikukbn,  //地区区分
                    tikucd = tikucd,    //地区コード
                    staffid = key       //地区担当者
                });
            }

            return dtl;
        }
    }
}