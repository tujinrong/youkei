// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             トークンテーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_aftokenDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_aftoken";
        public long tokenseq { get; set; }                        //トークンシーケンス
        public string userid { get; set; }                        //ユーザーID
        public string? regsisyo { get; set; }                     //登録支所
        public string? sisyocd { get; set; }                      //部署（支所）コード
        public string? gamenauth { get; set; }                    //画面権限
        public Enumロール区分 rolekbn { get; set; }               //ロール区分
        public string? syozokucd { get; set; }                    //所属グループコード
        public bool kanrisyaflg { get; set; }                     //管理者フラグ
        public bool pnoeditflg { get; set; }                      //個人番号操作権限付与フラグ
        public bool alertviewflg { get; set; }                    //警告参照フラグ
        public DateTime accessdttm { get; set; }                  //アクセス日時
    }
}
