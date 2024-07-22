// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 帳票グループ帳票グループ登録
//          　 レスポンスインターフェース 
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00402D
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitResponse : DaResponseBase
    {
        public string rptgroupnm { get; set; }                      //帳票グループ名
        public string gyomukbn { get; set; }                        //業務区分
        public string? kojinrenrakusakicd { get; set; }             //個人連絡先
        public string? memocd { get; set; }                         //メモ情報（複数）
        public string? electronfilecd { get; set; }                 //電子ファイル（複数）
        public string? followmanage { get; set; }                   //フォロー管理（複数）
        public int orderseq { get; set; }                           //並び順

        public DateTime? upddttm { get; set; }                      //更新日時

        public List<DaSelectorModel> gyomukbnList { get; set; }     //業務区分のドロップダウンリスト
        public List<DaSelectorModel> renrakusakicds { get; set; }   //個人連絡先のドロップダウンリスト
        public List<DaSelectorModel> memocds { get; set; }          //メモ情報のドロップダウンリスト
        public List<DaSelectorModel> electronfilecds { get; set; }  //電子ファイル情報のドロップダウンリスト
        public List<DaSelectorModel> followmanages { get; set; }    //フォロー管理のドロップダウンリスト
    }
}