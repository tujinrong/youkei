// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力履歴画面
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00305D
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索処理
        /// </summary>
        public static List<AiKeyValue> GetParameters(SearchRequest req)
        {
            return new List<AiKeyValue>
            {
                new($"{nameof(SearchRequest.rptid)}_in", req.rptid),                                                  //帳票ID
                new($"{nameof(SearchRequest.yosikiid)}_in", req.yosikiid),                                            //様式ID
                new($"{nameof(tt_eurirekiDto.jyotaikbn)}_in", DaConvertUtil.EnumToStr(Enum履歴出力状態区分.処理完了)) //状態区分
            };
        }
    }
}