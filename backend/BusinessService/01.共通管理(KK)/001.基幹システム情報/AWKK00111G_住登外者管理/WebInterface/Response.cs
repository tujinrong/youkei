// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者管理
//             レスポンスインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00111G
{
    /// <summary>
    /// 初期化処理(検索条件)
    /// </summary>
    public class InitListResponse : DaResponseBase
    {
        public bool fusyoflg { get; set; } = true;                      //生年月日不詳フラグフラグ
        public List<DaSelectorModel> selectorlist1 { get; set; }        //ドロップダウンリスト(登録者)
        public List<DaSelectorModel> selectorlist2 { get; set; }        //ドロップダウンリスト(更新者)
        public List<DaSelectorModel> selectorlist3 { get; set; }        //ドロップダウンリスト(削除フラグ)
        public List<DaSelectorModel> selectorlist4 { get; set; }        //ドロップダウンリスト(業務ID)
        public List<DaSelectorModel> selectorlist5 { get; set; }        //ドロップダウンリスト(独自施策システム等ID)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<RowVM> kekkalist { get; set; }                      //結果リスト(住登外者一覧)
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public InitDetailVM initdetail { get; set; }                    //住登外者詳細_基本情報等タブリスト初期化
    }

    /// <summary>
    /// 世帯検索処理(詳細画面)
    /// </summary>
    public class SearchSetaiResponse : DaResponseBase
    {
        public SetaiInfoVM setaiInfo { get; set; }                      //世帯情報（詳細画面）
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailResponse : DaResponseBase
    {
        public int rirekitotal { get; set; }                            //総履歴数
        public int rirekinum { get; set; }                              //履歴No.
        public BaseInfoVM baseinfo { get; set; }                        //住登外者詳細_ヘッダー部情報
        public MainInfoVM maininfo { get; set; }                        //住登外者詳細_基本情報等タブメイン
    }

    /// <summary>
    /// 保存/削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase
    {
        public string atenano { get; set; }                             //宛名番号
        public int rirekino { get; set; }                               //履歴番号
        //確認メッセージ（C011001）を表示する用
        public List<SeitaiDictVM> seitaidictlist { get; set; }          //同一世帯員情報一覧（宛名番号、氏名）
    }

    /// <summary>
    /// 自動入力処理(詳細画面--郵便情報)
    /// 郵便番号から住所関連項目を自動設定する
    /// </summary>
    public class AutoSetResponse : DaResponseBase
    {
        public YubinInfoVM yubininfo { get; set; }                      //住登外者詳細_基本情報（郵便情報）
    }

    /// <summary>
    /// 検索処理(個人番号)
    /// </summary>
    public class SearchPersonalResponse : DaResponseBase
    {
        public string? personalno { get; set; }                         //個人番号
    }

    /// <summary>
    /// 検索処理(自動付番)
    /// </summary>
    public class SearchAutoSaibanResponse : DaResponseBase
    {
        public string? seqno { get; set; }                              //世帯番号および宛名番号
    }
}
