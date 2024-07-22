// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 健（検）診対象者設定
//             リクエストインターフェース
// 作成日　　: 2024.01.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00301G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public int nendo { get; set; }  //年度
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : SearchRequest
    {
        public List<RowVM> kekkalist { get; set; }  //情報一覧
        public List<LockVM> locklist { get; set; }  //排他チェック用リスト
    }
}