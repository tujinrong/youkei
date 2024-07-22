// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 取込実行チェック
// 　　　　　　データ定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
using AIplus.AiImporter;
using BCC.Affect.Service.CheckImporter.Define.File;

namespace BCC.Affect.Service.CheckImporter
{
    public class ImDef
    {
        /// <summary>
        /// ファイル項目定義
        /// </summary>
        public List<AiFileColumnDef> FileColumns { get; set; } = new List<AiFileColumnDef>();

        /// <summary>
        ///マッピング項目定義
        /// </summary>
        public List<AITransferDef> TransferColumns { get; set; } = new List<AITransferDef>();

        /// <summary>
        /// 画面項目定義
        /// </summary>
        public List<ImEditorColumnDef> EditorColumns { get; set; } = new List<ImEditorColumnDef>();

        /// <summary>
        /// 項目登録移送定義
        /// </summary>
        public List<ImInsertDetailDef> InsertDetails { get; set; } = new List<ImInsertDetailDef>();

    }

    public class SearchDataModel
    {
        public string condictionvalue { get; set; } //条件値
        public string targetvalue { get; set; }     //取得先値
    }
}
