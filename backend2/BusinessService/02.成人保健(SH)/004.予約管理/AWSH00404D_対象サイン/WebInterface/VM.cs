// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 対象サイン
//             ビューモデル定義
// 作成日　　: 2024.02.27
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00404D
{
    /// <summary>
    /// 検診状況情報(1件)
    /// </summary>
    public class RowVM
    {
        public string jigyocd { get; set; }     //検診種別
        public string kensahohocd { get; set; } //検査方法コード
        public string age { get; set; }         //年齢
        public string sign2 { get; set; }       //対象サイン
        public string kensahoho { get; set; }   //成人健（検）診事業・検査方法
        public string sign1 { get; set; }       //一時対象サイン
        public bool kijunflg { get; set; }      //年齢基準日フラグ(false:指定日;true:受診日時点)
        public string kijunymd { get; set; }    //年齢計算基準日
        public string kyohiriyu { get; set; }   //受診拒否理由
    }
}