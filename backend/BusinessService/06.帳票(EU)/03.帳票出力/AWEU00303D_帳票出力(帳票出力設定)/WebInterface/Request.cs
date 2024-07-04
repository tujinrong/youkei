// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(帳票出力設定)
//             リクエストインターフェース
// 作成日　　: 2023.04.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************

using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00303D
{
    /// <summary>
    /// プレビュー処理
    /// </summary>
    public class PreviewRequest : CommonRequest
    {
        public new const EnumReportType outputtype = EnumReportType.PREVIEW;    //出力方式
        public int pagesize { get; set; } = 20;                                 //ページサイズ
        public int pagenum { get; set; } = 1;                                   //ページNo.
    }

    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : CommonRequest
    {
    }

    /// <summary>
    /// 共通
    /// </summary>
    public class CommonRequest : DaRequestBase
    {
        public long workseq { get; set; }                                   //ワークシーケンス 
        public string rptid { get; set; }                                   //帳票ID
        public string yosikiid { get; set; }                                //様式ID
        public string outputfilenm { get; set; }                            //出力名
        public string? memo;                                                //検索条件メモ
        public List<string>? selectedatenanolist { get; set; }              //選択した宛名番号リスト
        public List<KensakuJyokenVM>? jyokenlist { get; set; }              //検索条件
        public List<DetailKensakuJyokenVM>? detailjyokenlist { get; set; }  //詳細検索条件
        public EnumReportType outputtype { get; set; }                      //出力方式
        public bool sqljikkoflg { get; set; }                               //更新SQL
        public bool hakusiflg { get; set; }                                 //白纸
        public bool jyokensheetflg { get; set; }                            //条件シートを出力
        public bool rirekiupdflg { get; set; }                              //発送履歴テーブル更新

        public TyusyutuVM tyusyutuinfo { get; set; }                        //抽出パネル情報
        public OutPutInfoVM? outPutInfo { get; set; }                       //出力情報
    }

    /// <summary>
    /// バッチ処理
    /// </summary>
    public class BatchRequest : DownloadRequest
    {
        public DateTime executiontime { get; set; } 　　　　//実行日時
        public bool checkflg { get; set; } = false;         //チェックフラグ
    }
}