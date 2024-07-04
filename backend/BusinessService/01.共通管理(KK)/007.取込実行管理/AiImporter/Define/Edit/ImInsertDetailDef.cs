// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　取込登録詳細情報定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImInsertDetailDef
    {
        /// <summary>
        /// テーブル物理名
        /// </summary>
        public string Tableid { get; set; }

        /// <summary>
        /// フィールド物理名
        /// </summary>
        public string FieldId { get; set; }

        /// <summary>
        /// 処理区分
        /// </summary>
        public string Syorikbn { get; set; }

        /// <summary>
        /// データテーブル列名(データ元画面項目)
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 固定値
        /// </summary>
        public string? Koteiti { get; set; }

        /// <summary>
        /// DB固定値
        /// </summary>
        public string? DBKoteiti { get; set; }

    }
}
