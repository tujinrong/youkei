// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             健（検）診予約希望者詳細テーブル
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tt_shkensinkibosyasyosaiDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tt_shkensinkibosyasyosai";
        public int nendo { get; set; }                            //年度
        public int nitteino { get; set; }                         //日程番号
        public string atenano { get; set; }                       //宛名番号
        public string jigyocd { get; set; }                       //検診種別
        public string kensahohocd { get; set; }                   //検査方法コード
        public Enum待機フラグ cancelmatiflg { get; set; }		  //キャンセル待ち
        public string? syokaiuketukeymd { get; set; }             //初回受付日
        public string? henkouketukeymd { get; set; }              //受付変更日
    }
}
