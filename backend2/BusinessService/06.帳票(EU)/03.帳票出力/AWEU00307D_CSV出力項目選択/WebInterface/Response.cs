// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: CSV出力項目選択
//             レスポンスインターフェース
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist { get; set; }    //ドロップダウンリスト(出力パターン)
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public string outputptnnm { get; set; }                    //出力パターン名
        public List<RowVM> kekkalist1 { get; set; }                //帳票項目リスト(全て)
        public List<string> kekkalist2 { get; set; }               //帳票項目リスト(出力用、ソート済)
        public DateTime? upddttm { get; set; }                     //更新日時
    }
}