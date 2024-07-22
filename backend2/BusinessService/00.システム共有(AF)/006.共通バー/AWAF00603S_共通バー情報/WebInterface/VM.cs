// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: 共通バー情報
//             ビューモデル定義
// 作成日　　: 2024.07.10
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00603S
{
    /// <summary>
    /// 共通バー情報
    /// </summary>
    public class InfoVM
    {
        public Enum共通バー番号 barno { get; set; }   //共通バー番号
        public string barnm { get; set; }             //共通バー名称
        public bool attnflg { get; set; }             //注意フラグ
        public bool enabled { get; set; }             //アクセス権限(権限がない場合:false)
        public bool addflg { get; set; }              //追加権限フラグ
        public bool updateflg { get; set; }           //修正権限フラグ
        public bool deleteflg { get; set; }           //削除権限フラグ
        public bool personalnoflg { get; set; }       //個人番号利用権限フラグ
    }
}