// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 詳細条件検索
// 　　　　　　レスポンスインターフェースベース
// 作成日　　: 2024.07.25
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using static BCC.Affect.Service.CmFilterVM;
namespace BCC.Affect.Service.AWAF00703D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<CommonFilterVM> leftlist { get; set; }     //共通(左)リスト
        public List<CommonFilterVM> rightlist { get; set; }    //独自(右)リスト
    }
}