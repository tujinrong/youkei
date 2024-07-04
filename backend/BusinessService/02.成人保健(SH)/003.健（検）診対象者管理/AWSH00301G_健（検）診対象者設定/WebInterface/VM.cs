// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 健（検）診対象者設定
//             ViewModel定義
// 作成日　　: 2024.01.30
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00301G
{
    /// <summary>
    /// 行モデル(事業単位)
    /// </summary>
    public class RowVM
    {
        public string jigyocd { get; set; }         //成人健（検）診事業コード
        public List<HohoRowVM> rows { get; set; }   //検査方法単位情報
    }
    /// <summary>
    /// 行モデル(検査方法単位)
    /// </summary>
    public class HohoRowVM
    {
        public string? kensahohocd { get; set; }    //検査方法コード
        public string sex { get; set; }             //性別コード
        public string age { get; set; }             //年齢コード
        public string kijunkbn { get; set; }        //年齢基準日区分コード
        public string kijunymd { get; set; }        //年齢計算基準日
        public string hokenkbn { get; set; }        //保険区分コード
        public string tokusyu { get; set; }         //特殊コード
        public string sql { get; set; }             //SQL文
    }
    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public string jigyocd { get; set; }         //成人健（検）診事業コード
        public string? kensahohocd { get; set; }    //検査方法コード
        public DateTime upddttm { get; set; }       //更新日時
    }
}