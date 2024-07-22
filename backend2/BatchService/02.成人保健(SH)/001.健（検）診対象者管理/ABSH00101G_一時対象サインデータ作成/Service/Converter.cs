// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 一時対象サインデータ作成
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.02.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.BatchService.ABSH00101G
{
    public class Converter
    {
        /// <summary>
        /// パラメータ取得
        /// </summary>
        public static List<AiKeyValue> GetParameters(int nendo)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(tt_shjyusinkyohiriyuDto.nendo)}_in", nendo)   //年度
            };
            return paras;
        }
    }
}