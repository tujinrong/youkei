// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ホーム
// 　　　　　　画面項目からDB項目に変換
// 作成日　　: 2024.07.22
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00301G
{
    public class Converter : CmConerterBase
    {
        /// <summary>
        /// 検索パラメータ取得(お知らせ)
        /// </summary>
        public static List<AiKeyValue> GetParameters(string userid, Enum未読区分 readkbn)
        {
            var paras = new List<AiKeyValue>
            {
                new($"{nameof(SearchInfoRequest.userid)}_in", userid),       //ユーザーID
                new($"{nameof(SearchInfoRequest.readkbn)}_in", (int)readkbn) //未読区分
            };
            return paras;
        }
    }
}