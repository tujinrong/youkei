// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: メモ情報（世帯）
//             リクエストインターフェース
// 作成日　　: 2023.07.13
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00604D
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchRequest : CmSearchRequestBase
    {
        public string atenano { get; set; }     //宛名番号
        public string? patternno { get; set; }  //パターンNo.(ドロップダウンリストコード) 
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public string setaino { get; set; }                     //世帯番号
        public List<AWAF00601D.AddVM> addlist { get; set; }     //新規メモリスト
        public List<AWAF00601D.UpdVM> updlist { get; set; }     //更新メモリスト
        public List<AWAF00601D.LockVM> locklist { get; set; }   //排他チェック用リスト
    }
}