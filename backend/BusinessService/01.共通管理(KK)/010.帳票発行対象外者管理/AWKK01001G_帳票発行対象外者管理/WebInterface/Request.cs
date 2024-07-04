// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象外者管理
//             リクエストインターフェース
// 作成日　　: 2023.12.22
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK01001G
{
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public Enum名称区分 kbn { get; set; }   //名称区分(処理区分)
    }

    /// <summary>
    /// 保存処理(詳細画面)
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string atenano { get; set; }         //宛名番号
        public List<SaveVM> savelist { get; set; }  //保存リスト
        public List<LockVM> locklist { get; set; }  //排他チェック用リスト
    }
}