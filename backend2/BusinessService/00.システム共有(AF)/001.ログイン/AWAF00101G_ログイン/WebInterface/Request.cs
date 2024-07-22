// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログイン
//             リクエストインターフェース
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00101G
{
    /// <summary>
    /// ログイン処理
    /// </summary>
    public class LoginRequest : DaRequestBase
    {
        public string pword { get; set; }           //パスワード
        public Enumログイン区分 kbn { get; set; }   //ログイン区分
    }
}