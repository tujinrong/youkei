// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 連絡先
//             リクエストインターフェース
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00605D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : DaRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public SaveVM detailinfo { get; set; }  //連絡先情報
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public string jigyo { get; set; }           //利用事業(コード：名称)
        public string atenano { get; set; }         //宛名番号
        public DateTime upddttm { get; set; }       //更新日時
    }
}