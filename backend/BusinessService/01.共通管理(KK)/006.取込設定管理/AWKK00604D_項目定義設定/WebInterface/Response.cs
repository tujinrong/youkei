// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.画面項目情報ダイアログ画面
//             レスポンスインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00604D
{
    /// <summary>
    /// 初期化処理(取込設定：画面項目情報ダイアログ画面)
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        //ドロップダウンリストの初期化データ
        public List<DaSelectorModel> inputkbnList { get; set; }        //【入力区分】のドロップダウンリスト
        public List<DaSelectorKeyModel> inputtypeList { get; set; }    //【入力方法】のドロップダウンリスト
        public List<DaSelectorModel> formatList { get; set; }        　//【フォーマット】のドロップダウンリスト
        public List<DaSelectorModel> requiredflgList { get; set; }     //【必須】のドロップダウンリスト
        public List<DaSelectorModel> yearchkflgList { get; set; }      //【年度チェック】のドロップダウンリスト
        public List<DaSelectorModel> dispinputkbnList { get; set; }    //【表示入力設定】のドロップダウンリスト
        public List<DaSelectorModel> fromitemseqList { get; set; }     //【参照元項目】のドロップダウンリスト
        public List<DaSelectorModel> fromfieldidList { get; set; }     //【参照元フィールド】のドロップダウンリスト
        public List<DaSelectorModel> targetfieldidList { get; set; }   //【取得先フィールド】のドロップダウンリスト
        public List<DaSelectorKeyModel> msttableList { get; set; }     //【マスタチェックテーブル】のドロップダウンリスト
        public List<DaSelectorModel> mstfieldList { get; set; }        //【マスタチェック項目】のドロップダウンリスト
        public List<DaSelectorModel> jherrlelkbnList { get; set; }     //【条件必須エラーレベル区分】のドロップダウンリスト
        public List<DaSelectorModel> jhitemseqList { get; set; }       //【条件必須項目】のドロップダウンリスト
        public List<DaSelectorModel> jhenzanList { get; set; }         //【条件必須演算子】のドロップダウンリスト
        public List<DaSelectorModel> jigyocdList { get; set; }         //【実施事業】のドロップダウンリスト
        public List<DaSelectorModel> itemkbnList { get; set; }         //【項目特定区分】のドロップダウンリスト
        public List<DaSelectorModel> hikisukbnList { get; set; }       //【引数区分】のドロップダウンリスト

    }

    /// <summary>
    /// 【入力方法】初期化処理
    /// </summary>
    public class InitInputTypeResponse : DaResponseBase
    {
        public List<DaSelectorKeyModel> inputtypeList { get; set; }   //【入力方法】のドロップダウンリスト
    }

    /// <summary>
    /// 【フィールド】初期化処理
    /// </summary>
    public class InitFieldidResponse : DaResponseBase
    {
        public List<DaSelectorModel> fieldidList { get; set; }   //【フィールド】のドロップダウンリスト
    }
}