// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種検診対象者保守
//             ViewModel定義
// 作成日　　: 2024.02.05
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00302G
{
    /// <summary>
    /// 対象者情報(1行)
    /// </summary>
    public class PersonRowVM : AWKK00101G.RowBaseVM
    {
        public string adrs { get; set; }    //住所
    }
    /// <summary>
    /// 検診状況情報(1行)：ベース
    /// </summary>
    public class RowBaseVM
    {
        public string jigyocd { get; set; }     //検診事業コード
        public string kensahohocd { get; set; } //検査方法コード
    }
    /// <summary>
    /// 検診状況情報(1行)：レスポンス再表示用
    /// </summary>
    public class RowVM : RowBaseVM
    {
        public string age { get; set; }     //年齢
        public string sign2 { get; set; }   //対象サイン
    }
    /// <summary>
    /// 検診状況情報(1行)：レスポンス表示用
    /// </summary>
    public class Row2VM : RowVM
    {
        public string kensahoho { get; set; }   //成人健（検）診事業・検査方法
        public string sign1 { get; set; }       //一時対象サイン
        public bool kijunflg { get; set; }      //年齢基準日フラグ(false:指定日;true:受診日時点)
        public string kijunymd { get; set; }    //年齢計算基準日
    }
    /// <summary>
    /// 検診状況情報(1行)：リクエスト用
    /// </summary>
    public class Row3VM : RowBaseVM
    {
        public string sign1 { get; set; }       //一時対象サイン
        public string kijunymd { get; set; }    //年齢計算基準日
    }
}