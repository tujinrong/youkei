// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　レスポンスインターフェース
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00607D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public List<DaSelectorKeyModel> processingtypeList { get; set; }    //【処理種別】のドロップダウンリスト(nmcd,nm,kananm)
        public ProcedureVM procedureVM { get; set; }                        //プロシージャ情報
    }

    /// <summary>
    ///再読み込み処理
    /// </summary>
    public class ReSearchResponse : DaResponseBase
    {
        public ProcedureVM procedureVM { get; set; }   //プロシージャ情報
    }
}