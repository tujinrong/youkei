// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 医療機関検索
//             ビューモデル定義
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00702D
{
    /// <summary>
    /// 医療機関情報モデル
    /// </summary>
    public class SearchVM
    {
        public string kikancd { get; set; }         //医療機関コード（自治体独自）
        public string hokenkikancd { get; set; }    //保険医療機関コード
        public string kikannm { get; set; }         //医療機関名
        public string kanakikannm { get; set; }     //医療機関名カナ
        public string adrsfull { get; set; }        //住所
    }
}