// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             年度マスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_shnendoDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_shnendo";
        public int nendo { get; set; }                            //年度
        public string jigyocd { get; set; }                       //検診種別
        public string kensahohocd { get; set; }                   //検査方法コード
        public string? sex { get; set; }                          //性別
        public string age { get; set; }                           //年齢
        public Enum年齢基準日区分 kijunkbn { get; set; }          //年齢基準日区分
        public string? kijunymd { get; set; }                     //年齢計算基準日
        public string? hokenkbn { get; set; }                     //保険区分
        public string? tokusyu { get; set; }                      //特殊
        public string? sql { get; set; }                          //SQL文
        public string reguserid { get; set; }                     //登録ユーザーID
        public DateTime regdttm { get; set; }                     //登録日時
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
