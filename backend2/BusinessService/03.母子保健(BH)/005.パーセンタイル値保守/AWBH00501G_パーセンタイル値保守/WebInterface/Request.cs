// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: パーセンタイル値保守
//             リクエストインターフェース
// 作成日　　: 2024.06.01
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00501G
{
    /// <summary>
    /// パーセンタイル値保守画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string buicd { get; set; }                       //部位コード
        public string sex { get; set; }                         //性別    
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string jsonstr { get; set; }                     //リクエスト文字列（JSON形式）
        public List<PasentairuListVM> kekkalist { get; set; }   //結果リスト
    }
}