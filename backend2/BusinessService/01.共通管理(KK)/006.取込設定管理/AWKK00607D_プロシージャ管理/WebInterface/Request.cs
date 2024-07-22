// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　リクエストインターフェース
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00607D
{
    /// <summary>
    /// 共通処理
    /// </summary>
    public class CommonRequest : DaRequestBase
    {
        public string procseq { get; set; }    //プロシージャシーケンス
    }

    /// <summary>
    /// 登録処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public ProcedureVM procedureVM { get; set; }    //プロシージャ情報
        public Enum編集区分 editkbn { get; set; }       //編集区分
    }
}