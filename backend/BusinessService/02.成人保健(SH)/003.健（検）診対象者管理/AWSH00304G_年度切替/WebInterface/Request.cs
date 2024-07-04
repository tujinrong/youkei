// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 年度切替
//             リクエストインターフェース
// 作成日　　: 2024.01.31
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00304G
{
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : AWSH00301G.SearchRequest
    {
        public List<AWSH00301G.RowVM> kekkalist { get; set; }   //情報一覧
        public List<AWSH00301G.LockVM> locklist { get; set; }   //排他チェック用リスト
        public string hikitugikbn { get; set; }                 //引継ぎ区分コード
    }
}