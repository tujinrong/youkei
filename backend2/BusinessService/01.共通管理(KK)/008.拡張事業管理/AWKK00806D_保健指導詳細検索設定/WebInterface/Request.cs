// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 保健指導詳細検索設定
//             リクエストインターフェース
// 作成日　　: 2024.01.24
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00806D
{
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public List<AWKK00802D.SaveVM> kekkalist { get; set; }  //画面一覧
    }
}