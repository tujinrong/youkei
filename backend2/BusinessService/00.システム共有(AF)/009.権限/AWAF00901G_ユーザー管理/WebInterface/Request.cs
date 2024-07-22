// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ユーザー管理
//             リクエストインターフェース
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00901G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchListRequest : CmSearchRequestBase
    {
        public string user { get; set; }            //ユーザー
        public string syozoku { get; set; }         //所属グループ
        public Enumロール区分 rolekbn { get; set; } //ロール区分
    }

    /// <summary>
    /// 初期化処理(詳細画面)
    /// </summary>
    public class InitDetailRequest : SearchDetailRequest
    {
        public string roleid { get; set; }          //ロールID
        public Enumロール区分 rolekbn { get; set; } //ロール区分
        public Enum編集区分 editkbn { get; set; }   //編集区分
    }

    /// <summary>
    /// 検索処理(詳細画面)
    /// </summary>
    public class SearchDetailRequest : DaRequestBase
    {
        public string syozoku { get; set; }     //所属グループ
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveRequest : CmSaveRequestBase
    {
        public string roleid { get; set; }          //ロールID
        public Enumロール区分 rolekbn { get; set; } //ロール区分
        public Enum編集区分 editkbn { get; set; }   //編集区分

        public UserSaveVM? maininfo1 { get; set; }          //ユーザー情報
        public SyozokuSaveVM? maininfo2 { get; set; }       //所属グループ情報
        public List<KinoSaveVM> authlist1 { get; set; }     //権限リスト(画面・共通バー)
        public List<ReportSaveVM> authlist2 { get; set; }   //帳票権限リスト
        public List<KinoLockVM> keylist1 { get; set; }      //権限リスト(画面・共通バー)：排他用
        public List<ReportLockVM> keylist2 { get; set; }    //帳票権限リスト：排他用
        public List<string> keylist3 { get; set; }          //ユーザーIDリスト(所属用：更新・排他)
    }
}