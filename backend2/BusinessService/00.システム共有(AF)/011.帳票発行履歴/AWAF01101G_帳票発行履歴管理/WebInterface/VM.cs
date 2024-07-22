// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票発行履歴管理
//           ビューモデル定義
// 作成日　　: 2024.03.22
// 作成者　　: 千秋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF01101G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class RowVM
    {
        public string rptnm { get; set; }                　  //帳票名
        public string yosikinm { get; set; }                 //様式名
        public string nendo { get; set; }              　　  //年度
        public string hakkodttm { get; set; }                //発行日時
        public string hakkoninsu { get; set; }      　       //発行人数
        public string taisyocd { get; set; }                 //抽出対象
    }

}