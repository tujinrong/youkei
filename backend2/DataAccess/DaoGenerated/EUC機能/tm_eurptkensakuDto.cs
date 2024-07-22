// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUC帳票検索マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptkensakuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eurptkensaku";
		public int jyokenseq { get; set; }                        //条件シーケンス
		public string rptid { get; set; }                         //帳票ID
		public string? datasourceid { get; set; }                 //データソースID
		public int? jyokenid { get; set; }                        //条件ID
		public string? jyokenkbn { get; set; }                    //検索条件区分
		public string? jyokenlabel { get; set; }                  //ラベル
		public string? variables { get; set; }                    //変数名
		public string? sql { get; set; }                          //SQL
		public string? tablealias { get; set; }                   //テーブル別名
		public int? controlkbn { get; set; }                      //コントロール区分
		public string? mastercd { get; set; }                     //名称マスタコード
		public string? masterpara { get; set; }                   //名称マスタパラメータ
		public string? sansyomotosql { get; set; }                //参照元SQL
		public bool? hissuflg { get; set; }                       //必須フラグ
		public int? orderseq { get; set; }                        //並びシーケンス
		public int? datatype { get; set; }                        //データ型
		public string? nendohanikbn { get; set; }                 //年度範囲区分
		public string? syokiti { get; set; }                      //初期値
		public string? aimaikbn { get; set; }                     //曖昧検索区分
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
