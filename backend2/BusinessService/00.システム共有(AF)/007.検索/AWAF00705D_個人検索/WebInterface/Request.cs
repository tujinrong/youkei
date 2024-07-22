// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 個人検索
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2024.04.01
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00705D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string name { get; set; }            //氏名
        public string kname { get; set; }           //カナ氏名
        public string bymd { get; set; }            //生年月日
        public string[] sex { get; set; }           //性別
        public string[] juminkbn { get; set; }      //住民区分
        public string hokenkbn { get; set; }        //保険区分
    }
}