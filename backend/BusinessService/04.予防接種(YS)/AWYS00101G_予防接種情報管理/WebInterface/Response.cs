// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 予防接種情報管理
//             レスポンスインターフェース
// 作成日　　: 2024.06.18
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWKK00301G;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWYS00101G
{
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public CommonBarHeaderBase2VM headerinfo { get; set; }          //住民情報(ヘッダー)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<JyuminListVM> kekkalist { get; set; }               //住民・住登外一覧
    }

    /// <summary>
    /// 検索処理(詳細画面：接種情報(結果一覧のリンクをクリック)
    /// </summary>
    public class SearchDetailResponse : SearchDetailOneResponse
    {
        public CommonBarHeaderBase2VM headerinfo { get; set; }          //個人一覧ヘッダー情報
    }

    /// <summary>
    /// 検索処理(詳細画面：接種情報(生涯1回)タブ)
    /// </summary>
    public class SearchDetailOneResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> sessyufilterkbnlist { get; set; }  //ドロップダウンリスト(接種種類フィルター区分リスト)
        public bool rirekihyoji { get; set; }                           //履歴表示フラグ　true：全枝番の情報を表示、false：最大枝番の情報を表示
        public List<SessyuOneVm> kekkalist { get; set; }                //接種情報
    }

    /// <summary>
    /// 検索処理(詳細画面：接種情報(複数回)タブ)
    /// </summary>
    public class SearchDetailMultiResponse : SearchDetailOneResponse { }

    /// <summary>
    /// 検索処理(詳細画面：罹患情報タブタブ)
    /// </summary>
    public class SearchDetailRikanResponse : DaResponseBase
    {
        public List<SessyuRikanVm> kekkalist { get; set; }              //罹患情報
    }

    /// <summary>
    /// 検索処理(詳細画面：接種依頼情報タブ)
    /// </summary>
    public class SearchDetailIraiResponse : CmSearchResponseBase
    {
        public List<SessyuIraiVm> kekkalist { get; set; }               //接種依頼情報
    }

    /// <summary>
    /// 検索処理(詳細画面：その他情報タブ)
    /// </summary>
    public class SearchDetailFreeResponse : CmSearchResponseBase
    {
        public List<DaSelectorModel> grouplist1 { get; set; }           //フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }           //フリー項目グループ２リスト
        public List<FreeItemDispInfoVM> freeitemlist { get; set; }      //フリー項目情報（表示用）
    }

    /// <summary>
    /// 検索処理(詳細画面：その他情報タブ)
    /// </summary>
    public class SearchDetailOtherResponse : SearchDetailFreeResponse
    {
        public bool editflg { get; set; }                               //編集フラグ
        public List<FixItemDispInfoVM> fixitemlist { get; set; }        //固定項目情報（表示用）
    }

    /// <summary>
    /// 接種情報詳細画面検索処理
    /// </summary>
    public class SearchSessyuDetailResponse : SearchDetailFreeResponse
    {
        public HeaderInfoVM headerinfo { get; set; }                    //詳細画面ヘッダー情報
        public bool editflg { get; set; }                               //編集フラグ
        public FixItemSessyuVM fixiteminfo { get; set; }                //固定項目情報（表示用）
    }

    /// <summary>
    /// 接種依頼情報詳細画面検索処理
    /// </summary>
    public class SearchSessyuIraiDetailResponse : SearchDetailFreeResponse 
    {
        public HeaderInfoVM headerinfo { get; set; }                    //詳細画面ヘッダー情報
        public bool editflg { get; set; }                               //編集フラグ
        public FixItemSessyuIraiVM fixiteminfo { get; set; }            //固定項目情報（表示用）
    }

    /// <summary>
    /// 風疹抗体検査情報詳細画面検索処理
    /// </summary>
    public class SearchFusinDetailResponse : SearchDetailFreeResponse
    {
        public HeaderInfoVM headerinfo { get; set; }                    //詳細画面ヘッダー情報
        public bool editflg { get; set; }                               //編集フラグ
        public FixItemFusinVM fixiteminfo { get; set; }                 //固定項目情報（表示用）
    }

    /// <summary>
    /// 保存処理(接種情報詳細画面)
    /// </summary>
    public class SaveSessyuResponse : CommonResponse
    {
        public YSInputCheckInfoVM inputcheckinfo { get; set; }          //予防接種入力チェック情報（保存前チェック用）
    }

    /// <summary>
    /// 保存処理(罹患情報詳細画面)
    /// </summary>
    public class SaveRikanResponse : SaveSessyuResponse { }

    /// <summary>
    /// 保存/削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase { }
}