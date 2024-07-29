// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログイン
//             ビューモデル定義
// 作成日　　: 2024.07.12
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00101G
{
    /// <summary>
    /// ユーザー共通
    /// </summary>
    public class UserInfoVM
    {
        public string userid { get; set; }      //ユーザID
        public string usernm { get; set; }      //ユーザー名
        public List<string> roles { get; set; } //使用区分
        public bool kanrisyaflg { get; set; }   //管理者フラグ
        public string pSiyoKbn { get; set; }   


    }
}