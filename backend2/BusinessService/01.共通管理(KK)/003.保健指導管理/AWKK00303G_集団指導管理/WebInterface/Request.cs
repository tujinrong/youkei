// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 集団指導管理
//             リクエストインターフェース
// 作成日　　: 2023.12.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00303G
{
    /// <summary>
    /// 2.集団指導一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string gyomu { get; set; }                   //業務
        public string jigyo { get; set; }                   //事業
        public string tantosya { get; set; }                //予定者/実施者 
        public string jissibasyo { get; set; }              //実施場所 
        public string yoteiymdf { get; set; }               //予定日(From) 
        public string yoteiymdt { get; set; }               //予定日(To) 
        public string course { get; set; }                  //コース 
        public string jissiymdf { get; set; }               //実施日(From) 
        public string jissiymdt { get; set; }               //実施日(To) 
        public string coursenm { get; set; }                //コース名 
        public string atenano { get; set; }                 //宛名番号
    }

    /// <summary>
    /// 3.個別入力画面検索処理(集団指導管理の検索結果一覧の行をクリックした場合)
    /// 3.新規ボタンを押下場合
    /// 4.指導情報検索処理テスト用（個別入力画面のタブを選択（申込／結果））
    /// </summary>
    public class SearchDetailRequest : CmSearchRequestBase
    {
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; } = 0;                 //枝番
        public string mosikomikekkakbn { get; set; } = "1"; //申込結果区分
    }

    /// <summary>
    /// 5.参加者情報検索処理テスト用（個別入力画面のタブを選択場合（参加者のみ））
    /// </summary>
    public class SearchSankasyaListRequest : SearchDetailRequest
    {
        public string jigyocd { get; set; } = string.Empty; //事業コード
    }

    /// <summary>
    /// 6.保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public MainInfoVM maininfo { get; set; }            //個別入力画面_申込情報／結果情報タブメイン
    }

    /// <summary>
    /// 7.削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; }                      //枝番
    }

    /// <summary>
    /// 8参加者詳細画面検索処理（参加者情報一覧のリンクをクリック）
    /// 9参加者詳細情報検索処理（タブ切り替え）
    /// </summary>
    public class SearchSankasyaDetailRequest : SearchDetailRequest
    {
        public string atenano { get; set; }                 //宛名番号
    }

    /// <summary>
    /// 10.参加者保存処理
    /// </summary>
    public class SaveSankasyaRequest : CmSaveRequestBase
    {
        public SankasyaMainInfoVM maininfo { get; set; }    //参加者詳細画面_申込情報／結果情報タブメイン
    }

    /// <summary>
    /// 11.参加者削除処理
    /// </summary>
    public class DeleteSankasyaRequest : DeleteRequest
    {
        public string atenano { get; set; }                 //宛名番号
    }
}