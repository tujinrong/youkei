// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 納税義務者情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00104D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int kazeinendo { get; set; }         //課税年度
        public int kojinrirekino { get; set; }      //個人履歴番号
        public string misinkokukbn { get; set; }    //未申告区分
        public string takazeikbn { get; set; }      //他団体課税対象者区分
        public string takazeisikunm { get; set; }   //他団体課税対象者の課税先市区町村(名称)
        public string tosi_gyoseikunm { get; set; } //指定都市_行政区等(名称)
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
    }
}