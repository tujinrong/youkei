// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 受診拒否設定
//             リクエストインターフェース
// 作成日　　: 2024.02.06
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWSH00303D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public int nendo { get; set; }      //年度
        public string atenano { get; set; } //宛名番号
    }
    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : InitRequest
    {
        public List<SaveRowVM> kekkalist { get; set; }  //受診拒否理由情報一覧
    }
}