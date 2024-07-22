// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログイン
//             レスポンスインターフェース
// 作成日　　: 
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00101G
{
    /// <summary>
    /// ログイン処理(成功)
    /// </summary>
    public class LoginResponse : DaResponseBase
    {
        public string token { get; set; }               //トークン(ベースロジック)
        public UserInfoVM userinfo { get; set; }        //ユーザー情報(共通)
        public List<CmSisyoVM> sisyolist { get; set; }  //支所リスト(登録支所選択用)
        public bool pwdmsgflg { get; set; }             //警告フラグ true:警告メッセージが出る(通知範囲以内の場合)
    }
}