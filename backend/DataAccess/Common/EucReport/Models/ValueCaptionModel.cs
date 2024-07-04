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
    public class ValueCaptionModel
    {
        //values
        public string value { get; set; }

        //captions
        public string caption { get; set; }
    }
 
}