// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 警告情報照会
//             ビューモデル定義
// 作成日　　: 2023.09.25
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00607D
{
    /// <summary>
    /// 警告情報(1件)
    /// </summary>
    public class SearchVM
    {
        public int rirekino { get; set; }           //履歴番号
        public string siensotiymdf { get; set; }    //支援措置開始年月日
        public string siensotiymdt { get; set; }    //支援措置終了年月日
        public string siensotikbn { get; set; }     //支援措置区分
        public string upddttm { get; set; }         //更新日時
        public string saisinflg { get; set; }       //最新フラグ
    }
}