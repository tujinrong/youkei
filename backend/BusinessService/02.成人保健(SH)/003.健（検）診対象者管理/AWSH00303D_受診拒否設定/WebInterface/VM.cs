// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 受診拒否設定
//             ViewModel定義
// 作成日　　: 2024.02.06
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00303D
{
    /// <summary>
    /// 受診拒否理由情報(1行)：表示用
    /// </summary>
    public class InitRowVM : SaveRowVM
    {
        public string jigyonm { get; set; }         //成人健（検）診事業名
    }
    /// <summary>
    /// 受診拒否理由情報(1行)：保存用
    /// </summary>
    public class SaveRowVM
    {
        public string jigyocd { get; set; }         //成人健（検）診事業コード
        public string kyohiriyucdnm { get; set; }   //受診拒否理由(コード：名称)
    }
}