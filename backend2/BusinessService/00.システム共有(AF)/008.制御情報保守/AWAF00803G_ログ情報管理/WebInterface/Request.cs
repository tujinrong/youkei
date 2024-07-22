// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ログ情報管理
//             リクエストインターフェース
// 作成日　　: 2023.08.30
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00803G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public Enumログ区分? logkbn { get; set; }           //ログ区分
        public string? status { get; set; }                 //処理結果(コード：名称)
        public string? syoridttmf { get; set; }             //処理日時（開始）
        public string? syoridttmt { get; set; }             //処理日時（終了）
        public string? service { get; set; }                //機能(コード：名称)
        public string? method { get; set; }                 //処理(コード：名称)
        public string? user { get; set; }                   //操作者(コード：名称)
        public string? atenano { get; set; }                //宛名番号
        public override string? personalno { get; set; }    //個人番号
        public bool pnokbn { get; set; }                    //個人番号操作区分
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DaRequestBase
    {
        public long sessionseq { get; set; }    //ログシーケンス
    }

    /// <summary>
    /// 検索処理(詳細画面：共通)
    /// </summary>
    public class SearchCommonRequest : CmSearchRequestBase
    {
        public long sessionseq { get; set; }    //ログシーケンス
    }

    /// <summary>
    /// 検索処理(詳細画面：項目値変更情報)
    /// </summary>
    public class SearchColumnDetailRequest : SearchCommonRequest
    {
        public string? table { get; set; }      //変更テーブル
        public string? item { get; set; }       //変更項目
        public string? henkokbn { get; set; }   //変更区分
    }

    /// <summary>
    /// CSV出力処理
    /// </summary>
    public class OutputRequest : DaRequestBase
    {
        public Enumログ区分? logkbn { get; set; }           //ログ区分
        public string? status { get; set; }                 //処理結果(コード：名称)
        public string? syoridttmf { get; set; }             //処理日時（開始）
        public string? syoridttmt { get; set; }             //処理日時（終了）
        public string? service { get; set; }                //機能(コード：名称)
        public string? method { get; set; }                 //処理(コード：名称)
        public string? user { get; set; }                   //操作者(コード：名称)
        public string? atenano { get; set; }                //宛名番号
        public string? personalno { get; set; }             //個人番号
        public bool pnokbn { get; set; }                    //個人番号操作区分
        public bool mainflg { get; set; }                   //メインログフラグ
        public bool tusinflg { get; set; }                  //通信ログフラグ
        public bool batchflg { get; set; }                  //バッチログフラグ
        public bool gaibuflg { get; set; }                  //連携ログフラグ
        public bool dbflg { get; set; }                     //DB操作ログフラグ
        public bool columnflg { get; set; }                 //項目値変更フラグ
        public bool atenaflg { get; set; }                  //宛名番号ログフラグ
    }
}