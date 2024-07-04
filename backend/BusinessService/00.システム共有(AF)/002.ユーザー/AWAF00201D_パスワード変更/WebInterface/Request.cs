// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: パスワード変更
//             リクエストインターフェース
// 作成日　　: 2023.01.19
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00201D
{
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public string oldpword { get; set; }    // 旧パスワード
        public string newpword { get; set; }    // 新パスワード
    }
}