// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             検診履歴管理テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinrirekikanriDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tt_shkensinrirekikanri";
		public int nendo { get; set; }                            //年度
		public string jigyocd { get; set; }                       //成人健（検）診事業コード
		public string kensahohocd { get; set; }                   //検査方法コード
		public string atenano { get; set; }                       //宛名番号
		public string taisyoflg { get; set; }                     //一時対象サイン
    }
}
