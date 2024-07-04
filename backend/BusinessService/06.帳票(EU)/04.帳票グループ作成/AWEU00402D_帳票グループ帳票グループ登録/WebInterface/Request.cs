// *******************************************************************
// 業務名称　: 帳票グループ作成
// 機能概要　: 帳票グループ帳票グループ登録				
//          　 リクエストインターフェース 
// 作成日　　: 2023.10.31
// 作成者　　: xiao
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWEU00402D
{
    public class InitRequest : DaRequestBase
    {
        public Enum編集区分 editkbn { get; set; }       //編集区分
        public string rptgroupid { get; set; }          //帳票グループID
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : DaRequestBase
    {
        public Enum編集区分 editkbn { get; set; }       //編集区分
        public DateTime? upddttm { get; set; }          //更新日時

        public string rptgroupid { get; set; }          //帳票グループID
        public string rptgroupnm { get; set; }          //帳票グループ名
        public string kojinrenrakusakicd { get; set; }  //個人連絡先
        public string memocd { get; set; }              //メモ情報（複数）
        public string electronfilecd { get; set; }      //電子ファイル（複数）
        public string followmanage { get; set; }        //フォロー管理（複数）
        public string gyomukbn { get; set; }            //業務区分
        public int orderseq { get; set; }               //並び順
    }

    /// <summary>
    /// 削除処理
    /// </summary>
    public class DeleteRequest : DaRequestBase
    {
        public DateTime upddttm { get; set; }           //更新日時
        public string rptgroupid { get; set; }          //帳票グループID
    }
}