// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
//             レスポンスインターフェース
// 作成日　　: 2024.05.27
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK01301G
{
    /// <summary>
    /// ベース初期化処理（入り口によって異なる項目の初期化）
    /// </summary>
    public class InitBaseResponse : DaResponseBase
    {
        public bool nendoflg { get; set; }                                      //年度表示フラグ
    }
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitListResponse : InitBaseResponse
    {
        public List<DaSelectorModel> selectorlist { get; set; }                 //ドロップダウンリスト(抽出対象)
    }
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public int totalpagecount2 { get; set; }                                //ページ数（二番目の一覧）
        public int totalrowcount2 { get; set; }                                 //総件数（二番目の一覧）
        public List<RowVM> kekkalist1 { get; set; }                             //抽出情報一覧（全体抽出）
        public List<RowVM> kekkalist2 { get; set; }                             //抽出情報一覧（個別抽出）
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : InitBaseResponse
    {
        public List<FreeItemTyusyutuVM> jokenlist1 { get; set; }                //フリー項目情報(検索条件)
        public List<FreeItemTyusyutuVM> jokenlist2 { get; set; }                //フリー項目情報(検索条件以外)
        public TyusyutuMainVM tyusyutuinfo { get; set; }                        //抽出情報
        public AtenaVM? atenainfo { get; set; }                                 //宛名情報（個別抽出の場合）
        public bool hakkenhyojiflg { get; set; }                                //発券情報表示フラグ（個別抽出の場合）
        public List<HakkenVM> hakkeninfo { get; set; }                          //発券情報（個別抽出かつ発券情報表示の場合）
    }
    /// <summary>
    /// 抽出処理
    /// </summary>
    public class ExtractResponse : DaResponseBase
    {
        public long? tyusyutuseq { get; set; }                                   //抽出シーケンス 
    }

}