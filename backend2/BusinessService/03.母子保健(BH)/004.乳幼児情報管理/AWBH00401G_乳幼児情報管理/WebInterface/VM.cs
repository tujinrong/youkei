// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 
//             ビューモデル定義
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWBH00401G
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
    /// 検索処理(乳幼児一覧画面)
    /// </summary>
    public class NyuyoujiListVM : BaseInfoVM
    {
        public string datasts { get; set; }             //状態
        public string gyoseiku { get; set; }            //行政区
        public string syosai { get; set; }              //詳細（メニュー名称文字列）
    }


    /// <summary>
    /// 検索処理(乳幼児ヘッダー部分情報)
    /// </summary>
    public class HeaderInfoVM : BaseInfoVM
    {
        public string age { get; set; }                 //年齢															
        public string kijunymd { get; set; }            //年齢計算基準日
    }

    /// <summary>
    /// メニュー名称表示用
    /// </summary>
    public class MenuInfoVM
    {
        public string menucd { get; set; }              //メニューコード	
        public string menuname { get; set; }            //メニュー名称														
        public string status { get; set; }              //表示状態（文字色）
    }

    /// <summary>
    /// タブ名称表示用
    /// </summary>
    public class TabInfoVM
    {
        public string tabcd { get; set; }               //タブコード	
        public string tabname { get; set; }             //タブ名称														
        public string status { get; set; }              //表示状態（文字色）
    }

    /// <summary>
    /// 履歴回数表示用
    /// </summary>
    public class KaisuInfoVM
    {

        public int kaisu { get; set; }                  //履歴回数
    }

    /// <summary>
    /// 乳幼児詳細画面_固定項目情報（表示用）
    /// </summary>
    public class FixItemDispInfoVM : FreeItemDispInfoVM {}

    /// <summary>
    /// 乳幼児詳細画面_フリー項目情報（表示用）
    /// </summary>
    public class FreeItemDispInfoVM : FreeItemBaseVM
    {
        public string? groupid { get; set; }            //グループID
        public int orderseq { get; set; }               //並びシーケンス
    }

    /// <summary>
    /// 乳幼児詳細画面_独自項目情報
    /// </summary>
    public class DokujiInfoVM
    {
        public int edano { get; set; }                  //枝番
        public string value { get; set; }               //値
    }

    /// <summary>
    /// 乳幼児詳細画面_フリー項目情報（保存用）
    /// </summary>
    public class FreeItemInfoVM
    {
        public int inputtype { get; set; }              //入力タイプ
        public string item { get; set; }                //項目（名称）
        public object? value { get; set; }              //値
    }

    /// <summary>
    /// 父母親情報
    /// </summary>
    public class AtenaInfoVM
    {
        public string simei_yusen { get; set; }         //氏名_優先
        public string jutoknm { get; set; }             //住登区分名称
        public string juminsyubetunm { get; set; }      //住民種別名称
        public string juminjotainm { get; set; }        //住民状態名称
        public string juminnm { get; set; }             //住民区分名称
    }
}