// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票出力(CSV出力設定)
//             リクエストインターフェース
// 作成日　　: 2024.07.05
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using AIplus.AiReport.Enums;
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00302D
{
    /// <summary>
    /// CSV出力設定初期化処理
    /// </summary>
    public class DetailInitRequest : DaRequestBase
    {
        public string rptid { get; set; }       //帳票ID
        public string yosikiid { get; set; }    //様式ID
    }

    /// <summary>
    /// ダウンロード処理
    /// </summary>
    public class DownloadRequest : DaRequestBase
    {
        public long workseq { get; set; }                                       //ワークシーケンス 
        public string rptid { get; set; }                                       //帳票ID
        public string yosikiid { get; set; }                                    //様式ID
        public string outputfilenm { get; set; }                                //出力名
        public string? memo;                                                    //検索条件メモ
        public ArEnumEncoding csvencoding { get; set; } = ArEnumEncoding.UTF8;  //文字セット
        public List<AtenaVM>? selecteddatalist { get; set; }                    //選択したデータ
        public bool csvbom { get; set; } = false;                               // bom
        public bool csvoutputheader { get; set; } = true;                       // CSV出力ヘッダータグ
        public string? csvquotation { get; set; }                     　　　　　// CSV出力囲み文字
        public string csvpattern { get; set; }                                  // CSV出力パターン
        public List<KensakuJyokenVM>? jyokenlist { get; set; }                  //検索条件
        public List<DetailKensakuJyokenVM>? detailjyokenlist { get; set; }      //詳細検索条件
        public bool sqljikkoflg { get; set; }                                   //更新SQL
        public bool hakusiflg { get; set; }                                     //白纸
        public bool jyokensheetflg { get; set; }                                //条件シートを出力
        public bool rirekiupdflg { get; set; }                                  //発送履歴テーブル更新

        public TyusyutuVM tyusyutuinfo { get; set; }                            //抽出パネル情報
    }
}