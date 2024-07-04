// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             抽出情報マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_kktyusyutuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_kktyusyutu";
		public string tyusyututaisyocd { get; set; }              //抽出対象コード
		public string tyusyututaisyonm { get; set; }              //抽出対象名
		public string rptid { get; set; }                         //帳票ID
		public string? tyusyutudatasyosaikbn { get; set; }        //抽出データ詳細区分
		public string syosaikbnmaincd { get; set; }               //詳細区分メインコード
		public int syosaikbnsubcd { get; set; }                   //詳細区分サブコード
		public string tuticycle { get; set; }                     //通知サイクル
		public bool saityusyutujogaiflg { get; set; }             //再抽出除外フラグ
		public bool sinkidatatenyuryokuflg { get; set; }          //新規入力フラグ
		public bool hakkeninfoflg { get; set; }                   //発券情報管理フラグ
		public string? tyusyutukinoid { get; set; }               //抽出画面機能ID
		public string storedfunction { get; set; }                //ストアドファンクション
		public int orderseq { get; set; }                         //並びシーケンス
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
