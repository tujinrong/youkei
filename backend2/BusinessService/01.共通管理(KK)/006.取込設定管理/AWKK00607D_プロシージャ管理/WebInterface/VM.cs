// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込設定.プロシージャ管理画面
// 　　　　　　ビューモデル定義
// 作成日　　: 2023.10.09
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00607D
{
    /// <summary>
    /// プロシージャ情報モデル
    /// </summary>
    public class ProcedureVM
    {
        public string procseq { get; set; }     //プロシージャシーケンス		
        public string procnm { get; set; }      //プロシージャ名		
        public string prockbn { get; set; }     //プロシージャ区分		
        public string procsql { get; set; }     //内容		
    }

    /// <summary>
    /// パラメータタイプ
    /// </summary>
    public class ProcedureParameter
    {
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}