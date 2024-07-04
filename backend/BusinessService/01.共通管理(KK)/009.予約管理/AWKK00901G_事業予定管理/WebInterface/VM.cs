// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業予定管理
//             ビューモデル定義
// 作成日　　: 2024.03.04
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00901G
{
    /// <summary>
    /// 日程情報(1件)
    /// </summary>
    public class NitteiRowVM
    {
        public int nitteino { get; set; }           //日程番号
        public string gyomukbnnm { get; set; }      //業務区分名
        public string jigyonm { get; set; }         //その他日程事業・保健指導事業名
        public string jissinaiyo { get; set; }      //実施内容
        public string jissiyoteiymd { get; set; }   //実施予定日
        public string time { get; set; }            //開始時間～終了時間
        public string kaijonm { get; set; }         //会場名
        public string kikannm { get; set; }         //医療機関名
        public string staffidnms { get; set; }      //担当者名(複数)
        public int teiin { get; set; }              //定員
    }
    /// <summary>
    /// コース情報(1件)
    /// </summary>
    public class CourseRowVM
    {
        public int courseno { get; set; }       //コース番号
        public string gyomukbnnm { get; set; }  //業務区分名
        public string coursenm { get; set; }    //コース名
        public int kaisu { get; set; }          //回数
        public string jissikikan { get; set; }  //実施期間
    }
    /// <summary>
    /// 日程情報(ヘッダー)
    /// </summary>
    public class NitteiHeaderVM
    {
        public string gyomukbn { get; set; }    //業務区分
        public string regsisyonm { get; set; }  //登録支所名
    }
    /// <summary>
    /// 日程情報(明細)
    /// </summary>
    public class NitteiDetailVM
    {
        public string jigyocdnm { get; set; }       //その他日程事業・保健指導事業(コード：名称)
        public string jissinaiyo { get; set; }      //実施内容
        public string jissiyoteiymd { get; set; }   //実施予定日
        public string tmf { get; set; }             //開始時間
        public string tmt { get; set; }             //終了時間
        public string kaijocdnm { get; set; }       //会場(コード：名称)
        public string kikancdnm { get; set; }       //医療機関(コード：名称)
        public List<string> staffids { get; set; }  //担当者(複数)
        public int? teiin { get; set; }             //定員
        public bool editflg { get; set; }           //編集フラグ(事業)
    }
    /// <summary>
    /// コース情報(ヘッダー)
    /// </summary>
    public class CourseHeaderVM : NitteiHeaderVM
    {
        public string coursenm { get; set; }    //コース名
    }
    /// <summary>
    /// コース情報(明細)
    /// </summary>
    public class CourseDetailVM : NitteiDetailVM
    {
        public int? nitteino { get; set; }  //日程番号
        public int kaisu { get; set; }      //回数
    }
}