// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ホーム
//             レスポンスインターフェース
// 作成日　　: 2024.07.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00301G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public int nendo { get; set; }                           //システム年度
        public int atenanolen { get; set; }                      //宛名番号長さ
        public int kikancdlen { get; set; }                      //医療機関コード長さ
        public List<DaSelectorModel> selectorlist { get; set; }  //処理区分一覧
        public List<InfoVM> kekkalist1 { get; set; }             //お知らせリスト
        public List<GaibulogVM> kekkalist2 { get; set; }         //外部連携処理結果履歴リスト
    }

    /// <summary>
    /// 検索処理(お知らせ)
    /// </summary>
    public class SearchInfoResponse : DaResponseBase
    {
        public List<InfoVM> kekkalist { get; set; }              //お知らせリスト
    }

    /// <summary>
    /// 検索処理(連携処理)
    /// </summary>
    public class SearchLogResponse : DaResponseBase
    {
        public List<GaibulogVM> kekkalist { get; set; }          //外部連携処理結果履歴リスト
    }

    /// <summary>
    /// メニュー取得処理
    /// </summary>
    public class GetMenuResponse : DaResponseBase
    {
        public List<MenuModel> menulist { get; set; }            //メニューリスト
        public List<ProgramModel> programlist { get; set; }      //プログラムリスト
    }
}