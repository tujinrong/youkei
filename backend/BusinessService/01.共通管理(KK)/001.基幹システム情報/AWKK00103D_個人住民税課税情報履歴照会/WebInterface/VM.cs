// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 個人住民税課税情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00103D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int kazeinendo { get; set; }         //課税年度
        public int kazeirirekino { get; set; }      //課税情報履歴番号
        public string kazeikbn { get; set; }        //課税非課税区分
        public string tosi_gyoseikunm { get; set; } //指定都市_行政区等(名称)
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
    }
}