// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 成人健（検）診事業詳細検索設定
//             ViewModel定義
// 作成日　　: 2024.01.15
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00802D
{
    /// <summary>
    /// 並び順設定行モデル(表示用)
    /// </summary>
    public class SearchVM : SaveVM
    {
        public string hyojinm { get; set; } //詳細条件表示名
    }
    /// <summary>
    /// 並び順設定行モデル(保存用)
    /// </summary>
    public class SaveVM
    {
        public Enum詳細検索条件区分 jyokbn { get; set; }    //条件区分
        public int jyoseq { get; set; }                     //条件シーケンス
        public bool hyojiflg { get; set; }                  //表示フラグ
    }
}