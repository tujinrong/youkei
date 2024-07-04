// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 妊産婦情報管理
//             リクエストインターフェース
// 作成日　　: 2024.02.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWBH00302D;

namespace BCC.Affect.Service.AWBH00301G
{
    //Todo：母子種類とボタン文字色は一時利用、後でDataAccess--Generated--DaCodeConstに移行する予定
    ///<summary>
    ///母子種類
    ///</summary>
    public class 母子種類
    {
        ///<summary>妊産婦</summary>
        public const string _1 = "1";
        ///<summary>乳幼児</summary>
        public const string _2 = "2";
    }

    /// <summary>
    /// 1.妊産婦一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest
    {
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string bhtetyono { get; set; }                   //母子手帳番号    
    }

    /// <summary>
    /// 2.3.妊産婦詳細画面検索処理(結果一覧のリンクをクリック)
    /// </summary>
    public class SearchDetailRequest : CmSearchRequestBase
    {
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string atenano { get; set; }                     //宛名番号
        public long torokuno { get; set; }                      //登録番号
    }

    /// <summary>
    /// 4.妊産婦フリー検索処理(メニュー／タブ／回数をクリック)
    /// 4.新規ボタンを押下
    /// </summary>
    public class SearchSyosaiRequest : SearchDetailRequest
    {
        public string bhsyosaimenyucd { get; set; }             //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; } = "1";        //母子詳細タブコード
        public int torokunorenban { get; set; } = 0;            //登録番号連番（多胎管理でない場合は0）
        public int edano { get; set; } = 0;                     //枝番（履歴回数管理でない場合は0）
        public int kaisu { get; set; } = 0;                     //回数（履歴回数管理でない場合は0）
    }

    /// <summary>
    /// 5.医療機関検索処理
    /// </summary>
    public class SearchKikanNMRequest : CmSearchRequestBase
    {
        public string kikancd { get; set; }                     //医療機関コード
    }

    /// <summary>
    /// 6.医師検索処理
    /// </summary>
    public class SearchIshiNMRequest : CmSearchRequestBase
    {
        public string staffid { get; set; }                     //医師コード
    }

    /// <summary>
    /// キー項目
    /// </summary>
    public class KeyRequest : CmSaveRequestBase
    {
        public bool delflg { get; set; }                        //削除フラグ　True：全ての詳細内容削除、False：選択中の履歷のみ削除
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string bhsyosaimenyucd { get; set; }             //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; }               //母子詳細タブコード
        public string atenano { get; set; }                     //宛名番号
        public long torokuno { get; set; } = 0;                 //登録番号
        public int torokunorenban { get; set; } = 0;            //登録番号連番
        public int edano { get; set; } = 0;                     //枝番
        public int kaisu { get; set; } = 0;                     //回数
    }

    /// <summary>
    /// 7.保存処理
    /// </summary>
    public class SaveRequest : KeyRequest
    {
        public List<JyoseiListInfoVM> jyoseilistinfo { get; set; }  //費用助成一覧
        public List<FreeItemInfoVM> fixiteminfo { get; set; }   //固定項目情報
        public List<FreeItemInfoVM> freeiteminfo { get; set; }  //フリー項目情報（業務毎）
    }

    /// <summary>
    /// 7.保存処理（JSON文字列）
    /// </summary>
    public class SaveAllRequest : CmSaveRequestBase
    {
        public List<SaveRequest> saveinfo { get; set; }         //画面情報（全て業務）
    }

    /// <summary>
    /// 8.削除処理
    /// </summary>
    public class DeleteRequest : KeyRequest { }
}