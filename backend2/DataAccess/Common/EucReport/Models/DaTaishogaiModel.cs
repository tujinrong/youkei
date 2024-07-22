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

    public class DaTaishogaiModel
    {
        public long workseq { get; set; }                         // workId
        public string atenano { get; set; }                       //宛名番号
        public string simei { get; set; }                         //氏名
        public string? sexhyoki { get; set; }                     //性別表記
        public string? adrs2 { get; set; }                        //住所2
        public string? gyoseikucd { get; set; }                   //指定都市_行政区等コード
        public bool formflg { get; set; }                         //出力フラグ
        public bool taisyoflg { get; set; }                       //対象外者フラグ
        public bool taisyooutflg { get; set; }                    //対象外出力可能フラグ
        public string? taisyogairiyu { get; set; }                //対象外理由
        public bool alertviewflg { get; set; }                    //警告参照
        public string taisyogaikbn { get; set; }                  //対象外区分
        public string keikoku { get; set; }                       //警告内容
        public string siensotikbn { get; set; }                   //支援措置区分

    }
}