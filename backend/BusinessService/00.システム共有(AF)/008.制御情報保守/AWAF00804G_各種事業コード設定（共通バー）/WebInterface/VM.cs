// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 各種事業コード設定（共通バー）
//             ViewModel定義
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00804G
{
    /// <summary>
    /// 行モデル
    /// </summary>
    public class RowVM
    {
        public string cd { get; set; }      //設定対象コード(キー)
        public string nm { get; set; }      //設定対象表示名称
        public string cdnm1 { get; set; }   //集約コード名称(個人連絡先)
        public string cdnm2 { get; set; }   //集約コード名称(メモ情報)
        public string cdnm3 { get; set; }   //集約コード名称(電子ファイル情報)
        public string cdnm4 { get; set; }   //集約コード名称(フォロー管理)
        public bool flg1 { get; set; }      //設定不要フラグ(個人連絡先)
        public bool flg2 { get; set; }      //設定不要フラグ(メモ情報)
        public bool flg3 { get; set; }      //設定不要フラグ(電子ファイル情報)
        public bool flg4 { get; set; }      //設定不要フラグ(フォロー管理)
    }
}