// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 料金内訳
//             ビューモデル定義
// 作成日　　: 2024.02.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00403D
{
    /// <summary>
    /// ヘッダー情報
    /// </summary>
    public class HeaderVM : CommonBarHeaderBaseVM
    {
        public string genmenkbn_tokutei { get; set; }   //減免区分（特定健診）名称
        public string genmenkbn_gan { get; set; }       //減免区分（がん検診）名称
    }
    /// <summary>
    /// 自己負担金情報(1件)
    /// </summary>
    public class RowVM
    {
        public string kensahoho { get; set; }   //成人健（検）診事業・検査方法
        public string jusinkingaku { get; set; }            //受診金額
        public string kingaku_sityosonhutan { get; set; }   //（市区町村負担）金額
    }
    /// <summary>
    /// 予約情報(1件)
    /// </summary>
    public class DetailVM
    {
        public string jigyocd { get; set; }         //検診種別
        public string kensahohocd { get; set; }     //検査方法コード
        public string kijunymd { get; set; }        //年齢基準日
        public string genmenkbn { get; set; }       //減免区分
        public string ryokinpattern { get; set; }   //料金パターン
    }
    /// <summary>
    /// 自己負担金キー
    /// </summary>
    public class MoneyKeyVM : MoneyKeyBase3VM
    {
        public string ryokinpattern { get; set; }   //料金パターン
        public string genmenkbn { get; set; }       //減免区分
        public string kijunymd { get; set; }        //年齢計算基準日
    }
    /// <summary>
    /// 自己負担金キー
    /// </summary>
    public class MoneyKeyBaseVM
    {
        public string jigyocd { get; set; }         //検診種別
        public int nitteino { get; set; }           //日程番号
    }
    /// <summary>
    /// 自己負担金キー(インタフェース用)
    /// </summary>
    public class MoneyKeyBase2VM : MoneyKeyBaseVM
    {
        public string kensahohocdnm { get; set; }   //検査方法(コード：名称)
    }
    /// <summary>
    /// 自己負担金キー(ロジック用)
    /// </summary>
    public class MoneyKeyBase3VM : MoneyKeyBaseVM
    {
        public string kensahohocd { get; set; }     //検査方法コード
    }
}