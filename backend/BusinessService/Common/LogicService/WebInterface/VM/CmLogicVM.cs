// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: ロジック共通仕様処理
//             ViewModel定義
// 作成日　　: 2023.07.18
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using Newtonsoft.Json;

namespace BCC.Affect.Service.Common
{
    /// <summary>
    /// 権限モデル
    /// </summary>
    public class CmAuthVM
    {
        public bool personalflg { get; set; }           //個人番号操作権限フラグ
        public bool alertviewflg { get; set; }          //警告参照フラグ
        public List<string> editSisyos { get; set; }    //更新可能支所一覧
    }

    /// <summary>
    /// 支所モデル
    /// </summary>
    public class CmSisyoVM
    {
        public string sisyocd { get; set; } //支所コード
        public string sisyonm { get; set; } //支所名
    }

    /// <summary>
    /// ヘッダー基本情報
    /// </summary>
    public class CmHeaderBaseVM
    {
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string sex { get; set; }             //性別
        public string juminkbn { get; set; }        //住民区分
        public string bymd { get; set; }            //生年月日
    }

    /// <summary>
    /// 共通バー共通基本情報
    /// </summary>
    public class CommonBarHeaderBaseVM : CmHeaderBaseVM
    {
        public string age { get; set; }             //年齢
        public string agekijunymd { get; set; }     //年齡計算基準日
    }

    /// <summary>
    /// 共通バー共通基本情報
    /// </summary>
    public class CommonBarHeaderBase2VM : CommonBarHeaderBaseVM
    {
        public string keikoku { get; set; } //警告内容
    }

    /// <summary>
    /// 共通バー共通基本情報
    /// </summary>
    public class CommonBarHeaderBase3VM : CommonBarHeaderBase2VM
    {
        public string adrs { get; set; }    //住所
    }

    /// <summary>
    /// 画面共通基本情報
    /// </summary>
    public class GamenHeaderBaseVM : CommonBarHeaderBaseVM
    {
        [JsonIgnore]
        public string personalno { get; set; }  //個人番号
    }

    /// <summary>
    /// 画面共通基本情報
    /// </summary>
    public class GamenHeaderBase2VM : GamenHeaderBaseVM
    {
        public string adrs { get; set; }    //住所
        public string keikoku { get; set; } //警告内容
    }

    /// <summary>
    /// 基準値範囲
    /// </summary>
    public class KjItemVM
    {
        public string itemcd { get; set; }           //項目コード
        public string kijunvaluehyoki { get; set; }  //基準値表記
        public string alertvaluehyoki { get; set; }  //注意値表記
        public string errvaluehyoki { get; set; }    //異常値表記
        public List<KijunVM> kijunlist { get; set; } //基準値リスト
    }

    /// <summary>
    /// 基準値(チェック用)
    /// </summary>
    public class KijunVM
    {
        public double? errvalue1t { get; set; }      //異常値（数値）以下
        public double? alertvalue1f { get; set; }    //注意値（数値）開始
        public double? alertvalue1t { get; set; }    //注意値（数値）終了
        public double? kijunvaluef { get; set; }     //基準値（数値）開始
        public double? kijunvaluet { get; set; }     //基準値（数値）終了
        public double? alertvalue2f { get; set; }    //注意値（数値）開始
        public double? alertvalue2t { get; set; }    //注意値（数値）終了
        public double? errvalue2f { get; set; }      //異常値（数値）以上
        public string hanteicd { get; set; }         //基準値（コード）
        public string alerthanteicd { get; set; }    //注意値（コード）
        public string errhanteicd { get; set; }      //異常値（コード）
    }
    /// <summary>
    /// フリー項目モデル(初期化)：フリー
    /// </summary>
    public class FreeItemBaseVM : FixFreeItemBaseVM
    {
        public string? groupid2 { get; set; }          //グループID2
    }
    /// <summary>
    /// フリー項目モデル(初期化)：固定
    /// </summary>
    public class FixFreeItemBaseVM : FreeItemUpdBaseVM
    {
        public string itemnm { get; set; }                      //項目名
        public Enum画面項目入力 inputkbn { get; set; }          //画面項目入力区分
        public List<DaSelectorModel> cdlist { get; set; }       //一覧選択リスト
        public int? keta1 { get; set; }                         //入力桁(整数部/文字)
        public int? keta2 { get; set; }                         //入力桁(小数部)
        public bool hissuflg { get; set; }                      //必須フラグ
        public string hanif { get; set; }                       //入力範囲（開始）
        public string hanit { get; set; }                       //入力範囲（終了）
        public bool inputflg { get; set; }                      //入力フラグ
        public EnumMsgCtrlKbn msgkbn { get; set; }              //メッセージ区分
        public string syokiti { get; set; }                     //初期値
        public string biko { get; set; }                        //備考
    }
    /// <summary>
    /// フリー項目モデル(更新)
    /// </summary>
    public class FreeItemUpdBaseVM
    {
        public string itemcd { get; set; }                  //項目コード
        public object? value { get; set; }                  //値
        public bool? fusyoflg { get; set; }                 //不詳フラグ
        public Enum入力タイプ inputtypekbn { get; set; }    //入力タイプ区分
    }
    /// <summary>
    /// 一覧列情報
    /// </summary>
    public class ColumnInfoVM
    {
        public string title { get; set; }   //項目論理名
        public string key { get; set; }     //項目物理名
    }
    /// <summary>
    /// 一覧データ
    /// </summary>
    public class DataInfoVM
    {
        public string key { get; set; }     //項目物理名
        public string value { get; set; }   //値
    }
}