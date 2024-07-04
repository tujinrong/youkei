// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行履歴管理
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
using AIplus.FreeQuery.Common;
using AIplus.FreeQuery.Where;
using NPOI.Util;
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWAF01101G
{
    public class Converter : CmConerterBase
    {       
        public static List<AiKeyValue> GetParameters(SearchListRequest req)
        {
            var paras = new List<AiKeyValue>();

            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.rptid)}_in", CmLogicUtil.GetSearchPara(req.rptid)));             　　　　 //帳票名
            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.yosikiid)}_in", CmLogicUtil.GetSearchPara(req.yosikiid)));                //様式名
            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.nendo)}_in", req.nendo));          　　　　　　　　　　　　　　　　　　 　//年度
            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.taisyocd)}_in", CmLogicUtil.GetSearchPara(req.taisyocd)));                //抽出対象
            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.hakkodttmf)}_in", DaSelectorService.GetCd(req.hakkodttmf)));      　　    //発行日時(開始)
            paras.Add(new AiKeyValue($"{nameof(SearchListRequest.hakkodttmt)}_in", DaSelectorService.GetCd(req.hakkodttmt)));      　　    //発行日時(終了)
            return paras;
        }
    }
}