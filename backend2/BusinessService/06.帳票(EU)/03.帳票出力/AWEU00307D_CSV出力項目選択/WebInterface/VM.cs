// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: CSV出力項目選択
//             ビューモデル定義
// 作成日　　: 2024.02.26
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00307D
{
    /// <summary>
    /// 出力項目情報
    /// </summary>
    public class RowVM
    {
        public string reportitemid { get; set; }   //様式項目ID
        public string reportitemnm { get; set; }   //帳票項目名称
    }
}