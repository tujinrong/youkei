// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 汎用情報保守
//             リクエストインターフェース
// 作成日　　: 2022.12.21
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00801G
{
    /// <summary>
    /// 初期化(メインコード)
    /// </summary>
    public class InitMainCodeRequest : DaRequestBase
    {
        public Enum名称区分 kbn { get; set; }   //名称区分(メインコード)
    }

    /// <summary>
    /// 初期化(サブコード)
    /// </summary>
    public class InitSubCodeRequest : InitMainCodeRequest
    {
        public string hanyomaincd { get; set; } //汎用メインコード
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string hanyomaincd { get; set; } //汎用メインコード
        public string hanyosubcd { get; set; }  //汎用サブコード
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : SearchRequest
    {
        public List<LockVM> locklist { get; set; }  //排他キーリスト
        public List<HanyoVM> savelist { get; set; } //汎用データリスト
    }

    /// <summary>
    /// サブコード情報登録(保存処理)
    /// </summary>
    public class SaveSubCodeInfoRequest : SearchRequest
    {
        public SubCodeInfoVM subcdInfoVM { get; set; }  //サブコード情報
        public Enum編集区分 editkbn { get; set; }       //編集区分
    }
}