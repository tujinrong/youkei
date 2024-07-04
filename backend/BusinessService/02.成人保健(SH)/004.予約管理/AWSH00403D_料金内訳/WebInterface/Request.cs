// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 料金内訳
//             リクエストインターフェース
// 作成日　　: 2024.02.26
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00403D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public int nendo { get; set; }          //年度
        public string atenano { get; set; }     //宛名番号
        public List<MoneyKeyBase2VM> kekkalist { get; set; }    //予約情報一覧
    }
}