// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込実行チェック
// 　　　　　　オプション項目定義
// 作成日　　: 2023.10.10
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.CheckImporter
{
    public class ImCheckOption
    {
        /// <summary>
        /// 一括取込入力区分
        /// </summary>
        public string impkbn { get; set; } = string.Empty;

        /// <summary>
        /// 登録区分
        /// </summary>
        public string regupdkbn { get; set; } = string.Empty;

        /// <summary>
        /// 年度
        /// </summary>
        public string nendo { get; set; } = string.Empty;

        /// <summary>
        /// 取込対象テーブル情報定義
        /// </summary>
        public List<string> TableidList = new List<string>();

        /// <summary>
        /// コード変換定義
        /// </summary>
        public List<ImCdChangeDef> CdChangeDataList { get; set; } = new List<ImCdChangeDef>();

        /// <summary>
        /// データ型定義
        /// </summary>
        public Dictionary<string, string> DataTypeDic = new Dictionary<string, string>();

        /// <summary>
        /// フォーマット_日付定義
        /// </summary>
        public Dictionary<string, string> FormatDateDic = new Dictionary<string, string>();

        /// <summary>
        /// テーブル名称情報定義
        /// </summary>
        public Dictionary<string, string> TableNameDic = new Dictionary<string, string>();

        /// <summary>
        /// 性別名称情報定義
        /// </summary>
        public Dictionary<string, string> SexNameDic = new Dictionary<string, string>();

        /// <summary>
        /// 医療機関情報定義
        /// </summary>
        public Dictionary<string, string> kikanDic = new Dictionary<string, string>();
        /// <summary>
        /// 関数情報定義
        /// </summary>
        public Dictionary<string, List<object?>> kansuDic = new Dictionary<string, List<object?>>();

        /// <summary>
        /// ファイル取込自動チェックFlg
        /// </summary>
        public bool IsAutoCheckFlg = false;

        /// <summary>
        /// 処理キー
        /// </summary>
        public string ProcessKey { get; set; }
    }
}
