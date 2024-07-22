// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 会場保守
//             リクエストインターフェース
// 作成日　　: 2023.11.02
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00202G
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string kaijocd { get; set; }    //会場コード
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string kaijocd { get; set; }    //会場コード
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public MainInfoVM maininfo { get; set; }            //会場情報メイン
        public List<TikuOneSaveVM> tikulist { get; set; }   //地区リスト
        public Enum編集区分 editkbn { get; set; }           //編集区分
    }
}
