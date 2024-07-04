// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 事業コード管理
//             ViewModel定義
// 作成日　　: 2024.01.25
// 作成者　　: 劉
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00805D
{
    /// <summary>
    /// 集約コード情報
    /// </summary>
    public class SaveVM
    {
        public string cdnm1 { get; set; }           //個人連絡先集約コード(コード：名称)
        public List<string> cdnmlist2 { get; set; } //集約コードリスト(メモ情報)
        public List<string> cdnmlist3 { get; set; } //集約コードリスト(電子ファイル情報)
        public List<string> cdnmlist4 { get; set; } //集約コードリスト(フォロー管理)
        public bool flg1 { get; set; }              //設定不要フラグ(個人連絡先)
        public bool flg2 { get; set; }              //設定不要フラグ(メモ情報)
        public bool flg3 { get; set; }              //設定不要フラグ(電子ファイル情報)
        public bool flg4 { get; set; }              //設定不要フラグ(フォロー管理)
    }
}