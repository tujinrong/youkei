// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//             リクエストインターフェース
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWBH00401G
{
    /// <summary>
    /// 1.乳幼児一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest
    {
        public string bosikbn { get; set; } = AWBH00301G.母子種類._2;   //母子種類
    }

    /// <summary>
    /// 2.3.乳幼児詳細画面検索処理(結果一覧のリンクをクリック)
    /// </summary>
    public class SearchDetailRequest : CmSearchRequestBase
    {
        public string bosikbn { get; set; } = AWBH00301G.母子種類._2;   //母子種類
        public string atenano { get; set; }                             //宛名番号
    }

    /// <summary>
    /// 4.乳幼児フリー検索処理(メニュー／タブ／回数をクリック)
    /// 4.新規ボタンを押下
    /// </summary>
    public class SearchSyosaiRequest : SearchDetailRequest
    {
        public string bhsyosaimenyucd { get; set; }                     //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; } = "1";                //母子詳細タブコード
        public int kaisu { get; set; } = 0;                             //回数
    }

    /// <summary>
    /// 5.父母親情報検索処理
    /// </summary>
    public class SearchAtenaInfoRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                             //宛名番号
    }

    /// <summary>
    /// キー項目
    /// </summary>
    public class KeyRequest : CmSaveRequestBase
    {
        public bool delflg { get; set; }                                //削除フラグ　True：全ての詳細内容削除、False：選択中の履歷のみ削除
        public string bosikbn { get; set; } = AWBH00301G.母子種類._2;   //母子種類
        public string bhsyosaimenyucd { get; set; }                     //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; }                       //母子詳細タブコード
        public string atenano { get; set; }                             //宛名番号
        public int kaisu { get; set; } = 0;                             //回数
    }

    /// <summary>
    /// 6.保存処理
    /// </summary>
    public class SaveRequest : KeyRequest
    {
        public List<FreeItemInfoVM> fixiteminfo { get; set; }           //固定項目情報
        public List<FreeItemInfoVM> freeiteminfo { get; set; }          //フリー項目情報
    }

    /// <summary>
    /// 6.保存処理（JSON文字列）
    /// </summary>
    public class SaveAllRequest : CmSaveRequestBase
    {
        public List<SaveRequest> saveinfo { get; set; }                 //画面情報（全て業務）
    }

    /// <summary>
    /// 7.削除処理
    /// </summary>
    public class DeleteRequest : KeyRequest { }

}