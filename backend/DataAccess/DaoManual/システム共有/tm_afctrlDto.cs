// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: DTO定義
//             コントロールマスタ
// 作成日　　: 2023.01.23
// 作成者　　: 屠
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.DataAccess
{
    public class tm_afctrlDto : DaEntityModelBase
    {
        public const string TABLE_NAME = "tm_afctrl";
        public string ctrlmaincd { get; set; }                    //コントロールメインコード
        public int ctrlsubcd { get; set; }                        //コントロールサブコード
        public string ctrlcd { get; set; }                        //コントロールコード
        public string itemnm { get; set; }                        //項目名称
        public EnumDataType datatype { get; set; }                //データ型
        public bool rangeflg { get; set; }                        //範囲フラグ
        public string? value1 { get; set; }                       //値１
        public string? value2 { get; set; }                       //値２
        public string? biko { get; set; }                         //備考
        public string upduserid { get; set; }                     //更新ユーザーID
        public DateTime upddttm { get; set; }                     //更新日時
    }
}
