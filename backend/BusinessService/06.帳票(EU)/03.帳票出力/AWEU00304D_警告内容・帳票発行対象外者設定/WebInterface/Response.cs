// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定
//          　 レスポンスインターフェース 
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00304D
{
    /// <summary>
    /// 警告内容検索処理
    /// </summary>
    public class SearchWarningsResponse : CmSearchResponseBase
    {
        public long workseq { get; set; }                       //ワークシーケンス 
        public List<WarningContentVM> kekkalist { get; set; }   //警告内容リスト
    }
}