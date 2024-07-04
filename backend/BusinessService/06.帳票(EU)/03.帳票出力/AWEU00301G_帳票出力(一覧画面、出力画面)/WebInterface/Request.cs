// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00301G
{
    /// <summary>
    /// 一覧画面検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string? gyomukbn { get; set; }   //業務区分
        public string? rptgroupid { get; set; } //帳票グループID
        public string? rptnm { get; set; }      //帳票名
    }

    /// <summary>
    /// 出力画面初期化処理
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public string rptid { get; set; } //帳票ID
    }

    /// <summary>
    /// 様式情報の取得処理
    /// </summary>
    public class YosikiInfoRequest : DaRequestBase
    {
        public string rptid { get; set; }                                   //帳票ID
        public string tyusyututaisyocd { get; set; }                        //抽出対象コード
        public string? tyusyutukbn { get; set; }                            //帳票出力区分(抽出パネルのとき設定)
        public string? himozukevalue { get; set; }                          //様式紐付け値(抽出パネルのとき未設定)
        public int? himozukejyokenid { get; set; }                          //様式紐付け条件ID(抽出パネルのとき未設定)
    }

    /// <summary>
    /// 出力画面検索処理
    /// </summary>
    public class DetailSearchRequest : CmSearchRequestBase
    {
        public string rptid { get; set; } //帳票ID
        public long workseq { get; set; } //ワークシーケンス
    }

    /// <summary>
    /// 抽出内容が変更時処理
    /// </summary>
    public class ChangeTyusyutunaiyoRequest : DaRequestBase
    {
        public string tyusyutunaiyo { get; set; }   //抽出内容
    }

    /// <summary>
    /// 参照元項目入力後参照先項目の選択リストを取得する処理
    /// </summary>
    public class GetTargetItemValueRequest : DaRequestBase
    {
        public string rptid { get; set; }           //帳票ID
        public string jyokenlabel { get; set; }     //参照元項目ラベル
        public string val { get; set; }             //参照元項目値
        public string targetitemseq { get; set; }   //参照先項目ID(複数? ,)
    }
}