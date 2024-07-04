// *******************************************************************
// 業務名称　: 健康管理システム
// 機能概要　: コントロール情報保守
//             ビューモデル定義
// 作成日　　: 2023.07.18
// 作成者　　: 蔣
// 変更履歴　:
// *******************************************************************
namespace BCC.Affect.Service.AWAF00802G
{
    /// <summary>
    /// 検索処理
    /// </summary>
    public class SearchVM : SaveVM
    {
        public string itemnm { get; set; }         //項目名称
        public EnumDataType datatype { get; set; } //データ型
        public bool rangeflg { get; set; }         //範囲フラグ
    }

    /// <summary>
    /// 保存処理
    /// </summary>
    public class SaveVM
    {
        public string ctrlcd { get; set; }          //コントロールコード
        public object value { get; set; }           //値
        public string biko { get; set; }            //備考
        public DateTime upddttm { get; set; }       //更新日時
    }

    /// <summary>
    /// 値モデル
    /// </summary>
    public class ValueVM
    {
        public string? value1 { get; set; }     //値１
        public string? value2 { get; set; }     //値２
        public ValueVM(string? value1, string? value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }
    }
}