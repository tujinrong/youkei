// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 集団指導管理
//             ビューモデル定義
// 作成日　　: 2023.12.23
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWKK00303G
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitDetailVM
    {
        public List<DaSelectorModel> gyomulist { get; set; }            //ドロップダウンリスト(業務リスト)
        public List<DaSelectorModel> jigyolist { get; set; }            //ドロップダウンリスト(事業リスト)
        public List<DaSelectorModel> kaijolist { get; set; }            //ドロップダウンリスト(実施場所リスト)
        public List<StaffListVM> stafflist { get; set; }                //ドロップダウンリスト(予定者／実施者リスト)
        public List<DaSelectorModel> courselist { get; set; }           //ドロップダウンリスト(コースリスト)
        public List<DaSelectorModel> syukeikbnlist { get; set; }        //ドロップダウンリスト(地域保健集計区分リスト)
        public List<DaSelectorModel> group1list { get; set; }           //ドロップダウンリスト(グループ１リスト)
        public List<DaSelectorModel> group2list { get; set; }           //ドロップダウンリスト(グループ２リスト)
        public List<DaSelectorModel> sankasyagroup1list { get; set; }   //ドロップダウンリスト(参加者グループ１リスト)
        public List<DaSelectorModel> sankasyagroup2list { get; set; }   //ドロップダウンリスト(参加者グループ２リスト)
        public List<DaSelectorModel> syukketuswitch { get; set; }       //スイッチ(出欠区分スイッチ)
    }

    /// <summary>
    /// 検索処理(結果一覧画面)
    /// </summary>
    public class SyudanListVM
    {
        public string gyomukbn { get; set; }                //業務区分
        public string gyomu { get; set; }                   //業務
        public string jigyocd { get; set; }                 //事業コード 
        public string jigyo { get; set; }                   //事業名称
        public string? yoteiymd { get; set; }               //実施予定日 
        public string? yotetmf { get; set; }                //予定開始時間  
        public string? yotebasyo { get; set; }              //実施予定場所 
        public string yoteisya { get; set; }                //予定者 
        public int? nitteno { get; set; }                   //日程番号  
        public int? nittesyosaino { get; set; }             //日程詳細番号 
        public string? coursenm { get; set; }               //コース名 
        public string jissiymd { get; set; }                //実施日  
        public string jissitm { get; set; }                 //実施時間 
        public string? jissibasyo { get; set; }             //実施場所 
        public string jissisya { get; set; }                //実施者 
        public int edano { get; set; }                      //枝番（キー項目、非表示）
    }

    /// <summary>
    /// 事業従事者リスト（予定者／実施者用）
    /// </summary>
    public class StaffListVM
    {
        public string staffid { get; set; }                 //事業従事者ID
        public string staffsimei { get; set; }              //事業従事者氏名
    }

    /// <summary>
    /// 親画面引き続き情報（表示用）
    /// </summary>
    public class ParamInfoVM
    {
        public string gyomu { get; set; }                   //業務
        public int edano { get; set; }                      //枝番
    }

    /// <summary>
    /// 事業詳細画面_固定情報（表示用）
    /// </summary>
    public class JigyoBaseInfoVM
    {
        public bool inputflg { get; set; }                  //申込情報入力
        public List<DaSelectorModel> jigyolist { get; set; } //ドロップダウンリスト(事業リスト)
        public string jigyo { get; set; }                   //事業コード
        public string kaijo { get; set; }                   //実施場所
        public List<StaffListVM> stafflist { get; set; }    //事業従事者ID（予定者／実施者）
        public string regsisyocd { get; set; }              //登録支所コード
        public string regsisyonm { get; set; }              //登録支所名称
    }

    /// <summary>
    /// 事業詳細画面_指導情報（表示用）
    /// </summary>
    public class JigyoFixInfoVM : JigyoBaseInfoVM
    {
        public string yoteiymd { get; set; }                //実施予定日（申込タブ用）
        public string yoteitm { get; set; }                 //予定開始時間（申込タブ用）
        public string syukeikbn { get; set; }               //地域保健集計区分（結果タブ用）
        public string jissiymd { get; set; }                //実施日（結果タブ用）
        public string tmf { get; set; }                     //開始時間（結果タブ用）
        public string tmt { get; set; }                     //終了時間（結果タブ用）
    }

    /// <summary>
    /// 個人詳細画面_フリー項目情報（表示用）
    /// </summary>
    public class FreeItemDispInfoVM : FreeItemBaseVM
    {
        public string itemkbn { get; set; }                 //分類
        public string? groupid { get; set; }                //グループID
        public string syukeikbn { get; set; }               //利用地域保健集計区分
    }

    /// <summary>
    /// 参加者基本情報
    /// </summary>
    public class SankasyaBaseInfoVM
    {
        public string atenano { get; set; }                 //宛名番号
        public string name { get; set; }                    //氏名
        public string kname { get; set; }                   //カナ氏名
        public string sex { get; set; }                     //性別（名称）
        public string bymd { get; set; }                    //生年月日（和暦表示）
        public string juminkbn { get; set; }                //住民区分（名称）
        public string keikoku { get; set; }                 //警告内容
    }

    /// <summary>
    /// 参加者一覧情報
    /// </summary>
    public class SankasyaInfoVM : SankasyaBaseInfoVM
    {
        public string syukketukbn { get; set; }             //出欠区分
    }

    //********************************************************参加者詳細画面表示********************************************************
    /// <summary>
    /// 参加者詳細画面_ヘッダー情報（表示用）
    /// </summary>
    public class HeaderInfoVM : SankasyaInfoVM
    {
        public string age { get; set; }                     //年齢			
        public string kijunymd { get; set; }                //年齢計算基準日
    }

    /// <summary>
    /// 参加者詳細画面_固定情報（表示用）
    /// </summary>
    public class SankasyaFixInfoVM
    {
        public bool inputflg { get; set; } = false;         //申込情報入力
        public string jigyo { get; set; }                   //事業コード
        public string syukeikbn { get; set; }               //地域保健集計区分（結果タブ用）
        public string regsisyocd { get; set; }              //登録支所コード
        public string regsisyonm { get; set; }              //登録支所名称
    }

    //********************************************************集団個別入力画面保存********************************************************
    /// <summary>
    /// 個人詳細画面_フリー項目情報（保存用）
    /// </summary>
    public class FreeItemInfoVM
    {
        public int inputtype { get; set; }                  //入力タイプ
        public string item { get; set; }                    //項目（コード：名称）
        public object? value { get; set; }                  //値
    }

    /// <summary>
    /// 個人詳細画面_固定情報（保存用）
    /// </summary>
    public class PersonalBaseInfoVM
    {
        public bool inputflg { get; set; }                  //申込／結果情報入力
        public string jigyo { get; set; }                   //事業（コード : 名称）
        public string kaijo { get; set; }                   //実施場所
        public List<StaffListVM> stafflist { get; set; }    //事業従事者ID（予定者／実施者）
        public string regsisyocd { get; set; }              //登録支所コード
    }

    /// <summary>
    /// 個人詳細画面_申込情報（保存用）
    /// </summary>
    public class MosikomiSaveVM : PersonalBaseInfoVM
    {
        public string yoteiymd { get; set; }                //実施予定日
        public string yoteitm { get; set; }                 //予定開始時間
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// <summary>
    /// 個人詳細画面_結果情報（保存用）
    /// </summary>
    public class KekkaSaveVM : PersonalBaseInfoVM
    {
        public string jissiymd { get; set; }                //実施日
        public string tmf { get; set; }                     //開始時間
        public string tmt { get; set; }                     //終了時間
        public string syukeikbn { get; set; }               //地域保健集計区分
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// 参加者一覧（保存用）
    /// </summary>
    public class SankasyaListVM
    {
        public string atenano { get; set; }                 //宛名番号
        public string syukketukbn { get; set; }             //出欠区分
    }

    /// <summary>
    /// 参加者情報情報（保存用）
    /// </summary>
    public class SankasyaSaveVM
    {
        public bool inputflg { get; set; }                  //参加者情報入力
        public string jigyo { get; set; }                   //事業（コード : 名称）
        public List<SankasyaListVM> sankasyalist { get; set; } //参加者一覧
    }

    /// <summary>
    /// 個人詳細画面_申込情報／結果情報タブ（保存用）
    /// </summary>
    public class MainInfoVM
    {
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; } = 0;                 //枝番
        public MosikomiSaveVM mosikomiinfo { get; set; }    //申込情報
        public KekkaSaveVM kekkainfo { get; set; }          //結果情報
        public SankasyaSaveVM sankasyainfo { get; set; }    //参加者情報
    }

    //********************************************************参加者詳細画面保存********************************************************
    /// <summary>
    /// 参加者詳細_申込情報／結果情報タブ（保存用）
    /// </summary>
    public class SankasyaMainInfoVM
    {
        public string gyomukbn { get; set; }                //業務区分
        public int edano { get; set; } = 0;                 //枝番
        public string? atenano { get; set; } = null;        //宛名番号
        public SankasyaMosikomiInfoVM mosikomiinfo { get; set; } //申込情報
        public SankasyaKekkaInfoVM kekkainfo { get; set; }  //結果情報
    }

    /// <summary>
    /// 参加者詳細画面_申込情報（保存用）
    /// </summary>
    public class SankasyaMosikomiInfoVM
    {
        public bool inputflg { get; set; }                  //申込／結果情報入力
        public string regsisyocd { get; set; }              //登録支所コード
        public List<FreeItemInfoVM> freeiteminfo { get; set; } //フリー項目情報
    }

    /// <summary>
    /// 参加者詳細画面_結果情報（保存用）
    /// </summary>
    public class SankasyaKekkaInfoVM : SankasyaMosikomiInfoVM
    {
        public string syukeikbn { get; set; }               //地域保健集計区分
    }
}