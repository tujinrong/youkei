// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 生活保護受給情報履歴履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00108D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }              //履歴No.
        public string fukusijimusyocd { get; set; }               //福祉事務所コード
        public string caseno { get; set; }                        //ケース番号
        public int inno { get; set; }                             //員番号
        public int ketteirirekino { get; set; }                   //決定履歴番号
        public int sinseirirekino { get; set; }         //申請履歴番号
        public string seihoymdf { get; set; }           //生活保護開始年月日
        public string teisiymd { get; set; }            //停止年月日
        public string teisikaijoymd { get; set; }       //停止解除年月日
        public string haisiymd { get; set; }            //廃止年月日
        public string upddttm { get; set; }             //更新日時
        public string saisinflg { get; set; }           //最新フラグ
    }
}