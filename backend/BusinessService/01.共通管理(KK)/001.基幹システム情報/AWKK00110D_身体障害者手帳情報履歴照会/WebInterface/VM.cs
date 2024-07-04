// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 身体障害者手帳情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00110D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }              //履歴No.
        public int rirekino { get; set; }               //履歴番号
        public string tetyono { get; set; }             //手帳番号
        public string henkanymd { get; set; }           //返還日
        public string syokaikofuymd { get; set; }       //初回交付日
        public string syogaisyubetunm { get; set; }     //障害種別(名称)
        public string sogotokyunm { get; set; }         //総合等級(名称)
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
    }
}