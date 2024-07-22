// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票管理画面 
// 　　　　    ビューモデル定義　　 
// 作成日　　: 2024.01.16
// 作成者　　: ショウ
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00206D
{
    public class BaseReportVM
    {
        public string rptid { get; set; }       //帳票ID
        public string yosikiid { get; set; }    //様式ID
        public DateTime upddttm { get; set; }   //更新日時
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class BaseKoinReportVM : BaseReportVM
    {
        public bool koinnmflg { get; set; }     //市区町村長名の印字フラグ
        public bool koinpicflg { get; set; }    //電子公印の印字フラグ
        public bool dairisyaflg { get; set; }   //職務代理者適用フラグ
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class BaseContactInfoReportVM : BaseReportVM
    {
        public string toiawasesakicd { get; set; }  //問い合わせ先コード
        public string kacd { get; set; }            //課コード
        public string kakaricd { get; set; }        //係コード

    }

    /// <summary>
    /// 印字設定検索処理
    /// </summary>
    public class KoinReportVM : BaseKoinReportVM
    {
        public string rptnm { get; set; }   //帳票名
    }

    /// <summary>
    /// 問い合わせ先設定検索処理
    /// </summary>
    public class ContactInfoReportVM : BaseContactInfoReportVM
    {
        public string rptnm { get; set; }   //帳票名
        public string nm { get; set; }      //名称
        public string detail { get; set; }  //詳細
    }

    /// <summary>
    /// 市区町村長
    /// </summary>
    public class SonchoVM
    {
        public string sonchomei { get; set; }   //市区町村長名
        public DateTime? upddttm { get; set; }  //更新日時
    }

    /// <summary>
    /// 職務代理者
    /// </summary>
    public class DairishaVM
    {
        public string dairisha { get; set; }        //職務代理者
        public string dairimei { get; set; }        //職務代理名
        public DateTime? dairiymdf { get; set; }    //代理適用年月日（開始）
        public DateTime? dairiymdt { get; set; }    //代理適用年月日（終了）
        public DateTime? upddttm { get; set; }      //更新日時
    }
}