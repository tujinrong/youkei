// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: メモ情報
//             リクエストインターフェース
// 作成日　　: 2023.03.02
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00601D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public Enum名称区分 kbn1 { get; set; }  //名称区分(重要度)
        public Enum名称区分 kbn2 { get; set; }  //名称区分(登録事業)
        public Enum名称区分 kbn3 { get; set; }  //名称区分(登録支所)
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード)
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public List<AddVM> addlist { get; set; }    //新規メモリスト
        public List<UpdVM> updlist { get; set; }    //更新メモリスト
        public List<LockVM> locklist { get; set; }  //排他チェック用リスト
    }
}