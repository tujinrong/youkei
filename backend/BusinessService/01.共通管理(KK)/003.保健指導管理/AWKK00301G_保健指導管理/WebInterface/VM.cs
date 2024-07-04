// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 保健指導管理
//             ビューモデル定義
// 作成日　　: 2023.12.13
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK00301G
{
    /// <summary>
    /// 基本情報(メイン：ベース)
    /// </summary>
    public class BaseInfoVM
    {
        public string atenano { get; set; }             //宛名番号
        public string name { get; set; }                //氏名
        public string kname { get; set; }               //カナ氏名
        public string sex { get; set; }                 //性別（名称）
        public string bymd { get; set; }                //生年月日
        public string juminkbn { get; set; }            //住民区分
        public string keikoku { get; set; }             //警告内容
    }

    /// <summary>
    /// 検索処理(住民一覧画面)
    /// </summary>
    public class JyuminListVM : BaseInfoVM
    {
        public string adrs { get; set; }                //住所(住所1、住所2)
        public string gyoseiku { get; set; }            //行政区
    }


    /// <summary>
    /// 検索処理(世帯固定部分情報)
    /// </summary>
    public class SetaiBaseInfoVM
    {
        public string atenano { get; set; }             //宛名番号
        public string name { get; set; }                //氏名
        public string kname { get; set; }               //カナ氏名
        public string adrs_yubin { get; set; }          //郵便番号
        public string tosi_gyoseiku { get; set; }       //指定都市_行政区等
        public string adrs { get; set; }                //住所(住所1、住所2)
    }

    /// <summary>
    /// 検索処理(世帯地区情報)
    /// </summary>
    public class SetaiTikuListVM
    {
        public string tikukbn { get; set; }             //地区区分
        public string tiku { get; set; }                //地区
    }

    /// <summary>
    /// 検索処理(世帯構成員一覧画面)
    /// </summary>
    public class SetaiListVM : BaseInfoVM
    {
        public string zokuhyoki { get; set; }           //続柄
        public string homonyoteiymd { get; set; }       //訪問予定日
        public string homonjissiymd { get; set; }       //訪問実施日
        public string kobetuyoteiymd { get; set; }      //個別指導予定日
        public string kobetujissiymd { get; set; }      //個別指導実施日
    }

    /// <summary>
    /// 検索処理(個人一覧ヘッダー情報)
    /// </summary>
    public class PersonalHeaderInfoVM : BaseInfoVM
    {
        public string age { get; set; }                 //年齢															
        public string kijunymd { get; set; }            //年齢計算基準日
    }

    /// <summary>
    /// 検索処理(指導情報一覧画面)
    /// </summary>
    public class ShidouInfoListVM
    {
        public string gyomunm { get; set; }             //業務
        public string jigyocd { get; set; }             //事業コード
        public string jigyonm { get; set; }             //事業名称
        public string yoteiymd { get; set; }            //実施予定日
        public string yoteitm { get; set; }             //予定開始時間
        public string yoteikaijo { get; set; }          //実施場所（申込）
        public string yoteisya { get; set; }            //予定者
        public string jissiymd { get; set; }            //実施日
        public string jissitm { get; set; }             //実施時間
        public string jissikaijo { get; set; }          //実施場所（結果）
        public string nenrei { get; set; }              //実施日時点年齢
        public string jissisya { get; set; }            //実施者
        public int edano { get; set; }                  //枝番（キー項目、非表示）
    }

    /// <summary>
    /// 個人詳細画面_フリー項目情報（表示用）
    /// </summary>
    public class FreeItemDispInfoVM : FreeItemBaseVM
    {
        public string itemkbn { get; set; }             //分類
        public string? groupid { get; set; }            //グループID
        public string syukeikbn { get; set; }           //利用地域保健集計区分
    }

    /// <summary>
    /// 個人詳細画面_指導情報（表示用）
    /// </summary>
    public class FixDispInfoVM : PersonalBaseInfoVM
    {
        public string yoteiymd { get; set; }            //実施予定日（申込タブ用）
        public string yoteitm { get; set; }             //予定開始時間（申込タブ用）
        public string jissiymd { get; set; }            //実施日（結果タブ用）
        public string tmf { get; set; }                 //開始時間（結果タブ用）
        public string tmt { get; set; }                 //終了時間（結果タブ用）
        public string syukeikbn { get; set; }           //地域保健集計区分（結果タブ用）
        public List<DaSelectorModel> syukeikbnlist { get; set; }//ドロップダウンリスト(地域保健集計区分リスト)

    }

    /// <summary>
    /// 事業リスト（仕様未確定の為、未使用）
    /// </summary>
    public class JigyoListVM
    {
        public string jigyocd { get; set; }             //事業コード
        public string jigyonm { get; set; }             //事業名
    }

    /// <summary>
    /// 実施場所リスト
    /// </summary>
    public class KaijoListVM
    {
        public string kaijocd { get; set; }             //会場コード
        public string kaijonm { get; set; }             //会場名
    }

    /// <summary>
    /// 事業従事者リスト（予定者／実施者用）
    /// </summary>
    public class StaffListVM
    {
        public string staffid { get; set; }             //事業従事者ID
        public string staffsimei { get; set; }          //事業従事者氏名
    }

    /// <summary>
    /// 個人詳細画面_固定情報（保存用）
    /// </summary>
    public class PersonalBaseInfoVM
    {
        public bool inputflg { get; set; }                  //申込情報入力
        public List<DaSelectorModel> jigyolist { get; set; } //ドロップダウンリスト(事業リスト)
        public string jigyo { get; set; }                   //事業（コード : 名称）
        public string kaijo { get; set; }                   //実施場所
        public List<StaffListVM> stafflist { get; set; }    //事業従事者ID（予定者／実施者）
        public string regsisyocd { get; set; }              //登録支所コード
        public string regsisyonm { get; set; }              //登録支所名称
    }

    /// <summary>
    /// 個人詳細画面_フリー項目情報（保存用）
    /// </summary>
    public class FreeItemInfoVM
    {
        public int inputtype { get; set; }                  //入力タイプ
        public string item { get; set; }                    //項目（名称）
        public object? value { get; set; }                  //値
    }

    /// <summary>
    /// 個人詳細画面_申込情報（保存用）
    /// </summary>
    public class MosikomiInfoVM : PersonalBaseInfoVM
    {
        public string yoteiymd { get; set; }                //実施予定日
        public string yoteitm { get; set; }                 //予定開始時間
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// <summary>
    /// 個人詳細画面_結果情報（保存用）
    /// </summary>
    public class KekkaInfoVM : PersonalBaseInfoVM
    {
        public string jissiymd { get; set; }                //実施日
        public string tmf { get; set; }                     //開始時間
        public string tmt { get; set; }                     //終了時間
        public string syukeikbn { get; set; }               //地域保健集計区分
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// <summary>
    /// 個人詳細画面_申込情報／結果情報タブ（保存用）
    /// </summary>
    public class MainInfoVM
    {
        public string atenano { get; set; }                 //宛名番号
        public string hokensidokbn { get; set; }            //保健指導区分
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; } = 0;                 //枝番
        public MosikomiInfoVM mosikomiinfo { get; set; }    //申込情報
        public KekkaInfoVM kekkainfo { get; set; }          //結果情報
    }

    /// <summary>
    /// スタッフリストVM（検索用）
    /// </summary>
    public class StaffSearchVM
    {
        public string hokensidokbn { get; set; }            //保健指導区分
        public string gyomukbn { get; set; }                //業務区分
        public string atenano { get; set; }                 //宛名番号
        public int edano { get; set; } = 0;                 //枝番
        public string mosikomikekkakbn { get; set; }        //申込結果区分
    }

    /// <summary>
    /// 初期化処理(個人詳細画面)
    /// </summary>
    public class InitDetailVM
    {
        public bool inputflg { get; set; }                              //結果情報入力
        public List<DaSelectorModel> gyomulist { get; set; }            //ドロップダウンリスト(業務リスト)
        public List<DaSelectorModel> kaijolist { get; set; }            //ドロップダウンリスト(実施場所リスト)
        public List<DaSelectorModel> stafflist { get; set; }            //ドロップダウンリスト(実施者リスト)
        public List<DaSelectorModel> syukeikbnlist { get; set; }        //ドロップダウンリスト(地域保健集計区分リスト)
        public List<DaSelectorModel> group1list { get; set; }           //ドロップダウンリスト(グループ１リスト)
        public List<DaSelectorModel> group2list { get; set; }           //ドロップダウンリスト(グループ２リスト)
    }
}