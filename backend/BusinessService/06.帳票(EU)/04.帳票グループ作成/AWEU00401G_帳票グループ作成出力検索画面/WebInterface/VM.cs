// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 帳票グループ作成検索画面	
//          　 ビューモデル定義
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00401G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchVM
    {
        public string rptgroupid { get; set; }          //帳票ID
        public string rptgroupnm { get; set; }          //帳票グループ
        public string kojinrenrakusakicd { get; set; }  //個人連絡先
        public string memocd { get; set; }              //メモ情報
        public string electronfilecd { get; set; }      //電子ファイル情報
        public string followmanage { get; set; }        //フォロー管理
    }
}