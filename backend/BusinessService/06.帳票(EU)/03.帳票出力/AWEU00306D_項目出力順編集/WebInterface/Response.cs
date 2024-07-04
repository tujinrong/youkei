// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 項目出力順編集
//             レスポンスインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWEU00306D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorModel> selectorlist1 { get; set; } //ドロップダウンリスト(出力順)
        public List<DaSelectorModel> selectorlist2 { get; set; } //ドロップダウンリスト(項目)
        public string? sortptnno { get; set; }                   //出力順パターン番号
        public List<SortSubVM> sortsublist { get; set; }         //出力順の項目詳細リスト
        public DateTime? sortupddttm { get; set; }               //出力順更新日時
        public DateTime yosikiupddttm { get; set; }              //様式更新日時
    }

    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public List<SortSubVM> sortsublist { get; set; }         //出力順の項目詳細リスト
        public DateTime sortupddttm { get; set; }                //出力順更新日時
    }
}