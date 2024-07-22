// *******************************************************************
// 業務名称　: 互助防疫システム
// 機能概要　: DTO定義
//             成人健（検）診事業マスタ
// 作成日　　: 2024.07.23
// 作成者　　: 
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shkensinjigyoDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_shkensinjigyo";
        public string jigyocd { get; set; }                       //検診種別
        public Enum事業区分 kihonkakutyokbn { get; set; }         //基本／拡事業区分
        public Enum精密検査実施区分 seikenjissikbn { get; set; }  //精密検査実施区分
        public Enum減免区分種別 genmenkbn { get; set; }           //減免区分
        public Enum画面表示区分 cuponhyojikbn { get; set; }       //クーポン券表示区分
        public bool syogaiikaiflg { get; set; }	                  //生涯１回フラグ
        public bool kensahoho_setflg { get; set; }                //検査方法設定フラグ
        public string? kensahoho_maincd { get; set; }             //検査方法メインコード
        public int? kensahoho_subcd { get; set; }                 //検査方法サブコード
        public string? yoyakubunrui_maincd { get; set; }          //予約分類メインコード
        public int? yoyakubunrui_subcd { get; set; }              //予約分類サブコード
        public string? groupid2_maincd { get; set; }              //フリー項目グループ右設定メインコード
        public int? groupid2_subcd { get; set; }                  //フリー項目グループ右設定サブコード
        public EnumMsgCtrlKbn yoyakuchk { get; set; }             //予約画面チェック区分
        public EnumMsgCtrlKbn kensinchk { get; set; }             //健（検）診画面チェック区分
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
