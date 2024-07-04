// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票出力(CSV出力設定)
//             レスポンスインターフェース
// 作成日　　: 2024.02.25
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00302D
{
    /// <summary>
    /// CSV出力設定初期化処理
    /// </summary>
    public class DetailInitResponse : DaResponseBase
    {
        public int? outputptnno { get; set; }                    //出力パターン番号
        public List<DaSelectorModel> csvdroplist { get; set; }   //ドロップダウンリスト(csvdrop)
    }
}