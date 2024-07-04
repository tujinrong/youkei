// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.マッピング設定情報ダイアログ画面
//             レスポンスインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00603D
{
    /// <summary>
    /// 初期化処理(取込設定：マッピング設定情報ダイアログ画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        //ドロップダウンリストの初期化データ
        public List<DaSelectorModel> mappingkbnList { get; set; }           //【マッピング区分】のドロップダウンリスト
        public List<DaSelectorKeyModel> mappingmethodList { get; set; }     //【マッピング方法】のドロップダウンリスト
        public List<DaSelectorModel> fileitemseqList { get; set; }          //【ファイル項目】のドロップダウンリスト
        public List<DaSelectorModel> hikisukbnList { get; set; }          　//【引数区分】のドロップダウンリスト
    }

    /// <summary>
    /// 【マッピング方法】初期化処理
    /// </summary>
    public class InitMappingMethodResponse : DaResponseBase
    {
        public List<DaSelectorKeyModel> mappingmethodList { get; set; }     //【マッピング方法】のドロップダウンリスト
    }
}