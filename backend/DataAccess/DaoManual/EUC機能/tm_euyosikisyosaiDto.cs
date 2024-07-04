// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUC様式詳細マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_euyosikisyosaiDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_euyosikisyosai";
		public string rptid { get; set; }                         //帳票ID
		public string yosikiid { get; set; }                      //様式ID
		public int yosikieda { get; set; }                        //様式枝番
		public string yosikinm { get; set; }                      //様式名
		public Enum様式種別 yosikisyubetu { get; set; }                 //様式種別
		public Enum様式種別詳細 yosikikbn { get; set; }                     //様式種別詳細
		public bool meisaiflg { get; set; }                       //明細有無
		public string? meisaikoteikbn { get; set; }               //行（列）固定区分
		public Enum様式作成方法 yosikihouhou { get; set; }                  //様式作成方法
		public string? datasourceid { get; set; }                 //データソースID
		public int? himozukejyokenid { get; set; }                //様式紐付け条件ID
		public string? sql { get; set; }                          //SQL
		public string? procnm { get; set; }                       //プロシージャ名
		public bool distinctflg { get; set; }                     //重複データ排除フラグ
		public bool nulltozeroflg { get; set; }                   //空白値ゼロ出力フラグ
		public int? startrow { get; set; }                        //テンプレート明細開始行
		public int? loopmaxrow { get; set; }                      //１ページあたりの最大行数
		public int? looprow { get; set; }                         //1明細あたりの行数
		public int? startcol { get; set; }                        //明細開始列数
		public int? loopmaxcol { get; set; }                      //１ページあたりの最大列数
		public int? loopcol { get; set; }                         //1明細あたりの列数
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
