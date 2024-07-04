// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 年度切替
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.01.31
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.DataAccess.DaConvertUtil;

namespace BCC.Affect.Service.AWSH00304G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(int nendo, List<string> jigyocds, List <string> kyohiriyus)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tt_shjyusinkyohiriyuDto.nendo)}_in", nendo),                          //年度
                new($"{nameof(tt_shjyusinkyohiriyuDto.jigyocd)}s_in", ListToCommaStr(jigyocds)),    //事業コード
                new($"{nameof(tt_shjyusinkyohiriyuDto.kyohiriyu)}s_in", ListToCommaStr(kyohiriyus)) //事業コード
            };
            return paras;
        }
    }
}