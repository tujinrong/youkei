// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 妊産婦情報管理-費用助成一覧
//             リクエストインターフェース
// 作成日　　: 2024.05.14
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.AWBH00301G;

namespace BCC.Affect.Service.AWBH00302D
{
    /// <summary>
    /// 8.費用助成一覧画面検索処理
    /// </summary>
    public class SearchJyoseiListRequest : CmSearchRequestBase
    {
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string bhsyosaimenyucd { get; set; }             //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; }               //母子詳細タブコード
        public string atenano { get; set; }                     //宛名番号
        public long torokuno { get; set; }                      //登録番号
        public int sinseiedano { get; set; }                    //申請枝番
    }

    /// <summary>
    /// 費用助成一覧キー項目
    /// </summary>
    public class JyoseiKeyRequest : CmSaveRequestBase
    {
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string bhsyosaimenyucd { get; set; }             //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; }               //母子詳細タブコード
        public string atenano { get; set; }                     //宛名番号
        public long torokuno { get; set; }                      //登録番号
        public int sinseiedano { get; set; }                    //申請枝番
    }

    /// <summary>
    /// 9.保存処理（費用助成一覧）
    /// </summary>
    public class SaveJyoseiRequest : JyoseiKeyRequest
    {
        public List<JyoseiListInfoVM> jyoseilistinfo { get; set; }//費用助成一覧情報
    }

    /// <summary>
    /// 10.削除処理（費用助成一覧）
    /// </summary>
    public class DeleteJyoseiRequest : JyoseiKeyRequest { }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public class InitListRequest : CmSearchRequestBase
    {
        public string bosikbn { get; set; } = 母子種類._1;      //母子種類
        public string bhsyosaimenyucd { get; set; }             //母子詳細メニューコード
        public string bhsyosaitabcd { get; set; }               //母子詳細タブコード
        public int sinseiedano { get; set; }                    //申請枝番
    }
}