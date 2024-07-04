// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: お知らせ
//             リクエストインターフェース
// 作成日　　: 2023.01.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00302D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public Enum名称区分 kbn { get; set; }   //名称区分(重要度)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public Enum表示区分 showkbn { get; set; }   //表示区分
        public Enum未読区分 readkbn { get; set; }   //未読区分
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public List<InfoVM> addlist { get; set; }   //新規お知らせリスト
        public List<UpdVM> updlist { get; set; }    //更新お知らせリスト
        public List<LockVM> locklist { get; set; }  //排他チェック用リスト(編集用)
        public List<LockVM> locklist2 { get; set; } //排他チェック用リスト(既読用)
    }
}