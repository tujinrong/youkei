// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診予約希望者管理
//             ViewModel定義
// 作成日　　: 2024.02.20
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00402G
{
    /// <summary>
    /// 日程基本情報
    /// </summary>
    public class HeaderVM
    {
        public string jigyonm { get; set; }     //成人健（検）診予約日程事業名
        public string yoteiymd { get; set; }    //実施予定日
        public string timef { get; set; }       //開始時間
        public string timet { get; set; }       //終了時間
        public string kaijonm { get; set; }     //会場名
        public string kikannm { get; set; }     //医療機関名
        public string staffnms { get; set; }    //担当者一覧
    }

    /// <summary>
    /// 予約情報
    /// </summary>
    public class RowVM
    {
        public string title { get; set; }           //タイトル
        public string status { get; set; }          //状態
        public string teiin { get; set; }           //定員
        public string moshikominum { get; set; }    //申込人数
        public string taikinum { get; set; }        //待機数
    }

    /// <summary>
    /// 希望者情報
    /// </summary>
    public class PersonVM : CommonBarHeaderBase3VM
    {
        public string kazeikbn_setai { get; set; }      //課税非課税区分（世帯）
        public string hokenkbn { get; set; }            //保険区分
        public string genmenkbn_tokutei { get; set; }   //減免区分（特定健診）
        public string genmenkbn_gan { get; set; }       //減免区分（がん検診）
    }

    /// <summary>
    /// 予約情報(保存用)
    /// </summary>
    public class DetailRowSaveVM : DetailRowKeyVM
    {
        public int? nitteino { get; set; }              //日程番号
        public bool taikiflg { get; set; }              //待機フラグ
        public string syokaiuketukeymd { get; set; }    //初回受付日
        public string henkouketukeymd { get; set; }     //受付変更日
    }
    /// <summary>
    /// 予約情報(表示用)
    /// </summary>
    public class DetailRowVM : DetailRowSaveVM
    {
        public string jigyonm { get; set; }                             //検診名
        public string yoteiymd { get; set; }                            //実施予定日
        public string time { get; set; }                                //時間範囲
        public string status { get; set; }                              //状態
        public string cupon { get; set; }                               //クーポン
        public EnumMsgCtrlKbn yoyakuchk { get; set; }                   //予約画面チェック区分
        public List<DaSelectorDisabledModelSign> selectorlist { get; set; } //検査方法一覧
        public bool editflg { get; set; }                               //編集フラグ(false:①該当日程事業含まない検診②検査方法全て対象外③受診済)
    }
    public class DaSelectorDisabledModelSign : DaSelectorDisabledModel
    {
        public string sign { get; set; }                                //対象サイン
        public bool? flg1 { get; set; }                                  //昨年フラグ(false:受診済)
        public bool? flg2 { get; set; }                                  //今年フラグ(false:受診済)
        public DaSelectorDisabledModelSign(string? value, string? label, string? sign, bool? flg1, bool? flg2, bool? disabled = false) : base(value, label, disabled)
        {
            this.sign = sign ?? string.Empty;
            this.flg1 = flg1;
            this.flg2 = flg2;
        }
    }
    /// <summary>
    /// 予約情報(チェック用)
    /// </summary>
    public class DetailRowKeyVM
    {
        public string jigyocd { get; set; }         //検診種別
        public string kensahohocdnm { get; set; }   //検査方法(コード：名称)
    }
    /// <summary>
    /// 対象検査方法
    /// </summary>
    public class Row2VM
    {
        public string jigyocd { get; set; }     //検診種別
        public string kensahohocd { get; set; } //検査方法コード
        public bool flg1 { get; set; }          //昨年フラグ(false:受診済)
        public bool flg2 { get; set; }          //今年フラグ(false:受診済)
        public bool flg3 { get; set; }          //対象フラグ(true:対象)
    }

    /// <summary>
    /// 自己負担金
    /// </summary>
    public class MoneyVM
    {
        public string jusinkingaku { get; set; }            //受診金額
        public string kingaku_sityosonhutan { get; set; }   //（市区町村負担）金額
    }
}