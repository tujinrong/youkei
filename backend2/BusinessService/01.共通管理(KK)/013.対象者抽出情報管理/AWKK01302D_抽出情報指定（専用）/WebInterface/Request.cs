// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 抽出情報指定（専用）
//             リクエストインターフェース
// 作成日　　: 2024.06.03
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK01302D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitRequest : DaRequestBase { }
    /// <summary>
    /// 個別除外チェック（個別抽出の場合のみ）
    /// </summary>
    public class CheckRequest : DaRequestBase
    {
        public string tyusyututaisyocd { get; set; }            //抽出対象コード
        public string atenano { get; set; }                     //宛名番号
        public int? nendo { get;set; }                          //年度（年度管理されている場合）
    }
}