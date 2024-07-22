// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 汎用情報保守
//             レスポンスインターフェース
// 作成日　　: 2024.07.28
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00801G
{
    /// <summary>
    /// メインコード初期化処理
    /// </summary>
    public class InitMainCodeResponse : InitSubCodeResponse
    {
        public bool exceloutflg { get; set; } //EXCEL出力フラグ
    }

    /// <summary>
    /// サブコード初期化処理
    /// </summary>
    public class InitSubCodeResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; }   //ドロップダウンリスト(メインコード/サブコード)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public string biko { get; set; }                //備考
        public int? userryoikikaisicd { get; set; }     //ユーザ領域開始コード
        public int? maxHanyocd { get; set; }            //最大汎用コード
        public int? keta { get; set; }                  //桁数
        public bool iflg { get; set; }                  //INSERT可能フラグ
        public bool uflg { get; set; }                  //UPDATE可能フラグ
        public bool dflg { get; set; }                  //DELETE可能フラグ
        public List<HanyoVM> kekkalist { get; set; }    //汎用データリスト
        public List<LockVM> locklist { get; set; }      //汎用データリスト(ロック用)
    }

    /// <summary>
    /// サブコード情報登録(初期処理)
    /// </summary>
    public class InitSubCodeInfoResponse : DaResponseBase
    {
        public SubCodeInfoVM? subcdInfoVM { get; set; }         //サブコード情報
        public List<DaSelectorModel> maincdlist { get; set; }   //汎用メインコードリスト
    }
}