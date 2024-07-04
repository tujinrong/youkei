// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: EUC帳票ロジック処理
//
// 作成日　　: 2023.04.07
// 作成者　　: 呉
// 変更履歴　:
// *******************************************************************
using AIplus.AiReport;
using AIplus.AiReport.Common;
using AIplus.AiReport.DataEngines;
using AIplus.AiReport.Enums;
using AIplus.AiReport.Interface;
using AIplus.AiReport.Models;
using AIplus.AiReport.ReportDef;
using AIplus.AiReport.ReportDef.SheetDefs.Base;

namespace BCC.Affect.DataAccess
{
    public enum EnumReportType
    {
        PDF, EXCEL, PREVIEW, CSV, その他
    }

    /// <summary>
    /// 項目区分
    /// </summary>
    public enum EnumItemKbn
    {
        宛名番号 = 1, 個人番号, 宛名番号関連項目, その他
    }

    /// <summary>
    /// 操作区分
    /// </summary>
    public enum EnumUseKbn
    {
        追加 = 1, 更新, 削除, 検索
    }

    /// <summary>
    /// メーカワーク区分
    /// </summary>
    public enum EnumMakeWorkKbn
    {
        宛名ワークサブ = 0, 宛名番号ログ, その他
    }

    /// <summary>
    /// 出力区分
    /// </summary>
    public enum EnumSyutuKbn
    {
        EXCEL = 1,
        PDF,
        CSV
    }

    /// <summary>
    /// 実行モード
    /// </summary>
    public enum EnumSyutuMode
    {
        検索 = 1,
        出力
    }
}