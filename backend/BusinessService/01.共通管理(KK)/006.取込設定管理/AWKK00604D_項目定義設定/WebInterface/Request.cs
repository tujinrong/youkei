// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 取込設定.画面項目情報ダイアログ画面
//             リクエストインターフェース
// 作成日　　: 2023.09.08
// 作成者　　: 韋
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00604D
{
    /// <summary>
    /// 初期化処理(取込設定：画面項目情報ダイアログ画面)
    /// </summary>
    public class InitRequest : DaRequestBase
    {
        public int pageitemseq { get; set; }            //画面項目ID
        public string gyoumukbn { get; set; }           //業務区分
        public string impno { get; set; }               //一括取込入力No
        public string inputkbn { get; set; }            //入力区分
        public string inputtype { get; set; }           //入力方法
        public string msttable { get; set; }            //マスタチェックテーブル
        public List<string> pageitemList { get; set; }  //画面項目情報の(画面項目ID,項目名)のリスト
        public Enum編集区分 editkbn { get; set; }       //編集区分

    }

    /// <summary>
    /// ドロップダウン初期化(入力方法)
    /// </summary>
    public class InitInputTypeRequest : DaRequestBase
    {
        public string gyoumukbn { get; set; }    //業務区分
        public string impno { get; set; }        //一括取込入力No
        public string inputkbn { get; set; }     //入力区分
    }

    /// <summary>
    /// ドロップダウン初期化(フィールド)
    /// </summary>
    public class InitFieldidRequest : DaRequestBase
    {
        public string tableid { get; set; } //テーブルID
    }
}