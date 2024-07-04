// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUC帳票項目マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eurptitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eurptitem";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int yosikieda { get; set; }                        //様式枝番
		public string yosikiitemid { get; set; }                  //様式項目ID
		public string reportitemnm { get; set; }                  //帳票項目名称
		public string csvitemnm { get; set; }                     //CSV項目名称
		public string? sqlcolumn { get; set; }                    //SQLカラム
		public string tablealias { get; set; }                    //テーブル別名
		public Enum並び替え orderkbn { get; set; }                 //並び替え
        public int? orderkbnseq { get; set; }                     //並び替えシーケンス
        public int? orderseq { get; set; }                        //並びシーケンス
		public bool reportoutputflg { get; set; }                 //帳票出力フラグ
		public bool csvoutputflg { get; set; }                    //CSV出力フラグ
		public bool headerflg { get; set; }                       //ヘッダーフラグ
		public bool kaipageflg { get; set; }                      //改ページフラグ
		public Enum出力項目区分 itemkbn { get; set; }               //項目区分
		public string? formatkbn { get; set; }                    //フォーマット区分
		public string? formatkbn2 { get; set; }                   //フォーマット区分2
		public string? formatsyosai { get; set; }                 //フォーマット詳細
		public int? height { get; set; }                          //高
		public int? width { get; set; }                           //幅
		public int? offsetx { get; set; }                         //X軸オフセット
		public int? offsety { get; set; }                         //Y軸オフセット
		public string? blankvalue { get; set; }                   //白紙表示
		public string? mastercd { get; set; }                     //名称マスタコード
		public string? masterpara { get; set; }                   //名称マスタパラメータ
		public string? keyvaluepairsjson { get; set; }            //複数のキー・値・ペアjson
		public string? crosskbn { get; set; }                     //集計区分
		//public string? syukeihoho { get; set; }                   //集計方法
		public string? kbn1 { get; set; }                         //小計区分
		public int? level { get; set; }                           //集計レベル
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
