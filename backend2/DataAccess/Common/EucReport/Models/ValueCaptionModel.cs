// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: EUC帳票ロジック処理
//
// 作成日　　: 2024.07.07
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