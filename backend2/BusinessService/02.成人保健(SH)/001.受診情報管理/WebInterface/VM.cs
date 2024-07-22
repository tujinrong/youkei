// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 検診結果管理
//             ViewModel定義
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;
using Newtonsoft.Json;

namespace BCC.Affect.Service.AWSH001
{
    /// <summary>
    /// 検診結果一覧データモデル(行単位)
    /// </summary>
    public class KsRowVM
    {
        public int? kensinkaisu { get; set; }       //検診回数
        public string atenano { get; set; }         //宛名番号
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string sex { get; set; }             //性別
        public string bymd { get; set; }            //生年月日
        public string adrs { get; set; }            //住所
        public string gyoseiku { get; set; }        //行政区
        public string juminkbn { get; set; }        //住民区分
        public DateTime? jissiymd1 { get; set; }    //実施日(一次)
        public DateTime? jissiymd2 { get; set; }    //実施日(精密)
        public string keikoku { get; set; }         //警告内容
    }

    /// <summary>
    /// 検診詳細排他チェック用モデル
    /// </summary>
    public class KsLockVM
    {
        public int? kensinkaisu { get; set; }   //検診回数
        public DateTime? upddttm1 { get; set; } //更新日時(一次)
        public DateTime? upddttm2 { get; set; } //更新日時(精密)
    }

    /// <summary>
    /// 検診詳細情報モデル(回目単位)：ベース情報
    /// </summary>
    public class KsTimeVM : KsLockVM
    {
        public DateTime? jissiymd1 { get; set; }    //実施日(一次)
        public DateTime? jissiymd2 { get; set; }    //実施日(精密)
        public string? regsisyo1 { get; set; }      //登録支所(一次固定)
        public string? regsisyo2 { get; set; }      //登録支所(精密固定)
        public string? regsisyonm1 { get; set; }    //登録支所名(一次固定)
        public string? regsisyonm2 { get; set; }    //登録支所名(精密固定)
        public int? jissiage1 { get; set; }         //実施年齢(一次固定)
        public int? jissiage2 { get; set; }         //実施年齢(精密固定)
        public string? kensahoho1 { get; set; }     //検査方法(一次固定)(コード：名称)
    }

    /// <summary>
    /// 個人基本情報(詳細画面)
    /// </summary>
    public class KsHeaderVM
    {
        public string name { get; set; }        //氏名
        public string kname { get; set; }       //カナ氏名
        public string sexhyoki { get; set; }    //性別
        public string bymd { get; set; }        //生年月日
        public string juminkbn { get; set; }    //住民区分
        public string age { get; set; }         //年齢
        public string agekijunymd { get; set; } //年齡計算基準日
        [JsonIgnore]
        public string personalno { get; set; }  //個人番号
        public string keikoku { get; set; }     //警告内容
        public bool kensinkibosyasyosaiflg { get; set; }     //健（検）診予約希望者詳細フラグ
    }

    /// <summary>
    /// 詳細情報モデル(回目単位)：検索
    /// </summary>
    public class KsTimeSearchVM : KsTimeVM
    {
        public List<KsFixItemVM> itemlist1 { get; set; }    //項目リスト(一次固定)
        public List<KsFixItemVM> itemlist2 { get; set; }    //項目リスト(精密固定)
        public List<KsFreeItemVM> itemlist3 { get; set; }   //項目リスト(フリー)
    }

    /// <summary>
    /// 詳細情報モデル(回目単位)：更新
    /// </summary>
    public class KsTimeUpdateVM : KsTimeVM
    {
        public List<KsItemUpdVM> itemlist1 { get; set; }    //項目リスト(一次)
        public List<KsItemUpdVM> itemlist2 { get; set; }    //項目リスト(精密)
        public List<KsKekkaItemVM> kekkalist { get; set; }  //結果項目一覧(一次)
    }

    /// <summary>
    /// フリー項目モデル(更新)
    /// </summary>
    public class KsItemUpdVM : FreeItemUpdBaseVM
    {
        public int? kensinkaisu { get; set; }               //検診回数
    }

    /// <summary>
    /// フリー項目モデル(初期化)：固定
    /// </summary>
    public class KsFixItemVM : FixFreeItemBaseVM
    {
        public int? kensinkaisu { get; set; }               //検診回数
        public List<string> riyokensahohocds { get; set; }  //利用検査方法コード一覧
        public string? komokutokuteikbn { get; set; }       //項目特定区分
    }

    /// <summary>
    /// フリー項目モデル(初期化)：フリー
    /// </summary>
    public class KsFreeItemVM : KsFixItemVM
    {
        public EnumKensinKbn groupid { get; set; }     //グループID
        public string? groupid2 { get; set; }          //グループID2
    }

    /// <summary>
    /// 編集状態モデル
    /// </summary>
    public class KsStatusVM
    {
        public EnumActionType statuskbn { get; set; }   //状態区分
        public int? kensinkaisubefore { get; set; }     //検診回数(編集前)
        public int? kensinkaisuafter { get; set; }      //検診回数(編集後)
    }

    /// <summary>
    /// 検診フリー項目(結果項目)
    /// </summary>
    public class KsKekkaItemVM
    {
        public string itemcd { get; set; }  //項目コード
        public string? value { get; set; }  //値(コード：名称)
    }

    /// <summary>
    /// 検診フリー項目(計算用)
    /// </summary>
    public class KsCalculateVM
    {
        public string itemcd { get; set; }  //項目コード
        public object? value { get; set; }  //値
    }

    /// <summary>
    /// 検診フリー項目(キー)
    /// </summary>
    public class KjFreeItemVM
    {
        public string itemcd { get; set; }          //項目コード
        public EnumKensinKbn groupid { get; set; }  //グループID
    }
}