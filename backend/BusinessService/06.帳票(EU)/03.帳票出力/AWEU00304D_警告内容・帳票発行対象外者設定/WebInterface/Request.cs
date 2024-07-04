// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定			
//         　  リクエストインターフェース
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWEU00304D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchWarningsRequest : CmSearchRequestBase
    {
        public string rptid { get; set; }                                   //帳票ID
        public long? workseq { get; set; }                                  //ワークシーケンス
        public string yosikiid { get; set; }                                //様式ID
        public List<KensakuJyokenVM>? jyokenlist { get; set; }              //検索条件
        public List<DetailKensakuJyokenVM>? detailjyokenlist { get; set; }  //詳細検索条件

        public TyusyutuVM tyusyutuinfo { get; set; }                        //抽出パネル情報
    }

    /// <summary>
    /// 警告チェックの処理
    /// </summary>
    public class UpdateWarnCheckboxRequest : CmSearchRequestBase
    {
        public long workseq { get; set; }              //ワークシーケンス
        public string status { get; set; }             //ステータス
        public string atenano { get; set; }            //世帯番号
        public bool formflg { get; set; }              //出力フラグ 
        public bool formflgold { get; set; }           //出力フラグ
    }

    /// <summary>
    /// 警告内容の選ぶの処理
    /// </summary>
    public class UpdateWarningDetailsRequest : CmSearchRequestBase
    {
        public long workseq { get; set; }                               //ワークシーケンス
        public string status { get; set; }                              //ステータス 
        public List<WarningContentVM> warningContents { get; set; }     //警告内容情報リスト
    }
}