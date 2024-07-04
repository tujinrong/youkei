// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 宛名検索履歴
//             ビューモデル定義
// 作成日　　: 2023.03.17
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00701D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchVM
    {
        public string atenano { get; set; }    //宛名番号
        public string name { get; set; }       //氏名
        public string kname { get; set; }      //カナ氏名
        public string bymd { get; set; }       //生年月日
        public string sex { get; set; }        //性別
    }
}