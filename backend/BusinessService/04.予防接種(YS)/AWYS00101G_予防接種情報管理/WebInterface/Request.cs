// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 予防接種情報管理
//             リクエストインターフェース
// 作成日　　: 2024.06.18
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00301G;
using NPOI.SS.Formula.Functions;

namespace BCC.Affect.Service.AWYS00101G
{
    //************************************************************** 検索処理 **************************************************************
    /// <summary>
    /// 検索処理(世帯一覧)・初期化処理(詳細画面)
    /// </summary>
    public class CommonRequest : DaRequestBase
    {
        public string atenano { get; set; }                             //宛名番号
    }
    /// <summary>
    /// 予防接種情報一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest{ }

    /// <summary>
    /// 詳細画面_接種情報（生涯1回）画面検索処理(結果一覧のリンクをクリック)
    /// </summary>
    public class SearchDetailRequest : SearchDetailOneRequest{ }

    /// <summary>
    /// 詳細画面_接種情報（生涯1回）タブ検索処理(タブ切替／接種種類フィルター区分／履歴表示切り替え)
    /// </summary>
    public class SearchDetailOneRequest : SearchDetailRikanRequest
    {
        public bool rirekihyoji { get; set; } = true;                   //履歴表示フラグ　true：全枝番の情報を表示、false：最大枝番の情報を表示
    }

    /// <summary>
    /// 詳細画面_接種情報（複数回）タブ検索処理(タブ切替／接種種類フィルター区分)
    /// </summary>
    public class SearchDetailMultiRequest : SearchDetailRikanRequest { }

    /// <summary>
    /// 詳細画面_罹患情報タブ検索処理(タブ切替)
    /// </summary>
    public class SearchDetailRikanRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }                             //宛名番号
    }

    /// <summary>
    /// 詳細画面_接種依頼情報タブ検索処理(タブ切替)
    /// </summary>
    public class SearchDetailIraiRequest : SearchDetailRikanRequest { }

    /// <summary>
    /// 詳細画面_その他情報タブ検索処理(タブ切替)
    /// </summary>
    public class SearchDetailOtherRequest : SearchDetailRikanRequest { }

    /// <summary>
    /// 接種情報詳細画面検索処理
    /// </summary>
    public class SearchSessyuDetailRequest : SearchDetailRikanRequest 
    {
        public string syougaiflg { get; set; }                          //生涯フラグ（1：生涯1回、2：生涯複数回）
        public string sessyucd { get; set; }                            //接種種類コード
        public string kaisu { get; set; }                               //回数
        public int edano { get; set; }                                  //枝番
    }

    /// <summary>
    /// 接種依頼情報詳細画面検索処理
    /// </summary>
    public class SearchSessyuIraiDetailRequest : SearchDetailRikanRequest
    {
        public int edano { get; set; }                                  //枝番
    }

    /// <summary>
    /// 風疹抗体検査情報詳細画面検索処理
    /// </summary>
    public class SearchFusinDetailRequest : SearchDetailRikanRequest{ }

    //************************************************************** 保存処理 **************************************************************
    /// <summary>
    /// キー項目
    /// </summary>
    public class KeyRequest : CmSaveRequestBase
    {
        public string atenano { get; set; }                     //宛名番号
    }

    /// <summary>
    /// 接種情報詳細画面保存処理
    /// </summary>
    public class SaveSessyuRequest : KeyRequest
    {
        public FixItemSessyuBaseVM fixiteminfo { get; set; }    //固定項目情報
        public List<FreeItemInfoVM> freeiteminfo { get; set; }  //フリー項目情報
    }

    /// <summary>
    /// 罹患情報詳細画面保存処理
    /// </summary>
    public class SaveRikanRequest : KeyRequest
    {
        public List<SessyuRikanBaseVm> kekkalist { get; set; }  //罹患情報
    }

    /// <summary>
    /// 接種依頼情報詳細画面保存処理
    /// </summary>
    public class SaveSessyuIraiRequest : KeyRequest
    {
        public FixItemSessyuIraiBaseVM fixiteminfo { get; set; }//固定項目情報
        public List<FreeItemInfoVM> freeiteminfo { get; set; }  //フリー項目情報
    }

    /// <summary>
    /// その他情報詳細画面保存処理
    /// </summary>
    public class SaveOtherRequest : KeyRequest
    {
        public List<FreeItemInfoVM> freeiteminfo { get; set; }  //フリー項目情報
    }

    /// <summary>
    /// 風疹抗体検査情報詳細画面保存処理
    /// </summary>
    public class SaveFusinRequest : KeyRequest
    {
        public FixItemFusinBaseVM fixiteminfo { get; set; }     //固定項目情報
        public List<FreeItemInfoVM> freeiteminfo { get; set; }  //フリー項目情報
    }

    //************************************************************** 削除処理 **************************************************************
    /// <summary>
    /// 接種情報詳細画面削除処理
    /// </summary>
    public class DeleteSessyuRequest : DeleteSessyuIraiRequest
    {
        public string sessyucd { get; set; }                            //接種種類コード
        public string kaisu { get; set; }                               //回数
    }

    /// <summary>
    /// 接種依頼情報詳細画面削除処理
    /// </summary>
    public class DeleteSessyuIraiRequest : KeyRequest
    {
        public int edano { get; set; }                                  //枝番
    }

    /// <summary>
    /// その他情報詳細画面削除処理
    /// </summary>
    public class DeleteOtherRequest : KeyRequest { }

    /// <summary>
    /// 風疹抗体検査情報詳細画面削除処理
    /// </summary>
    public class DeleteFusinRequest : KeyRequest { }
}