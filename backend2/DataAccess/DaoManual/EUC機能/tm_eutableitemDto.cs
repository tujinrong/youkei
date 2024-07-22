// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             EUCテーブル項目マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.DataAccess
{
    public class tm_eutableitemDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_eutableitem";
        public const int EDITABLE_ITEM_ID_MIN_PREFIX = 100;
        public const int EDITABLE_ITEM_ID_MAX_PREFIX = 199;

        public string sqlcolumn { get; set; } //SQLカラム
        public string itemid { get; set; } //項目ID
        public string itemhyojinm { get; set; } //表示名称
        public int orderseq { get; set; } //並びシーケンス
        public EnumDataType datatype { get; set; } //データ型
        public bool selectflg { get; set; } //既定選択フラグ
        public Enum使用区分 usekbn { get; set; } //使用区分
        public Enum出力項目区分 itemkbn { get; set; } //出力項目区分
        public string? syukeikbn { get; set; } //集計項目区分
        public string tablealias { get; set; } //テーブル別名
        public string? tablealias2 { get; set; } //テーブル別名２
        public string? mastercd { get; set; } //名称マスタコード
        public string? masterpara { get; set; } //メインコード,サブコード
        public string daibunrui { get; set; } //大分類
        public string? tyubunrui { get; set; } //中分類
        public string? syobunrui { get; set; } //小分類
        public string? biko { get; set; } //備考
        public string reguserid { get; set; } //登録ユーザーID
        public DateTime regdttm { get; set; } //登録日時
        public string upduserid { get; set; } //更新ユーザーID
        public DateTime upddttm { get; set; } //更新日時
    }
}