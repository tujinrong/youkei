// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 事業実施報告書（日報）管理
//             リクエストインターフェース
// 作成日　　: 2023.11.09
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK00501G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string jissiymdf { get; set; }   //実施日時（開始）
        public string jissiymdt { get; set; }   //実施日時（終了）
        public string kaijo { get; set; }       //会場(コード：名称)
        public string jigyo { get; set; }       //事業(コード：名称)
        public string staff { get; set; }       //地区担当者(コード：名称)
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public long? hokokusyono { get; set; } //事業報告書番号
    }

    /// <summary>
    /// 検索処理(事業従事者情報)
    /// </summary>
    public class SearchRowRequest : DaRequestBase
    {
        public string staffid { get; set; }     //事業従事者ID
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public long hokokusyono { get; set; }                   //事業報告書番号
        public DateTime? upddttm { get; set; }                  //更新日時
        public JissihokokusyoVM jissihokokusyo { get; set; }    //事業実施報告書（日報）情報
        public HashSet<string> staffids { get; set; }           //事業従事者ID集合
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public long hokokusyono { get; set; } //事業報告書番号
        public DateTime upddttm { get; set; } //更新日時
    }
}