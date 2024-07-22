// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 詳細条件検索
// 　　　　　　リクエストインターフェースベース
// 作成日　　: 2024.07.25
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00703D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        //public string kinoid { get; set; }   //機能ID
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード)
        public string? jigyocds { get; set; }   //実施事業(複数「,」で連結)
    }
}