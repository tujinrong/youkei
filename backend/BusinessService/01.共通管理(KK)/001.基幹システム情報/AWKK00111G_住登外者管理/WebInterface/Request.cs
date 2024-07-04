// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 住登外者管理
//             リクエストインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 張
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWKK00111G
{
    /// <summary>
    /// 検索処理(一覧)
    /// </summary>
    public class SearchListRequest : Common.PersonSearchRequest
    {
        public bool fusyoflg { get; set; }                  //不詳フラグ    
        public string? reguser { get; set; }                //登録者(コード：名称)
        public DateTime? regdatef { get; set; }             //登録日時（開始）
        public DateTime? regdatet { get; set; }             //登録日時（終了）
        public string? upduser { get; set; }                //更新者(コード：名称)
        public DateTime? upddatef { get; set; }             //更新日時（開始）
        public DateTime? upddatet { get; set; }             //更新日時（終了）
        public string? delflg { get; set; }                 //削除フラグ(コード：名称) 
        public string? gyomuid { get; set; }                //業務ID(コード：名称)
        public string? dokujisystemid { get; set; }         //独自施策システム等ID(コード：名称)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public int rirekino { get; set; }                   //履歴番号
        public int rirekinum { get; set; }                  //履歴No.
    }

    /// <summary>
    /// 世帯情報処理(詳細画面)
    /// </summary>
    public class SearchSetaiRequest : DaRequestBase
    {
        public string setaino { get; set; }                 //世帯番号
    }

    /// <summary>
    /// 検索処理(詳細画面--異動ボタン押下最新履歴情報取得処理)
    /// </summary>
    public class SearchLasteRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public MainInfoVM maininfo { get; set; }            //住登外者詳細_基本情報等タブメイン
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号

    }

    /// <summary>
    /// 世帯情報更新処理
    /// </summary>
    public class SaveSeitaiRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号
        public int rirekino { get; set; }                   //履歴番号
        public List<SeitaiDictVM> seitaidictlist { get; set; }//同一世帯員情報一覧（宛名番号）
    }

    /// <summary>
    /// 検索処理(詳細画面--郵便情報)
    /// </summary>
    public class AutoSetRequest : DaRequestBase
    {
        public string adrs_yubin { get; set; }              //郵便番号	
    }

    /// <summary>
    /// 最新個人番号取得処理
    /// </summary>
    public class SearchPersonalRequest : DaRequestBase
    {
        public string atenano { get; set; }                 //宛名番号

    }

    /// <summary>
    /// 検索処理(詳細画面--異動処理「最新履歴」)
    /// </summary>
    public class SearchSeisinDetailRequest : SearchDetailRequest
    {
        public string idoymd { get; set; }                  //異動年月日
        public string idojiyu { get; set; }                 //異動事由
    }

    /// <summary>
    /// 自動付番処理（世帯番号及び宛名番号の自動採番）
    /// </summary>
    public class AutoSaibanRequest : DaRequestBase
    {
        public string seqflg { get; set; }                  //自動付番フラグ　1:世帯番号、2:宛名番号
    }

}
