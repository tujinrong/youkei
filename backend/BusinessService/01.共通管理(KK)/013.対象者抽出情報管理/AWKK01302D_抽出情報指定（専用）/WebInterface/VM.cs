// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 抽出情報指定（専用）
//             ビューモデル定義
// 作成日　　: 2024.06.03
// 作成者　　: 陳
// 変更履歴　:
// *******************************************************************

namespace BCC.Affect.Service.AWKK01302D
{
    /// <summary>
    /// 抽出情報
    /// </summary>
    public class TyusyutuVM
    {

        public int? nendo { get; set; }                              //年度
        public string? tyusyututaisyocd { get; set; }                //抽出対象コード
        public string? tyusyututaisyonm { get; set; }                //抽出対象名
        public string? rptid { get; set; }                           //帳票ID
        public long? tyusyutuseq { get; set; }                       //抽出シーケンス
        public string? tyusyutunaiyo { get; set; }                   //抽出内容
        public string? tyusyutunum { get; set; }                     //抽出人数
        public string? regdttm { get; set; }                         //登録日時
    }
}