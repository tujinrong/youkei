// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人検索
// 　　　　　　ビューモデル定義
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00705D
{
    /// <summary>
    /// 個人情報モデル
    /// </summary>
    public class SearchVM
    {
        public string atenano { get; set; }             //宛名番号
        public string name { get; set; }                //氏名
        public string kname { get; set; }               //カナ氏名
        public string sex { get; set; }                 //性別
        public string bymd { get; set; }                //生年月日
        public string adrs { get; set; }                //住所
        public string gyoseiku { get; set; }            //行政区
        public string juminkbn { get; set; }            //住民区分
        public string hokenkbn { get; set; }            //保険区分
        public string keikoku { get; set; }             //警告内容

    }
}