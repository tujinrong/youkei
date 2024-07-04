// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 自己負担金情報保守
//             ビューモデル定義
// 作成日　　: 2024.03.05
// 作成者　　: CNC劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00601G
{
    /// <summary>
    /// 検索処理(検索結果一覧)
    /// </summary>
    public class RowVM : LockVM
    {
        public int jusinkingaku { get; set; }           //受診金額
        public int kingaku_sityosonhutan { get; set; }  //金額（市区町村負担）
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public string kensin_jigyocd { get; set; }         //成人健（検）診事業コード
        public string ryokinpattern { get; set; }          //料金パターン
        public string kensahohocd { get; set; }            //検査方法
        public string sex { get; set; }                    //性別
        public string genmenkbncd { get; set; }            //減免区分
        public string agehani { get; set; }                //年齢範囲
        public DateTime? upddttm { get; set; }             //更新日時
    }
}