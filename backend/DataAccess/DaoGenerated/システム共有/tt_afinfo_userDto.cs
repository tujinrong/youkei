// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             お知らせ確認状態テーブル
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_afinfo_userDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_afinfo_user";
		public long infoseq { get; set; }                         //お知らせシーケンス
		public string userid { get; set; }                        //ユーザーID
    }
}
