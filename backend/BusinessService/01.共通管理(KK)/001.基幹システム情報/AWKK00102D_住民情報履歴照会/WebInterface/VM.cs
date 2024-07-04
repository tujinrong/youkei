// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住民情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.10.10
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00102D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int kojinrirekino { get; set; }      //個人履歴番号
        public int kojinrireki_edano { get; set; }  //個人履歴番号_枝番号
        public string name { get; set; }            //氏名
        public string juminjotai { get; set; }      //住民状態
        public string idoymd { get; set; }          //異動年月日
        public string idojiyu { get; set; }         //異動事由
        public string adrs { get; set; }            //住所(住所_町字、住所_番地号表記、住所_方書)
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
    }
}