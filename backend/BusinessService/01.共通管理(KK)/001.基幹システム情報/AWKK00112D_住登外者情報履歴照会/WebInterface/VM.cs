// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者情報履歴照会
//             ビューモデル定義
// 作成日　　: 2023.11.24
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00112D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class RowVM
    {
        public int rirekinum { get; set; }          //履歴No.
        public int rirekino { get; set; }           //履歴番号
        public string name { get; set; }            //氏名
        public string juminjotai { get; set; }      //住民区分（住民種別内容、住民状態内容）
        public string idoymd { get; set; }          //異動年月日
        public string idojiyu { get; set; }         //異動事由（名称）
        public string adrs { get; set; }            //住所(住所_都道府県、住所_市区郡町村名、住所_町字、住所_番地号表記、住所_方書)
        public string upddttm { get; set; }         //更新日時
        public string saisin { get; set; }          //最新（名称）
    }
}