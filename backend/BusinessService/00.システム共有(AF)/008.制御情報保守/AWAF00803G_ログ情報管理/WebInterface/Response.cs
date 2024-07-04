// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ログ情報管理
//             レスポンスインターフェース
// 作成日　　: 2023.09.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00803G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(ログ区分)
        public List<DaSelectorModel> selectorlist2 { get; set; }    //ドロップダウンリスト(処理結果)
        public List<DaSelectorModel> selectorlist3 { get; set; }    //ドロップダウンリスト(機能)
        public List<DaSelectorKeyModel> selectorlist4 { get; set; } //ドロップダウンリスト(処理)
        public List<DaSelectorModel> selectorlist5 { get; set; }    //ドロップダウンリスト(操作者)
        public bool csvoutflg { get; set; }                         //CSV出力フラグ
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }  //ログ情報一覧
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : CmSearchResponseBase
    {
        public HeaderVM headerinfo { get; set; }    //ログ基本情報
        public bool existflg1 { get; set; }         //通信ログ操作状況
        public bool existflg2 { get; set; }         //バッチログ操作状況
        public bool existflg3 { get; set; }         //外部連携ログ操作状況
        public bool existflg4 { get; set; }         //DB操作ログ操作状況
        public bool existflg5 { get; set; }         //項目値変更ログ操作状況
        public bool existflg6 { get; set; }         //宛名番号ログ操作状況
    }

    /// <summary>
    /// 初期化処理(項目値変更情報)
    /// </summary>
    public class InitColumDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(変更テーブル)
        public List<DaSelectorKeyModel> selectorlist2 { get; set; } //ドロップダウンリスト(変更項目)
        public List<DaSelectorModel> selectorlist3 { get; set; }    //ドロップダウンリスト(変更区分)
    }

    /// <summary>
    /// 検索処理(通信ログ情報)
    /// </summary>
    public class SearchTusinDetailResponse : CmSearchResponseBase
    {
        public List<TusinRowVM> kekkalist { get; set; }  //通信ログ情報一覧
    }

    /// <summary>
    /// 検索処理(バッチログ情報)
    /// </summary>
    public class SearchBatchDetailResponse : CmSearchResponseBase
    {
        public List<BatchRowVM> kekkalist { get; set; }  //バッチログ情報一覧
    }

    /// <summary>
    /// 検索処理(連携ログ情報)
    /// </summary>
    public class SearchGaibuDetailResponse : CmSearchResponseBase
    {
        public List<GaibuRowVM> kekkalist { get; set; }  //連携ログ情報一覧
    }

    /// <summary>
    /// 検索処理(DB操作ログ情報)
    /// </summary>
    public class SearchDBDetailResponse : CmSearchResponseBase
    {
        public List<DBRowVM> kekkalist { get; set; }  //DB操作ログ情報一覧
    }

    /// <summary>
    /// 検索処理(項目値変更情報)
    /// </summary>
    public class SearchColumnDetailResponse : CmSearchResponseBase
    {
        public List<ColumnRowVM> kekkalist { get; set; }  //項目値変更情報一覧
    }

    /// <summary>
    /// 検索処理(宛名番号ログ情報)
    /// </summary>
    public class SearchAtenaDetailResponse : CmSearchResponseBase
    {
        public List<AtenaRowVM> kekkalist { get; set; }  //宛名番号ログ情報一覧
    }
}