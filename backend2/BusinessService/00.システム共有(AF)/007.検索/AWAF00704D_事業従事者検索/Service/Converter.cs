// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業従事者検索
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.10.20
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00704D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req, List<string> keyList)
        {
            var paras = new List<AiKeyValue>
            {
                new AiKeyValue($"{nameof(SearchRequest.staffsimei)}_in", ToLikeStr(req.staffsimei)),                    //事業従事者氏名
                new AiKeyValue($"{nameof(SearchRequest.syokusyu)}_in", CmLogicUtil.GetSearchPara(req.syokusyu)),        //職種
                new AiKeyValue($"{nameof(SearchRequest.katudokbn)}_in", CmLogicUtil.GetSearchPara(req.katudokbn)),      //活動区分
                new AiKeyValue($"{nameof(tm_afstaff_subDto.jissijigyo)}s_in", GetKeyList(keyList)),                     //実施事業
                new($"{nameof(tm_afstaffDto.stopflg)}_in", req.hasStopFlg)                                              //使用停止sql
            };
            return paras;
        }

        /// <summary>
        /// 実施事業取得
        /// </summary>
        private static string? GetKeyList(List<string> keyList)
        {
            if (keyList.Count > 0)
            {
                return string.Join(DaStrPool.C_COMMA, keyList);
            }
            
            //マスタ画面の場合、全件取得
            return null;
        }
    }
}
