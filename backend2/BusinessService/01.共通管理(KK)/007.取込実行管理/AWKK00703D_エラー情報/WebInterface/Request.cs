// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行.エラー一覧(行のエラー明細）
//             リクエストインターフェース
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00703D
{
    /// <summary>
    /// アップロード処理
    /// </summary>
    public class InitListRequest : DaRequestBase
    {
        public int impexeid { get; set; }   //取込実行ID
        public int rowno { get; set; }      //行番号
    }
}