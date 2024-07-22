// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eurpt";
		public string rptid { get; set; }                         //帳票ID
		public string rptnm { get; set; }                         //帳票名
		public string rptgroupid { get; set; }                    //帳票グループID
		public string? datasourceid { get; set; }                 //データソースID
		public bool tyusyutupanelflg { get; set; }                //抽出パネル表示フラグ
		public string? yosikihimonm { get; set; }                 //様式紐付け名
		public bool atenaflg { get; set; }                        //宛名フラグ
		public bool ninsanpuflg { get; set; }                     //妊産婦フラグ
		public bool addresssealflg { get; set; }                  //アドレスシールフラグ
		public bool barcodesealflg { get; set; }                  //バーコードシール出力フラグ
		public bool hagakiflg { get; set; }                       //はがき出力フラグ
		public bool atenadaityoflg { get; set; }                  //宛名台帳出力フラグ
		public bool kensuhyonenreiflg { get; set; }               //件数表(年齢別)出力フラグ
		public bool kensuhyogyoseikuflg { get; set; }             //件数表(行政区別)出力フラグ
		public string? sql { get; set; }                          //SQL
		public string? procnm { get; set; }                       //プロシージャ名
		public int orderseq { get; set; }                         //並びシーケンス
		public string? rptbiko { get; set; }                      //帳票説明
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
