// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: ユーザー管理
//             ビューモデル定義
// 作成日　　: 2023.07.04
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
using BCC.Affect.Service.Common;

namespace BCC.Affect.Service.AWAF00901G
{
    /// <summary>
    /// 検索処理(ユーザー)
    /// </summary>
    public class UserRowVM
    {
        public string userid { get; set; }    //ユーザーID
        public string usernm { get; set; }    //ユーザー名
        public string syozokucd { get; set; } //所属グループコード
        public string syozokunm { get; set; } //所属グループ名
        public string yukoymdf { get; set; }  //有効年月日（開始）
        public string yukoymdt { get; set; }  //有効年月日（終了）
        public string status { get; set; }    //状態
    }

    /// <summary>
    /// 検索処理(所属)
    /// </summary>
    public class SyozokuRowVM
    {
        public string syozokucd { get; set; } //所属グループID
        public string syozokunm { get; set; } //所属グループ名
    }

    /// <summary>
    /// 機能権限キー(排他用)
    /// </summary>
    public class KinoLockVM
    {
        public string kinoid { get; set; }   //機能ID
        public DateTime? upddttm { get; set; }  //更新日時(排他用)
    }

    /// <summary>
    /// 機能権限情報(保存用)
    /// </summary>
    public class KinoSaveVM : KinoLockVM
    {
        public Enumプログラム区分 programkbn { get; set; }  //プログラム区分
        public bool? addflg { get; set; }                   //追加権限フラグ
        public bool? updflg { get; set; }                   //修正権限フラグ
        public bool? delflg { get; set; }                   //削除権限フラグ
        public bool? personalnoflg { get; set; }            //個人番号利用権限フラグ
        public bool? keisyoflg { get; set; }                //継承可能フラグ
    }

    /// <summary>
    /// 機能権限情報(画面)
    /// </summary>
    public class GamenVM : KinoSaveVM
    {
        public bool viewflg { get; set; }   //アクセス権限フラグ
    }

    /// <summary>
    /// 機能権限情報(共通バー)
    /// </summary>
    public class CmBarVM : GamenVM
    {
        public string kinonm { get; set; }  //機能名
    }

    /// <summary>
    /// 帳票権限キー(排他用)
    /// </summary>
    public class ReportLockVM
    {
        public string repgroupid { get; set; }  //帳票グループID
        public DateTime? upddttm { get; set; }  //更新日時(排他用)
    }

    /// <summary>
    /// 帳票権限情報(保存用)
    /// </summary>
    public class ReportSaveVM : ReportLockVM
    {
        public bool? tutisyooutflg { get; set; }    //通知書出力フラグ
        public bool? pdfoutflg { get; set; }        //PDF出力フラグ
        public bool? exceloutflg { get; set; }      //EXCEL出力フラグ
        public bool? othersflg { get; set; }        //その他出力フラグ
        public bool? personalnoflg { get; set; }    //個人番号利用フラグ
        public bool? keisyoflg { get; set; }        //継承可能フラグ
    }

    /// <summary>
    /// 帳票権限情報
    /// </summary>
    public class ReportVM : ReportSaveVM
    {
        public string reportgroupnm { get; set; } //帳票グループ名
        public bool viewflg { get; set; }         //アクセス権限
    }

    /// <summary>
    /// 権限情報ベース(ユーザー・所属　共通)
    /// </summary>
    public class RoleAuthBaseVM
    {
        public bool kanrisyaflg { get; set; }               //管理者フラグ
        public bool pnoeditflg { get; set; }                //個人番号操作権限付与フラグ
        public bool alertviewflg { get; set; }              //警告参照フラグ
        public List<CmSisyoVM> editsisyolist { get; set; }  //更新可能支所一覧
    }

    /// <summary>
    /// 権限情報ベース(ユーザー)
    /// </summary>
    public class UserAuthBaseVM : RoleAuthBaseVM
    {
        public bool kanrisyakeisyoflg { get; set; }     //管理者継承フラグ
        public bool pnoeditkeisyoflg { get; set; }      //個人番号操作権限付与継承フラグ
        public bool alertviewkeisyoflg { get; set; }    //警告参照継承フラグ
        public bool authsisyokeisyoflg { get; set; }    //部署（支所）別更新権限継承フラグ
    }

    /// <summary>
    /// ユーザー情報(表示用)
    /// </summary>
    public class UserInfoVM : UserAuthBaseVM
    {
        public string syozoku { get; set; }                 //所属グループ
        public bool authsetflg { get; set; }                //権限設定フラグ
        public bool stopflg { get; set; }                   //使用停止フラグ
        public string usernm { get; set; }                  //ユーザー名
        public string yukoymdf { get; set; }                //有効年月日（開始）
        public string yukoymdt { get; set; }                //有効年月日（終了）
        public int errorkaisu { get; set; }                 //ログインエラー回数
        public List<CmSisyoVM> regsisyolist { get; set; }   //登録支所
        public DateTime? upddttm { get; set; }              //更新日時(排他用)
    }

    /// <summary>
    /// ユーザー情報(保存用)
    /// </summary>
    public class UserSaveVM : UserInfoVM
    {
        public string pword { get; set; }    // 新パスワード
    }

    /// <summary>
    /// 所属グループ情報(保存用)
    /// </summary>
    public class SyozokuSaveVM : RoleAuthBaseVM
    {
        public string syozokunm { get; set; }           //所属グループ名
        public bool stopflg { get; set; }               //使用停止フラグ
        public List<UserRowVM> userlist1 { get; set; }  //ユーザーリスト(該当所属)
        public DateTime? upddttm { get; set; }          //更新日時(排他用)
    }

    /// <summary>
    /// 所属グループ情報(表示用)
    /// </summary>
    public class SyozokuInfoVM : SyozokuSaveVM
    {
        public List<UserDetailVM> userlist2 { get; set; }   //ユーザーリスト(全ユーザー)
    }

    /// <summary>
    /// ユーザー一覧情報(選択用)
    /// </summary>
    public class UserDetailVM : UserRowVM
    {
        public bool editflg { get; set; }   //編集フラグ
    }
}