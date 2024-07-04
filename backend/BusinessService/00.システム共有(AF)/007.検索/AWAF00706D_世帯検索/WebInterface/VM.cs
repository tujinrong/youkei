// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 世帯検索
// 　　　　　　ビューモデル定義
// 作成日　　: 2023.11.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00706D
{
    /// <summary>
    /// 世帯情報モデル
    /// </summary>
    public class SearchVM
    {
        public string setaino { get; set; }             //世帯番号
        public string atenano { get; set; }             //宛名番号
        public string name { get; set; }                //氏名
        public string sex { get; set; }                 //性別
        public string? bymd { get; set; }               //生年月日
        public string juminkbn { get; set; }            //住民区分
        public string adrs_yubin { get; set; }          //郵便番号
        public string adrs { get; set; }                //住所
    }
}