// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 対象サイン
//             レスポンスインターフェース
// 作成日　　: 2024.02.27
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWSH00404D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchResponse : DaResponseBase
    {
        public CommonBarHeaderBaseVM headerinfo { get; set; }  //個人基本情報
        public List<RowVM> kekkalist { get; set; }      //検診状況一覧
    }
}