// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: お知らせ
//             ビューモデル定義
// 作成日　　: 2024.07.26
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00302D
{
    /// <summary>
    /// お知らせ情報モデル
    /// </summary>
    public class InfoVM
    {
        public string juyodo { get; set; }          //重要度
        public string syosai { get; set; }          //詳細
        public DateTime kigenymd { get; set; }      //提示期限
        public bool atesakiflg { get; set; }        //宛先指定フラグ
        public List<string>? userlist { get; set; } //宛先一覧(ユーザーID)
    }

    /// <summary>
    /// お知らせ情報(更新)モデル
    /// </summary>
    public class UpdVM : InfoVM
    {
        public long infoseq { get; set; }   //シーケンス番号
        public bool readflg { get; set; }   //既読フラグ
    }

    /// <summary>
    /// お知らせ情報(検索)モデル
    /// </summary>
    public class SearchVM : UpdVM
    {
        public string regusernm { get; set; }     //登録操作者名
        public DateTime regdttm { get; set; }     //登録日時
        public DateTime upddttm { get; set; }     //更新日時
        public bool editflg { get; set; }         //編集フラグ
    }

    /// <summary>
    /// 排他チェック用モデル
    /// </summary>
    public class LockVM
    {
        public long infoseq { get; set; }        //シーケンス番号
        public DateTime upddttm { get; set; }    //更新日時
    }

    /// <summary>
    /// ユーザーモデル
    /// </summary>
    public class UserVM
    {
        public string userid { get; set; } //ユーザーID
        public string usernm { get; set; } //ユーザー名
    }
}