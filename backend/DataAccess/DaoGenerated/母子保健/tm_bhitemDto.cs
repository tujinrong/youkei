// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             母子保健項目コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_bhitemDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_bhitem";
		public string bhsyurui { get; set; }                      //母子種類
		public string bhdatalistcd { get; set; }                  //母子データリストコード
		public string itemcd { get; set; }                        //項目コード
		public string itemnm { get; set; }                        //項目名
		public string? groupid { get; set; }                      //グループID
		public string? groupid2 { get; set; }                     //グループID2
		public int inputtype { get; set; }                        //入力タイプ
		public string? codejoken1 { get; set; }                   //コード条件1
		public string? codejoken2 { get; set; }                   //コード条件2
		public string? codejoken3 { get; set; }                   //コード条件3
		public string? keta { get; set; }                         //入力桁
		public bool hissuflg { get; set; }                        //必須フラグ
		public string? hanif { get; set; }                        //入力範囲（開始）
		public string? hanit { get; set; }                        //入力範囲（終了）
		public bool rirekiflg { get; set; }                       //履歴管理フラグ
		public bool hyojiflg { get; set; }                        //表示フラグ
		public int? hyojinendof { get; set; }                     //表示年度（開始）
		public int? hyojinendot { get; set; }                     //表示年度（終了）
		public bool inputflg { get; set; }                        //入力フラグ
		public int msgkbn { get; set; }                           //メッセージ区分
		public string? tani { get; set; }                         //単位
		public string? syokiti { get; set; }                      //初期値
		public string? keisankbn { get; set; }                    //計算区分
		public string? keisansusiki { get; set; }                 //計算数式
		public string? keisankansuid { get; set; }                //計算関数ID
		public string? keisanparam { get; set; }                  //計算パラメータ
		public bool kekkaflg { get; set; }                        //結果項目フラグ
		public string? riyokensahohocd { get; set; }              //利用検査方法コード
		public bool haitiflg { get; set; }                        //画面配置フラグ
		public int orderseq { get; set; }                         //並びシーケンス
		public string? biko { get; set; }                         //備考
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
