// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票発行対象者抽出情報管理（専用）
//             リクエストインターフェース
// 作成日　　: 2024.05.27
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK01301G
{
    /// <summary>
    /// 検索処理(一覧画面)
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public int pagesize2 { get; set; } = 20;                            //ページサイズ（二番目の一覧）
        public int pagenum2 { get; set; } = 1;                              //ページNo.（二番目の一覧）
        public int orderby2 { get; set; } = 0;                              //並び順（二番目の一覧）
        public int? nendo { get; set; }                                     //年度
        public string? tyusyututaisyo { get; set; }                         //抽出対象（コード：名称）
        public string? tyusyutunaiyo { get; set; }                          //抽出内容
        public string? regdttmf { get; set; }                               //抽出日（開始）
        public string? regdttmt { get; set; }                               //抽出日（終了）
    }
    /// <summary>
    /// ベースリクエスト
    /// </summary>
    public class DetailBaseRequest : DaRequestBase
    {
        public string zentaikobetukbn { get; set; }                         //全体個別抽出区分
    }
    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : DetailBaseRequest
    {
        public string tyusyututaisyocd { get; set; }                        //抽出対象コード
        public long? tyusyutuseq { get; set; }                              //抽出シーケンス（全体抽出参照モード、抽出後）
        public string? atenano { get; set; }                                //宛名番号（個別抽出）
        public int? nendo { get; set; }                                     //年度（個別抽出かつ年度管理されている場合）
        public string tyusyutunaiyo { get; set; } = "個別抽出";             //抽出内容（全体抽出の場合、フロントエンドの入力値；個別抽出の場合、個別抽出の固定テキスト）
    }
    /// <summary>
    /// 抽出処理
    /// </summary>
    public class ExtractRequest : DetailBaseRequest
    {
        public string tyusyututaisyocd { get; set; }                        //抽出対象コード
        public string? atenano { get; set; }                                //宛名番号（個別抽出）
        public string tyusyutunaiyo { get; set; }                           //抽出内容
        public bool continueflg { get; set; }                               //継続希望フラグ
        public int? nendo { get; set; }                                     //年度（個別抽出かつ年度管理されている場合）
        public List<ParameterVM> parameters { get; set; }                   //抽出パラメータ
    }
}