// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 基準値保守
//             ビューモデル定義
// 作成日　　: 2024.07.16
// 作成者　　: CNC
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00205G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM
    {
        public string itemnm { get; set; }              //項目名称
        public string sex { get; set; }                 //性別
        public string age { get; set; }                 //年齢範囲
        public string tani { get; set; }                //単位
        public string kijunvaluehyoki { get; set; }     //基準範囲
        public string alertvaluehyoki { get; set; }     //要注意
        public string errvaluehyoki { get; set; }       //異常値
        public DateTime? yukoymdf { get; set; }         //有効年月日開始
        public DateTime? yukoymdt { get; set; }         //有効年月日終了
        public string yukoymd { get; set; }             //有効年月日範囲
        public int edano { get; set; }                  //枝番
        public string itemcd { get; set; }              //項目コード
        public bool yukoflg { get; set; }               //有効フラグ
    }

    /// <summary>
    /// 項目名称変更情報(詳細画面)
    /// </summary>
    public class FreeMstInfoVM
    {
        public string tani { get; set; }                             //単位
        public string inputflgstr { get; set; }                      //入力フラグ
        public string hyojinendof { get; set; }                      //表示年度（開始）フロント
        public string hyojinendot { get; set; }                      //表示年度（終了）フロント
        public bool numcdflg { get; set; }                           //入力タイプフラグ
        public List<DaSelectorModel> selectorlist3 { get; set; }     //ドロップダウンリスト(基準値（コード）)
    }

    /// <summary>
    /// 基準値保守数値設定情報(詳細画面)
    /// </summary>
    public class MainNumsetInfoVM
    {
        public double? errvalue1t { get; set; }        //異常値1
        public double? alertvalue1f { get; set; }      //注意値1（開始）
        public double? alertvalue1t { get; set; }      //注意値1（終了）
        public double? kijunvaluef { get; set; }       //基準値1（開始）
        public double? kijunvaluet { get; set; }       //基準値1（終了）
        public double? alertvalue2f { get; set; }      //注意値2（開始）
        public double? alertvalue2t { get; set; }      //注意値2（終了）
        public double? errvalue2f { get; set; }        //異常値2
    }


    /// <summary>
    /// 基準値保守コード設定情報(詳細画面)
    /// </summary>
    public class MainCodesetInfoSaveVM
    {
        public List<string> hanteicdlist { get; set; }        //基準値（コード）
        public List<string> alerthanteicdlist { get; set; }   //注意値（コード）
        public List<string> errhanteicdlist { get; set; }     //異常値（コード）
    }

    /// <summary>
    /// 基準値保守情報(メイン：保存用)
    /// </summary>
    public class SaveMainVM
    {
        public bool ageflg { get; set; }                                //年齢指定
        public int? agef { get; set; }                                  //年齢（開始）
        public int? aget { get; set; }                                  //年齢（終了）
        public bool sexflg { get; set; }                                //性別指定
        public string sex { get; set; }                                 //性別（コード：名称）
        public DateTime yukoymdf { get; set; }                          //有効年月日（開始）
        public DateTime yukoymdt { get; set; }                          //有効年月日（終了）
        public string kijunvaluehyoki { get; set; }                     //基準値表記
        public string alertvaluehyoki { get; set; }                     //注意値表記
        public string errvaluehyoki { get; set; }                       //異常値表記
        public MainCodesetInfoSaveVM? maincodesetinfo { get; set; }     //基準値保守コード設定情報
        public MainNumsetInfoVM? mainnumsetinfo { get; set; }           //基準値保守数値設定情報
        public FreeMstInfoVM freemstinfo { get; set; }                  //項目名称変更情報
        public DateTime? upddttm { get; set; }            　　　　　　　//更新日時(排他用)
    }

    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class ItemVM
    {
        public string itemnm { get; set; }              //項目名称
        public string tani { get; set; }                //単位
    }
}