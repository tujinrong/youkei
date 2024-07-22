// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導管理
//             レスポンスインターフェース
// 作成日　　: 2023.12.13
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWSH001;

namespace BCC.Affect.Service.AWKK00301G
{
    /// <summary>
    /// 1.住民一覧画面検索処理(一覧画面)
    /// </summary>
    public class SearchListResponse : CmSearchResponseBase
    {
        public List<JyuminListVM> kekkalist { get; set; }               //結果リスト(住民一覧)
        public bool transflg { get; set; }                              //遷移フラグ
    }

    /// <summary>
    /// 2.3.住民詳細画面検索処理(一覧画面)
    /// </summary>
    public class SearchDetailResponse : CmSearchResponseBase
    {
        public SetaiBaseInfoVM setaibaseinfo { get; set; }              //世帯情報（固定部分）
        public List<SetaiTikuListVM> setaitikulist { get; set; }        //世帯地区情報一覧
        public List<SetaiListVM> setailist { get; set; }                //世帯構成員一覧
    }

    /// <summary>
    /// 4.世帯詳細画面検索処理(一覧画面)
    /// </summary>
    public class SearchSetaiDetailResponse : CmSearchResponseBase
    {
        public PersonalHeaderInfoVM personalheaderinfo { get; set; }    //個人一覧ヘッダー情報
        public List<DaSelectorModel> gyomulist { get; set; }            //ドロップダウンリスト(業務リスト)
        public List<DaSelectorModel> h_jigyolist { get; set; }          //ドロップダウンリスト(事業リスト)(申込タブ用)
        public List<DaSelectorModel> k_jigyolist { get; set; }          //ドロップダウンリスト(事業リスト)(結果タブ用)
        public List<ShidouInfoListVM> shidouinfolist { get; set; }      //個人一覧指導情報
    }

    /// <summary>
    /// 5.世帯詳細画面検索処理（個人一覧のタブを選択）
    /// </summary>
    public class SearchShidouDetailResponse : DaResponseBase
    {
        public List<DaSelectorModel> gyomulist { get; set; }            //ドロップダウンリスト(業務リスト)
        public List<DaSelectorModel> h_jigyolist { get; set; }          //ドロップダウンリスト(事業リスト)(申込タブ用)
        public List<DaSelectorModel> k_jigyolist { get; set; }          //ドロップダウンリスト(事業リスト)(結果タブ用)
        public List<ShidouInfoListVM> shidouinfolist { get; set; }      //個人一覧指導情報
    }

    /// <summary>
    /// 6.個人詳細画面検索処理（個人詳細画面）
    /// </summary>
    public class SearchPersonDetailResponse : SearchPersonShidouResponse
    {
        public PersonalHeaderInfoVM personalheaderinfo { get; set; }    //個人詳細ヘッダー情報
    }

    /// <summary>
    /// 7.個人詳細画面検索処理（個人詳細のタブを選択）
    /// </summary>
    public class SearchPersonShidouResponse : SearchFreeItemResponse
    {
        public bool editflg { get; set; }                               //編集フラグ
        public FixDispInfoVM personalfixinfo { get; set; }              //個人詳細固定情報（表示用）
    }

    /// <summary>
    /// 7.8.保存/削除処理(詳細画面)
    /// </summary>
    public class CommonResponse : DaResponseBase { }

    /// <summary>
    /// 9.フリー項目絞込処理
    /// </summary>
    public class SearchFreeItemResponse : DaResponseBase
    {
        public List<DaSelectorModel> grouplist1 { get; set; }           //フリー項目グループ１リスト
        public List<DaSelectorModel> grouplist2 { get; set; }           //フリー項目グループ２リスト
        public List<FreeItemDispInfoVM> freeitemlist { get; set; }      //フリー項目情報（表示用）
    }

    /// <summary>
    /// 10.初期化処理(個人詳細画面)
    /// </summary>
    public class InitDetailResponse : DaResponseBase
    {
        public InitDetailVM initdetail { get; set; }                    //個人詳細画面_基本情報等タブリスト初期化
    }

    /// <summary>
    /// 11.実施日時点年齢取得処理
    /// </summary>
    public class GetAgeResponse : DaResponseBase
    {
        public string nenrei { get; set; }                              //実施日時点年齢
    }
}