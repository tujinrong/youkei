// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 送付先管理
//             レスポンスインターフェース
// 作成日　　: 2023.11.14
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00608D
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : CmSearchResponseBase
    {
        public PersonHeaderVM headerinfo { get; set; }               //住民情報
        public List<RowVM> kekkalist { get; set; }                   //結果リスト(送付先一覧)
        public bool sinkiflg { get; set; }                          //利用目的新規用フラグ
        public bool exceloutflg { get; set; }                        //EXCEL出力フラグ
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel> riyomokutekiList { get; set; }     //ドロップダウンリスト(利用目的)
        public List<DaSelectorModel> torokujiyuList { get; set; }       //ドロップダウンリスト(登録事由)
        public List<DaSelectorModel> sityosonList { get; set; }         //ドロップダウンリスト(市区町村)
        public List<DaSelectorKeyModel> tyoazaList { get; set; }        //ドロップダウンリスト(町字)
        public bool showflg { get; set; }                               //表示フラグ(登録支所)
        public string regsisyo { get; set; }                            //登録支所
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public MainInfoVM mainInfo { get; set; }                    //会場情報メイン
    }

    /// <summary>
    /// 自動入力処理(詳細画面)
    /// 郵便番号から項目「市区町村、町字」を自動設定する
    /// </summary>
    public class AutoSetResponse : SearchDetailResponse
    {
      public AutoSetVM autoset { get; set; }
    }
}
