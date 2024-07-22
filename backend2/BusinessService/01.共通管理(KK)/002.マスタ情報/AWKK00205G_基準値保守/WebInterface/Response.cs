// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基準値保守
//             レスポンスインターフェース
// 作成日　　: 2024.07.16
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00205G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }     //ドロップダウンリスト(業務)
        public List<DaSelectorModel> selectorlist2 { get; set; }     //ドロップダウンリスト(事業)：成人
        public List<DaSelectorModel> selectorlist3 { get; set; }     //ドロップダウンリスト(事業)：母子
        public List<DaSelectorModel> selectorlist4 { get; set; }     //ドロップダウンリスト(事業)：予防
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                  //結果リスト(基準値保守一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : GetFreeMstInfoResponse
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(項目名称)　新規の場合のみ
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(性別)
        public string? itemnm { get; set; }                         //項目名称 編集の場合のみ
        public string gyomukbnnm { get; set; }                      //業務（名称）
        public string kijunjigyonm { get; set; }                    //事業（名称）
        public SaveMainVM saveinfo { get; set; }                    //基準値保守情報(詳細画面)
    }


    /// <summary>
    /// 項目名称変更処理（詳細画面）
    /// </summary>
    public class GetFreeMstInfoResponse : DaResponseBase
    {
        public FreeMstInfoVM freemstinfo { get; set; }      　　　　//項目名称変更情報
    }
}