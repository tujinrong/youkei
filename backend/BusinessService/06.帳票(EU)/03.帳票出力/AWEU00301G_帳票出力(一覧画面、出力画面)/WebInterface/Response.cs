// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(一覧画面、出力画面)
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00301G
{
    /// <summary>
    /// 初期化処理(一覧画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; }    //ドロップダウンリスト(業務)
        public List<DaSelectorKeyModel> selectorlist2 { get; set; } //ドロップダウンリスト(帳票グループ)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchResponse : CmSearchResponseBase
    {
        public List<ReportVM> kekkalist { get; set; } //帳票リスト
    }

    /// <summary>
    /// 初期化処理(出力画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public string? rptbiko { get; set; }                                //帳票説明
        public bool atenaflg { get; set; }                                  //宛名フラグ
        public string? yosikihimonm { get; set; }                           //様式紐付け名
        public List<KensakuJyokenInitVM> kensakujyokenlist1 { get; set; }   //検索条件
        public List<KensakuJyokenInitVM> kensakujyokenlist2 { get; set; }   //検索条件以外
        public List<YosikiInfo> selectorlist { get; set; }                  //ドロップダウンリスト(出力様式)
        public List<DetailJyokenInitVM>? detailjyokenlist { get; set; }     //詳細条件リスト

        public bool tyusyutupanelflg { get; set; }                          //抽出パネル表示フラグ
        public List<MyDaSelectorModel> tyusyututaisyolist { get; set; }     //ドロップダウンリスト(抽出対象:抽出対象コード,抽出対象名,通知サイクル,抽出データ詳細区分)
        public List<DaSelectorKeyModel> tyusyutunaiyolist { get; set; }     //ドロップダウンリスト(抽出内容:抽出シーケンス,抽出内容,抽出対象コード_年度)
        public List<MyDaSelectorModel> tyusyutukbnlist { get; set; }        //ドロップダウンリスト(帳票出力区分:区分コード,区分名称,様式種別,抽出データ詳細区分)
    }


    /// <summary>
    /// 様式情報の取得処理
    /// </summary>
    public class YosikiInfoResponse : DaResponseBase
    {
        public List<YosikiInfo> selectorlist { get; set; }          //ドロップダウンリスト(出力様式)
    }

    /// <summary>
    /// 抽出内容が変更時処理
    /// </summary>
    public class ChangeTyusyutunaiyoResponse : DaResponseBase
    {
        public string atenanocnt { get; set; }  //抽出人数
        public string regdttm { get; set; }     //登録日時
    }

    /// <summary>
    /// 検索処理(出力画面)
    /// </summary>
    public class SearchDetailResponse : CmSearchResponseBase
    {
        public List<AtenaVM> kekkalist { get; set; } //宛名リスト
    }

    /// <summary>
    /// 様式情報の取得
    /// </summary>
    public class YosikiInfo : DaResponseBase
    {
        public string yosikiid { get; set; }                      //様式ID
        public string yosikinm { get; set; }                      //様式名
        public Enum様式種別 yosikisyubetu { get; set; }           //様式種別
        public bool updateflg { get; set; }                       //更新フラグ
        public bool hakoflg { get; set; }                         //帳票発行履歴管理フラグ
        public bool pdfflg { get; set; }                          //PDF出力フラグ
        public bool excelflg { get; set; }                        //EXCEL出力フラグ
        public bool otherflg { get; set; }                        //その他出力フラグ
        public bool tutisyooutflg { get; set; }                   //通知書出力フラグ
        public string? rirekiupdkbn { get; set; }                 //発送履歴テーブル更新区分
    }

    /// <summary>
    /// 参照元項目入力後参照先項目の選択リストを取得する処理
    /// </summary>
    public class GetTargetItemValueResponse : DaResponseBase
    {
        public List<TargetItemValueVM> targetItemValueList { get; set; } //取得先項目の値リスト
    }
}