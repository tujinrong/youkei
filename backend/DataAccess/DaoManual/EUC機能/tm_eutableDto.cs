// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             EUCテーブルマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.DataAccess
{
    public class tm_eutableDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_eutable";
        public string tablealias { get; set; } //テーブル·別名
        public string tablenm { get; set; } //テーブル物理名
        public string tablehyojinm { get; set; } //テーブル名称
        public EnumTableKbn tablekbn { get; set; } //テーブル区分
        public bool tableflg { get; set; } //テーブルフラグ
        public int orderseq { get; set; } //並びシーケンス
    }
}