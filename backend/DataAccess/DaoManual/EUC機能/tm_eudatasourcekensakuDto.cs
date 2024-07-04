// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUCデータソース検索マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourcekensakuDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_eudatasourcekensaku";
        public string datasourceid { get; set; }                  //データソースID
        public int jyokenid { get; set; }                    //条件ID
        public string sqlcolumn { get; set; }                     //SQLカラン
        public Enum検索条件区分 jyokenkbn { get; set; }            //検索条件区分
        public string jyokenlabel { get; set; }                   //ラベル
        public string? variables { get; set; }                    //変数名
        public string sql { get; set; }                           //SQL
        public Enumコントロール controlkbn { get; set; }            //コントロール区分
        public string? mastercd { get; set; }                     //名称マスタコード
        public string? masterpara { get; set; }                   //名称マスタパラメータ
        public string? sansyomotosql { get; set; }                //参照元SQL
        public EnumDataType datatype { get; set; }                //データ型
        public string? nendohanikbn { get; set; }                 //年度範囲区分
        public string? syokiti { get; set; }                      //初期値
        public string? aimaikbn { get; set; }                     //曖昧検索区分
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
        public string tablealias { get; set; }                     //テーブル名
    }
}
