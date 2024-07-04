// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             メニューマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afmenuDto : DaEntityModelBase
    {
		public const string TABLE_NAME = "tm_afmenu";
		public string kinoid { get; set; }                        //機能ID
		public string oyamenuid { get; set; }                     //親メニューID
		public int orderseq { get; set; }                         //並びシーケンス
		public bool paramkeisyoflg { get; set; }                  //検索パラメーター継承フラグ
		public bool addctrlflg { get; set; }                      //追加権限制御フラグ
		public bool updctrlflg { get; set; }                      //修正権限制御フラグ
		public bool delctrlflg { get; set; }                      //削除権限制御フラグ
		public bool pnousectrlflg { get; set; }                   //個人番号利用権限制御フラグ
    }
}
