// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導管理
//             リクエストインターフェース
// 作成日　　: 2023.12.13
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00301G
{
    /// <summary>
    /// 1.住民一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest { }

    /// <summary>
    /// 2.3.住民詳細画面検索処理(結果一覧のリンクをクリック)
    /// </summary>
    public class SearchDetailRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
    }

    /// <summary>
    /// 4.世帯詳細画面検索処理(世帯一覧のリンクをクリック)
    /// </summary>
    public class SearchSetaiDetailRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string hokensidokbn { get; set; } = "1";     //保健指導区分
    }

    /// <summary>
    /// 5.世帯詳細画面検索処理（個人一覧のタブを選択）
    /// </summary>
    public class SearchShidouDetailRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string hokensidokbn { get; set; }            //保健指導区分
        public string gyomukbn { get; set; }                //業務区分
        public string jigyocd { get; set; }                 //事業コード

    }

    /// <summary>
    /// 6.個人詳細画面検索処理（個人一覧のリンクをクリック）
    /// 7.個人詳細画面検索処理（個人詳細のタブを選択）
    /// </summary>
    public class SearchPersonDetailRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string hokensidokbn { get; set; }            //保健指導区分
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; }                      //枝番
        public string mosikomikekkakbn { get; set; } = "1"; //申込結果区分
    }

    /// <summary>
    /// 8.保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public MainInfoVM maininfo { get; set; }            //個人詳細画面_申込情報／結果情報タブメイン
    }

    /// <summary>
    /// 9.削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string hokensidokbn { get; set; }            //保健指導区分
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; }                      //枝番

    }

    /// <summary>
    /// 10.フリー項目絞込処理（「地域保健集計区分」ドロップダウンリストを選択）
    /// </summary>
    public class SearchFreeItemRequest : SearchPersonDetailRequest
    {
        public string groupid { get; set; }                 //グループ1	
        public string groupid2 { get; set; }                //グループ2	
        public bool hissuflg { get; set; }                  //必須フラグ	
        public string syukeikbn { get; set; }               //地域保健集計区分	

    }

    /// <summary>
    /// 11.実施日時点年齢を取得
    /// </summary>
    public class GetAgeRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public string yoteiymd { get; set; }                //実施予定日
    }
}