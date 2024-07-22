// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.マッピング設定情報ダイアログ画面
//             リクエストインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00603D
{
    /// <summary>
    /// 初期化処理(取込設定：マッピング設定情報ダイアログ画面)
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public string mappingkbn { get; set; }          //マッピング区分（【マッピング方法】ロップダウン初期化時用）
        public List<string> fileitemList { get; set; }  //取込ファイルIF情報の（ファイル項目ID,項目名）のリスト
        public Enum編集区分 editkbn { get; set; }       //編集区分
    }

    /// <summary>
    /// ドロップダウン初期化(マッピング方法)
    /// </summary>
    public class InitMappingMethodRequest : DaRequestBase
    {
        public string mappingkbn { get; set; } //マッピング区分
    }
}