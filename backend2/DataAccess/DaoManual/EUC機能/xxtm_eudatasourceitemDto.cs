// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUCデータソース項目マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_eudatasourceitemDtoxx : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_eudatasourceitem";
		public string datasourceid { get; set; }                  //データソースID
        public int itemseq { get; set; }                        //項目SEQ
        public string itemid { get; set; }                        //項目ID
		public string? sqlcolumn { get; set; }                    //SQLカラム
		public string itemhyojinm { get; set; }                   //表示名称
		public string daibunrui { get; set; }                     //大分類
		public string? tyubunrui { get; set; }                    //中分類
		public string? syobunrui { get; set; }                    //小分類
		public Enum使用区分 usekbn { get; set; }                   //使用区分
		public Enum出力項目区分 itemkbn { get; set; }               //出力項目区分
		public string? syukeikbn { get; set; }                    //集計項目区分
		public EnumDataType datatype { get; set; }                //データ型
		public string tablealias { get; set; }                    //テーブル別名
		public string? tablealias2 { get; set; }                  //テーブル別名2
		public string? mastercd { get; set; }                     //名称マスタコード
		public string? masterpara { get; set; }                   //名称マスタパラメータ
		public string reguserid { get; set; }                     //登録ユーザーID
		public DateTime regdttm { get; set; }                     //登録日時
		public string upduserid { get; set; }                     //更新ユーザーID
		public DateTime upddttm { get; set; }                     //更新日時
    }
}
