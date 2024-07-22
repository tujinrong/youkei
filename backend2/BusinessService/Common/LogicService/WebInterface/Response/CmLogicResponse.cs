// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ロジック共通仕様処理
//             レスポンスインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.Common
{
    /// <summary>
    /// 初期化処理(パスワードポリシー)
    /// </summary>
    public class CmPwdInitResponse : DaResponseBase
    {
        public bool pwdflg { get; set; } = false;               //パスワードポリシー設定フラグ
        public bool numflg { get; set; } = false;               //半角数字フラグ
        public bool enflg { get; set; } = false;                //半角英字フラグ
        public bool symbolflg { get; set; } = false;            //半角記号フラグ
        public string symbolstr { get; set; } = string.Empty;   //使用可能記号
        public int? maxlen { get; set; } = null;                //最大文字数
    }
}