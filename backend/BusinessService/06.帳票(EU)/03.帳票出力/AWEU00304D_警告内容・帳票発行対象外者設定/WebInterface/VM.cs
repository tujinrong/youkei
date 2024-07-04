// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 警告内容・帳票発行対象外者設定
//          　 ビューモデル定義
// 作成日　　: 2024.02.19
// 作成者　　: シュウ
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00304D
{
    /// <summary>
    /// 警告内容情報
    /// </summary>
    public class WarningContentVM
    {
        public string atenano { get; set; }         //宛名番号
        public string simei { get; set; }           //氏名
        public string keikoku { get; set; }         //警告内容
        public string? taisyogairiyu { get; set; }  //対象外者/対象外理由
        public bool formflg { get; set; }           //出力フラグ
        public bool formflgold { get; set; }        //出力フラグ(旧)
    }
}