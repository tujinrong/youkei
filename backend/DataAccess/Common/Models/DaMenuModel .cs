// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: 権限管理
//
// 作成日　　: 2023.01.10
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class GamenCommonModel
    {
        public string menuid { get; set; }        //メニューID
        public bool addflg { get; set; }          //追加権限フラグ
        public bool updateflg { get; set; }       //修正権限フラグ
        public bool deleteflg { get; set; }       //削除権限フラグ
        public bool personalnoflg { get; set; }   //個人番号利用権限フラグ
    }
    public class MenuModel : GamenCommonModel
    {
        public string path { get; set; }            //パス(URL用)
        public string parentid { get; set; }        //親メニューID
        public bool isfolder { get; set; }          //フォルダフラグ(フォルダの場合：true　画面の場合:false)
        public int menuseq { get; set; }            //全メニュー内シーケンス
        public string menuname { get; set; }        //メニュー表示名称(画面名称共有)
        public bool paramkeisyoflg { get; set; }    //検索パラメーター継承フラグ
        public bool enabled { get; set; }           //アクセス権限(権限がない場合:false)
    }
    public class GamenModel : GamenCommonModel
    {
        public Enumプログラム区分 programkbn { get; set; }     //プログラム区分
    }
    public class ProgramModel
    {
        public string kinoid { get; set; }           //機能ID
        public List<string> menuids { get; set; }    //メニューIDリスト
    }
}