// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUC様式マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_euyosikiDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_euyosiki";
        public string rptid { get; set; }                         //帳票ID
        public string yosikiid { get; set; }                      //様式ID
        public Enum内外区分 naigaikbn { get; set; }                     //内外区分
        public string hakokbn { get; set; }                         //帳票発行履歴管理区分
        public bool? hakoflg { get; set; }                         //帳票発行履歴管理フラグ
        public int? himozukejyokenid { get; set; }                //様式紐付け条件ID
        public string? himozukevalue { get; set; }                //様式紐付け値
        public string? templatefilenm { get; set; }               //テンプレートファイル名
        public byte[] templatefiledata { get; set; }              //テンプレートファイル
        public int? endrow { get; set; }                          //テンプレート終了行
        public int? endcol { get; set; }                          //テンプレート終了列
        public int? pagesize { get; set; }                        //ページサイズ
        public bool? landscape { get; set; }                      //用紙の向き
        public bool koinnmflg { get; set; }                       //市区町村印字フラグ
        public bool koinpicflg { get; set; }                      //電子更新印字フラグ
        public bool dairisyaflg { get; set; }                     //職務代理者適用フラグ
        public string? kacd { get; set; }                         //課コード
        public string? kakaricd { get; set; }                     //係コード
        public string? toiawasesakicd { get; set; }               //問い合わせ先コード
        public bool gyomuflg { get; set; }                        //業務画面使用フラグ
        public bool updateflg { get; set; }                       //更新フラグ
        public string updatesql { get; set; }                     //更新プロシージャ/SQL
        public bool tutisyoflg { get; set; }                      //通知書出力フラグ
        public bool pdfflg { get; set; }                          //PDF出力フラグ
        public bool excelflg { get; set; }                        //EXCEL出力フラグ
        public bool otherflg { get; set; }                        //その他出力フラグ
        public int? sortptnno { get; set; }                       //出力順パターン
        public int? outputptnno { get; set; }                     //CSV出力パターン
        public int orderseq { get; set; }                         //並び順
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
