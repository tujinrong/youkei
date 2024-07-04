// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予約希望者管理
//             ビューモデル定義
// 作成日　　: 2024.03.07
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00902G
{
    /// <summary>
    /// 日程情報(1件)
    /// </summary>
    public class NitteiRowVM : RowBaseVM
    {
        public string gyomukbnnm { get; set; }      //業務区分名
        public int? courseno { get; set; }          //コース番号
        public string coursenm { get; set; }        //コース名
        public string time { get; set; }            //開始時間～終了時間
    }
    /// <summary>
    /// コース情報(1件)
    /// </summary>
    public class CourseRowVM : RowBaseVM
    {
        public string tmf { get; set; }            //開始時間
        public string tmt { get; set; }            //終了時間
    }
    /// <summary>
    /// 共通情報(1件)
    /// </summary>
    public class RowBaseVM
    {
        public int nitteino { get; set; }           //日程番号
        public int? kaisu { get; set; }             //回数
        public string jigyonm { get; set; }         //その他日程事業・保健指導事業名
        public string jissinaiyo { get; set; }      //実施内容
        public string jissiyoteiymd { get; set; }   //実施予定日
        public string kaijonm { get; set; }         //会場名
        public string kikannm { get; set; }         //医療機関名
        public string staffidnms { get; set; }      //担当者名(複数)
        public string status { get; set; }          //状態
        public string ninzu { get; set; }           //申/定員
        public int? taikinum { get; set; }          //待機数
    }
    /// <summary>
    /// コース情報(ヘッダー)
    /// </summary>
    public class CourseHeaderVM
    {
        public string gyomukbnnm { get; set; }  //業務区分名
        public string coursenm { get; set; }    //コース名
    }

    /// <summary>
    /// 日程基本情報(ヘッダー)
    /// </summary>
    public class PersonHeaderVM : CourseHeaderVM
    {
        public int? courseno { get; set; }          //コース番号
        public int? kaisu { get; set; }             //回数
        public string jigyonm { get; set; }         //その他日程事業・保健指導事業名
        public string? jissinaiyo { get; set; }  //実施内容
        public string jissiyoteiymd { get; set; }   //実施予定日
        public string tmf { get; set; }             //開始時間
        public string tmt { get; set; }             //終了時間
        public string kaijonm { get; set; }         //会場名
        public string kikannm { get; set; }         //医療機関名
        public string staffnms { get; set; }        //担当者一覧
    }

    /// <summary>
    /// 日程基本情報(予約状態)
    /// </summary>
    public class PersonDetailVM
    {
        public string status { get; set; }      //状態
        public int teiin { get; set; }          //定員
        public int? moushikominum { get; set; } //申込人数
        public int? taikinum { get; set; }      //待機人数
    }

    /// <summary>
    /// 希望者情報(検索用)
    /// </summary>
    public class PersonRowVM : LockVM
    {
        public int yoyakuno { get; set; }       //予約番号
        public string name { get; set; }        //氏名
        public string kname { get; set; }       //カナ氏名
        public string sex { get; set; }         //性別
        public string bymd { get; set; }        //生年月日
        public string age { get; set; }         //年齢
        public string juminkbn { get; set; }    //住民区分
        public string keikoku { get; set; }     //警告内容
        public string status { get; set; }	    //予約状態
    }

    /// <summary>
    /// 希望者情報(排他用)
    /// </summary>
    public class LockVM
    {
        public int nitteino { get; set; }     //日程番号
        public string atenano { get; set; }     //宛名番号
        public DateTime upddttm { get; set; }   //更新日時(排他用)
    }

    /// <summary>
    /// 予約情報(詳細画面)
    /// </summary>
    public class DetailVM
    {
        public int? yoyakuno { get; set; }              //予約番号
        public bool taikiflg { get; set; }              //待機フラグ
        public int? jusinkingaku { get; set; }          //受診金額
        public int? kingaku_sityosonhutan { get; set; } //金額（市区町村負担）
        public string syokaiuketukeymd { get; set; }    //初回受付日
        public string biko { get; set; }                //備考
    }
}