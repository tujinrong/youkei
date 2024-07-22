// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ロジック共通仕様処理
//             リクエストインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.Common
{
    /// <summary>
    /// 検索処理(一覧画面：受診者を探す場合)
    /// </summary>
    public class PersonSearchRequest : CmSearchRequestBase
    {
        public string? atenano { get; set; }                            //宛名番号
        public string? name { get; set; }                               //氏名
        public string? kname { get; set; }                              //カナ氏名
        public string? bymd { get; set; }                               //生年月日
        public override string? personalno { get; set; }                //個人番号
        public List<AWAF00703D.SearchVM>? syosailist { get; set; }      //詳細条件(検索)
    }
}